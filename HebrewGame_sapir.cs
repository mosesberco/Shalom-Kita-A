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
    public partial class HebrewGame_sapir : Form
    {
        //משחק אות פותחת
        private User user;
        private int correctanswer;
        private int questionNumber;
        private int totalQuestions = 5;
        private List<string> correctImagePaths;
        private List<string> incorrectImagePaths;
        private Random random;
        private int correctImageDisplayedIndex;
        private string correctImagePath;
        private Timer timer;
        private int delayInSeconds = 1;
        private Image im;
        private bool isDelayActive;
        private Button[] answerButtons;
        private int randomQuestion;
        private int coins;





        // Initializes a new instance of the "Form1" class.
        // Sets up the timer, random generator, and answer buttons.
        public HebrewGame_sapir(User user)
        {
            this.user = user;
            InitializeComponent();
            InitializeTimer();
            random = new Random();
            questionNumber = 0;
            InitializeAnswerButtons();
            startOver.Visible = false;
            foreach (var button in answerButtons)
            {
                button.Enabled = false;
            }

        }

        // Initializes the answer buttons.
        private void InitializeAnswerButtons()
        {
            answerButtons = new Button[] { answer1, answer2, answer3 }; // Initialize with your actual buttons
        }

        // Initializes the timer with a specified interval and event handler.
        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = delayInSeconds * 1000; // Convert seconds to milliseconds
            timer.Tick += Timer_Tick;
        }

        // Handles the timer tick event. Stops the timer and randomizes the next question if the game is still active.
        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            isDelayActive = false;
            if (questionNumber < totalQuestions)
            {

                picsRandomize(); // Trigger randomization after timer elapses
            }
        }

        // Randomizes the pictures for the current question.
        private void picsRandomize()
        {
            if (!isDelayActive)
            {
                randomQuestion = random.Next(1, 23);
                askQuestion(randomQuestion);
                buttonRandomize.Enabled = false;
                int correctImageIndex = random.Next(correctImagePaths.Count);
                correctImagePath = correctImagePaths[correctImageIndex];
                HashSet<int> selectedIndexes = new HashSet<int>();
                string[] displayedImagePaths = new string[3];
                correctImageDisplayedIndex = random.Next(3);
                displayedImagePaths[correctImageDisplayedIndex] = correctImagePath;
                for (int i = 0; i < 3; i++)
                {
                    if (i == correctImageDisplayedIndex)
                        continue;

                    int index;
                    do
                    {
                        index = random.Next(incorrectImagePaths.Count);
                    } while (selectedIndexes.Contains(index));

                    selectedIndexes.Add(index);
                    displayedImagePaths[i] = incorrectImagePaths[index];
                }
                letterPic.BackgroundImage = im;
                answer1.BackgroundImage = Image.FromFile(displayedImagePaths[0]);
                answer2.BackgroundImage = Image.FromFile(displayedImagePaths[1]);
                answer3.BackgroundImage = Image.FromFile(displayedImagePaths[2]);
                questionNumber++;

                foreach (var button in answerButtons)
                {
                    button.Enabled = true;
                }
            }


        }

        // Checks the user's answer and updates the game state accordingly.
        private void CheckAnswerEventer(object sender, EventArgs e)
        {
            Label[] labels = { option3, option2, option1 };
            Button clickedPictureButton = sender as Button;
            int clickedIndex = Array.IndexOf(new[] { answer1, answer2, answer3 }, clickedPictureButton);

            if (clickedIndex == correctImageDisplayedIndex)
            {
                clickedPictureButton.BackColor = Color.Green;
                labels[correctImageDisplayedIndex].BackColor = Color.Green;
                MessageBox.Show("תשובה נכונה");
                correctanswer++;
                isDelayActive = true;
                timer.Start();

            }
            else
            {
                clickedPictureButton.BackColor = Color.Red;
                labels[correctImageDisplayedIndex].BackColor = Color.Green;
                labels[clickedIndex].BackColor = Color.Red;
                MessageBox.Show("תשובה לא נכונה");
                isDelayActive = true;
                timer.Start();

            }
            if (questionNumber == totalQuestions)
            {
                EndGame();
            }
            foreach (Label l in labels)
            {
                l.BackColor = Color.White;
            }
            foreach (var button in answerButtons)
            {
                button.Enabled = false;
            }

        }

        // Handles the form load event by adding event handlers for the answer buttons.
        private void Form1_Load(object sender, EventArgs e)
        {
            answer1.Click += new EventHandler(CheckAnswerEventer);
            answer2.Click += new EventHandler(CheckAnswerEventer);
            answer3.Click += new EventHandler(CheckAnswerEventer);
        }

        // Starts the game by initializing game state and randomizing the first question.
        private void startGame(object sender, EventArgs e)
        {
            buttonRandomize.Visible = false;
            correctanswer = 0;
            questionNumber = 0;
            coins = 0;
            picsRandomize();

        }

        // Ends the game, displays the final score, and shows the start over button.
        private void EndGame()
        {
            MessageBox.Show("         !סוף המשחק" + Environment.NewLine + "צדקת ב " + correctanswer + " מתוך " + totalQuestions + " שאלות" + Environment.NewLine + " הרווחת " + correctanswer * 100 + " מטבעות!");
            coins = correctanswer * 100;
            startOver.Visible = true;
            isDelayActive = false;
            var DB = new Database();
            var balance = DB.GetBalance(int.Parse(user.ID));
            DB.SetBalance(int.Parse(user.ID), (correctanswer) + balance);
            Close();

        }

        // Restarts the game by hiding the start over button and calling startGame.
        private void StartOverTheGame(object sender, EventArgs e)
        {
            startOver.Visible = false;
            startGame(null, EventArgs.Empty);
        }


        private void askQuestion(int qnum)
        {

            switch (qnum)
            {
                case 1:
                    //א
                    //letterPic.BackgroundImage = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    im = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    correctImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\אגס.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\אגרטל.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ארון.png"

                    };
                    incorrectImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ברווז.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\כתר.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\זמר.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\רכבת.png"
                    };
                    break;
                case 2:
                    //ב
                    //letterPic.BackgroundImage = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    im = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ב.jpg");
                    correctImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\בייגלה.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\בית.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\בננה.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ברווז.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\בלון.png"

                    };
                    incorrectImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\יין.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\כתר.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\זמר.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\לטאה.jpg"
                    };
                    break;
                case 3:
                    //ג
                    //letterPic.BackgroundImage = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    im = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ג.jpg");
                    correctImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\גזר.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\גלגל.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\גמל.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\גרזן.png"

                    };
                    incorrectImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\לב.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\מכונית.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\נר.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\רכבת.png"
                    };
                    break;
                case 4:
                    //ד
                    //letterPic.BackgroundImage = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    im = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ד.jpg");
                    correctImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\דג.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\דולפין.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\דחליל.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\דרדס.png"

                    };
                    incorrectImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\זבוב.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\מטוס.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\לגו.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\רמזור.jpg"
                    };
                    break;
                case 5:
                    //ה
                    //letterPic.BackgroundImage = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    im = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ה.jpg");
                    correctImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\הגה.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\היפופוטם.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\הר.jpg"

                    };
                    incorrectImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\אגרטל.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\כלב.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\סוס.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ספר.png"
                    };
                    break;
                case 6:
                    //ו
                    //letterPic.BackgroundImage = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    im = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ו.jpg");
                    correctImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\וופל.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\וורד.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\וילון.png"

                    };
                    incorrectImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ברווז.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\טווס.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\זמר.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\יונה.jpg"
                    };
                    break;
                case 7:
                    //ז
                    //letterPic.BackgroundImage = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    im = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ז.jpg");
                    correctImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\זבוב.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\זמר.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\זאב.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\זברה.jpg"

                    };
                    incorrectImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\היפופוטם.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\כתר.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\טניס.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\חזיר.jpg"
                    };
                    break;
                case 8:
                    //ח
                    //letterPic.BackgroundImage = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    im = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ח.jpg");
                    correctImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\חבל.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\חזיר.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\חציל.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\חתול.jpg"

                    };
                    incorrectImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ברווז.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\כתר.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\עטלף.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\עיןן.png"
                    };
                    break;
                case 9:
                    //ט
                    //letterPic.BackgroundImage = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    im = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ט.jpg");
                    correctImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\טבח.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\טווס.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\טניס.png"

                    };
                    incorrectImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\תמנון.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\תרנגול.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\זמר.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\שימלה.png"
                    };
                    break;
                case 10:
                    //י
                    //letterPic.BackgroundImage = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    im = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\י.jpg");
                    correctImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\יד.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\יונה.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\יין.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ינשוף.png"

                    };
                    incorrectImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\חציל.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\כריש.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\זבוב.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\רכבת.png"
                    };
                    break;
                case 11:
                    //כ
                    //letterPic.BackgroundImage = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    im = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\כ.jpg");
                    correctImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\כלב.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\כריש.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\כתר.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\כדור.jpg"

                    };
                    incorrectImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\קרנף.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\צוללת.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\קנגרו.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\רכבת.png"
                    };
                    break;
                case 12:
                    //ל
                    //letterPic.BackgroundImage = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    im = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ל.jpg");
                    correctImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\לב.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\לגו.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\לוח.jpeg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\לטאה.jpg"

                    };
                    incorrectImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ברווז.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\נקניקיהה.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\מטוס.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\חתול.jpg"
                    };
                    break;
                case 13:
                    //מ
                    //letterPic.BackgroundImage = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    im = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\מ.jpg");
                    correctImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\מטוס.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\מכונית.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\מסוק.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\משאית.JPG"

                    };
                    incorrectImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ספיידרמן.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\סרטן.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\עטלף.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\פטריה.jpg"
                    };
                    break;
                case 14:
                    //נ
                    //letterPic.BackgroundImage = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    im = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\נ.jpg");
                    correctImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\נחש.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\נקניקיהה.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\נר.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\נמר.jpg"

                    };
                    incorrectImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\דחליל.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\בלון.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\גלגל.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\רכבת.png"
                    };
                    break;
                case 15:
                    //ס
                    //letterPic.BackgroundImage = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    im = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ס.png");
                    correctImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ספיידרמן.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\סוס.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ספר.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\סרטן.jpg"

                    };
                    incorrectImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\שימלה.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\קקטוס.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\פרפר.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\מסוק.jpg"
                    };
                    break;
                case 16:
                    //ע
                    //letterPic.BackgroundImage = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    im = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ע.jpg");
                    correctImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\עטלף.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\עיןן.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ענן.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\עקרב.png"

                    };
                    incorrectImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\הר.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\אגס.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\אגרטל.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\רכבת.png"
                    };
                    break;
                case 17:
                    //פ
                    //letterPic.BackgroundImage = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    im = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\פ.jpg");
                    correctImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\פטריה.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\פיל.JPG",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\פרה.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\פרפר.jpg"

                    };
                    incorrectImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\צדפים.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\נמר.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\זמר.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\צלם.jpg"
                    };
                    break;
                case 18:
                    //צ
                    //letterPic.BackgroundImage = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    im = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\צ.jpg");
                    correctImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\צב.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\צדפים.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\צוללת.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\צלם.jpg"

                    };
                    incorrectImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\תפוח.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\משאית.JPG",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\לטאה.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\סוס.jpg"
                    };
                    break;
                case 19:
                    //ק
                    //letterPic.BackgroundImage = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    im = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ק.jpg");
                    correctImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\קוף.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\קנגרו.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\קקטוס.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\קרנף.jpg"

                    };
                    incorrectImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\כריש.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\כתר.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\כלב.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\סרטן.jpg"
                    };
                    break;
                case 20:
                    //ר
                    //letterPic.BackgroundImage = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    im = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ר.jpg");
                    correctImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\רכבת.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\רמזור.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\רשת.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\רגל.jpg"

                    };
                    incorrectImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ברווז.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\צוללת.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\עיןן.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\נחש.jpg"
                    };
                    break;
                case 21:
                    //ש
                    //letterPic.BackgroundImage = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    im = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ש.jpg");
                    correctImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\שזיף.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\שימלה.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\שמש.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\שן.jpg"

                    };
                    incorrectImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ספר.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\צדפים.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\זמר.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\פטריה.jpg"
                    };
                    break;
                case 22:
                    //ת
                    //letterPic.BackgroundImage = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\א.jpg");
                    im = Image.FromFile(@"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\ת.jpg");
                    correctImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\תמנון.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\תמרורר.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\תפוח.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\תרנגול.jpg"

                    };
                    incorrectImagePaths = new List<string>
                    {
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\טווס.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\כתר.png",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\טבח.jpg",
                        @"C:\Users\Sapir Shenkor\source\repos\project-game\project-game\Resources\יונה.jpg"
                    };
                    break;


            }


        }
    }
}

