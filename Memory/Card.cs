using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    [Serializable]
    public class Card
    {
        //test
        public string Shape { get; set; }
        public Image OpenCard { get; set; }
        public Image CloseCard { get; set; }
        public Image StillCard { get; set; }
        public bool Guessed { get; set; }
        public Card(string shape,Image open, Image close, Image still)
        {
            Shape = shape;
            CloseCard = close;
            OpenCard = open;
            StillCard = still;
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
