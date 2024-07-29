using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace final_project
{
    public partial class EnglishMemoryGame : Form
    {
        int moneyPerPoint = 100;

        int score = 0;

        int Timer = 90;

        bool gameOver = false;

        Random random = new Random();

        /*List<string> icons = new List<string>() { 
            "dog", "cat", "house", "bus", "cow", "bird", "ball", "balloon",
            "C:\\Users\\mpota\\source\\repos\\C#\\EnglishGame2\\EnglishGame2\\Resources\\dogPic (1).png",
            "C:\\Users\\mpota\\source\\repos\\C#\\EnglishGame2\\EnglishGame2\\Resources\\cowPic.png",
            "C:\\Users\\mpota\\source\\repos\\C#\\EnglishGame2\\EnglishGame2\\Resources\\catPic.png",
            "C:\\Users\\mpota\\source\\repos\\C#\\EnglishGame2\\EnglishGame2\\Resources\\busPic.png",
            "C:\\Users\\mpota\\source\\repos\\C#\\EnglishGame2\\EnglishGame2\\Resources\\birdPic.png",
            "C:\\Users\\mpota\\source\\repos\\C#\\EnglishGame2\\EnglishGame2\\Resources\\ballPic.png",
            "C:\\Users\\mpota\\source\\repos\\C#\\EnglishGame2\\EnglishGame2\\Resources\\balloonPic.png",
            "C:\\Users\\mpota\\source\\repos\\C#\\EnglishGame2\\EnglishGame2\\Resources\\housePic.png"
        };*/

        /*List<string> imgsList = new List<string>()
        {
            "C:\\Users\\mpota\\source\\repos\\C#\\EnglishGame2\\EnglishGame2\\Resources\\dogPic (1).png",
            "C:\\Users\\mpota\\source\\repos\\C#\\EnglishGame2\\EnglishGame2\\Resources\\cowPic.png",
            "C:\\Users\\mpota\\source\\repos\\C#\\EnglishGame2\\EnglishGame2\\Resources\\catPic.png",
            "C:\\Users\\mpota\\source\\repos\\C#\\EnglishGame2\\EnglishGame2\\Resources\\busPic.png",
            "C:\\Users\\mpota\\source\\repos\\C#\\EnglishGame2\\EnglishGame2\\Resources\\birdPic.png",
            "C:\\Users\\mpota\\source\\repos\\C#\\EnglishGame2\\EnglishGame2\\Resources\\ballPic.png",
            "C:\\Users\\mpota\\source\\repos\\C#\\EnglishGame2\\EnglishGame2\\Resources\\balloonPic.png",
            "C:\\Users\\mpota\\source\\repos\\C#\\EnglishGame2\\EnglishGame2\\Resources\\housePic.png"
        };*/

        List<string> icons = new List<string>() {
            "dog", "cat", "house", "bus", "cow", "bird", "ball", "balloon",
            "Resources\\dogPic (1).png",
            "Resources\\cowPic.png",
            "Resources\\catPic.png",
            "Resources\\busPic.png",
            "Resources\\birdPic.png",
            "Resources\\ballPic.png",
            "Resources\\balloonPic.png",
            "Resources\\housePic.png"
        };

        List<string> imgsList = new List<string>()
        {
            "Resources\\dogPic (1).png",
            "Resources\\cowPic.png",
            "Resources\\catPic.png",
            "Resources\\busPic.png",
            "Resources\\birdPic.png",
            "Resources\\ballPic.png",
            "Resources\\balloonPic.png",
            "Resources\\housePic.png"
        };



        Label firstClicked, secondClicked;


        public EnglishMemoryGame()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        private void AssignIconsToSquares()
        {
            Label label;
            int randomNumber;
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;

                randomNumber = random.Next(0, icons.Count);
                bool isPresent = imgsList.Contains(icons[randomNumber]);
                if (isPresent)
                {
                    /*label.Text = icons[randomNumber];
                    label.Image = Image.FromFile(icons[randomNumber]);*/
                    string imagePath = Path.Combine(projectDirectory, icons[randomNumber]);
                    label.Text = icons[randomNumber];
                    label.Image = Image.FromFile(imagePath);
                    label.Tag = "image";//
                }
                else
                {
                    label.Text = icons[randomNumber];
                    label.Font = new Font("Arial", 40);
                    label.Tag = "text";//
                }

                label.Image = null;//

                icons.RemoveAt(randomNumber);

            }
            LabelTime.Text = Timer + " Seconds";
            timer2.Start();
        }

        private void labelClick(object sender, EventArgs e)
        {
            if (firstClicked != null && secondClicked != null)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel == null)
                return;

            if (clickedLabel.ForeColor == Color.Black || clickedLabel.Image != null)
                return;

            if (clickedLabel.Tag.ToString() == "image")
            {
                clickedLabel.Image = Image.FromFile(clickedLabel.Text);
                clickedLabel.Font = new Font("Arial", 1);
                clickedLabel.TextAlign = ContentAlignment.BottomCenter;
            }
            else
            {
                clickedLabel.ForeColor = Color.Black;
            }

            if (firstClicked == null)
            {
                firstClicked = clickedLabel;
                return;
            }
            else
            {
                secondClicked = clickedLabel;
            }

            if (firstClicked.Tag.ToString() == secondClicked.Tag.ToString())
                timer1.Start();
            else if (firstClicked.Tag.ToString() == "text" && secondClicked.Tag.ToString() == "image")
            {
                if (secondClicked.Text.Contains(firstClicked.Text + "Pic"))
                {
                    firstClicked = null;
                    secondClicked = null;
                    score++;
                    CheckForWinner();
                }
                else
                    timer1.Start();
            }
            else if (firstClicked.Tag.ToString() == "image" && secondClicked.Tag.ToString() == "text")
            {
                if (firstClicked.Text.Contains(secondClicked.Text + "Pic"))
                {
                    firstClicked = null;
                    secondClicked = null;
                    score++;
                    CheckForWinner();
                }
                else
                    timer1.Start();
            }
            else
                timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            if (firstClicked.Tag.ToString() == "image")
                firstClicked.Image = null;

            if (firstClicked.Tag.ToString() == "text")
                firstClicked.ForeColor = firstClicked.BackColor;

            if (secondClicked != null && secondClicked.Tag.ToString() == "image")
                secondClicked.Image = null;

            if (secondClicked != null && secondClicked.Tag.ToString() == "text")
                secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (gameOver)
                return;

            if (Timer > 0)
            {
                Timer -= 1;

                if (Timer > 9)
                {
                    LabelTime.Text = Timer + " Seconds";
                }
                else
                {
                    LabelTime.Text = "0" + Timer + " Seconds";
                }
            }
            else
            {
                timer2.Stop();
                if (score == 0)
                {
                    MessageBox.Show("Time's Up!\nYour score is 0/8 :(\nTry again don't give up!");
                    Close();
                }
                else if (score > 0 && score < 8)
                {
                    MessageBox.Show("Well done!\nYour score is " + score + "/8\n" + "You've earned " + score * moneyPerPoint + " coins.");
                    Close();
                }
            }

        }

        private void CheckForWinner()
        {
            if (score == 8)
            {
                gameOver = true;
                timer2.Stop();
                MessageBox.Show("You matched all the icons!\n" + "You've earned 800 coins.\n" + "Congrats!");
                Close();
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
