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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPairGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSequenceGameStarter)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPairGame
            // 
            this.pictureBoxPairGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxPairGame.Location = new System.Drawing.Point(353, 55);
            this.pictureBoxPairGame.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxPairGame.Name = "pictureBoxPairGame";
            this.pictureBoxPairGame.Size = new System.Drawing.Size(348, 330);
            this.pictureBoxPairGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPairGame.TabIndex = 2;
            this.pictureBoxPairGame.TabStop = false;
            this.pictureBoxPairGame.Click += new System.EventHandler(this.pictureBoxPairGame_Click);
            // 
            // pictureBoxSequenceGameStarter
            // 
            this.pictureBoxSequenceGameStarter.BackgroundImage = global::Memory.Properties.Resources.sequence;
            this.pictureBoxSequenceGameStarter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSequenceGameStarter.Location = new System.Drawing.Point(11, 55);
            this.pictureBoxSequenceGameStarter.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxSequenceGameStarter.Name = "pictureBoxSequenceGameStarter";
            this.pictureBoxSequenceGameStarter.Size = new System.Drawing.Size(338, 330);
            this.pictureBoxSequenceGameStarter.TabIndex = 1;
            this.pictureBoxSequenceGameStarter.TabStop = false;
            this.pictureBoxSequenceGameStarter.Click += new System.EventHandler(this.pictureBoxSequenceGameStarter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(263, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "CHOOSE GAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(100, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "SEQUENCE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(500, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "PAIR UP";
            // 
            // Starter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Memory.Properties.Resources.green_cup;
            this.ClientSize = new System.Drawing.Size(712, 396);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxPairGame);
            this.Controls.Add(this.pictureBoxSequenceGameStarter);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Starter";
            this.Text = "Starter";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPairGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSequenceGameStarter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxPairGame;
        private System.Windows.Forms.PictureBox pictureBoxSequenceGameStarter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}