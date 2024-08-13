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
    public partial class Hebrew_Etai : Form
    {
        List<Tuple<string, string>> imagePairs = new List<Tuple<string, string>>();     // List to hold the pairs of images
        private User user;
        string firstChoice;
        string secondChoice;
        int tries;
        List<PictureBox> pictures = new List<PictureBox>();
        PictureBox picA;
        PictureBox picB;
        int totalTime = 100;
        int countDownTime;
        bool gameOver = false;
        int score = 0;
        public Hebrew_Etai(User user)
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.user = user;
            var db = new Database();
            var balance = db.GetBalance(int.Parse(user.ID));
            InitializeComponent();
            InitializeImagePairs();                     // Initialize image pairs
            LoadPictures();                             // Load picture boxes onto the form
            user_data_lbl.Text = $" שם משתמש : {user.Username}  מטבעות : {balance}";
        }        
        private void InitializeImagePairs()             // Method to initialize image pairs
        {
            for (int i = 0; i < 27; i++)
            {
                char letter = (char)('a' + i);  // Generate the letter part (a, b, c, ...)
                string number = (i + 1).ToString();  // Generate the number part (1, 2, 3, ...)
                imagePairs.Add(new Tuple<string, string>(letter.ToString(), number));
            }
        }  
        private void TimerEvent(object sender, EventArgs e)             // Timer event handler to handle countdown and game over logic
        {
            countDownTime--;
            lblTimeLeft.Text =$"זמן נותר: {countDownTime}";         // Update the countdown label
            if (countDownTime < 1)
            {
                GameOver("הזמן נגמר, לא נורא תצליח/י פעם הבאה", false);

                foreach (PictureBox pic in pictures)
                {
                    if (pic.Tag != null)
                    {
                        var picPath = pic.Tag.ToString();
                        Image img = (Image)Properties.Resources.ResourceManager.GetObject(picPath);
                        pic.Image = img;
                    }
                }
            }
        }
        private void RestartGame()                  // Method to restart the game
        {
            // Randomly select 6 pairs from the 27 pairs
            var selectedPairs = imagePairs.OrderBy(x => Guid.NewGuid()).Take(6).ToList();

            List<string> allItems = new List<string>();

            foreach (var pair in selectedPairs)
            {
                allItems.Add(pair.Item1);
                allItems.Add(pair.Item2);
            }

            allItems = allItems.OrderBy(x => Guid.NewGuid()).ToList(); // Shuffle the selected pairs

            for (int i = 0; i < pictures.Count; i++)
            {
                pictures[i].Image = null; // Clear the images from previous game
                pictures[i].Tag = allItems[i]; // Assign new shuffled tags
            }

            tries = 0;
            lblStatus.Text = $"מספר נסיונות: {tries} ";         // Reset tries count
            lblTimeLeft.Text = $"זמן נותר: {totalTime} ";       // Reset countdown label
            gameOver = false;
            GameTimer.Start();                  // Start the timer           
            countDownTime = totalTime;          // Reset countdown time
        }       
        private void RestartGameEvent(object sender, EventArgs e)           // Event handler for the restart game button click
        {
            RestartGame();
        }       
        private void LoadPictures()             // Method to load picture boxes onto the form
        {
            this.Controls.Add(this.gamePanel);
            this.gamePanel.SendToBack();

            int pictureSize =110; // Size of each picture box
            int padding = 20; // Padding between picture boxes
            int columns = 4; // Number of columns
            int rows = 3; // Number of rows

            // Calculate the total width and height of the game board
            int totalWidth = columns * pictureSize + (columns - 1) * padding;
            int totalHeight = rows * pictureSize + (rows - 1) * padding;

            // Calculate starting positions to center the board
            int startX = (this.ClientSize.Width - totalWidth) / 2;
            int startY = (this.ClientSize.Height - totalHeight) / 2 -30; // Add some top margin

            // Create and position picture boxes
            for (int i = 0; i < 12; i++)
            {
                int row = i / columns;
                int col = i % columns;

                PictureBox newPic = new PictureBox
                {
                    Height = pictureSize,
                    Width = pictureSize,
                    BackColor = Color.YellowGreen,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Cursor = Cursors.Hand,
                    Left = startX + col * (pictureSize + padding),
                    Top = startY + row * (pictureSize + padding),
                    BorderStyle = BorderStyle.FixedSingle
                };
                newPic.Click += NewPic_Click; // Attach click event handler
                pictures.Add(newPic);
                Controls.Add(newPic);
                newPic.BringToFront();
            }
            RestartGame(); // Start a new game
        }        
        private async void NewPic_Click(object sender, EventArgs e)         // Event handler for picture box click
        {
            if (gameOver)       // If the game is over, ignore clicks
            {
                return;
            }
            if (firstChoice == null)
            {
                picA = sender as PictureBox;
                if (picA.Tag != null && picA.Image == null)
                {
                    var picPath = picA.Tag.ToString();
                    Image img = (Image)Properties.Resources.ResourceManager.GetObject(picPath);
                    picA.Image = img;
                    firstChoice = picA.Tag.ToString();
                }
            }
            else if (secondChoice == null)
            {
                picB = sender as PictureBox;
                if (picB.Tag != null && picB.Image == null)
                {
                    var picPath = picB.Tag.ToString();
                    Image img = (Image)Properties.Resources.ResourceManager.GetObject(picPath);
                    picB.Image = img;
                    secondChoice = picB.Tag.ToString();
                    await Task.Delay(1100);
                    CheckPictures(picA, picB);
                }
            }
        }       
        private void CheckPictures(PictureBox A, PictureBox B)          // Method to check if two selected pictures match
        {
            bool isMatch = false;
            foreach (var pair in imagePairs)
            {
                if ((A.Tag.ToString() == pair.Item1 && B.Tag.ToString() == pair.Item2) ||
                    (A.Tag.ToString() == pair.Item2 && B.Tag.ToString() == pair.Item1))
                {
                    isMatch = true;     // Found a match
                    break;
                }
            }
            if (isMatch)
            {
                score++;
                A.Tag = null; // Clear tag for matched pictures
                B.Tag = null;
            }         
            else
            {
                tries++;
                lblStatus.Text = $" מספר נסיונות: {tries}" ; // Update tries count
            }

            firstChoice = null;
            secondChoice = null;
        
            foreach (PictureBox pics in pictures.ToList())          // Hide images for unmatched pairs
            {
                if (pics.Tag != null)
                {
                    pics.Image = null;
                }
            }
            IfAllOver();
        }       
        private void GameOver(string msg, bool isWon)            // Method to handle game over
        {
            GameTimer.Stop();
            gameOver = true;
            if (isWon)
                MessageBox.Show(msg, "ניצחון", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(msg, "המשחק נגמר", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
         private void IfAllOver()
         {
            if (pictures.All(o => o.Tag == null))
            {
                //score = 50 - tries + this.countDownTime;

                //if (score == 0)
                //{
                //    GameOver("יותר מדי נסיונות לא הרווחת מטבעות הפעם", false);
                //}
                //else
                {
                    var DB = new Database();
                    var balance = DB.GetBalance(int.Parse(user.ID));
                    DB.SetBalance(int.Parse(user.ID), balance + score);
                    GameOver(" כל הכבוד ניצחת! זכית ב" + score + " מטבעות ", true);
                    Close();
                }                
            }
         }
    }
}

