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
                MessageBox.Show("Username must be between 6 and 8 characters long.", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int digitCount = username.Count(char.IsDigit);
            int letterCount = username.Count(c => (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'));

            if (digitCount > 3 || letterCount + digitCount != username.Length)
            {
                MessageBox.Show("Username must contain at most 2 digits and the rest must be English letters.", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate Password
            if (password.Length < 8 || password.Length > 10)
            {
                MessageBox.Show("Password must be between 8 to 10 characters long.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!password.Any(char.IsLetter) || !password.Any(char.IsDigit) || !password.Any(c => "!$#@%^&*".Contains(c)))
            {
                MessageBox.Show("Password must contain at least one letter, one digit, and one special character (!$#@%^&*).", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate ID Number
            if (string.IsNullOrWhiteSpace(id) || !id.All(char.IsDigit) || id.Count() != 9)
            {
                MessageBox.Show("ID must be a valid 9 digits number.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate Email
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate Gender
            if (string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("Please select Gender.", "Invalid Gender", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Safety Warning - if username matches password
            if (usernameTextBox.Text.Equals(passwordTextBox.Text))
            {
                DialogResult result = MessageBox.Show("Warning - Similar username and password can lead to security breach.", "Security Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
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
                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                Login loginForm = new Login();
                loginForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
