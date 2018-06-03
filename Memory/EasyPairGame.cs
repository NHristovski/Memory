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

            game.startGame();

            updateLabels();
        }

        private void updateLabels()
        {
            labelCurrentPlayer.Text = game.currentPlayer.Name;
            labelP1points.Text = game.Player1.Score.Points + "";
            labelP2points.Text = game.Player2.Score.Points + "";

            textBoxAvaliable2x.Text = game.getx2Avaliable();
            textBoxAvaliableFindNext.Text = game.getFindNextAvaliable();
            textBoxAvaliableOpenCards.Text = game.getOpenCardsAvaliable();
            textBoxAvalibleSecondChance.Text = game.getSecondChanceAvaliable();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void validateCard(PictureBox pb)
        {
            updateLabels();
            game.validateCard(pb);
            updateLabels();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox1);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox2);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox3);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox4);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox5);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox6);
            }

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox7);
            }

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox8);
            }

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox9);
            }

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox10);
            }

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox11);
            }

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox12);
            }

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox13);
            }

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox14);
            }

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox15);
            }

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox16);
            }

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
                PictureBox pictureBox = game.FindNext(game.previousCard.Item2);
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
                game.OpenCards();
                updateLabels();
                game.ShouldHandle = false;

                foreach(var pbs in game.validCards)
                {
                    game.makeCardStill(pbs);
                }
                Thread.Sleep(2000);
                foreach (var pbs in game.validCards)
                {
                    game.closeCard(pbs);
                }

                game.ShouldHandle = true;

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
