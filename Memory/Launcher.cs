using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public partial class Launcher : Form
    {


        PairGameForm form;

        public Launcher()
        {

            InitializeComponent();
            form = null;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

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

        private bool InvalidP1Name()
        {
            if (textBoxPlayer1Name.Text.Equals(String.Empty))
            {
                errorProviderP1Name.SetError(textBoxPlayer1Name, "Please enter name!");
                return true;
            }
            else if (textBoxPlayer1Name.Text.Contains(" "))
            {
                errorProviderP1Name.SetError(textBoxPlayer1Name, "The name can not have \" \" (empty space)!");
                return true;
            }
            else if (textBoxPlayer1Name.Text.Contains(","))
            {
                errorProviderP1Name.SetError(textBoxPlayer1Name, "The name can not have \",\" (comma)!");
                return true;
            }
            return false;
        }
        private bool InvalidP2Name()
        {
            if (radioButtonHuman.Checked && textBoxPlayer2Name.Text.Equals(String.Empty))
            {
                errorProviderP2Name.SetError(textBoxPlayer2Name, "Please enter name!");
                return true;
            }
            else if (radioButtonHuman.Checked && textBoxPlayer2Name.Text.Contains(" "))
            {
                errorProviderP2Name.SetError(textBoxPlayer2Name, "The name can not have \" \" (empty space)!");
                return true;
            }
            else if (radioButtonHuman.Checked && textBoxPlayer2Name.Text.Contains(","))
            {
                errorProviderP2Name.SetError(textBoxPlayer2Name, "The name can not have \",\" (comma)!");
                return true;
            }
            return false;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {


            Player Player1;
            Player Player2;

            var invalidP1Name = InvalidP1Name();
            var invalidP2Name = InvalidP2Name();

            if (invalidP1Name || invalidP2Name)
            {
                MessageBox.Show("Please enter the valid names for the players!");
                return;
            }
            

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
                Player2 = PlayerFactory.GetPairGameHumanPlayer(textBoxPlayer2Name.Text,"placeHolder");
            }

            if (radioButtonEasy.Checked)
            {
                Player1 = PlayerFactory.GetPairGameHumanPlayer(textBoxPlayer1Name.Text,"EasyGame");
                ((PairGamePlayer)Player2).type = "EasyGame";
                ((PairGamePlayer)Player1).setEasyGameAvaliable();
                ((PairGamePlayer)Player2).setEasyGameAvaliable();
                
                form = new EasyPairGameForm(Player1, Player2);
            }
            else if (radioButtonMedium.Checked)
            {
                Player1 = PlayerFactory.GetPairGameHumanPlayer(textBoxPlayer1Name.Text, "MediumGame");
                ((PairGamePlayer)Player2).type = "MediumGame";
                ((PairGamePlayer)Player1).setNormalGameAvaliable();
                ((PairGamePlayer)Player2).setNormalGameAvaliable();

                form = new NormalPairGameForm(Player1,Player2);
            }
            else// hard
            {
                Player1 = PlayerFactory.GetPairGameHumanPlayer(textBoxPlayer1Name.Text, "HardGame");
                ((PairGamePlayer)Player2).type = "HardGame";
                ((PairGamePlayer)Player1).setHardGameAvaliable();
                ((PairGamePlayer)Player2).setHardGameAvaliable();

                form = new HardPairGameForm(Player1, Player2);
            }

            runNewPairGame(form);

        }

        public static void staticRunNewPairGame(PairGameForm f)
        {
            f.resolvePicBoxes();
            f.ShowDialog();
        }

        private void runNewPairGame(PairGameForm f)
        {
            this.Dispose();
            f.ShowDialog();
        }
        
        private void textBoxPlayer1Name_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxPlayer1Name.Text.Equals(String.Empty))
            {
                errorProviderP1Name.SetError(textBoxPlayer1Name, "Please enter name!");
            }
            else if (textBoxPlayer1Name.Text.Contains(" "))
            {
                errorProviderP1Name.SetError(textBoxPlayer1Name, "The name can not have \" \" (empty space)!");
            }
            else if (textBoxPlayer1Name.Text.Contains(","))
            {
                errorProviderP1Name.SetError(textBoxPlayer1Name, "The name can not have \",\" (comma)!");
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
            else if (textBoxPlayer2Name.Text.Contains(" "))
            {
                errorProviderP2Name.SetError(textBoxPlayer2Name, "The name can not have \" \" (empty space)!");
            }
            else if (textBoxPlayer2Name.Text.Contains(","))
            {
                errorProviderP2Name.SetError(textBoxPlayer2Name, "The name can not have \",\" (comma)!");
            }
            else
            {
                errorProviderP2Name.SetError(textBoxPlayer2Name, null);
            }
        }

        private void textBoxPlayer1Name_TextChanged(object sender, EventArgs e)
        {
            errorProviderP1Name.SetError(textBoxPlayer1Name, null);
        }

        private void textBoxPlayer2Name_TextChanged(object sender, EventArgs e)
        {
            errorProviderP2Name.SetError(textBoxPlayer2Name, null);
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            FileStream fileStream = null;
            string openFileName = string.Empty;
            try
            {
                var openFileDialog = new OpenFileDialog
                {
                    Title = "Open Pair Game",
                    Filter = "Easy Pair Game (.easy)|*.easy|Normal Pair Game (.normal)|*.normal|Hard Pair Game (.hard)|*.hard"
                };

                var result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    openFileName = openFileDialog.FileName;

                    if (openFileName != string.Empty && openFileName != null)
                    {
                        IFormatter formatter = new BinaryFormatter();
                        fileStream = new FileStream(openFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                        PairGame g = (PairGame)(formatter.Deserialize(fileStream));

                        if (openFileName.EndsWith(".easy"))
                        {
                            this.Dispose();
                            EasyPairGameForm easy = new EasyPairGameForm(g.Player1, g.Player2);
                            easy.game.setInfo(g.getInfo());
                            easy.game.Time = g.Time;
                            easy.saveFileName = openFileName;
                            staticRunNewPairGame(easy);

                        }
                        else if (openFileName.EndsWith(".normal"))
                        {
                            this.Dispose();
                            var normal = new NormalPairGameForm(g.Player1, g.Player2);
                            normal.game.setInfo(g.getInfo());
                            normal.game.Time = g.Time;
                            normal.saveFileName = openFileName;
                            staticRunNewPairGame(normal);
                        }
                        else if (openFileName.EndsWith(".hard"))
                        {
                            this.Dispose();
                            var hard = new HardPairGameForm(g.Player1, g.Player2);
                            hard.game.setInfo(g.getInfo());
                            hard.game.Time = g.Time;
                            hard.saveFileName = openFileName;
                            staticRunNewPairGame(hard);
                        }
                        else
                        {
                            throw new InvalidDataException("This file can not be opened!");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem opening this file!\nOriginal message: " + ex.Message);
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }

        private void groupBoxBotLevel_Enter(object sender, EventArgs e){}
    }
}
