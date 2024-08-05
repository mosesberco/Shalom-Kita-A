
namespace final_project
{
    partial class EnglishBuildWordsGame
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
            this.TitleGame = new MaterialSkin.Controls.MaterialTextBox();
            this.TitleWord = new MaterialSkin.Controls.MaterialLabel();
            this.CheckIfWordInGroup = new MaterialSkin.Controls.MaterialButton();
            this.TxtFD1 = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.SuspendLayout();
            // 
            // TitleGame
            // 
            this.TitleGame.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TitleGame.Depth = 0;
            this.TitleGame.Font = new System.Drawing.Font("Roboto", 12F);
            this.TitleGame.Location = new System.Drawing.Point(249, 83);
            this.TitleGame.MaxLength = 50;
            this.TitleGame.MouseState = MaterialSkin.MouseState.OUT;
            this.TitleGame.Multiline = false;
            this.TitleGame.Name = "TitleGame";
            this.TitleGame.Size = new System.Drawing.Size(310, 50);
            this.TitleGame.TabIndex = 5;
            this.TitleGame.Text = "Try to built as many words you can!";
            this.TitleGame.TextChanged += new System.EventHandler(this.TitleGame_TextChanged);
            // 
            // TitleWord
            // 
            this.TitleWord.AutoSize = true;
            this.TitleWord.Depth = 0;
            this.TitleWord.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.TitleWord.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            this.TitleWord.Location = new System.Drawing.Point(255, 220);
            this.TitleWord.MouseState = MaterialSkin.MouseState.HOVER;
            this.TitleWord.Name = "TitleWord";
            this.TitleWord.Size = new System.Drawing.Size(342, 58);
            this.TitleWord.TabIndex = 6;
            this.TitleWord.Text = "Write The Word!";
            // 
            // CheckIfWordInGroup
            // 
            this.CheckIfWordInGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CheckIfWordInGroup.Depth = 0;
            this.CheckIfWordInGroup.DrawShadows = true;
            this.CheckIfWordInGroup.HighEmphasis = true;
            this.CheckIfWordInGroup.Icon = null;
            this.CheckIfWordInGroup.Location = new System.Drawing.Point(281, 325);
            this.CheckIfWordInGroup.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CheckIfWordInGroup.MouseState = MaterialSkin.MouseState.HOVER;
            this.CheckIfWordInGroup.Name = "CheckIfWordInGroup";
            this.CheckIfWordInGroup.Size = new System.Drawing.Size(115, 36);
            this.CheckIfWordInGroup.TabIndex = 7;
            this.CheckIfWordInGroup.Text = "Check Word";
            this.CheckIfWordInGroup.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.CheckIfWordInGroup.UseAccentColor = false;
            this.CheckIfWordInGroup.UseVisualStyleBackColor = true;
            this.CheckIfWordInGroup.Click += new System.EventHandler(this.CheckIfWordInGroup_Click);
            // 
            // TxtFD1
            // 
            this.TxtFD1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TxtFD1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtFD1.Depth = 0;
            this.TxtFD1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TxtFD1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TxtFD1.Hint = "";
            this.TxtFD1.Location = new System.Drawing.Point(433, 315);
            this.TxtFD1.MouseState = MaterialSkin.MouseState.HOVER;
            this.TxtFD1.Name = "TxtFD1";
            this.TxtFD1.Size = new System.Drawing.Size(210, 46);
            this.TxtFD1.TabIndex = 8;
            this.TxtFD1.Text = "";
            this.TxtFD1.TextChanged += new System.EventHandler(this.TxtFD1_TextChanged);
            // 
            // EnglishBuildWordsGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 573);
            this.Controls.Add(this.TxtFD1);
            this.Controls.Add(this.CheckIfWordInGroup);
            this.Controls.Add(this.TitleWord);
            this.Controls.Add(this.TitleGame);
            this.Name = "EnglishBuildWordsGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialTextBox TitleGame;
        private MaterialSkin.Controls.MaterialLabel TitleWord;
        private MaterialSkin.Controls.MaterialButton CheckIfWordInGroup;
        private MaterialSkin.Controls.MaterialMultiLineTextBox TxtFD1;
    }
}