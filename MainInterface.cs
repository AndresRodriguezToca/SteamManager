using SteamManager.Class;
using SteamManager.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace SteamManager
{
    public partial class MainInterface : Form
    {
        //GENERAL VARIABLES
        SteamApiClient steamApiClient;
        SteamAccount steamAccount;
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
    }
}
