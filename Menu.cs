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
    //Add Login form 
    public partial class Menu : Form
    {
        private User user;
        public Menu(User user)
        {
            InitializeComponent();
            this.user = user;
            updateUserData(user);
            checkUser();
        }

        private void checkUser()
        {
            if (user != null)
            {
                this.login.Enabled = false;
                this.LogOut.Enabled = true;
            }
            else
            {
                this.login.Enabled = true;
                this.LogOut.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var eng1 = new EnglishBuildWordsGameMenu(user);
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

        private void login_Click(object sender, EventArgs e)    //return value - the user that logged in
        {
            var loginForm = new Login();
            loginForm.Show();
        }

        private void Store_Click(object sender, EventArgs e)    //fix sizing, img loading, buying errors
        {
            var storeForm = new StoreForm(user);
            storeForm.Show();
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            this.user = null;
            updateUserData(user);
            checkUser();
        }

        private void userInterface_Click(object sender, EventArgs e)    //fix userInterface logic - index?! ,, db?!,, where top X button????????!!!!!!!!
        {
            var userInterface = new UserInterface(new Database(), 3);
            userInterface.Show();

        }
    }
}
