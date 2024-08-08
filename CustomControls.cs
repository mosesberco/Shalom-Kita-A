using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace final_project
{
    public class ModernButton : Button
    {
        public ModernButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.FromArgb(59, 130, 246);
            ForeColor = Color.White;
            Font = new Font("Arial", 12, FontStyle.Bold);
            Cursor = Cursors.Hand;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new Rectangle(0, 0, Width, Height));
            this.Region = new Region(path);
        }
    }

    public class ModernTextBox : TextBox
    {
        public ModernTextBox()
        {
            BorderStyle = BorderStyle.None;
            Font = new Font("Arial", 14);
            BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(59, 130, 246), 2),
                                     new Rectangle(0, 0, Width - 1, Height - 1));
        }
    }
}