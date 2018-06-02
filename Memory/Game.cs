using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

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

    public class PairGame : Game, IObservable
    {
        private STATES State;

        protected string[] shapes;

        public Player Player2 { get; set; }
        public Player currentPlayer {get;set;}

        protected List<PictureBox> pictureBoxes;
        protected List<Card> cards;
        protected Dictionary<PictureBox, Card> cardsDictionary;
        public HashSet<PictureBox> validCards;
        public Tuple<string, PictureBox> previousCard;

        protected List<Tuple<PictureBox, PictureBox>> canBePairedCards;
        public List<PictureBox> openedCards;

        public bool secondCard;
        public int scoreMultiplier;

        public bool ShouldHandle { get; set; }


        public readonly int x2Price;
        public readonly int secondChancePrice;
        public readonly int openCardsPrice;
        public readonly int findNextPrice;

        IGameObserver Observer;

        // CONSTRUCTOR
        public PairGame(Player player1,Player player2, List<PictureBox> pictureBoxes, int x2Price, int secondChancePrice, int findNextPrice, int openCardsPrice) : base(player1)
        {
            State = STATES.NORMAL_STATE;

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

            ShouldHandle = true;

            this.x2Price = x2Price;
            this.secondChancePrice = secondChancePrice;
            this.openCardsPrice = openCardsPrice;
            this.findNextPrice = findNextPrice;

            this.Observer = new GameObserver();
            ((GameObserver)Observer).Game = this;
        }

        //Implementig interface IObervable
        public STATES GetState()
        {
            return State;
        }
        public void ReturnToNormalState()
        {
            this.State = STATES.NORMAL_STATE;
        }
        private void makeStateSecondChance()
        {
            this.State = STATES.SECON_CHANCE_STATE;
        }

        // ANIMATIONS
        public void animateOpeningCard(PictureBox pb)
        {
            if (secondCard && !currentPlayer.isBot())
            {
                ShouldHandle = false;
            }

            Card card = getCard(pb);
            //MessageBox.Show(card.pathToOpenCard);
            if (!card.Guessed)
            {
                GifImage gifImage = new GifImage(card.OpenCard);
                for (int i = 0; i < gifImage.frameCount; i++)
                {
                    pb.Enabled = true;
                    pb.Image = gifImage.GetNextFrame();
                    pb.Enabled = false;
                }
            }
        }

        public void closeCard(PictureBox pb)
        {
            pb.Image = Paths.closedCard;
            pb.Enabled = true; 
        }

        public void makeCardStill(PictureBox pb)
        {
            pb.Enabled = true;
            pb.Image = getCard(pb).StillCard;
            pb.Enabled = false;

        }

        public void animateClosingCard(PictureBox pb)
        {
            GifImage gifImage = new GifImage(getCard(pb).CloseCard);
            for (int i = 0; i < gifImage.frameCount; i++)
            {
                pb.Enabled = true;
                pb.Image = gifImage.GetNextFrame();
                pb.Enabled = false;
            }
            closeCard(pb);

            ShouldHandle = true;
        }


        // HELPER FUNCTIONS FOR VALIDATING CARD
        public void removeFromCanBePaired(PictureBox pb)
        {
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
        }

        public void addToCanBePaired(PictureBox pb)
        {
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
        }


        // MAIN FUNCTION OF THE CLASS
        public bool validateCard(PictureBox pb)
        {
            return Observer.validateCard(pb);
        }

        public bool shouldEnd()
        {
            return this.validCards.Count == 0;
        }

        // BOT MOVES

        public Tuple<PictureBox, PictureBox> botMove()
        {
            return currentPlayer.ChoseMove(canBePairedCards, openedCards, validCards, cardsDictionary, rand);
        }

        public void playBotMove()
        {
            // Bot makes moves until he misses
            ShouldHandle = false; // disable clicking on pictureboxes while bot makes moves

            Tuple<PictureBox, PictureBox> move = botMove();
            Observer.validateCard(move.Item1);

            while (Observer.validateCard(move.Item2))
            {
                if (this.shouldEnd())
                {
                    this.endGame();
                }

                move = botMove();
                Observer.validateCard(move.Item1);              
            }

            ShouldHandle = true; // enable clicking on pictureBoxes
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

            if (currentPlayer.isBot())
            {
                playBotMove();
            }
            
        }

        public Card getCard(PictureBox pb)
        {
            return cardsDictionary[pb];
        }

        // RETURNS OPEN,CLOSE,STILL CARD IMAGES
        public Tuple<Image,Image,Image> getImages(string shape)
        {
            return new Tuple<Image, Image, Image>(Image.FromFile(Paths.pathToResources + shape + "_open.gif"),
                                                  Image.FromFile(Paths.pathToResources + shape + "_close.gif"),
                                                  Image.FromFile(Paths.pathToResources + shape + "_still.jpg"));
            
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

                    Tuple<Image, Image, Image> images = this.getImages(shape);

                    Card card = new Card(shape, images.Item1, images.Item2, images.Item3);
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

            /*StringBuilder sb = new StringBuilder();

            foreach (var elem in cardsDictionary)
            {
                sb.Append(elem.Key.Name).Append("-").Append(elem.Value.Shape).Append("\n");
            } 
            MessageBox.Show(sb.ToString());*/
        }


        //HELPERS FUNCTIONS

        public string getx2Avaliable()
        {
            return ((PairGameHumanPlayer)currentPlayer).x2Avaliable + "";
        } 
        public string getSecondChanceAvaliable()
        {
            return ((PairGameHumanPlayer)currentPlayer).secondChanceAvaliable + "";
        }
        public string getFindNextAvaliable()
        {
            return ((PairGameHumanPlayer)currentPlayer).findNextAvaliable + "";
        }
        public string getOpenCardsAvaliable()
        {
            return ((PairGameHumanPlayer)currentPlayer).openCardsAvaliable + "";
        }

        public void DoubleMultiplier()
        {
            if (((PairGameHumanPlayer)currentPlayer).x2Avaliable < 1)
            {
                throw new HelperNotAvaliableException(); 
            }
            if (currentPlayer.Score.Points < x2Price)
            {
                throw new NotEnoughScoreException();
            }

            ((PairGameHumanPlayer)currentPlayer).Usex2(x2Price);
            this.scoreMultiplier *= 2;
        }

        public PictureBox FindNext(PictureBox pb)
        {
            if (!secondCard)
            {
                throw new CardNotOpenedException();
            }
            if (((PairGameHumanPlayer)currentPlayer).findNextAvaliable < 1)
            {
                throw new HelperNotAvaliableException();
            }
            if (currentPlayer.Score.Points < findNextPrice)
            {
                throw new NotEnoughScoreException();
            }

            foreach (var pbox in validCards)
            {
                if (getCard(pbox).Equals(getCard(pb)) && pbox != pb)
                {
                    ((PairGameHumanPlayer)currentPlayer).UseFindNext(findNextPrice);
                    return pbox;
                }
            }
            throw new Exception("CANNOT FIND THE CARD! CHECK FINDNEXT IN GAME.CS");
        }

       
        public void OpenCards()
        {
            if (((PairGameHumanPlayer)currentPlayer).openCardsAvaliable < 1)
            {
                throw new HelperNotAvaliableException();
            }
            if (currentPlayer.Score.Points < openCardsPrice)
            {
                throw new NotEnoughScoreException();
            }

            ((PairGameHumanPlayer)currentPlayer).UseOpenCards(openCardsPrice);
        }
        
        public void SecondChance()
        {
            if (!secondCard)
            {
                throw new CardNotOpenedException();
            }
            if (((PairGameHumanPlayer)currentPlayer).secondChanceAvaliable < 1)
            {
                throw new HelperNotAvaliableException();
            }
            if (currentPlayer.Score.Points < secondChancePrice)
            {
                throw new NotEnoughScoreException();
            }

            ((PairGameHumanPlayer)currentPlayer).UseSecondChance(secondChancePrice);
            makeStateSecondChance();
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
