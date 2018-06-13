using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public partial class SequenceGameForm : Form
    {
        public SequenceGameController GameController { get; set; }

        public SequenceGameForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        //private void buttonGenerateStations_Click(object sender, EventArgs e)
        //{
        //    //GameController.InitializeGame();
        //    //Invalidate();
        //}

        private void SequenceGameForm_Paint(object sender, PaintEventArgs e)
        {
            GameController.DrawDockingStations(e.Graphics);
        }

        private void buttonStartSequence_Click(object sender, EventArgs e)
        {
            GameController.StartSequencer();
        }

        public void setRoundTimeLabel(string content)
        {
            lblRoundTime.Text = content;
        }

        public void setRoundLabel(int round)
        {
            lblRound.Text = round.ToString();
        }

        public void setPointsLabel(int points)
        {
            lblPoints.Text = points.ToString();
        }

        private void SequenceGameForm_Load(object sender, EventArgs e)
        {
            //GameController.InitializeGame();
            lblPlayerName.Text = GameController.Player1.Name;
            pnlPlayerStats.Top = GameController.calculatePanelsPosition(pnlPlayerStats.Height);
            Invalidate();
        }
    }
}
