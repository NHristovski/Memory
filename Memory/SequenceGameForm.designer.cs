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
            this.buttonStartSequence = new System.Windows.Forms.Button();
            this.lblRoundTime = new System.Windows.Forms.Label();
            this.pnlPlayerStats = new System.Windows.Forms.Panel();
            this.lblRound = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.pnlPlayerStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStartSequence
            // 
            this.buttonStartSequence.Location = new System.Drawing.Point(105, 134);
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
            this.lblRoundTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoundTime.Location = new System.Drawing.Point(106, 85);
            this.lblRoundTime.Name = "lblRoundTime";
            this.lblRoundTime.Size = new System.Drawing.Size(87, 31);
            this.lblRoundTime.TabIndex = 2;
            this.lblRoundTime.Text = "00:00";
            // 
            // pnlPlayerStats
            // 
            this.pnlPlayerStats.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlPlayerStats.Controls.Add(this.lblPoints);
            this.pnlPlayerStats.Controls.Add(this.label3);
            this.pnlPlayerStats.Controls.Add(this.lblRound);
            this.pnlPlayerStats.Controls.Add(this.buttonStartSequence);
            this.pnlPlayerStats.Controls.Add(this.lblRoundTime);
            this.pnlPlayerStats.Controls.Add(this.label2);
            this.pnlPlayerStats.Controls.Add(this.lblPlayerName);
            this.pnlPlayerStats.Controls.Add(this.label1);
            this.pnlPlayerStats.Location = new System.Drawing.Point(0, 203);
            this.pnlPlayerStats.Name = "pnlPlayerStats";
            this.pnlPlayerStats.Size = new System.Drawing.Size(306, 174);
            this.pnlPlayerStats.TabIndex = 3;
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRound.Location = new System.Drawing.Point(247, 42);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(17, 17);
            this.lblRound.TabIndex = 3;
            this.lblRound.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(230, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Round";
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.Location = new System.Drawing.Point(33, 42);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(54, 17);
            this.lblPlayerName.TabIndex = 1;
            this.lblPlayerName.Text = "Player";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(140, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Points";
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.Location = new System.Drawing.Point(156, 42);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(17, 17);
            this.lblPoints.TabIndex = 5;
            this.lblPoints.Text = "0";
            // 
            // SequenceGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
        private System.Windows.Forms.Panel pnlPlayerStats;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Label label3;
    }
}