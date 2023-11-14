using HtmlAgilityPack;
using System.Net.Http;

namespace DistroPartStock.Pages.Smartphone.Samsung
{
    public class SamsungGalaxyS23FEPage
    {
        private readonly HttpClient _httpClient;
        private static readonly string PAGEURL = "https://distro.ubif.net/index.php?route=product/category&path=1637_110_3232&limit=999";

        public SamsungGalaxyS23FEPage(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task GetProductDetails()
        {
            var response = await _httpClient.GetAsync(PAGEURL);
            var pageContent = await response.Content.ReadAsStringAsync();

            // Load the HTML content into HtmlDocument
            var htmlDocument = new HtmlDocument();
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
                    var productInfo = new
                    {
                        ProductName = productNameNode?.GetAttributeValue("title", ""),
                        Model = modelNode?.InnerText.Trim(),
                        OnHand = onHandNode?.InnerText.Trim()
                    };

                    // Print or do whatever you want with the product information
                    Console.WriteLine($"Product Name: {productInfo.ProductName}");
                    Console.WriteLine($"Model: {productInfo.Model}");
                    Console.WriteLine($"On Hand: {productInfo.OnHand}");
                    Console.WriteLine();
                }
            }
        }
    }
}
