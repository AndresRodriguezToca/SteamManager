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
    using System.Windows;
    using System.Xml.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using SteamManager.Class;
    using SteamWebAPI2.Interfaces;
    using SteamWebAPI2.Models;
    using static SteamManager.Class.SteamOwnedGames;

    public class SteamApiClient
    {
        //LIBRARY BASE ON https://steamapi.xpaw.me/ by xPaw
        private const string SteamApiBaseUrl = "https://api.steampowered.com";
        private const string StoreSteamPowered = "https://store.steampowered.com";
        private const string iSteamUser = "iSteamUser"; //Steam provides API calls to provide information about Steam users.
        private const string ISteamNews = "ISteamNews"; //Steam provides methods to fetch news feeds for each Steam game.
        private const string ISteamUserStats = "ISteamUserStats"; //Steam provides methods to fetch global stat information by game.
        private const string IPlayerService = "IPlayerService"; //Provides additional methods for interacting with Steam Users.
        private const string AppDetails = "api/appdetails"; //Steam returns game information

        //ENCRYPTER (IN CASE I NEEDED FOR STEAM)
        private Encrypter Encrypter = new Encrypter();
        private const int byteCount = 32;

        private readonly HttpClient httpClient;
        private readonly string apiKey;
        private readonly string steamID;

        public SteamApiClient(string apiKey, string steamID)
        {
            this.apiKey = apiKey;
            this.steamID = steamID;
            this.httpClient = new HttpClient();
        }

        public string getAPIKey { get { return apiKey; } }
        public string getSteamID { get { return steamID; } }

        public async Task<SteamAccount> ValidateUserAPI()
        {

            try
            {
                // Send a POST request to the Steam API for user authentication
                var request = new HttpRequestMessage(HttpMethod.Get, $"{SteamApiBaseUrl}/{iSteamUser}/GetPlayerSummaries/v0002/?key={this.apiKey}&steamids={this.steamID}");

                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (responseContent != null)
                {
                    SteamAccount steamAccount = new SteamAccount(responseContent);
                    return steamAccount;
                } else
                {
                    return null;
                }

                
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<SteamOwnedGames> GetOwnerGames(SteamAccount steamAccount)
        {
            try
            {
                // Send a POST request to the Steam API for user authentication
                var request = new HttpRequestMessage(HttpMethod.Get, $"{SteamApiBaseUrl}/{IPlayerService}/GetOwnedGames/v1/?key={this.apiKey}&steamid={this.steamID}&include_appinfo=true&include_played_free_games=true");
                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (responseContent != null)
                {
                    //GET EACH GAME INDIVIDUALLY
                    dynamic parsedData = JsonConvert.DeserializeObject(responseContent);
                    dynamic gameData = parsedData?.response?.games;

                    foreach (dynamic game in gameData)
                    {
                        //GET ADDITIONAL GAME INFORMATION
                        var appid = game.appid.ToString();
                        var request2 = new HttpRequestMessage(HttpMethod.Get, $"{StoreSteamPowered}/{AppDetails}?appids={appid}");
                        var response2 = await httpClient.SendAsync(request2, HttpCompletionOption.ResponseHeadersRead);
                        var responseContent2 = await response2.Content.ReadAsStringAsync();
                        //ADD TO ARRAY
                        var gameDetails = JsonConvert.DeserializeObject<dynamic>(responseContent2);
                        // Check if the necessary properties exist in the gameDetails object
                        var gameType = gameDetails[appid]?.data?.type?.ToString();
                        var short_description = gameDetails[appid]?.data?.short_description?.ToString();
                        var supported_language = gameDetails[appid]?.data?.supported_languages?.ToString();
                        var developers = gameDetails[appid]?.data?.developers?.ToString();
                        var publishers = gameDetails[appid]?.data?.publishers?.ToString();
                        var price_final_formatted = gameDetails[appid]?.data?.price_overview?.final_formatted?.ToString();
                        var platforms_windows = gameDetails[appid]?.data?.platforms?.windows?.ToString();
                        var platforms_mac = gameDetails[appid]?.data?.platforms?.mac?.ToString();
                        var platforms_linux = gameDetails[appid]?.data?.platforms?.linux?.ToString();
                        var metacritic = gameDetails[appid]?.data?.metacritic?.score?.ToString();
                        var categories = gameDetails[appid]?.data?.categories?.ToString();
                        var genres = gameDetails[appid]?.data?.genres?.ToString();

                        // Add variables to the gameData object
                        game.gameType = gameType;
                        game.short_description = short_description;
                        game.supported_language = supported_language;
                        game.developers = developers;
                        game.publishers = publishers;
                        game.price_final_formatted = price_final_formatted;
                        game.platforms_windows = platforms_windows;
                        game.platforms_mac = platforms_mac;
                        game.platforms_linux = platforms_linux;
                        game.metacritic = metacritic;
                        game.categories = categories;
                        game.genres = genres;
                    }

                    // Serialize the updated gameData back to JSON
                    responseContent = JsonConvert.SerializeObject(parsedData);

                    SteamOwnedGames steamOwnedGames = new SteamOwnedGames(responseContent);
                    return steamOwnedGames;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}
