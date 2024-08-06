using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace final_project
{
    public partial class UserInterface : Form
    {
        private User userActive;
        private Dictionary<string, string> items = new Dictionary<string, string>();

        private Database database;

        public UserInterface(Database db, User user)
        {
            
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            database = db;
            this.userActive = user;
            this.items = database.GetItemsByUserId(user);
            UpdateRecentPurchases(this.items);
            UpdateForm();
        }

        private void loadItems()
        {
            var storeDB = new Database(@"../../../storeitems.xlsx");

            items.Clear();
            items = storeDB.GetItemsByUserId(userActive);
        }
        private void UpdateForm()
        {
            textBoxUserName.Text = this.userActive.Username;
            textBoxPassword.Text = this.userActive.Password;
            textBoxID.Text = this.userActive.ID;
            textBoxEmail.Text = this.userActive.Email;
            textBoxGender.Text = this.userActive.Gender;
            textBoxCoins.Text = this.userActive.Balance.ToString();
        }

        private void buttonChangeUserName_Click(object sender, EventArgs e)
        {
            ChangeUserName changeUserForm = new ChangeUserName(database, userActive);
            if (changeUserForm.ShowDialog() == DialogResult.OK)
            {
                UpdateForm();
            }
        }

        private void buttonCHangePassword_Click_1(object sender, EventArgs e)
        {
            ChangePassword changePasswordForm = new ChangePassword(database, userActive);
            if (changePasswordForm.ShowDialog() == DialogResult.OK)
            {
                UpdateForm();
            }
        }

         private void UpdateRecentPurchases(Dictionary<string, string> recentPurchases)
        {
            // Clear existing images and labels
            pictureBox1.ImageLocation = null;
            pictureBox2.ImageLocation = null;
            pictureBox3.ImageLocation = null;
            labelProduct1.Text = string.Empty;
            labelProduct2.Text = string.Empty;
            labelProduct3.Text = string.Empty;

            // Update controls based on recent purchases
            int index = 0;
            foreach (var purchase in recentPurchases)
            {
                
                if (index == 0)
                {
                    pictureBox1.ImageLocation = purchase.Value;
                    labelProduct1.Text = purchase.Key;
                }
                else if (index == 1)
                {
                    pictureBox2.ImageLocation = purchase.Value;
                    labelProduct2.Text = purchase.Key;
                }
                else if (index == 2)
                {
                    pictureBox3.ImageLocation = purchase.Value;
                    labelProduct3.Text = purchase.Key;
                }
                else { break; }
                index++;
            }
        }

    }
}
