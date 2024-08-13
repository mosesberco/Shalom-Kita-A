using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace final_project
{
    public partial class EnglishMenu : Form
    {
        private User user;

        public EnglishMenu(User user)
        {
            InitializeComponent();
            this.user = user;

            this.Text = "Create the Words - Menu";
            this.Size = new Size(1024, 768);
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponents();
            SetupBackgroundImage();
        }

        private void InitializeComponents()
        {
            TableLayoutPanel mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 5,
                Padding = new Padding(20),
                BackColor = Color.Transparent
            };

            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 10));

            // Exit Button Layout (top-right)
            TableLayoutPanel exitLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
            };

            // Title Label
            Label titleLabel = new Label
            {
                Text = "Welcome To \"Create the Words\"",
                Font = new Font("Gill Sans MT", 24, FontStyle.Bold),
                AutoSize = true,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Rules Label
            Label rulesLabel = new Label
            {
                Text = "חוקי המשחק:\n" +
                       "1. מטרה: עליך ליצור כמה שיותר מילים מחמש אותיות נתונות בזמן של 90 שניות.\n" +
                       "2. זמן משחק: למשחק יש זמן קצוב של 90 שניות.\n" +
                       "3. צבירת נקודות:\n" +
                       "   * כל מילה תקינה שנוצרת מעניקה 10 נקודות.\n" +
                       "   * נסה ליצור לפחות 5 מילים בזמן המוקצב.\n" +
                       "4. חוקי מילים:\n" +
                       "   * כל מילה צריכה להיות בתוקף (לפי מילון או רשימת מילים תקנית).\n" +
                       "   * יש להשתמש אך ורק באותיות הנתונות.\n" +
                       "בהצלחה!",
                Font = new Font("Gill Sans MT", 12, FontStyle.Bold),
                AutoSize = true,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopCenter,
                RightToLeft = RightToLeft.Yes,
                BackColor = Color.FromArgb(200, 255, 255, 255)
            };

            // Start Game Button
            ModernButton startGameButton = new ModernButton
            {
                Text = "Let's Start The Game",
                Size = new Size(200, 50),
                Anchor = AnchorStyles.None,
                Dock = DockStyle.None,
                BackColor = Color.Blue
            };
            startGameButton.Click += StartGameButton_Click;

            // User Info Label
            Label userInfoLabel = new Label
            {
                Text = $"Player: {user.Username} | Balance: {user.Balance}",
                Font = new Font("Gill Sans MT", 14),
                AutoSize = true,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Exit Button
            ModernButton EXITGameButton = new ModernButton
            {
                Text = "Exit",
                Size = new Size(70, 50),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Dock = DockStyle.None,
                BackColor = Color.Red,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            EXITGameButton.Click += EXITGameButton_Click;

            exitLayout.Controls.Add(new Label(), 0, 0);
            exitLayout.Controls.Add(EXITGameButton, 1, 0);

            mainLayout.Controls.Add(titleLabel, 0, 0);
            mainLayout.Controls.Add(rulesLabel, 0, 2);
            mainLayout.Controls.Add(startGameButton, 0, 3);
            mainLayout.Controls.Add(EXITGameButton, 1, 3);
            mainLayout.Controls.Add(userInfoLabel, 0, 4);

            this.Controls.Add(mainLayout);
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            EnglishBuildWordsGame gameForm = new EnglishBuildWordsGame(user);
            //
            Menu menu = new Menu(user);
            gameForm.FormClosed += (s, args) =>
            {
                menu.Show();
            };
            //
            gameForm.Show();
        }

        private void EXITGameButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (this.BackgroundImage != null)
            {
                e.Graphics.DrawImage(this.BackgroundImage, ClientRectangle);
            }
            else
            {
                base.OnPaintBackground(e);
            }
        }

        private void SetupBackgroundImage()
        {
            try
            {
                this.BackgroundImage = Properties.Resources.ilan_menu;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading background image: {ex.Message}", "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}