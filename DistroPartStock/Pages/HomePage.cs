using DistroPartStock.Pages.Smartphone.Samsung;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DistroPartStock.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }


        public SamsungPage NavigateToSamsungPage()
        {

            return new SamsungPage(_driver);
        }

    }
}
