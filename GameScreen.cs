using final_project.Properties;
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
    public partial class GameScreen : Form
    {
        private User user;
        private class QuestionData
        {
            public string ImageName { get; set; }
            public Dictionary<string, int> AnimalCounts { get; set; }
        }

        private List<QuestionData> questions = new List<QuestionData>
        {
        new QuestionData
        {
            ImageName = "q1",
            AnimalCounts = new Dictionary<string, int>
            {
                { "dog", 2 },
                { "cat", 3 },
                { "elephant", 1 },
                { "tiger", 0 },
                { "monkey", 0 },

            }
        },
         new QuestionData
        {
            ImageName = "q2",
            AnimalCounts = new Dictionary<string, int>
            {
                { "dog", 2 },
                { "cat", 2 },
                { "elephant", 2 },
                { "tiger", 0 },
                { "monkey", 0 },
            }
        },
         new QuestionData
        {
            ImageName = "q3",
            AnimalCounts = new Dictionary<string, int>
            {
                { "dog", 1 },
                { "cat", 1 },
                { "elephant", 2 },
                { "tiger", 1 },
                { "monkey", 1 },
            }
        },
          new QuestionData
        {
            ImageName = "q4",
            AnimalCounts = new Dictionary<string, int>
            {
                { "dog", 0 },
                { "cat", 0 },
                { "elephant", 1 },
                { "tiger", 2 },
                { "monkey", 3 },
            }
        },
            new QuestionData
        {
            ImageName = "q5",
            AnimalCounts = new Dictionary<string, int>
            {
                { "dog", 1 },
                { "cat", 0 },
                { "elephant", 1 },
                { "tiger", 2 },
                { "monkey", 2 },
            }
        },
                 new QuestionData
        {
            ImageName = "q6",
            AnimalCounts = new Dictionary<string, int>
            {
                { "dog", 0 },
                { "cat", 2 },
                { "elephant", 2 },
                { "tiger", 1 },
                { "monkey", 1 },
            }
        },
        // Add more questions here
        };
        private Random random = new Random();
        private PictureBox largePictureBox;
        private PictureBox[] smallPictureBoxes;
        private Button[] submitButtons;
        private TextBox[] answerTextBoxes;
        private string[] animalImages = { "cat", "dog", "elephant", "tiger", "monkey" }; // Add all animal image names without .png
        private QuestionData currentQuestion;
        private int score = 0;
        private int roundsCompleted = 0;                                                // exit games after 5 rounds
        private Timer gameTimer;
        private int timeLeft = 60;
        private bool roundCompleted = false;

        public GameScreen(User user)
        {
            this.user = user;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            SetupControls();
            SetupTimer();
            UpdateUserInfo();
            NewRound();
        }
        private void SetupControls()
        {
            largePictureBox = pictureBoxQuestion;
            smallPictureBoxes = new PictureBox[] { pictureBoxAnswer1, pictureBoxAnswer2, pictureBoxAnswer3 };
            submitButtons = new Button[] { buttonSubmit1, buttonSubmit2, buttonSubmit3 };
            answerTextBoxes = new TextBox[] { textBoxAnswer1, textBoxAnswer2, textBoxAnswer3 };
            buttonExit.Click += buttonExit_Click;
            for (int i = 0; i < submitButtons.Length; i++)
            {
                int index = i;
                submitButtons[i].Click += (sender, e) => CheckAnswer(index);
            }

            // Set up timerLabel
            timerLabel.Font = new Font("Gill Sans MT", 12, FontStyle.Bold);
            timerLabel.ForeColor = Color.White;
            timerLabel.AutoSize = true;
            timerLabel.Location = new Point(910, 20);
            timerLabel.RightToLeft = RightToLeft.Yes;

            // Set up userInfoLabel
            userInfoLabel.Font = new Font("Gill Sans MT", 12);
            userInfoLabel.ForeColor = Color.White;
            userInfoLabel.AutoSize = true;
            userInfoLabel.Location = new Point(1160,0);
            userInfoLabel.RightToLeft = RightToLeft.Yes;
        }
        private void SetupTimer()
        {
            gameTimer = new Timer();
            gameTimer.Interval = 1000; // 1 second
            gameTimer.Tick += GameTimer_Tick;
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            UpdateTimerDisplay();

            if (timeLeft <= 0)
            {
                gameTimer.Stop();
                EndRound();
            }
        }
        private void UpdateTimerDisplay()
        {
            timerLabel.Text = $"זמן שנותר: {timeLeft} שניות";
        }
        private void UpdateUserInfo()
        {
            var db = new Database();
            int balance = db.GetBalance(int.Parse(user.ID));
            userInfoLabel.Text = $"משתמש: {user.Username}\nמטבעות : {balance}\nניקוד: ${score}";
        }
        private void NewRound()
        {
            if (roundsCompleted == 4)
            {
                EndGame();
            }

            currentQuestion = questions[random.Next(questions.Count)];
            largePictureBox.Image = (Image)Resources.ResourceManager.GetObject(currentQuestion.ImageName);

            List<string> roundAnimals = new List<string>(animalImages);
            roundAnimals = roundAnimals.OrderBy(a => random.Next()).ToList();

            for (int i = 0; i < smallPictureBoxes.Length; i++)
            {
                smallPictureBoxes[i].Image = (Image)Resources.ResourceManager.GetObject(roundAnimals[i]);
                smallPictureBoxes[i].Tag = roundAnimals[i];
                answerTextBoxes[i].Clear();
                submitButtons[i].Enabled = true;
            }

            roundCompleted = false;
            timeLeft = 60;
            UpdateTimerDisplay();
            gameTimer.Start();
        }
        private void CheckAnswer(int index)
        {
            string animal = (string)smallPictureBoxes[index].Tag;
            if (int.TryParse(answerTextBoxes[index].Text, out int count))
            {
                int correctCount = currentQuestion.AnimalCounts[animal];
                if (count == correctCount && count >= 0 && count <= 10)
                {
                    MessageBox.Show("\u200F" + "עבודה טובה!", "הצלחת", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    submitButtons[index].Enabled = false;
                }
                else
                {
                    MessageBox.Show("\u200F" + "נסה שוב", "תשובה שגויה", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("\u200F" + "בבקשה הכנס מספרים בלבד", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (submitButtons.All(b => !b.Enabled))
            {
                roundCompleted = true;
                EndRound();
            }
        }
        private void EndGame()
        {
            var DB = new Database();
            var balance = DB.GetBalance(int.Parse(user.ID));
            DB.SetBalance(int.Parse(user.ID), score + balance);
            //MessageBox.Show($"Great job! youv'e earned {score} coins.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("\u200F" + $"כל הכבוד! זכית ב {score} מטבעות", "נגמר המשחק", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
        private void EndRound()
        {
            gameTimer.Stop();
            roundsCompleted++;

            if (roundCompleted)
            {
                score += 3;
                UpdateUserInfo();
                //MessageBox.Show($"Round completed! You earned 10 coins.", "Round Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("\u200F" + $"השלב הסתיים! צברת 3 מטבעות", "השלב הסתיים", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //MessageBox.Show($"Round not completed.", "Times Up!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show($"השלב לא הסתיים", "נגמר הזמן", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            roundCompleted = false;
            NewRound();
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            gameTimer.Stop();
        }
    }
}

