namespace Memory
{
    partial class Starter
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
            this.pictureBoxPairGame = new System.Windows.Forms.PictureBox();
            this.pictureBoxSequenceGameStarter = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPairGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSequenceGameStarter)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxPairGame
            // 
            this.pictureBoxPairGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxPairGame.Location = new System.Drawing.Point(5, 21);
            this.pictureBoxPairGame.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxPairGame.Name = "pictureBoxPairGame";
            this.pictureBoxPairGame.Size = new System.Drawing.Size(381, 340);
            this.pictureBoxPairGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPairGame.TabIndex = 2;
            this.pictureBoxPairGame.TabStop = false;
            this.pictureBoxPairGame.Click += new System.EventHandler(this.pictureBoxPairGame_Click);
            // 
            // pictureBoxSequenceGameStarter
            // 
            this.pictureBoxSequenceGameStarter.BackgroundImage = global::Memory.Properties.Resources.sequence;
            this.pictureBoxSequenceGameStarter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSequenceGameStarter.Location = new System.Drawing.Point(5, 21);
            this.pictureBoxSequenceGameStarter.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxSequenceGameStarter.Name = "pictureBoxSequenceGameStarter";
            this.pictureBoxSequenceGameStarter.Size = new System.Drawing.Size(344, 345);
            this.pictureBoxSequenceGameStarter.TabIndex = 1;
            this.pictureBoxSequenceGameStarter.TabStop = false;
            this.pictureBoxSequenceGameStarter.Click += new System.EventHandler(this.pictureBoxSequenceGameStarter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label1.Location = new System.Drawing.Point(256, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "CHOOSE GAME";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.pictureBoxPairGame);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(354, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 366);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PAIR UP";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.pictureBoxSequenceGameStarter);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox2.Location = new System.Drawing.Point(0, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(358, 366);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SEQUENCE";
            // 
            // Starter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Memory.Properties.Resources.green_cup;
            this.ClientSize = new System.Drawing.Size(738, 421);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Starter";
            this.Text = "Starter";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPairGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSequenceGameStarter)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxPairGame;
        private System.Windows.Forms.PictureBox pictureBoxSequenceGameStarter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}