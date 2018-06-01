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


            game = new PairGame(Player1,Player2, picBoxes,
               labelCurrentPlayer, labelP1points, labelP2points);

            game.startGame();
            game.updateLabels();
        }

        /*private void EasyPairGame_Load(object sender, EventArgs e)
        {   // NEEDS CHANGE: PLAYERS
           
            // just for checking
   
            //labelCurrentPlayer.Text = game.currentPlayer.Name;
            //labelP1points.Text = game.Player1.Score.Points + "";
            //labelP2points.Text = game.Player2.Score.Points + "";
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void validateCard(PictureBox pb)
        {
            game.validateCard(pb);

            //just for checking
            //labelCurrentPlayer.Text = game.currentPlayer.Name;
            //labelP1points.Text = game.Player1.Score.Points + "";
            //labelP2points.Text = game.Player2.Score.Points + "";
            
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
