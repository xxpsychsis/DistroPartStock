using DistroPartStock.Pages.Smartphone.Samsung;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace DistroPartStock.Pages
{
    public class HomePage
    {


        private IWebElement ProductsDropDown => _driver.FindElement(By.XPath("//a[@class='dropbtn' and contains(text(), 'Products')]"));
        private IWebElement SmartphoneDropdown => _driver.FindElement(By.XPath("//a[@class='dropbtn' and contains(text(), 'Smartphone')]"));
        private IWebElement Samsung => _driver.FindElement(By.XPath("//a[@class='dropbtn' and contains(text(), 'Samsung')]"));


        private readonly IWebDriver _driver;
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }


        public SamsungPage NavigateToSamsungPage()
        {
            Actions actions = new(_driver);

            actions.MoveToElement(ProductsDropDown).Perform();
            actions.MoveToElement(SmartphoneDropdown).Perform();
            Samsung.Click();

            return new SamsungPage(_driver);
        }

    }
}
