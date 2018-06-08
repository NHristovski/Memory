﻿using System;
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
    public partial class SequenceGameForm : Form
    {
        public SequenceGameController GameController { get; set; }

        public SequenceGameForm()
        {
            InitializeComponent();
            SequenceGameControllerFactory factory = new SequenceGameControllerFactory(null, this);
            GameController = factory.createSequenceGameController(GameModes.Easy);
        }

        private void buttonGenerateStations_Click(object sender, EventArgs e)
        {
            GameController.InitializeGame();
            Invalidate();
        }

        private void SequenceGameForm_Paint(object sender, PaintEventArgs e)
        {
            GameController.DrawDockingStations(e.Graphics);
        }

        private void buttonStartSequence_Click(object sender, EventArgs e)
        {
            GameController.StartSequencer();
        }

        public void setRoundTimeLabel(string content)
        {
            lblRoundTime.Text = content;
        }
    }
}