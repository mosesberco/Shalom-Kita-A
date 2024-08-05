
namespace final_project
{
    partial class ChangePassword
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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.newPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.confirmPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.button1 = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.materialLabel1.Location = new System.Drawing.Point(13, 108);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(143, 19);
            this.materialLabel1.TabIndex = 11;
            this.materialLabel1.Text = "Enter new password";
            // 
            // newPassword
            // 
            this.newPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.newPassword.Depth = 0;
            this.newPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.newPassword.Location = new System.Drawing.Point(183, 77);
            this.newPassword.MaxLength = 50;
            this.newPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.newPassword.Multiline = false;
            this.newPassword.Name = "newPassword";
            this.newPassword.Size = new System.Drawing.Size(147, 50);
            this.newPassword.TabIndex = 12;
            this.newPassword.Text = "";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.materialLabel2.Location = new System.Drawing.Point(13, 161);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(164, 19);
            this.materialLabel2.TabIndex = 13;
            this.materialLabel2.Text = "Confirm new password";
            // 
            // confirmPassword
            // 
            this.confirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.confirmPassword.Depth = 0;
            this.confirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.confirmPassword.Location = new System.Drawing.Point(183, 130);
            this.confirmPassword.MaxLength = 50;
            this.confirmPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.confirmPassword.Multiline = false;
            this.confirmPassword.Name = "confirmPassword";
            this.confirmPassword.Size = new System.Drawing.Size(147, 50);
            this.confirmPassword.TabIndex = 14;
            this.confirmPassword.Text = "";
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Depth = 0;
            this.button1.DrawShadows = true;
            this.button1.HighEmphasis = true;
            this.button1.Icon = null;
            this.button1.Location = new System.Drawing.Point(153, 207);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button1.MouseState = MaterialSkin.MouseState.HOVER;
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 36);
            this.button1.TabIndex = 15;
            this.button1.Text = "Save";
            this.button1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button1.UseAccentColor = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 260);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.confirmPassword);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.newPassword);
            this.Controls.Add(this.materialLabel1);
            this.Name = "ChangePassword";
            this.Text = "Change password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox newPassword;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox confirmPassword;
        private MaterialSkin.Controls.MaterialButton button1;
    }
}