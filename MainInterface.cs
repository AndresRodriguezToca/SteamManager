using SteamManager.Class;
using SteamManager.Services;
using System;
using System.Net;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Security.Principal;
using FontAwesome.Sharp;
using SteamManager.InterfaceControls;

namespace SteamManager
{

    public partial class MainInterface : Form
    {
        //AVOID DEADLOCK !!!
        public async Task FetchDataAndSetupInterfaceElements()
        {
            //FETCH ADDITIONAL DATA
            //GET OWNED GAMES
            this.steamOwnedGames = await steamApiClient.GetOwnerGames(steamAccount);
        }

        //GENERAL VARIABLES
        SteamApiClient steamApiClient;
        SteamAccount steamAccount;
        SteamOwnedGames steamOwnedGames;
        SteamAccountSecondary steamAccountSecondary = new SteamAccountSecondary();

        //CONTROLS
        AccountInformationControl accountInformationControl = new AccountInformationControl();
        LibraryCollectionControl libraryCollectionControl = new LibraryCollectionControl();
        GameInventoryControl gameInventoryControl = new GameInventoryControl();
        FriendsListControl friendsListControl = new FriendsListControl();
        MessagesControl messagesControl = new MessagesControl();
        NewsControl newsControl = new NewsControl();
        FreeGamesControl freeGamesControl = new FreeGamesControl();
        PricingControl pricingControl = new PricingControl();

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
            // Apply the GraphicsPath to the control's Region property
            // Create a GraphicsPath object to define the shape
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pBoxImage.Width, pBoxImage.Height);
            pBoxImage.Region = new Region(path);

            //NAVIGATION BUTTONS
            unselectNavigationButtons();

            iconPictureBoxAddAccount.MouseEnter += MouseEnterPictureBox;
            iconPictureBoxAddAccount.MouseLeave += MouseLeavePictureBox;

            //FETCH DATA AND SETUP DINAMYC INTERFACE ELEMENTS
            Task.Run(async () =>
            {
                await FetchDataAndSetupInterfaceElements();

                //SETUP ELEMENTS
                // -- IMAGE USERNAME
                pBoxImage.IconChar = IconChar.None;
                WebRequest request = WebRequest.Create(steamAccount.getAvatarFull);
                WebResponse response = await request.GetResponseAsync();
                System.IO.Stream responseStream = response.GetResponseStream();
                pBoxImage.BackgroundImage = new System.Drawing.Bitmap(responseStream);
                pBoxImage.BackgroundImageLayout = ImageLayout.Stretch;
                //USERNAME TEXT
                this.Invoke((Action)(() => lblUsername.Text = (steamAccount.getPersonName) + " (" + steamAccount.GetStatusAsString() + ")"));
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

        private void btnAccountInformation_Click(object sender, EventArgs e)
        {
            //CLEAR PANEL
            flowLayoutPanelContent.Controls.Clear();

            //CLEAR NAVIGATION SELECTION
            unselectNavigationButtons();

            //ACTIVATE CLICKED NAVIGATION BUTTON
            selectNavigationButtons(btnAccountInformation);

            // SIZE
            accountInformationControl.Width = flowLayoutPanelContent.ClientSize.Width;
            accountInformationControl.Height = flowLayoutPanelContent.ClientSize.Height;

            //ADD CONTROL
            flowLayoutPanelContent.Controls.Add(accountInformationControl);

        }

        private void btnLibraryCollection_Click(object sender, EventArgs e)
        {
            //CLEAR PANEL
            flowLayoutPanelContent.Controls.Clear();

            //CLEAR NAVIGATION SELECTION
            unselectNavigationButtons();

            //ACTIVATE CLICKED NAVIGATION BUTTON
            selectNavigationButtons(btnLibraryCollection);

            // SIZE
            libraryCollectionControl.Width = flowLayoutPanelContent.ClientSize.Width;
            libraryCollectionControl.Height = flowLayoutPanelContent.ClientSize.Height;

            //ADD CONTROL
            flowLayoutPanelContent.Controls.Add(libraryCollectionControl);

        }

        private void btnGameInventory_Click(object sender, EventArgs e)
        {
            //CLEAR PANEL
            flowLayoutPanelContent.Controls.Clear();

            //CLEAR NAVIGATION SELECTION
            unselectNavigationButtons();

            //ACTIVATE CLICKED NAVIGATION BUTTON
            selectNavigationButtons(btnGameInventory);

            // SIZE
            gameInventoryControl.Width = flowLayoutPanelContent.ClientSize.Width;
            gameInventoryControl.Height = flowLayoutPanelContent.ClientSize.Height;

            //ADD CONTROL
            flowLayoutPanelContent.Controls.Add(gameInventoryControl);
        }

        private void btnFriendList_Click(object sender, EventArgs e)
        {
            //CLEAR PANEL
            flowLayoutPanelContent.Controls.Clear();

            //CLEAR NAVIGATION SELECTION
            unselectNavigationButtons();

            //ACTIVATE CLICKED NAVIGATION BUTTON
            selectNavigationButtons(btnFriendList);

            // SIZE
            friendsListControl.Width = flowLayoutPanelContent.ClientSize.Width;
            friendsListControl.Height = flowLayoutPanelContent.ClientSize.Height;

            //ADD CONTROL
            flowLayoutPanelContent.Controls.Add(friendsListControl);
        }

        private void btnMessages_Click(object sender, EventArgs e)
        {
            //CLEAR PANEL
            flowLayoutPanelContent.Controls.Clear();

            //CLEAR NAVIGATION SELECTION
            unselectNavigationButtons();

            //ACTIVATE CLICKED NAVIGATION BUTTON
            selectNavigationButtons(btnMessages);

            // SIZE
            messagesControl.Width = flowLayoutPanelContent.ClientSize.Width;
            messagesControl.Height = flowLayoutPanelContent.ClientSize.Height;

            //ADD CONTROL
            flowLayoutPanelContent.Controls.Add(messagesControl);
        }

        private void btnNews_Click(object sender, EventArgs e)
        {
            //CLEAR PANEL
            flowLayoutPanelContent.Controls.Clear();

            //CLEAR NAVIGATION SELECTION
            unselectNavigationButtons();

            //ACTIVATE CLICKED NAVIGATION BUTTON
            selectNavigationButtons(btnNews);

            // SIZE
            newsControl.Width = flowLayoutPanelContent.ClientSize.Width;
            newsControl.Height = flowLayoutPanelContent.ClientSize.Height;

            //ADD CONTROL
            flowLayoutPanelContent.Controls.Add(newsControl);
        }

        private void btnFreeGames_Click(object sender, EventArgs e)
        {
            //CLEAR PANEL
            flowLayoutPanelContent.Controls.Clear();

            //CLEAR NAVIGATION SELECTION
            unselectNavigationButtons();

            //ACTIVATE CLICKED NAVIGATION BUTTON
            selectNavigationButtons(btnFreeGames);

            // SIZE
            freeGamesControl.Width = flowLayoutPanelContent.ClientSize.Width;
            freeGamesControl.Height = flowLayoutPanelContent.ClientSize.Height;

            //ADD CONTROL
            flowLayoutPanelContent.Controls.Add(freeGamesControl);
        }

        private void btnPricing_Click(object sender, EventArgs e)
        {
            //CLEAR PANEL
            flowLayoutPanelContent.Controls.Clear();

            //CLEAR NAVIGATION SELECTION
            unselectNavigationButtons();

            //ACTIVATE CLICKED NAVIGATION BUTTON
            selectNavigationButtons(btnPricing);

            // SIZE
            pricingControl.Width = flowLayoutPanelContent.ClientSize.Width;
            pricingControl.Height = flowLayoutPanelContent.ClientSize.Height;

            //ADD CONTROL
            flowLayoutPanelContent.Controls.Add(pricingControl);
        }

        //ANIMATION FOR NAVIGATION OPTIONS
        private void mouseEnterNav(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = Color.DodgerBlue;
        }

        private void mouseLeaveNav(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = Color.White;
        }

        private void MouseEnterPictureBox(object sender, EventArgs e)
        {
            IconPictureBox iconPictureBox = (IconPictureBox)sender;
            iconPictureBox.IconColor = Color.DodgerBlue;
        }

        private void MouseLeavePictureBox(object sender, EventArgs e)
        {
            IconPictureBox iconPictureBox = (IconPictureBox)sender;
            iconPictureBox.IconColor = Color.White;
        }


        private void unselectNavigationButtons()
        {
            btnAccountInformation.ForeColor = Color.White;
            btnLibraryCollection.ForeColor = Color.White;
            btnGameInventory.ForeColor = Color.White;
            btnFriendList.ForeColor = Color.White;
            btnMessages.ForeColor = Color.White;
            btnNews.ForeColor = Color.White;
            btnFreeGames.ForeColor = Color.White;
            btnPricing.ForeColor = Color.White;
            btnAccountInformation.MouseEnter -= mouseEnterNav;
            btnLibraryCollection.MouseEnter -= mouseEnterNav;
            btnGameInventory.MouseEnter -= mouseEnterNav;
            btnFriendList.MouseEnter -= mouseEnterNav;
            btnMessages.MouseEnter -= mouseEnterNav;
            btnNews.MouseEnter -= mouseEnterNav;
            btnFreeGames.MouseEnter -= mouseEnterNav;
            btnPricing.MouseEnter -= mouseEnterNav;
            btnAccountInformation.MouseLeave -= mouseLeaveNav;
            btnLibraryCollection.MouseLeave -= mouseLeaveNav;
            btnGameInventory.MouseLeave -= mouseLeaveNav;
            btnFriendList.MouseLeave -= mouseLeaveNav;
            btnMessages.MouseLeave -= mouseLeaveNav;
            btnNews.MouseLeave -= mouseLeaveNav;
            btnFreeGames.MouseLeave -= mouseLeaveNav;
            btnPricing.MouseLeave -= mouseLeaveNav;
            btnAccountInformation.MouseEnter += mouseEnterNav;
            btnLibraryCollection.MouseEnter += mouseEnterNav;
            btnGameInventory.MouseEnter += mouseEnterNav;
            btnFriendList.MouseEnter += mouseEnterNav;
            btnMessages.MouseEnter += mouseEnterNav;
            btnNews.MouseEnter += mouseEnterNav;
            btnFreeGames.MouseEnter += mouseEnterNav;
            btnPricing.MouseEnter += mouseEnterNav;
            btnAccountInformation.MouseLeave += mouseLeaveNav;
            btnLibraryCollection.MouseLeave += mouseLeaveNav;
            btnGameInventory.MouseLeave += mouseLeaveNav;
            btnFriendList.MouseLeave += mouseLeaveNav;
            btnMessages.MouseLeave += mouseLeaveNav;
            btnNews.MouseLeave += mouseLeaveNav;
            btnFreeGames.MouseLeave += mouseLeaveNav;
            btnPricing.MouseLeave += mouseLeaveNav;
        }

        private void selectNavigationButtons(Label selectedLabel)
        {
            selectedLabel.ForeColor = Color.SteelBlue;
            selectedLabel.MouseEnter -= mouseEnterNav;
            selectedLabel.MouseLeave -= mouseLeaveNav;
        }

        //ASK ADDITIONAL STEAM ID (ADD IF PROVIDED)
        private async void iconPictureBoxAddAccount_Click(object sender, EventArgs e)
        {
            using (AddSteamAccount inputDialog = new AddSteamAccount())
            {
                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    //GET STEAM ID FROM INPUT BOX
                    string userInput = inputDialog.steamID;

                    //VALIDATE STEAM ACCOUNT;
                    SteamApiClient tempClient = new SteamApiClient(steamApiClient.getAPIKey, userInput);
                    SteamAccount tempSteamAccount = await tempClient.ValidateUserAPI();
                    if (tempSteamAccount != null)
                    {
                        steamAccountSecondary.GetSetSteamAccounts.Add(tempSteamAccount);
                        SteamOwnedGames tempSteamOwnedGames = await tempClient.GetOwnerGames(tempSteamAccount);
                        steamAccountSecondary.GetSetSteamOwnedGames.Add(tempSteamOwnedGames);

                        //ADD PROFILE TO MAIN FRAME LAYOUT
                        ToolTip tooltip = new ToolTip();
                        IconPictureBox iconPictureBox = new IconPictureBox();
                        iconPictureBox.Anchor = AnchorStyles.None;
                        iconPictureBox.BackColor = Color.Transparent;
                        iconPictureBox.IconColor = Color.White;
                        iconPictureBox.IconFont = IconFont.Auto;
                        iconPictureBox.IconSize = 36;
                        iconPictureBox.Margin = new Padding(0);
                        iconPictureBox.TabStop = false;
                        iconPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                        tooltip.SetToolTip(iconPictureBox, tempSteamAccount.getPersonName);
                        // -- IMAGE USERNAME
                        iconPictureBox.IconChar = IconChar.None;
                        WebRequest request = WebRequest.Create(tempSteamAccount.getAvatarFull);
                        WebResponse response = await request.GetResponseAsync();
                        System.IO.Stream responseStream = response.GetResponseStream();
                        iconPictureBox.BackgroundImage = new Bitmap(responseStream);
                        iconPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                        GraphicsPath path = new GraphicsPath();
                        path.AddEllipse(0, 0, iconPictureBox.Width, iconPictureBox.Height);
                        iconPictureBox.Region = new Region(path);

                        // Add the IconPictureBox at the beginning of the FlowLayoutPanel
                        flowLayoutPanel6.Controls.Add(iconPictureBox);
                        flowLayoutPanel6.Controls.SetChildIndex(iconPictureBox, 0);

                    }
                    else
                    {
                        MessageBox.Show("Steam Account not Found!");
                    }
                }
            }
        }
    }
}
