using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace final_project
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void showPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            passwordTextBox.PasswordChar = showPasswordCheckBox.Checked ? '\0' : '*';
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool ValidateInput(string username, string password, string id, string email, string gender)
        {
            // Validate Username
            if (username.Length < 6 || username.Length > 8)
            {
                MessageBox.Show("שם משתמש חייב להכיל בין 6-8 תווים", "שם משתמש לא תקין", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int digitCount = username.Count(char.IsDigit);
            int letterCount = username.Count(c => (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'));

            if (digitCount > 3 || letterCount + digitCount != username.Length)
            {
                MessageBox.Show("שם משתמש חייב להכיל עד 2 ספרות והשאר אותיות באנגלית", "שם משתמש לא תקין", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate Password
            if (password.Length < 8 || password.Length > 10)
            {
                MessageBox.Show("הסיסמא חייבת להכיל בין 8-10 תווים", "סיסמא לא תקינה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            var DB = new Database();
            if (DB.has_ID(id))
            {
                MessageBox.Show("התעודת זהות שהכנסת כבר קיימת במערכת","תעודת זהות לא תקינה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }    

            if (!password.Any(char.IsLetter) || !password.Any(char.IsDigit) || !password.Any(c => "!$#@%^&*".Contains(c)))
            {            
                MessageBox.Show("\u200F" + "הסיסמא חייבת להכיל לפחות אות אחת, ספרה אחת, ותו אחד מיוחד (!$#@%^&*)", "סיסמא לא תקינה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate ID Number
            if (string.IsNullOrWhiteSpace(id) || !id.All(char.IsDigit) || id.Count() != 9)
            {             
                MessageBox.Show("תעודת הזהות צריכה להכיל 9 מספרים", "תעודת זהות לא תקינה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate Email
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("הכנס כתובת דואר אלקטרוני תקינה", "דואר אלקטרוני לא תקין", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate Gender
            if (string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("בבקשה הכנס מגדר", "מגדר לא תקין", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Safety Warning - if username matches password
            if (usernameTextBox.Text.Equals(passwordTextBox.Text))
            {
                DialogResult result = MessageBox.Show("אזהרה - שם משתמש וסיסמא זהים עלולים להוביל לפרצת אבטחה", "אזהרת אבטחה", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    return true;
                else
                {
                    ClearForm();
                    return false;
                }  
            }

            // If all validations pass
            return true;
        }

        private void ClearForm()
        {
            usernameTextBox.Clear();
            passwordTextBox.Clear();
            idTextBox.Clear();
            emailTextBox.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            string id = idTextBox.Text;
            string email = emailTextBox.Text;
            string gender = genderTextBox.Text;

            if (!ValidateInput(username, password, id, email, gender))
            {
                return; // If validation fails, stop the registration process
            }

            Database db = new Database();

            if (db.RegisterUser(username, password, id, email, gender))
            {
                MessageBox.Show("ההרשמה למערכת בוצעה בהצלחה", "הרשמה בוצעה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                Login loginForm = new Login();
                loginForm.Show();
                Close();
            }
            else
            {
                MessageBox.Show("ההרשמה נכשלה. בבקשה נסה שוב", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
