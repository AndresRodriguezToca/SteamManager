using System.Windows.Forms;

namespace SteamManager
{
    partial class MainInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAccountInformation = new System.Windows.Forms.Label();
            this.btnLibraryCollection = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGameInventory = new System.Windows.Forms.Label();
            this.btnFriendList = new System.Windows.Forms.Label();
            this.btnMessages = new System.Windows.Forms.Label();
            this.btnNews = new System.Windows.Forms.Label();
            this.btnFreeGames = new System.Windows.Forms.Label();
            this.btnPricing = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.pBoxImage = new FontAwesome.Sharp.IconPictureBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.lbOwnedGamesCount = new System.Windows.Forms.Label();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.iconPictureBox5 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox6 = new FontAwesome.Sharp.IconPictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.iconPictureBoxAddAccount = new FontAwesome.Sharp.IconPictureBox();
            this.flowLayoutPanelContent = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxImage)).BeginInit();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBoxAddAccount)).BeginInit();
            this.flowLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.btnAccountInformation);
            this.flowLayoutPanel1.Controls.Add(this.btnLibraryCollection);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.btnGameInventory);
            this.flowLayoutPanel1.Controls.Add(this.btnFriendList);
            this.flowLayoutPanel1.Controls.Add(this.btnMessages);
            this.flowLayoutPanel1.Controls.Add(this.btnNews);
            this.flowLayoutPanel1.Controls.Add(this.btnFreeGames);
            this.flowLayoutPanel1.Controls.Add(this.btnPricing);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 9);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(273, 528);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.iconPictureBox4);
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 20);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(273, 39);
            this.flowLayoutPanel2.TabIndex = 27;
            // 
            // iconPictureBox4
            // 
            this.iconPictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox4.Cursor = System.Windows.Forms.Cursors.Default;
            this.iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.Steam;
            this.iconPictureBox4.IconColor = System.Drawing.Color.White;
            this.iconPictureBox4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox4.IconSize = 33;
            this.iconPictureBox4.Location = new System.Drawing.Point(3, 3);
            this.iconPictureBox4.Name = "iconPictureBox4";
            this.iconPictureBox4.Size = new System.Drawing.Size(34, 33);
            this.iconPictureBox4.TabIndex = 18;
            this.iconPictureBox4.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(43, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 31);
            this.label2.TabIndex = 15;
            this.label2.Text = "Steam Manager";
            // 
            // btnAccountInformation
            // 
            this.btnAccountInformation.AutoSize = true;
            this.btnAccountInformation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccountInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccountInformation.ForeColor = System.Drawing.Color.White;
            this.btnAccountInformation.Location = new System.Drawing.Point(3, 59);
            this.btnAccountInformation.Name = "btnAccountInformation";
            this.btnAccountInformation.Padding = new System.Windows.Forms.Padding(30, 20, 0, 0);
            this.btnAccountInformation.Size = new System.Drawing.Size(226, 44);
            this.btnAccountInformation.TabIndex = 17;
            this.btnAccountInformation.Text = "Account Information";
            this.btnAccountInformation.Click += new System.EventHandler(this.btnAccountInformation_Click);
            // 
            // btnLibraryCollection
            // 
            this.btnLibraryCollection.AutoSize = true;
            this.btnLibraryCollection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLibraryCollection.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLibraryCollection.ForeColor = System.Drawing.Color.White;
            this.btnLibraryCollection.Location = new System.Drawing.Point(3, 103);
            this.btnLibraryCollection.Name = "btnLibraryCollection";
            this.btnLibraryCollection.Padding = new System.Windows.Forms.Padding(30, 20, 0, 0);
            this.btnLibraryCollection.Size = new System.Drawing.Size(202, 44);
            this.btnLibraryCollection.TabIndex = 18;
            this.btnLibraryCollection.Text = "Library Collection";
            this.btnLibraryCollection.Click += new System.EventHandler(this.btnLibraryCollection_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 147);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(30, 20, 0, 0);
            this.label1.Size = new System.Drawing.Size(144, 44);
            this.label1.TabIndex = 36;
            this.label1.Text = "My Wishlist";
            // 
            // btnGameInventory
            // 
            this.btnGameInventory.AutoSize = true;
            this.btnGameInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGameInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGameInventory.ForeColor = System.Drawing.Color.White;
            this.btnGameInventory.Location = new System.Drawing.Point(3, 191);
            this.btnGameInventory.Name = "btnGameInventory";
            this.btnGameInventory.Padding = new System.Windows.Forms.Padding(30, 20, 0, 0);
            this.btnGameInventory.Size = new System.Drawing.Size(219, 44);
            this.btnGameInventory.TabIndex = 32;
            this.btnGameInventory.Text = "My Game Inventory";
            this.btnGameInventory.Click += new System.EventHandler(this.btnGameInventory_Click);
            // 
            // btnFriendList
            // 
            this.btnFriendList.AutoSize = true;
            this.btnFriendList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFriendList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFriendList.ForeColor = System.Drawing.Color.White;
            this.btnFriendList.Location = new System.Drawing.Point(3, 235);
            this.btnFriendList.Name = "btnFriendList";
            this.btnFriendList.Padding = new System.Windows.Forms.Padding(30, 20, 0, 0);
            this.btnFriendList.Size = new System.Drawing.Size(181, 44);
            this.btnFriendList.TabIndex = 19;
            this.btnFriendList.Text = "My Friends List";
            this.btnFriendList.Click += new System.EventHandler(this.btnFriendList_Click);
            // 
            // btnMessages
            // 
            this.btnMessages.AutoSize = true;
            this.btnMessages.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMessages.ForeColor = System.Drawing.Color.White;
            this.btnMessages.Location = new System.Drawing.Point(3, 279);
            this.btnMessages.Name = "btnMessages";
            this.btnMessages.Padding = new System.Windows.Forms.Padding(30, 20, 0, 0);
            this.btnMessages.Size = new System.Drawing.Size(134, 44);
            this.btnMessages.TabIndex = 33;
            this.btnMessages.Text = "Messages";
            this.btnMessages.Click += new System.EventHandler(this.btnMessages_Click);
            // 
            // btnNews
            // 
            this.btnNews.AutoSize = true;
            this.btnNews.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNews.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNews.ForeColor = System.Drawing.Color.White;
            this.btnNews.Location = new System.Drawing.Point(3, 323);
            this.btnNews.Name = "btnNews";
            this.btnNews.Padding = new System.Windows.Forms.Padding(30, 20, 0, 0);
            this.btnNews.Size = new System.Drawing.Size(156, 44);
            this.btnNews.TabIndex = 28;
            this.btnNews.Text = "Steam News";
            this.btnNews.Click += new System.EventHandler(this.btnNews_Click);
            // 
            // btnFreeGames
            // 
            this.btnFreeGames.AutoSize = true;
            this.btnFreeGames.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFreeGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFreeGames.ForeColor = System.Drawing.Color.White;
            this.btnFreeGames.Location = new System.Drawing.Point(3, 367);
            this.btnFreeGames.Name = "btnFreeGames";
            this.btnFreeGames.Padding = new System.Windows.Forms.Padding(30, 20, 0, 0);
            this.btnFreeGames.Size = new System.Drawing.Size(219, 44);
            this.btnFreeGames.TabIndex = 30;
            this.btnFreeGames.Text = "Steam Free Games";
            this.btnFreeGames.Click += new System.EventHandler(this.btnFreeGames_Click);
            // 
            // btnPricing
            // 
            this.btnPricing.AutoSize = true;
            this.btnPricing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPricing.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPricing.ForeColor = System.Drawing.Color.White;
            this.btnPricing.Location = new System.Drawing.Point(3, 411);
            this.btnPricing.Name = "btnPricing";
            this.btnPricing.Padding = new System.Windows.Forms.Padding(30, 20, 0, 0);
            this.btnPricing.Size = new System.Drawing.Size(169, 44);
            this.btnPricing.TabIndex = 35;
            this.btnPricing.Text = "Steam Pricing";
            this.btnPricing.Click += new System.EventHandler(this.btnPricing_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel3.Controls.Add(this.pBoxImage);
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(9, 576);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(273, 56);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // pBoxImage
            // 
            this.pBoxImage.BackColor = System.Drawing.Color.Transparent;
            this.pBoxImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.pBoxImage.IconChar = FontAwesome.Sharp.IconChar.Image;
            this.pBoxImage.IconColor = System.Drawing.Color.White;
            this.pBoxImage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pBoxImage.IconSize = 53;
            this.pBoxImage.Location = new System.Drawing.Point(3, 3);
            this.pBoxImage.Name = "pBoxImage";
            this.pBoxImage.Size = new System.Drawing.Size(59, 53);
            this.pBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxImage.TabIndex = 17;
            this.pBoxImage.TabStop = false;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel5);
            this.flowLayoutPanel4.Controls.Add(this.lblUsername);
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(65, 0);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(205, 56);
            this.flowLayoutPanel4.TabIndex = 18;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.iconPictureBox2);
            this.flowLayoutPanel5.Controls.Add(this.lbOwnedGamesCount);
            this.flowLayoutPanel5.Controls.Add(this.iconPictureBox3);
            this.flowLayoutPanel5.Controls.Add(this.label7);
            this.flowLayoutPanel5.Controls.Add(this.iconPictureBox5);
            this.flowLayoutPanel5.Controls.Add(this.iconPictureBox6);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(0, 31);
            this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(205, 25);
            this.flowLayoutPanel5.TabIndex = 19;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Gamepad;
            this.iconPictureBox2.IconColor = System.Drawing.Color.White;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 22;
            this.iconPictureBox2.Location = new System.Drawing.Point(3, 3);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(22, 22);
            this.iconPictureBox2.TabIndex = 18;
            this.iconPictureBox2.TabStop = false;
            // 
            // lbOwnedGamesCount
            // 
            this.lbOwnedGamesCount.AutoSize = true;
            this.lbOwnedGamesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOwnedGamesCount.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbOwnedGamesCount.Location = new System.Drawing.Point(31, 3);
            this.lbOwnedGamesCount.Margin = new System.Windows.Forms.Padding(3);
            this.lbOwnedGamesCount.Name = "lbOwnedGamesCount";
            this.lbOwnedGamesCount.Size = new System.Drawing.Size(15, 16);
            this.lbOwnedGamesCount.TabIndex = 18;
            this.lbOwnedGamesCount.Text = "0";
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.Message;
            this.iconPictureBox3.IconColor = System.Drawing.Color.White;
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox3.IconSize = 22;
            this.iconPictureBox3.Location = new System.Drawing.Point(52, 3);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(22, 22);
            this.iconPictureBox3.TabIndex = 19;
            this.iconPictureBox3.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label7.Location = new System.Drawing.Point(80, 3);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "0";
            // 
            // iconPictureBox5
            // 
            this.iconPictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconPictureBox5.IconChar = FontAwesome.Sharp.IconChar.Gear;
            this.iconPictureBox5.IconColor = System.Drawing.Color.White;
            this.iconPictureBox5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox5.IconSize = 22;
            this.iconPictureBox5.Location = new System.Drawing.Point(101, 3);
            this.iconPictureBox5.Name = "iconPictureBox5";
            this.iconPictureBox5.Size = new System.Drawing.Size(22, 22);
            this.iconPictureBox5.TabIndex = 21;
            this.iconPictureBox5.TabStop = false;
            // 
            // iconPictureBox6
            // 
            this.iconPictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconPictureBox6.IconChar = FontAwesome.Sharp.IconChar.DoorClosed;
            this.iconPictureBox6.IconColor = System.Drawing.Color.White;
            this.iconPictureBox6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox6.IconSize = 22;
            this.iconPictureBox6.Location = new System.Drawing.Point(129, 3);
            this.iconPictureBox6.Name = "iconPictureBox6";
            this.iconPictureBox6.Size = new System.Drawing.Size(22, 22);
            this.iconPictureBox6.TabIndex = 22;
            this.iconPictureBox6.TabStop = false;
            this.iconPictureBox6.Click += new System.EventHandler(this.iconPictureBox6_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblUsername.Location = new System.Drawing.Point(3, 11);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(148, 20);
            this.lblUsername.TabIndex = 17;
            this.lblUsername.Text = "Steam Username";
            // 
            // iconPictureBoxAddAccount
            // 
            this.iconPictureBoxAddAccount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconPictureBoxAddAccount.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBoxAddAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconPictureBoxAddAccount.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.iconPictureBoxAddAccount.IconColor = System.Drawing.Color.White;
            this.iconPictureBoxAddAccount.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBoxAddAccount.IconSize = 36;
            this.iconPictureBoxAddAccount.Location = new System.Drawing.Point(0, 0);
            this.iconPictureBoxAddAccount.Margin = new System.Windows.Forms.Padding(0);
            this.iconPictureBoxAddAccount.Name = "iconPictureBoxAddAccount";
            this.iconPictureBoxAddAccount.Size = new System.Drawing.Size(36, 39);
            this.iconPictureBoxAddAccount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconPictureBoxAddAccount.TabIndex = 18;
            this.iconPictureBoxAddAccount.TabStop = false;
            this.iconPictureBoxAddAccount.Click += new System.EventHandler(this.iconPictureBoxAddAccount_Click);
            // 
            // flowLayoutPanelContent
            // 
            this.flowLayoutPanelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelContent.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelContent.Location = new System.Drawing.Point(285, 9);
            this.flowLayoutPanelContent.Name = "flowLayoutPanelContent";
            this.flowLayoutPanelContent.Size = new System.Drawing.Size(780, 623);
            this.flowLayoutPanelContent.TabIndex = 2;
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel6.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel6.Controls.Add(this.iconPictureBoxAddAccount);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(9, 537);
            this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(273, 39);
            this.flowLayoutPanel6.TabIndex = 3;
            // 
            // MainInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 641);
            this.Controls.Add(this.flowLayoutPanel6);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanelContent);
            this.Name = "MainInterface";
            this.Text = "MainInterface";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxImage)).EndInit();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBoxAddAccount)).EndInit();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label btnAccountInformation;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label btnLibraryCollection;
        private System.Windows.Forms.Label btnFriendList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private FontAwesome.Sharp.IconPictureBox pBoxImage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Label lbOwnedGamesCount;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label7;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox5;
        private System.Windows.Forms.Label btnNews;
        private System.Windows.Forms.Label btnFreeGames;
        private System.Windows.Forms.Label btnGameInventory;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelContent;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox6;
        private System.Windows.Forms.Label btnMessages;
        private System.Windows.Forms.Label btnPricing;
        private System.Windows.Forms.Label label1;
        private FlowLayoutPanel flowLayoutPanel6;
        private FontAwesome.Sharp.IconPictureBox iconPictureBoxAddAccount;
    }
}