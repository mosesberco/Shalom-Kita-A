using System;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace final_project
{
    public partial class ChangePassword : MaterialForm
    {
        private User userActive;
        private Database database;

        public ChangePassword(Database db, User userActive)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            this.userActive = userActive;
            this.database = db;
        }

        private bool IsPasswordValid(string password)
        {
            return password.Length >= 6 && password.Any(c => "!@#$".Contains(c));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newPass = newPassword.Text;
            string confirmPass = confirmPassword.Text;

            try
            {
                if (newPass != confirmPass)
                {
                    throw new Exception("Passwords do not match.");
                }

                if (!IsPasswordValid(newPass))
                {
                    throw new Exception("Password must be at least 6 characters long and contain at least one of these special characters: !@#$");
                }

                database.SetPassword(int.Parse(userActive.ID), newPass);
                this.userActive.Password = newPass;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}