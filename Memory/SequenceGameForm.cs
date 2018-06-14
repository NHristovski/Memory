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
        private string[] endOfRoundMessages;
        private string[] lostGameMessages;

        private Random rand = new Random();

        public SequenceGameForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            messagesTimer.Interval = 2000;

            endOfRoundMessages = new string[] {
                "Nice job son !!",
                "Good round son !!",
                "You are killing it son !!",
                "That was close !!"
            };

            lostGameMessages = new string[]
            {
                "You have 4 missed calls from Dad",
                "Game Over",
                "Well, better luck next time",
                "Dad: Your grandma plays better than you",
                "You ran out of time"
            };
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

        public void updateHelperLabels()
        {
            SequenceGamePlayer player = (SequenceGamePlayer)GameController.Player1;
            lblIncreaseMultiplier.Text = player.increaseMultiplierHelper.ToString();
            lblExtraTime.Text = player.extraTimeHelper.ToString();
            lblShowSequence.Text = player.showSequenceHelper.ToString();
        }

        private void SequenceGameForm_Load(object sender, EventArgs e)
        {
            //GameController.InitializeGame();
            lblPlayerName.Text = GameController.Player1.Name;
            updateHelperLabels();
            pnlPlayerStats.Top = GameController.calculatePanelsPosition(pnlPlayerStats.Height);
            pnlHelpers.Top = GameController.calculatePanelsPosition(pnlHelpers.Height);
            Invalidate();
        }

        public void resetGame()
        {
            SequenceGameControllerFactory f = new SequenceGameControllerFactory(GameController.Player1, this);
            GameController = f.createSequenceGameController(GameController.gameMode);
            GameController.InitializeGame();
        }

        public void endOfRound()
        {
            string message = "Dad: " + endOfRoundMessages[rand.Next(endOfRoundMessages.Length)];
            lblMessage.ForeColor = Color.PowderBlue;
            lblMessage.Text = message;
            lblMessage.Left = (this.Width / 2) - (lblMessage.Width / 2);
            messagesTimer.Start();
        }

        public void lostGame(string str)
        {
            GameController.savePlayer();
            string message = lostGameMessages[rand.Next(endOfRoundMessages.Length)];
            lblMessage.ForeColor = Color.Gold;
            lblMessage.Text = message;
            lblMessage.Left = (this.Width / 2) - (lblMessage.Width / 2);
            messagesTimer.Start();
            DialogResult result = MessageBox.Show(str, "Game status", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                GameController.resetGame();
            else
                this.Close();
        }

        public void winGame(string str) // No more rounds
        {
            GameController.savePlayer();
            lblMessage.ForeColor = Color.PowderBlue;
            messagesTimer.Interval = 5000;
            lblMessage.Text = "Dad: You have done very good job, I am proud of you son !!";
            lblMessage.Left = (this.Width / 2) - (lblMessage.Width / 2);
            messagesTimer.Start();
            messagesTimer.Interval = 2000;
            DialogResult result = MessageBox.Show(str, "Game status", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                GameController.resetGame();
            else
                this.Close();
        }

        private void messagesTimer_Tick(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            messagesTimer.Stop();
        }

        private void btnUseShowSequence_Click(object sender, EventArgs e)
        {
            GameController.useShowSequence();
            updateHelperLabels();
        }

        private void btnUseExtraTime_Click(object sender, EventArgs e)
        {
            GameController.useExtraTime();
            updateHelperLabels();
        }

        private void btnUseMultiplier_Click(object sender, EventArgs e)
        {
            GameController.useIncreaseMultiplier();
            updateHelperLabels();
        }
    }
}
