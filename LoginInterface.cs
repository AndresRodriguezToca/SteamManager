using Steam.Models.DOTA2;
using SteamManager.Class;
using SteamManager.Services;
using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Models;
using SteamWebAPI2.Utilities;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SteamManager
{
    public partial class LoginInterface : Form
    {
        //GLOBALS
        private const string SteamWebAPIBaseUrl = "https://api.steampowered.com";
        private const string ValidateEndPoint = "/ISteamUserAuth/AuthenticateUserTicket/v1/";

        public LoginInterface()
        {
            InitializeComponent();
            CenterToScreen();
            //ADDITIONAL STYLES
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            SetBackgroundGradient(Color.FromArgb(23, 26, 33));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //ADD BACKGROUND GRADIENT EFFECT
        private void SetBackgroundGradient(Color baseColor)
        {
            Color darkerColor = Color.FromArgb(baseColor.R - 10, baseColor.G - 10, baseColor.B - 10);

            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                this.ClientRectangle,
                baseColor,
                darkerColor,
                LinearGradientMode.Vertical);

            this.Paint += (sender, e) =>
            {
                e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);
            };
        }

        //SIGN IN STEAM
        private async void btnSignIn_Click(object sender, EventArgs e)
        {
            //GET VALUES FROM INPUT BOXES
            String steamID = tbUsername.Text;
            String sdk = tbSDK.Text;

            //VALIDATE
            if (steamID == ""){
                System.Windows.Forms.MessageBox.Show("Invalid Username");
                return;
            }
            if (sdk == ""){
                System.Windows.Forms.MessageBox.Show("Invalid SDK");
                return;
            }

            //INITIATE CLIENT
            SteamApiClient client = new SteamApiClient(sdk);
            SteamAccount steamAccount = await client.ValidateUserAPI(sdk, steamID);

            //VALIDATE STEAM INFORMATION
            if (steamAccount != null)
            {
                //OPEN APPLICATION
                this.Hide();
                MainInterface mainInterface = new MainInterface(client, steamAccount);
                mainInterface.Closed += (s, args) => this.Close();
                mainInterface.Show();

            } else {
                //POP ERROR
                System.Windows.Forms.MessageBox.Show("Could not adquire your account information. Make sure the SDK and SteamID are correct, and try again!");
                return;
            }


        }

        //CLOSE APPLICATION
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //REFERENCE 
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://steamcommunity.com/id/andsilenxer/");
        }

    }
}
