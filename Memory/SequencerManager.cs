using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public class SequencerManager
    {
        private static readonly float widthPercent = 14f;
        private static readonly float heightPercent = 24.9f;
        //private static readonly int width = 120;
        //private static readonly int height = 150;

        // Responsive sequencer
        public int width { get { return (int)Math.Ceiling((Parent.Width / 100.0) * widthPercent); } }

        public int height { get { return (int)Math.Ceiling((Parent.Height / 100.0) * heightPercent); } }

        private int topY;
        private int bottomY;
        public int SequencerTime { get; set; }
        public Timer sequencingTimer { get; set; }

        public PictureBox SequencingPictureBox { get; set; }
        public List<Card> CurrentSequence { get; set; }
        public List<Card> NotShownSequence { get; set; }
        public Card CurrentCard { get; set; }
        public Form Parent { get; set; }
        public SequenceGameController Controller { get; set; }

        public SequencerManager(Form parent, SequenceGameController controller)
        {
            CurrentSequence = new List<Card>();
            NotShownSequence = new List<Card>();
            sequencingTimer = new Timer();
            Parent = parent;
            Controller = controller;
            
            sequencingTimer.Tick += new EventHandler(sequencingTimer_Tick);
        }

        public void CreateSequencerPictureBox(int availableTopCoordinate, int availableBottomCoordinate)
        {
            topY = availableTopCoordinate;
            bottomY = availableBottomCoordinate;

            int locationX = Parent.Width / 2 - width / 2;
            int locationY = topY + ((bottomY - topY) / 2 - height / 2);

            PictureBox pb = new PictureBox()
            {
                Height = height,
                Width = width,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new System.Drawing.Point(locationX, locationY),
                Image = Paths.closedCard,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            Parent.Controls.Add(pb);
            SequencingPictureBox = pb;
        }

        public void setCardSequence(List<Card> cards)
        {
            CurrentSequence = cards;
            NotShownSequence = new List<Card>(cards);
        }

        public void startCardSequence()
        {
            sequencingTimer.Interval = SequencerTime;

            // Shouldnt happen.
            if (CurrentSequence == null || CurrentSequence.Count == 0)
                throw new Exception("Current sequence not set !!");

            if (NotShownSequence.Count == 0)
            {
                Controller.HandleSequencerTermination();
                return;
            }

            CurrentCard = NotShownSequence[0];
            NotShownSequence.RemoveAt(0);

            animateOpeningCard(CurrentCard);
            makeCardStill(CurrentCard);
            sequencingTimer.Start();
        }

        private void sequencingTimer_Tick(object sender, EventArgs e)
        {
            sequencingTimer.Stop();
            animateClosingCard(CurrentCard);
            closeCard();
            startCardSequence();
        }

        // ANIMATIONS - Niksi

        public void animateOpeningCard(Card card)
        {
            GifImage gifImage = new GifImage(card.OpenCard);
            for (int i = 0; i < gifImage.frameCount; i++)
            {
                SequencingPictureBox.Enabled = true;
                SequencingPictureBox.Image = gifImage.GetNextFrame();
                SequencingPictureBox.Enabled = false;
            }
        }

        public void closeCard()
        {
            SequencingPictureBox.Image = Paths.closedCard;
            SequencingPictureBox.Enabled = true;
        }

        public void makeCardStill(Card card)
        {
            SequencingPictureBox.Enabled = true;
            SequencingPictureBox.Image = card.StillCard;
            SequencingPictureBox.Enabled = false;

        }

        public void animateClosingCard(Card card)
        {
            GifImage gifImage = new GifImage(card.CloseCard);
            for (int i = 0; i < gifImage.frameCount; i++)
            {
                SequencingPictureBox.Enabled = true;
                SequencingPictureBox.Image = gifImage.GetNextFrame();
                SequencingPictureBox.Enabled = false;
            }
            closeCard();
        }

        public bool sequenceIsValid(List<Card> cards)
        {
            if (CurrentSequence.Count != cards.Count)
                return false;

            for (int i = 0; i < CurrentSequence.Count; i++)
            {
                if (!CurrentSequence[i].Equals(cards[i]))
                    return false;
            }

            return true;
        }

        public Point getSequencerMiddlePoint()
        {
            return new Point(SequencingPictureBox.Location.X, SequencingPictureBox.Location.Y + height / 2); 
        }

        public void disposeSequencer()
        {
            SequencingPictureBox.Dispose();
            SequencingPictureBox = null;
        }
    }
}
