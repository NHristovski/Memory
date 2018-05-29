using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Memory
{
    public abstract class Game
    {
        public Player Player1 { get; set; }

        public Game(Player player)
        {
            Player1 = player;
          
        }

        public abstract void startGame();
        public abstract void endGame();


    }
    public class PairGame : Game
    {
        protected Dictionary<System.Windows.Forms.PictureBox, Card> cardsDictionary;
        protected string[] shapes;
        public Player Player2 { get; set; }
        protected List<System.Windows.Forms.PictureBox> pictureBoxes;
        protected List<Card> cards;

        public PairGame(Player player1,Player player2, List<System.Windows.Forms.PictureBox> pictureBoxes) : base(player1)
        {
            Player2 = player2;
            shapes = new string[] { "spade", "heart" }; // not complete
            cardsDictionary = new Dictionary<System.Windows.Forms.PictureBox, Card>();
            this.pictureBoxes = pictureBoxes;
            cards = new List<Card>();
        }
        public Card getCard(System.Windows.Forms.PictureBox pb)
        {
            return cardsDictionary[pb];
        }
        private StringBuilder getShapesFolder(string shape)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(System.IO.Directory.GetCurrentDirectory())
                .Append(@"\shapes\")
                .Append(shape)
                .Append(@"\")
                .Append(shape);
            return stringBuilder;
        }
        protected string getPathOpen(string shape)
        {
            StringBuilder stringBuilder = this.getShapesFolder(shape);
            stringBuilder.Append("_open.gif");
            return stringBuilder.ToString();
        }
        protected string getPathClose(string shape)
        {
            StringBuilder stringBuilder = this.getShapesFolder(shape);
            stringBuilder.Append("_close.gif");
            return stringBuilder.ToString();
        }
        protected string getPathStill(string shape)
        {
            StringBuilder stringBuilder = this.getShapesFolder(shape);
            stringBuilder.Append("_still.jpg");
            return stringBuilder.ToString();
        }
        public override void startGame()
        {
            Random rand = new Random();
            HashSet<int> picked = new HashSet<int>();
            for (int i = 0; i < pictureBoxes.Count / 2; i++)
            {
                int index = rand.Next(shapes.Length); // chose one shape
                //if (picked.Contains(index)) // see if it is already chosen
                //{
                  //  i--;
                //}
                //else
               // {
                    picked.Add(index);
                    string shape = shapes[index];
                    string shapeOpen = this.getPathOpen(shape);
                    string shapeClose = this.getPathClose(shape);
                    string shapeStill = this.getPathStill(shape);
                    Card card = new Card(shape, shapeOpen, shapeClose, shapeStill);
                    cards.Add(card);
                    cards.Add(card);
              //  }

            }
            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                int index = rand.Next(cards.Count);
                cardsDictionary.Add(pictureBoxes[i], cards[index]);
                cards.RemoveAt(index);
            }
        }


        public override void endGame()
        {
            System.Windows.Forms.MessageBox.Show("END GAME");
        }
    }
    

    public class SequenceGame : Game
    {
        public SequenceGame(Player player) : base(player)
        {

        }
        public override void startGame()
        {
            throw new Exception("Start Game is not implemented");
        }
        public override void endGame()
        {
            throw new Exception("End Game is not implemented");
        }
    }

  
}
