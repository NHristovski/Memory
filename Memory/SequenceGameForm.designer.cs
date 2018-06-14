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
            this.components = new System.ComponentModel.Container();
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
            this.messagesTimer = new System.Windows.Forms.Timer(this.components);
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlHelpers = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblShowSequence = new System.Windows.Forms.Label();
            this.lblExtraTime = new System.Windows.Forms.Label();
            this.lblIncreaseMultiplier = new System.Windows.Forms.Label();
            this.btnUseShowSequence = new System.Windows.Forms.Button();
            this.btnUseExtraTime = new System.Windows.Forms.Button();
            this.btnUseMultiplier = new System.Windows.Forms.Button();
            this.pnlPlayerStats.SuspendLayout();
            this.pnlHelpers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStartSequence
            // 
            this.buttonStartSequence.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartSequence.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonStartSequence.Location = new System.Drawing.Point(118, 124);
            this.buttonStartSequence.Name = "buttonStartSequence";
            this.buttonStartSequence.Size = new System.Drawing.Size(81, 24);
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
            // messagesTimer
            // 
            this.messagesTimer.Interval = 1000;
            this.messagesTimer.Tick += new System.EventHandler(this.messagesTimer_Tick);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Gold;
            this.lblMessage.Location = new System.Drawing.Point(377, 9);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 31);
            this.lblMessage.TabIndex = 10;
            // 
            // pnlHelpers
            // 
            this.pnlHelpers.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlHelpers.Controls.Add(this.btnUseMultiplier);
            this.pnlHelpers.Controls.Add(this.btnUseExtraTime);
            this.pnlHelpers.Controls.Add(this.btnUseShowSequence);
            this.pnlHelpers.Controls.Add(this.lblIncreaseMultiplier);
            this.pnlHelpers.Controls.Add(this.lblExtraTime);
            this.pnlHelpers.Controls.Add(this.lblShowSequence);
            this.pnlHelpers.Controls.Add(this.pictureBox3);
            this.pnlHelpers.Controls.Add(this.pictureBox2);
            this.pnlHelpers.Controls.Add(this.pictureBox1);
            this.pnlHelpers.Location = new System.Drawing.Point(511, 191);
            this.pnlHelpers.Name = "pnlHelpers";
            this.pnlHelpers.Size = new System.Drawing.Size(317, 164);
            this.pnlHelpers.TabIndex = 11;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Memory.Properties.Resources.points_p;
            this.pictureBox3.Location = new System.Drawing.Point(228, 10);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(76, 76);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(121, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(76, 76);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::Memory.Properties.Resources.show_sequence;
            this.pictureBox1.Location = new System.Drawing.Point(14, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblShowSequence
            // 
            this.lblShowSequence.AutoSize = true;
            this.lblShowSequence.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowSequence.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblShowSequence.Location = new System.Drawing.Point(44, 97);
            this.lblShowSequence.Name = "lblShowSequence";
            this.lblShowSequence.Size = new System.Drawing.Size(17, 17);
            this.lblShowSequence.TabIndex = 3;
            this.lblShowSequence.Text = "0";
            // 
            // lblExtraTime
            // 
            this.lblExtraTime.AutoSize = true;
            this.lblExtraTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtraTime.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblExtraTime.Location = new System.Drawing.Point(155, 97);
            this.lblExtraTime.Name = "lblExtraTime";
            this.lblExtraTime.Size = new System.Drawing.Size(17, 17);
            this.lblExtraTime.TabIndex = 4;
            this.lblExtraTime.Text = "0";
            // 
            // lblIncreaseMultiplier
            // 
            this.lblIncreaseMultiplier.AutoSize = true;
            this.lblIncreaseMultiplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncreaseMultiplier.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblIncreaseMultiplier.Location = new System.Drawing.Point(256, 97);
            this.lblIncreaseMultiplier.Name = "lblIncreaseMultiplier";
            this.lblIncreaseMultiplier.Size = new System.Drawing.Size(17, 17);
            this.lblIncreaseMultiplier.TabIndex = 5;
            this.lblIncreaseMultiplier.Text = "0";
            // 
            // btnUseShowSequence
            // 
            this.btnUseShowSequence.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUseShowSequence.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnUseShowSequence.Location = new System.Drawing.Point(14, 124);
            this.btnUseShowSequence.Name = "btnUseShowSequence";
            this.btnUseShowSequence.Size = new System.Drawing.Size(76, 24);
            this.btnUseShowSequence.TabIndex = 9;
            this.btnUseShowSequence.Text = "Use";
            this.btnUseShowSequence.UseVisualStyleBackColor = true;
            this.btnUseShowSequence.Click += new System.EventHandler(this.btnUseShowSequence_Click);
            // 
            // btnUseExtraTime
            // 
            this.btnUseExtraTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUseExtraTime.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnUseExtraTime.Location = new System.Drawing.Point(121, 124);
            this.btnUseExtraTime.Name = "btnUseExtraTime";
            this.btnUseExtraTime.Size = new System.Drawing.Size(76, 24);
            this.btnUseExtraTime.TabIndex = 10;
            this.btnUseExtraTime.Text = "Use";
            this.btnUseExtraTime.UseVisualStyleBackColor = true;
            this.btnUseExtraTime.Click += new System.EventHandler(this.btnUseExtraTime_Click);
            // 
            // btnUseMultiplier
            // 
            this.btnUseMultiplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUseMultiplier.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnUseMultiplier.Location = new System.Drawing.Point(228, 124);
            this.btnUseMultiplier.Name = "btnUseMultiplier";
            this.btnUseMultiplier.Size = new System.Drawing.Size(76, 24);
            this.btnUseMultiplier.TabIndex = 11;
            this.btnUseMultiplier.Text = "Use";
            this.btnUseMultiplier.UseVisualStyleBackColor = true;
            this.btnUseMultiplier.Click += new System.EventHandler(this.btnUseMultiplier_Click);
            // 
            // SequenceGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(840, 564);
            this.Controls.Add(this.pnlHelpers);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pnlPlayerStats);
            this.Name = "SequenceGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SequenceGameForm";
            this.Load += new System.EventHandler(this.SequenceGameForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SequenceGameForm_Paint);
            this.pnlPlayerStats.ResumeLayout(false);
            this.pnlPlayerStats.PerformLayout();
            this.pnlHelpers.ResumeLayout(false);
            this.pnlHelpers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Timer messagesTimer;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel pnlHelpers;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblIncreaseMultiplier;
        private System.Windows.Forms.Label lblExtraTime;
        private System.Windows.Forms.Label lblShowSequence;
        private System.Windows.Forms.Button btnUseMultiplier;
        private System.Windows.Forms.Button btnUseExtraTime;
        private System.Windows.Forms.Button btnUseShowSequence;
    }
}