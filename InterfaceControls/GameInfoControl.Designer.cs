using System;
using System.Drawing;
using System.Windows.Forms;

namespace SteamManager.InterfaceControls
{
    partial class GameInfoControl : UserControl
    {

        public void SetGameInfo(string gameName, string gameID, string additionalInfo)
        {
            // PICTURE
            pictureBox.ImageLocation = "https://cdn.cloudflare.steamstatic.com/steam/apps/" + gameID + "/header.jpg";

            // GAME NAME
            lblGameName.Text = gameName;
        }

        private PictureBox pictureBox;
        private Label lblGameName;
    }
}
