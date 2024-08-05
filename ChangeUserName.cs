using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace final_project
{
    public partial class ChangeUserName : MaterialForm
    {
        private User userActive;
        private Database database;
        public ChangeUserName(Database db, User userActive)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
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
