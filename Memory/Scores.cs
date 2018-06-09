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
        private PlayerDocument playerDocumentForPairGame;
        private List<Player> currentPairGamePlayers;

        private PlayerDocument playerDocumentForSequenceGame;
        //private List<Player> currentSequenceGamePlayers;
        //BIDEJKI NEMA FILTER ZA SEQUENCE GAME NEMA POTREBA OD CURRENT PLAYERS

        private List<Player> currentPlayers; // generic for the sorting ( can be currentPairGamePlayers )
                                             // or playerDocForSeqGame.Players

        private bool pairGameView;

        public Scores()
        {
            InitializeComponent();
            DoubleBuffered = true;
            pairGameView = true;

            currentPairGamePlayers = new List<Player>();
            playerDocumentForPairGame = new PlayerDocument();

            this.getDataAboutPairGame(); // puts data from file into playerDocumentForPairGame

            currentPairGamePlayers.AddRange(playerDocumentForPairGame.Players);
            currentPlayers = currentPairGamePlayers; // the first view when the form is opened is from players from pairGame

            comboBox1_SelectedValueChanged(null, null); // this is just short for sort them by points



            // ZA DARKO
            playerDocumentForSequenceGame = new PlayerDocument();

            //
            // TO DO !!!!!
            //
            this.getDataAboutSequenceGame(); // fill the playerDocumentForSequenceGame
        }

        public void getDataAboutSequenceGame()
        {
            // prvo treba da napravish eden .txt file vo Resources folderot kade
            // ke gi cuvas informaciite za players. Vo toj file zapisuvas koga ke bide 
            // kraj na igrata (end game metodot).
            //     *** Playerot treba da ima DateTime (koga pocnala igrata), score.Points
            //         i string duration ( tajmerot (kolku vreme do zavruvanje na igrata)) za da moze sort da se primeni.
            
            //Vo klasata Paths dodadi static string do toj file.

            // E sega sto treba da pravi ovoj method:
            //  -citanje na site linii od SeqGameScores.txt:
            //      (nesto vaka) string[] scores = File.ReadAllLines(Paths.pathToSeqGameScores);

            // od sekoja linija napravi SeqGamePlayer i dodadi go vo PlayerDocForSeqGame
            //     ( jas gi zapisuvam vo csv format vo fileot i tuka samo pravam
            //       split(',') i gi dobivam delovite. Dzirni podole ako nesto ne e jasno).
            //done


        }

        public void getDataAboutPairGame()
        {
            // Reading the scores from file, 
            //converting them into players (so we can sort them as we like in runtime)
            string[] scores = File.ReadAllLines(Paths.pathToPairGameScores);
            foreach (var str in scores)
            {
                string[] parts = str.Split(new char[] { ',' });
                Player p = PlayerFactory.GetPairGameHumanPlayer(parts[0],parts[5]);
                p.Score.Points = int.Parse(parts[1]);
                p.Score.Time = parts[2];
                p.gameStarted = Convert.ToDateTime(parts[3]);

                playerDocumentForPairGame.addPlayer(p);
            }
            
        }

        //
        // TO DO !!!!!
        //
        private void UpdateGridSequenceGame(List<Player> players)
        {
            DataTable table = new DataTable();

            // za sekoj player gi vadis informaciite dali so geteri ( ili jas
            // mu pravam to string pa slip(' ') i gi dobivam i gi dodavash vo table.

            // Najprvo gi pravis kolonite
            //  -table.Columns.Add("IME_NA_KOLONA", typeof(string)); * typeof moze da bide string,int,double itn zavisi sto ke vrednost ke ima vo taa kolona

            // tuka za sekoj player dodavash row so negovite informacii
            // i na kraj dataGridView1.DataSource = table;



            dataGridView1.DataSource = table;
        }

        private void UpdateGridPairGame(List<Player> players)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Rank", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Score", typeof(string));
            table.Columns.Add("Duration", typeof(string));
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Date", typeof(string));


            int counter = 1;
            foreach (var player in players)
            {
                string[] parts = player.ToString().Split(new char[] { ' ' });
                table.Rows.Add(counter,parts[0], parts[1], parts[2], parts[5], parts[3]);
                counter++;
            }

            dataGridView1.DataSource = table;
        }


        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem.ToString().Equals("Score"))
            {
                currentPlayers = PlayerDocument.sortByPoints(currentPlayers);
            }
            else if (comboBox1.SelectedItem.ToString().Equals("Duration"))
            {
                currentPairGamePlayers = PlayerDocument.sortByTime(currentPlayers);
            }
            else // date
            {
                currentPairGamePlayers = PlayerDocument.sortByDate(currentPlayers);
            }

            if (pairGameView)
            {
                UpdateGridPairGame(currentPairGamePlayers);
            }
            else
            {
                UpdateGridSequenceGame(playerDocumentForSequenceGame.Players);
            }
        }

        private void checkBoxEasy_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxEasy.Checked)
            {
                currentPairGamePlayers.RemoveAll(p => ((PairGamePlayer)p).type.Equals("EasyGame"));
                UpdateGridPairGame(currentPairGamePlayers);
            }
            else
            {
                currentPairGamePlayers.AddRange(playerDocumentForPairGame.Players.Where(p => ((PairGamePlayer)p).type.Equals("EasyGame")).ToList());
                comboBox1_SelectedValueChanged(null, null);
            }
        }

        private void checkBoxNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxNormal.Checked)
            {
                currentPairGamePlayers.RemoveAll(p => ((PairGamePlayer)p).type.Equals("MediumGame"));
                UpdateGridPairGame(currentPairGamePlayers);
            }
            else
            {
                currentPairGamePlayers.AddRange(playerDocumentForPairGame.Players.Where(p => ((PairGamePlayer)p).type.Equals("MediumGame")).ToList());
                comboBox1_SelectedValueChanged(null, null);
            }
        }

        private void checkBoxHard_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxHard.Checked)
            {
                currentPairGamePlayers.RemoveAll(p => ((PairGamePlayer)p).type.Equals("HardGame"));
                UpdateGridPairGame(currentPairGamePlayers);
            }
            else
            {
                currentPairGamePlayers.AddRange(playerDocumentForPairGame.Players.Where(p => ((PairGamePlayer)p).type.Equals("HardGame")).ToList());
                comboBox1_SelectedValueChanged(null, null);
            }
        }

        private void buttonPairGame_Click(object sender, EventArgs e)
        {
            groupBoxFilter.Visible = true;
            pairGameView = true;
            currentPlayers = currentPairGamePlayers;

            comboBox1_SelectedValueChanged(null, null);
            UpdateGridPairGame(currentPlayers);

            
        }

        private void buttonSequenceGame_Click(object sender, EventArgs e)
        {
            groupBoxFilter.Visible = false;
            pairGameView = false;
            currentPlayers = playerDocumentForSequenceGame.Players;

            comboBox1_SelectedValueChanged(null, null);
            UpdateGridSequenceGame(currentPlayers);
        }
    }
}
