using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public partial class EasyPairGameForm : PairGameForm
    { 
        List<PictureBox> picBoxes;
        PairGame game;
        List<cEventSuppressor> suppressors;

        public EasyPairGameForm(Player Player1,Player Player2)
        {
            InitializeComponent();

            picBoxes = new List<PictureBox>();
            
            picBoxes.Add(this.pictureBox1);
            picBoxes.Add(this.pictureBox2);
            picBoxes.Add(this.pictureBox3);
            picBoxes.Add(this.pictureBox4);
            picBoxes.Add(this.pictureBox5);
            picBoxes.Add(this.pictureBox6);
            picBoxes.Add(this.pictureBox7);
            picBoxes.Add(this.pictureBox8);
            picBoxes.Add(this.pictureBox9);
            picBoxes.Add(this.pictureBox10);
            picBoxes.Add(this.pictureBox11);
            picBoxes.Add(this.pictureBox12);
            picBoxes.Add(this.pictureBox13);
            picBoxes.Add(this.pictureBox14);
            picBoxes.Add(this.pictureBox15);
            picBoxes.Add(this.pictureBox16);


            int x2Price = 250;
            int secondChancePrice = 350;
            int findNextPrice = 500;
            int openCardsPrice = 700;

            game = new PairGame(Player1,Player2, picBoxes,x2Price,secondChancePrice,findNextPrice,openCardsPrice);

            foreach (var pBox in picBoxes)
            {
                game.closeCard(pBox);
            }

            pictureBox2x.Image = Image.FromFile(Paths.pathTo2xImage);
            pictureBoxSecondChance.Image = Image.FromFile(Paths.pathToSecondChanceImage);
            pictureBoxOpenCards.Image = Image.FromFile(Paths.pathToOpenCardsImage);
            pictureBoxFindNext.Image = Image.FromFile(Paths.pathToFindNextImage);

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

            resumeAllPictureBoxes();

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
                PictureBox pictureBox = game.FindNext(game.PreviousCard);
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
    }
}
