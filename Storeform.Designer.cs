
using System.Drawing;
using System.Windows.Forms;

namespace final_project
{
    partial class StoreForm
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
            panel1 = new Panel();
            walletlabel2 = new Label();
            label1 = new Label();
            walletLabel1 = new Label();
            pictureBox2 = new PictureBox();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 129, 167);
            panel1.Controls.Add(walletlabel2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(walletLabel1);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(276, 561);
            panel1.TabIndex = 0;
            // 
            // walletlabel2
            // 
            walletlabel2.AutoSize = true;
            walletlabel2.Font = new Font("Gill Sans MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            walletlabel2.ForeColor = Color.White;
            walletlabel2.Location = new Point(186, 76);
            walletlabel2.Margin = new Padding(3);
            walletlabel2.Name = "walletlabel2";
            walletlabel2.Size = new Size(0, 34);
            walletlabel2.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Gill Sans MT", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(11, 1);
            label1.Name = "label1";
            label1.Size = new Size(241, 67);
            label1.TabIndex = 0;
            label1.Text = "Gift Shop";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // walletLabel1
            // 
            walletLabel1.AutoSize = true;
            walletLabel1.FlatStyle = FlatStyle.Flat;
            walletLabel1.Font = new Font("Gill Sans MT", 24F, FontStyle.Bold, GraphicsUnit.Point);
            walletLabel1.ForeColor = Color.White;
            walletLabel1.Location = new Point(57, 68);
            walletLabel1.Name = "walletLabel1";
            walletLabel1.Size = new Size(123, 45);
            walletLabel1.TabIndex = 1;
            walletLabel1.Text = "Wallet";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImageLayout = ImageLayout.None;
            pictureBox2.ErrorImage = null;
            //pictureBox2.Image = Properties.Resources.Walletwhite;
            pictureBox2.InitialImage = null;
            pictureBox2.Location = new Point(11, 68);
            pictureBox2.Margin = new Padding(0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(37, 41);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.White;
            button1.FlatAppearance.MouseOverBackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Gill Sans MT", 24F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(62, 506);
            button1.Name = "button1";
            button1.Size = new Size(118, 52);
            button1.TabIndex = 6;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.ErrorImage = null;
            //pictureBox1.Image = Properties.Resources.cartwithgiftswhite;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(11, 124);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(243, 401);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // StoreForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = Color.FromArgb(253, 252, 220);
            ClientSize = new Size(889, 561);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "StoreForm";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Store";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label1;
        private Label walletLabel1;
        private PictureBox pictureBox2;
        private Button button1;
        private Label walletlabel2;
    }


}
