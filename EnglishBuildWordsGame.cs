using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;


namespace final_project
{
    public partial class EnglishBuildWordsGame : Form
    {
        private User user;
        private Label lettersLabel;
        private Label scoreLabel;
        private Label timerLabel;
        private ModernTextBox wordInputBox;
        private ModernButton checkWordButton;
        private ModernButton hintButton;
        private FlowLayoutPanel wordsFoundPanel;
        private Random random;
        private List<string> currentGroupWords;
        private Dictionary<string, List<string>> groupWordsDict;
        private Timer gameTimer;
        private int currentScore;
        private int timeRemaining;
        private List<string> checkedWords;
        private Label progressLabel;
        private int wordsFound;
        private const int WordsToWin = 5;

        public EnglishBuildWordsGame(User user)
        {
            InitializeComponent();
            
            this.user = user;

            this.Text = "Create the Words";
            this.MinimumSize = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            SetupBackgroundImage();
            this.Paint += EnglishBuildWordsGame_Paint;

            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                BackColor = Color.Transparent
            };
            this.Controls.Add(mainPanel);

            InitializeGameComponents(mainPanel);
            LoadRandomGroupFromExcel();
            checkedWords = new List<string>();

        }


        private void InitializeGameComponents(Panel mainPanel)
        {
            random = new Random();

            lettersLabel = new Label
            {
                Font = new Font("Gill Sans MT", 20, FontStyle.Bold),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(20, 20)
            };
            mainPanel.Controls.Add(lettersLabel);

            scoreLabel = new Label
            {
                Font = new Font("Gill Sans MT", 16, FontStyle.Bold),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(mainPanel.Width - 150, 20)
            };
            mainPanel.Controls.Add(scoreLabel);

            timerLabel = new Label
            {
                Font = new Font("Gill Sans MT", 16, FontStyle.Bold),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(mainPanel.Width - 150, 60)
            };
            mainPanel.Controls.Add(timerLabel);

            wordInputBox = new ModernTextBox
            {
                Size = new Size(mainPanel.Width - 340, 40),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Location = new Point(20, 100)
            };

            progressLabel = new Label
            {
                Font = new Font("Gill Sans MT", 14, FontStyle.Bold),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(20, 60),
                Text = $"Progress: 0/{WordsToWin}"
            };
            mainPanel.Controls.Add(progressLabel);


            mainPanel.Controls.Add(wordInputBox);

            checkWordButton = new ModernButton
            {
                Text = "Check Word",
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(135, 60, 214),
                ForeColor = Color.White,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(mainPanel.Width - 220, 100)
            };
            checkWordButton.Click += CheckWordButton_Click;
            mainPanel.Controls.Add(checkWordButton);

            hintButton = new ModernButton
            {
                Text = "Hint",
                Size = new Size(80, 40),
                BackColor = Color.FromArgb(135, 60, 214),
                ForeColor = Color.White,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(mainPanel.Width - 100, 100)
            };
            hintButton.Click += HintButton_Click;
            mainPanel.Controls.Add(hintButton);

            Label wordsFoundLabel = new Label
            {
                Text = "Words Found:",
                Font = new Font("Gill Sans MT", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 160)
            };
            mainPanel.Controls.Add(wordsFoundLabel);

            wordsFoundPanel = new FlowLayoutPanel
            {
                Size = new Size(mainPanel.Width - 40, 100),
                Location = new Point(20, 190),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                AutoScroll = true,
                BorderStyle = BorderStyle.FixedSingle
            };
            mainPanel.Controls.Add(wordsFoundPanel);

            ModernButton EXITGameButton = new ModernButton
            {
                Text = "Exit",
                Size = new Size(70, 30),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(mainPanel.Width - 100, 150),
                Dock = DockStyle.None,
                BackColor = Color.Red,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            mainPanel.Controls.Add(EXITGameButton);
            EXITGameButton.Click += ExitGameButton_Click;

            Label userInfoLabel = new Label
            {
                Text = $"Player: {user.Username} | Balance: {user.Balance}",
                Font = new Font("Gill Sans MT", 12),
                AutoSize = true,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                Location = new Point(20, mainPanel.Height - 40),
            };
            userInfoLabel.BackColor = Color.FromArgb(200, Color.White);
            mainPanel.Controls.Add(userInfoLabel);

            currentScore = 0;
            timeRemaining = 60;
            UpdateScoreLabel();
            UpdateTimerLabel();

            gameTimer = new Timer
            {
                Interval = 1000
            };
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();
        }

        private void CheckWordButton_Click(object sender, EventArgs e)
        {
            string word = wordInputBox.Text.Trim().ToLower();
            CheckWord(word);
            wordInputBox.Clear();
        }

        private void HintButton_Click(object sender, EventArgs e)
        {
            if (currentGroupWords != null && currentGroupWords.Count > 0)
            {
                int index = random.Next(0, currentGroupWords.Count);
                string hint = currentGroupWords[index];
                int indexHint = random.Next(0, 3);
                switch (indexHint)
                {
                    case 0:
                        char firstLet = hint[0];
                        MessageBox.Show($"Your Hint - a word starts with the letter '{firstLet}'", "Hint");
                        break;
                    case 1:
                        char endLet = hint[hint.Length - 1];
                        MessageBox.Show($"Your Hint - a word ends with the letter '{endLet}'", "Hint");
                        break;
                    case 2:
                        int numberOfLetters = hint.Length;
                        MessageBox.Show($"Your Hint - a word contains '{numberOfLetters}' letters", "Hint");
                        break;
                    default:
                        MessageBox.Show("Invalid hint type.", "Hint Error");
                        break;
                }
            }
            else
            {
                MessageBox.Show("No words available for hint.", "Hint Error");
            }
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
            // Select a random group from allGroups
            if (allGroups.Any())
            {
                int randomIndex = random.Next(0, allGroups.Count);
                string randomGroup = allGroups[randomIndex];

                // Retrieve words for the selected group
                currentGroupWords = groupWordsDict[randomGroup];

                string spacedGroup = string.Join(" ", randomGroup.ToCharArray());


                // Display the letters label with the random group
                lettersLabel.Text = "Letters: " + spacedGroup;
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (timeRemaining > 0)
            {
                timeRemaining--;
                UpdateTimerLabel();
            }
            else
            {
                EndGame(false);
            }
        }

        private void EndGame(bool won)
        {
            gameTimer.Stop();
            string message = won ?
                $"Congratulations! You found {wordsFound} words and won the game!" :
                $"Time's up! You found {wordsFound} words. Final Score: {currentScore}";

            message += "\n\nWords in this group:";
            foreach (var word in currentGroupWords)
            {
                message += $"\n- {word}";
            }

            ShowCustomMessageBox(message, "Game Over", MessageBoxIcon.Information, true);

            var DB = new Database();
            var balance = DB.GetBalance(int.Parse(user.ID));
            DB.SetBalance(int.Parse(user.ID), (currentScore / 10) + balance);
            int coins = (currentScore / 10);
            string woncoin = "Good Job! You Earned" + " " + coins + " " + "Coins";
            ShowCustomMessageBox(woncoin, "Total Coins", MessageBoxIcon.Information, false);
            this.Close();
        }

        private void ShowCustomMessageBox(string message, string title, MessageBoxIcon icon, bool gameover)
        {
            using (Form customBox = new Form())
            {
                customBox.Text = title;
                if(gameover)
                    customBox.ClientSize = new Size(300, 300);
                else
                    customBox.ClientSize = new Size(300, 160);
                customBox.FormBorderStyle = FormBorderStyle.FixedDialog;
                customBox.StartPosition = FormStartPosition.CenterParent;
                customBox.BackColor = Color.FromArgb(83, 189, 165);

                Label messageLabel = new Label();
                messageLabel.Text = message;
                messageLabel.AutoSize = true;
                messageLabel.Location = new Point(10, 10);
                messageLabel.MaximumSize = new Size(280, 0);
                messageLabel.Font = new Font("Gill Sans MT", 12, FontStyle.Regular);
                customBox.Controls.Add(messageLabel);

                Button okButton = new Button();
                okButton.Text = "OK";
                okButton.DialogResult = DialogResult.OK;
                okButton.FlatAppearance.BorderColor = Color.Black;
                okButton.Location = new Point(110, 130);
                okButton.BackColor = Color.FromArgb(255, 255, 255);
                okButton.ForeColor = Color.Black;
                okButton.Font = new Font("Gill Sans MT", 10, FontStyle.Bold);
                customBox.Controls.Add(okButton);

                customBox.AcceptButton = okButton;

                customBox.ShowDialog(this);
            }
        }

        private void UpdateScoreLabel()
        {
            scoreLabel.Text = $"Score: {currentScore}";
        }

        private void UpdateTimerLabel()
        {
            timerLabel.Text = $"Time: {timeRemaining}s";
        }

        private void CheckWord(string word)
        {
            if (word.All(char.IsLetter) && word.Length >= 2 && word.Length <= 5)
            {
                if (currentGroupWords != null && currentGroupWords.Contains(word))
                {
                    if (!checkedWords.Contains(word))
                    {
                        checkedWords.Add(word);
                        wordsFound++;
                        UpdateScore(10);
                        AddWordToFoundPanel(word);
                        UpdateProgressLabel();
                        ShowCustomMessageBox($"Correct!\r\n\r\n\"{word}\" is one of the words.\r\n\r\n+10 points", "Success", MessageBoxIcon.Information, false);
                        if (wordsFound >= WordsToWin)
                        {
                            EndGame(true);
                        }
                    }
                    else
                    {
                        ShowCustomMessageBox($"You already used the word \"{word}\"!", "Duplicate Word", MessageBoxIcon.Warning, false);
                    }
                }
                else
                {
                    ShowCustomMessageBox($"Incorrect! \"{word}\" is not in the group.", "Wrong Word", MessageBoxIcon.Error, false);
                }
            }
            else
            {
                ShowCustomMessageBox("Please enter a valid word consisting of 2 to 5 letters only.", "Invalid Input", MessageBoxIcon.Warning, false);
            }
        }

        private void UpdateProgressLabel()
        {
            progressLabel.Text = $"Progress: {wordsFound}/{WordsToWin}";
        }

        private void AddWordToFoundPanel(string word)
        {
            Label wordLabel = new Label
            {
                Text = word,
                AutoSize = true,
                Margin = new Padding(5),
                Font = new Font("Gill Sans MT", 12)
            };
            wordsFoundPanel.Controls.Add(wordLabel);
        }

        private void UpdateScore(int points)
        {
            currentScore += points;
            UpdateScoreLabel();
        }

        private void TitleGame_TextChanged(object sender, EventArgs e)
        {
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                       Color.FromArgb(219, 234, 254),
                                                                       Color.FromArgb(191, 219, 254),
                                                                       LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
        }

        private void SetupBackgroundImage()
        {
            try
            {
                this.BackgroundImage = Properties.Resources.ilan_game;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading background image: {ex.Message}", "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnglishBuildWordsGame_Paint(object sender, PaintEventArgs e)
        {
            if (this.BackgroundImage != null)
            {
                e.Graphics.DrawImage(this.BackgroundImage, ClientRectangle);
            }
        }

        private void ExitGameButton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }

 }
