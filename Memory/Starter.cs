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
    public partial class Starter : Form
    {
        public Starter()
        {
            InitializeComponent();
            this.Icon = new Icon(Paths.pathToMemoryIcon);
            this.MaximizeBox = false;
            pictureBoxPairGame.Image = Image.FromFile(Paths.pathToMediumGamePicture);

        }

        private void pictureBoxPairGame_Click(object sender, EventArgs e)
        {
            Launcher l = new Launcher();
            this.Dispose();
            l.ShowDialog();
        }
        //
        //
        // TO DO
        //
        private void pictureBoxSequenceGameStarter_Click(object sender, EventArgs e)
        {
            //!!!
            // DA SE POSTAVI SLIKA OD SEQ GAME VO CONSTRUCTOROT NA KLASAVA

            SequenceGameForm sequenceGameForm = new SequenceGameForm();
            this.Dispose();
            sequenceGameForm.ShowDialog();
        }
    }
}
