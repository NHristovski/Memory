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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPairGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSequenceGameStarter)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPairGame
            // 
            this.pictureBoxPairGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxPairGame.Image = global::Memory.Properties.Resources.PG_cstill;
            this.pictureBoxPairGame.Location = new System.Drawing.Point(369, 0);
            this.pictureBoxPairGame.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxPairGame.Name = "pictureBoxPairGame";
            this.pictureBoxPairGame.Size = new System.Drawing.Size(369, 421);
            this.pictureBoxPairGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPairGame.TabIndex = 2;
            this.pictureBoxPairGame.TabStop = false;
            this.pictureBoxPairGame.Click += new System.EventHandler(this.pictureBoxPairGame_Click);
            // 
            // pictureBoxSequenceGameStarter
            // 
            this.pictureBoxSequenceGameStarter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSequenceGameStarter.Image = global::Memory.Properties.Resources.SG_cstill;
            this.pictureBoxSequenceGameStarter.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSequenceGameStarter.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxSequenceGameStarter.Name = "pictureBoxSequenceGameStarter";
            this.pictureBoxSequenceGameStarter.Size = new System.Drawing.Size(369, 421);
            this.pictureBoxSequenceGameStarter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSequenceGameStarter.TabIndex = 1;
            this.pictureBoxSequenceGameStarter.TabStop = false;
            this.pictureBoxSequenceGameStarter.Click += new System.EventHandler(this.pictureBoxSequenceGameStarter_Click);
            // 
            // Starter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Memory.Properties.Resources.green_cup;
            this.ClientSize = new System.Drawing.Size(738, 421);
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

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxPairGame;
        private System.Windows.Forms.PictureBox pictureBoxSequenceGameStarter;
    }
}