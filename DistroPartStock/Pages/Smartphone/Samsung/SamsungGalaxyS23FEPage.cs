using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.ObjectModel;

namespace DistroPartStock.Pages.Smartphone.Samsung
{
    public class SamsungGalaxyS23FEPage
    {
        ReadOnlyCollection<IWebElement> productTiles => _driver.FindElements(By.CssSelector(".product-grid .product-tile"));


        private readonly IWebDriver _driver;
        public SamsungGalaxyS23FEPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GetProductDetails()
        {
            foreach (var productTile in productTiles)
            {
                // Find elements within each product tile
                var productNameElement = productTile.FindElement(By.CssSelector(".caption a[title]"));
                var modelElement = productTile.FindElement(By.CssSelector(".caption .details .text-info"));
                var onHandElement = productTile.FindElement(By.CssSelector(".caption .details .text-danger"));

                // Get the text from the elements
                var productName = productNameElement.Text;
                var model = modelElement.Text;
                var onHand = onHandElement.Text;

                // Print or do whatever you want with the extracted information
                Console.WriteLine($"Product Name: {productName}");
                Console.WriteLine($"Model: {model}");
                Console.WriteLine($"On Hand: {onHand}");
                Console.WriteLine();
            }

        }

    }
}
