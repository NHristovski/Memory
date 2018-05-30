using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Memory
{
    public abstract class Game
    {
        private static Random rand = new Random();

        public Player Player1 { get; set; }

        public Game(Player player)
        {
            Player1 = player;
          
        }

        public abstract void startGame();
        public abstract void endGame();

    }

    public class PairGame : Game
    {
        
        protected string[] shapes;

        public Player Player2 { get; set; }
        public Player currentPlayer {get;set;}

        protected List<PictureBox> pictureBoxes;
        protected List<Card> cards;
        protected Dictionary<PictureBox, Card> cardsDictionary;
        protected HashSet<PictureBox> validCards;
        protected Tuple<string, PictureBox> previousCard;

        protected List<Tuple<PictureBox, PictureBox>> canBePairedCards;
        protected List<PictureBox> openedCards;

        private bool secondCard;
        private int scoreMultiplier;

        public PairGame(Player player1,Player player2, List<PictureBox> pictureBoxes) : base(player1)
        {
            Player2 = player2;
            shapes = new string[] { "spade", "heart" }; // not complete
            secondCard = false;
            currentPlayer = Player1;
            scoreMultiplier = 1;

            cardsDictionary = new Dictionary<PictureBox, Card>();

            canBePairedCards = new List<Tuple<PictureBox, PictureBox>>();
            openedCards = new List<PictureBox>();
            this.pictureBoxes = pictureBoxes;
            cards = new List<Card>();
            this.validCards = new HashSet<PictureBox>(pictureBoxes);
        }

        private void animateOpeningCard(PictureBox pb)
        {
            Card card = getCard(pb);
            if (!card.Guessed)
            {
                GifImage gifImage = new GifImage(card.pathToOpenCard);
                for (int i = 0; i < gifImage.frameCount; i++)
                {
                    pb.Enabled = true;
                    pb.Image = gifImage.GetNextFrame();
                    pb.Enabled = false;
                }
            }
        }
        private void animateClosingCard(PictureBox pb)
        {
            GifImage gifImage = new GifImage(getCard(pb).pathToCloseCard);
            for (int i = 0; i < gifImage.frameCount; i++)
            {
                pb.Enabled = true;
                pb.Image = gifImage.GetNextFrame();
                pb.Enabled = false;
            }
            closeCard(pb);
        }

        public bool validateCard(PictureBox pb)
        {
            Card card = getCard(pb);
            animateOpeningCard(pb);
            if (secondCard)
            {
                /*foreach (var pBox in validCards)
                {
                    pBox.Enabled = false;
                }*/
                if (card.Shape.Equals(previousCard.Item1)) // 2 same cards 
                {
                    currentPlayer.Score.Points += (scoreMultiplier * 100);
                    scoreMultiplier++;

                    makeCardStill(pb);
                    makeCardStill(previousCard.Item2);

                    validCards.Remove(pb);
                    validCards.Remove(previousCard.Item2);

                    if (validCards.Count == 0) // every card is guessed
                    {
                        endGame();
                    }

                    previousCard = new Tuple<string, PictureBox>(string.Empty, null); // set previous to null
                    secondCard = false;
                    return true;

                }
                else // 2 different cards
                {
                    animateClosingCard(pb);
                    animateClosingCard(previousCard.Item2);

                    scoreMultiplier = 1;

                    changeTurn();

                    previousCard = new Tuple<string, PictureBox>(string.Empty, null); // set previous to null
                    secondCard = false;

                    return false;
                }
                /*foreach (var pBox in validCards)
                {
                    pBox.Enabled = true;
                }*/
                
            }
            else
            {
                //openedCards.Add(pb);

                for (int i = 0; i < openedCards.Count; i++)
                {
                    if ( getCard(openedCards[i]).Equals(getCard(pb)) && openedCards[i] != pb)
                    {
                        Tuple<PictureBox, PictureBox> tuple = new Tuple<PictureBox, PictureBox>(openedCards[i], pb);
                        if (!(canBePairedCards.Contains(tuple) || canBePairedCards.Contains(new Tuple<PictureBox, PictureBox>(pb, openedCards[i]))))
                        {
                            canBePairedCards.Add(tuple);
                        }
                        
                    }
                }
                secondCard = true;
                previousCard = new Tuple<string, PictureBox>(card.Shape, pb);

                return true;
            }

            
        }

        private void closeCard(PictureBox pb)
        {
            //pb.ImageLocation = pathToClosedCard;
            pb.Image = Properties.Resources.closedCard;
            pb.Enabled = true; ;
        }
        private void makeCardStill(PictureBox pb)
        {
            pb.Enabled = true;
            pb.ImageLocation = getCard(pb).pathToStillCard;
            pb.Enabled = false;
        }

        public void changeTurn()
        {
            if (currentPlayer == Player2)
            {
                currentPlayer = Player1;
            }
            else
            {
                currentPlayer = Player2;
            }

            if (currentPlayer.isBot())
            {
               // Tuple<PictureBox,PictureBox> move = currentPlayer.ChoseMove()
               // while
            }
            
        }

        public Card getCard(PictureBox pb)
        {
            return cardsDictionary[pb];
        }

        private StringBuilder getShapesFolder(string shape)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(System.IO.Directory.GetCurrentDirectory())
                .Append(@"\shapes\")
                .Append(shape)
                .Append(@"\")
                .Append(shape);
            return stringBuilder;
        }
        protected string getPathOpen(string shape)
        {
            StringBuilder stringBuilder = this.getShapesFolder(shape);
            stringBuilder.Append("_open.gif");
            return stringBuilder.ToString();
        }
        protected string getPathClose(string shape)
        {
            StringBuilder stringBuilder = this.getShapesFolder(shape);
            stringBuilder.Append("_close.gif");
            return stringBuilder.ToString();
        }
        protected string getPathStill(string shape)
        {
            StringBuilder stringBuilder = this.getShapesFolder(shape);
            stringBuilder.Append("_still.jpg");
            return stringBuilder.ToString();
        }

        public override void startGame()
        {
            Random rand = new Random();
            HashSet<int> picked = new HashSet<int>();
            for (int i = 0; i < pictureBoxes.Count / 2; i++)
            {
                int index = rand.Next(shapes.Length); // chose one shape
                //if (picked.Contains(index)) // see if it is already chosen
                //{
                  //  i--;
                //}
                //else
               // {
                    picked.Add(index);
                    string shape = shapes[index];
                    string shapeOpen = this.getPathOpen(shape);
                    string shapeClose = this.getPathClose(shape);
                    string shapeStill = this.getPathStill(shape);
                    Card card = new Card(shape, shapeOpen, shapeClose, shapeStill);
                    cards.Add(card);
                    cards.Add(card);
              //  }

            }
            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                int index = rand.Next(cards.Count);
                cardsDictionary.Add(pictureBoxes[i], cards[index]);
                cards.RemoveAt(index);
            }
        }


        public override void endGame()
        {
            // **** what should this method do:
            // -WHO WON
            // -WRITE POINTS in file
            // -DO YOU WANNA PLAY AGAIN?
            MessageBox.Show("END GAME");
        }
    }
    

    public class SequenceGame : Game
    {
        public SequenceGame(Player player) : base(player)
        {

        }
        public override void startGame()
        {
            throw new Exception("Start Game is not implemented");
        }
        public override void endGame()
        {
            throw new Exception("End Game is not implemented");
        }
    }

  
}
