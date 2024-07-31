
namespace final_project
{
    partial class EnsglishBuildWordsGameMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleGame = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.StartingGameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleGame
            // 
            this.TitleGame.AutoSize = true;
            this.TitleGame.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleGame.Location = new System.Drawing.Point(25, 9);
            this.TitleGame.Name = "TitleGame";
            this.TitleGame.Size = new System.Drawing.Size(1150, 97);
            this.TitleGame.TabIndex = 2;
            this.TitleGame.Text = "Wellcome To \"Create the Words\" ";
            this.TitleGame.Click += new System.EventHandler(this.TitleGame_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(147, 109);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(716, 207);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // StartingGameButton
            // 
            this.StartingGameButton.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartingGameButton.Location = new System.Drawing.Point(337, 348);
            this.StartingGameButton.Name = "StartingGameButton";
            this.StartingGameButton.Size = new System.Drawing.Size(283, 51);
            this.StartingGameButton.TabIndex = 4;
            this.StartingGameButton.Text = "Lets Start The Game";
            this.StartingGameButton.UseVisualStyleBackColor = true;
            this.StartingGameButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // EnsglishBuildWordsGameMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1147, 644);
            this.Controls.Add(this.StartingGameButton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.TitleGame);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Name = "EnsglishBuildWordsGameMenu";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label TitleGame;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button StartingGameButton;
    }
}