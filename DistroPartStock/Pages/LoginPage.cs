using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DistroPartStock.Pages
{
    public class LoginPage
    {
        private static readonly string PageUrl = "https://distro.ubif.net/index.php?route=account/login";

        private IWebElement EmailInput => _driver.FindElement(By.Id("input-email"));
        private IWebElement PasswordInput => _driver.FindElement(By.Id("input-password"));
        private IWebElement LoginButton => _driver.FindElement(By.XPath("//button")); //generic and bad but its the only button

        private readonly IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }



        public HomePage Login(string email, string password)
        {
            EmailInput.SendKeys(email);
            PasswordInput.SendKeys(password);
            LoginButton.Click();
            return new HomePage(_driver);
        }


    }
}
