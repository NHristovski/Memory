using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.IO;

namespace Memory
{
    [Serializable]
    public abstract class Game 
    {
        
        protected static Random rand = new Random();

        public Player Player1 { get; set; }

        public int Time { get; set; }

        public Game(Player player)
        {
            Player1 = player;
            Time = 0;
          
        }

        public string getTimeRepresentation()
        {
            return (Time > 3600) ?
                string.Format("{0:00}:{1:00}:{2:00}", Time / 3600, (Time % 3600) / 60, (Time % 3600) % 60)
                :
                string.Format("{0:00}:{1:00}", Time / 60, Time % 60);
        }

        protected abstract void startGame();
        public abstract DialogResult endGame();

    }

    [Serializable]
    public class PairGame : Game, IObservable
    {
        private STATES State;

        protected string[] shapes;

        public Player Player2 { get; set; }


        // List<PictureBox>
        public List<string> pictureBoxes;
        public List<Card> cards;
        // Dictionary<PictureBox, Card>
        public Dictionary<string, Card> cardsDictionary;
        
        public readonly int x2Price;
        public readonly int secondChancePrice;
        public readonly int openCardsPrice;
        public readonly int findNextPrice;

        [NonSerialized]
        public List<PictureBox> realPicBoxes;

        GameObserver Observer;

        //public bool ShouldHandle
        //{
        //    get { return Observer.ShouldHandle; }
        //    set { Observer.ShouldHandle = value; }
        //}

        public PictureBox getPreviousCard()
        {
            return Observer.getPreviousCard();
        }
        // CONSTRUCTOR
        public PairGame(Player player1,Player player2,List<PictureBox> realPBS, List<string> pictureBoxes, int x2Price, int secondChancePrice, int findNextPrice, int openCardsPrice) : base(player1)
        {
            State = STATES.NORMAL_STATE;
            Player2 = player2;
            shapes = new string[] { "spade", "heart", "I", "IRed",
                "V", "X", "arrow", "diamond", "mars", "moon" }; // not complete

            this.x2Price = x2Price;
            this.secondChancePrice = secondChancePrice;
            this.openCardsPrice = openCardsPrice;
            this.findNextPrice = findNextPrice;

            this.pictureBoxes = pictureBoxes;
            cardsDictionary = new Dictionary<string, Card>();
            cards = new List<Card>();

            realPicBoxes = realPBS;

            this.Observer = new GameObserver(this,realPicBoxes,pictureBoxes,cardsDictionary,rand);

            startGame();
        }

        //Implementig interface IObervable
        public STATES GetState()
        {
            return State;
        }
        public void ReturnToNormalState()
        {
            this.State = STATES.NORMAL_STATE;
        }
        public void GoInStateSecondChance()
        {
            this.State = STATES.SECON_CHANCE_STATE;
        }
        
        // MAIN FUNCTION OF THE CLASS
        public bool validateCard(PictureBox pb)
        {
            return Observer.validateCard(pb);
        }

        // RETURNS OPEN,CLOSE,STILL CARD IMAGES
        public Tuple<Image,Image,Image> getImages(string shape)
        {
            return new Tuple<Image, Image, Image>(Image.FromFile(Paths.pathToResources + shape + "_open.gif"),
                                                  Image.FromFile(Paths.pathToResources + shape + "_close.gif"),
                                                  Image.FromFile(Paths.pathToResources + shape + "_still.jpg"));
            
        }

       

        protected override void startGame()
        {
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

                    Tuple<Image, Image, Image> images = this.getImages(shape);

                    Card card = new Card(shape, images.Item1, images.Item2, images.Item3);
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

            /*StringBuilder sb = new StringBuilder();

            foreach (var elem in cardsDictionary)
            {
                sb.Append(elem.Key.Name).Append("-").Append(elem.Value.Shape).Append("\n");
            } 
            MessageBox.Show(sb.ToString());*/
        }


        public override DialogResult endGame()
        {

            string winner = string.Empty;
            if (Player1.Score.Points > Player2.Score.Points)
            {
                winner = Player1.Name + " with score: " + Player1.Score.Points;
            }
            else if (Player1.Score.Points < Player2.Score.Points)
            {
                winner = Player2.Name + " with score: " + Player2.Score.Points;
            }
            else
            {
                winner = " DRAW! ";
            }

            //PlayerDocument.Players.Add(Player1);
            using (StreamWriter sw = File.AppendText(Paths.pathToPairGameScores))
            {
                var phrase = string.Join(",", Player1.ToString().Split(new char[] { ' ' }));
                sw.WriteLine(phrase);
                if (!Player2.isBot())
                { 
                    phrase = string.Join(",", Player2.ToString().Split(new char[] { ' ' }));
                    //PlayerDocument.Players.Add(Player2);
                    sw.WriteLine(phrase);
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("Winner: ").Append(winner)
                .Append("\n").Append("Play time: ")
                .Append(this.getTimeRepresentation()).Append("\n\n")
                .Append("Would you like to play again?");

            DialogResult result = MessageBox.Show(sb.ToString(),"GAME OVER",MessageBoxButtons.YesNo);
            return result;
        }

        public override string ToString()
        {
            string s = Player1.Name + " " + Player2.Name;
            foreach (var ss in pictureBoxes)
            {
                s += " " + ss;
            }
            s += "\n";
            foreach (var a in cardsDictionary)
            {
                s += a.Key + "-" + a.Value + "\n";
            }
            return s;
        }
        // INTERACTION METHODS

        public Tuple<bool, int, Player, HashSet<string>,
            Tuple<string, string>, Dictionary<string, Card>,
            Tuple<List<Tuple<string, string>>, List<string>>> getInfo()
        {

            return Observer.getInfo();

        }

        public void setInfo(Tuple<bool, int, Player, HashSet<string>,
            Tuple<string, string>, Dictionary<string, Card>,
            Tuple<List<Tuple<string, string>>, List<string>>> tuple)
        {
            Observer.setInfo(tuple);
        }


        public bool ShouldEnd()
        {
            return Observer.shouldEnd();
        }

        public string getScoreMultiplier()
        {
            return Observer.scoreMultiplier + "";
        }

        public bool BotTurn()
        {
            return Observer.currentPlayer.isBot();
        }

        public bool BotMoveSuccsessfull()
        {
            return Observer.playBotMove();
        }

        public void closeCard(PictureBox pb)
        {
            Observer.closeCard(pb);
        }

        public string GetCurrentPlayerName()
        {
            return Observer.currentPlayer.Name;
        }

        public string getx2Avaliable()
        {
            return Observer.getx2Avaliable();
        }

        public string getFindNextAvaliable()
        {
            return Observer.getFindNextAvaliable();
        }

        public string getOpenCardsAvaliable()
        {
            return Observer.getOpenCardsAvaliable();
        }

        public string getSecondChanceAvaliable()
        {
            return Observer.getSecondChanceAvaliable();
        }

        public void DoubleMultiplier()
        {
            Observer.DoubleMultiplier();
        }

        public void SecondChance()
        {
            Observer.SecondChance();
        }

        public PictureBox FindNext(PictureBox pb)
        {
            return Observer.FindNext(pb);
        }

        public void OpenCards()
        {
            Observer.OpenCards();
        }

        public void makeCardStill(PictureBox pb)
        {
            Observer.makeCardStill(pb);
        }

        public void makeCardsStill()
        {
            Observer.makeCardsStill();
        }

        public void closeValidCards()
        {
            Observer.closeValidCards();
        }
        public bool isValid(PictureBox pb)
        {
            return Observer.validCards.Contains(pb.Name);
        }
        
    }

    [Serializable]
    public class SequenceGame : Game
    {
        public SequenceGame(Player player) : base(player)
        {

        }
        protected override void startGame()
        {
            throw new Exception("Start Game is not implemented");
        }
        public override DialogResult endGame()
        {
            throw new Exception("End Game is not implemented");
        }
    }

  
}
