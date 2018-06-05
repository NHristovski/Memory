using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Memory
{
    [Serializable]
    public abstract class Player
    {
        public string Name{ get;set;}
        public DateTime gameStarted { get; set; }
        public DateTime gameEnded { get; set; }
        public Score Score { get; set; }

        protected IChosingMoveStrategy chosingMoveStrategy;

        public Player(string name,IChosingMoveStrategy chosingMoveStrategy)
        {
            Name = name;
            this.chosingMoveStrategy = chosingMoveStrategy;

            Score = new Score();
            gameStarted = DateTime.Now; // gameStarted and gameEnded are non null variables,
            gameEnded = DateTime.Now;   // so I put DateTime.Now instead of null

            // After creating Player with this constructor it has only Name and 
            // empty Score ( 0 points). When new game is clicked gameStarted should be updated. 
            // When game ends gameEnded should be updated, points (inside score ) 
            // should be updated, and Time insade score should be inicialized to GameEnded - GameStarted.
        }

        public Player ResetScore()
        {
            // !!!!!! Is this all it needs to reset???

            this.Score.Points = 0;
            return this;
            ////////////////////
        }
        public override string ToString()
        {
            return string.Format("{0,-20},{1}", Name, Score.ToString());
        }

        public void calculateDurationOfGame() // set the Time parametar of score
        {
            TimeSpan duration = gameEnded - gameStarted;
            Score.Time = duration;
        }

        public abstract bool isBot();
        public abstract Tuple<PictureBox, PictureBox> ChoseMove(List<Tuple<PictureBox, PictureBox>> unpairedOpenPairs, List<PictureBox> openedCards, HashSet<PictureBox> validPicutreBoxes, Dictionary<PictureBox, Card> cardsDictionary, Random rand);

        
    }

    [Serializable]
    public abstract class PairGamePlayer : Player
    {
        public int x2Avaliable { get; set; }
        public int secondChanceAvaliable { get; set; }
        public int openCardsAvaliable { get; set; }
        public int findNextAvaliable { get; set; }

        public PairGamePlayer(string name, IChosingMoveStrategy strategy) : base(name, strategy)
        {
        }
        public virtual void setEasyGameAvaliable()
        {

        }
        public virtual void setNormalGameAvaliable()
        {
        }
        public virtual void setHardGameAvaliable()
        {
        }
    }

    [Serializable]
    public class HumanPlayer : PairGamePlayer
    {
        //public bool Turn { get; set; }

        public HumanPlayer(string name) : base(name,null)
        {
        }

        public override bool isBot()
        {
            return false;
        }
        public override Tuple<PictureBox, PictureBox> ChoseMove(List<Tuple<PictureBox, PictureBox>> unpairedOpenPairs, List<PictureBox> openedCards, HashSet<PictureBox> validPicutreBoxes, Dictionary<PictureBox, Card> cardsDictionary, Random rand)
        {
            return null;
        }
    }

    [Serializable]
    public class PairGameHumanPlayer : HumanPlayer
    {

        public PairGameHumanPlayer(string name) : base(name)
        {

        }

        public override void setEasyGameAvaliable()
        {
            x2Avaliable = 2;
            secondChanceAvaliable = 1;
            findNextAvaliable = 1;
            openCardsAvaliable = 1;
        }
        public override void setNormalGameAvaliable()
        {
            x2Avaliable = 1;
            secondChanceAvaliable = 2;
            findNextAvaliable = 2;
            openCardsAvaliable = 1;
        }
        public override void setHardGameAvaliable()
        {
            x2Avaliable = 2;
            secondChanceAvaliable = 3;
            findNextAvaliable = 2;
            openCardsAvaliable = 1;
        }

        public void Usex2(int price)
        {
            x2Avaliable--;
            Score.Points -= price;
        }
        public void UseSecondChance(int price)
        {
            secondChanceAvaliable--;
            Score.Points -= price;
        }
        public void UseOpenCards(int price)
        {
            openCardsAvaliable--;
            Score.Points -= price;
        }
        public void UseFindNext(int price)
        {
            findNextAvaliable--;
            Score.Points -= price;
        }
    }

    [Serializable]
    public class Bot : PairGamePlayer
    {
        
        public override void setEasyGameAvaliable()
        {
            x2Avaliable = 2;
            secondChanceAvaliable = 1;
            findNextAvaliable = 1;
            openCardsAvaliable = 1;
        }
        public override void setNormalGameAvaliable()
        {
            x2Avaliable = 1;
            secondChanceAvaliable = 2;
            findNextAvaliable = 2;
            openCardsAvaliable = 1;
        }
        public override void setHardGameAvaliable()
        {
            x2Avaliable = 2;
            secondChanceAvaliable = 3;
            findNextAvaliable = 2;
            openCardsAvaliable = 1;
        }

        public Bot(string name,IChosingMoveStrategy strategy) : base(name,strategy)
        {
        }
        
        public override bool isBot()
        {
            return true;
        }

        public override Tuple<PictureBox,PictureBox> ChoseMove(List<Tuple<PictureBox, PictureBox>> unpairedOpenPairs,List<PictureBox> openedCards,HashSet<PictureBox> validPicutreBoxes,Dictionary<PictureBox, Card> cardsDictionary,Random rand)
        {
            return chosingMoveStrategy
                .ChoseMove(unpairedOpenPairs, openedCards, validPicutreBoxes, cardsDictionary, rand);
        }
    }


}
