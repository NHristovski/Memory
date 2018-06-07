using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public partial class Scores : Form
    {
        private PlayerDocument playerDocument;

        public Scores()
        {
            InitializeComponent();
            DoubleBuffered = true;

            playerDocument = new PlayerDocument();

            this.getData();
            UpdateGrid();
        }
        public void getData()
        {
            string[] scores = File.ReadAllLines(Paths.pathToPairGameScores);
            foreach (var str in scores)
            {
                string[] parts = str.Split(new char[] { ',' });
                Player p = PlayerFactory.GetPairGameHumanPlayer(parts[0]);
                p.Score.Points = int.Parse(parts[1]);
                string time = parts[3];
                string[] partsTime = time.Split(new char[] { ':' });

                int mult = 1;
                int t = 0;
                for (int i = partsTime.Length -1; i >= 0; i--)
                {
                    t += mult * int.Parse(partsTime[i]);
                    mult *= 60;
                }
                p.Score.Time = t;

                p.gameStarted = DateTime.Now; // CHANGE
                playerDocument.addPlayer(p);
            }
            playerDocument.sortByPoints();
            
        }

        private void UpdateGrid()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Score", typeof(string));
            table.Columns.Add("Duration", typeof(string));
            table.Columns.Add("Date", typeof(string));

            int counter = 1;
            foreach (var player in PlayerDocument.Players)
            {
                string[] parts = player.ToString().Split(new char[] { ' ' });
                table.Rows.Add(counter,parts[0], parts[1], parts[2], parts[3]);
                counter++;
            }

            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

            
            if (comboBox1.SelectedItem.ToString().Equals("Score"))
            {
                MessageBox.Show("Score");
                playerDocument.sortByPoints();
            }
            else if (comboBox1.SelectedItem.ToString().Equals("Duration"))
            {
                MessageBox.Show("Duration");
                playerDocument.sortByTime();
            }
            else // date
            {
                MessageBox.Show("Date");
                playerDocument.sortByDate();
            }
            UpdateGrid();
        }
    }
}
