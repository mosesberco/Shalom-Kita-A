using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_project
{
    public partial class ChangeUserName : Form
    {
        private User userActive;
        private Database database;
        public ChangeUserName(Database db, User userActive)
        {
            InitializeComponent();
            this.userActive = userActive;
            this.database = db;
        }

        private bool IsInputValid(string input)
        {
            return input.Length > 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userInput = newUserName.Text;

            if (IsInputValid(userInput))
            {
                database.SetUsername(int.Parse(userActive.ID), userInput);
                this.userActive.Username = userInput;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else MessageBox.Show("error");
        }

    }
}
