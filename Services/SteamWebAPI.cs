using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamManager.Services
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using SteamWebAPI2.Models;

    public class SteamApiClient
    {
        private const string SteamApiBaseUrl = "https://api.steampowered.com";
        private Encrypter Encrypter = new Encrypter();
        private const int byteCount = 32;

        private readonly HttpClient httpClient;
        private readonly string apiKey;

        public SteamApiClient(string apiKey)
        {
            this.apiKey = apiKey;
            this.httpClient = new HttpClient();
        }

        public async Task<string> ValidateUserAPI(string sdk, string steamID)
        {

            try
            {
                // Send a POST request to the Steam API for user authentication
                var request = new HttpRequestMessage(HttpMethod.Get, $"{SteamApiBaseUrl}/ISteamUser/GetPlayerSummaries/v0002/?key={sdk}&steamids={steamID}");

                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                Console.WriteLine(response);
                var responseContent = await response.Content.ReadAsStringAsync();

                // Print the response content
                Console.WriteLine(responseContent);

                if(responseContent.StatusCode = )
            }
            catch (Exception)
            {
                return "INVALID";
            }
        }

        private string ParseSteamIdFromResponse(string response)
        {
            // Parse the response JSON to extract the SteamID
            // Replace this with your own JSON parsing logic to extract the SteamID
            // The response JSON structure will depend on the specific Steam API endpoint you are using
            // Consult the Steam Web API documentation for the appropriate response structure
            // Here's an example assuming the response contains a field named "steamid"
            var steamId = "1234567890"; // Replace with your parsing logic

            return steamId;
        }
    }
}
