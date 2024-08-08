
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
            this.user_balance = new System.Windows.Forms.TextBox();
            this.userData = new System.Windows.Forms.TextBox();
            this.walletlabel2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BackBTN = new System.Windows.Forms.Button();
            this.westPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // westPanel
            // 
            this.westPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(200)))), ((int)(((byte)(221)))));
            this.westPanel.Controls.Add(this.user_balance);
            this.westPanel.Controls.Add(this.userData);
            this.westPanel.Controls.Add(this.walletlabel2);
            this.westPanel.Controls.Add(this.label1);
            this.westPanel.Controls.Add(this.BackBTN);
            this.westPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.westPanel.Location = new System.Drawing.Point(0, 0);
            this.westPanel.Name = "westPanel";
            this.westPanel.Size = new System.Drawing.Size(210, 787);
            this.westPanel.TabIndex = 0;
            // 
            // user_balance
            // 
            this.user_balance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(129)))), ((int)(((byte)(167)))));
            this.user_balance.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold);
            this.user_balance.ForeColor = System.Drawing.Color.White;
            this.user_balance.Location = new System.Drawing.Point(21, 215);
            this.user_balance.Name = "user_balance";
            this.user_balance.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.user_balance.Size = new System.Drawing.Size(175, 26);
            this.user_balance.TabIndex = 9;
            this.user_balance.Text = "wallet";
            this.user_balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // userData
            // 
            this.userData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(129)))), ((int)(((byte)(167)))));
            this.userData.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold);
            this.userData.ForeColor = System.Drawing.Color.White;
            this.userData.Location = new System.Drawing.Point(21, 174);
            this.userData.Name = "userData";
            this.userData.Size = new System.Drawing.Size(175, 26);
            this.userData.TabIndex = 8;
            this.userData.Text = "userData";
            this.userData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Gill Sans MT", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gift Shop";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BackBTN
            // 
            this.BackBTN.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BackBTN.FlatAppearance.BorderSize = 0;
            this.BackBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BackBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.BackBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBTN.Font = new System.Drawing.Font("Gill Sans MT", 24F, System.Drawing.FontStyle.Bold);
            this.BackBTN.ForeColor = System.Drawing.Color.White;
            this.BackBTN.Location = new System.Drawing.Point(47, 712);
            this.BackBTN.Name = "BackBTN";
            this.BackBTN.Size = new System.Drawing.Size(101, 45);
            this.BackBTN.TabIndex = 6;
            this.BackBTN.Text = "Back";
            this.BackBTN.UseVisualStyleBackColor = true;
            this.BackBTN.Click += new System.EventHandler(this.BackBTN_Click);
            // 
            // StoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1092, 787);
            this.Controls.Add(this.westPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "StoreForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gift Shop";
            this.westPanel.ResumeLayout(false);
            this.westPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel westPanel;
        private Label label1;
        private Button BackBTN;
        private Label walletlabel2;
        private TextBox userData;
        private TextBox user_balance;
    }


}
