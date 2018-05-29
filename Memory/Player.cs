using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;   

namespace Memory
{
    public abstract class Player
    {
        public string Name{ get;set;}
        public DateTime gameStarted { get; set; }
        public DateTime gameEnded { get; set; }
        public Score Score { get; set; }

        public Player(string name)
        {
            Name = name;
            Score = new Score();
            gameStarted = DateTime.Now; // gameStarted and gameEnded are non null variables,
            gameEnded = DateTime.Now;   // so I put DateTime.Now instead of null

            // After creating Player with this constructor it has only Name and 
            // empty Score ( 0 points). When new game is clicked gameStarted should be updated. 
            // When game ends gameEnded should be updated, points (inside score ) 
            // should be updated, and Time insade score should be inicialized to GameEnded - GameStarted.
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

        public abstract bool isHuman(); 
    }

    public class HumanPlayer : Player
    {
        public bool Turn { get; set; }

        public HumanPlayer(string name) : base(name)
        {

        }
        public override bool isHuman()
        {
            return true;
        }
    }

    public abstract class Bot : Player
    {
        public Bot() : base("NOT-A-BOT")
        {

        }
        public override bool isHuman()
        {
            return false;
        }
        public abstract void chooseMove();
    }

    public class EasyBot : Bot
    {
        public EasyBot() : base()
        {

        }
        public override void chooseMove()
        {
            throw new NotImplementedException();
        }
    }
    public class NormalBot : Bot
    {
        public NormalBot() : base()
        {

        }
        public override void chooseMove()
        {
            throw new NotImplementedException();
        }
    }
    public class HardBot : Bot
    {
        public HardBot() : base()
        {

        }
        public override void chooseMove()
        {
            throw new NotImplementedException();
        }
    }
}
