
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
            this.westPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.user_balance = new System.Windows.Forms.TextBox();
            this.userData = new System.Windows.Forms.TextBox();
            this.walletlabel2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BackBTN = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.westPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // westPanel
            // 
            this.westPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(200)))), ((int)(((byte)(221)))));
            this.westPanel.Controls.Add(this.pictureBox1);
            this.westPanel.Controls.Add(this.user_balance);
            this.westPanel.Controls.Add(this.userData);
            this.westPanel.Controls.Add(this.walletlabel2);
            this.westPanel.Controls.Add(this.label1);
            this.westPanel.Controls.Add(this.BackBTN);
            this.westPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.westPanel.Location = new System.Drawing.Point(0, 0);
            this.westPanel.Name = "westPanel";
            this.westPanel.Size = new System.Drawing.Size(300, 763);
            this.westPanel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::final_project.Properties.Resources.cartwithgiftswhite;
            this.pictureBox1.Location = new System.Drawing.Point(0, 232);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 421);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // user_balance
            // 
            this.user_balance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(129)))), ((int)(((byte)(167)))));
            this.user_balance.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_balance.ForeColor = System.Drawing.Color.White;
            this.user_balance.Location = new System.Drawing.Point(58, 174);
            this.user_balance.Name = "user_balance";
            this.user_balance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.user_balance.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.user_balance.Size = new System.Drawing.Size(175, 26);
            this.user_balance.TabIndex = 9;
            this.user_balance.Text = "wallet";
            this.user_balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // userData
            // 
            this.userData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(129)))), ((int)(((byte)(167)))));
            this.userData.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userData.ForeColor = System.Drawing.Color.White;
            this.userData.Location = new System.Drawing.Point(58, 119);
            this.userData.Name = "userData";
            this.userData.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.userData.Size = new System.Drawing.Size(175, 26);
            this.userData.TabIndex = 8;
            this.userData.Text = "userData";
            this.userData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // walletlabel2
            // 
            this.walletlabel2.AutoSize = true;
            this.walletlabel2.Font = new System.Drawing.Font("Gill Sans MT", 18F);
            this.walletlabel2.ForeColor = System.Drawing.Color.White;
            this.walletlabel2.Location = new System.Drawing.Point(159, 66);
            this.walletlabel2.Margin = new System.Windows.Forms.Padding(3);
            this.walletlabel2.Name = "walletlabel2";
            this.walletlabel2.Size = new System.Drawing.Size(0, 34);
            this.walletlabel2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Gill Sans MT", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(8, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 67);
            this.label1.TabIndex = 0;
            this.label1.Text = "חנות מתנות";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BackBTN
            // 
            this.BackBTN.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BackBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BackBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.BackBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBTN.Font = new System.Drawing.Font("Gill Sans MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackBTN.ForeColor = System.Drawing.Color.White;
            this.BackBTN.Location = new System.Drawing.Point(67, 697);
            this.BackBTN.Name = "BackBTN";
            this.BackBTN.Size = new System.Drawing.Size(153, 45);
            this.BackBTN.TabIndex = 6;
            this.BackBTN.Text = "חזרה לתפריט";
            this.BackBTN.UseVisualStyleBackColor = true;
            this.BackBTN.Click += new System.EventHandler(this.BackBTN_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(300, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(920, 763);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // StoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1222, 763);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.westPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StoreForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gift Shop";
            this.westPanel.ResumeLayout(false);
            this.westPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel westPanel;
        private Label label1;
        private Button BackBTN;
        private Label walletlabel2;
        private TextBox userData;
        private TextBox user_balance;
        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanel1;
    }


}
