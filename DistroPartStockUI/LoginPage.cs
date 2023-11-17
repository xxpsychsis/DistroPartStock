using System.Net;

namespace DistroPartStock.Pages
{
    public class LoginPage
    {
        private readonly HttpClient _httpClient;
        private static readonly string PAGEURL = "https://distro.ubif.net/index.php?route=account/login"; // Replace with the actual login page URL
        private static readonly string USERNAME = "eauclaire@ubreakifix.com"; // Replace with the actual username
        private static readonly string PASSWORD = "Tompa12844!@!@"; // Replace with the actual password

        public LoginPage(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Login(string username, string password)
        {
            var formData = new Dictionary<string, string>
            {
                { "email", USERNAME },
                { "password", PASSWORD }
            };

            var content = new FormUrlEncodedContent(formData);
            var loginResponse = await _httpClient.PostAsync(PAGEURL, content);

            if (loginResponse.IsSuccessStatusCode)
            {
                foreach (var header in loginResponse.Headers)
                {
                    Console.WriteLine($"Header: {header.Key} - {string.Join(", ", header.Value)}");
                }

                // Extract distro_session token from headers or response content
                var distroSessionToken = GetDistroSessionToken(loginResponse);

                return distroSessionToken;
            }
            else
            {
                // Handle login failure
                return null;
            }
        }

        private string GetDistroSessionToken(HttpResponseMessage response)
        {
            // Check headers for the distro_session token
            if (response.Headers.TryGetValues("Set-Cookie", out var cookieValues))
            {
                foreach (var cookieValue in cookieValues)
                {
                    var cookie = new Cookie("distro_session", ""); // Use the appropriate cookie name
                    cookie.Value = cookieValue.Split(';')[0].Split('=')[1]; // Extract the value from the Set-Cookie header
                    return cookie.Value;
                }
            }

            // If not found in headers, you may need to extract from response content
            // Modify this part based on the actual structure of the response content
            var pageContent = response.Content.ReadAsStringAsync().Result;

            // Implement logic to extract the distro_session token from the content
            // You might use regular expressions, HTML parsing, or other methods based on the response content structure

            return null; // Return null if the token is not found
        }
    }
}

