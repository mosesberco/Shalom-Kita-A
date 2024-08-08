
namespace final_project
{
    partial class Register
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
            this.genderTextBox = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.showPasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.txtGen = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.Label();
            this.txtusername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // genderTextBox
            // 
            this.genderTextBox.BackColor = System.Drawing.Color.Lavender;
            this.genderTextBox.FormattingEnabled = true;
            this.genderTextBox.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.genderTextBox.Location = new System.Drawing.Point(276, 327);
            this.genderTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.genderTextBox.Name = "genderTextBox";
            this.genderTextBox.Size = new System.Drawing.Size(164, 21);
            this.genderTextBox.TabIndex = 33;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Lavender;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Gill Sans MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(11, 9);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 45);
            this.button3.TabIndex = 32;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(402, 432);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 23);
            this.label8.TabIndex = 31;
            this.label8.Text = "Login";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(220, 432);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 23);
            this.label7.TabIndex = 30;
            this.label7.Text = "Already have an account ?";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Gill Sans MT", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(287, 371);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 50);
            this.button1.TabIndex = 29;
            this.button1.Text = "Register";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // showPasswordCheckBox
            // 
            this.showPasswordCheckBox.AutoSize = true;
            this.showPasswordCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.showPasswordCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showPasswordCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showPasswordCheckBox.Font = new System.Drawing.Font("Gill Sans MT", 9.75F);
            this.showPasswordCheckBox.ForeColor = System.Drawing.Color.Black;
            this.showPasswordCheckBox.Location = new System.Drawing.Point(444, 194);
            this.showPasswordCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.showPasswordCheckBox.Name = "showPasswordCheckBox";
            this.showPasswordCheckBox.Size = new System.Drawing.Size(107, 22);
            this.showPasswordCheckBox.TabIndex = 28;
            this.showPasswordCheckBox.Text = "show password";
            this.showPasswordCheckBox.UseVisualStyleBackColor = false;
            this.showPasswordCheckBox.CheckedChanged += new System.EventHandler(this.showPasswordCheckBox_CheckedChanged);
            // 
            // txtGen
            // 
            this.txtGen.AutoSize = true;
            this.txtGen.BackColor = System.Drawing.Color.Transparent;
            this.txtGen.Font = new System.Drawing.Font("Gill Sans MT", 24F);
            this.txtGen.ForeColor = System.Drawing.Color.Black;
            this.txtGen.Location = new System.Drawing.Point(153, 310);
            this.txtGen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtGen.Name = "txtGen";
            this.txtGen.Size = new System.Drawing.Size(119, 45);
            this.txtGen.TabIndex = 27;
            this.txtGen.Text = "Gender";
            // 
            // txtEmail
            // 
            this.txtEmail.AutoSize = true;
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.Font = new System.Drawing.Font("Gill Sans MT", 24F);
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(179, 265);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(89, 45);
            this.txtEmail.TabIndex = 26;
            this.txtEmail.Text = "Email";
            // 
            // txtID
            // 
            this.txtID.AutoSize = true;
            this.txtID.BackColor = System.Drawing.Color.Transparent;
            this.txtID.Font = new System.Drawing.Font("Gill Sans MT", 24F);
            this.txtID.ForeColor = System.Drawing.Color.Black;
            this.txtID.Location = new System.Drawing.Point(216, 222);
            this.txtID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(52, 45);
            this.txtID.TabIndex = 25;
            this.txtID.Text = "ID";
            // 
            // emailTextBox
            // 
            this.emailTextBox.BackColor = System.Drawing.Color.Lavender;
            this.emailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.emailTextBox.Location = new System.Drawing.Point(276, 280);
            this.emailTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(164, 26);
            this.emailTextBox.TabIndex = 24;
            // 
            // idTextBox
            // 
            this.idTextBox.BackColor = System.Drawing.Color.Lavender;
            this.idTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.idTextBox.Location = new System.Drawing.Point(276, 237);
            this.idTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(164, 26);
            this.idTextBox.TabIndex = 23;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.Color.Lavender;
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.passwordTextBox.Location = new System.Drawing.Point(276, 194);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(164, 26);
            this.passwordTextBox.TabIndex = 22;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.BackColor = System.Drawing.Color.Lavender;
            this.usernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.usernameTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.usernameTextBox.Location = new System.Drawing.Point(276, 147);
            this.usernameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(164, 26);
            this.usernameTextBox.TabIndex = 21;
            // 
            // txtPass
            // 
            this.txtPass.AutoSize = true;
            this.txtPass.BackColor = System.Drawing.Color.Transparent;
            this.txtPass.Font = new System.Drawing.Font("Gill Sans MT", 24F);
            this.txtPass.ForeColor = System.Drawing.Color.Black;
            this.txtPass.Location = new System.Drawing.Point(128, 179);
            this.txtPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(144, 45);
            this.txtPass.TabIndex = 20;
            this.txtPass.Text = "Password";
            // 
            // txtusername
            // 
            this.txtusername.AutoSize = true;
            this.txtusername.BackColor = System.Drawing.Color.Transparent;
            this.txtusername.Font = new System.Drawing.Font("Gill Sans MT", 24F);
            this.txtusername.ForeColor = System.Drawing.Color.Black;
            this.txtusername.Location = new System.Drawing.Point(110, 132);
            this.txtusername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(162, 45);
            this.txtusername.TabIndex = 19;
            this.txtusername.Text = "User name";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Gill Sans MT", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(213, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 96);
            this.label1.TabIndex = 18;
            this.label1.Text = "Sign Up";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(644, 491);
            this.Controls.Add(this.genderTextBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.showPasswordCheckBox);
            this.Controls.Add(this.txtGen);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign Up";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox genderTextBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox showPasswordCheckBox;
        private System.Windows.Forms.Label txtGen;
        private System.Windows.Forms.Label txtEmail;
        private System.Windows.Forms.Label txtID;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label txtPass;
        private System.Windows.Forms.Label txtusername;
        private System.Windows.Forms.Label label1;
    }
}