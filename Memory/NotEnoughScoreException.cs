using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    [Serializable]
    public class NotEnoughScoreException : Exception
    {
        public NotEnoughScoreException() : base("You don't have enought score to buy this helper!")
        {
            
        }
    }
    [Serializable]
    public class HelperNotAvaliableException : Exception
    {
        public HelperNotAvaliableException() : base("You have used all your instances of this helper!")
        {
        }
    }
    [Serializable]
    public class CardNotOpenedException : Exception
    {
        public CardNotOpenedException() : base("You have to open one card before using this helper!")
        {

        }
    }
}
