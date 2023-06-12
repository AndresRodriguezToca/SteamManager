using System.Collections.Generic;

namespace SteamManager.Class
{
    public class SteamAccountSecondary
    {
        // Private fields
        private List<SteamAccount> steamAccounts;
        private List<SteamOwnedGames> steamOwnedGames;

        // Constructor
        public SteamAccountSecondary()
        {
            steamAccounts = new List<SteamAccount>();
            steamOwnedGames = new List<SteamOwnedGames>();
        }

        // Getter and Setter properties
        public List<SteamAccount> GetSetSteamAccounts
        {
            get { return steamAccounts; }
            set { steamAccounts = value; }
        }

        public List<SteamOwnedGames> GetSetSteamOwnedGames
        {
            get { return steamOwnedGames; }
            set { steamOwnedGames = value; }
        }
    }
}
