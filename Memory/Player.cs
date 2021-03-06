﻿using System;
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
        //public DateTime gameEnded { get; set; }
        public Score Score { get; set; }

        protected IChosingMoveStrategy chosingMoveStrategy;

        public Player(string name,IChosingMoveStrategy chosingMoveStrategy)
        {
            Name = name;
            this.chosingMoveStrategy = chosingMoveStrategy;

            Score = new Score();
            gameStarted = DateTime.Now;
        }

        public Player ResetScore()
        {
            this.Score.Points = 0;
            gameStarted = DateTime.Now;
            return this;
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Name, Score.ToString(), gameStarted.ToString("M/d/yyyy")); // 
        }

        public abstract bool isBot();                       
        public abstract Tuple<string, string> ChoseMove(List<Tuple<string, string>> unpairedOpenPairs, List<string> openedCards, HashSet<string> validPicutreBoxes, Dictionary<string, Card> cardsDictionary, Random rand);

        
    }

    [Serializable]
    public abstract class PairGamePlayer : Player
    {
        public int x2Avaliable { get; set; }
        public int secondChanceAvaliable { get; set; }
        public int openCardsAvaliable { get; set; }
        public int findNextAvaliable { get; set; }
        public string type;
        public PairGamePlayer(string name, IChosingMoveStrategy strategy,string type) : base(name, strategy)
        {
            this.type = type;
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

        public override string ToString()
        {
            return base.ToString() + " " + type;
        }

        public virtual void Usex2(int price)
        {

        }
        public virtual void UseSecondChance(int price)
        {

        }
        public virtual void UseOpenCards(int price)
        {

        }
        public virtual void UseFindNext(int price)
        {

        }
    }

    [Serializable]
    public class HumanPlayer : PairGamePlayer
    {
        //public bool Turn { get; set; }

        public HumanPlayer(string name,string type) : base(name,null,type)
        {
        }

        public override bool isBot()
        {
            return false;
        }
        public override Tuple<string, string> ChoseMove(List<Tuple<string, string>> unpairedOpenPairs, List<string> openedCards, HashSet<string> validPicutreBoxes, Dictionary<string, Card> cardsDictionary, Random rand)
        {
            return null;
        }
    }

    [Serializable]
    public class PairGameHumanPlayer : HumanPlayer
    {

        public PairGameHumanPlayer(string name, string type) : base(name, type)
        {

        }

        public override void setEasyGameAvaliable()
        {
            x2Avaliable = 2;
            secondChanceAvaliable = 2;
            findNextAvaliable = 1;
            openCardsAvaliable = 1;
        }
        public override void setNormalGameAvaliable()
        {
            x2Avaliable = 2;
            secondChanceAvaliable = 3;
            findNextAvaliable = 2;
            openCardsAvaliable = 1;
        }
        public override void setHardGameAvaliable()
        {
            x2Avaliable = 3;
            secondChanceAvaliable = 4;
            findNextAvaliable = 2;
            openCardsAvaliable = 1;
        }

        public override void Usex2(int price)
        {
            x2Avaliable--;
            Score.Points -= price;
        }
        public override void UseSecondChance(int price)
        {
            secondChanceAvaliable--;
            Score.Points -= price;
        }
        public override void UseOpenCards(int price)
        {
            openCardsAvaliable--;
            Score.Points -= price;
        }
        public override void UseFindNext(int price)
        {
            findNextAvaliable--;
            Score.Points -= price;
        }
    }   

    [Serializable]
    public class Bot : PairGamePlayer
    {

        public Bot(string name,IChosingMoveStrategy strategy) : base(name,strategy,"bot")
        {
        }
        
        public override bool isBot()
        {
            return true;
        }

        public override Tuple<string, string> ChoseMove(List<Tuple<string, string>> unpairedOpenPairs, List<string> openedCards, HashSet<string> validPicutreBoxes, Dictionary<string, Card> cardsDictionary, Random rand)
        {
            return chosingMoveStrategy
                .ChoseMove(unpairedOpenPairs, openedCards, validPicutreBoxes, cardsDictionary, rand);
        }
        private void setAvaliable()
        {
            x2Avaliable = 0;
            secondChanceAvaliable = 0;
            findNextAvaliable = 0;
            openCardsAvaliable = 0;
        }
        public override void setEasyGameAvaliable()
        {
            setAvaliable();
        }
        public override void setNormalGameAvaliable()
        {
            setAvaliable();
        }
        public override void setHardGameAvaliable()
        {
            setAvaliable();
        }
        public override void Usex2(int price)
        {
        }
        public override void UseSecondChance(int price)
        {
        }
        public override void UseOpenCards(int price)
        {
        }
        public override void UseFindNext(int price)
        {
        }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public class SequenceGamePlayer : Player
    {
        public int TotalTime { get; private set; }
        public string GameType { get; set; }
        public int Level { get; set; }
        public Gender PlayerGender { get; set; }

        // Helpers
        public int showSequenceHelper { get; set; }
        public int extraTimeHelper { get; set; }
        public int increaseMultiplierHelper { get; set; }

        public SequenceGamePlayer(string name) : base(name, null)
        {
            TotalTime = 0;
            GameType = "";
            Level = 0;
            PlayerGender = Gender.Male;

            // Helpers
            showSequenceHelper = 0;
            extraTimeHelper = 0;
            increaseMultiplierHelper = 0;
        }

        public void ResetPlayer()
        {
            TotalTime = 0;
            Level = 1;
            base.ResetScore();
            showSequenceHelper = 0;
            extraTimeHelper = 0;
            increaseMultiplierHelper = 0;
        }

        public void GivePoints(int points)
        {
            Score.Points += points;
        }

        public void ReducePoints(int points)
        {
            if (Score.Points >= points)
            {
                Score.Points -= points;
            }
            else
                throw new NotEnoughScoreException();
        }

        public void addTime(int seconds)
        {
            TotalTime += seconds;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", Name, Score.ToString(), Level.ToString(), gameStarted.ToString("M/d/yyyy"), GameType);
        }

        // Useless

        public override Tuple<string, string> ChoseMove(List<Tuple<string, string>> unpairedOpenPairs, List<string> openedCards, HashSet<string> validPicutreBoxes, Dictionary<string, Card> cardsDictionary, Random rand)
        {
            return null;
        }

        public override bool isBot()
        {
            return false;
        }
    }

}
