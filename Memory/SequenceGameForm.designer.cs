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
            this.lblPoints = new System.Windows.Forms.Label();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.lblRound = new System.Windows.Forms.Label();
            this.pnlPlayerStats = new System.Windows.Forms.Panel();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pbGender = new System.Windows.Forms.PictureBox();
            this.messagesTimer = new System.Windows.Forms.Timer(this.components);
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlHelpers = new System.Windows.Forms.Panel();
            this.btnUseMultiplier = new System.Windows.Forms.Button();
            this.btnUseExtraTime = new System.Windows.Forms.Button();
            this.btnUseShowSequence = new System.Windows.Forms.Button();
            this.lblIncreaseMultiplier = new System.Windows.Forms.Label();
            this.lblExtraTime = new System.Windows.Forms.Label();
            this.lblShowSequence = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlHelp2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pnlHelp = new System.Windows.Forms.Panel();
            this.pbHelp = new System.Windows.Forms.PictureBox();
            this.panelMovingTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlStore = new System.Windows.Forms.Panel();
            this.lblStoreError = new System.Windows.Forms.Label();
            this.pbStore = new System.Windows.Forms.PictureBox();
            this.pnlStore2 = new System.Windows.Forms.Panel();
            this.btnBuyMultiplier = new System.Windows.Forms.Button();
            this.tbPointsPrice = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnBuyTime = new System.Windows.Forms.Button();
            this.tbTimePrice = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnBuySequence = new System.Windows.Forms.Button();
            this.tbSequencePrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlPlayerStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGender)).BeginInit();
            this.pnlHelpers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlHelp2.SuspendLayout();
            this.pnlHelp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).BeginInit();
            this.pnlStore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStore)).BeginInit();
            this.pnlStore2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStartSequence
            // 
            this.buttonStartSequence.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartSequence.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonStartSequence.Location = new System.Drawing.Point(182, 124);
            this.buttonStartSequence.Name = "buttonStartSequence";
            this.buttonStartSequence.Size = new System.Drawing.Size(104, 29);
            this.buttonStartSequence.TabIndex = 1;
            this.buttonStartSequence.Text = "Start";
            this.buttonStartSequence.UseVisualStyleBackColor = true;
            this.buttonStartSequence.Click += new System.EventHandler(this.buttonStartSequence_Click);
            // 
            // lblRoundTime
            // 
            this.lblRoundTime.AutoSize = true;
            this.lblRoundTime.BackColor = System.Drawing.Color.Transparent;
            this.lblRoundTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoundTime.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblRoundTime.Location = new System.Drawing.Point(173, 79);
            this.lblRoundTime.Name = "lblRoundTime";
            this.lblRoundTime.Size = new System.Drawing.Size(124, 46);
            this.lblRoundTime.TabIndex = 2;
            this.lblRoundTime.Text = "00:00";
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.BackColor = System.Drawing.Color.Transparent;
            this.lblPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblPoints.Location = new System.Drawing.Point(75, 112);
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
            this.lblPlayerName.Location = new System.Drawing.Point(75, 35);
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
            this.lblRound.Location = new System.Drawing.Point(242, 31);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(17, 17);
            this.lblRound.TabIndex = 7;
            this.lblRound.Text = "0";
            // 
            // pnlPlayerStats
            // 
            this.pnlPlayerStats.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlPlayerStats.Controls.Add(this.pictureBox9);
            this.pnlPlayerStats.Controls.Add(this.pictureBox8);
            this.pnlPlayerStats.Controls.Add(this.pbGender);
            this.pnlPlayerStats.Controls.Add(this.buttonStartSequence);
            this.pnlPlayerStats.Controls.Add(this.lblRound);
            this.pnlPlayerStats.Controls.Add(this.lblRoundTime);
            this.pnlPlayerStats.Controls.Add(this.lblPlayerName);
            this.pnlPlayerStats.Controls.Add(this.lblPoints);
            this.pnlPlayerStats.Location = new System.Drawing.Point(12, 191);
            this.pnlPlayerStats.Name = "pnlPlayerStats";
            this.pnlPlayerStats.Size = new System.Drawing.Size(317, 164);
            this.pnlPlayerStats.TabIndex = 9;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::Memory.Properties.Resources.trophy_p;
            this.pictureBox9.Location = new System.Drawing.Point(182, 10);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(58, 57);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 10;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::Memory.Properties.Resources.money_bag;
            this.pictureBox8.Location = new System.Drawing.Point(15, 91);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(58, 57);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 9;
            this.pictureBox8.TabStop = false;
            // 
            // pbGender
            // 
            this.pbGender.Image = global::Memory.Properties.Resources.boy;
            this.pbGender.Location = new System.Drawing.Point(15, 13);
            this.pbGender.Name = "pbGender";
            this.pbGender.Size = new System.Drawing.Size(58, 57);
            this.pbGender.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGender.TabIndex = 8;
            this.pbGender.TabStop = false;
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
            // pnlHelp2
            // 
            this.pnlHelp2.Controls.Add(this.label3);
            this.pnlHelp2.Controls.Add(this.richTextBox1);
            this.pnlHelp2.Location = new System.Drawing.Point(840, 191);
            this.pnlHelp2.Name = "pnlHelp2";
            this.pnlHelp2.Size = new System.Drawing.Size(230, 373);
            this.pnlHelp2.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(93, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Help";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.richTextBox1.Location = new System.Drawing.Point(12, 38);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(206, 292);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // pnlHelp
            // 
            this.pnlHelp.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlHelp.Controls.Add(this.pbHelp);
            this.pnlHelp.Location = new System.Drawing.Point(805, 527);
            this.pnlHelp.Name = "pnlHelp";
            this.pnlHelp.Size = new System.Drawing.Size(265, 37);
            this.pnlHelp.TabIndex = 13;
            // 
            // pbHelp
            // 
            this.pbHelp.Image = ((System.Drawing.Image)(resources.GetObject("pbHelp.Image")));
            this.pbHelp.Location = new System.Drawing.Point(0, 1);
            this.pbHelp.Name = "pbHelp";
            this.pbHelp.Size = new System.Drawing.Size(35, 35);
            this.pbHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHelp.TabIndex = 0;
            this.pbHelp.TabStop = false;
            this.pbHelp.Click += new System.EventHandler(this.pbHelp_Click);
            // 
            // panelMovingTimer
            // 
            this.panelMovingTimer.Interval = 25;
            this.panelMovingTimer.Tick += new System.EventHandler(this.panelMovingTimer_Tick);
            // 
            // pnlStore
            // 
            this.pnlStore.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlStore.Controls.Add(this.lblStoreError);
            this.pnlStore.Controls.Add(this.pbStore);
            this.pnlStore.Location = new System.Drawing.Point(805, 490);
            this.pnlStore.Name = "pnlStore";
            this.pnlStore.Size = new System.Drawing.Size(265, 37);
            this.pnlStore.TabIndex = 15;
            // 
            // lblStoreError
            // 
            this.lblStoreError.AutoSize = true;
            this.lblStoreError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreError.ForeColor = System.Drawing.Color.Crimson;
            this.lblStoreError.Location = new System.Drawing.Point(37, 3);
            this.lblStoreError.Name = "lblStoreError";
            this.lblStoreError.Size = new System.Drawing.Size(0, 13);
            this.lblStoreError.TabIndex = 1;
            // 
            // pbStore
            // 
            this.pbStore.Image = ((System.Drawing.Image)(resources.GetObject("pbStore.Image")));
            this.pbStore.Location = new System.Drawing.Point(0, 1);
            this.pbStore.Name = "pbStore";
            this.pbStore.Size = new System.Drawing.Size(35, 35);
            this.pbStore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStore.TabIndex = 0;
            this.pbStore.TabStop = false;
            this.pbStore.Click += new System.EventHandler(this.pbStore_Click);
            // 
            // pnlStore2
            // 
            this.pnlStore2.Controls.Add(this.btnBuyMultiplier);
            this.pnlStore2.Controls.Add(this.tbPointsPrice);
            this.pnlStore2.Controls.Add(this.label12);
            this.pnlStore2.Controls.Add(this.btnBuyTime);
            this.pnlStore2.Controls.Add(this.tbTimePrice);
            this.pnlStore2.Controls.Add(this.label11);
            this.pnlStore2.Controls.Add(this.btnBuySequence);
            this.pnlStore2.Controls.Add(this.tbSequencePrice);
            this.pnlStore2.Controls.Add(this.label10);
            this.pnlStore2.Controls.Add(this.label9);
            this.pnlStore2.Controls.Add(this.label8);
            this.pnlStore2.Controls.Add(this.label7);
            this.pnlStore2.Controls.Add(this.label5);
            this.pnlStore2.Controls.Add(this.pictureBox6);
            this.pnlStore2.Controls.Add(this.pictureBox5);
            this.pnlStore2.Controls.Add(this.pictureBox4);
            this.pnlStore2.Controls.Add(this.label4);
            this.pnlStore2.Location = new System.Drawing.Point(840, 150);
            this.pnlStore2.Name = "pnlStore2";
            this.pnlStore2.Size = new System.Drawing.Size(230, 377);
            this.pnlStore2.TabIndex = 14;
            // 
            // btnBuyMultiplier
            // 
            this.btnBuyMultiplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuyMultiplier.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnBuyMultiplier.Location = new System.Drawing.Point(94, 295);
            this.btnBuyMultiplier.Name = "btnBuyMultiplier";
            this.btnBuyMultiplier.Size = new System.Drawing.Size(90, 23);
            this.btnBuyMultiplier.TabIndex = 16;
            this.btnBuyMultiplier.Text = "B U Y";
            this.btnBuyMultiplier.UseVisualStyleBackColor = true;
            this.btnBuyMultiplier.Click += new System.EventHandler(this.btnBuyMultiplier_Click);
            // 
            // tbPointsPrice
            // 
            this.tbPointsPrice.Enabled = false;
            this.tbPointsPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPointsPrice.Location = new System.Drawing.Point(145, 270);
            this.tbPointsPrice.Name = "tbPointsPrice";
            this.tbPointsPrice.Size = new System.Drawing.Size(39, 20);
            this.tbPointsPrice.TabIndex = 15;
            this.tbPointsPrice.Text = "175";
            this.tbPointsPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(91, 271);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 16);
            this.label12.TabIndex = 14;
            this.label12.Text = "Price:";
            // 
            // btnBuyTime
            // 
            this.btnBuyTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuyTime.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnBuyTime.Location = new System.Drawing.Point(97, 199);
            this.btnBuyTime.Name = "btnBuyTime";
            this.btnBuyTime.Size = new System.Drawing.Size(90, 23);
            this.btnBuyTime.TabIndex = 13;
            this.btnBuyTime.Text = "B U Y";
            this.btnBuyTime.UseVisualStyleBackColor = true;
            this.btnBuyTime.Click += new System.EventHandler(this.btnBuyTime_Click);
            // 
            // tbTimePrice
            // 
            this.tbTimePrice.Enabled = false;
            this.tbTimePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTimePrice.Location = new System.Drawing.Point(148, 169);
            this.tbTimePrice.Name = "tbTimePrice";
            this.tbTimePrice.Size = new System.Drawing.Size(39, 20);
            this.tbTimePrice.TabIndex = 12;
            this.tbTimePrice.Text = "215";
            this.tbTimePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(94, 170);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 11;
            this.label11.Text = "Price:";
            // 
            // btnBuySequence
            // 
            this.btnBuySequence.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuySequence.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnBuySequence.Location = new System.Drawing.Point(93, 107);
            this.btnBuySequence.Name = "btnBuySequence";
            this.btnBuySequence.Size = new System.Drawing.Size(90, 23);
            this.btnBuySequence.TabIndex = 10;
            this.btnBuySequence.Text = "B U Y";
            this.btnBuySequence.UseVisualStyleBackColor = true;
            this.btnBuySequence.Click += new System.EventHandler(this.btnBuySequence_Click);
            // 
            // tbSequencePrice
            // 
            this.tbSequencePrice.Enabled = false;
            this.tbSequencePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSequencePrice.Location = new System.Drawing.Point(144, 77);
            this.tbSequencePrice.Name = "tbSequencePrice";
            this.tbSequencePrice.Size = new System.Drawing.Size(39, 20);
            this.tbSequencePrice.TabIndex = 9;
            this.tbSequencePrice.Text = "150";
            this.tbSequencePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(90, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 8;
            this.label10.Text = "Price:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(90, 253);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "multiplier";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(90, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Increase points";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(90, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Extra 10 seconds";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(90, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Show sequence";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::Memory.Properties.Resources.points_p;
            this.pictureBox6.Location = new System.Drawing.Point(12, 240);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(76, 76);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 3;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Memory.Properties.Resources.extra_time;
            this.pictureBox5.Location = new System.Drawing.Point(12, 146);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(76, 76);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 2;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Memory.Properties.Resources.show_sequence;
            this.pictureBox4.Location = new System.Drawing.Point(12, 54);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(76, 76);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(89, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Store";
            // 
            // SequenceGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(840, 564);
            this.Controls.Add(this.pnlStore);
            this.Controls.Add(this.pnlStore2);
            this.Controls.Add(this.pnlHelp);
            this.Controls.Add(this.pnlHelp2);
            this.Controls.Add(this.pnlHelpers);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pnlPlayerStats);
            this.Name = "SequenceGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sequence Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SequenceGameForm_FormClosing);
            this.Load += new System.EventHandler(this.SequenceGameForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SequenceGameForm_Paint);
            this.pnlPlayerStats.ResumeLayout(false);
            this.pnlPlayerStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGender)).EndInit();
            this.pnlHelpers.ResumeLayout(false);
            this.pnlHelpers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlHelp2.ResumeLayout(false);
            this.pnlHelp2.PerformLayout();
            this.pnlHelp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).EndInit();
            this.pnlStore.ResumeLayout(false);
            this.pnlStore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStore)).EndInit();
            this.pnlStore2.ResumeLayout(false);
            this.pnlStore2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonStartSequence;
        private System.Windows.Forms.Label lblRoundTime;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label lblRound;
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
        private System.Windows.Forms.Panel pnlHelp2;
        private System.Windows.Forms.Panel pnlHelp;
        private System.Windows.Forms.PictureBox pbHelp;
        private System.Windows.Forms.Timer panelMovingTimer;
        private System.Windows.Forms.Panel pnlStore;
        private System.Windows.Forms.PictureBox pbStore;
        private System.Windows.Forms.Panel pnlStore2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnBuyMultiplier;
        private System.Windows.Forms.TextBox tbPointsPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnBuyTime;
        private System.Windows.Forms.TextBox tbTimePrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnBuySequence;
        private System.Windows.Forms.TextBox tbSequencePrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStoreError;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pbGender;
    }
}