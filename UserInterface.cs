using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace final_project
{
    public partial class UserInterface : Form
    {
        private User userActive;
        private Panel items_panel;
        private const int ItemWidth = 200;
        private const int ItemHeight = 250;
        private Dictionary<string, (string, int)> items ;

        private Database database;

        public UserInterface(Database db, User user)
        {
            
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            database = db;
            this.userActive = user;
            loadItems();
            //this.items = database.GetItemsByUserId(user);
            AddItemToUI(this.items);
            UpdateForm();
            items_panel = new Panel();                          //set itemspanel location

            items_panel.Location = new Point(200, 200);
        }

        private void loadItems()
        {
            var storeDB = new Database(@"../../storeitems.xlsx");

            items.Clear();                                      //exception in runtime -> user {udi,udi}
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

        // private void UpdateRecentPurchases(Dictionary<string, (string, int)> recentPurchases)
        //{
        //    // Clear existing images and labels
        //    pictureBox1.ImageLocation = null;
        //    pictureBox2.ImageLocation = null;
        //    pictureBox3.ImageLocation = null;

        //    labelProduct1.Text = string.Empty;
        //    labelProduct2.Text = string.Empty;
        //    labelProduct3.Text = string.Empty;

        //    // Update controls based on recent purchases
        //    int index = 0;
        //    foreach (var purchase in recentPurchases)
        //    {

        //        if (index == 0)
        //        {
        //            pictureBox1.ImageLocation = purchase.Value.Item1;
        //            labelProduct1.Text = purchase.Key;
        //        }
        //        else if (index == 1)
        //        {
        //            pictureBox2.ImageLocation = purchase.Value;
        //            labelProduct2.Text = purchase.Key;
        //        }
        //        else if (index == 2)
        //        {
        //            pictureBox3.ImageLocation = purchase.Value;
        //            labelProduct3.Text = purchase.Key;
        //        }
        //        else { break; }
        //        index++;
        //    }
        //}
        private void AddItemToUI(Dictionary<string, (string, int)> items)
        {
            foreach (var item in items)
            {

                var panel = new Panel
                {
                    Width = ItemWidth,
                    Height = ItemHeight,
                    Margin = new Padding(5)
                };

                var pictureBox = new PictureBox
                {
                    ImageLocation = item.Value.Item1,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Width = ItemWidth - 20,
                    Height = 120,
                    Top = 10,
                    Left = 10
                };

                var nameLabel = new Label
                {
                    Text = item.Key + $"\nכמות: {item.Value.Item2}",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Width = ItemWidth - 20,
                    Height = 30,
                    Top = pictureBox.Bottom + 5,
                    Left = 10,
                    Font = new Font("Gill Sans MT", 12, FontStyle.Regular)
                };

                panel.Controls.Add(pictureBox);
                panel.Controls.Add(nameLabel);
                items_panel.Controls.Add(panel);
            }

        }


    }
}
