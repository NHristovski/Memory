namespace Memory
{
    partial class StarterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StarterForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonEnd = new System.Windows.Forms.Button();
            this.buttonShowScores = new System.Windows.Forms.Button();
            this.buttonStartGame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(120, 23);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(357, 185);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // buttonEnd
            // 
            this.buttonEnd.BackColor = System.Drawing.Color.DarkOrange;
            this.buttonEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEnd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonEnd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEnd.Font = new System.Drawing.Font("Eras Demi ITC", 16F);
            this.buttonEnd.Location = new System.Drawing.Point(198, 412);
            this.buttonEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(207, 49);
            this.buttonEnd.TabIndex = 2;
            this.buttonEnd.Text = "END";
            this.buttonEnd.UseVisualStyleBackColor = false;
            this.buttonEnd.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // buttonShowScores
            // 
            this.buttonShowScores.BackColor = System.Drawing.Color.DarkOrange;
            this.buttonShowScores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonShowScores.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonShowScores.Font = new System.Drawing.Font("Eras Demi ITC", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowScores.Location = new System.Drawing.Point(198, 346);
            this.buttonShowScores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonShowScores.Name = "buttonShowScores";
            this.buttonShowScores.Size = new System.Drawing.Size(207, 49);
            this.buttonShowScores.TabIndex = 1;
            this.buttonShowScores.Text = "HIGH SCORE";
            this.buttonShowScores.UseVisualStyleBackColor = false;
            this.buttonShowScores.Click += new System.EventHandler(this.buttonShowScores_Click);
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.BackColor = System.Drawing.Color.DarkOrange;
            this.buttonStartGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonStartGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStartGame.Font = new System.Drawing.Font("Eras Demi ITC", 16F);
            this.buttonStartGame.Location = new System.Drawing.Point(198, 274);
            this.buttonStartGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(207, 49);
            this.buttonStartGame.TabIndex = 0;
            this.buttonStartGame.Text = "START";
            this.buttonStartGame.UseVisualStyleBackColor = false;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // StarterForm
            // 
            this.AcceptButton = this.buttonStartGame;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Memory.Properties.Resources.from1_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.buttonEnd;
            this.ClientSize = new System.Drawing.Size(616, 518);
            this.Controls.Add(this.buttonStartGame);
            this.Controls.Add(this.buttonShowScores);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonEnd);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "StarterForm";
            this.Text = "Memory";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonEnd;
        private System.Windows.Forms.Button buttonShowScores;
        private System.Windows.Forms.Button buttonStartGame;
    }
}

