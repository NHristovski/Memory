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
        public string openFileName;
        public string saveFileName;
        System.Threading.Timer timer;


        public NormalPairGameForm(Player Player1, Player Player2)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

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

            int x2Price = 200;
            int secondChancePrice = 350;
            int findNextPrice = 450;
            int openCardsPrice = 900;

            game = new PairGame(Player1, Player2, realPicBoxes, picBoxes, x2Price, secondChancePrice, findNextPrice, openCardsPrice);

            foreach (var pBox in realPicBoxes)
            {
                game.closeCard(pBox);
            }


            init();

            
        }

        private void tick(Object stateInfo)
        {
            game.Time += 1;
            textBoxTime.Text = game.getTimeRepresentation();
        }

        private void init()
        {

            textBoxTime.Text = game.getTimeRepresentation();

            timer = new System.Threading.Timer(tick, new AutoResetEvent(false), 0, 1000);

            openFileName = string.Empty;
            saveFileName = string.Empty;

            DoubleBuffered = true;

            pictureBox2x.Image = Image.FromFile(Paths.pathTo2xImage);
            pictureBoxSecondChance.Image = Image.FromFile(Paths.pathToSecondChanceImage);
            pictureBoxOpenCards.Image = Image.FromFile(Paths.pathToOpenCardsImage);
            pictureBoxFindNext.Image = Image.FromFile(Paths.pathToFindNextImage);

            int x2Price = 200;
            int secondChancePrice = 300;
            int findNextPrice = 450;
            int openCardsPrice = 900;


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
            if (game.getPreviousCard() != null)
            {
                game.makeCardStill(game.getPreviousCard());
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

                timer.Dispose();

                game.Player1.Score.Time = game.getTimeRepresentation();
                game.Player2.Score.Time = game.getTimeRepresentation();


                var result = game.endGame();

                if (result == DialogResult.Yes)
                {
                    normalGameToolStripMenuItem_Click(null, null);
                }
                else
                {
                    this.Dispose();
                }
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
            ((PairGamePlayer)p1).type = "EasyGame";

            Player p2 = game.Player2.ResetScore();
            ((PairGamePlayer)p2).setEasyGameAvaliable();
            ((PairGamePlayer)p2).type = "EasyGame";

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
            ((PairGamePlayer)p1).type = "HardGame";

            Player p2 = game.Player2.ResetScore();
            ((PairGamePlayer)p2).setHardGameAvaliable();
            ((PairGamePlayer)p2).type = "HardGame";

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
                if (saveFileName == string.Empty)
                {
                    var saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Title = "Save your Pair Game";
                    saveFileDialog.Filter = "Normal Pair Game (.normal)|*.normal";

                    var result = saveFileDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        saveFileName = saveFileDialog.FileName;
                    }
                }
                if (saveFileName != string.Empty && saveFileName != null)
                {
                    IFormatter formatter = new BinaryFormatter();
                    fileStream = new FileStream(saveFileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);

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
            saveFileName = string.Empty;
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
                    openFileName = openFileDialog.FileName;

                    if (openFileName != string.Empty && openFileName != null)
                    {
                        IFormatter formatter = new BinaryFormatter();
                        fileStream = new FileStream(openFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                        PairGame g = (PairGame)(formatter.Deserialize(fileStream));

                        DialogResult res = MessageBox.Show("Would you like to save this game?", "SaveGame", MessageBoxButtons.YesNo);
                        if (res == DialogResult.Yes)
                        {
                            saveToolStripMenuItem_Click(null, null);
                        }

                        if (openFileName.EndsWith(".easy"))
                        {
                            this.Dispose();
                            EasyPairGameForm easy = new EasyPairGameForm(g.Player1, g.Player2);
                            easy.game.setInfo(g.getInfo());
                            easy.game.Time = g.Time;
                            easy.saveFileName = openFileName;
                            Launcher.staticRunNewPairGame(easy);

                        }
                        else if (openFileName.EndsWith(".normal"))
                        {
                            this.Dispose();
                            var normal = new NormalPairGameForm(g.Player1, g.Player2);
                            normal.game.setInfo(g.getInfo());
                            normal.game.Time = g.Time;
                            normal.saveFileName = openFileName;
                            Launcher.staticRunNewPairGame(normal);
                        }
                        else if (openFileName.EndsWith(".hard"))
                        {
                            this.Dispose();
                            var hard = new HardPairGameForm(g.Player1, g.Player2);
                            hard.game.setInfo(g.getInfo());
                            hard.game.Time = g.Time;
                            hard.saveFileName = openFileName;
                            Launcher.staticRunNewPairGame(hard);
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


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tuka treba da gi pisuva pravilata na igrata");
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox4) && pictureBox4 != game.getPreviousCard())
            {
                pictureBox4.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox4) && pictureBox4 != game.getPreviousCard())
            {
                pictureBox4.Image = Paths.closedCard;
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox1) && pictureBox1 != game.getPreviousCard())
            {
                pictureBox1.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox1) && pictureBox1 != game.getPreviousCard())
            {
                pictureBox1.Image = Paths.closedCard;
            }
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox2) && pictureBox2 != game.getPreviousCard())
            {
                pictureBox2.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox2) && pictureBox2 != game.getPreviousCard())
            {
                pictureBox2.Image = Paths.closedCard;
            }
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox3) && pictureBox3 != game.getPreviousCard())
            {
                pictureBox3.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox3) && pictureBox3 != game.getPreviousCard())
            {
                pictureBox3.Image = Paths.closedCard;
            }
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox5) && pictureBox5 != game.getPreviousCard())
            {
                pictureBox5.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox5) && pictureBox5 != game.getPreviousCard())
            {
                pictureBox5.Image = Paths.closedCard;
            }
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox6) && pictureBox6 != game.getPreviousCard())
            {
                pictureBox6.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox6) && pictureBox6 != game.getPreviousCard())
            {
                pictureBox6.Image = Paths.closedCard;
            }
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox7) && pictureBox7 != game.getPreviousCard())
            {
                pictureBox7.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox7) && pictureBox7 != game.getPreviousCard())
            {
                pictureBox7.Image = Paths.closedCard;
            }
        }

        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox8) && pictureBox8 != game.getPreviousCard())
            {
                pictureBox8.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox8) && pictureBox8 != game.getPreviousCard())
            {
                pictureBox8.Image = Paths.closedCard;
            }
        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox9) && pictureBox9 != game.getPreviousCard())
            {
                pictureBox9.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox9) && pictureBox9 != game.getPreviousCard())
            {
                pictureBox9.Image = Paths.closedCard;
            }
        }

        private void pictureBox10_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox10) && pictureBox10 != game.getPreviousCard())
            {
                pictureBox10.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox10) && pictureBox10 != game.getPreviousCard())
            {
                pictureBox10.Image = Paths.closedCard;
            }
        }

        private void pictureBox11_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox11) && pictureBox11 != game.getPreviousCard())
            {
                pictureBox11.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox11) && pictureBox11 != game.getPreviousCard())
            {
                pictureBox11.Image = Paths.closedCard;
            }
        }

        private void pictureBox12_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox12) && pictureBox12 != game.getPreviousCard())
            {
                pictureBox12.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox12_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox12) && pictureBox12 != game.getPreviousCard())
            {
                pictureBox12.Image = Paths.closedCard;
            }
        }

        private void pictureBox13_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox13) && pictureBox13 != game.getPreviousCard())
            {
                pictureBox13.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox13_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox13) && pictureBox13 != game.getPreviousCard())
            {
                pictureBox13.Image = Paths.closedCard;
            }
        }

        private void pictureBox14_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox14) && pictureBox14 != game.getPreviousCard())
            {
                pictureBox14.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox14_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox14) && pictureBox14 != game.getPreviousCard())
            {
                pictureBox14.Image = Paths.closedCard;
            }
        }

        private void pictureBox15_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox15) && pictureBox15 != game.getPreviousCard())
            {
                pictureBox15.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox15_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox15) && pictureBox15 != game.getPreviousCard())
            {
                pictureBox15.Image = Paths.closedCard;
            }
        }

        private void pictureBox16_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox16) && pictureBox16 != game.getPreviousCard())
            {
                pictureBox16.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox16_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox16) && pictureBox16 != game.getPreviousCard())
            {
                pictureBox16.Image = Paths.closedCard;
            }
        }

        private void pictureBox17_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox17) && pictureBox17 != game.getPreviousCard())
            {
                pictureBox17.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox18_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox18) && pictureBox18 != game.getPreviousCard())
            {
                pictureBox18.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox19_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox19) && pictureBox19 != game.getPreviousCard())
            {
                pictureBox19.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox20_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox20) && pictureBox20 != game.getPreviousCard())
            {
                pictureBox20.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox21_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox21) && pictureBox21 != game.getPreviousCard())
            {
                pictureBox21.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox22_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox22) && pictureBox22 != game.getPreviousCard())
            {
                pictureBox22.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox23_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox23) && pictureBox23 != game.getPreviousCard())
            {
                pictureBox23.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox24_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox24) && pictureBox24 != game.getPreviousCard())
            {
                pictureBox24.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox25_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox25) && pictureBox25 != game.getPreviousCard())
            {
                pictureBox25.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox26_MouseEnter(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox26) && pictureBox26 != game.getPreviousCard())
            {
                pictureBox26.Image = Paths.readyToOpenImage;
            }
        }

        private void pictureBox26_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox26) && pictureBox26 != game.getPreviousCard())
            {
                pictureBox26.Image = Paths.closedCard;
            }
        }

        private void pictureBox25_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox25) && pictureBox25 != game.getPreviousCard())
            {
                pictureBox25.Image = Paths.closedCard;
            }
        }

        private void pictureBox24_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox24) && pictureBox24 != game.getPreviousCard())
            {
                pictureBox24.Image = Paths.closedCard;
            }
        }

        private void pictureBox23_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox23) && pictureBox23 != game.getPreviousCard())
            {
                pictureBox23.Image = Paths.closedCard;
            }
        }

        private void pictureBox22_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox22) && pictureBox22 != game.getPreviousCard())
            {
                pictureBox22.Image = Paths.closedCard;
            }
        }

        private void pictureBox21_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox21) && pictureBox21 != game.getPreviousCard())
            {
                pictureBox21.Image = Paths.closedCard;
            }
        }

        private void pictureBox20_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox20) && pictureBox20 != game.getPreviousCard())
            {
                pictureBox20.Image = Paths.closedCard;
            }
        }

        private void pictureBox19_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox19) && pictureBox19 != game.getPreviousCard())
            {
                pictureBox19.Image = Paths.closedCard;
            }
        }

        private void pictureBox18_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox18) && pictureBox18 != game.getPreviousCard())
            {
                pictureBox18.Image = Paths.closedCard;
            }
        }

        private void pictureBox17_MouseLeave(object sender, EventArgs e)
        {
            if (game.isValid(pictureBox17) && pictureBox17 != game.getPreviousCard())
            {
                pictureBox17.Image = Paths.closedCard;
            }
        }
    }
}
