namespace DistroPartStock.Pages.Smartphone.Samsung
{
    /// <summary>
    /// Samsung Base Page, This page Lists all the Phones
    /// </summary>
    public class SamsungPage
    {
        private readonly HttpClient _httpClient;
        public SamsungPage(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
