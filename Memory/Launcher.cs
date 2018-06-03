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
    public partial class Launcher : Form
    {

        // !!!!!!!!!!!!!!! SHOULD THEY BE HERE OR IN THE START BUTTON METHOD?
        private Player Player1;
        private Player Player2;

        PairGameForm form;
        public Launcher()
        {
            InitializeComponent();
            form = null;
            Player1 = null;
            Player2 = null;
            changeVisibility();
        }

        private void changeVisibility()
        {
            textBoxPlayer2Name.Visible = radioButtonHuman.Checked;
            labelPlayer2Name.Visible = radioButtonHuman.Checked;
            groupBoxBotLevel.Visible = radioButtonBot.Checked;
        }

        private void radioButtonBot_CheckedChanged(object sender, EventArgs e)
        {
            changeVisibility();
        }

        private void radioButtonHuman_CheckedChanged(object sender, EventArgs e)
        {
            changeVisibility();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (textBoxPlayer1Name.Text.Equals(String.Empty)
                ||
                (radioButtonHuman.Checked && textBoxPlayer2Name.Text.Equals(String.Empty)))
            {
                MessageBox.Show("Please enter the name of the players!");
                return;
            }

            Player1 = PlayerFactory.GetPairGameHumanPlayer(textBoxPlayer1Name.Text);
            

            if (radioButtonBot.Checked)
            {
                if (radioButtonBotEasy.Checked)
                {
                    Player2 = PlayerFactory.GetEasyBot();
                }
                else if (radioButtonBotMedium.Checked)
                {
                    Player2 = PlayerFactory.GetNormalBot();
                }
                else
                {
                    Player2 = PlayerFactory.GetHardBot();
                }
            }
            else
            {
                Player2 = PlayerFactory.GetPairGameHumanPlayer(textBoxPlayer2Name.Text);
            }

            if (radioButtonEasy.Checked)
            {
                ((PairGamePlayer)Player1).setEasyGameAvaliable();
                ((PairGamePlayer)Player2).setEasyGameAvaliable();
                
                form = new EasyPairGameForm(Player1, Player2);
            }
            else if (radioButtonMedium.Checked)
            {
                ((PairGamePlayer)Player1).setNormalGameAvaliable();
                ((PairGamePlayer)Player2).setNormalGameAvaliable();

                form = new NormalPairGameForm(Player1,Player2);
            }
            else// hard
            {
                ((PairGamePlayer)Player1).setHardGameAvaliable();
                ((PairGamePlayer)Player2).setHardGameAvaliable();

                form = new HardPairGameForm(Player1, Player2);
            }


            form.ShowDialog();
            this.Hide();

        }

        private void textBoxPlayer1Name_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxPlayer1Name.Text.Equals(String.Empty))
            {
                errorProviderP1Name.SetError(textBoxPlayer1Name, "Please enter name!");
            }
            else
            {
                errorProviderP1Name.SetError(textBoxPlayer1Name, null);
            }
        }

        private void textBoxPlayer2Name_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxPlayer2Name.Text.Equals(String.Empty))
            {
                errorProviderP2Name.SetError(textBoxPlayer2Name, "Please enter name!");
            }
            else
            {
                errorProviderP2Name.SetError(textBoxPlayer2Name, null);
            }
        }
    }
}
