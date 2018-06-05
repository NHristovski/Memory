using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Memory
{
    [Serializable]
    public class Score
    {
        public int Points { get; set; }
        public TimeSpan Time { get; set; }
        bool Win { get; set; }
        public Score()
        {
            Points = 0;
            Time = TimeSpan.Zero;
        }

        public override string ToString()
        {
           return String.Format("{0,-5}{1,20}{2,10}",Points, Time.ToString(@"hh\:mm\:ss"),Win ? "WIN" : "LOSE");
        }
    }
}
