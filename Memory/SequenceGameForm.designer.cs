namespace Memory
{
    partial class SequenceGameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SequenceGameForm));
            this.buttonStartSequence = new System.Windows.Forms.Button();
            this.lblRoundTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.lblRound = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlPlayerStats = new System.Windows.Forms.Panel();
            this.pnlPlayerStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStartSequence
            // 
            this.buttonStartSequence.Location = new System.Drawing.Point(122, 131);
            this.buttonStartSequence.Name = "buttonStartSequence";
            this.buttonStartSequence.Size = new System.Drawing.Size(81, 23);
            this.buttonStartSequence.TabIndex = 1;
            this.buttonStartSequence.Text = "Start";
            this.buttonStartSequence.UseVisualStyleBackColor = true;
            this.buttonStartSequence.Click += new System.EventHandler(this.buttonStartSequence_Click);
            // 
            // lblRoundTime
            // 
            this.lblRoundTime.AutoSize = true;
            this.lblRoundTime.BackColor = System.Drawing.Color.Transparent;
            this.lblRoundTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoundTime.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblRoundTime.Location = new System.Drawing.Point(116, 73);
            this.lblRoundTime.Name = "lblRoundTime";
            this.lblRoundTime.Size = new System.Drawing.Size(87, 31);
            this.lblRoundTime.TabIndex = 2;
            this.lblRoundTime.Text = "00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(131, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Points";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(214, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Round";
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.BackColor = System.Drawing.Color.Transparent;
            this.lblPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblPoints.Location = new System.Drawing.Point(150, 38);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(17, 17);
            this.lblPoints.TabIndex = 5;
            this.lblPoints.Text = "0";
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblPlayerName.Location = new System.Drawing.Point(49, 38);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(54, 17);
            this.lblPlayerName.TabIndex = 6;
            this.lblPlayerName.Text = "Player";
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.BackColor = System.Drawing.Color.Transparent;
            this.lblRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRound.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblRound.Location = new System.Drawing.Point(233, 38);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(17, 17);
            this.lblRound.TabIndex = 7;
            this.lblRound.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(49, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Player";
            // 
            // pnlPlayerStats
            // 
            this.pnlPlayerStats.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlPlayerStats.Controls.Add(this.label6);
            this.pnlPlayerStats.Controls.Add(this.buttonStartSequence);
            this.pnlPlayerStats.Controls.Add(this.lblRound);
            this.pnlPlayerStats.Controls.Add(this.lblRoundTime);
            this.pnlPlayerStats.Controls.Add(this.lblPlayerName);
            this.pnlPlayerStats.Controls.Add(this.label1);
            this.pnlPlayerStats.Controls.Add(this.lblPoints);
            this.pnlPlayerStats.Controls.Add(this.label2);
            this.pnlPlayerStats.Location = new System.Drawing.Point(12, 191);
            this.pnlPlayerStats.Name = "pnlPlayerStats";
            this.pnlPlayerStats.Size = new System.Drawing.Size(317, 164);
            this.pnlPlayerStats.TabIndex = 9;
            // 
            // SequenceGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(840, 564);
            this.Controls.Add(this.pnlPlayerStats);
            this.Name = "SequenceGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SequenceGameForm";
            this.Load += new System.EventHandler(this.SequenceGameForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SequenceGameForm_Paint);
            this.pnlPlayerStats.ResumeLayout(false);
            this.pnlPlayerStats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonStartSequence;
        private System.Windows.Forms.Label lblRoundTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlPlayerStats;
    }
}