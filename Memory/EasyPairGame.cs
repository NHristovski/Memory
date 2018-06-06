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
    public partial class EasyPairGameForm : PairGameForm
    { 
        //PictureBox
        List<string> picBoxes;
        List<PictureBox> realPicBoxes;
        public PairGame game;
        List<cEventSuppressor> suppressors;
        private string FileName;
        System.Windows.Forms.Timer timer;

        public EasyPairGameForm(Player Player1,Player Player2)
        {
            InitializeComponent();

            FileName = string.Empty;

            DoubleBuffered = true;

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
                this.pictureBox16.Name
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
                this.pictureBox16
            };

            int x2Price = 250;
            int secondChancePrice = 350;
            int findNextPrice = 500;
            int openCardsPrice = 700;

            game = new PairGame(Player1,Player2,realPicBoxes, picBoxes,x2Price,secondChancePrice,findNextPrice,openCardsPrice);

            foreach (var pBox in realPicBoxes)
            {
                game.closeCard(pBox);
            }

            init();

        }

        public override void resolvePicBoxes()
        {
            game.closeValidCards();
            foreach(var pb in realPicBoxes)
            {
                if (!game.isValid(pb))
                {
                    game.makeCardStill(pb);
                }
            }
            this.updateLabels();
            this.Refresh();
        }

        private void tick(object sender, EventArgs e)
        {
            game.Time += 1;
            textBoxTime.Text = game.getTimeRepresentation();
        }
        private void init()
        {

            textBoxTime.Text = game.getTimeRepresentation();

            timer = new System.Windows.Forms.Timer
            {
                Enabled = true,
                Interval = 1000,
            };
            timer.Tick += new EventHandler(tick);
            timer.Start();

            FileName = string.Empty;

            DoubleBuffered = true;

            pictureBox2x.Image = Image.FromFile(Paths.pathTo2xImage);
            pictureBoxSecondChance.Image = Image.FromFile(Paths.pathToSecondChanceImage);
            pictureBoxOpenCards.Image = Image.FromFile(Paths.pathToOpenCardsImage);
            pictureBoxFindNext.Image = Image.FromFile(Paths.pathToFindNextImage);

            int x2Price = 250;
            int secondChancePrice = 350;
            int findNextPrice = 500;
            int openCardsPrice = 700;

            textBoxPrice2x.Text = x2Price + "";
            textBoxPriceFindNext.Text = findNextPrice + "";
            textBoxPriceOpenCards.Text = openCardsPrice + "";
            textBoxPriceSecondChance.Text = secondChancePrice + "";

            labelP1points.Text = game.Player1.Name + " points:";
            labelP2points.Text = game.Player2.Name + " points:";

            updateLabels();

            suppressors = new List<cEventSuppressor>
            {
                this.pictureBox1.Suppress(),
                this.pictureBox2.Suppress(),
                this.pictureBox3.Suppress(),
                this.pictureBox4.Suppress(),
                this.pictureBox5.Suppress(),
                this.pictureBox6.Suppress(),
                this.pictureBox7.Suppress(),
                this.pictureBox8.Suppress(),
                this.pictureBox9.Suppress(),
                this.pictureBox10.Suppress(),
                this.pictureBox11.Suppress(),
                this.pictureBox12.Suppress(),
                this.pictureBox13.Suppress(),
                this.pictureBox14.Suppress(),
                this.pictureBox15.Suppress(),
                this.pictureBox16.Suppress()
            };

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

            updateLabels();
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
        
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

                timer.Stop();

                var result = game.endGame();

                if (result == DialogResult.Yes)
                {
                    this.Dispose();
                    Launcher l = new Launcher();
                    l.ShowDialog();
                }

                this.Dispose();

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
            catch(HelperNotAvaliableException ex)
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
            catch(CardNotOpenedException ex)
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
                    saveFileDialog.Filter = "Easy Pair Game (.easy)|*.easy";

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
                    //Filter = "Easy Pair Game (.easy)|*.easy|Normal Pair Game (.normal)|*.normal|Hard Pair Game (.hard)|*.hard"
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
                        easy.game.Time = g.Time;
                        Launcher.staticRunNewPairGame(easy);

                    }
                    else if (FileName.EndsWith(".normal"))
                    {
                        this.Dispose();
                        var normal = new NormalPairGameForm(g.Player1, g.Player2);
                        normal.game.setInfo(g.getInfo());
                        normal.game.Time = g.Time;
                        Launcher.staticRunNewPairGame(normal);
                    }
                    else if (FileName.EndsWith(".hard"))
                    {
                        this.Dispose();
                        var hard = new HardPairGameForm(g.Player1, g.Player2);
                        hard.game.setInfo(g.getInfo());
                        hard.game.Time = g.Time;
                        Launcher.staticRunNewPairGame(hard);
                    }
                    else
                    {
                        throw new InvalidDataException("This file can not be opened!");
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

    }
}
