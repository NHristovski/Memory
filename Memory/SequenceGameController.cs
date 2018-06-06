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
        public SequencerManager sequencerManager { get; set; }
        public Dictionary<PictureBox, DockingStation> DockingRelations { get; set; } // Chec while refactoring
        public int NumberOfDockingStations { get; set; }
        public SequenceGameForm Parent { get; set; }
        public Timer RoundTimer { get; set; }
        public int RemainingRoundTimeInMilliseconds { get; set; } = 10000;

        protected string[] shapes;

        public SequenceGameController(int numberOfDockingStations, Player player, SequenceGameForm parent) : base(player)
        {
            NumberOfDockingStations = numberOfDockingStations;
            dockingStationManager = new DockingStationManager(this, parent.Width, parent.Height);
            pictureBoxManager = new PictureBoxManager(this, parent);
            DockingRelations = new Dictionary<PictureBox, DockingStation>();
            shapes = new string[] { "spade", "heart", "I", "IRed", "V", "X" };
            sequencerManager = new SequencerManager(2000, 120, 150, parent, this);
            Parent = parent;
            RoundTimer = new Timer();
        }

        public void InitializeGame()
        {
            dockingStationManager.GenerateStations(NumberOfDockingStations);
            pictureBoxManager.GeneratePictureBoxes(shapes);
            pictureBoxManager.DisplayPictureBoxes();
            sequencerManager.setCardSequence(GenerateRandomCardSequence());
            sequencerManager.CreateSequencerPictureBox(pictureBoxManager.getPictureBoxVerticalLocation(), dockingStationManager.getDockingStationVerticalLocation());
            RoundTimer.Tick += new EventHandler(roundTimer_Tick);
            RoundTimer.Interval = 1000; // 1 second
        }

        private void roundTimer_Tick(object sender, EventArgs e)
        {
            RemainingRoundTimeInMilliseconds -= 1000;
            int minutes = RemainingRoundTimeInMilliseconds / 60000;
            int seconds = (RemainingRoundTimeInMilliseconds - minutes * 60000) / 1000;
            Parent.setRoundTimeLabel(String.Format("{0:00}:{1:00}", minutes, seconds));

            if (RemainingRoundTimeInMilliseconds <= 0)
            {
                RoundTimer.Stop();
                endGame();
            }
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

                if (dockingStationManager.dockingStationsFull())
                {
                    List<Card> cards = dockingStationManager.getDockedCards();
                    if (sequencerManager.sequenceIsValid(cards))
                    {
                        endGame();
                    }
                }
            }
        }

        // Niksi
        public Tuple<Image, Image, Image> getImages(string shape)
        {
            System.Resources.ResourceManager rm = Properties.Resources.ResourceManager;
            return new Tuple<Image, Image, Image>(Image.FromFile(Paths.pathToResources + shape + "_open.gif"),
                                                  Image.FromFile(Paths.pathToResources + shape + "_close.gif"),
                                                  Image.FromFile(Paths.pathToResources + shape + "_still.jpg"));
        }

        public void DrawDockingStations(Graphics g)
        {
            dockingStationManager.DrawDockingStations(g);
        }

        public List<Card> GenerateRandomCardSequence()
        {
            List<string> tempShapes = new List<string>(shapes);
            List<Card> randomCards = new List<Card>();

            for (int i = 0; i < dockingStationManager.Stations.Count; i++)
            {
                int index = rand.Next(tempShapes.Count); // Try catch for shape
                string shape = tempShapes[index];

                Tuple<Image, Image, Image> images = getImages(shape);

                randomCards.Add(new Card(tempShapes[index], images.Item1, images.Item2, images.Item3));
                tempShapes.RemoveAt(index);
            }

            return randomCards;
        }

        public void StartSequencer()
        {
            sequencerManager.startCardSequence();
            pictureBoxManager.forbidPictureBoxInteraction();
        }

        public void HandleSequencerTermination()
        {
            pictureBoxManager.allowPictureBoxInteraction();
            RoundTimer.Start();
        }

        protected override void startGame()
        {
            throw new NotImplementedException();
        }

        public void resetGame()
        {
            pictureBoxManager.resetPictureBoxes();
            dockingStationManager.resetDockingStations();
            dockingStationManager.GenerateStations(NumberOfDockingStations);
            sequencerManager.setCardSequence(GenerateRandomCardSequence());
        }

        public override void endGame()
        {
            if (NumberOfDockingStations < 5)
                NumberOfDockingStations++;
            DialogResult result = MessageBox.Show("WIN !!!\nDo you want to continue ?", "Game status", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                resetGame();
            //sequencerManager.CurrentSequence.Clear();
            //pictureBoxManager.resetPictureBoxes();

            // Decide what to do if he cancels (Exit ?  )

            Parent.Invalidate();
        }
    }
}
