using DistroPartStock.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

class Program
{
    private static readonly string username = "eauclaire@ubreakfix.com";
    private static readonly string password = "Tompa12844!@!@";
    private static readonly string baseurl = "https://distro.ubif.net/index.php?route=account/login";

    static async Task Main(string[] args)
    {
        //Init
        var driver = new CustomWebDriver(BrowserType.Chrome).Driver;
        var loginPage = new LoginPage(driver);
        driver.Navigate().GoToUrl(baseurl);

        //Login
        var homePage = loginPage.Login(username, password);


        driver.Quit();
    }
}

