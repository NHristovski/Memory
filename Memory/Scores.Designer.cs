namespace Memory
{
    partial class Scores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonPairGame = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonSequenceGame = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxEasy = new System.Windows.Forms.CheckBox();
            this.checkBoxHard = new System.Windows.Forms.CheckBox();
            this.checkBoxNormal = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPairGame
            // 
            this.buttonPairGame.Location = new System.Drawing.Point(13, 5);
            this.buttonPairGame.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPairGame.Name = "buttonPairGame";
            this.buttonPairGame.Size = new System.Drawing.Size(114, 37);
            this.buttonPairGame.TabIndex = 2;
            this.buttonPairGame.Text = "Pair Game";
            this.buttonPairGame.UseVisualStyleBackColor = true;
            this.buttonPairGame.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 37);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1016, 323);
            this.dataGridView1.TabIndex = 1;
            // 
            // buttonSequenceGame
            // 
            this.buttonSequenceGame.Location = new System.Drawing.Point(125, 5);
            this.buttonSequenceGame.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSequenceGame.Name = "buttonSequenceGame";
            this.buttonSequenceGame.Size = new System.Drawing.Size(171, 37);
            this.buttonSequenceGame.TabIndex = 3;
            this.buttonSequenceGame.Text = "Sequence Game";
            this.buttonSequenceGame.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Score",
            "Duration",
            "Date"});
            this.comboBox1.Location = new System.Drawing.Point(721, 368);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "Score";
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(653, 371);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sort by";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxHard);
            this.groupBox1.Controls.Add(this.checkBoxEasy);
            this.groupBox1.Controls.Add(this.checkBoxNormal);
            this.groupBox1.Location = new System.Drawing.Point(13, 368);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // checkBoxEasy
            // 
            this.checkBoxEasy.AutoSize = true;
            this.checkBoxEasy.Checked = true;
            this.checkBoxEasy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEasy.Location = new System.Drawing.Point(1, 40);
            this.checkBoxEasy.Name = "checkBoxEasy";
            this.checkBoxEasy.Size = new System.Drawing.Size(113, 24);
            this.checkBoxEasy.TabIndex = 0;
            this.checkBoxEasy.Text = "EasyGame";
            this.checkBoxEasy.UseVisualStyleBackColor = true;
            this.checkBoxEasy.CheckedChanged += new System.EventHandler(this.checkBoxEasy_CheckedChanged);
            // 
            // checkBoxHard
            // 
            this.checkBoxHard.AutoSize = true;
            this.checkBoxHard.Checked = true;
            this.checkBoxHard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHard.Location = new System.Drawing.Point(317, 40);
            this.checkBoxHard.Name = "checkBoxHard";
            this.checkBoxHard.Size = new System.Drawing.Size(113, 24);
            this.checkBoxHard.TabIndex = 1;
            this.checkBoxHard.Text = "HardGame";
            this.checkBoxHard.UseVisualStyleBackColor = true;
            this.checkBoxHard.CheckedChanged += new System.EventHandler(this.checkBoxHard_CheckedChanged);
            // 
            // checkBoxNormal
            // 
            this.checkBoxNormal.AutoSize = true;
            this.checkBoxNormal.Checked = true;
            this.checkBoxNormal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNormal.Location = new System.Drawing.Point(148, 40);
            this.checkBoxNormal.Name = "checkBoxNormal";
            this.checkBoxNormal.Size = new System.Drawing.Size(135, 24);
            this.checkBoxNormal.TabIndex = 2;
            this.checkBoxNormal.Text = "MediumGame";
            this.checkBoxNormal.UseVisualStyleBackColor = true;
            this.checkBoxNormal.CheckedChanged += new System.EventHandler(this.checkBoxNormal_CheckedChanged);
            // 
            // Scores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 473);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonSequenceGame);
            this.Controls.Add(this.buttonPairGame);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Scores";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonPairGame;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonSequenceGame;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxHard;
        private System.Windows.Forms.CheckBox checkBoxEasy;
        private System.Windows.Forms.CheckBox checkBoxNormal;
    }
}