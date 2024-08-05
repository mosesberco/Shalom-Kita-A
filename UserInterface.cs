using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace final_project
{
    public partial class UserInterface : MaterialForm
    {
        private User userActive;
        private Dictionary<string, string> items = new Dictionary<string, string>();

        private Database database;

        public UserInterface(Database db, int userIndex)
        {
            
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            database = db;
            LoadUser(userIndex);
            UpdateForm();
        }

        private void loadItems()
        {
            var storeDB = new Database(@"../../../storeitems.xlsx");

            items.Clear();
            items = storeDB.GetItemsByUserId(userActive);
        }
        private void LoadUser(int userIndex)
        {
            this.userActive = database.LoadUserData(userIndex);
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
    }
}
