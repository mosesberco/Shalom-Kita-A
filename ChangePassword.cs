using System;
using System.Linq;
using System.Windows.Forms;

namespace final_project
{
    public partial class ChangePassword : Form
    {
        private User userActive;
        private Database database;
        public ChangePassword(Database db, User userActive)
        {
            InitializeComponent();
            this.userActive = userActive;
            this.database = db;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private bool IsPasswordValid(string password)
        {
            return password.Length >= 6 && password.Length <= 8 && password.Any(c => "!@#$".Contains(c));
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