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
            Tuple<string, string> ChoseMove(
            List<Tuple<string, string>> unpairedOpenPairs,
            List<string> openedCards,
            HashSet<string> validPicutreBoxes,
            Dictionary<string, Card> cardsDictionary,
            Random rand);

        // Input <- List of cards that can imidietly paired,
        //          List of cards that only one of them is opened
        //          Set of all valid PBoxes
        //          Dict pb -> card
        //
        // Output -> With pboxes should the bot open next   
    }

    [Serializable]
    public class EasyBotStrategy : IChosingMoveStrategy
    {
        // chose 2 random cards
        public Tuple<string, string> ChoseMove(
            List<Tuple<string, string>> unpairedOpenPairs,
            List<string> openedCards,
            HashSet<string> validPicutreBoxes,
            Dictionary<string, Card> cardsDictionary,
            Random rand)
        {
            List<string> validPBs = new List<string>(validPicutreBoxes);
            int firstIndex = rand.Next() % validPBs.Count;
            int secondIndex = rand.Next() % validPBs.Count;

            while (firstIndex == secondIndex) // we need 2 different numbers (positions)
            {
                secondIndex = rand.Next() % validPBs.Count;
            }

            return new Tuple<string, string>(validPBs[firstIndex], validPBs[secondIndex]);
        }
    }

    [Serializable]
    public class NormalBotStrategy : IChosingMoveStrategy
    {
        // Open 1 random card, if the other cards with same shape is alreadyOpened chose it
        // else chose other random card
        public Tuple<string, string> ChoseMove(
            List<Tuple<string, string>> unpairedOpenPairs,
            List<string> openedCards,
            HashSet<string> validPicutreBoxes,
            Dictionary<string, Card> cardsDictionary,
            Random rand)
        {
            List<string> validPBs = new List<string>(validPicutreBoxes);

            int firstIndex = rand.Next() % validPBs.Count;

            Card firstCard = cardsDictionary[validPBs[firstIndex]];

            int secondIndex = -1;

            //StringBuilder sb = new StringBuilder();
            //sb.Append("Current card " + firstCard.Shape + " Na pozicija "  + validPBs[firstIndex].Name + "\n");
            for (int i = 0; i < openedCards.Count; i++)
            {
                //sb.Append(cardsDictionary[openedCards[i]].Shape + "\n");
                if (cardsDictionary[openedCards[i]].Equals(firstCard))
                {
                    if (!(validPBs[firstIndex].Equals(openedCards[i]))) // not the same picture box
                    {
                        secondIndex = i;
                        //MessageBox.Show("Treba da ja otvoram pb " + openedCards[i].Name);
                    }
                    // DEBUGING
                    //else
                    //{
                    //    MessageBox.Show("ISTI SE NO NA ISTA POZICIJA!!!");
                    //}
                }
            }

            //MessageBox.Show(sb.ToString());

            if (secondIndex == -1) // no match so return random cards
            {
                //MessageBox.Show("Nema druga vakva karta pa prodolzuvam random");

                //EasyBotStrategy easyBotStrategy = new EasyBotStrategy();
                //return easyBotStrategy
                //    .ChoseMove(unpairedOpenPairs, openedCards, validPicutreBoxes, cardsDictionary, rand);

                secondIndex = rand.Next() % validPBs.Count;
                while (openedCards.Contains(validPBs[secondIndex]) || secondIndex == firstIndex) // find random card that is not in the already opened cards
                {
                    secondIndex = rand.Next() % validPBs.Count;
                }

                return new Tuple<string, string>(validPBs[firstIndex], validPBs[secondIndex]);

            }
            else
            {
                return new Tuple<string, string>(validPBs[firstIndex], openedCards[secondIndex]);
            }
         
        }
    }

    [Serializable]
    public class HardBotStrategy : IChosingMoveStrategy
    {
        // check if there is some unpairedOpenPairs, if there are none proceed as normalBot would
        public Tuple<string, string> ChoseMove(
            List<Tuple<string, string>> unpairedOpenPairs,
            List<string> openedCards,
            HashSet<string> validPicutreBoxes,
            Dictionary<string, Card> cardsDictionary,
            Random rand)
        {
            if (unpairedOpenPairs.Any())
            {
                //MessageBox.Show("Ke vratam od canBeOpened " + unpairedOpenPairs.First().Item1.Name + "-" + unpairedOpenPairs.First().Item2.Name);
                var pair = unpairedOpenPairs.First();
                if (validPicutreBoxes.Contains(pair.Item1) && validPicutreBoxes.Contains(pair.Item2))
                {
                    return unpairedOpenPairs.First();
                }
                else
                {
                    unpairedOpenPairs.Remove(pair);
                    var hardBotStrategy = new HardBotStrategy();
                    return hardBotStrategy.ChoseMove(unpairedOpenPairs, openedCards, validPicutreBoxes, cardsDictionary, rand);
                }
            }

            //MessageBox.Show("Prodolzhuvam kako normal");
            NormalBotStrategy normalBotStrategy = new NormalBotStrategy();
            return normalBotStrategy
                    .ChoseMove(unpairedOpenPairs, openedCards, validPicutreBoxes, cardsDictionary, rand);

        }
    }
}
