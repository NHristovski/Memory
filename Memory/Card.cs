using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public class Card
    {
        public string Shape { get; set; }
        public string pathToOpenCard { get; set; }
        public string pathToCloseCard { get; set; }
        public string pathToStillCard { get; set; }
        public bool Guessed { get; set; }
        public Card(string shape,string open, string close, string still)
        {
            Shape = shape;
            pathToCloseCard = close;
            pathToOpenCard = open;
            pathToStillCard = still;
            Guessed = false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Card card = (Card)obj;

            return this.Shape.Equals(card.Shape);
        }

        public override int GetHashCode()
        {
            return -637254986 + EqualityComparer<string>.Default.GetHashCode(Shape);
        }

        public override string ToString()
        {
            return Shape;
        }
    }
}
