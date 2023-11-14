using DistroPartStock.Pages;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.ComponentModel;
using System.Security.Policy;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;

namespace DistroPartStockUI
{
    public partial class DistroPartStockUI : Form
    {
        LoginPage loginPage;
        HttpClient client;
        private List<string> urlList = new List<string>();
        List<ProductInfo> products = new List<ProductInfo>();

        private static readonly string homePageUrl = "https://distro.ubif.net/index.php?route=common/home";
        public DistroPartStockUI()
        {
            InitializeComponent();
            //Init HttpClient
            CookieContainer cookies = new();
            HttpClientHandler handler = new();
            handler.CookieContainer = cookies;
            client = new(handler);

            //Init Pages
            loginPage = new LoginPage(client);
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
            foreach (Control c in Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    if (cb.Checked == true)
                    {
                        var textValue = (cb.Text).Replace(" ", "");
                        if (Enum.TryParse<SettingsEnum>(textValue, out SettingsEnum enumValue))
                        {
                            Console.WriteLine("Value Was Not Parsed Successfully");
                            var url = GetEnumDescription(enumValue);
                            urlList.Add(url);
                        }                       
                    }
                }
            }
            foreach(var url in urlList)
            {
                await ScrapeWebsiteData(url);
            }
            SaveToCsv();
        }


        private void SaveToCsv()
        {
            using (var writer = new StreamWriter("C:\\Users\\Damien Sprinkle\\Desktop\\output.csv"))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(products);
            }
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
                        Model = modelNode?.InnerText.Trim(),
                        OnHand = onHandNode?.InnerText.Trim()
                    };
                    products.Add(productInfo);
                }
            }

        }


        private static string GetEnumDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}