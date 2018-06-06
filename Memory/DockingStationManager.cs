using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public class DockingStationManager
    {
        public static readonly int dockingStationsDistance = 15;
        public static readonly int bottomOffset = 180;
        public static readonly int dockingOffset = (DockingStation.width * DockingStation.height * 20) / 100;
        public int LeftOffset { get; set; }

        public List<DockingStation> Stations { get; set; }
        public int ParentWidth { get; set; }
        public int ParentHeight { get; set; }
        public SequenceGameController Controller { get; set; }


        public DockingStationManager(SequenceGameController controller, int width, int height)
        {
            Stations = new List<DockingStation>();
            ParentWidth = width;
            ParentHeight = height;
            Controller = controller;
        }

        public void GenerateStations(int n)
        {
            Stations.Clear();
            LeftOffset = (ParentWidth - n * (DockingStation.width + dockingStationsDistance)) / 2;
            int Offset = 0;
            for (int i = 0; i < n; i++)
            {
                DockingStation station = new DockingStation(LeftOffset + Offset, ParentHeight - bottomOffset, Color.DarkSeaGreen, (i + 1).ToString());
                Stations.Add(station);
                Offset += DockingStation.width + dockingStationsDistance;
            }
        }

        public void DrawDockingStations(Graphics g)
        {
            Stations.ForEach(s => s.DrawDockingStation(g));
        }

        public DockingStation FindPossibleDockerStation(PictureBox dockingPictureBox)
        {
            Rectangle rectangle = new Rectangle(dockingPictureBox.Location, dockingPictureBox.Size);

            List<int> intersectionAreas = Stations
                                          //.Where(s => s.Docked == false)
                                          .Select(r => Rectangle.Intersect(r.Station, rectangle))
                                          .Select(i => i.Width * i.Height)
                                          .ToList();
            int maxIntersectionArea = 0;
            int index = -1;

            for (int i = 0; i < 2; i++)
            {
                maxIntersectionArea = intersectionAreas.Max();
                index = intersectionAreas.IndexOf(maxIntersectionArea);
                DockingStation suitableDockingStation = Stations[index];

                if (maxIntersectionArea >= dockingOffset && !suitableDockingStation.Docked)
                {
                    return suitableDockingStation;
                }
                else
                    intersectionAreas[index] = 0;
            }

            return null;
        }

        public int getDockingStationVerticalLocation() // Returns upper Y value of DockingStation
        {
            return Stations.FirstOrDefault().Station.Location.Y;
        }
    }
}
