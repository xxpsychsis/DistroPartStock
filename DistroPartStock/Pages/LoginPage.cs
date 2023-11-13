namespace DistroPartStock.Pages
{
    public class LoginPage
    {
        private readonly HttpClient _httpClient;
        public LoginPage(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private static readonly string USERNAME = "eauclaire@ubreakfix.com";
        private static readonly string PASSWORD = "Tompa120844!*!!";
        private static readonly string LOGINURL = "https://distro.ubif.net/index.php?route=account/login";

        public async Task<bool> Login()
        {
            var formData = new Dictionary<string, string>
            {
                { "email", USERNAME }, // Using the name of the email input field
                { "password", PASSWORD } // Using the name of the password input field
             };

            var content = new FormUrlEncodedContent(formData);
            var loginResponse = await _httpClient.PostAsync(LOGINURL, content);
            return loginResponse.IsSuccessStatusCode;
        }
    }
}
