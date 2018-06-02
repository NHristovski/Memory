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
        public PairGame Game { get; set; }

        public GameObserver()
        {
            Game = null;
        }

        public bool normalValidate(PictureBox pb)
        {

            Card card = Game.getCard(pb);
            Game.animateOpeningCard(pb);

            if (Game.secondCard)
            {
                /*foreach (var pBox in validCards)
                {
                    pBox.Enabled = false;
                }*/
                if (card.Shape.Equals(Game.previousCard.Item1)) // 2 same cards 
                {
                    // calculate points
                    Game.currentPlayer.Score.Points += (Game.scoreMultiplier * 100);
                    Game.scoreMultiplier++;

                    //updateLabels();

                    Game.makeCardStill(pb);
                    Game.makeCardStill(Game.previousCard.Item2);

                    Game.validCards.Remove(pb);
                    Game.validCards.Remove(Game.previousCard.Item2);

                    Game.openedCards.Remove(pb);
                    Game.openedCards.Remove(Game.previousCard.Item2);

                    Game.removeFromCanBePaired(pb);

                    if (Game.validCards.Count == 0) // every card is guessed
                    {
                        Game.endGame();
                    }

                    Game.previousCard = new Tuple<string, PictureBox>(string.Empty, null); // set previous to null
                    Game.secondCard = false;

                    Game.ShouldHandle = true;
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
                    Game.animateClosingCard(pb);
                    Game.animateClosingCard(Game.previousCard.Item2);

                    Game.ShouldHandle = true;
                    //MessageBox.Show("sega moze da handla");

                    Game.scoreMultiplier = 1;

                    Game.addToCanBePaired(pb);

                    if (!Game.openedCards.Contains(pb))
                    {
                        Game.openedCards.Add(pb);
                    }

                    Game.previousCard = new Tuple<string, PictureBox>(string.Empty, null); // set previous to null
                    Game.secondCard = false;


                    if (!Game.currentPlayer.isBot())
                    {
                        Game.changeTurn();
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
                Game.ShouldHandle = true;

                Game.addToCanBePaired(pb);

                if (!Game.openedCards.Contains(pb))
                {
                    Game.openedCards.Add(pb);
                }

                Game.secondCard = true;
                Game.previousCard = new Tuple<string, PictureBox>(card.Shape, pb);

                return true;
            }



        }
        public bool validateSecondChance(PictureBox pb)
        {
            
            Card card = Game.getCard(pb);
            Game.animateOpeningCard(pb);


            //((PairGameHumanPlayer)Game.currentPlayer).UseSecondChance(Game.secondChancePrice);

            if (card.Shape.Equals(Game.previousCard.Item1)) // 2 same cards 
            {
                // calculate points
                Game.currentPlayer.Score.Points += (Game.scoreMultiplier * 100);
                Game.scoreMultiplier++;

                Game.makeCardStill(pb);
                Game.makeCardStill(Game.previousCard.Item2);

                Game.validCards.Remove(pb);
                Game.validCards.Remove(Game.previousCard.Item2);

                Game.openedCards.Remove(pb);
                Game.openedCards.Remove(Game.previousCard.Item2);

                Game.removeFromCanBePaired(pb);

                if (Game.validCards.Count == 0) // every card is guessed
                {
                    Game.endGame();
                }

                Game.ShouldHandle = true;
                Game.secondCard = false;


                return true;

            }
            else // 2 different cards
            {
                Game.animateClosingCard(pb);
                //animateClosingCard(previousCard.Item2);

                Game.addToCanBePaired(pb);

                if (!Game.openedCards.Contains(pb))
                {
                    Game.openedCards.Add(pb);
                }
                Game.ShouldHandle = true;

                return false;
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
