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

        //FUNCTION TO GET ALL STEAM SECONDARY ACCOUNTS
        public List<SteamAccount> GetAllSteamAccounts()
        {
            return steamAccounts;
        }

        //FUNCTION TO GET ALL STEAM OWNED SECONDARY GAMES
        public List<SteamOwnedGames> GetAllSteamOwnedGames()
        {
            return steamOwnedGames;
        }
    }
}
