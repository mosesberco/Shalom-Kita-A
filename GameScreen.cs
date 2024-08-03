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
                { "cat", 2 },
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

        public GameScreen(User user)
        {
            this.user = user;
            InitializeComponent();
            SetupControls();
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


        }

        private void NewRound()
        {
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
        }

        private void CheckAnswer(int index)
        {
            string animal = (string)smallPictureBoxes[index].Tag;
            if (int.TryParse(answerTextBoxes[index].Text, out int count))
            {
                int correctCount = currentQuestion.AnimalCounts[animal];
                if (count == correctCount)
                {
                    MessageBox.Show("Good Job!");
                    score += 2;
                    submitButtons[index].Enabled = false;
                }
                else
                {
                    MessageBox.Show("Try again :)");
                }
            }
            else
            {
                MessageBox.Show("Not valid number, please try again");
            }

            if (submitButtons.All(b => !b.Enabled))
            {
                MessageBox.Show("A new round is starting now!");
                NewRound();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            var DB = new Database();
            var balance = DB.GetBalance(int.Parse(user.ID));
            DB.SetBalance(int.Parse(user.ID), (score / 10) + balance);
            Application.Exit();
        }
    }
}
