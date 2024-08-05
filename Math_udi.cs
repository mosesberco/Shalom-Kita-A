using MaterialSkin;
using MaterialSkin.Controls;
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
    public partial class Game_Udi : MaterialForm
    {
        Question_udi[] questions;
        List<Question_udi> wrong_answers = new List<Question_udi>();
        int totalQuestions, index, score;
        Random random = new Random();
        private User user;
        private MaterialButton[] buttons;
        public Game_Udi(User user)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.Green900, Primary.Orange700, Accent.Orange400, TextShade.WHITE);
            this.questions = Question_udi.generateQuestions(10);
            this.totalQuestions = 10;
            this.index = 0;
            this.score = 0;
            this.user = user;
            buttons = new MaterialButton[] { button1, button2, button3, button4 };
            nextQuestion();
            setButtons();
            progressBar1.Maximum = totalQuestions;
            userData.Text = $"Username : {user.Username}\nBalance : {user.Balance}";
        }
        public void nextQuestion()
        {
            lblQuestion.Text = $"#{this.index + 1}.  " + this.questions[this.index].toString();
            lblQuestion.Text = $"#{this.index+1}.  "+this.questions[this.index].toString();
            scoreLabel.Text = $"Score : {this.score}/{this.totalQuestions}";
        }
        private async void checkAnswerEvent(object sender, EventArgs e)
        {
            MaterialButton clickedButton = (MaterialButton)sender;
            int btnAnswer = int.Parse(clickedButton.Text);

            if (checkAnswer(btnAnswer))
            {
                score += 1;
                clickedButton.BackColor = Color.Green;
            }
            else
            {
                wrong_answers.Add(this.questions[index]);
                clickedButton.BackColor = Color.Red;
            }

            SetButtonsEnabled(false);
            // Wait for 1 second
            await Task.Delay(1100);
            // Reset button colors and re-enable them
            ResetButtonColors();
            SetButtonsEnabled(true);
            progressBar1.Value = this.index + 1;
            this.index++;

            if (gameOver())
            {
                var DB = new Database();
                var balance = DB.GetBalance(int.Parse(user.ID));
                DB.SetBalance(int.Parse(user.ID), (score / 10) + balance);
                DB.SetBalance(int.Parse(user.ID), score + balance);
                //MessageBox.Show($"You earned {score / 10} points this game!","Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                setButtons();
                nextQuestion();
            }
        }

        private void ResetButtonColors()
        {
            foreach (var button in buttons)
            {
                button.BackColor = Color.DarkSeaGreen;
            }
        }

        private void SetButtonsEnabled(bool enabled)
        {
            foreach (var button in buttons)
            {
                button.Enabled = enabled;
            }
        }
        private bool gameOver()
        {
            if (this.index == 10)
            {
                string message = $"Your score is {this.score}/{this.totalQuestions * 10}\nYour Grade is {this.score}!!!\n\n";
                if (wrong_answers.Count > 0)
                {
                    message += "Questions you got wrong:\n\n";
                    for (int i = 0; i < wrong_answers.Count; i++)
                    {
                        Question_udi q = wrong_answers[i];
                        message += $"{i + 1}. {q.toString()}\n   Correct answer: {q.getCorrectAnswer()}\n\n";
                    }
                }
                else
                {
                    message += "Congratulations! You got all questions right!";
                }
                MessageBox.Show(message, "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show($"You earned {score} points this game!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            return false;
        }

        private bool checkAnswer(int btnAnswer)
        {
            return btnAnswer == this.questions[this.index].getCorrectAnswer();
        }
        internal void setButtons()
        {
            int correctIndex = random.Next(0, 4);
            int correctAnswer = this.questions[index].getCorrectAnswer();
            HashSet<int> usedNumbers = new HashSet<int> { correctAnswer };

            for (int i = 0; i < 4; i++)
            {
                if (i == correctIndex)
                {
                    buttons[i].Text = $"{correctAnswer}";
                }
                else
                {
                    int wrongAnswer;
                    do
                    {
                        wrongAnswer = random.Next(1, 21);
                    } while (usedNumbers.Contains(wrongAnswer));

                    usedNumbers.Add(wrongAnswer);
                    buttons[i].Text = $"{wrongAnswer}";
                }
            }
        }
    }
}

