using Newtonsoft.Json;
using SteamManager.Class;
using SteamManager.InterfaceControls;
using SteamManager.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SteamManager.Class.SteamOwnedGames;

namespace SteamManager
{
    public partial class AccountInformationControl : UserControl
    {
        private SteamApiClient steamApiClient;
        private SteamAccount steamAccount;
        private SteamOwnedGames steamOwnedGames;
        private SteamAccountSecondary steamAccountSecondary;

        public AccountInformationControl()
        {
            InitializeComponent();
        }

        public AccountInformationControl(SteamApiClient steamApiClient, SteamAccount steamAccount, SteamOwnedGames steamOwnedGames, SteamAccountSecondary steamAccountSecondary)
        {
            InitializeComponent();

            this.steamApiClient = steamApiClient;
            this.steamAccount = steamAccount;
            this.steamOwnedGames = steamOwnedGames;
            this.steamAccountSecondary = steamAccountSecondary;

            //VARIABLES
            int rowIndex = 0;
            int columnIndex = 0;

            if (steamAccount != null)
            {
                //ADD GAME
                PictureBox pictureBoxAccount = new PictureBox();
                pictureBoxAccount.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxAccount.ImageLocation = steamAccount.getAvatarFull;
                tableLayoutAccount.Controls.Add(pictureBoxAccount, columnIndex, rowIndex);
                //RESIZE FIRST ROW FROM LIBRARY COLLECTION
                for (int i = 0; i < tableLayoutAccount.RowCount; i++)
                {
                    tableLayoutAccount.RowStyles[i] = new RowStyle(SizeType.Absolute, 150);
                }
                columnIndex++;

                // CHECK IF COLUMN EXCEEDS THE LIMIT COLUMNS
                if (columnIndex >= tableLayoutAccount.ColumnCount)
                {
                    //SET BACK TO 0
                    columnIndex = 0;
                    //ADD A NEW ROW
                    rowIndex++;
                }
            }
            // ADD SECONDARY ACCOUNTS
            foreach (SteamAccount account in steamAccountSecondary.GetAllSteamAccounts())
            {
                //ADD GAME
                PictureBox pictureBoxAccount = new PictureBox();
                pictureBoxAccount.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxAccount.ImageLocation = account.getAvatarFull;
                tableLayoutAccount.Controls.Add(pictureBoxAccount, columnIndex, rowIndex);
                //RESIZE FIRST ROW FROM LIBRARY COLLECTION
                for (int i = 0; i < tableLayoutAccount.RowCount; i++)
                {
                    tableLayoutAccount.RowStyles[i] = new RowStyle(SizeType.Absolute, 150);
                }
                columnIndex++;

                // CHECK IF COLUMN EXCEEDS THE LIMIT COLUMNS
                if (columnIndex >= tableLayoutAccount.ColumnCount)
                {
                    //SET BACK TO 0
                    columnIndex = 0;
                    //ADD A NEW ROW
                    rowIndex++;
                }
            }
        }
    }
}
