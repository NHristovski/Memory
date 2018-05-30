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
            HashSet<PictureBox> validPicutreBoxes);
        // Input <- List of cards that can imidietly paired,
        //          List of cards that only one of them is opened
        //          Set of all valid PBoxes
        //
        // Output -> With pboxes should the bot open next   
    }

    /*public class EasyBotStrategy : IChosingMoveStrategy
    {

    }*/
}
