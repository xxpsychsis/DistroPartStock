using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DistroPartStock.Pages.Smartphone.Samsung
{
    /// <summary>
    /// Samsung Base Page, This page Lists all the Phones
    /// </summary>
    public class SamsungPage
    {
        private readonly IWebDriver _driver;
        public SamsungPage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
