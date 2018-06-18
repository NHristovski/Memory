using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public class DockingStation
    {
        //public static readonly int width = 100; // 90
        //public static readonly int height = 120;

        public Color StationColor { get; set; }
        public Rectangle Station { get; set; }
        public Color ContentColor { get; set; }
        public string Content { get; set; }
        public Boolean Docked { get; set; }
        public Card DockedCard { get; set; }
        //public Card DockedCard { get; set; }

        public DockingStation(Rectangle rectangle, Color rectangleColor, string content, Color? contentColor = null)
        {
            Station = rectangle;
            StationColor = rectangleColor;
            Content = content;
            ContentColor = contentColor ?? Color.CornflowerBlue;
            Docked = false;
        }

        //public DockingStation(int x, int y, Color rectangleColor, string content, Color? contentColor = null)
        //    : this(new Rectangle(x, y, width, height), rectangleColor, content, contentColor) { }

        public void DrawDockingStation(Graphics g)
        {
            Pen pn = new Pen(StationColor, 2);
            g.DrawRectangle(pn, Station);
            Pen redPen = new Pen(Color.CornflowerBlue, 2);
            g.DrawRectangle(redPen, Station.Location.X - 2, Station.Location.Y - 2, Station.Width + 4, Station.Height + 4);

            using (Font font = new Font(FontFamily.GenericSansSerif, 10))
            {
                SolidBrush br = new SolidBrush(Color.FromArgb(150, Color.White)); // Color.White);
                g.FillRectangle(br, Station);
                SolidBrush brush = new SolidBrush(ContentColor);
                g.DrawString(Content, font, brush, Station.X + Station.Width / 2 - 5, Station.Y + Station.Height / 2 - 5);
                br.Dispose();
                brush.Dispose();
            }
            redPen.Dispose();
            pn.Dispose();
        }

        public void resetDockingStation()
        {
            Docked = false;
            DockedCard = null;
        }
    }
}