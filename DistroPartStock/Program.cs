using HtmlAgilityPack;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using DistroPartStock.Pages;
using System.Net;
using System.Reflection.Metadata;
using DistroPartStock.Pages.Smartphone.Samsung;

class Program
{
    static async Task Main(string[] args)
    {
        //Init HttpClient
        CookieContainer cookies = new CookieContainer();
        HttpClientHandler handler = new HttpClientHandler();
        handler.CookieContainer = cookies;
        HttpClient client = new HttpClient(handler);

        //Init Pages
        var loginPage = new LoginPage(client);
        var samsungGalaxyS23FEPage = new SamsungGalaxyS23FEPage(client);


        //Login 
        await loginPage.Login();



        await samsungGalaxyS23FEPage.GetProductDetails();


    }
}
