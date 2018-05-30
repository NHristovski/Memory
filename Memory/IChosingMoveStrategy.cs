using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public interface IChosingMoveStrategy
    {
        Tuple<PictureBox, PictureBox> ChoseMove(
            List<Tuple<PictureBox, PictureBox>> unpairedOpenPairs,
            List<PictureBox> openedCards,
            HashSet<PictureBox> validPicutreBoxes,
            Dictionary<PictureBox, Card> cardsDictionary,
            Random rand);

        // Input <- List of cards that can imidietly paired,
        //          List of cards that only one of them is opened
        //          Set of all valid PBoxes
        //          Dict pb -> card
        //
        // Output -> With pboxes should the bot open next   
    }

    public class EasyBotStrategy : IChosingMoveStrategy
    {
        // chose 2 random cards
        public Tuple<PictureBox, PictureBox> ChoseMove(List<Tuple<PictureBox, PictureBox>> unpairedOpenPairs, List<PictureBox> openedCards, HashSet<PictureBox> validPicutreBoxes, Dictionary<PictureBox, Card> cardsDictionary, Random rand)
        {
            List<PictureBox> validPBs = new List<PictureBox>(validPicutreBoxes);
            int firstIndex = rand.Next() % validPBs.Count;
            int secondIndex = rand.Next() % validPBs.Count;

            while (firstIndex == secondIndex) // we need 2 different numbers (positions)
            {
                secondIndex = rand.Next() % validPBs.Count;
            }

            return new Tuple<PictureBox, PictureBox>(validPBs[firstIndex], validPBs[secondIndex]);
        }
    }

    public class NormalBotStrategy : IChosingMoveStrategy
    {
        // Open 1 random card, if the other cards with same shape is alreadyOpened chose it
        // else chose other random card
        public Tuple<PictureBox, PictureBox> ChoseMove(List<Tuple<PictureBox, PictureBox>> unpairedOpenPairs, List<PictureBox> openedCards, HashSet<PictureBox> validPicutreBoxes, Dictionary<PictureBox, Card> cardsDictionary, Random rand)
        {
            List<PictureBox> validPBs = new List<PictureBox>(validPicutreBoxes);
            int firstIndex = rand.Next() % validPBs.Count;

            Card firstCard = cardsDictionary[validPBs[firstIndex]];

            int secondIndex = -1;

            for (int i = 0; i < openedCards.Count; i++)
            {
                if (cardsDictionary[openedCards[i]].Equals(firstCard))
                {
                    if (i != firstIndex)
                    {
                        secondIndex = i;
                       // MessageBox.Show("Treba da ja otvoram pb " + openedCards[i].Name);
                    }
                }
            }
            

            if (secondIndex == -1) // no match so return random cards
            {
                //MessageBox.Show("Nema druga vakva karta pa prodolzuvam random");
                EasyBotStrategy easyBotStrategy = new EasyBotStrategy();
                return easyBotStrategy
                    .ChoseMove(unpairedOpenPairs, openedCards, validPicutreBoxes, cardsDictionary, rand);
            }
            else
            {
                return new Tuple<PictureBox, PictureBox>(validPBs[firstIndex], openedCards[secondIndex]);
            }
        }
    }

    public class HardBotStrategy : IChosingMoveStrategy
    {
        // check if there is some unprairedOpenPairs, if there are none proceed as normalBot would
        public Tuple<PictureBox, PictureBox> ChoseMove(List<Tuple<PictureBox, PictureBox>> unpairedOpenPairs, List<PictureBox> openedCards, HashSet<PictureBox> validPicutreBoxes, Dictionary<PictureBox, Card> cardsDictionary, Random rand)
        {
            if (unpairedOpenPairs.Any())
            {
                //MessageBox.Show("Ke vratam od canBeOpened");
                return unpairedOpenPairs.First();
            }

            //MessageBox.Show("Prodolzhuvam kako normal");
            NormalBotStrategy normalBotStrategy = new NormalBotStrategy();
            return normalBotStrategy
                    .ChoseMove(unpairedOpenPairs, openedCards, validPicutreBoxes, cardsDictionary, rand);

        }
    }
}
