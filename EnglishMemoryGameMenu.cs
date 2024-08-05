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
    public partial class EnglishMemoryGameMenu : MaterialForm
    {
        private User user;
        public EnglishMemoryGameMenu(User user)
        {
            this.user = user;   
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Purple600, Primary.Purple800, Primary.Grey200, Accent.Amber100, TextShade.WHITE);
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
