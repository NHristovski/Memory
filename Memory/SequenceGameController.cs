using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public class SequenceGameController : Game
    {
        public DockingStationManager dockingStationManager { get; set; }
        public PictureBoxManager pictureBoxManager { get; set; }
        public Dictionary<PictureBox, DockingStation> DockingRelations { get; set; } // Chec while refactoring
        public int NumberOfDockingStations { get; set; }
        public Form Parent { get; set; }

        protected string[] shapes;

        public SequenceGameController(int numberOfDockingStations, Player player, Form parent) : base(player)
        {
            NumberOfDockingStations = numberOfDockingStations;
            dockingStationManager = new DockingStationManager(this, parent.Width, parent.Height);
            pictureBoxManager = new PictureBoxManager(this, parent);
            DockingRelations = new Dictionary<PictureBox, DockingStation>();
            shapes = new string[] { "spade", "heart", "I", "IRed", "V", "X" };
            Parent = parent;
        }

        public void InitializeGame()
        {
            dockingStationManager.GenerateStations(NumberOfDockingStations);
            pictureBoxManager.GeneratePictureBoxes(shapes);
            pictureBoxManager.DisplayPictureBoxes();
        }

        public void HandlePictureBoxRelease(PictureBox dockingPictureBox)
        {
            DockingStation dockingStation;
            if (DockingRelations.TryGetValue(dockingPictureBox, out dockingStation) && dockingStation != null)
            {
                dockingStation.Docked = false;
                DockingRelations.Remove(dockingPictureBox);
            }

            DockingStation stationToDockTo = dockingStationManager.FindPossibleDockerStation(dockingPictureBox);

            if (stationToDockTo != null)
            {
                pictureBoxManager.dockPictureBoxToStation(dockingPictureBox, stationToDockTo);
                stationToDockTo.Docked = true;
                stationToDockTo.DockedCard = pictureBoxManager.getPictureBoxCard(dockingPictureBox);
                DockingRelations.Add(dockingPictureBox, stationToDockTo);
            }
        }

        public void DrawDockingStations(Graphics g)
        {
            dockingStationManager.DrawDockingStations(g);
        }

        // Niksi
        public Tuple<Image, Image, Image> getImages(string shape)
        {
            System.Resources.ResourceManager rm = Properties.Resources.ResourceManager;
            return new Tuple<Image, Image, Image>(Image.FromFile(Paths.pathToResources + shape + "_open.gif"),
                                                  Image.FromFile(Paths.pathToResources + shape + "_close.gif"),
                                                  Image.FromFile(Paths.pathToResources + shape + "_still.jpg"));
        }

        protected override void startGame()
        {
            throw new NotImplementedException();
        }

        public override void endGame()
        {
            throw new NotImplementedException();
        }
    }
}
