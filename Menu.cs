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
        public Database DB;
        private User user;
        public Menu(User user)
        {
            DB = new Database();
            InitializeComponent();
            this.user = user;
            updateUserData(user);
            FormClosing += Menu_FormClosing; 
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void eng_BuildWords_Click(object sender, EventArgs e)
        {
            var eng1 = new EnglishMenu(user);
            Run(eng1);
        }
        private void eng_MemoryGame_Click(object sender, EventArgs e)
        {
            var eng2 = new EnglishMemoryGameMenu(user);
            Run(eng2);
        }
        private void heb_AddSub_Click(object sender, EventArgs e)
        {
            var math1 = new Game_Udi(user);
            Run(math1);
        }
        private void heb_CountAnimals_Click(object sender, EventArgs e)
        {
            var math2 = new GameScreen(user);
            Run(math2);
        }
        private void heb_MemoryGame_Click(object sender, EventArgs e)      //exception locating file img !!!!!
        {
            var heb1 = new Hebrew_Etai(user);
            Run(heb1);
        }
        private void heb_MatchLetterPhoto_Click(object sender, EventArgs e)
        {
            var heb2 = new HebrewGame_sapir(user);
            Run(heb2);
        }
        public void updateUserData(User user)
        {
            if (this.user == null)
            {
                userData.Text = "בבקשה התחבר/י כדי להציג את פרטי המשתמש.";
            }
            else
            {
                this.user = DB.getUser(user.ID);
                var balance = DB.GetBalance(int.Parse(user.ID));  
                var username = DB.GetUserName(int.Parse(user.ID));
                userData.Text = $"שם משתמש : {username}\nמטבעות : {balance}";
            }
        }
        private void Store_Click(object sender, EventArgs e)
        {
            var storeForm = new StoreForm(user);
            Run(storeForm);
        }
        private void LogOut_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            Run(login);
        }
        private void userInterface_Click(object sender, EventArgs e)
        {
            var userInterface = new UserInterface(new Database(), user);
            Run(userInterface);
        }
        private void Run(Form form)
        {
            form.Show();
            Hide();
            form.FormClosed += (s, args) =>
            {
            // This code runs when the form is closed
                updateUserData(user);
                Show();
            };
        }
    }
}
