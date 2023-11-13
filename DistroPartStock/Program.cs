using DistroPartStock.Pages;
using DistroPartStock.Pages.Smartphone.Samsung;
using HtmlAgilityPack;
using System;
using System.Net;
using System.Net.Http;

class Program
{
    private static readonly string USERNAME = "eauclaire@ubreakfix.com";
    private static readonly string PASSWORD = "Tompa12844!@!@";
    private static readonly string AUTHURL = "https://distro.ubif.net/index.php?route=account/login";

    static async Task Main(string[] args)
    {
        //Setup and Login
        CookieContainer cookies = new CookieContainer();
        HttpClientHandler handler = new HttpClientHandler();
        handler.CookieContainer = cookies;

        HttpClient httpClient = new HttpClient(handler);

        var formData = new Dictionary<string, string>
            {
                { "email", USERNAME },
                { "password", PASSWORD }
            };

        var content = new FormUrlEncodedContent(formData);
        Uri uri = new Uri("https://distro.ubif.net/index.php?route=product/category&path=1637_110_3232&limit=999");
        HttpResponseMessage response = await httpClient.PostAsync(AUTHURL, content);
        IEnumerable<Cookie> responseCookies = cookies.GetCookies(uri).Cast<Cookie>();

        foreach (Cookie cookie in responseCookies)
            Console.WriteLine(cookie.Name + ": " + cookie.Value);

        response = await httpClient.GetAsync("https://distro.ubif.net/index.php?route=product/category&path=1637_110_3232&limit=999");

        var pageContent = await response.Content.ReadAsStringAsync();
        //Init Pages
        var samsungGalaxys23FEPage = new SamsungGalaxyS23FEPage(httpClient);
        await samsungGalaxys23FEPage.GetProductDetails();


        }

    }

