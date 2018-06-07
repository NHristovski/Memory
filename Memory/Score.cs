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
        public string Time { get; set; }
        bool Win { get; set; }
        public Score()
        {
            Points = 0;
            Time = "";
        }

        public string getTimeRepresentation()
        {
            //System.Windows.Forms.MessageBox.Show(this.Time + " ");
            return Time;
        }

        public override string ToString()
        {
           return String.Format("{0} {1}",Points, getTimeRepresentation());
        }
    }
}
