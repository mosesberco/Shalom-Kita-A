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
            this.guidelines = new System.Windows.Forms.Label();
            this.answer1 = new System.Windows.Forms.Button();
            this.answer2 = new System.Windows.Forms.Button();
            this.answer3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonRandomize = new System.Windows.Forms.Button();
            this.option3 = new System.Windows.Forms.Label();
            this.option2 = new System.Windows.Forms.Label();
            this.option1 = new System.Windows.Forms.Label();
            this.startOver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.letterPic)).BeginInit();
            this.SuspendLayout();
            // 
            // letterPic
            // 
            this.letterPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.letterPic.Location = new System.Drawing.Point(821, 173);
            this.letterPic.Name = "letterPic";
            this.letterPic.Size = new System.Drawing.Size(245, 267);
            this.letterPic.TabIndex = 3;
            this.letterPic.TabStop = false;
            this.letterPic.Tag = "4";
            // 
            // guidelines
            // 
            this.guidelines.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.guidelines.Font = new System.Drawing.Font("Showcard Gothic", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.guidelines.Location = new System.Drawing.Point(447, 34);
            this.guidelines.Name = "guidelines";
            this.guidelines.Size = new System.Drawing.Size(984, 94);
            this.guidelines.TabIndex = 4;
            this.guidelines.Text = "ברוכים הבאים למשחק אות פותחת! עליכם לבחור את התמונה הנכונה אשר מתחילה באות המופיע" +
    "ה";
            this.guidelines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.guidelines.Click += new System.EventHandler(this.guidelines_Click);
            // 
            // answer1
            // 
            this.answer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.answer1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.answer1.Location = new System.Drawing.Point(501, 534);
            this.answer1.Name = "answer1";
            this.answer1.Size = new System.Drawing.Size(274, 312);
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
            this.answer2.Location = new System.Drawing.Point(821, 531);
            this.answer2.Name = "answer2";
            this.answer2.Size = new System.Drawing.Size(274, 315);
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
            this.answer3.Location = new System.Drawing.Point(1157, 534);
            this.answer3.Name = "answer3";
            this.answer3.Size = new System.Drawing.Size(274, 313);
            this.answer3.TabIndex = 7;
            this.answer3.Tag = "3";
            this.answer3.UseVisualStyleBackColor = true;
            this.answer3.Click += new System.EventHandler(this.CheckAnswerEventer);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(659, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 8);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonRandomize
            // 
            //this.buttonRandomize.BackgroundImage = global::final_project.Properties.Resources.start;
            this.buttonRandomize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRandomize.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonRandomize.Location = new System.Drawing.Point(512, 173);
            this.buttonRandomize.Name = "buttonRandomize";
            this.buttonRandomize.Size = new System.Drawing.Size(212, 74);
            this.buttonRandomize.TabIndex = 9;
            this.buttonRandomize.UseVisualStyleBackColor = true;
            this.buttonRandomize.Click += new System.EventHandler(this.startGame);
            // 
            // option3
            // 
            this.option3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.option3.Location = new System.Drawing.Point(591, 458);
            this.option3.Name = "option3";
            this.option3.Size = new System.Drawing.Size(102, 64);
            this.option3.TabIndex = 10;
            this.option3.Text = ".ג";
            this.option3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // option2
            // 
            this.option2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.option2.Location = new System.Drawing.Point(901, 458);
            this.option2.Name = "option2";
            this.option2.Size = new System.Drawing.Size(97, 64);
            this.option2.TabIndex = 11;
            this.option2.Text = ".ב";
            this.option2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // option1
            // 
            this.option1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.option1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.option1.Location = new System.Drawing.Point(1242, 467);
            this.option1.Name = "option1";
            this.option1.Size = new System.Drawing.Size(92, 64);
            this.option1.TabIndex = 12;
            this.option1.Text = ".א";
            this.option1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startOver
            // 
            this.startOver.BackColor = System.Drawing.Color.Gold;
            this.startOver.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.startOver.Location = new System.Drawing.Point(465, 253);
            this.startOver.Name = "startOver";
            this.startOver.Size = new System.Drawing.Size(259, 80);
            this.startOver.TabIndex = 13;
            this.startOver.Text = "שחק שוב";
            this.startOver.UseVisualStyleBackColor = false;
            this.startOver.Click += new System.EventHandler(this.StartOverTheGame);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            //this.BackgroundImage = global::final_project.Properties.Resources.רקע;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1913, 1180);
            this.Controls.Add(this.startOver);
            this.Controls.Add(this.option1);
            this.Controls.Add(this.option2);
            this.Controls.Add(this.option3);
            this.Controls.Add(this.buttonRandomize);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.answer3);
            this.Controls.Add(this.answer2);
            this.Controls.Add(this.answer1);
            this.Controls.Add(this.guidelines);
            this.Controls.Add(this.letterPic);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.letterPic)).EndInit();
            this.ResumeLayout(false);

        }

        private void guidelines_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.PictureBox letterPic;
        private System.Windows.Forms.Label guidelines;
        private System.Windows.Forms.Button answer1;
        private System.Windows.Forms.Button answer2;
        private System.Windows.Forms.Button answer3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonRandomize;
        private System.Windows.Forms.Label option3;
        private System.Windows.Forms.Label option2;
        private System.Windows.Forms.Label option1;
        private System.Windows.Forms.Button startOver;
    }
}