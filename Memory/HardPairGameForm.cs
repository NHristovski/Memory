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
    public partial class HardPairGameForm : PairGameForm
    {

        List<PictureBox> picBoxes;
        PairGame game;

        public HardPairGameForm(Player Player1, Player Player2)
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
            picBoxes.Add(this.pictureBox17);
            picBoxes.Add(this.pictureBox18);
            picBoxes.Add(this.pictureBox19);
            picBoxes.Add(this.pictureBox20);
            picBoxes.Add(this.pictureBox21);
            picBoxes.Add(this.pictureBox22);
            picBoxes.Add(this.pictureBox23);
            picBoxes.Add(this.pictureBox24);
            picBoxes.Add(this.pictureBox25);
            picBoxes.Add(this.pictureBox26);
            picBoxes.Add(this.pictureBox27);
            picBoxes.Add(this.pictureBox28);
            picBoxes.Add(this.pictureBox29);
            picBoxes.Add(this.pictureBox30);
            picBoxes.Add(this.pictureBox31);
            picBoxes.Add(this.pictureBox32);
            picBoxes.Add(this.pictureBox33);
            picBoxes.Add(this.pictureBox34);
            picBoxes.Add(this.pictureBox35);
            picBoxes.Add(this.pictureBox36);
            picBoxes.Add(this.pictureBox37);
            picBoxes.Add(this.pictureBox38);
            picBoxes.Add(this.pictureBox39);
            picBoxes.Add(this.pictureBox40);

            game = new PairGame(Player1, Player2, picBoxes);
            game.startGame();

            updateLabels();
        }

        private void updateLabels()
        {
            labelCurrentPlayer.Text = game.currentPlayer.Name;
            labelP1points.Text = game.Player1.Score.Points + "";
            labelP2points.Text = game.Player2.Score.Points + "";
        }

        private void validateCard(PictureBox pb)
        {
            updateLabels();
            game.validateCard(pb);
            updateLabels();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox2);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox1);
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

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox22);
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

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox17);
            }
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox18);
            }
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox19);
            }
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox20);
            }
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox21);
            }
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox23);
            }
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox24);
            }
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox25);
            }
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox26);
            }
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox27);
            }
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox28);
            }
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox29);
            }
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox30);
            }
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox31);
            }
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox32);
            }
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox33);
            }
        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox34);
            }
        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox35);
            }
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox36);
            }
        }

        private void pictureBox37_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox37);
            }
        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox38);
            }
        }

        private void pictureBox39_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox39);
            }
        }

        private void pictureBox40_Click(object sender, EventArgs e)
        {
            if (game.ShouldHandle)
            {
                validateCard(pictureBox40);
            }
        }
    }
}
