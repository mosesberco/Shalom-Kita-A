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
    public partial class EnglishMemoryGameMenu : Form
    {
        private User user;
        public EnglishMemoryGameMenu(User user)
        {
            this.user = user;   
            InitializeComponent();
            initializeLabels();
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            EnglishMemoryGame gameForm = new EnglishMemoryGame(user, this);
            gameForm.Show();
        }
        public void initializeLabels()
        {
            //dynamiclly upload the form.
            var DB = new Database();
            var balance = DB.GetBalance(int.Parse(user.ID));

            nameLabel.Text = "Hello, " + user.Username.ToString();
            moneyLabel.Text = "Balance: " + balance;
            this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("memoryGameMenuBackground");

            startButton.FlatStyle = FlatStyle.Flat;
            startButton.FlatAppearance.BorderSize = 0;
            startButton.BackColor = ColorTranslator.FromHtml("#F0DDA6");
            startButton.ForeColor = Color.White;
            startButton.Font = new Font("Gill Sans MT", 30, FontStyle.Bold);
            startButton.Text = "Start Game";
            startButton.UseVisualStyleBackColor = false;
            startButton.MouseEnter += new EventHandler(Button_MouseEnter);
            startButton.MouseLeave += new EventHandler(Button_MouseLeave);
        }
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            startButton.BackColor = Color.DeepSkyBlue;
        }
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            startButton.BackColor = ColorTranslator.FromHtml("#F0DDA6");
        }
        public void updateBalance(int balance)
        {
            moneyLabel.Text = "Balance: " + balance;
        }
    }
}
