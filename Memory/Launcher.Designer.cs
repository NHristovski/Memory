namespace Memory
{
    partial class Launcher
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
            this.textBoxPlayer1Name = new System.Windows.Forms.TextBox();
            this.labelPlayer1Name = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonHard = new System.Windows.Forms.RadioButton();
            this.radioButtonMedium = new System.Windows.Forms.RadioButton();
            this.radioButtonEasy = new System.Windows.Forms.RadioButton();
            this.textBoxPlayer2Name = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelPlayer2Name = new System.Windows.Forms.Label();
            this.groupBoxBotLevel = new System.Windows.Forms.GroupBox();
            this.radioButtonBotHard = new System.Windows.Forms.RadioButton();
            this.radioButtonBotMedium = new System.Windows.Forms.RadioButton();
            this.radioButtonBotEasy = new System.Windows.Forms.RadioButton();
            this.radioButtonBot = new System.Windows.Forms.RadioButton();
            this.radioButtonHuman = new System.Windows.Forms.RadioButton();
            this.buttonStart = new System.Windows.Forms.Button();
            this.errorProviderP1Name = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderP2Name = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonOpen = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxBotLevel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderP1Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderP2Name)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPlayer1Name
            // 
            this.textBoxPlayer1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPlayer1Name.Location = new System.Drawing.Point(27, 43);
            this.textBoxPlayer1Name.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPlayer1Name.MaxLength = 15;
            this.textBoxPlayer1Name.Multiline = true;
            this.textBoxPlayer1Name.Name = "textBoxPlayer1Name";
            this.textBoxPlayer1Name.Size = new System.Drawing.Size(233, 28);
            this.textBoxPlayer1Name.TabIndex = 0;
            this.textBoxPlayer1Name.TextChanged += new System.EventHandler(this.textBoxPlayer1Name_TextChanged);
            this.textBoxPlayer1Name.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPlayer1Name_Validating);
            // 
            // labelPlayer1Name
            // 
            this.labelPlayer1Name.AutoSize = true;
            this.labelPlayer1Name.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayer1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelPlayer1Name.Location = new System.Drawing.Point(23, 16);
            this.labelPlayer1Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlayer1Name.Name = "labelPlayer1Name";
            this.labelPlayer1Name.Size = new System.Drawing.Size(147, 25);
            this.labelPlayer1Name.TabIndex = 1;
            this.labelPlayer1Name.Text = "Player1 Name";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.radioButtonHard);
            this.groupBox1.Controls.Add(this.radioButtonMedium);
            this.groupBox1.Controls.Add(this.radioButtonEasy);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(27, 91);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(180, 144);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Difficulty";
            // 
            // radioButtonHard
            // 
            this.radioButtonHard.AutoSize = true;
            this.radioButtonHard.Location = new System.Drawing.Point(38, 110);
            this.radioButtonHard.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonHard.Name = "radioButtonHard";
            this.radioButtonHard.Size = new System.Drawing.Size(83, 24);
            this.radioButtonHard.TabIndex = 2;
            this.radioButtonHard.Text = "HARD";
            this.radioButtonHard.UseVisualStyleBackColor = true;
            // 
            // radioButtonMedium
            // 
            this.radioButtonMedium.AutoSize = true;
            this.radioButtonMedium.Location = new System.Drawing.Point(38, 69);
            this.radioButtonMedium.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonMedium.Name = "radioButtonMedium";
            this.radioButtonMedium.Size = new System.Drawing.Size(104, 24);
            this.radioButtonMedium.TabIndex = 1;
            this.radioButtonMedium.Text = "MEDIUM";
            this.radioButtonMedium.UseVisualStyleBackColor = true;
            // 
            // radioButtonEasy
            // 
            this.radioButtonEasy.AutoSize = true;
            this.radioButtonEasy.Checked = true;
            this.radioButtonEasy.Location = new System.Drawing.Point(38, 33);
            this.radioButtonEasy.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonEasy.Name = "radioButtonEasy";
            this.radioButtonEasy.Size = new System.Drawing.Size(77, 24);
            this.radioButtonEasy.TabIndex = 0;
            this.radioButtonEasy.TabStop = true;
            this.radioButtonEasy.Text = "EASY";
            this.radioButtonEasy.UseVisualStyleBackColor = true;
            // 
            // textBoxPlayer2Name
            // 
            this.textBoxPlayer2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPlayer2Name.Location = new System.Drawing.Point(21, 90);
            this.textBoxPlayer2Name.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPlayer2Name.MaxLength = 15;
            this.textBoxPlayer2Name.Multiline = true;
            this.textBoxPlayer2Name.Name = "textBoxPlayer2Name";
            this.textBoxPlayer2Name.Size = new System.Drawing.Size(235, 28);
            this.textBoxPlayer2Name.TabIndex = 5;
            this.textBoxPlayer2Name.TextChanged += new System.EventHandler(this.textBoxPlayer2Name_TextChanged);
            this.textBoxPlayer2Name.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPlayer2Name_Validating);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.labelPlayer2Name);
            this.groupBox2.Controls.Add(this.groupBoxBotLevel);
            this.groupBox2.Controls.Add(this.radioButtonBot);
            this.groupBox2.Controls.Add(this.radioButtonHuman);
            this.groupBox2.Controls.Add(this.textBoxPlayer2Name);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox2.Location = new System.Drawing.Point(334, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(273, 305);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Player 2";
            // 
            // labelPlayer2Name
            // 
            this.labelPlayer2Name.AutoSize = true;
            this.labelPlayer2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelPlayer2Name.Location = new System.Drawing.Point(16, 63);
            this.labelPlayer2Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlayer2Name.Name = "labelPlayer2Name";
            this.labelPlayer2Name.Size = new System.Drawing.Size(147, 25);
            this.labelPlayer2Name.TabIndex = 8;
            this.labelPlayer2Name.Text = "Player2 Name";
            // 
            // groupBoxBotLevel
            // 
            this.groupBoxBotLevel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBoxBotLevel.Controls.Add(this.radioButtonBotHard);
            this.groupBoxBotLevel.Controls.Add(this.radioButtonBotMedium);
            this.groupBoxBotLevel.Controls.Add(this.radioButtonBotEasy);
            this.groupBoxBotLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxBotLevel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBoxBotLevel.Location = new System.Drawing.Point(38, 176);
            this.groupBoxBotLevel.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxBotLevel.Name = "groupBoxBotLevel";
            this.groupBoxBotLevel.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxBotLevel.Size = new System.Drawing.Size(186, 118);
            this.groupBoxBotLevel.TabIndex = 8;
            this.groupBoxBotLevel.TabStop = false;
            this.groupBoxBotLevel.Text = "Bot Level";
            this.groupBoxBotLevel.Enter += new System.EventHandler(this.groupBoxBotLevel_Enter);
            // 
            // radioButtonBotHard
            // 
            this.radioButtonBotHard.AutoSize = true;
            this.radioButtonBotHard.Location = new System.Drawing.Point(41, 87);
            this.radioButtonBotHard.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonBotHard.Name = "radioButtonBotHard";
            this.radioButtonBotHard.Size = new System.Drawing.Size(83, 24);
            this.radioButtonBotHard.TabIndex = 3;
            this.radioButtonBotHard.Text = "HARD";
            this.radioButtonBotHard.UseVisualStyleBackColor = true;
            // 
            // radioButtonBotMedium
            // 
            this.radioButtonBotMedium.AutoSize = true;
            this.radioButtonBotMedium.Location = new System.Drawing.Point(41, 59);
            this.radioButtonBotMedium.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonBotMedium.Name = "radioButtonBotMedium";
            this.radioButtonBotMedium.Size = new System.Drawing.Size(104, 24);
            this.radioButtonBotMedium.TabIndex = 3;
            this.radioButtonBotMedium.Text = "MEDIUM";
            this.radioButtonBotMedium.UseVisualStyleBackColor = true;
            // 
            // radioButtonBotEasy
            // 
            this.radioButtonBotEasy.AutoSize = true;
            this.radioButtonBotEasy.Checked = true;
            this.radioButtonBotEasy.Location = new System.Drawing.Point(39, 31);
            this.radioButtonBotEasy.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonBotEasy.Name = "radioButtonBotEasy";
            this.radioButtonBotEasy.Size = new System.Drawing.Size(77, 24);
            this.radioButtonBotEasy.TabIndex = 3;
            this.radioButtonBotEasy.TabStop = true;
            this.radioButtonBotEasy.Text = "EASY";
            this.radioButtonBotEasy.UseVisualStyleBackColor = true;
            // 
            // radioButtonBot
            // 
            this.radioButtonBot.AutoSize = true;
            this.radioButtonBot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.radioButtonBot.Location = new System.Drawing.Point(21, 143);
            this.radioButtonBot.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonBot.Name = "radioButtonBot";
            this.radioButtonBot.Size = new System.Drawing.Size(65, 29);
            this.radioButtonBot.TabIndex = 7;
            this.radioButtonBot.Text = "Bot";
            this.radioButtonBot.UseVisualStyleBackColor = true;
            this.radioButtonBot.CheckedChanged += new System.EventHandler(this.radioButtonBot_CheckedChanged);
            // 
            // radioButtonHuman
            // 
            this.radioButtonHuman.AutoSize = true;
            this.radioButtonHuman.Checked = true;
            this.radioButtonHuman.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.radioButtonHuman.Location = new System.Drawing.Point(21, 27);
            this.radioButtonHuman.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonHuman.Name = "radioButtonHuman";
            this.radioButtonHuman.Size = new System.Drawing.Size(101, 29);
            this.radioButtonHuman.TabIndex = 6;
            this.radioButtonHuman.TabStop = true;
            this.radioButtonHuman.Text = "Human";
            this.radioButtonHuman.UseVisualStyleBackColor = true;
            this.radioButtonHuman.CheckedChanged += new System.EventHandler(this.radioButtonHuman_CheckedChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.LavenderBlush;
            this.buttonStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.buttonStart.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonStart.Location = new System.Drawing.Point(27, 280);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(138, 35);
            this.buttonStart.TabIndex = 7;
            this.buttonStart.Text = "S T A R T";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // errorProviderP1Name
            // 
            this.errorProviderP1Name.ContainerControl = this;
            // 
            // errorProviderP2Name
            // 
            this.errorProviderP2Name.ContainerControl = this;
            // 
            // buttonOpen
            // 
            this.buttonOpen.BackColor = System.Drawing.Color.LavenderBlush;
            this.buttonOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.buttonOpen.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonOpen.Location = new System.Drawing.Point(180, 280);
            this.buttonOpen.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(138, 35);
            this.buttonOpen.TabIndex = 8;
            this.buttonOpen.Text = "CONTINUE";
            this.buttonOpen.UseVisualStyleBackColor = false;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.BackgroundImage = global::Memory.Properties.Resources.green_cup;
            this.ClientSize = new System.Drawing.Size(618, 320);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelPlayer1Name);
            this.Controls.Add(this.textBoxPlayer1Name);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Launcher";
            this.Text = "Launcher";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxBotLevel.ResumeLayout(false);
            this.groupBoxBotLevel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderP1Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderP2Name)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPlayer1Name;
        private System.Windows.Forms.Label labelPlayer1Name;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonHard;
        private System.Windows.Forms.RadioButton radioButtonMedium;
        private System.Windows.Forms.RadioButton radioButtonEasy;
        private System.Windows.Forms.TextBox textBoxPlayer2Name;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBoxBotLevel;
        private System.Windows.Forms.RadioButton radioButtonBotHard;
        private System.Windows.Forms.RadioButton radioButtonBotMedium;
        private System.Windows.Forms.RadioButton radioButtonBotEasy;
        private System.Windows.Forms.RadioButton radioButtonBot;
        private System.Windows.Forms.RadioButton radioButtonHuman;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelPlayer2Name;
        private System.Windows.Forms.ErrorProvider errorProviderP1Name;
        private System.Windows.Forms.ErrorProvider errorProviderP2Name;
        private System.Windows.Forms.Button buttonOpen;
    }
}