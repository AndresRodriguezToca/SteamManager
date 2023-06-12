using SteamWebAPI2.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SteamManager.InterfaceControls
{
    public partial class AddSteamAccount : UserControl
    {
        public string steamID { get; private set; }
        public AddSteamAccount()
        {
            InitializeComponent();
        }

        internal DialogResult ShowDialog()
        {
            using (Form dialogForm = new Form())
            {
                // CENTER ON THE SCREEN
                dialogForm.StartPosition = FormStartPosition.CenterScreen;
                // REMOVE WINDOWS NAVIGATION
                dialogForm.FormBorderStyle = FormBorderStyle.None;

                // Customize the dialogForm according to your needs
                dialogForm.Size = new Size(358, 214);
                dialogForm.Controls.Add(this);

                // Modify the control properties to match the provided layout
                this.iconPictureBox2.Location = new System.Drawing.Point(51, 63);
                this.label1.Location = new System.Drawing.Point(48, 42);
                this.panel2.Location = new System.Drawing.Point(99, 63);
                this.tableLayoutPanel1.Location = new System.Drawing.Point(51, 114);
                this.tableLayoutPanel1.RowCount = 2;

                // Create the Add Account button
                Button btnAddSteamSign = new Button();
                btnAddSteamSign.Text = "ADD ACCOUNT";
                btnAddSteamSign.BackColor = Color.DodgerBlue;
                btnAddSteamSign.ForeColor = Color.White;
                btnAddSteamSign.FlatStyle = FlatStyle.Flat;
                btnAddSteamSign.FlatAppearance.BorderSize = 0;
                btnAddSteamSign.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                btnAddSteamSign.Click += btnAddSteamSign_Click;
                btnAddSteamSign.Size = new Size(120, 41); // Set the size to 120x41
                this.tableLayoutPanel1.Controls.Add(btnAddSteamSign, 0, 0);
                this.tableLayoutPanel1.SetColumnSpan(btnAddSteamSign, 2);

                // Create the Go Back button
                Button btnClose = new Button();
                btnClose.Text = "GO BACK";
                btnClose.BackColor = Color.DodgerBlue;
                btnClose.ForeColor = Color.White;
                btnClose.FlatStyle = FlatStyle.Flat;
                btnClose.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                btnClose.Size = new Size(120, 41); // Set the size to 120x41
                btnClose.Click += (sender, e) => dialogForm.DialogResult = DialogResult.Cancel;
                this.tableLayoutPanel1.Controls.Add(btnClose, 0, 1);
                this.tableLayoutPanel1.SetColumnSpan(btnClose, 2);

                dialogForm.AcceptButton = btnAddSteamSign;
                dialogForm.CancelButton = btnClose;

                // Show the dialogForm as a dialog
                DialogResult result = dialogForm.ShowDialog();

                // Store the user's input
                steamID = tbSteamAccountID.Text;

                return result;
            }
        }
        private void btnAddSteamSign_Click(object sender, EventArgs e)
        {
            // Close the dialog with DialogResult.OK
            this.FindForm().DialogResult = DialogResult.OK;
            this.FindForm().Close();
        }
    }
}
