using HtmlAgilityPack;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var httpClient = new HttpClient();

        var loginUrl = "https://distro.ubif.net/index.php?route=account/login"; // Login URL
        var username = "eauclaire@ubreakfix.com"; // Replace with your email
        var password = "Tompa120844!*!!"; // Replace with your password

        var formData = new Dictionary<string, string>
        {
            { "email", username }, // Using the name of the email input field
            { "password", password } // Using the name of the password input field
        };

        var content = new FormUrlEncodedContent(formData);
        var loginResponse = await httpClient.PostAsync(loginUrl, content);

        if (loginResponse.IsSuccessStatusCode)
        {
            Console.WriteLine("Login successful!");

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
        else
        {
            Console.WriteLine("Login failed.");
        }
    }
}
