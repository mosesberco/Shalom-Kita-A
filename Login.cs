﻿using LoginRegister;
using OfficeOpenXml;
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

namespace final_project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide the login form
            Register registerForm = new Register(); // Create an instance of the register form
            registerForm.Show(); // Show the register form
        }

        private bool ValidateLogin(string username, string password)
        {
            string filePath = @"C://Users//liora//source//repos//LoginRegister//LoginRegister//Users.xlsx";
            FileInfo fileInfo = new FileInfo(filePath);

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Users"];
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    string storedUsername = worksheet.Cells[row, 1].Value.ToString();
                    string storedPassword = worksheet.Cells[row, 2].Value.ToString();

                    if (username == storedUsername && password == storedPassword)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            DatabaseOperations db = new DatabaseOperations();
            if (db.ValidateUser(username, password))
            {
                MessageBox.Show("Login successful!");

            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void showPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            passwordTextBox.PasswordChar = showPasswordCheckBox.Checked ? '\0' : '*';
        }
    }
}