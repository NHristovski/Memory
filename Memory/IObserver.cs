using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public enum STATES
    {
        NORMAL_STATE,
        SECON_CHANCE_STATE
    }
    public interface IGameObserver
    {
        bool validateCard(PictureBox pb);
    }

    public interface IObservable
    {
        STATES GetState();
        void ReturnToNormalState();
    }

    public class GameObserver : IGameObserver
    {
        private PairGame Game;
        public Player currentPlayer { get; set; }
        public static Random rand;

        public bool secondCard;
        public int scoreMultiplier;
        public bool ShouldHandle { get; set; }



        public HashSet<PictureBox> validCards;
        public Tuple<string, PictureBox> previousCard;
        private Dictionary<PictureBox, Card> cardsDictionary;
        protected List<Tuple<PictureBox, PictureBox>> canBePairedCards;
        public List<PictureBox> openedCards;


        public GameObserver(PairGame game,List<PictureBox> pictureBoxes,Dictionary<PictureBox,Card> dict,Random rand)
        {
            Game = game;
            currentPlayer = Game.Player1;

            secondCard = false;
            scoreMultiplier = 1;

            ShouldHandle = true;

            canBePairedCards = new List<Tuple<PictureBox, PictureBox>>();
            openedCards = new List<PictureBox>();
            cardsDictionary = dict;
            validCards = new HashSet<PictureBox>(pictureBoxes);

            GameObserver.rand = rand;
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

        public bool shouldEnd()
        {
            return validCards.Count == 0;
        }

        public Card getCard(PictureBox pb)
        {
            return cardsDictionary[pb];
        }
        // Validating
        public bool normalValidate(PictureBox pb)
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
                    // calculate points
                    currentPlayer.Score.Points += (scoreMultiplier * 100);
                    scoreMultiplier++;

                    //updateLabels();

                    makeCardStill(pb);
                    makeCardStill(previousCard.Item2);

                    validCards.Remove(pb);
                    validCards.Remove(previousCard.Item2);

                    openedCards.Remove(pb);
                    openedCards.Remove(previousCard.Item2);

                    removeFromCanBePaired(pb);

                    if (validCards.Count == 0) // every card is guessed
                    {
                        Game.endGame();
                    }

                    previousCard = new Tuple<string, PictureBox>(string.Empty, null); // set previous to null
                    secondCard = false;

                    ShouldHandle = true;
                    //MessageBox.Show("sega moze da handla");

                    return true;

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

                }
                else // 2 different cards
                {
                    animateClosingCard(pb);
                    animateClosingCard(previousCard.Item2);

                    ShouldHandle = true;
                    //MessageBox.Show("sega moze da handla");

                    scoreMultiplier = 1;

                    addToCanBePaired(pb);

                    if (!openedCards.Contains(pb))
                    {
                        openedCards.Add(pb);
                    }

                    previousCard = new Tuple<string, PictureBox>(string.Empty, null); // set previous to null
                    secondCard = false;


                    //if (!currentPlayer.isBot())
                    //{
                    //    
                    //}
                    changeTurn();

                    return false;
                }
                /*foreach (var pBox in validCards)
                {
                    pBox.Enabled = true;
                }*/

            }
            else
            {
                ShouldHandle = true;

                addToCanBePaired(pb);

                if (!openedCards.Contains(pb))
                {
                    openedCards.Add(pb);
                }

                secondCard = true;
                previousCard = new Tuple<string, PictureBox>(card.Shape, pb);

                return true;
            }



        }
        public bool validateSecondChance(PictureBox pb)
        {
            
            Card card = getCard(pb);
            animateOpeningCard(pb);


            //((PairGameHumanPlayer)Game.currentPlayer).UseSecondChance(Game.secondChancePrice);

            if (card.Shape.Equals(previousCard.Item1)) // 2 same cards 
            {
                // calculate points
                currentPlayer.Score.Points += (scoreMultiplier * 100);
                scoreMultiplier++;

                makeCardStill(pb);
                makeCardStill(previousCard.Item2);

                validCards.Remove(pb);
                validCards.Remove(previousCard.Item2);

                openedCards.Remove(pb);
                openedCards.Remove(previousCard.Item2);

                removeFromCanBePaired(pb);

                if (this.shouldEnd()) // every card is guessed
                {
                    Game.endGame();
                }

                ShouldHandle = true;
                secondCard = false;


                return true;

            }
            else // 2 different cards
            {
                animateClosingCard(pb);
                //animateClosingCard(previousCard.Item2);

                addToCanBePaired(pb);

                if (!openedCards.Contains(pb))
                {
                    openedCards.Add(pb);
                }
                ShouldHandle = true;

                return false;
            }

        }

        // BOT MOVES

        public Tuple<PictureBox, PictureBox> botMove()
        {
            return currentPlayer.ChoseMove(canBePairedCards, openedCards, validCards, cardsDictionary, rand);
        }

        public bool playBotMove()
        {
            // Bot makes moves until he misses
            ShouldHandle = false; // disable clicking on pictureboxes while bot makes moves

            Tuple<PictureBox, PictureBox> move = botMove();
            validateCard(move.Item1);

            if (validateCard(move.Item2))
            {
                if (this.shouldEnd())
                {
                    Game.endGame();
                    return false;
                }

                return true;
            }

            
            ShouldHandle = true; // enable clicking on pictureBoxes
            return false;
        }

        public void changeTurn()
        {
            if (currentPlayer == Game.Player2)
            {
                currentPlayer = Game.Player1;
            }
            else
            {
                currentPlayer = Game.Player2;
            }

            if (currentPlayer.isBot())
            {
                playBotMove();
            }

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
            if (currentPlayer.Score.Points < Game.x2Price)
            {
                throw new NotEnoughScoreException();
            }

            ((PairGameHumanPlayer)currentPlayer).Usex2(Game.x2Price);
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
            if (currentPlayer.Score.Points < Game.findNextPrice)
            {
                throw new NotEnoughScoreException();
            }

            foreach (var pbox in validCards)
            {
                if (getCard(pbox).Equals(getCard(pb)) && pbox != pb)
                {
                    ((PairGameHumanPlayer)currentPlayer).UseFindNext(Game.findNextPrice);
                    return pbox;
                }
            }
            throw new Exception("CANNOT FIND THE CARD! CHECK FINDNEXT IN IOBSERVER.CS");
        }


        public void OpenCards()
        {
            if (((PairGameHumanPlayer)currentPlayer).openCardsAvaliable < 1)
            {
                throw new HelperNotAvaliableException();
            }
            if (currentPlayer.Score.Points < Game.openCardsPrice)
            {
                throw new NotEnoughScoreException();
            }

            ((PairGameHumanPlayer)currentPlayer).UseOpenCards(Game.openCardsPrice);
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
            if (currentPlayer.Score.Points < Game.secondChancePrice)
            {
                throw new NotEnoughScoreException();
            }

            ((PairGameHumanPlayer)currentPlayer).UseSecondChance(Game.secondChancePrice);
            Game.GoInStateSecondChance();
        }
        public void makeCardsStill()
        {
            foreach (var pbs in validCards)
            {
                this.makeCardStill(pbs);
            }
        }
        public void closeValidCards()
        {
            foreach (var pbs in validCards)
            {
                closeCard(pbs);
            }
        }

        public bool validateCard(PictureBox pb)
        {
            if (Game == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                if (Game.GetState() == STATES.NORMAL_STATE)
                {
                    return normalValidate(pb);
                }
                else if (Game.GetState() == STATES.SECON_CHANCE_STATE)
                {
                    Game.ReturnToNormalState();
                    return validateSecondChance(pb);
                }
                else
                {
                    throw new Exception("GAME IS NOT IN THE ALOWED STATES");
                }
            }
        }
    }
}
