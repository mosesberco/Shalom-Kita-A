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
    public partial class Game_Udi: Form
    {
        Question_udi[] questions;
        List<Question_udi> wrong_answers = new List<Question_udi>();
        int totalQuestions, index, score;
        Random random = new Random();
        private User user;

        public Game_Udi(User user)
        {
            InitializeComponent();
            questions = Question_udi.generateQuestions(10);
            totalQuestions = 10;
            index = 0;
            score = 0;
            this.user = user;
            nextQuestion();
            setButtons();
            progressBar1.Maximum = totalQuestions;
            var DB = new Database();
            var balance = DB.GetBalance(int.Parse(user.ID));
            userData.Text = $"שם משתמש : {user.Username}\nמטבעות : {balance}";
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        public void nextQuestion()
        {
            lblQuestion.Text = $"{this.index+1}.  "+this.questions[this.index].toString();
            scoreLabel.Text = $"נקודות : {this.score}/{this.totalQuestions}";
            scoreLabel.RightToLeft = RightToLeft.Yes;
        }
        private async void checkAnswerEvent(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
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
            // Disable all buttons to prevent multiple clicks
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
                DB.SetBalance(int.Parse(user.ID), score + balance);
                Close();
            }
            else
            {
                setButtons();
                nextQuestion();
            }
        }
        private void ResetButtonColors()
        {
            button1.BackColor = Color.Transparent;
            button2.BackColor = Color.Transparent;
            button3.BackColor = Color.Transparent;
            button4.BackColor = Color.Transparent;
        }
        private void SetButtonsEnabled(bool enabled)
        {
            button1.Enabled = enabled;
            button2.Enabled = enabled;
            button3.Enabled = enabled;
            button4.Enabled = enabled;
        }
        private bool gameOver()         //CFG
        {
            if (index == totalQuestions)
            {
                string message = $"Your score is {this.score}/{this.totalQuestions}\n";
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
                MessageBox.Show($"You earned {score} coins this game!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            return false;
        }
        private bool checkAnswer(int btnANswer)
        {
            return btnANswer == questions[index].getCorrectAnswer();
        }
        internal void setButtons()
        {
            Button[] buttons = { button1, button2, button3, button4 };
            int correctIndex = random.Next(0, 4);
            int correctAnswer = questions[index].getCorrectAnswer();
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

