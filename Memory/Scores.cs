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
        private List<Player> currentPlayers;
        public Scores()
        {
            InitializeComponent();
            DoubleBuffered = true;
            currentPlayers = new List<Player>();
            playerDocument = new PlayerDocument();

            this.getData();
            currentPlayers.AddRange(PlayerDocument.Players);

            comboBox1_SelectedValueChanged(null, null);
        }
        public void getData()
        {
            string[] scores = File.ReadAllLines(Paths.pathToPairGameScores);
            foreach (var str in scores)
            {
                string[] parts = str.Split(new char[] { ',' });
                Player p = PlayerFactory.GetPairGameHumanPlayer(parts[0],parts[5]);
                p.Score.Points = int.Parse(parts[1]);
                p.Score.Time = parts[2];
                p.gameStarted = Convert.ToDateTime(parts[3]);

                playerDocument.addPlayer(p);
            }
            
        }

        private void UpdateGrid(List<Player> players)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Score", typeof(string));
            table.Columns.Add("Duration", typeof(string));
            table.Columns.Add("Date", typeof(string));
            table.Columns.Add("Type", typeof(string));

            int counter = 1;
            foreach (var player in players)
            {
                string[] parts = player.ToString().Split(new char[] { ' ' });
                table.Rows.Add(counter,parts[0], parts[1], parts[2], parts[3], parts[5]);
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
                currentPlayers = playerDocument.sortByPoints(currentPlayers);
            }
            else if (comboBox1.SelectedItem.ToString().Equals("Duration"))
            {
                currentPlayers = playerDocument.sortByTime(currentPlayers);
            }
            else // date
            {
                currentPlayers = playerDocument.sortByDate(currentPlayers);
            }
            UpdateGrid(currentPlayers);
        }

        private void checkBoxEasy_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxEasy.Checked)
            {
                currentPlayers.RemoveAll(p => ((PairGamePlayer)p).type.Equals("EasyGame"));
                UpdateGrid(currentPlayers);
            }
            else
            {
                currentPlayers.AddRange(PlayerDocument.Players.Where(p => ((PairGamePlayer)p).type.Equals("EasyGame")).ToList());
                comboBox1_SelectedValueChanged(null, null);
            }
        }

        private void checkBoxNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxNormal.Checked)
            {
                currentPlayers.RemoveAll(p => ((PairGamePlayer)p).type.Equals("MediumGame"));
                UpdateGrid(currentPlayers);
            }
            else
            {
                currentPlayers.AddRange(PlayerDocument.Players.Where(p => ((PairGamePlayer)p).type.Equals("MediumGame")).ToList());
                comboBox1_SelectedValueChanged(null, null);
            }
        }

        private void checkBoxHard_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxHard.Checked)
            {
                currentPlayers.RemoveAll(p => ((PairGamePlayer)p).type.Equals("HardGame"));
                UpdateGrid(currentPlayers);
            }
            else
            {
                currentPlayers.AddRange(PlayerDocument.Players.Where(p => ((PairGamePlayer)p).type.Equals("HardGame")).ToList());
                comboBox1_SelectedValueChanged(null, null);
            }
        }
    }
}
