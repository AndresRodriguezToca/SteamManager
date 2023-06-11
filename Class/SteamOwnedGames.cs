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

        //PARSE JSON TO ARRAY FORMAT
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
                }
            }
        }

        public int GetOwnedGamesCount()
        {
            return Games.Count;
        }

        public class Game
        {
            // GETTERS
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

            // SETTER
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
    }
}
