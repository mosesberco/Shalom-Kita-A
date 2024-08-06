using System.Drawing;

namespace final_project
{
    partial class Login
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
            this.button1 = new System.Windows.Forms.Button();
            this.signupButton = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.showPasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.Label();
            this.txtusername = new System.Windows.Forms.Label();
            this.loginLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Info;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button1.Location = new System.Drawing.Point(22, 422);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 36);
            this.button1.TabIndex = 31;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // signupButton
            // 
            this.signupButton.AutoSize = true;
            this.signupButton.BackColor = System.Drawing.SystemColors.Info;
            this.signupButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.signupButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.signupButton.Location = new System.Drawing.Point(290, 438);
            this.signupButton.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.signupButton.Name = "signupButton";
            this.signupButton.Size = new System.Drawing.Size(66, 20);
            this.signupButton.TabIndex = 30;
            this.signupButton.Text = "Sign Up";
            this.signupButton.Click += new System.EventHandler(this.signupButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(227, 402);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "don\'t have an account ?";
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.SystemColors.Info;
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.loginButton.Location = new System.Drawing.Point(601, 422);
            this.loginButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(68, 36);
            this.loginButton.TabIndex = 28;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // showPasswordCheckBox
            // 
            this.showPasswordCheckBox.AutoSize = true;
            this.showPasswordCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showPasswordCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showPasswordCheckBox.Location = new System.Drawing.Point(415, 309);
            this.showPasswordCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.showPasswordCheckBox.Name = "showPasswordCheckBox";
            this.showPasswordCheckBox.Size = new System.Drawing.Size(96, 17);
            this.showPasswordCheckBox.TabIndex = 27;
            this.showPasswordCheckBox.Text = "show password";
            this.showPasswordCheckBox.UseVisualStyleBackColor = true;
            this.showPasswordCheckBox.CheckedChanged += new System.EventHandler(this.showPasswordCheckBox_CheckedChanged);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.passwordTextBox.Location = new System.Drawing.Point(221, 309);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(165, 26);
            this.passwordTextBox.TabIndex = 26;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.usernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.usernameTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.usernameTextBox.Location = new System.Drawing.Point(221, 264);
            this.usernameTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(165, 26);
            this.usernameTextBox.TabIndex = 25;
            // 
            // txtPass
            // 
            this.txtPass.AutoSize = true;
            this.txtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtPass.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtPass.Location = new System.Drawing.Point(101, 315);
            this.txtPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(90, 20);
            this.txtPass.TabIndex = 24;
            this.txtPass.Text = "password:";
            // 
            // txtusername
            // 
            this.txtusername.AutoSize = true;
            this.txtusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtusername.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtusername.Location = new System.Drawing.Point(101, 264);
            this.txtusername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(101, 20);
            this.txtusername.TabIndex = 23;
            this.txtusername.Text = "User name:";
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.loginLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.loginLabel.Location = new System.Drawing.Point(303, 41);
            this.loginLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(62, 24);
            this.loginLabel.TabIndex = 22;
            this.loginLabel.Text = "Login";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.BackgroundImage = global::final_project.Properties.Resources.shalom_kita_a;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(711, 492);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.signupButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.showPasswordCheckBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.loginLabel);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label signupButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.CheckBox showPasswordCheckBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label txtPass;
        private System.Windows.Forms.Label txtusername;
        private System.Windows.Forms.Label loginLabel;
    }
}