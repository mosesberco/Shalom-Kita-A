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
        private User user;
        private int correctanswer;
        private int questionNumber;
        private int totalQuestions = 5;
        private List<Image> correctImagePaths;
        private List<Image> incorrectImagePaths;
        private Random random;
        private int correctImageDisplayedIndex;
        private Image correctImagePath;
        private Timer timer;
        private int delayInSeconds = 1;
        private Image im;
        private bool isDelayActive;
        private Button[] answerButtons;
        private int randomQuestion;
        private int coins;

        public HebrewGame_sapir(User user)
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            var DB = new Database();
            var balance = DB.GetBalance(int.Parse(user.ID));
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
            BackgroundImage= (Image)Properties.Resources.ResourceManager.GetObject("רקע");
            buttonRandomize.BackgroundImage= (Image)Properties.Resources.ResourceManager.GetObject("start");
            playerinfo.Text = user.Username.ToString() + ":שלום" + "\n" + "מטבעות: " + balance;
            playerinfo.BackColor = Color.Transparent;
            guidelines.Text = "ברוכים הבאים למשחק אות פותחת! עליכם לבחור את התמונה הנכונה אשר מתחילה באות המופיעה";
            guidelines.BackColor = Color.Transparent;
            backtomenu.Text = "חזרה לתפריט";
        }
        private void InitializeAnswerButtons()          // Initializes the answer buttons
        {
            answerButtons = new Button[] { answer1, answer2, answer3 };             // Initialize with your actual buttons
        }     
        private void InitializeTimer()          // Initializes the timer with a specified interval and event handler
        {
            timer = new Timer();
            timer.Interval = delayInSeconds * 1000; // Convert seconds to milliseconds
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)     // Handles the timer tick event. Stops the timer and randomizes the next question if the game is still active
        {
            timer.Stop();
            isDelayActive = false;
            if (questionNumber < totalQuestions)
            { 
                picsRandomize(); // Trigger randomization after timer elapses
            }
        }
        private void picsRandomize()            // Randomizes the pictures for the current question
        {
            if (!isDelayActive)
            {
                randomQuestion = random.Next(1, 23);
                askQuestion(randomQuestion);
                buttonRandomize.Enabled = false;
                int correctImageIndex = random.Next(correctImagePaths.Count);
                correctImagePath = correctImagePaths[correctImageIndex];
                HashSet<int> selectedIndexes = new HashSet<int>();
                Image[] displayedImagePaths = new Image[3];
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
                answer1.BackgroundImage = displayedImagePaths[0];
                answer2.BackgroundImage = displayedImagePaths[1];
                answer3.BackgroundImage = displayedImagePaths[2];
                questionNumber++;
                foreach (var button in answerButtons)
                {
                    button.Enabled = true;
                }
            }
        }      
        private void CheckAnswerEventer(object sender, EventArgs e)     // Checks the user's answer and updates the game state accordingly
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
        private void Form1_Load(object sender, EventArgs e)     // Handles the form load event by adding event handlers for the answer buttons
        {
            answer1.Click += new EventHandler(CheckAnswerEventer);
            answer2.Click += new EventHandler(CheckAnswerEventer);
            answer3.Click += new EventHandler(CheckAnswerEventer);
        }        
        private void startGame(object sender, EventArgs e)      // Starts the game by initializing game state and randomizing the first question
        {
            buttonRandomize.Visible = false;
            correctanswer = 0;
            questionNumber = 0;
            coins = 0;
            picsRandomize();
        }     
        private void EndGame()      // Ends the game, displays the final score, and shows the start over button
        {
            MessageBox.Show("!סוף המשחק" + Environment.NewLine + "צדקת ב " + correctanswer + " מתוך " + totalQuestions + " שאלות" + Environment.NewLine + "        הרווחת $ " + correctanswer * 3,
                "כל הכבוד", MessageBoxButtons.OK, MessageBoxIcon.Information);
            coins = correctanswer * 3;
            startOver.Visible = true;
            isDelayActive = false;
            var DB = new Database();
            var balance = DB.GetBalance(int.Parse(user.ID));
            DB.SetBalance(int.Parse(user.ID), (coins) + balance);
            Close();
        }   
        private void StartOverTheGame(object sender, EventArgs e)       // Restarts the game by hiding the start over button and calling startGame
        {
            startOver.Visible = false;
            startGame(null, EventArgs.Empty);
        }
        private void backtomenu_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void askQuestion(int qnum)
        { 
            switch (qnum)
            {
                case 1:
                    //א
                    im = (Image)Properties.Resources.ResourceManager.GetObject("א");
                    correctImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("אגס"),
                        (Image)Properties.Resources.ResourceManager.GetObject("אגרטל"),
                        (Image)Properties.Resources.ResourceManager.GetObject("ארון")

                    };
                    incorrectImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("ברווז"),
                        (Image)Properties.Resources.ResourceManager.GetObject("כתר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("זמר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("רכבת")
                    };
                    break;
                
                case 2:
                    //ב
                    im = (Image)Properties.Resources.ResourceManager.GetObject("ב");
                    correctImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("בייגלה"),
                        (Image)Properties.Resources.ResourceManager.GetObject("בית"),
                        (Image)Properties.Resources.ResourceManager.GetObject("בננה"),
                        (Image)Properties.Resources.ResourceManager.GetObject("ברווז"),
                        (Image)Properties.Resources.ResourceManager.GetObject("בלון")
                    };
                    incorrectImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("יין"),
                        (Image)Properties.Resources.ResourceManager.GetObject("כתר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("זמר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("לטאה")
                    };
                    break;

                case 3:
                    //ג
                    im = (Image)Properties.Resources.ResourceManager.GetObject("ג");
                    correctImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("גזר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("גלגל"),
                        (Image)Properties.Resources.ResourceManager.GetObject("גמל"),
                        (Image)Properties.Resources.ResourceManager.GetObject("גרזן")
                    };
                    incorrectImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("לב"),
                        (Image)Properties.Resources.ResourceManager.GetObject("מכונית"),
                        (Image)Properties.Resources.ResourceManager.GetObject("נר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("רכבת")
                    };
                    break;
                
                case 4:
                    //ד
                    im = (Image)Properties.Resources.ResourceManager.GetObject("ד");
                    correctImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("דג"),
                        (Image)Properties.Resources.ResourceManager.GetObject("דולפין"),
                        (Image)Properties.Resources.ResourceManager.GetObject("דחליל"),
                        (Image)Properties.Resources.ResourceManager.GetObject("דרדס")
                    };
                    incorrectImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("זבוב"),
                        (Image)Properties.Resources.ResourceManager.GetObject("מטוס"),
                        (Image)Properties.Resources.ResourceManager.GetObject("לגו"),
                        (Image)Properties.Resources.ResourceManager.GetObject("רמזור")
                    };
                    break;

                case 5:
                    //ה
                    im = (Image)Properties.Resources.ResourceManager.GetObject("ה");
                    correctImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("הגה"),
                        (Image)Properties.Resources.ResourceManager.GetObject("היפופוטם"),
                        (Image)Properties.Resources.ResourceManager.GetObject("הר")
                    };
                    incorrectImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("אגרטל"),
                        (Image)Properties.Resources.ResourceManager.GetObject("כלב"),
                        (Image)Properties.Resources.ResourceManager.GetObject("סוס"),
                        (Image)Properties.Resources.ResourceManager.GetObject("ספר")
                    };
                    break;

                case 6:
                    //ו
                    im = (Image)Properties.Resources.ResourceManager.GetObject("ו");
                    correctImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("וופל"),
                        (Image)Properties.Resources.ResourceManager.GetObject("וורד"),
                        (Image)Properties.Resources.ResourceManager.GetObject("וילון")
                    };
                    incorrectImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("ברווז"),
                        (Image)Properties.Resources.ResourceManager.GetObject("טווס"),
                        (Image)Properties.Resources.ResourceManager.GetObject("זמר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("יונה")
                    };
                    break;
                
                case 7:
                    //ז
                    im = (Image)Properties.Resources.ResourceManager.GetObject("ז");
                    correctImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("זבוב"),
                        (Image)Properties.Resources.ResourceManager.GetObject("זמר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("זאב"),
                        (Image)Properties.Resources.ResourceManager.GetObject("זברה")
                    };
                    incorrectImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("היפופוטם"),
                        (Image)Properties.Resources.ResourceManager.GetObject("כתר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("טניס"),
                        (Image)Properties.Resources.ResourceManager.GetObject("חזיר")
                    };
                    break;

                case 8:
                    //ח
                    im = (Image)Properties.Resources.ResourceManager.GetObject("ח");
                    correctImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("חבל"),
                        (Image)Properties.Resources.ResourceManager.GetObject("חזיר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("חציל"),
                        (Image)Properties.Resources.ResourceManager.GetObject("חתול")
                    };
                    incorrectImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("ברווז"),
                        (Image)Properties.Resources.ResourceManager.GetObject("כתר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("עטלף"),
                        (Image)Properties.Resources.ResourceManager.GetObject("עיןן")
                    };
                    break;

                case 9:
                    //ט
                    im = (Image)Properties.Resources.ResourceManager.GetObject("ט");
                    correctImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("טבח"),
                        (Image)Properties.Resources.ResourceManager.GetObject("טווס"),
                        (Image)Properties.Resources.ResourceManager.GetObject("טניס")
                    };
                    incorrectImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("תמנון"),
                        (Image)Properties.Resources.ResourceManager.GetObject("תרנגול"),
                        (Image)Properties.Resources.ResourceManager.GetObject("זמר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("שימלה")
                    };
                    break;
                
                case 10:
                    //י
                    im = (Image)Properties.Resources.ResourceManager.GetObject("י");
                    correctImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("יד"),
                        (Image)Properties.Resources.ResourceManager.GetObject("יונה"),
                        (Image)Properties.Resources.ResourceManager.GetObject("יין"),
                        (Image)Properties.Resources.ResourceManager.GetObject("ינשוף")
                    };
                    incorrectImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("חציל"),
                        (Image)Properties.Resources.ResourceManager.GetObject("כריש"),
                        (Image)Properties.Resources.ResourceManager.GetObject("זבוב"),
                        (Image)Properties.Resources.ResourceManager.GetObject("רכבת")
                    };
                    break;

                case 11:
                    //כ
                    im = (Image)Properties.Resources.ResourceManager.GetObject("כ");
                    correctImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("כלב"),
                        (Image)Properties.Resources.ResourceManager.GetObject("כריש"),
                        (Image)Properties.Resources.ResourceManager.GetObject("כתר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("כדור")
                    };
                    incorrectImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("קרנף"),
                        (Image)Properties.Resources.ResourceManager.GetObject("צוללת"),
                        (Image)Properties.Resources.ResourceManager.GetObject("קנגרו"),
                        (Image)Properties.Resources.ResourceManager.GetObject("רכבת")
                    };
                    break;

                case 12:
                    //ל
                    im = (Image)Properties.Resources.ResourceManager.GetObject("ל");
                    correctImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("לב"),
                        (Image)Properties.Resources.ResourceManager.GetObject("לגו"),
                        (Image)Properties.Resources.ResourceManager.GetObject("לוח"),
                        (Image)Properties.Resources.ResourceManager.GetObject("לטאה")
                    };
                    incorrectImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("ברווז"),
                        (Image)Properties.Resources.ResourceManager.GetObject("נקניקיהה"),
                        (Image)Properties.Resources.ResourceManager.GetObject("מטוס"),
                        (Image)Properties.Resources.ResourceManager.GetObject("חתול")
                    };
                    break;

                case 13:
                    //מ
                    im = (Image)Properties.Resources.ResourceManager.GetObject("מ");
                    correctImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("מטוס"),
                        (Image)Properties.Resources.ResourceManager.GetObject("מכונית"),
                        (Image)Properties.Resources.ResourceManager.GetObject("מסוק"),
                        (Image)Properties.Resources.ResourceManager.GetObject("משאית")
                    };
                    incorrectImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("ספיידרמן"),
                        (Image)Properties.Resources.ResourceManager.GetObject("סרטן"),
                        (Image)Properties.Resources.ResourceManager.GetObject("עטלף"),
                        (Image)Properties.Resources.ResourceManager.GetObject("פטריה")
                    };
                    break;

                case 14:
                    //נ
                    im = (Image)Properties.Resources.ResourceManager.GetObject("נ");
                    correctImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("נחש"),
                        (Image)Properties.Resources.ResourceManager.GetObject("נקניקיה"),
                        (Image)Properties.Resources.ResourceManager.GetObject("נר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("נמר")
                    };
                    incorrectImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("דחליל"),
                        (Image)Properties.Resources.ResourceManager.GetObject("בלון"),
                        (Image)Properties.Resources.ResourceManager.GetObject("גלגל"),
                        (Image)Properties.Resources.ResourceManager.GetObject("רכבת")
                    };
                    break;

                case 15:
                    //ס
                    im = (Image)Properties.Resources.ResourceManager.GetObject("ס");
                    correctImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("ספיידרמן"),
                        (Image)Properties.Resources.ResourceManager.GetObject("סוס"),
                        (Image)Properties.Resources.ResourceManager.GetObject("ספר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("סרטן")
                    };
                    incorrectImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("שימלה"),
                        (Image)Properties.Resources.ResourceManager.GetObject("קקטוס"),
                        (Image)Properties.Resources.ResourceManager.GetObject("פרפר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("מסוק")
                    };
                    break;

                case 16:
                    //ע
                    im = (Image)Properties.Resources.ResourceManager.GetObject("ע");
                    correctImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("עטלף"),
                        (Image)Properties.Resources.ResourceManager.GetObject("עיןן"),
                        (Image)Properties.Resources.ResourceManager.GetObject("ענן"),
                        (Image)Properties.Resources.ResourceManager.GetObject("עקרב")
                    };
                    incorrectImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("הר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("אגס"),
                        (Image)Properties.Resources.ResourceManager.GetObject("אגרטל"),
                        (Image)Properties.Resources.ResourceManager.GetObject("רכבת")
                    };
                    break;

                case 17:
                    //פ
                    im = (Image)Properties.Resources.ResourceManager.GetObject("פ");
                    correctImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("פטריה"),
                        (Image)Properties.Resources.ResourceManager.GetObject("פיל"),
                        (Image)Properties.Resources.ResourceManager.GetObject("פרה"),
                        (Image)Properties.Resources.ResourceManager.GetObject("פרפר")
                    };
                    incorrectImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("צדפים"),
                        (Image)Properties.Resources.ResourceManager.GetObject("נמר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("זמר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("צלם")
                    };
                    break;

                case 18:
                    //צ
                    im = (Image)Properties.Resources.ResourceManager.GetObject("צ");
                    correctImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("צב"),
                        (Image)Properties.Resources.ResourceManager.GetObject("צדפים"),
                        (Image)Properties.Resources.ResourceManager.GetObject("צוללת"),
                        (Image)Properties.Resources.ResourceManager.GetObject("צלם")
                    };
                    incorrectImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("תפוח"),
                        (Image)Properties.Resources.ResourceManager.GetObject("משאית"),
                        (Image)Properties.Resources.ResourceManager.GetObject("לטאה"),
                        (Image)Properties.Resources.ResourceManager.GetObject("סוס")
                    };
                    break;

                case 19:
                    //ק
                    im = (Image)Properties.Resources.ResourceManager.GetObject("ק");
                    correctImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("קוף"),
                        (Image)Properties.Resources.ResourceManager.GetObject("קנגרו"),
                        (Image)Properties.Resources.ResourceManager.GetObject("קקטוס"),
                        (Image)Properties.Resources.ResourceManager.GetObject("קרנף")
                    };
                    incorrectImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("כריש"),
                        (Image)Properties.Resources.ResourceManager.GetObject("כתר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("כלב"),
                        (Image)Properties.Resources.ResourceManager.GetObject("סרטן")
                    };
                    break;

                case 20:
                    //ר
                    im = (Image)Properties.Resources.ResourceManager.GetObject("ר");
                    correctImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("רכבת"),
                        (Image)Properties.Resources.ResourceManager.GetObject("רמזור"),
                        (Image)Properties.Resources.ResourceManager.GetObject("רשת"),
                        (Image)Properties.Resources.ResourceManager.GetObject("רגל")
                    };
                    incorrectImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("ברווז"),
                        (Image)Properties.Resources.ResourceManager.GetObject("צוללת"),
                        (Image)Properties.Resources.ResourceManager.GetObject("עיןן"),
                        (Image)Properties.Resources.ResourceManager.GetObject("נחש")
                    };
                    break;

                case 21:
                    //ש
                    im = (Image)Properties.Resources.ResourceManager.GetObject("ש");
                    correctImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("שזיף"),
                        (Image)Properties.Resources.ResourceManager.GetObject("שימלה"),
                        (Image)Properties.Resources.ResourceManager.GetObject("שמש"),
                        (Image)Properties.Resources.ResourceManager.GetObject("שן")
                    };
                    incorrectImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("ספר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("צדפים"),
                        (Image)Properties.Resources.ResourceManager.GetObject("זמר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("פטריה")
                    };
                    break;

                case 22:
                    //ת
                    im = (Image)Properties.Resources.ResourceManager.GetObject("ת");
                    correctImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("תמנון"),
                        (Image)Properties.Resources.ResourceManager.GetObject("תמרורר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("תפוח"),
                        (Image)Properties.Resources.ResourceManager.GetObject("תרנגול")
                    };
                    incorrectImagePaths = new List<Image>
                    {
                        (Image)Properties.Resources.ResourceManager.GetObject("טווס"),
                        (Image)Properties.Resources.ResourceManager.GetObject("כתר"),
                        (Image)Properties.Resources.ResourceManager.GetObject("טבח"),
                        (Image)Properties.Resources.ResourceManager.GetObject("יונה")
                    };
                    break;
            }
        }
    }
}

