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
            this.pictureBoxPairGame.Location = new System.Drawing.Point(404, 73);
            this.pictureBoxPairGame.Name = "pictureBoxPairGame";
            this.pictureBoxPairGame.Size = new System.Drawing.Size(409, 417);
            this.pictureBoxPairGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPairGame.TabIndex = 2;
            this.pictureBoxPairGame.TabStop = false;
            this.pictureBoxPairGame.Click += new System.EventHandler(this.pictureBoxPairGame_Click);
            // 
            // pictureBoxSequenceGameStarter
            // 
            this.pictureBoxSequenceGameStarter.Location = new System.Drawing.Point(-1, 73);
            this.pictureBoxSequenceGameStarter.Name = "pictureBoxSequenceGameStarter";
            this.pictureBoxSequenceGameStarter.Size = new System.Drawing.Size(405, 417);
            this.pictureBoxSequenceGameStarter.TabIndex = 1;
            this.pictureBoxSequenceGameStarter.TabStop = false;
            this.pictureBoxSequenceGameStarter.Click += new System.EventHandler(this.pictureBoxSequenceGameStarter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(321, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "CHOSE GAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(108, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "SEQUENCE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(572, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "PAIR UP";
            // 
            // Starter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 488);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxPairGame);
            this.Controls.Add(this.pictureBoxSequenceGameStarter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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