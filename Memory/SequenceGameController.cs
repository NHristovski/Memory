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
        public GameModes gameMode { get; set; }
        private static readonly int numberOfLevels = 2;

        protected int CurrentRound { get; set; }
        protected int NumberOfDockingStations { get; set; }
        public int StartNumberOfDockingStations { get; set; }
        public int EndNumberOfDockingStations { get; set; }
        public int FirstLevelTimeReducerInSeconds { get; set; } // First level is first round of pair of rounds ->
        public int SecondLevelTimeReducerInSeconds { get; set; } // -> (with same number of docking stations)
        protected int RemainingRoundTimeInSeconds { get; set; }
        public int FirstLevelDivisor { get; set; }
        public int SecondLevelDivisor { get; set; }
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
            shapes = new string[] { "trinity_knot", "pi", "spade", "heart", "X", "tree", "arrow", "diamond", "mars", "I",
                "IRed", "V", "moon", "star", "floppy", "triangle",
                "venera", "yin_yang", "delta"};

            // "trinity_knot", "pi", "yin_yang", "delta", "tree", "floppy"
            sequencerManager = new SequencerManager(parent, this);
            ParentForm = parent;
            RoundTimer = new Timer();
            CurrentRound = 1;
        }

        public void InitializeGame() // Call only once
        {
            NumberOfDockingStations = StartNumberOfDockingStations;
            RoundTimer.Interval = 1000;
            InitializeRound();
            pictureBoxManager.GeneratePictureBoxes(shapes);
            pictureBoxManager.DisplayPictureBoxes();
            sequencerManager.CreateSequencerPictureBox(pictureBoxManager.getPictureBoxVerticalLocation(), dockingStationManager.getDockingStationVerticalLocation());
            RoundTimer.Tick += new EventHandler(roundTimer_Tick);
        }

        protected void InitializeRound()
        {
            if (CurrentRound % 2 == 0) // Second level
            {
                RemainingRoundTimeInSeconds = (NumberOfDockingStations * 10) / SecondLevelDivisor - SecondLevelTimeReducerInSeconds;
                CurrentSequencerTime = SequencerTimeInMilliseconds - 500;
            }
            else // First level
            {
                RemainingRoundTimeInSeconds = (NumberOfDockingStations * 10) / FirstLevelDivisor - FirstLevelTimeReducerInSeconds;
                CurrentSequencerTime = SequencerTimeInMilliseconds;
            }

            //sequencerManager.sequencingTimer.Interval = CurrentSequencerTime > 0 ? CurrentSequencerTime : 1;
            dockingStationManager.GenerateStations(NumberOfDockingStations);
            ParentForm.Invalidate();
            sequencerManager.setCardSequence(GenerateRandomCardSequence());
            sequencerManager.SequencerTime = CurrentSequencerTime > 0 ? CurrentSequencerTime : 1;
            //RoundTimer.Interval = RemainingRoundTimeInSeconds * 1000;
            MessageBox.Show("Round: " + CurrentRound.ToString() + " - " + gameMode.ToString()
                          + "\nDockers: " + NumberOfDockingStations
                          + "\nRound time: " + RemainingRoundTimeInSeconds + "s"
                          + "\nSequencer time: " + CurrentSequencerTime + "ms");
        }

        private void roundTimer_Tick(object sender, EventArgs e)
        {
            RemainingRoundTimeInSeconds--;
            int minutes = RemainingRoundTimeInSeconds / 60;
            int seconds = RemainingRoundTimeInSeconds - minutes * 60;

            ParentForm.setRoundTimeLabel(String.Format("{0:00}:{1:00}", minutes, seconds));

            if(RemainingRoundTimeInSeconds == 0)
            {
                RoundTimer.Stop();
                enddGame();
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
                        EndOfRound();
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
            if (CurrentRound != 1)
                InitializeRound();

            pictureBoxManager.forbidPictureBoxInteraction();
            sequencerManager.startCardSequence();
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

        protected void EndOfRound()
        {
            // Give player points
            // Increase multiplier
            // RoundTimer.Stop();
            RoundTimer.Stop();
            MessageBox.Show("End of round");

            if (CurrentRound % 2 == 0) // If second level finished
            {
                NumberOfDockingStations++;
            }

            if (CurrentRound == (EndNumberOfDockingStations - StartNumberOfDockingStations + 1 ) * 2)
            {
                enddGame();
            }

            CurrentRound++;
            pictureBoxManager.resetPictureBoxes();
        }

        public void resetGame() // Will be changed !!
        {
            pictureBoxManager.resetPictureBoxes();
            dockingStationManager.resetDockingStations();
            dockingStationManager.GenerateStations(NumberOfDockingStations);
            sequencerManager.setCardSequence(GenerateRandomCardSequence());
        }

        // One method for finishedGame
        // One method for end of game due to elapsed round time

        public void enddGame() // Will be changed !!
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

        public override DialogResult endGame()
        {
            throw new NotImplementedException();
        }
    }
}
