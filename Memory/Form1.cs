﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace Memory
{
    public partial class StarterForm : Form
    {
        //PlayerDoc;
        public StarterForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(System.IO.Directory.GetCurrentDirectory() + @"\ico\favicon.ico");
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            EasyPairGame epg = new EasyPairGame();
            //this.Hide();
            epg.ShowDialog();
            //this.Show();
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
