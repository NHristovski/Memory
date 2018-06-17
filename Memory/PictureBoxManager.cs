using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public class PictureBoxManager
    {
        //public static readonly int pictureBoxWidth = 100; // 90
        //public static readonly int pictureBoxHeight = 120;
        //public static readonly int pictureBoxOffset = 30;


        // Responsive pbs.
        private static readonly float widthPercent = 11.7f;
        private static readonly float heightPercent = 19.9f;
        private static readonly float offsetPercent = 30; // Relative to PbWidth
        public int pictureBoxWidth { get { return (int)Math.Ceiling((Parent.Width / 100.0) * widthPercent); } }

        public int pictureBoxHeight { get { return (int)Math.Ceiling((Parent.Height / 100.0) * heightPercent); } }

        public int pictureBoxOffset { get { return (int)Math.Ceiling((pictureBoxWidth / 100.0) * offsetPercent); } }
        //

        public int LeftOffset
        {
            get
            {
                return (Parent.Width - ((PictureBoxes.Count - 1) * pictureBoxOffset + pictureBoxWidth)) / 2;
            }
        }


        public Form Parent { get; set; }
        public List<PictureBox> PictureBoxes { get; set; }
        public PictureBox ActivePictureBox { get; set; } // PictureBox that is held at the moment (With mousedown)
        public Point HoldingPoint { get; set; } // Point where holding the ActivePictureBox started
        public Dictionary<PictureBox, Card> PictureBoxCardRelations { get; set; }
        public Dictionary<PictureBox, Point> PictureBoxInitialLocations { get; set; }
        public SequenceGameController Controller { get; set; }


        public PictureBoxManager(SequenceGameController controller, Form parent)
        {
            Parent = parent;
            PictureBoxes = new List<PictureBox>();
            PictureBoxCardRelations = new Dictionary<PictureBox, Card>();
            PictureBoxInitialLocations = new Dictionary<PictureBox, Point>();
            HoldingPoint = Point.Empty;
            Controller = controller;
        }

        public void GeneratePictureBoxes(string[] shapes)
        {
            for (int i = 0; i < shapes.Length; i++)
            {
                PictureBox pb = new PictureBox
                {
                    Width = pictureBoxWidth,
                    Height = pictureBoxHeight,
                    BorderStyle = BorderStyle.FixedSingle,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                //pb.SizeMode = PictureBoxSizeMode.StretchImage;
                //ResourceManager rm = Properties.Resources.ResourceManager;
                //Image image = (Image)rm.GetObject("_" + i);
                var image = Controller.getImages(shapes[i]).Item3;
                pb.Image = image;
                Card card = new Card(shapes[i], null, null, image);
                PictureBoxCardRelations.Add(pb, card);

                pb.MouseDown += new MouseEventHandler(pictureBox_MouseDown);
                pb.MouseMove += new MouseEventHandler(pictureBox_MouseMove);
                pb.MouseUp += new MouseEventHandler(pictureBox_MouseUp);
                pb.MouseDoubleClick += new MouseEventHandler(pictureBox_MouseDoubleClick);
                PictureBoxes.Add(pb);
            }
        }

        public void DisplayPictureBoxes()
        {
            foreach (PictureBox pb in PictureBoxes)
            {
                pb.Top = 50;
                pb.Left = LeftOffset + (PictureBoxes.IndexOf(pb) * pictureBoxOffset);
                PictureBoxInitialLocations.Add(pb, pb.Location);
                Parent.Controls.Add(pb);
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(String.Format("{0} x {1} - {2}", pictureBoxWidth, pictureBoxHeight, pictureBoxOffset));
            HoldingPoint = e.Location;
            ActivePictureBox = (PictureBox)sender;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (HoldingPoint != Point.Empty)
            {
                ActivePictureBox.Left += e.X - HoldingPoint.X;
                ActivePictureBox.Top += e.Y - HoldingPoint.Y;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            //List<Card> lista = Controller.dockingStationManager.getDockedCards();
            //StringBuilder sb = new StringBuilder();
            //lista.ForEach(c => sb.Append(c.Shape + "\n"));
            //MessageBox.Show(sb.ToString());

            if (ActivePictureBox != null)
            {
                // 1. Let Controller work with ActivePictureBox
                // 2. Controller communicates with DockingStationManager which will check wheter to and where to dock.
                // 3. Control will be given to Controller which will communicate back with PictureBoxManager to dock 
                //    the PictureBox. 
                Controller.HandlePictureBoxRelease(ActivePictureBox);
            }

            HoldingPoint = Point.Empty;
            ActivePictureBox = null;
        }

        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            resetPictureBox((PictureBox)sender);
        }

        public void resetPictureBox(PictureBox pictureBox)
        {
            Point initialLocation = getPictureBoxInitialLocation(pictureBox);
            if (initialLocation != null)
                pictureBox.Location = initialLocation;
        }

        public void dockPictureBoxToStation(PictureBox dockingPictureBox, DockingStation dockingStation)
        {
            dockingPictureBox.Location = dockingStation.Station.Location;
        }

        public int getPictureBoxVerticalLocation() // Returns lower Y value of picturebox
        {
            return PictureBoxes.FirstOrDefault().Location.Y + pictureBoxHeight;
        }

        public Card getPictureBoxCard(PictureBox pb)
        {
            return PictureBoxCardRelations[pb];
        }

        public Point getPictureBoxInitialLocation(PictureBox pb)
        {
            Point initialLocation;
            if (!PictureBoxInitialLocations.TryGetValue(pb, out initialLocation))
                return Point.Empty;

            return initialLocation;
        }

        public void resetPictureBoxes()
        {
            PictureBoxes.ForEach(pb => this.resetPictureBox(pb));
        }

        public void disposePictureBoxes()
        {
            PictureBoxes.ForEach(pb => pb.Dispose());
            PictureBoxes.Clear();
        }

        public void allowPictureBoxInteraction()
        {
            PictureBoxes.ForEach(pb => pb.Enabled = true);
        }

        public void forbidPictureBoxInteraction()
        {
            PictureBoxes.ForEach(pb => pb.Enabled = false);
        }

        public void bringPictureBoxesToFront()
        {
            for(int i = PictureBoxes.Count() - 1; i >= 0; i--)
            {
                PictureBoxes[i].BringToFront();
            }
        }
    }
}
