using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public partial class Scores : Form
    {
        public Scores()
        {
            InitializeComponent();
            DoubleBuffered = true;
            button1_Click(null, null);
        }
        public string[] getData()
        {
            string[] scores = File.ReadAllLines(Paths.pathToPairGameScores);
            return scores;
        }

        private DataTable makeDataTable(string[] lines)
        {
            DataTable table = new DataTable();

            DataColumn IdColumn = new DataColumn("Id", typeof(string));
            table.Columns.Add(IdColumn);
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Score", typeof(string));
            table.Columns.Add("Duration", typeof(string));
            table.Columns.Add("Date", typeof(string));

            int counter = 1;
            foreach (var line in lines)
            {
                string[] parts = line.Split(new char[] { ',' });
                table.Rows.Add(counter,parts[0], parts[1], parts[2], parts[3]);
                counter++;
            }

            return table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = makeDataTable(getData());
        }
    }
}
