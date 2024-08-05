
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.StartingGameButton = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(50, 199);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(716, 207);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            this.materialLabel1.Location = new System.Drawing.Point(142, 110);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(472, 58);
            this.materialLabel1.TabIndex = 5;
            this.materialLabel1.Text = "Welcome to the Game";
            // 
            // StartingGameButton
            // 
            this.StartingGameButton.AutoSize = false;
            this.StartingGameButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StartingGameButton.Depth = 0;
            this.StartingGameButton.DrawShadows = true;
            this.StartingGameButton.HighEmphasis = true;
            this.StartingGameButton.Icon = null;
            this.StartingGameButton.Location = new System.Drawing.Point(296, 454);
            this.StartingGameButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.StartingGameButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.StartingGameButton.Name = "StartingGameButton";
            this.StartingGameButton.Size = new System.Drawing.Size(195, 66);
            this.StartingGameButton.TabIndex = 6;
            this.StartingGameButton.Text = "Start Game";
            this.StartingGameButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.StartingGameButton.UseAccentColor = false;
            this.StartingGameButton.UseVisualStyleBackColor = true;
            this.StartingGameButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // EnglishBuildWordsGameMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(833, 678);
            this.Controls.Add(this.StartingGameButton);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.richTextBox1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Name = "EnglishBuildWordsGameMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create the Words";
            this.Load += new System.EventHandler(this.EnglishBuildWordsGameMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton StartingGameButton;
    }
}