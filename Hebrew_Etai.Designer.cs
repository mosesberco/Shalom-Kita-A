namespace final_project
{

    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    public class CustomPanel : Panel
    {
        public CustomPanel()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var brush = new SolidBrush(Color.FromArgb(200, Color.White)))
            using (var pen = new Pen(Color.LightGray, 1))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                var rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                var path = GetRoundedRectangle(rect, 20); // 20 is the radius of the rounded corners

                e.Graphics.FillPath(brush, path);
                e.Graphics.DrawPath(pen, path);
            }
        }

        private GraphicsPath GetRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
    partial class Hebrew_Etai
    {
        private System.ComponentModel.IContainer components = null;
        private CustomPanel gamePanel;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.lblTimeLeft = new MaterialSkin.Controls.MaterialLabel();
            this.lblStatus = new MaterialSkin.Controls.MaterialLabel();
            this.btnRestart = new MaterialSkin.Controls.MaterialButton();
            this.gamePanel = new final_project.CustomPanel();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 1000;
            this.GameTimer.Tick += new System.EventHandler(this.TimerEvent);
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.Depth = 0;
            this.lblTimeLeft.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTimeLeft.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            this.lblTimeLeft.Location = new System.Drawing.Point(563, 597);
            this.lblTimeLeft.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(194, 60);
            this.lblTimeLeft.TabIndex = 3;
            this.lblTimeLeft.Text = "זמן נשאר";
            // 
            // lblStatus
            // 
            this.lblStatus.Depth = 0;
            this.lblStatus.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblStatus.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            this.lblStatus.Location = new System.Drawing.Point(65, 597);
            this.lblStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(194, 60);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "התאמה";
            // 
            // btnRestart
            // 
            this.btnRestart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRestart.Depth = 0;
            this.btnRestart.DrawShadows = true;
            this.btnRestart.HighEmphasis = true;
            this.btnRestart.Icon = null;
            this.btnRestart.Location = new System.Drawing.Point(371, 620);
            this.btnRestart.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRestart.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(99, 36);
            this.btnRestart.TabIndex = 5;
            this.btnRestart.Text = "התחל מחדש";
            this.btnRestart.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRestart.UseAccentColor = false;
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.RestartGameEvent);
            // 
            // gamePanel
            // 
            this.gamePanel.BackColor = System.Drawing.Color.Transparent;
            this.gamePanel.Location = new System.Drawing.Point(50, 50);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(926, 680);
            this.gamePanel.TabIndex = 0;
            // 
            // Hebrew_Etai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(806, 705);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTimeLeft);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Hebrew_Etai";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "משחק זיכרון";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        { }
        private System.Windows.Forms.Timer GameTimer;
        private MaterialSkin.Controls.MaterialLabel lblTimeLeft;
        private MaterialSkin.Controls.MaterialLabel lblStatus;
        private MaterialSkin.Controls.MaterialButton btnRestart;
    }
}
