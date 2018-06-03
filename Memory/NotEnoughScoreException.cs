using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public class NotEnoughScoreException : Exception
    {
        public NotEnoughScoreException() : base("You don't have enought score to buy this helper!")
        {
            
        }
    }

    public class HelperNotAvaliableException : Exception
    {
        public HelperNotAvaliableException() : base("You have used all your instances of this helper!")
        {
        }
    }
    public class CardNotOpenedException : Exception
    {
        public CardNotOpenedException() : base("You have to open one card before using this helper!")
        {

        }
    }
}
