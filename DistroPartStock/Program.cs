using DistroPartStock.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

class Program
{
    private static readonly string username = "eauclaire@ubreakifix.com";
    private static readonly string password = "Tompa12844!@!@";
    private static readonly string baseurl = "https://distro.ubif.net/index.php?route=account/login";

    static async Task Main(string[] args)
    {
        //Init
        var browser = BrowserType.Chrome;
        var driver = new CustomWebDriver(browser).Driver;
        var loginPage = new LoginPage(driver);
        driver.Navigate().GoToUrl(baseurl);

        //Login
        var homePage = loginPage.Login(username, password);
        var samsungPage = homePage.NavigateToSamsungPage();
        var galaxyS23FePage = samsungPage.SelectSamsungGalaxyS23Fe();

        galaxyS23FePage.GetProductDetails();

        driver.Quit();
    }
}

