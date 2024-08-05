using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace final_project
{
    public partial class Login : MaterialForm
    {
        private Database DB;
        public Login()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            this.DB = new Database();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide the login form
            Register registerForm = new Register(); // Create an instance of the register form
            registerForm.Show(); // Show the register form
        }

        //private bool ValidateLogin(string username, string password)
        //{

        //    var DB = new Database();
        //    return DB.ValidateUser(username, password);

        //    string filePath = @"C://Users//liora//source//repos//LoginRegister//LoginRegister//Users.txt";

        //    if (!File.Exists(filePath))
        //    {
        //        MessageBox.Show("User file not found.");
        //        return false;
        //    }

        //    var lines = File.ReadAllLines(filePath);
        //    foreach (var line in lines)
        //    {
        //        var parts = line.Split(',');
        //        if (parts.Length == 2)
        //        {
        //            string storedUsername = parts[0];
        //            string storedPassword = parts[1];

        //            if (username == storedUsername && password == storedPassword)
        //            {
        //                return true;
        //            }
        //        }
        //    }

        //    return false;
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            int index = DB.ValidateUser(username, password);

            if (index!=-1)
            {
                MessageBox.Show("Login successful!");
                this.Hide();
                UserInterface userInterface = new UserInterface(DB, index);
                userInterface.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        //private void showPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    passwordTextBox.PasswordChar = showPasswordCheckBox.Checked ? '\0' : '*';
        //}

        
    }
}