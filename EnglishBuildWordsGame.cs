using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using MaterialSkin;
using MaterialSkin.Controls;


namespace final_project
{
    public partial class EnglishBuildWordsGame : MaterialForm
    {
        private Label lettersLabel;
        private Random random;
        private List<string> currentGroupWords;
        private Dictionary<string, List<string>> groupWordsDict;
        private Timer gameTimer;
        private Label scoreLabel;
        private Label timerLabel;
        private int currentScore;
        private int timeRemaining;
        private List<string> checkedWords;
        private User user;

        public EnglishBuildWordsGame(User user)
        {
            this.user = user;
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red800, Primary.Red700, Primary.Blue500, Accent.LightBlue400, TextShade.WHITE);
            InitializeGameComponents();
            LoadRandomGroupFromExcel();
            checkedWords = new List<string>(); // Initialize the list
        }

        private void PrintAllGroups(List<string> allGroups)
        {
            string allGroupsContent = string.Join(Environment.NewLine, allGroups);
            MessageBox.Show(allGroupsContent, "All Groups");
        }

        private void PrintGroupWordsDict()
        {
            string dictContent = string.Join(Environment.NewLine,
                groupWordsDict.Select(kvp => $"{kvp.Key}: {string.Join(", ", kvp.Value)}"));
            MessageBox.Show(dictContent, "Group Words Dictionary");
        }

        private void LoadRandomGroupFromExcel()
        {
            // Load all groups from Excel into a list
            List<string> allGroups = new List<string>();
            groupWordsDict = new Dictionary<string, List<string>>();
            // Specify your Excel file path
            string filePath = @"..\..\EnglishBuildWordsGameData.xlsx";

            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1); // Assuming data is in the first sheet

                    // Read data from Excel and populate list of all groups and their corresponding words
                    var rows = worksheet.RowsUsed().Skip(1); // Skip header row
                    foreach (var row in rows)
                    {
                        string group = row.Cell(2).GetString(); // Assuming Groups is in the second column
                        allGroups.Add(group);

                        List<string> words = new List<string>();
                        for (int colIndex = 3; colIndex <= row.LastCellUsed().Address.ColumnNumber; colIndex++)
                        {
                            string word = row.Cell(colIndex).GetString();
                            if (!string.IsNullOrEmpty(word))
                            {
                                words.Add(word);
                            }
                        }
                        groupWordsDict[group] = words;
                    }
                }
                Console.WriteLine(groupWordsDict);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data from Excel: {ex.Message}");
            }

            PrintAllGroups(allGroups);
            PrintGroupWordsDict();

            // Select a random group from allGroups
            if (allGroups.Any())
            {
                int randomIndex = random.Next(0, allGroups.Count);
                string randomGroup = allGroups[randomIndex];

                // Retrieve words for the selected group
                currentGroupWords = groupWordsDict[randomGroup];

                // Display the letters label with the random group
                lettersLabel.Text = "Letters: " + randomGroup;
            }
        }

        private void InitializeGameComponents()
        {
            random = new Random();

            lettersLabel = new Label();
            lettersLabel.Font = new Font("Calibri", 20, FontStyle.Bold);
            lettersLabel.AutoSize = true;
            lettersLabel.Location = new System.Drawing.Point(420, 140);
            this.Controls.Add(lettersLabel);

            scoreLabel = new Label();
            scoreLabel.Font = new Font("Calibri", 20, FontStyle.Bold);
            scoreLabel.AutoSize = true;
            scoreLabel.Location = new System.Drawing.Point(450, 200); // Adjust location as needed
            scoreLabel.Text = "Score: 0";
            this.Controls.Add(scoreLabel);

            timerLabel = new Label();
            timerLabel.Font = new Font("Calibri", 20, FontStyle.Bold);
            timerLabel.AutoSize = true;
            timerLabel.Location = new System.Drawing.Point(680, 85); // Adjust location as needed
            timerLabel.Text = "Time: 60"; // Initialize with 60 seconds
            this.Controls.Add(timerLabel);

            currentScore = 0;
            timeRemaining = 60;

            gameTimer = new Timer();
            gameTimer.Interval = 1000; // 1 second intervals
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (timeRemaining > 0)
            {
                timeRemaining--;
                timerLabel.Text = "Time: " + timeRemaining;
            }
            else
            {
                gameTimer.Stop();
                MessageBox.Show("Time's up! Final Score: " + currentScore);
                var DB = new Database();
                var balance = DB.GetBalance(int.Parse(user.ID));
                DB.SetBalance(int.Parse(user.ID), (currentScore/ 10) + balance);
                // Optionally, you can disable input here
            }
        }

        private void GenerateAndDisplayRandomLetters()
        {
            string letters = GenerateRandomLetters(5);
            lettersLabel.Text = "Letters: " + letters;
        }

        private string GenerateRandomLetters(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] letterArray = new char[length];

            for (int i = 0; i < length; i++)
            {
                letterArray[i] = chars[random.Next(chars.Length)];
            }

            return new string(letterArray);
        }

        private void CheckWord(string word)
        {
            // Check if the word is alphanumeric and within length 2 to 5
            if (word.All(char.IsLetter) && word.Length >= 2 && word.Length <= 5)
            {
                if (currentGroupWords != null && currentGroupWords.Contains(word))
                {
                    if (!checkedWords.Contains(word))
                    {
                        checkedWords.Add(word); // Use Add method to add the word
                        MessageBox.Show($"Correct! \"{word}\" is one of the words. +10 points");
                        UpdateScore(10); // Add points for a correct word
                    }
                    else
                    {
                        MessageBox.Show($"You already used the word \"{word}\"!");
                    }
                }
                else
                {
                    MessageBox.Show($"Incorrect! \"{word}\" is not in the group.");
                    //UpdateScore(-5); // Optionally, subtract points for an incorrect word
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid word consisting of 2 to 5 letters only.");
            }
        }

        private void UpdateScore(int points)
        {
            currentScore += points;
            scoreLabel.Text = "Score: " + currentScore;
        }

        private void TitleGame_TextChanged(object sender, EventArgs e)
        {
        }

        private void CheckIfWordInGroup_Click(object sender, EventArgs e)
        {
            // Retrieve the text from textBox1
            string input = TxtFD1.Text.Trim();

            // Call CheckWord method with the input text
            CheckWord(input);
        }

        
      
        private void TxtFD1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
