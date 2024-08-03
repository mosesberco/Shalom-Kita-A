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
        // List to hold the pairs of images
        List<Tuple<string, string>> imagePairs = new List<Tuple<string, string>>();
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
            this.user = user;
            InitializeComponent();
            InitializeImagePairs(); // Initialize image pairs
            LoadPictures(); // Load picture boxes onto the form
        }




        // Method to initialize image pairs
        private void InitializeImagePairs()
        {
            for (int i = 0; i < 27; i++)
            {
                char letter = (char)('a' + i);  // Generate the letter part (a, b, c, ...)
                string number = (i + 1).ToString();  // Generate the number part (1, 2, 3, ...)
                imagePairs.Add(new Tuple<string, string>(letter.ToString(), number));
            }
        }

        // Timer event handler to handle countdown and game over logic
        private void TimerEvent(object sender, EventArgs e)
        {
            countDownTime--;
            lblTimeLeft.Text = countDownTime + " :זמן נותר"; // Update the countdown label
            if (countDownTime < 1)
            {
                GameOver("הזמן נגמר, לא נורא תצליח פעם הבאה");

                foreach (PictureBox pic in pictures)
                {
                    if (pic.Tag != null)
                    {
                        pic.Image = Image.FromFile("pics/" + pic.Tag + ".png"); // Show all images when time is up
                    }
                }
            }
        }

        // Method to restart the game
        private void RestartGame()
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
            lblStatus.Text = tries + " :מספר נסיונות לא מוצלחים"; // Reset tries count
            lblTimeLeft.Text = totalTime + " :זמן נותר"; // Reset countdown label
            gameOver = false;
            GameTimer.Start(); // Start the timer
            countDownTime = totalTime; // Reset countdown time
        }

        // Event handler for the restart game button click
        private void RestartGameEvent(object sender, EventArgs e)
        {
            RestartGame();
        }

        // Method to load picture boxes onto the form
        private void LoadPictures()
        {
            this.Controls.Add(this.gamePanel);
            this.gamePanel.SendToBack();

            int pictureSize = 120; // Size of each picture box
            int padding = 20; // Padding between picture boxes
            int columns = 4; // Number of columns
            int rows = 3; // Number of rows

            // Calculate the total width and height of the game board
            int totalWidth = columns * pictureSize + (columns - 1) * padding;
            int totalHeight = rows * pictureSize + (rows - 1) * padding;

            // Calculate starting positions to center the board
            int startX = (this.ClientSize.Width - totalWidth) / 2;
            int startY = (this.ClientSize.Height - totalHeight) / 2 - 50; // Add some top margin

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
                this.Controls.Add(newPic);
                newPic.BringToFront();
            }
            RestartGame(); // Start a new game
        }

        // Event handler for picture box click
        private void NewPic_Click(object sender, EventArgs e)
        {
            if (gameOver) // If the game is over, ignore clicks
            {
                return;
            }
            if (firstChoice == null)
            {
                picA = sender as PictureBox;
                if (picA.Tag != null && picA.Image == null)
                {
                    picA.Image = Image.FromFile($"pics/{picA.Tag}.png"); // Show image for the first choice
                    firstChoice = picA.Tag.ToString();
                }
            }
            else if (secondChoice == null)
            {
                picB = sender as PictureBox;
                if (picB.Tag != null && picB.Image == null)
                {
                    picB.Image = Image.FromFile($"pics/{picB.Tag}.png"); // Show image for the second choice
                    secondChoice = picB.Tag.ToString();
                }
            }
            else
            {
                CheckPictures(picA, picB); // Check if the selected pictures match
            }
        }

        // Method to check if two selected pictures match
        private void CheckPictures(PictureBox A, PictureBox B)
        {
            bool isMatch = false;
            foreach (var pair in imagePairs)
            {
                if ((A.Tag.ToString() == pair.Item1 && B.Tag.ToString() == pair.Item2) ||
                    (A.Tag.ToString() == pair.Item2 && B.Tag.ToString() == pair.Item1))
                {
                    isMatch = true; // Found a match
                    break;
                }
            }

            if (isMatch)
            {
                A.Tag = null; // Clear tag for matched pictures
                B.Tag = null;
            }
            else
            {
                tries++;
                lblStatus.Text = tries + " :מספר נסיונות לא מוצלחים"; // Update tries count
            }

            firstChoice = null;
            secondChoice = null;

            // Hide images for unmatched pairs
            foreach (PictureBox pics in pictures.ToList())
            {
                if (pics.Tag != null)
                {
                    pics.Image = null;
                }
            }

            // Check if all pictures are matched
            if (pictures.All(o => o.Tag == null))
            {
                score = 50 - tries + this.countDownTime;
                var DB = new Database();
                var balance = DB.GetBalance(int.Parse(user.ID));
                DB.SetBalance(int.Parse(user.ID), balance+score);
                GameOver(" כל הכבוד ניצחת! זכית ב" + score + " מטבעות ");
            }
        }

        // Method to handle game over
        private int GameOver(string msg)
        {
            GameTimer.Stop();
            gameOver = true;
            MessageBox.Show(msg); // Show game over message
            return score;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Placeholder for text changed event handler (if needed)
        }
    }
}

