using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO;


namespace final_project
{
    public partial class UserInterface : Form
    {
        private User user;
        private Panel items_panel= new Panel();
        private const int ItemWidth = 120;
        private const int ItemHeight = 160;
        private Dictionary<string, (string, int)> items ;

        private Database database;

        public UserInterface(Database db, User user)
        {
            
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            database = db;
            this.user = user;
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

            
            ///items.Clear();                                      //exception in runtime -> user {udi,udi}
            items = storeDB.GetItemsByUserId(user);
        }
        private void UpdateForm()
        {
            textBoxUserName.Text = this.user.Username;
            textBoxPassword.Text = this.user.Password;
            textBoxID.Text = this.user.ID;
            textBoxEmail.Text = this.user.Email;
            textBoxGender.Text = this.user.Gender;
            textBoxCoins.Text = database.GetBalance(int.Parse(user.ID)).ToString();
            //textBoxCoins.Text = this.user.Balance.ToString();
        }

        private void buttonChangeUserName_Click(object sender, EventArgs e)
        {
            ChangeUserName changeUserForm = new ChangeUserName(database, user);
            if (changeUserForm.ShowDialog() == DialogResult.OK)
            {
                UpdateForm();
            }
        }

        private void buttonCHangePassword_Click_1(object sender, EventArgs e)
        {
            ChangePassword changePasswordForm = new ChangePassword(database, user);
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
        // Assuming flowLayoutPanel1 is your FlowLayoutPanel
        private void AddItemToUI(Dictionary<string, (string, int)> items)
        {
            // Clear existing controls
            flowLayoutPanel1.Controls.Clear();

            foreach (var item in items)
            {
                var panel = new Panel
                {
                    Width = ItemWidth + 20,
                    Height = ItemHeight +100,
                    Margin = new Padding(5)
                };
                string fullImagePath = Path.Combine(Application.StartupPath, @"..\..\" + item.Value.Item1);

                var pictureBox = new PictureBox
                {

                    ImageLocation = fullImagePath,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Width = ItemWidth ,
                    Height = ItemHeight, // Adjust height to leave space for the text
                    Top = 10,
                    Left = 10
                };

                var nameLabel = new Label
                {
                    Text = item.Key + $"\nכמות: {item.Value.Item2}",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Width = ItemWidth ,
                    Height = 50,
                    Top = pictureBox.Bottom + 5,
                    Left = 10,
                    Font = new Font("Gill Sans MT", 11, FontStyle.Regular)
                };

                panel.Controls.Add(pictureBox);
                panel.Controls.Add(nameLabel);

                flowLayoutPanel1.Controls.Add(panel);
            }
        }


    }
}
