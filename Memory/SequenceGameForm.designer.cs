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
            this.buttonGenerateStations = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonGenerateStations
            // 
            this.buttonGenerateStations.Location = new System.Drawing.Point(1, 0);
            this.buttonGenerateStations.Name = "buttonGenerateStations";
            this.buttonGenerateStations.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerateStations.TabIndex = 0;
            this.buttonGenerateStations.Text = "Generate";
            this.buttonGenerateStations.UseVisualStyleBackColor = true;
            this.buttonGenerateStations.Click += new System.EventHandler(this.buttonGenerateStations_Click);
            // 
            // SequenceGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 564);
            this.Controls.Add(this.buttonGenerateStations);
            this.Name = "SequenceGameForm";
            this.Text = "SequenceGameForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SequenceGameForm_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerateStations;
    }
}