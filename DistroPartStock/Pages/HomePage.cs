using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistroPartStock.Pages
{
    public class HomePage
    {
        private readonly HttpClient _httpClient;
        public HomePage(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

    }
}
