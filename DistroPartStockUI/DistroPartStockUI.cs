using DistroPartStock.Pages;
using System.Net;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace DistroPartStockUI
{
    public partial class DistroPartStockUI : Form
    {
        LoginPage loginPage;
        HttpClient client;
        CookieContainer cookies;
        private List<string> urlList = new List<string>();
        List<ProductInfo> products = new List<ProductInfo>();
        private BindingList<ProductInfo> phoneDataList = new BindingList<ProductInfo>();


        private static readonly string homePageUrl = "https://distro.ubif.net/index.php?route=common/home";
        public DistroPartStockUI()
        {
            InitializeComponent();
            //Init HttpClient
            cookies = new();
            HttpClientHandler handler = new();
            handler.CookieContainer = cookies;
            client = new(handler);

            //Init Pages
            loginPage = new LoginPage(client);
            dataGridView.DataSource = phoneDataList;
            dataGridView.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["ProductName"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView.CellFormatting += DataGridView_CellFormatting;

        }


        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the current cell is in the "OnHand" column
            if (dataGridView.Columns[e.ColumnIndex].Name == "OnHand")
            {
                // Check if the cell value is "Out Of Stock"
                if (e.Value != null && e.Value.ToString() == "Out of Stock")
                {
                    // Apply bold font style
                    e.CellStyle.Font = new System.Drawing.Font(dataGridView.Font, System.Drawing.FontStyle.Bold);
                }
            }
        }

        private async Task Login()
        {
            var username = usernameTextBox.Text;
            var password = passwordTextbox.Text;
            await loginPage.Login(username, password); //these arent actually being used yet, theyre still hard coded
            var loginSucceeded = await VerifyUserLoggedIn();
            if (loginSucceeded)
            {
                LoginPanel.Visible = false;
            }
            //Clear the Text Box Values
            usernameTextBox.Text = "";
            passwordTextbox.Text = "";

            //Enable Rest Of Form
            settingsPanel.Visible = true;
        }

        private async Task<bool> VerifyUserLoggedIn()
        {
            var response = await client.GetAsync(homePageUrl);
            var pageContent = await response.Content.ReadAsStringAsync();
            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(pageContent);
            var productTitle = htmlDocument.DocumentNode.SelectSingleNode("//title");

            if (productTitle.InnerHtml == "uBreakiFix by Asurion Distribution ")
            {
                Console.WriteLine("Login Successful");
                return true;
            }
            else
            {
                return false;
            }

        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            await Login();
        }

        private async void ScrapeButton_Click(object sender, EventArgs e)
        {

            var filePath = settingsFilePath.Text;
            string json = File.ReadAllText(filePath);

            JObject jsonObject = JObject.Parse(json);

            foreach (JProperty phoneProperty in jsonObject["Phones"].Children())
            {
                string phoneName = phoneProperty.Name;
                bool scrape = (bool)phoneProperty.Value["Scrape"];
                string url = (string)phoneProperty.Value["Url"];

                if (scrape)
                {
                    urlList.Add(url);
                }
            }
            var phonesToCheck = urlList.Count;
            var phonesChecked = 0;
            progressBar.Visible = true;
            progressBar.Maximum = phonesToCheck;
            foreach (var url in urlList)
            {
                progressBar.Value = phonesChecked;
                await ScrapeWebsiteData(url);
                phonesChecked++;
            }
            dataGridView.Refresh();
            exportBox.Visible = true;
            progressBar.Value = 0;
            progressBar.Visible = false;
        }


        private async Task ScrapeWebsiteData(string pageUrl)
        {
            var response = await client.GetAsync(pageUrl);
            var pageContent = await response.Content.ReadAsStringAsync();

            // Load the HTML content into HtmlDocument
            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(pageContent);

            // Select all product tiles within the product grid
            var productTiles = htmlDocument.DocumentNode.SelectNodes("//div[@class='product-grid']/div[@class='product-tile']");

            if (productTiles != null)
            {
                foreach (var productTile in productTiles)
                {
                    // Select relevant elements within the product tile
                    var productNameNode = productTile.SelectSingleNode(".//div[@class='caption']//a");
                    var modelNode = productTile.SelectSingleNode(".//div[@class='caption']/div[@class='details']/small[@class='text-info']");
                    var onHandNode = productTile.SelectSingleNode(".//div[@class='caption']/div[@class='details']/small[@class='text-danger']");

                    // Create an object to hold the information
                    var productInfo = new ProductInfo
                    {
                        ProductName = productNameNode?.GetAttributeValue("title", ""),
                        SKU = modelNode?.InnerText.Trim(),
                        OnHand = onHandNode?.InnerText.Trim()
                    };
                    if (productInfo.ProductName != null)
                    {
                        Console.WriteLine(productInfo.ProductName);
                        if (productInfo.ProductName.Contains("UB Display"))
                        {
                            products.Add(productInfo);
                            phoneDataList.Add(productInfo);
                        }
                        if (productInfo.ProductName.Contains("Glass/LCD"))
                        {
                            products.Add(productInfo);
                            phoneDataList.Add(productInfo);
                        }
                    }

                }
            }

        }

        private void browseSettingsFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a File";
                openFileDialog.Filter = "JSON Files|*.json";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Display the selected file path in the TextBox
                    settingsFilePath.Text = openFileDialog.FileName;

                    // You can also use openFileDialog.FileName to get the selected file path
                    // Do whatever you need with the file path
                }
            }
        }

    }
}