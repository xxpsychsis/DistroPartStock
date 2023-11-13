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
        private IWebElement SamsungGalaxyS23FeBtn => _driver.FindElement(By.XPath("//h2[contains(text(), 'Samsung Galaxy S23 FE')]"));


        private readonly IWebDriver _driver;
        public SamsungPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public SamsungGalaxyS23FEPage SelectSamsungGalaxyS23Fe()
        {
            SamsungGalaxyS23FeBtn.Click();
            Thread.Sleep(5000);

            return new SamsungGalaxyS23FEPage(_driver);
        }
    }
}
