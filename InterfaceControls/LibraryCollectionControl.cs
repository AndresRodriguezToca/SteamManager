using Newtonsoft.Json;
using SteamManager.Class;
using SteamManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GoogleTranslateFreeApi;

namespace SteamManager
{
    // Define Genre class
    public class Genre
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }

    public partial class LibraryCollectionControl : UserControl
    {
        public LibraryCollectionControl(SteamApiClient steamApiClient, SteamAccount steamAccount, SteamOwnedGames steamOwnedGames, SteamAccountSecondary steamAccountSecondary)
        {
            InitializeComponent();


            //POP ACCOUNT LIBRARIES
            cbxLibrary.Items.Clear();
            cbxLibrary.Items.Add(steamAccount.getPersonName);
            //POP SECONDARY ACCOUNT LIBRARIES
            List<SteamAccount> allAccounts = steamAccountSecondary.GetAllSteamAccounts();
            foreach (SteamAccount account in allAccounts)
            {
                // Access individual Steam account properties or perform operations
                cbxLibrary.Items.Add(account.getPersonName);
            }

            // POP ALL POSSIBLE GENRES
            HashSet<string> uniqueGenres = new HashSet<string>();

            // ADD GENDERS
            foreach (SteamOwnedGames.Game game in steamOwnedGames.Games)
            {
                if (!string.IsNullOrEmpty(game.Genres))
                {
                    var genres = JsonConvert.DeserializeObject<List<Genre>>(game.Genres);
                    foreach (var genre in genres)
                    {
                        if (!string.IsNullOrEmpty(genre.Description))
                        {
                            uniqueGenres.Add(genre.Description);
                        }
                    }
                }
            }

            // ADD ALL OTHER GENDERS (SECONDARY ACCOUNTS)
            List<SteamOwnedGames> allGames = steamAccountSecondary.GetAllSteamOwnedGames();
            foreach (SteamOwnedGames ownedGames in allGames)
            {
                foreach (SteamOwnedGames.Game game in ownedGames.Games)
                {
                    if (!string.IsNullOrEmpty(game.Genres))
                    {
                        var genres = JsonConvert.DeserializeObject<List<Genre>>(game.Genres);
                        foreach (var genre in genres)
                        {
                            if (!string.IsNullOrEmpty(genre.Description))
                            {
                                uniqueGenres.Add(genre.Description);
                            }
                        }
                    }
                }
            }

            //TRANSLATE ANY NON_ENGLISH WORD
            TranslateGenresToEnglish(uniqueGenres);
            cbxGenre.Items.AddRange(uniqueGenres.ToArray());
        }

        //THIS METHOD TRANSLATE USING GOOGLET
        private void TranslateGenresToEnglish(HashSet<string> genres)
        {
            var translator = new GoogleTranslator();
            var englishGenres = new HashSet<string>();

            foreach (var genre in genres)
            {
                if (!IsEnglish(genre))
                {
                    var translation = translator.TranslateAsync(genre, Language.Auto, Language.English).Result;
                    englishGenres.Add(translation.MergedTranslation);
                }
                else
                {
                    englishGenres.Add(genre);
                }
            }

            genres.Clear();
            genres.UnionWith(englishGenres);
        }

        //CHECK IF IS ENGLISH OR NOT
        private bool IsEnglish(string text)
        {
            // Check if the text is already in English
            return text.All(c => c < 128);
        }

    }

}
