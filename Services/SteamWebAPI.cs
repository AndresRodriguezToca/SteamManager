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
    using SteamManager.Class;
    using SteamWebAPI2.Models;

    public class SteamApiClient
    {
        //LIBRARY BASE ON https://steamapi.xpaw.me/ by xPaw
        private const string SteamApiBaseUrl = "https://api.steampowered.com";
        private const string iSteamUser = "iSteamUser"; //Steam provides API calls to provide information about Steam users.
        private const string ISteamNews = "ISteamNews"; //Steam provides methods to fetch news feeds for each Steam game.
        private const string ISteamUserStats = "ISteamUserStats"; //Steam provides methods to fetch global stat information by game.
        private const string IPlayerService = "IPlayerService"; //Provides additional methods for interacting with Steam Users.

        //ENCRYPTER (IN CASE I NEEDED FOR STEAM)
        private Encrypter Encrypter = new Encrypter();
        private const int byteCount = 32;

        private readonly HttpClient httpClient;
        private readonly string apiKey;
        private readonly string steamID;
        SteamOwnedGames steamOwnedGames;

        public SteamApiClient(string apiKey, string steamID)
        {
            this.apiKey = apiKey;
            this.steamID = steamID;
            this.httpClient = new HttpClient();
        }

        public async Task<SteamAccount> ValidateUserAPI()
        {

            try
            {
                // Send a POST request to the Steam API for user authentication
                var request = new HttpRequestMessage(HttpMethod.Get, $"{SteamApiBaseUrl}/{iSteamUser}/GetPlayerSummaries/v0002/?key={this.apiKey}&steamids={this.steamID}");

                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                Console.WriteLine(response);
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
