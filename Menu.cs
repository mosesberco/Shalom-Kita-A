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
    public partial class Menu : Form
    {
        private User user;
        public Menu(User user)
        {
            InitializeComponent();
            this.user = user;
            updateUserData(user);
            this.FormClosing += Menu_FormClosing;
            //checkUser();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var eng1 = new EnglishMenu(user);
            eng1.Show();
        }
        private void button4_Click(object sender, EventArgs e)      //exception locating file img !!!!!
        {
            var eng2 = new EnglishMemoryGameMenu(user);
            eng2.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var math1 = new Game_Udi(user);
            math1.Show();
            this.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            var math2 = new GameScreen(user);
            math2.Show();
        }
        private void button3_Click(object sender, EventArgs e)      //exception locating file img !!!!!
        {
            var heb1 = new Hebrew_Etai(user);
            heb1.Show();
        }
        private void button6_Click(object sender, EventArgs e)      //exception - fix game logic
        {
            var heb2 = new HebrewGame_sapir(user);
            heb2.Show();
        }
        private void updateUserData(User user)
        {
            if (this.user == null)
            {
                userData.Text = $"Please login to display your data.";
            }
            else
                userData.Text = $"Username : {user.Username}\nBalance : {user.Balance}";
        }

        private void Store_Click(object sender, EventArgs e)    //fix sizing, img loading, buying errors
        {
            var storeForm = new StoreForm(user);
            storeForm.Show();
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            //this.user = null;
            //updateUserData(user);
            //checkUser();
            Login login = new Login();
            login.Show();
            Close();
            
        }

        private void userInterface_Click(object sender, EventArgs e)    //fix userInterface logic - index?! ,, db?!,, where top X button????????!!!!!!!!
        {
            var userInterface = new UserInterface(new Database(), user);
            userInterface.Show();
        }


    }
}
