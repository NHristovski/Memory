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
        public int Time { get; set; }
        bool Win { get; set; }
        public Score()
        {
            Points = 0;
            Time = 0;
        }

        public string getTimeRepresentation()
        {
            return (Time > 3600) ?
                string.Format("{0:00}:{1:00}:{2:00}", Time / 3600, (Time % 3600) / 60, (Time % 3600) % 60)
                :
                string.Format("{0:00}:{1:00}", Time / 60, Time % 60);
        }

        public override string ToString()
        {
           return String.Format("{0} {1}",Points, getTimeRepresentation());
        }
    }
}
