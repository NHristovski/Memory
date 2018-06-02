using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public class NotEnoughScoreException : Exception
    {
        public NotEnoughScoreException() : base()
        {

        }
    }

    public class HelperNotAvaliableException : Exception
    {
        public HelperNotAvaliableException() : base()
        {

        }
    }
}
