using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Reference
/// https://github.com/ahmetyasirkilic/FlatButton/blob/master/CustomButton/FlatButton.cs
/// </summary>

namespace Memory
{
    class FlatButton : Control
    {
        private SolidBrush borderBrush, textBrush;
        private Rectangle borderRectangle;
        private bool active = false;
        private StringFormat stringFormat = new StringFormat();

        public override Cursor Cursor { get; set; } = Cursors.Hand;
        public float BorderThickness { get; set; } = 2;
        public Color PressColor { get; set; }


        public FlatButton()
        {
            borderBrush = new SolidBrush(Color.White);// ColorTranslator.FromHtml("#31302b"));
            textBrush = new SolidBrush(Color.White); // ColorTranslator.FromHtml("#FFF"));

            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            PressColor = Color.FromArgb(146, 175, 78);

            this.Paint += FlatButton_Paint;
        }

        private void FlatButton_Paint(object sender, PaintEventArgs e)
        {
            borderRectangle = new Rectangle(0, 0, Width, Height);
            //e.Graphics.DrawRectangle(new Pen(borderBrush, BorderThickness), borderRectangle);
            e.Graphics.DrawString(this.Text, this.Font, (active) ? textBrush : borderBrush, borderRectangle, stringFormat);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            base.BackColor = PressColor; // ColorTranslator.FromHtml("#31302b");
            active = true;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            base.BackColor = Color.FromArgb(161, 192, 87);
            active = false;
        }
    }
}
