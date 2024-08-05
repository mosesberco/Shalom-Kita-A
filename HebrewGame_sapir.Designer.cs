using System;


namespace final_project
{
    partial class HebrewGame_sapir
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.letterPic = new System.Windows.Forms.PictureBox();
            this.answer1 = new System.Windows.Forms.Button();
            this.answer2 = new System.Windows.Forms.Button();
            this.answer3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.buttonRandomize = new MaterialSkin.Controls.MaterialButton();
            this.startOver = new MaterialSkin.Controls.MaterialButton();
            this.option1 = new MaterialSkin.Controls.MaterialLabel();
            this.option2 = new MaterialSkin.Controls.MaterialLabel();
            this.option3 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.letterPic)).BeginInit();
            this.SuspendLayout();
            // 
            // letterPic
            // 
            this.letterPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.letterPic.Location = new System.Drawing.Point(474, 162);
            this.letterPic.Margin = new System.Windows.Forms.Padding(1);
            this.letterPic.Name = "letterPic";
            this.letterPic.Size = new System.Drawing.Size(113, 108);
            this.letterPic.TabIndex = 3;
            this.letterPic.TabStop = false;
            this.letterPic.Tag = "4";
            // 
            // answer1
            // 
            this.answer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.answer1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.answer1.Location = new System.Drawing.Point(153, 378);
            this.answer1.Margin = new System.Windows.Forms.Padding(1);
            this.answer1.Name = "answer1";
            this.answer1.Size = new System.Drawing.Size(126, 127);
            this.answer1.TabIndex = 5;
            this.answer1.Tag = "1";
            this.answer1.UseVisualStyleBackColor = true;
            this.answer1.Click += new System.EventHandler(this.CheckAnswerEventer);
            // 
            // answer2
            // 
            this.answer2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.answer2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.answer2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.answer2.FlatAppearance.BorderSize = 20;
            this.answer2.Location = new System.Drawing.Point(371, 378);
            this.answer2.Margin = new System.Windows.Forms.Padding(1);
            this.answer2.Name = "answer2";
            this.answer2.Size = new System.Drawing.Size(126, 128);
            this.answer2.TabIndex = 6;
            this.answer2.Tag = "2";
            this.answer2.UseVisualStyleBackColor = false;
            this.answer2.Click += new System.EventHandler(this.CheckAnswerEventer);
            // 
            // answer3
            // 
            this.answer3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.answer3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.answer3.FlatAppearance.BorderSize = 20;
            this.answer3.Location = new System.Drawing.Point(613, 379);
            this.answer3.Margin = new System.Windows.Forms.Padding(1);
            this.answer3.Name = "answer3";
            this.answer3.Size = new System.Drawing.Size(126, 127);
            this.answer3.TabIndex = 7;
            this.answer3.Tag = "3";
            this.answer3.UseVisualStyleBackColor = true;
            this.answer3.Click += new System.EventHandler(this.CheckAnswerEventer);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(356, 267);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(4, 3);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // materialLabel1
            // 
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(12, 65);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(267, 83);
            this.materialLabel1.TabIndex = 14;
            this.materialLabel1.Text = "ברוכים הבאים למשחק אות פותחת\r\n עליכם לבחור את התמונה הנכונה אשר מתחילה באות המופי" +
    "עה\r\nכל תשובה נכונה תזכה אותכם ב2$ בארנק הדיגיטלי\r\n";
            this.materialLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonRandomize
            // 
            this.buttonRandomize.AutoSize = false;
            this.buttonRandomize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRandomize.Depth = 0;
            this.buttonRandomize.DrawShadows = true;
            this.buttonRandomize.HighEmphasis = true;
            this.buttonRandomize.Icon = null;
            this.buttonRandomize.Location = new System.Drawing.Point(234, 170);
            this.buttonRandomize.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonRandomize.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonRandomize.Name = "buttonRandomize";
            this.buttonRandomize.Size = new System.Drawing.Size(171, 47);
            this.buttonRandomize.TabIndex = 15;
            this.buttonRandomize.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonRandomize.UseAccentColor = false;
            this.buttonRandomize.UseVisualStyleBackColor = true;
            this.buttonRandomize.Click += new System.EventHandler(this.startGame);
            // 
            // startOver
            // 
            this.startOver.AutoSize = false;
            this.startOver.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.startOver.Depth = 0;
            this.startOver.DrawShadows = true;
            this.startOver.HighEmphasis = true;
            this.startOver.Icon = null;
            this.startOver.Location = new System.Drawing.Point(234, 223);
            this.startOver.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.startOver.MouseState = MaterialSkin.MouseState.HOVER;
            this.startOver.Name = "startOver";
            this.startOver.Size = new System.Drawing.Size(145, 47);
            this.startOver.TabIndex = 16;
            this.startOver.Text = "שחק שוב";
            this.startOver.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.startOver.UseAccentColor = false;
            this.startOver.UseVisualStyleBackColor = true;
            this.startOver.Click += new System.EventHandler(this.StartOverTheGame);
            // 
            // option1
            // 
            this.option1.Depth = 0;
            this.option1.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.option1.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            this.option1.Location = new System.Drawing.Point(143, 320);
            this.option1.MouseState = MaterialSkin.MouseState.HOVER;
            this.option1.Name = "option1";
            this.option1.Size = new System.Drawing.Size(54, 57);
            this.option1.TabIndex = 17;
            this.option1.Text = ".א";
            // 
            // option2
            // 
            this.option2.Depth = 0;
            this.option2.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.option2.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            this.option2.Location = new System.Drawing.Point(361, 320);
            this.option2.MouseState = MaterialSkin.MouseState.HOVER;
            this.option2.Name = "option2";
            this.option2.Size = new System.Drawing.Size(54, 57);
            this.option2.TabIndex = 18;
            this.option2.Text = ".ב";
            // 
            // option3
            // 
            this.option3.Depth = 0;
            this.option3.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.option3.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            this.option3.Location = new System.Drawing.Point(626, 320);
            this.option3.MouseState = MaterialSkin.MouseState.HOVER;
            this.option3.Name = "option3";
            this.option3.Size = new System.Drawing.Size(54, 57);
            this.option3.TabIndex = 19;
            this.option3.Text = ".ג";
            // 
            // HebrewGame_sapir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(826, 611);
            this.Controls.Add(this.option3);
            this.Controls.Add(this.option2);
            this.Controls.Add(this.option1);
            this.Controls.Add(this.startOver);
            this.Controls.Add(this.buttonRandomize);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.answer3);
            this.Controls.Add(this.answer2);
            this.Controls.Add(this.answer1);
            this.Controls.Add(this.letterPic);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "HebrewGame_sapir";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "אות פותחת";
            ((System.ComponentModel.ISupportInitialize)(this.letterPic)).EndInit();
            this.ResumeLayout(false);

        }

        private void guidelines_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.PictureBox letterPic;
        private System.Windows.Forms.Button answer1;
        private System.Windows.Forms.Button answer2;
        private System.Windows.Forms.Button answer3;
        private System.Windows.Forms.Button button1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton buttonRandomize;
        private MaterialSkin.Controls.MaterialButton startOver;
        private MaterialSkin.Controls.MaterialLabel option1;
        private MaterialSkin.Controls.MaterialLabel option2;
        private MaterialSkin.Controls.MaterialLabel option3;
    }
}