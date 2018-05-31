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
        protected static Random rand = new Random();

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

        private Label l1, l2, l3;

        protected List<PictureBox> pictureBoxes;
        protected List<Card> cards;
        protected Dictionary<PictureBox, Card> cardsDictionary;
        protected HashSet<PictureBox> validCards;
        protected Tuple<string, PictureBox> previousCard;

        protected List<Tuple<PictureBox, PictureBox>> canBePairedCards;
        protected List<PictureBox> openedCards;

        private bool secondCard;
        private int scoreMultiplier;


        // Sega za sega mora PairGame klasata da se spravuva so labelite za poeni i currentPlayer
        public PairGame(Player player1,Player player2, List<PictureBox> pictureBoxes
            ,Label l1,Label l2,Label l3) : base(player1)
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

            this.l1 = l1;
            this.l2 = l2;
            this.l3 = l3;
        }

        public void updateLabels()
        {
            l1.Text = currentPlayer.Name;
            l2.Text = Player1.Score.Points + "";
            l3.Text = Player2.Score.Points + "";
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
            updateLabels();
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
                    
                    openedCards.Remove(pb);
                    openedCards.Remove(previousCard.Item2);

                    for (int i = 0; i < canBePairedCards.Count; i++)
                    {
                        if (canBePairedCards[i].Item1 == pb && canBePairedCards[i].Item2 == previousCard.Item2)
                        {
                            canBePairedCards.RemoveAt(i);
                            break;
                        }
                        else if (canBePairedCards[i].Item1 == previousCard.Item2 && canBePairedCards[i].Item2 == pb)
                        {
                            canBePairedCards.RemoveAt(i);
                            break;
                        }
                    }

                    updateLabels();

                    if (validCards.Count == 0) // every card is guessed
                    {
                        endGame();
                    }

                    previousCard = new Tuple<string, PictureBox>(string.Empty, null); // set previous to null
                    secondCard = false;

                    /*StringBuilder sb = new StringBuilder();
                    sb.Append("Second card \ncanBeOpened: ");
                    foreach (var elem in canBePairedCards)
                    {
                        sb.Append(elem.Item1.Name + "-" + elem.Item2.Name + " ");
                    }
                    sb.Append("\nOppenedCards: ");

                    foreach (var c in openedCards)
                    {
                        sb.Append(c.Name + " ");
                    }
                    MessageBox.Show(sb.ToString());*/

                    return true;

                }
                else // 2 different cards
                {
                    animateClosingCard(pb);
                    animateClosingCard(previousCard.Item2);

                    scoreMultiplier = 1;

                    for (int i = 0; i < openedCards.Count; i++)
                    {
                        if (getCard(openedCards[i]).Equals(getCard(pb)) && openedCards[i] != pb)
                        {
                            Tuple<PictureBox, PictureBox> tuple = new Tuple<PictureBox, PictureBox>(openedCards[i], pb);
                            if (!(canBePairedCards.Contains(tuple)
                                ||
                                canBePairedCards.Contains(new Tuple<PictureBox, PictureBox>(pb, openedCards[i]))))
                            {
                                canBePairedCards.Add(tuple);
                                break;
                            }

                        }
                    }

                    if (!openedCards.Contains(pb))
                    {
                        openedCards.Add(pb);
                    }

                    updateLabels();

                    previousCard = new Tuple<string, PictureBox>(string.Empty, null); // set previous to null
                    secondCard = false;

                    /*StringBuilder sb = new StringBuilder();
                    sb.Append("Second card \ncanBeOpened: ");
                    foreach (var elem in canBePairedCards)
                    {
                        sb.Append(elem.Item1.Name + "-" + elem.Item2.Name + " ");
                    }
                    sb.Append("\nOppenedCards: ");

                    foreach (var c in openedCards)
                    {
                        sb.Append(c.Name + " ");
                    }
                    MessageBox.Show(sb.ToString());*/

                    if (!currentPlayer.isBot())
                    {
                        changeTurn();
                    }

                    return false;
                }
                /*foreach (var pBox in validCards)
                {
                    pBox.Enabled = true;
                }*/
                
            }
            else
            {

                updateLabels();

                for (int i = 0; i < openedCards.Count; i++)
                {
                    if ( getCard(openedCards[i]).Equals(getCard(pb)) && openedCards[i] != pb)
                    {
                        Tuple<PictureBox, PictureBox> tuple = new Tuple<PictureBox, PictureBox>(openedCards[i], pb);
                        if (!(canBePairedCards.Contains(tuple)
                            ||
                            canBePairedCards.Contains(new Tuple<PictureBox, PictureBox>(pb, openedCards[i]))))
                        {
                            canBePairedCards.Add(tuple);
                            break;
                        }
                        
                    }
                }

                if (!openedCards.Contains(pb))
                {
                    openedCards.Add(pb);
                }

                updateLabels();


                secondCard = true;
                previousCard = new Tuple<string, PictureBox>(card.Shape, pb);

                /*StringBuilder sb = new StringBuilder();
                sb.Append("First card \ncanBeOpened: ");
                foreach (var elem in canBePairedCards)
                {
                    sb.Append(elem.Item1.Name + "-" + elem.Item2.Name + " ");
                }
                sb.Append("\nOppenedCards: ");

                foreach (var c in openedCards)
                {
                    sb.Append(c.Name + " ");
                }
                MessageBox.Show(sb.ToString());*/

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


        private void playBotMoves()
        {
            // Bot makes moves until he misses
            updateLabels();

            Tuple<PictureBox, PictureBox> move = currentPlayer.ChoseMove(canBePairedCards, openedCards, validCards, cardsDictionary, rand);
            validateCard(move.Item1);

            while (validateCard(move.Item2))
            {
                updateLabels();
                if (validCards.Count == 0)
                {
                    break;
                }
                move = currentPlayer.ChoseMove(canBePairedCards, openedCards, validCards, cardsDictionary, rand);
                validateCard(move.Item1);
            }

            changeTurn();
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
            updateLabels();

            if (currentPlayer.isBot())
            {
                playBotMoves();   
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
