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
        // Variables for Game Modes: Easy, Normal, Hard
        private static readonly int numberOfLevels = 2;

        protected int CurrentRound { get; set; }
        public int NumberOfDockingStations { get; set; }
        public int MaxNumberOfDockingStations { get; set; }
        public int FirstLevelTimeReducerInSeconds { get; set; } // First level is first round of pair of rounds ->
        public int SecondLevelTimeReducerInSeconds { get; set; } // -> (with same number of docking stations)
        protected int RemainingRoundTimeInSeconds { get; set; }
        public int SequencerTimeInMilliseconds { get; set; } // Shouldnt be changed (Repeats every second level)
        protected int CurrentSequencerTime { get; set; } // How many milliseconds will the Sequencer be opened
        //

        protected DockingStationManager dockingStationManager { get; set; }
        protected PictureBoxManager pictureBoxManager { get; set; }
        protected SequencerManager sequencerManager { get; set; }
        protected Dictionary<PictureBox, DockingStation> DockingRelations { get; set; } // Check while refactoring
        protected SequenceGameForm ParentForm { get; set; }
        protected Timer RoundTimer { get; set; }

        protected string[] shapes;

        public SequenceGameController(Player player, SequenceGameForm parent) : base(player)
        {
            dockingStationManager = new DockingStationManager(this, parent.Width, parent.Height);
            pictureBoxManager = new PictureBoxManager(this, parent);
            DockingRelations = new Dictionary<PictureBox, DockingStation>();
            shapes = new string[] { "spade", "heart", "I", "IRed", "V", "X" };
            sequencerManager = new SequencerManager(parent, this);
            ParentForm = parent;
            RoundTimer = new Timer();
        }

        public void InitializeGame() // Call only once
        {
            InitializeRound();
            pictureBoxManager.GeneratePictureBoxes(shapes);
            pictureBoxManager.DisplayPictureBoxes();
            sequencerManager.CreateSequencerPictureBox(pictureBoxManager.getPictureBoxVerticalLocation(), dockingStationManager.getDockingStationVerticalLocation());
            RoundTimer.Tick += new EventHandler(roundTimer_Tick);
            RoundTimer.Interval = 1000; // 1 second
        }

        private void roundTimer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
        }

        protected override void startGame()
        {
            throw new NotImplementedException();
        }

        protected void InitializeRound()
        {
            dockingStationManager.GenerateStations(NumberOfDockingStations);
            sequencerManager.setCardSequence(GenerateRandomCardSequence());
            sequencerManager.SequencerTime = CurrentSequencerTime;
        }

        protected void EndOfRound()
        { 
            // Give player points
            // Increase multiplier

            if(CurrentRound % 2 == 0) // Second level
            {
                NumberOfDockingStations++;
                RemainingRoundTimeInSeconds = (NumberOfDockingStations * 10) / 2 - SecondLevelTimeReducerInSeconds;
                CurrentSequencerTime = SequencerTimeInMilliseconds - 500;
            }
            else // First level
            {
                RemainingRoundTimeInSeconds = (NumberOfDockingStations * 10) / 2 - FirstLevelTimeReducerInSeconds;
                CurrentSequencerTime = SequencerTimeInMilliseconds;
            }

            CurrentRound++;
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

            ParentForm.Invalidate();
        }
    }
}
