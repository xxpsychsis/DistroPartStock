using DistroPartStock.Pages;
using HtmlAgilityPack;

class Program
{
    static async Task Main(string[] args)
    {
        //Init Pages
        var httpClient = new HttpClient();
        var loginPage = new LoginPage(httpClient);
        var homePage = new HomePage(httpClient);


        //Login
        var loginResponse = await loginPage.Login();
        if (loginResponse)
        {
            //login should probably be moved to a json file? so it can be changed easier
            throw new Exception("Login Failed, Please Verify Login Credentials");
        }




        var scrapingUrl = "https://distro.ubif.net/index.php?route=common/home"; // The URL of the page you want to scrape
        // After login, fetch the page for scraping
        var response = await httpClient.GetAsync(scrapingUrl);
        var pageContent = await response.Content.ReadAsStringAsync();

        var doc = new HtmlDocument();
        doc.LoadHtml(pageContent);

        // Scrape data
        // Example: doc.DocumentNode.SelectNodes("XPATH_EXPRESSION")
        // Replace "XPATH_EXPRESSION" with the actual XPath to locate the data you want
        // ...
    }
}
