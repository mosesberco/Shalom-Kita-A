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
        private User user;
        private Database database;
        public ChangeUserName(User userActive)
        {
            InitializeComponent();
            user = userActive;
            database = new Database();
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private bool IsInputValid(string input)
        {
            // Validate Username
            if (input.Length < 6 || input.Length > 8)
            {
                MessageBox.Show("שם משתמש חייב להכיל בין 6-8 תווים", "שם משתמש לא תקין", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string userInput = newUserName.Text;

            if (IsInputValid(userInput))
            {
                database.SetUsername(int.Parse(user.ID), userInput);
                Close();
            }
            else MessageBox.Show("תקלה בשינוי שם משתמש", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
