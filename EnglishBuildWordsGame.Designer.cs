
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
            this.TitleGame = new System.Windows.Forms.TextBox();
            this.TitleWord = new System.Windows.Forms.Label();
            this.CheckIfWordInGroup = new System.Windows.Forms.Button();
            this.TxtFD1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // TitleGame
            // 
            this.TitleGame.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.TitleGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleGame.Cursor = System.Windows.Forms.Cursors.PanSouth;
            this.TitleGame.Font = new System.Drawing.Font("Calibri", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleGame.Location = new System.Drawing.Point(348, 85);
            this.TitleGame.Name = "TitleGame";
            this.TitleGame.Size = new System.Drawing.Size(287, 36);
            this.TitleGame.TabIndex = 0;
            this.TitleGame.Text = "Try to built as many words you can!";
            this.TitleGame.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TitleGame.TextChanged += new System.EventHandler(this.TitleGame_TextChanged);
            // 
            // TitleWord
            // 
            this.TitleWord.AutoSize = true;
            this.TitleWord.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleWord.Location = new System.Drawing.Point(394, 272);
            this.TitleWord.Name = "TitleWord";
            this.TitleWord.Size = new System.Drawing.Size(225, 37);
            this.TitleWord.TabIndex = 2;
            this.TitleWord.Text = "Write The Word!";
            this.TitleWord.Click += new System.EventHandler(this.TitleWord_Click);
            // 
            // CheckIfWordInGroup
            // 
            this.CheckIfWordInGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CheckIfWordInGroup.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckIfWordInGroup.Location = new System.Drawing.Point(348, 317);
            this.CheckIfWordInGroup.Name = "CheckIfWordInGroup";
            this.CheckIfWordInGroup.Size = new System.Drawing.Size(109, 23);
            this.CheckIfWordInGroup.TabIndex = 3;
            this.CheckIfWordInGroup.Text = "Check Word";
            this.CheckIfWordInGroup.UseMnemonic = false;
            this.CheckIfWordInGroup.UseVisualStyleBackColor = true;
            this.CheckIfWordInGroup.Click += new System.EventHandler(this.CheckIfWordInGroup_Click);
            // 
            // TxtFD1
            // 
            this.TxtFD1.Location = new System.Drawing.Point(496, 317);
            this.TxtFD1.Name = "TxtFD1";
            this.TxtFD1.Size = new System.Drawing.Size(109, 21);
            this.TxtFD1.TabIndex = 4;
            this.TxtFD1.Text = "";
            this.TxtFD1.TextChanged += new System.EventHandler(this.TxtFD1_TextChanged);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 450);
            this.Controls.Add(this.TxtFD1);
            this.Controls.Add(this.CheckIfWordInGroup);
            this.Controls.Add(this.TitleWord);
            this.Controls.Add(this.TitleGame);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TitleGame;
        private System.Windows.Forms.Label TitleWord;
        private System.Windows.Forms.Button CheckIfWordInGroup;
        private System.Windows.Forms.RichTextBox TxtFD1;
    }
}