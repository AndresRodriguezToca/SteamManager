using Newtonsoft.Json;
using SteamManager.Class;
using SteamManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GoogleTranslateFreeApi;
using SteamManager.InterfaceControls;

namespace SteamManager
{

    public partial class LibraryCollectionControl : UserControl
    {
        public LibraryCollectionControl(SteamApiClient steamApiClient, SteamAccount steamAccount, SteamOwnedGames steamOwnedGames, SteamAccountSecondary steamAccountSecondary)
        {
            InitializeComponent();
            int rowIndex = 0;
            int columnIndex = 0;


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

            // ADD GENDERS & GAMES TO COLLECTION
            foreach (SteamOwnedGames.Game game in steamOwnedGames.Games)
            {
                //ADD GENRE
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

                //ADD GAME
                var gameInfoControl = new GameInfoControl();
                gameInfoControl.SetGameInfo(game.Name, game.AppId.ToString(), GetAdditionalInfo(game));
                gameInfoControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
                tableLayoutPanel1.Controls.Add(gameInfoControl, columnIndex, rowIndex);
                //RESIZE FIRST ROW FROM LIBRARY COLLECTION
                for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
                {
                    tableLayoutPanel1.RowStyles[i] = new RowStyle(SizeType.Absolute, 150);
                }
                columnIndex++;

                // CHECL IF COLUMN EXCEEDS THE LIMIT COLUMNS
                if (columnIndex >= tableLayoutPanel1.ColumnCount)
                {
                    //SET BACK TO 0
                    columnIndex = 0;
                    //ADD A NEW ROW
                    rowIndex++;
                }
            }

            // ADD ALL OTHER GENDERS (SECONDARY ACCOUNTS) AND GAMES TO COLLECTION
            List<SteamOwnedGames> allGames = steamAccountSecondary.GetAllSteamOwnedGames();
            foreach (SteamOwnedGames ownedGames in allGames)
            {
                foreach (SteamOwnedGames.Game game in ownedGames.Games)
                {
                    //ADD GENRE
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

        //GETS GAME INFORMATION
        private string GetAdditionalInfo(SteamOwnedGames.Game game)
        {
            // Customize the additional information as you desire
            // For example, concatenate the properties you want to display
            return $"App ID: {game.AppId}, Playtime: {game.PlaytimeForever}, Genre: {game.Genres}, Publisher: {game.Publishers}";
        }

    }

    // GENRE CLASS
    public class Genre
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }

}
