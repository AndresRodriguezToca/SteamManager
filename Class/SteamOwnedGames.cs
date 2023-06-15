using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SteamManager.Class
{
    public class SteamOwnedGames
    {
        public List<Game> Games { get; }

        public SteamOwnedGames(string jsonData)
        {
            Games = new List<Game>();
            ParseJson(jsonData);
        }

        private void ParseJson(string jsonData)
        {
            dynamic parsedData = JsonConvert.DeserializeObject(jsonData);
            dynamic gameData = parsedData?.response?.games;

            if (gameData != null)
            {
                foreach (dynamic game in gameData)
                {
                    int appId = game.ContainsKey("appid") ? game["appid"] : 0;
                    string name = game.ContainsKey("name") ? game["name"] : string.Empty;
                    int playtimeForever = game.ContainsKey("playtime_forever") ? game["playtime_forever"] : 0;
                    int playtime2Weeks = game.ContainsKey("playtime_2weeks") ? game["playtime_2weeks"] : 0;
                    string iconUrl = game.ContainsKey("img_icon_url") ? game["img_icon_url"] : string.Empty;
                    bool hasCommunityVisibleStats = game.ContainsKey("has_community_visible_stats") ? game["has_community_visible_stats"] : false;
                    int playtimeWindowsForever = game.ContainsKey("playtime_windows_forever") ? game["playtime_windows_forever"] : 0;
                    int playtimeMacForever = game.ContainsKey("playtime_mac_forever") ? game["playtime_mac_forever"] : 0;
                    int playtimeLinuxForever = game.ContainsKey("playtime_linux_forever") ? game["playtime_linux_forever"] : 0;
                    int lastPlayedTime = game.ContainsKey("rtime_last_played") ? game["rtime_last_played"] : 0;
                    bool hasLeaderboards = game.ContainsKey("has_leaderboards") ? game["has_leaderboards"] : false;

                    Game newGame = new Game(appId, name, playtimeForever, iconUrl, hasCommunityVisibleStats, playtimeWindowsForever, playtimeMacForever, playtimeLinuxForever, lastPlayedTime, hasLeaderboards);
                    Games.Add(newGame);

                    // Additional variables
                    newGame.GameType = game.ContainsKey("gameType") ? game["gameType"] : string.Empty;
                    newGame.ShortDescription = game.ContainsKey("short_description") ? game["short_description"] : string.Empty;
                    newGame.SupportedLanguage = game.ContainsKey("supported_language") ? game["supported_language"] : string.Empty;
                    newGame.Developers = game.ContainsKey("developers") ? game["developers"] : string.Empty;
                    newGame.Publishers = game.ContainsKey("publishers") ? game["publishers"] : string.Empty;
                    newGame.PriceFinalFormatted = game.ContainsKey("price_final_formatted") ? game["price_final_formatted"] : string.Empty;
                    newGame.PlatformsWindows = game.ContainsKey("platforms_windows") ? game["platforms_windows"] : string.Empty;
                    newGame.PlatformsMac = game.ContainsKey("platforms_mac") ? game["platforms_mac"] : string.Empty;
                    newGame.PlatformsLinux = game.ContainsKey("platforms_linux") ? game["platforms_linux"] : string.Empty;
                    newGame.Metacritic = game.ContainsKey("metacritic") ? game["metacritic"] : string.Empty;
                    newGame.Categories = game.ContainsKey("categories") ? game["categories"] : string.Empty;
                    newGame.Genres = game.ContainsKey("genres") ? game["genres"] : string.Empty;
                }
            }
        }

        public int GetOwnedGamesCount()
        {
            return Games.Count;
        }

        public class Game
        {
            public int AppId { get; }
            public string Name { get; }
            public int PlaytimeForever { get; }
            public string IconUrl { get; }
            public bool HasCommunityVisibleStats { get; }
            public int PlaytimeWindowsForever { get; }
            public int PlaytimeMacForever { get; }
            public int PlaytimeLinuxForever { get; }
            public int LastPlayedTime { get; }
            public bool HasLeaderboards { get; }

            // Additional variables
            public string GameType { get; set; }
            public string ShortDescription { get; set; }
            public string SupportedLanguage { get; set; }
            public string Developers { get; set; }
            public string Publishers { get; set; }
            public string PriceFinalFormatted { get; set; }
            public string PlatformsWindows { get; set; }
            public string PlatformsMac { get; set; }
            public string PlatformsLinux { get; set; }
            public string Metacritic { get; set; }
            public string Categories { get; set; }
            public string Genres { get; set; }

            public Game(int appId, string name, int playtimeForever, string iconUrl, bool hasCommunityVisibleStats, int playtimeWindowsForever, int playtimeMacForever, int playtimeLinuxForever, int lastPlayedTime, bool hasLeaderboards)
            {
                AppId = appId;
                Name = name;
                PlaytimeForever = playtimeForever;
                IconUrl = iconUrl;
                HasCommunityVisibleStats = hasCommunityVisibleStats;
                PlaytimeWindowsForever = playtimeWindowsForever;
                PlaytimeMacForever = playtimeMacForever;
                PlaytimeLinuxForever = playtimeLinuxForever;
                LastPlayedTime = lastPlayedTime;
                HasLeaderboards = hasLeaderboards;
            }
        }

        public override string ToString()
        {
            string result = "";
            foreach (Game game in Games)
            {
                result += $"AppId: {game.AppId}\n";
                result += $"Name: {game.Name}\n";
                result += $"PlaytimeForever: {game.PlaytimeForever}\n";
                result += $"IconUrl: {game.IconUrl}\n";
                result += $"HasCommunityVisibleStats: {game.HasCommunityVisibleStats}\n";
                result += $"PlaytimeWindowsForever: {game.PlaytimeWindowsForever}\n";
                result += $"PlaytimeMacForever: {game.PlaytimeMacForever}\n";
                result += $"PlaytimeLinuxForever: {game.PlaytimeLinuxForever}\n";
                result += $"LastPlayedTime: {game.LastPlayedTime}\n";
                result += $"HasLeaderboards: {game.HasLeaderboards}\n";
                result += $"GameType: {game.GameType}\n";
                result += $"ShortDescription: {game.ShortDescription}\n";
                result += $"SupportedLanguage: {game.SupportedLanguage}\n";
                result += $"Developers: {game.Developers}\n";
                result += $"Publishers: {game.Publishers}\n";
                result += $"PriceFinalFormatted: {game.PriceFinalFormatted}\n";
                result += $"PlatformsWindows: {game.PlatformsWindows}\n";
                result += $"PlatformsMac: {game.PlatformsMac}\n";
                result += $"PlatformsLinux: {game.PlatformsLinux}\n";
                result += $"Metacritic: {game.Metacritic}\n";
                result += $"Categories: {game.Categories}\n";
                result += $"Genres: {game.Genres}\n\n";
            }
            return result;
        }
    }
}
