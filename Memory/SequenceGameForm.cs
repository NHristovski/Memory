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

        // Moving panels
        private bool helpPanelOpened;
        private bool storePanelOpened;
        private Tuple<Panel, Panel, Boolean> currentMovingPanel;
        // *

        private bool gameStarted;
        private Random rand = new Random();

        public SequenceGameForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            messagesTimer.Interval = 2000;
            helpPanelOpened = false;
            storePanelOpened = false;
            gameStarted = false;

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
            gameStarted = true;
            pbHelp.Enabled = false;
            pbStore.Enabled = false;
            buttonStartSequence.Enabled = false;
            GameController.StartSequencer();
        }

        public void setRoundTimeLabel(string content)
        {
            lblRoundTime.Text = content;
        }

        public void setRoundTimeLabelColor(Color color)
        {
            lblRoundTime.ForeColor = color;
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

            if (((SequenceGamePlayer)GameController.Player1).PlayerGender == Gender.Male)
                pbGender.Image = Properties.Resources.boy;
            else // Female
                pbGender.Image = Properties.Resources.girl;

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
            buttonStartSequence.Enabled = true;
            pbStore.Enabled = true;
            pbHelp.Enabled = true;
            string message = "Dad: " + endOfRoundMessages[rand.Next(endOfRoundMessages.Length)];
            lblMessage.ForeColor = Color.PowderBlue;
            lblMessage.Text = message;
            lblMessage.Left = (this.Width / 2) - (lblMessage.Width / 2);
            messagesTimer.Start();

            lblRoundTime.ForeColor = SystemColors.ButtonFace;
        }

        public void lostGame(string str)
        {
            buttonStartSequence.Enabled = true;
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
            lblRoundTime.ForeColor = SystemColors.ButtonFace;
        }

        public void winGame(string str) // No more rounds
        {
            buttonStartSequence.Enabled = true;
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

            lblRoundTime.ForeColor = SystemColors.ButtonFace;
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

        private void openHelpPanel()
        {

        }

        private void closeHelpPanel()
        {
          
        }

        private void panelMovingTimer_Tick(object sender, EventArgs e)
        {
            Panel firstPanel = currentMovingPanel.Item1;
            Panel secondPanel = currentMovingPanel.Item2;
            bool panelOpened = currentMovingPanel.Item3;

            firstPanel.BringToFront();
            secondPanel.BringToFront();

            if (panelOpened)
            {
                if (firstPanel.Left + 10 > 840)
                {
                    firstPanel.Left = 840;
                    secondPanel.Left = 805;
                    panelMovingTimer.Stop();
                    return;
                }

                firstPanel.Left += 10;
                secondPanel.Left += 10;
            }
            else
            {
                if (firstPanel.Left - 10 < 610)
                {
                    firstPanel.Left = 610;
                    secondPanel.Left = 575;
                    panelMovingTimer.Stop();
                    return;
                }

                firstPanel.Left -= 10;
                secondPanel.Left -= 10;
            }

        }

        private void pbHelp_Click(object sender, EventArgs e)
        {
            //if (storePanelOpened)
            //    pbStore_Click(null, null);

            currentMovingPanel = new Tuple<Panel, Panel, bool>(pnlHelp2, pnlHelp, helpPanelOpened);
            panelMovingTimer.Start();
            helpPanelOpened = !helpPanelOpened;
        }

        private void pbStore_Click(object sender, EventArgs e)
        {
            //if (helpPanelOpened)
            //    pbHelp_Click(null, null);

            lblStoreError.Text = "";
            currentMovingPanel = new Tuple<Panel, Panel, bool>(pnlStore2, pnlStore, storePanelOpened);
            panelMovingTimer.Start();
            storePanelOpened = !storePanelOpened;
        }

        private void btnBuySequence_Click(object sender, EventArgs e)
        {
            lblStoreError.Text = "";
            try
            {
                GameController.buySequenceHelper(int.Parse(tbSequencePrice.Text));
                updateHelperLabels();
            }
            catch (NotEnoughScoreException)
            {
                lblStoreError.Text = String.Format("Error: You need {0}$ to buy sequence \nhelper!", tbSequencePrice.Text);
            }
        }

        private void btnBuyTime_Click(object sender, EventArgs e)
        {
            lblStoreError.Text = "";
            try
            {
                GameController.buyTimeHelper(int.Parse(tbTimePrice.Text));
                updateHelperLabels();
            }
            catch (NotEnoughScoreException)
            {
                lblStoreError.Text = String.Format("Error: You need {0}$ to buy time \nhelper!", tbTimePrice.Text);
            }
        }

        private void btnBuyMultiplier_Click(object sender, EventArgs e)
        {
            lblStoreError.Text = "";
            try
            {
                GameController.buyMultiplierHelper(int.Parse(tbPointsPrice.Text));
                updateHelperLabels();
            }
            catch (NotEnoughScoreException)
            {
                lblStoreError.Text = String.Format("Error: You need {0}$ to buy multiplier \nhelper!", tbPointsPrice.Text);
            }
        }

        private void SequenceGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gameStarted)
                GameController.savePlayer();
        }
    }
}
