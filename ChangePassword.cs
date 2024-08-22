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
            database = db;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private bool IsPasswordValid(string password)
        {
            // Validate Password
            if (password.Length < 8 || password.Length > 10)
            {
                MessageBox.Show("הסיסמא חייבת להכיל בין 8-10 תווים", "סיסמא לא תקינה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!password.Any(char.IsLetter) || !password.Any(char.IsDigit) || !password.Any(c => "!$#@%^&*".Contains(c)))
            {
                MessageBox.Show("\u200F" + "הסיסמא חייבת להכיל לפחות אות אחת, ספרה אחת, ותו אחד מיוחד (!$#@%^&*)", "סיסמא לא תקינה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void saveBTN_Click(object sender, EventArgs e)
        {
            string newPass = newPassword.Text;
            string confirmPass = confirmPassword.Text;

            try
            {
                if (newPass != confirmPass)
                {
                    MessageBox.Show("\u200F" + "הסיסמאות לא זהות", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!IsPasswordValid(newPass))
                {
                    MessageBox.Show("\u200F" + "הסיסמא חייבת להכיל לפחות אות אחת, ספרה אחת, ותו אחד מיוחד (!$#@%^&*)", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                database.SetPassword(int.Parse(userActive.ID), newPass);
                userActive.Password = newPass;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("הסיסמא שונתה בהצלחה", "שינוי סיסמא בוצע", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            newPassword.PasswordChar = showPasswordCheckBox.Checked ? '\0' : '*';
            confirmPassword.PasswordChar = showPasswordCheckBox.Checked ? '\0' : '*';
        }
    }
}