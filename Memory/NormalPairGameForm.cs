﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public partial class NormalPairGameForm : PairGameForm
    {
        //PictureBox
        List<string> picBoxes;
        List<PictureBox> realPicBoxes;
        public PairGame game;
        List<cEventSuppressor> suppressors;
        private string FileName;

        public NormalPairGameForm(PairGame game)
        {
            this.game = game;

            foreach (var pBox in picBoxes)
            {
                //if (game.isValid(pBox))
                //{
                //    game.closeCard(pBox);
                //}
                //else
                //{
                // still
                //}

            }

            init();


        }

        public NormalPairGameForm(Player Player1, Player Player2)
        {
            InitializeComponent();

            picBoxes = new List<string>
            {
                this.pictureBox1.Name,
                this.pictureBox2.Name,
                this.pictureBox3.Name,
                this.pictureBox4.Name,
                this.pictureBox5.Name,
                this.pictureBox6.Name,
                this.pictureBox7.Name,
                this.pictureBox8.Name,
                this.pictureBox9.Name,
                this.pictureBox10.Name,
                this.pictureBox11.Name,
                this.pictureBox12.Name,
                this.pictureBox13.Name,
                this.pictureBox14.Name,
                this.pictureBox15.Name,
                this.pictureBox16.Name,
                this.pictureBox17.Name,
                this.pictureBox18.Name,
                this.pictureBox19.Name,
                this.pictureBox20.Name,
                this.pictureBox21.Name,
                this.pictureBox22.Name,
                this.pictureBox23.Name,
                this.pictureBox24.Name,
                this.pictureBox25.Name,
                this.pictureBox26.Name,
            };

            realPicBoxes = new List<PictureBox>
            {
                this.pictureBox1,
                this.pictureBox2,
                this.pictureBox3,
                this.pictureBox4,
                this.pictureBox5,
                this.pictureBox6,
                this.pictureBox7,
                this.pictureBox8,
                this.pictureBox9,
                this.pictureBox10,
                this.pictureBox11,
                this.pictureBox12,
                this.pictureBox13,
                this.pictureBox14,
                this.pictureBox15,
                this.pictureBox16,
                this.pictureBox17,
                this.pictureBox18,
                this.pictureBox19,
                this.pictureBox20,
                this.pictureBox21,
                this.pictureBox22,
                this.pictureBox23,
                this.pictureBox24,
                this.pictureBox25,
                this.pictureBox26,
            };

            int x2Price = 300;
            int secondChancePrice = 450;
            int findNextPrice = 700;
            int openCardsPrice = 1000;

            game = new PairGame(Player1, Player2, realPicBoxes, picBoxes, x2Price, secondChancePrice, findNextPrice, openCardsPrice);

            foreach (var pBox in realPicBoxes)
            {
                game.closeCard(pBox);
            }


            init();

            
        }

        private void init()
        {
            FileName = string.Empty;

            DoubleBuffered = true;

            pictureBox2x.Image = Image.FromFile(Paths.pathTo2xImage);
            pictureBoxSecondChance.Image = Image.FromFile(Paths.pathToSecondChanceImage);
            pictureBoxOpenCards.Image = Image.FromFile(Paths.pathToOpenCardsImage);
            pictureBoxFindNext.Image = Image.FromFile(Paths.pathToFindNextImage);

            int x2Price = 300;
            int secondChancePrice = 450;
            int findNextPrice = 700;
            int openCardsPrice = 1000;

            textBoxPrice2x.Text = x2Price + "";
            textBoxPriceFindNext.Text = findNextPrice + "";
            textBoxPriceOpenCards.Text = openCardsPrice + "";
            textBoxPriceSecondChance.Text = secondChancePrice + "";

            labelP1points.Text = game.Player1.Name + " points:";
            labelP2points.Text = game.Player2.Name + " points:";

            updateLabels();

            suppressors = new List<cEventSuppressor>();

            suppressors.Add(this.pictureBox1.Suppress());
            suppressors.Add(this.pictureBox2.Suppress());
            suppressors.Add(this.pictureBox3.Suppress());
            suppressors.Add(this.pictureBox4.Suppress());
            suppressors.Add(this.pictureBox5.Suppress());
            suppressors.Add(this.pictureBox6.Suppress());
            suppressors.Add(this.pictureBox7.Suppress());
            suppressors.Add(this.pictureBox8.Suppress());
            suppressors.Add(this.pictureBox9.Suppress());
            suppressors.Add(this.pictureBox10.Suppress());
            suppressors.Add(this.pictureBox11.Suppress());
            suppressors.Add(this.pictureBox12.Suppress());
            suppressors.Add(this.pictureBox13.Suppress());
            suppressors.Add(this.pictureBox14.Suppress());
            suppressors.Add(this.pictureBox15.Suppress());
            suppressors.Add(this.pictureBox16.Suppress());
            suppressors.Add(this.pictureBox17.Suppress());
            suppressors.Add(this.pictureBox18.Suppress());
            suppressors.Add(this.pictureBox19.Suppress());
            suppressors.Add(this.pictureBox20.Suppress());
            suppressors.Add(this.pictureBox22.Suppress());
            suppressors.Add(this.pictureBox23.Suppress());
            suppressors.Add(this.pictureBox24.Suppress());
            suppressors.Add(this.pictureBox25.Suppress());
            suppressors.Add(this.pictureBox26.Suppress());

            resumeAllPictureBoxes();

            if (game.Player2.isBot())
            {
                setBotLevelEasyToolStripMenuItem.Enabled = true;
                setBotLevelNormalToolStripMenuItem.Enabled = true;
                setBotLevelHardToolStripMenuItem.Enabled = true;
            }
            else
            {
                setBotLevelEasyToolStripMenuItem.Enabled = false;
                setBotLevelNormalToolStripMenuItem.Enabled = false;
                setBotLevelHardToolStripMenuItem.Enabled = false;
            }

            this.Refresh();
        }

        public override void resolvePicBoxes()
        {
            game.closeValidCards();
            foreach (var pb in realPicBoxes)
            {
                if (!game.isValid(pb))
                {
                    game.makeCardStill(pb);
                }
            }
            this.updateLabels();
            this.Refresh();
        }

        private void resumeAllPictureBoxes()
        {
            foreach (var suppressor in suppressors)
            {
                suppressor.Resume();
            }
        }
        private void suppressAllPictureBoxes()
        {
            foreach (var suppressor in suppressors)
            {
                suppressor.Suppress();
            }
        }

        private void updateLabels()
        {
            textBoxCurrentPlayer.Text = game.GetCurrentPlayerName();
            textBoxP1Points.Text = game.Player1.Score.Points + "";
            textBoxP2Points.Text = game.Player2.Score.Points + "";
            textBoxScoreMultiplier.Text = game.getScoreMultiplier();

            textBoxAvaliable2x.Text = game.getx2Avaliable();
            textBoxAvaliableFindNext.Text = game.getFindNextAvaliable();
            textBoxAvaliableOpenCards.Text = game.getOpenCardsAvaliable();
            textBoxAvalibleSecondChance.Text = game.getSecondChanceAvaliable();

            this.Refresh();
        }

        private void validateCard(PictureBox pb)
        {

            game.validateCard(pb);

            suppressAllPictureBoxes();

            if (game.BotTurn())
            {
                playBotMoves();

            }

            updateLabels();
            this.Refresh();

            if (game.ShouldEnd())
            {
                updateLabels();
                this.Refresh();
                game.endGame();
            }

            resumeAllPictureBoxes();

        }

        private void playBotMoves()
        {
            updateLabels();
            this.Refresh();
            Application.DoEvents();

            if (game.BotMoveSuccsessfull())
            {
                updateLabels();
                this.Refresh();

                if (!game.ShouldEnd())
                {
                    playBotMoves(); // play the next move
                }
            }

            updateLabels();
            this.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox3);           
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox4);          
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox5);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox6);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox7);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox8);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox9);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox10);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox11);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox12);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox13);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox14);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox15);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox16);
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox17);
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox18);
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox19);
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            validateCard(pictureBox20);
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox21);
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox22);
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            validateCard(pictureBox23);
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox24);
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox25);
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
                validateCard(pictureBox26);
        }

        private void pictureBox2x_Click(object sender, EventArgs e)
        {
            try
            {
                game.DoubleMultiplier();
                updateLabels();
            }
            catch (NotEnoughScoreException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (HelperNotAvaliableException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBoxSecondChance_Click(object sender, EventArgs e)
        {
            try
            {
                game.SecondChance();
                updateLabels();
            }
            catch (CardNotOpenedException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (NotEnoughScoreException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (HelperNotAvaliableException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBoxFindNext_Click(object sender, EventArgs e)
        {
            try
            {
                PictureBox pictureBox = game.FindNext(game.getPreviousCard());
                validateCard(pictureBox);
            }
            catch (CardNotOpenedException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (NotEnoughScoreException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (HelperNotAvaliableException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBoxOpenCards_Click(object sender, EventArgs e)
        {
            try
            {
                suppressAllPictureBoxes();

                game.OpenCards();
                game.makeCardsStill();
                Thread.Sleep(2000);
                game.closeValidCards();

                resumeAllPictureBoxes();

            }
            catch (NotEnoughScoreException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (HelperNotAvaliableException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Launcher l = new Launcher();
            l.ShowDialog();
        }

        private void easyGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Player p1 = game.Player1.ResetScore();
            ((PairGamePlayer)p1).setEasyGameAvaliable();

            Player p2 = game.Player2.ResetScore();
            ((PairGamePlayer)p2).setEasyGameAvaliable();

            this.Dispose();
            Launcher.staticRunNewPairGame(new EasyPairGameForm(p1, p2));
        }

        private void normalGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Player p1 = game.Player1.ResetScore();
            ((PairGamePlayer)p1).setNormalGameAvaliable();

            Player p2 = game.Player2.ResetScore();
            ((PairGamePlayer)p2).setNormalGameAvaliable();

            this.Dispose();
            Launcher.staticRunNewPairGame(new NormalPairGameForm(p1, p2));
        }

        private void hardGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Player p1 = game.Player1.ResetScore();
            ((PairGamePlayer)p1).setHardGameAvaliable();

            Player p2 = game.Player2.ResetScore();
            ((PairGamePlayer)p2).setHardGameAvaliable();

            this.Dispose();
            Launcher.staticRunNewPairGame(new HardPairGameForm(p1, p2));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void setBotLevelEasyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int score = game.Player2.Score.Points;
            game.Player2 = PlayerFactory.GetEasyBot();
            game.Player2.Score.Points = score;

            labelP1points.Text = game.Player1.Name + " points:";
            labelP2points.Text = game.Player2.Name + " points:";
            this.Refresh();
        }

        private void setBotLevelNormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int score = game.Player2.Score.Points;
            game.Player2 = PlayerFactory.GetNormalBot();
            game.Player2.Score.Points = score;

            labelP1points.Text = game.Player1.Name + " points:";
            labelP2points.Text = game.Player2.Name + " points:";
            this.Refresh();
        }

        private void setBotLevelHardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int score = game.Player2.Score.Points;
            game.Player2 = PlayerFactory.GetHardBot();
            game.Player2.Score.Points = score;

            labelP1points.Text = game.Player1.Name + " points:";
            labelP2points.Text = game.Player2.Name + " points:";
            this.Refresh();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream fileStream = null;
            try
            {
                if (FileName == string.Empty)
                {
                    var saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Title = "Save your Pair Game";
                    saveFileDialog.Filter = "Normal Pair Game (.normal)|*.normal";

                    var result = saveFileDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        FileName = saveFileDialog.FileName;
                    }
                }
                if (FileName != string.Empty && FileName != null)
                {
                    IFormatter formatter = new BinaryFormatter();
                    fileStream = new FileStream(FileName, FileMode.Create);

                    formatter.Serialize(fileStream, this.game);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Something went wrong! The file is not saved please try again.\nOriginal message: " + exception.Message);
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileName = string.Empty;
            saveToolStripMenuItem_Click(sender, e);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream fileStream = null;
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
                    FileName = openFileDialog.FileName;
                }
                if (FileName != string.Empty && FileName != null)
                {
                    IFormatter formatter = new BinaryFormatter();
                    fileStream = new FileStream(FileName, FileMode.Open);

                    PairGame g = (PairGame)(formatter.Deserialize(fileStream));

                    DialogResult res = MessageBox.Show("Would you like to save this game?", "SaveGame", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        saveToolStripMenuItem_Click(null, null);
                    }

                    if (FileName.EndsWith(".easy"))
                    {
                        this.Dispose();
                        EasyPairGameForm easy = new EasyPairGameForm(g.Player1, g.Player2);
                        easy.game.setInfo(g.getInfo());
                        Launcher.staticRunNewPairGame(easy);

                    }
                    else if (FileName.EndsWith(".normal"))
                    {
                        this.Dispose();
                        var normal = new NormalPairGameForm(g.Player1, g.Player2);
                        normal.game.setInfo(g.getInfo());
                        Launcher.staticRunNewPairGame(normal);
                    }
                    else if (FileName.EndsWith(".hard"))
                    {
                        this.Dispose();
                        var hard = new HardPairGameForm(g.Player1, g.Player2);
                        hard.game.setInfo(g.getInfo());
                        Launcher.staticRunNewPairGame(hard);
                    }
                    else
                    {
                        throw new InvalidDataException("This file can not be opened!");
                    }
                }
            }
            catch(Exception ex)
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

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tuka treba da gi pisuva pravilata na igrata");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helpToolStripMenuItem_Click(sender, e);
        }
    }
}
