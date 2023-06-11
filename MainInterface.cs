using SteamManager.Class;
using SteamManager.Services;
using System;
using System.Net;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace SteamManager
{

    public partial class MainInterface : Form
    {
        //AVOID DEADLOCK !!!
        public async Task FetchDataAndSetupInterfaceElements()
        {
            //FETCH ADDITIONAL DATA
            this.steamOwnedGames = await steamApiClient.GetOwnerGames(steamAccount);
        }

        //GENERAL VARIABLES
        SteamApiClient steamApiClient;
        SteamAccount steamAccount;
        SteamOwnedGames steamOwnedGames;
        public MainInterface(SteamApiClient steamApiClient, SteamAccount steamAccount)
        {
            //ASSIGN VARIABLES
            this.steamApiClient = steamApiClient;
            this.steamAccount = steamAccount;

            //INITIALIZE COMPONENETS AND STYLES
            InitializeComponent();
            CenterToScreen();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            SetBackgroundGradient(Color.FromArgb(23, 26, 33));

            //FETCH DATA AND SETUP INTERFACE ELEMENTS
            Task.Run(async () =>
            {
                await FetchDataAndSetupInterfaceElements();

                //SETUP ELEMENTS

                //IMAGE USERNAME
                pBoxImage.IconChar = FontAwesome.Sharp.IconChar.None;
                WebRequest request = WebRequest.Create(steamAccount.getAvatarFull);
                WebResponse response = await request.GetResponseAsync();
                System.IO.Stream responseStream = response.GetResponseStream();
                pBoxImage.BackgroundImage = new System.Drawing.Bitmap(responseStream);
                pBoxImage.BackgroundImageLayout = ImageLayout.Stretch;
                //USERNAME TEXT
                this.Invoke((Action)(() => lblUsername.Text = steamAccount.getPersonName));
                //OWNED GAMES COUNT
                if (steamOwnedGames != null)
                {
                    string ownedGamesCount = steamOwnedGames.Games.Count.ToString();
                    this.Invoke((Action)(() => lbOwnedGamesCount.Text = ownedGamesCount));
                }


            }).ConfigureAwait(true);
        }

        //ADD BACKGROUND GRADIENT EFFECT
        private void SetBackgroundGradient(Color baseColor)
        {
            Color darkerColor = Color.FromArgb(baseColor.R - 10, baseColor.G - 10, baseColor.B - 10);

            this.Paint += (sender, e) =>
            {
                using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
                    this.ClientRectangle,
                    baseColor,
                    darkerColor,
                    LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);
                }
            };

            this.Resize += (sender, e) =>
            {
                this.Invalidate();
            };
        }

        private void iconPictureBox6_Click(object sender, EventArgs e)
        {
            //OPEN APPLICATION
            this.Hide();
            LoginInterface loginInterface = new LoginInterface();
            loginInterface.Closed += (s, args) => this.Close();
            loginInterface.Show();
        }
    }
}
