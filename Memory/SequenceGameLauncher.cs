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
    public partial class SequenceGameLauncher : Form
    {
        SequenceGameController GameController;
        SequenceGameForm form;

        public SequenceGameLauncher()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            form = new SequenceGameForm();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Player player;

            if (tbPlayerName.Text.Equals(String.Empty))
            {
                errorProviderName.SetError(tbPlayerName, "Please enter name!");
                return;
            }

            player = PlayerFactory.GetSequenceGamePlayer(tbPlayerName.Text);
            SequenceGameControllerFactory ControllerFactory = new SequenceGameControllerFactory(player, form);

            if (rbEasy.Checked)
            {
                GameController = ControllerFactory.createSequenceGameController(GameModes.Easy);
                ((SequenceGamePlayer)player).GameType = "EasyGame";
            }
            else if (rbMedium.Checked)
            {
                GameController = ControllerFactory.createSequenceGameController(GameModes.Normal);
                ((SequenceGamePlayer)player).GameType = "NormalGame";
            }
            else if (rbHard.Checked)
            {
                GameController = ControllerFactory.createSequenceGameController(GameModes.Hard);
                ((SequenceGamePlayer)player).GameType = "HardGame";
            }

            form.GameController = GameController;
            GameController.InitializeGame();

            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void SequenceGameLauncher_Load(object sender, EventArgs e)
        {

        }
    }
}
