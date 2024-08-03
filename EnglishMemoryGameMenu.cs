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
            LabelInsrtuctions.Text = "ברוך הבא למשחק הזכרון!\nלפניך דקה וחצי להתאים 8 תמונות למשמעות שלהם באנגלית\nכל התאמה " +
                "תזכה אותך בנקודה, וכל נקודה שווה 100 מטבעות לחשבונך\nבהצלחה";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnglishMemoryGame gameForm = new EnglishMemoryGame(user);
            gameForm.Show();
        }
    }
}
