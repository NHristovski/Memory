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
    public partial class EasyPairGameForm : Form
    {
        //readonly string pathToClosedCard = System.IO.Directory.GetCurrentDirectory() + @"\shapes\closedCard.jpg";
        // the closed card is now in resources and we dont need the pathToClosedCard
        
        
        // MORA DA SE REFAKTORIRA, OVA SE TREBA DA E VO KLASATA PAIR GAME!!!!!!!!


        List<PictureBox> picBoxes;
        Game game;
        Player Player1;
        Player Player2;
        Player currentPlayer;
        Tuple<string, PictureBox> previousCard; // shape -> in witch pictureBox was the shape
        HashSet<PictureBox> validCards;
        bool secondCard;

        public EasyPairGameForm()
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

            validCards = new HashSet<PictureBox>(picBoxes);

            Player1 = new HumanPlayer("FirstPlayer");
            Player2 = new HumanPlayer("SecondPlayer");

            currentPlayer = Player1;
            secondCard = false;
            labelCurrentPlayer.Text = currentPlayer.Name;
            labelP1points.Text = Player1.Score.Points + "";
            labelP2points.Text = Player2.Score.Points + "";
        }

        private void EasyPairGame_Load(object sender, EventArgs e)
        {
            game = new PairGame(Player1,Player2, picBoxes);
            game.startGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void animateOpeningCard(PictureBox pb)
        {
            Card card = ((PairGame)game).getCard(pb);
            if (!card.Guessed)
            {
                GifImage gifImage = new GifImage(card.pathToOpenCard);
                for (int i = 0; i < gifImage.frameCount; i++)
                {
                    pb.Enabled = true;
                    pb.Image = gifImage.GetNextFrame();
                    pb.Enabled = false;
                }
            }
        }
        private void animateClosingCard(PictureBox pb)
        {
            GifImage gifImage = new GifImage(((PairGame)game).getCard(pb).pathToCloseCard);
            for (int i = 0; i < gifImage.frameCount; i++)
            {
                pb.Enabled = true;
                pb.Image = gifImage.GetNextFrame();
                pb.Enabled = false;
            }
            closeCard(pb);
        }
        private void closeCard(PictureBox pb)
        {
            //pb.ImageLocation = pathToClosedCard;
            pb.Image = Properties.Resources.closedCard;
            pb.Enabled = true; ;
        }
        private void makeCardStill(PictureBox pb)
        {
            pb.Enabled = true;
            pb.ImageLocation = ((PairGame)game).getCard(pb).pathToStillCard;
            pb.Enabled = false;
        }

        private void changeTurn()
        {
            if (currentPlayer == Player2)
            {
                currentPlayer = Player1;
            }
            else
            {
                currentPlayer = Player2;
            }
        }

        private void validateCard(PictureBox pb)
        {
            Card card = ((PairGame)game).getCard(pb);
            animateOpeningCard(pb);
            if (secondCard)
            {
                foreach (var pBox in validCards)
                {
                    pBox.Enabled = false;
                }
                if (card.Shape.Equals(previousCard.Item1)) // 2 same cards 
                {
                    currentPlayer.Score.Points += 100; // add points to current player;
                    makeCardStill(pb);
                    makeCardStill(previousCard.Item2);
                    validCards.Remove(pb);
                    validCards.Remove(previousCard.Item2);

                }
                else // 2 different cards
                {
                    animateClosingCard(pb);
                    animateClosingCard(previousCard.Item2);
                    changeTurn();
                }
                foreach (var pBox in validCards)
                {
                    pBox.Enabled = true; 
                }
                previousCard = new Tuple<string, PictureBox>(string.Empty, null); // set previous to null
                secondCard = false;
                
            }
            else
            {
                secondCard = true;
                previousCard = new Tuple<string, PictureBox>(card.Shape, pb);
            }
            labelCurrentPlayer.Text = currentPlayer.Name;
            labelP1points.Text = Player1.Score.Points + "";
            labelP2points.Text = Player2.Score.Points + "";

            if (validCards.Count == 0) // every card is guessed
            {
                game.endGame();
            }
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
    }
}
