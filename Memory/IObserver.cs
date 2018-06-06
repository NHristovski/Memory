using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    [Serializable]
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

    [Serializable]
    public class GameObserver : IGameObserver
    {
        private PairGame Game;
        public Player currentPlayer { get; set; }
        public static Random rand;

        public bool secondCard;
        public int scoreMultiplier;
        //public bool ShouldHandle { get; set; }



        public HashSet<string> validCards;
        // Tuple<string, pictureBox >
        public Tuple<string, string> previousCard;

        // Bi trebalo Dict<Pb,Card>
        public Dictionary<string, Card> cardsDictionary;
        // List<Tuple<PB,PB>>
        public List<Tuple<string, string>> canBePairedCards;

        // List<PB>
        public List<string> openedCards;

        [NonSerialized]
        public Dictionary<string, PictureBox> stringToPb;
        //[NonSerialized]
        //public List<PictureBox> realPbs;

        public GameObserver(PairGame game, List<PictureBox> realPB, List<string> pictureBoxes, Dictionary<string, Card> dict, Random rand)
        {
            Game = game;
            currentPlayer = Game.Player1;

            secondCard = false;
            scoreMultiplier = 1;

            //ShouldHandle = true;

            canBePairedCards = new List<Tuple<string, string>>();
            openedCards = new List<string>();
            cardsDictionary = dict;
            validCards = new HashSet<string>(pictureBoxes);

            GameObserver.rand = rand;

            makePBDict(pictureBoxes, realPB);
        }

        public PictureBox getPreviousCard()
        {
            if (previousCard == null)
            {
                return null;
            }
            else
            {
                if (previousCard.Item2 == null)
                {
                    return null;
                }
                return stringToPb[previousCard.Item2];
            }
        }
        private void makePBDict(List<string> pbs, List<PictureBox> realPbs)
        {
            stringToPb = new Dictionary<string, PictureBox>();
            for (int i = 0; i < pbs.Count; i++)
            {
                string name = pbs[i];
                for (int j = 0; j < realPbs.Count; j++)
                {
                    if (realPbs[i].Name.Equals(name))
                    {
                        stringToPb[name] = realPbs[i];
                        break;
                    }
                }

            }
        }
        // HELPER FUNCTIONS FOR VALIDATING CARD
        public void removeFromCanBePaired(string pb)
        {
            for (int i = 0; i < canBePairedCards.Count; i++)
            {
                if (canBePairedCards[i].Item1.Equals(pb) && canBePairedCards[i].Item2.Equals(previousCard.Item2))
                {
                    canBePairedCards.RemoveAt(i);
                    break;
                }
                else if (canBePairedCards[i].Item1.Equals(previousCard.Item2) && canBePairedCards[i].Item2.Equals(pb))
                {
                    canBePairedCards.RemoveAt(i);
                    break;
                }
            }
        }

        public void addToCanBePaired(string pb)
        {
            for (int i = 0; i < openedCards.Count; i++)
            {
                if (getCard(openedCards[i]).Equals(getCard(pb)) && !(openedCards[i].Equals(pb)))
                {
                    var tuple = new Tuple<string, string>(openedCards[i], pb);
                    if (!(canBePairedCards.Contains(tuple)
                        ||
                        canBePairedCards.Contains(new Tuple<string, string>(pb, openedCards[i]))))
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

            Card card = getCard(pb.Name);
            //MessageBox.Show(card.pathToOpenCard);
            if (!card.Guessed)
            {
                GifImage gifImage = new GifImage(card.OpenCard);
                for (int i = 0; i < gifImage.frameCount; i++)
                {
                    pb.Enabled = true;
                    pb.Image = gifImage.GetNextFrame();
                    pb.Enabled = false;
                    //Application.DoEvents();
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
            pb.Image = getCard(pb.Name).StillCard;
            pb.Enabled = false;

        }

        public void animateClosingCard(PictureBox pb)
        {
            GifImage gifImage = new GifImage(getCard(pb.Name).CloseCard);
            for (int i = 0; i < gifImage.frameCount; i++)
            {
                pb.Enabled = true;
                pb.Image = gifImage.GetNextFrame();
                pb.Enabled = false;
                //Application.DoEvents();
            }
            closeCard(pb);

        }

        public bool shouldEnd()
        {
            return validCards.Count == 0;
        }

        public Card getCard(string pb)
        {
            return cardsDictionary[pb];
        }
        // Validating
        public bool normalValidate(PictureBox pb)
        {

            Card card = getCard(pb.Name);
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
                    makeCardStill(stringToPb[previousCard.Item2]);

                    validCards.Remove(pb.Name);
                    validCards.Remove(previousCard.Item2);

                    openedCards.Remove(pb.Name);
                    openedCards.Remove(previousCard.Item2);

                    removeFromCanBePaired(pb.Name);

                    //if (validCards.Count == 0) // every card is guessed
                    //{
                    //    Game.endGame();
                    //}

                    previousCard = new Tuple<string, string>(string.Empty, null); // set previous to null
                    secondCard = false;

                    //ShouldHandle = true;
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
                    animateClosingCard(stringToPb[previousCard.Item2]);

                    //ShouldHandle = true;
                    //MessageBox.Show("sega moze da handla");

                    scoreMultiplier = 1;

                    addToCanBePaired(pb.Name);

                    if (!openedCards.Contains(pb.Name))
                    {
                        openedCards.Add(pb.Name);
                    }

                    previousCard = new Tuple<string, string>(string.Empty, null); // set previous to null
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
                //ShouldHandle = true;

                addToCanBePaired(pb.Name);

                if (!openedCards.Contains(pb.Name))
                {
                    openedCards.Add(pb.Name);
                }

                secondCard = true;
                previousCard = new Tuple<string, string>(card.Shape, pb.Name);

                return true;
            }



        }
        public bool validateSecondChance(PictureBox pb)
        {

            Card card = getCard(pb.Name);
            animateOpeningCard(pb);


            //((PairGameHumanPlayer)Game.currentPlayer).UseSecondChance(Game.secondChancePrice);

            if (card.Shape.Equals(previousCard.Item1)) // 2 same cards 
            {
                // calculate points
                currentPlayer.Score.Points += (scoreMultiplier * 100);
                scoreMultiplier++;

                makeCardStill(pb);
                makeCardStill(stringToPb[previousCard.Item2]);

                validCards.Remove(pb.Name);
                validCards.Remove(previousCard.Item2);

                openedCards.Remove(pb.Name);
                openedCards.Remove(previousCard.Item2);

                removeFromCanBePaired(pb.Name);

                secondCard = false;


                return true;

            }
            else // 2 different cards
            {
                animateClosingCard(pb);
                //animateClosingCard(previousCard.Item2);

                addToCanBePaired(pb.Name);

                if (!openedCards.Contains(pb.Name))
                {
                    openedCards.Add(pb.Name);
                }
                //ShouldHandle = true;

                return false;
            }

        }

        // BOT MOVES

        public Tuple<string, string> botMove()
        {
            return currentPlayer.ChoseMove(canBePairedCards, openedCards, validCards, cardsDictionary, rand);
        }

        public bool playBotMove()
        {
            // Bot makes moves until he misses
            //ShouldHandle = false; // disable clicking on pictureboxes while bot makes moves

            Tuple<string, string> move = botMove();
            validateCard(stringToPb[move.Item1]);

            if (validateCard(stringToPb[move.Item2]))
            {
                if (this.shouldEnd())
                {
                    return false;
                }

                return true;
            }


            //ShouldHandle = true; // enable clicking on pictureBoxes
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

            //if (currentPlayer.isBot())
            //{
            //    playBotMove();
            //}

        }

        //HELPERS FUNCTIONS

        public string getx2Avaliable()
        {
            return ((PairGamePlayer)currentPlayer).x2Avaliable + "";
        }
        public string getSecondChanceAvaliable()
        {
            return ((PairGamePlayer)currentPlayer).secondChanceAvaliable + "";
        }
        public string getFindNextAvaliable()
        {
            return ((PairGamePlayer)currentPlayer).findNextAvaliable + "";
        }
        public string getOpenCardsAvaliable()
        {
            return ((PairGamePlayer)currentPlayer).openCardsAvaliable + "";
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
                if (getCard(pbox).Equals(getCard(pb.Name)) && !(pbox.Equals(pb.Name)))
                {
                    ((PairGameHumanPlayer)currentPlayer).UseFindNext(Game.findNextPrice);
                    return stringToPb[pbox];
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
                this.makeCardStill(stringToPb[pbs]);
            }
        }
        public void closeValidCards()
        {
            foreach (var pbs in validCards)
            {
                if (previousCard != null && previousCard.Item2 != null && !(pbs.Equals(previousCard.Item2))) 
                {
                    closeCard(stringToPb[pbs]);
                }
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

        public Tuple<bool, int, Player, HashSet<string>,
            Tuple<string, string>, Dictionary<string, Card>,
            Tuple<List<Tuple<string, string>>, List<string>>> getInfo()
            {

            return new Tuple<bool, int, Player, HashSet<string>,
            Tuple<string, string>, Dictionary<string, Card>,
            Tuple<List<Tuple<string, string>>, List<string>>>
            (secondCard,
            scoreMultiplier, currentPlayer, validCards,
            previousCard, cardsDictionary,
            new Tuple<List<Tuple<string, string>>, List<string>>(canBePairedCards,
            openedCards));

            }

        public void setInfo(Tuple<bool, int, Player, HashSet<string>,
            Tuple<string, string>, Dictionary<string, Card>,
            Tuple<List<Tuple<string, string>>, List<string>>> tuple)
        {
            secondCard = tuple.Item1;
            scoreMultiplier = tuple.Item2;
            currentPlayer = tuple.Item3;
            validCards = tuple.Item4;
            previousCard = tuple.Item5;
            cardsDictionary = tuple.Item6;
            canBePairedCards = tuple.Item7.Item1;
            openedCards = tuple.Item7.Item2;


        }



    }
}
