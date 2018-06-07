﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Memory
{
    [Serializable]
    class PlayerDocument
    {
        public static List<Player> Players = new List<Player>();

        public PlayerDocument()
        {
            Players = new List<Player>();
        }

        public void addPlayer(Player player)
        {
            if (!player.isBot())
            {
                Players.Add(player);
            }
        }

        public void sortByPoints() // If same score -> sort by faster time finished
        {
           Players = Players.OrderByDescending(player => player.Score.Points)
                .ThenBy(player => player.Score.Time).ToList();
        }
        public void sortByTime() // Fastest games to slowest ( Bi trebalo da raboti treba da se istestira ) 
        {
            Players = Players.OrderBy(player => player.Score.Time)
                .ThenByDescending(player => player.Score.Points).ToList(); 
        }
        public void sortByDate()
        {
            Players = Players.OrderBy(player => player.gameStarted)
                .ThenByDescending(player => player.Score.Points).ToList();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("   {0,-20}{1}{2,20}\n\n", "Name", "Score", "Time"));
            int counter = 1;
            foreach (var player in Players)
            {
                stringBuilder.Append(String.Format("#{0,-3}", counter))
                    .Append(player.ToString() + "\n");
                counter++;
                
            }
            return stringBuilder.ToString();
        }
    }
}
