namespace KeyRemapper
{
    partial class MapSetup
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSetFrom = new System.Windows.Forms.Button();
            this.chkE1FlagFrom = new System.Windows.Forms.CheckBox();
            this.chkE0FlagFrom = new System.Windows.Forms.CheckBox();
            this.numSignalCodeFrom = new System.Windows.Forms.NumericUpDown();
            this.lblKey1 = new System.Windows.Forms.Label();
            this.btnDetectKey1 = new System.Windows.Forms.Button();
            this.btnRefresh1 = new System.Windows.Forms.Button();
            this.btnDetectDevice1 = new System.Windows.Forms.Button();
            this.btnDetectBoth1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDevice1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnMyComputer = new System.Windows.Forms.Button();
            this.btnCalculator = new System.Windows.Forms.Button();
            this.btnEmail = new System.Windows.Forms.Button();
            this.btnMediaSelect = new System.Windows.Forms.Button();
            this.btnVolDown = new System.Windows.Forms.Button();
            this.btnVolUp = new System.Windows.Forms.Button();
            this.btnMute = new System.Windows.Forms.Button();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPreviousTrack = new System.Windows.Forms.Button();
            this.btnNextTrack = new System.Windows.Forms.Button();
            this.btnSetTo = new System.Windows.Forms.Button();
            this.chkIgnore = new System.Windows.Forms.CheckBox();
            this.chkE1FlagTo = new System.Windows.Forms.CheckBox();
            this.chkE0FlagTo = new System.Windows.Forms.CheckBox();
            this.numSignalCodeTo = new System.Windows.Forms.NumericUpDown();
            this.lblKey2 = new System.Windows.Forms.Label();
            this.btnDetectKey2 = new System.Windows.Forms.Button();
            this.btnRefresh2 = new System.Windows.Forms.Button();
            this.btnDetectDevice2 = new System.Windows.Forms.Button();
            this.btnDetectBoth2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDevice2 = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSignalCodeFrom)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSignalCodeTo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSetFrom);
            this.groupBox1.Controls.Add(this.chkE1FlagFrom);
            this.groupBox1.Controls.Add(this.chkE0FlagFrom);
            this.groupBox1.Controls.Add(this.numSignalCodeFrom);
            this.groupBox1.Controls.Add(this.lblKey1);
            this.groupBox1.Controls.Add(this.btnDetectKey1);
            this.groupBox1.Controls.Add(this.btnRefresh1);
            this.groupBox1.Controls.Add(this.btnDetectDevice1);
            this.groupBox1.Controls.Add(this.btnDetectBoth1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbDevice1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(825, 123);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Map from:";
            // 
            // btnSetFrom
            // 
            this.btnSetFrom.Location = new System.Drawing.Point(157, 44);
            this.btnSetFrom.Name = "btnSetFrom";
            this.btnSetFrom.Size = new System.Drawing.Size(75, 23);
            this.btnSetFrom.TabIndex = 17;
            this.btnSetFrom.Text = "Set";
            this.btnSetFrom.UseVisualStyleBackColor = true;
            this.btnSetFrom.Click += new System.EventHandler(this.btnSetFrom_Click);
            // 
            // chkE1FlagFrom
            // 
            this.chkE1FlagFrom.AutoSize = true;
            this.chkE1FlagFrom.Location = new System.Drawing.Point(433, 49);
            this.chkE1FlagFrom.Name = "chkE1FlagFrom";
            this.chkE1FlagFrom.Size = new System.Drawing.Size(39, 17);
            this.chkE1FlagFrom.TabIndex = 13;
            this.chkE1FlagFrom.Text = "E1";
            this.chkE1FlagFrom.UseVisualStyleBackColor = true;
            // 
            // chkE0FlagFrom
            // 
            this.chkE0FlagFrom.AutoSize = true;
            this.chkE0FlagFrom.Location = new System.Drawing.Point(388, 49);
            this.chkE0FlagFrom.Name = "chkE0FlagFrom";
            this.chkE0FlagFrom.Size = new System.Drawing.Size(39, 17);
            this.chkE0FlagFrom.TabIndex = 12;
            this.chkE0FlagFrom.Text = "E0";
            this.chkE0FlagFrom.UseVisualStyleBackColor = true;
            // 
            // numSignalCodeFrom
            // 
            this.numSignalCodeFrom.Location = new System.Drawing.Point(94, 46);
            this.numSignalCodeFrom.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numSignalCodeFrom.Name = "numSignalCodeFrom";
            this.numSignalCodeFrom.Size = new System.Drawing.Size(57, 20);
            this.numSignalCodeFrom.TabIndex = 10;
            this.numSignalCodeFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblKey1
            // 
            this.lblKey1.AutoSize = true;
            this.lblKey1.Location = new System.Drawing.Point(235, 49);
            this.lblKey1.Name = "lblKey1";
            this.lblKey1.Size = new System.Drawing.Size(147, 13);
            this.lblKey1.TabIndex = 9;
            this.lblKey1.Text = " [ Detect or set a key to map ]";
            // 
            // btnDetectKey1
            // 
            this.btnDetectKey1.Location = new System.Drawing.Point(478, 45);
            this.btnDetectKey1.Name = "btnDetectKey1";
            this.btnDetectKey1.Size = new System.Drawing.Size(75, 23);
            this.btnDetectKey1.TabIndex = 8;
            this.btnDetectKey1.Text = "Detect";
            this.btnDetectKey1.UseVisualStyleBackColor = true;
            this.btnDetectKey1.Click += new System.EventHandler(this.btnDetectKey1_Click);
            // 
            // btnRefresh1
            // 
            this.btnRefresh1.Location = new System.Drawing.Point(701, 17);
            this.btnRefresh1.Name = "btnRefresh1";
            this.btnRefresh1.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh1.TabIndex = 7;
            this.btnRefresh1.Text = "Refresh";
            this.btnRefresh1.UseVisualStyleBackColor = true;
            this.btnRefresh1.Click += new System.EventHandler(this.btnRefresh1_Click);
            // 
            // btnDetectDevice1
            // 
            this.btnDetectDevice1.Location = new System.Drawing.Point(620, 17);
            this.btnDetectDevice1.Name = "btnDetectDevice1";
            this.btnDetectDevice1.Size = new System.Drawing.Size(75, 23);
            this.btnDetectDevice1.TabIndex = 6;
            this.btnDetectDevice1.Text = "Detect";
            this.btnDetectDevice1.UseVisualStyleBackColor = true;
            this.btnDetectDevice1.Click += new System.EventHandler(this.btnDetectDevice1_Click);
            // 
            // btnDetectBoth1
            // 
            this.btnDetectBoth1.Location = new System.Drawing.Point(94, 82);
            this.btnDetectBoth1.Name = "btnDetectBoth1";
            this.btnDetectBoth1.Size = new System.Drawing.Size(155, 23);
            this.btnDetectBoth1.TabIndex = 5;
            this.btnDetectBoth1.Text = "Detect device and key";
            this.btnDetectBoth1.UseVisualStyleBackColor = true;
            this.btnDetectBoth1.Click += new System.EventHandler(this.btnDetectBoth1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Or ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Key to map from:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source device:";
            // 
            // cmbDevice1
            // 
            this.cmbDevice1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevice1.FormattingEnabled = true;
            this.cmbDevice1.Location = new System.Drawing.Point(94, 19);
            this.cmbDevice1.Name = "cmbDevice1";
            this.cmbDevice1.Size = new System.Drawing.Size(520, 21);
            this.cmbDevice1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnMyComputer);
            this.groupBox2.Controls.Add(this.btnCalculator);
            this.groupBox2.Controls.Add(this.btnEmail);
            this.groupBox2.Controls.Add(this.btnMediaSelect);
            this.groupBox2.Controls.Add(this.btnVolDown);
            this.groupBox2.Controls.Add(this.btnVolUp);
            this.groupBox2.Controls.Add(this.btnMute);
            this.groupBox2.Controls.Add(this.btnPlayPause);
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Controls.Add(this.btnPreviousTrack);
            this.groupBox2.Controls.Add(this.btnNextTrack);
            this.groupBox2.Controls.Add(this.btnSetTo);
            this.groupBox2.Controls.Add(this.chkIgnore);
            this.groupBox2.Controls.Add(this.chkE1FlagTo);
            this.groupBox2.Controls.Add(this.chkE0FlagTo);
            this.groupBox2.Controls.Add(this.numSignalCodeTo);
            this.groupBox2.Controls.Add(this.lblKey2);
            this.groupBox2.Controls.Add(this.btnDetectKey2);
            this.groupBox2.Controls.Add(this.btnRefresh2);
            this.groupBox2.Controls.Add(this.btnDetectDevice2);
            this.groupBox2.Controls.Add(this.btnDetectBoth2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbDevice2);
            this.groupBox2.Location = new System.Drawing.Point(0, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(823, 210);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Map to:";
            // 
            // btnMyComputer
            // 
            this.btnMyComputer.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyComputer.Location = new System.Drawing.Point(179, 151);
            this.btnMyComputer.Name = "btnMyComputer";
            this.btnMyComputer.Size = new System.Drawing.Size(94, 31);
            this.btnMyComputer.TabIndex = 28;
            this.btnMyComputer.Text = "My Computer";
            this.btnMyComputer.UseVisualStyleBackColor = true;
            this.btnMyComputer.Click += new System.EventHandler(this.btnMyComputer_Click);
            // 
            // btnCalculator
            // 
            this.btnCalculator.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculator.Location = new System.Drawing.Point(97, 151);
            this.btnCalculator.Name = "btnCalculator";
            this.btnCalculator.Size = new System.Drawing.Size(76, 31);
            this.btnCalculator.TabIndex = 27;
            this.btnCalculator.Text = "Calculator";
            this.btnCalculator.UseVisualStyleBackColor = true;
            this.btnCalculator.Click += new System.EventHandler(this.btnCalculator_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmail.Location = new System.Drawing.Point(15, 151);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(76, 31);
            this.btnEmail.TabIndex = 26;
            this.btnEmail.Text = "Email";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // btnMediaSelect
            // 
            this.btnMediaSelect.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMediaSelect.Location = new System.Drawing.Point(635, 114);
            this.btnMediaSelect.Name = "btnMediaSelect";
            this.btnMediaSelect.Size = new System.Drawing.Size(95, 31);
            this.btnMediaSelect.TabIndex = 25;
            this.btnMediaSelect.Text = "Media Select";
            this.btnMediaSelect.UseVisualStyleBackColor = true;
            this.btnMediaSelect.Click += new System.EventHandler(this.btnMediaSelect_Click);
            // 
            // btnVolDown
            // 
            this.btnVolDown.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolDown.Location = new System.Drawing.Point(538, 114);
            this.btnVolDown.Name = "btnVolDown";
            this.btnVolDown.Size = new System.Drawing.Size(91, 31);
            this.btnVolDown.TabIndex = 24;
            this.btnVolDown.Text = "Volume Down";
            this.btnVolDown.UseVisualStyleBackColor = true;
            this.btnVolDown.Click += new System.EventHandler(this.btnVolDown_Click);
            // 
            // btnVolUp
            // 
            this.btnVolUp.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolUp.Location = new System.Drawing.Point(455, 114);
            this.btnVolUp.Name = "btnVolUp";
            this.btnVolUp.Size = new System.Drawing.Size(76, 31);
            this.btnVolUp.TabIndex = 23;
            this.btnVolUp.Text = "Volume Up";
            this.btnVolUp.UseVisualStyleBackColor = true;
            this.btnVolUp.Click += new System.EventHandler(this.btnVolUp_Click);
            // 
            // btnMute
            // 
            this.btnMute.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMute.Location = new System.Drawing.Point(373, 114);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(76, 31);
            this.btnMute.TabIndex = 22;
            this.btnMute.Text = "Mute";
            this.btnMute.UseVisualStyleBackColor = true;
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayPause.Location = new System.Drawing.Point(291, 114);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(76, 31);
            this.btnPlayPause.TabIndex = 21;
            this.btnPlayPause.Text = "Play/Pause";
            this.btnPlayPause.UseVisualStyleBackColor = true;
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(209, 114);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(76, 31);
            this.btnStop.TabIndex = 20;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPreviousTrack
            // 
            this.btnPreviousTrack.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviousTrack.Location = new System.Drawing.Point(97, 114);
            this.btnPreviousTrack.Name = "btnPreviousTrack";
            this.btnPreviousTrack.Size = new System.Drawing.Size(106, 31);
            this.btnPreviousTrack.TabIndex = 19;
            this.btnPreviousTrack.Text = "Previous Track";
            this.btnPreviousTrack.UseVisualStyleBackColor = true;
            this.btnPreviousTrack.Click += new System.EventHandler(this.btnPreviousTrack_Click);
            // 
            // btnNextTrack
            // 
            this.btnNextTrack.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextTrack.Location = new System.Drawing.Point(15, 114);
            this.btnNextTrack.Name = "btnNextTrack";
            this.btnNextTrack.Size = new System.Drawing.Size(76, 31);
            this.btnNextTrack.TabIndex = 17;
            this.btnNextTrack.Text = "Next Track";
            this.btnNextTrack.UseVisualStyleBackColor = true;
            this.btnNextTrack.Click += new System.EventHandler(this.btnNextTrack_Click);
            // 
            // btnSetTo
            // 
            this.btnSetTo.Location = new System.Drawing.Point(157, 44);
            this.btnSetTo.Name = "btnSetTo";
            this.btnSetTo.Size = new System.Drawing.Size(75, 23);
            this.btnSetTo.TabIndex = 16;
            this.btnSetTo.Text = "Set";
            this.btnSetTo.UseVisualStyleBackColor = true;
            this.btnSetTo.Click += new System.EventHandler(this.btnSetTo_Click);
            // 
            // chkIgnore
            // 
            this.chkIgnore.AutoSize = true;
            this.chkIgnore.Location = new System.Drawing.Point(388, 86);
            this.chkIgnore.Name = "chkIgnore";
            this.chkIgnore.Size = new System.Drawing.Size(106, 17);
            this.chkIgnore.TabIndex = 15;
            this.chkIgnore.Text = "Ignore Keystroke";
            this.chkIgnore.UseVisualStyleBackColor = true;
            this.chkIgnore.CheckedChanged += new System.EventHandler(this.chkIgnore_CheckedChanged);
            // 
            // chkE1FlagTo
            // 
            this.chkE1FlagTo.AutoSize = true;
            this.chkE1FlagTo.Location = new System.Drawing.Point(433, 49);
            this.chkE1FlagTo.Name = "chkE1FlagTo";
            this.chkE1FlagTo.Size = new System.Drawing.Size(39, 17);
            this.chkE1FlagTo.TabIndex = 14;
            this.chkE1FlagTo.Text = "E1";
            this.chkE1FlagTo.UseVisualStyleBackColor = true;
            // 
            // chkE0FlagTo
            // 
            this.chkE0FlagTo.AutoSize = true;
            this.chkE0FlagTo.Location = new System.Drawing.Point(388, 49);
            this.chkE0FlagTo.Name = "chkE0FlagTo";
            this.chkE0FlagTo.Size = new System.Drawing.Size(39, 17);
            this.chkE0FlagTo.TabIndex = 13;
            this.chkE0FlagTo.Text = "E0";
            this.chkE0FlagTo.UseVisualStyleBackColor = true;
            // 
            // numSignalCodeTo
            // 
            this.numSignalCodeTo.Location = new System.Drawing.Point(94, 46);
            this.numSignalCodeTo.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numSignalCodeTo.Name = "numSignalCodeTo";
            this.numSignalCodeTo.Size = new System.Drawing.Size(57, 20);
            this.numSignalCodeTo.TabIndex = 11;
            this.numSignalCodeTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblKey2
            // 
            this.lblKey2.AutoSize = true;
            this.lblKey2.Location = new System.Drawing.Point(238, 49);
            this.lblKey2.Name = "lblKey2";
            this.lblKey2.Size = new System.Drawing.Size(144, 13);
            this.lblKey2.TabIndex = 10;
            this.lblKey2.Text = "[ Detect or set a key to map ]";
            // 
            // btnDetectKey2
            // 
            this.btnDetectKey2.Location = new System.Drawing.Point(478, 44);
            this.btnDetectKey2.Name = "btnDetectKey2";
            this.btnDetectKey2.Size = new System.Drawing.Size(75, 23);
            this.btnDetectKey2.TabIndex = 8;
            this.btnDetectKey2.Text = "Detect";
            this.btnDetectKey2.UseVisualStyleBackColor = true;
            this.btnDetectKey2.Click += new System.EventHandler(this.btnDetectKey2_Click);
            // 
            // btnRefresh2
            // 
            this.btnRefresh2.Location = new System.Drawing.Point(701, 17);
            this.btnRefresh2.Name = "btnRefresh2";
            this.btnRefresh2.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh2.TabIndex = 7;
            this.btnRefresh2.Text = "Refresh";
            this.btnRefresh2.UseVisualStyleBackColor = true;
            this.btnRefresh2.Click += new System.EventHandler(this.btnRefresh2_Click);
            // 
            // btnDetectDevice2
            // 
            this.btnDetectDevice2.Location = new System.Drawing.Point(620, 17);
            this.btnDetectDevice2.Name = "btnDetectDevice2";
            this.btnDetectDevice2.Size = new System.Drawing.Size(75, 23);
            this.btnDetectDevice2.TabIndex = 6;
            this.btnDetectDevice2.Text = "Detect";
            this.btnDetectDevice2.UseVisualStyleBackColor = true;
            this.btnDetectDevice2.Click += new System.EventHandler(this.btnDetectDevice2_Click);
            // 
            // btnDetectBoth2
            // 
            this.btnDetectBoth2.Location = new System.Drawing.Point(94, 82);
            this.btnDetectBoth2.Name = "btnDetectBoth2";
            this.btnDetectBoth2.Size = new System.Drawing.Size(155, 23);
            this.btnDetectBoth2.TabIndex = 5;
            this.btnDetectBoth2.Text = "Detect device and key";
            this.btnDetectBoth2.UseVisualStyleBackColor = true;
            this.btnDetectBoth2.Click += new System.EventHandler(this.btnDetectBoth2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Or ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Key to map from:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Source device:";
            // 
            // cmbDevice2
            // 
            this.cmbDevice2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevice2.FormattingEnabled = true;
            this.cmbDevice2.Location = new System.Drawing.Point(94, 19);
            this.cmbDevice2.Name = "cmbDevice2";
            this.cmbDevice2.Size = new System.Drawing.Size(520, 21);
            this.cmbDevice2.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(655, 345);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(738, 345);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // MapSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 380);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MapSetup";
            this.Text = "Map Setup";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSignalCodeFrom)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSignalCodeTo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbDevice1;
        private System.Windows.Forms.Button btnRefresh1;
        private System.Windows.Forms.Button btnDetectDevice1;
        private System.Windows.Forms.Button btnDetectBoth1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDetectKey1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDetectKey2;
        private System.Windows.Forms.Button btnRefresh2;
        private System.Windows.Forms.Button btnDetectDevice2;
        private System.Windows.Forms.Button btnDetectBoth2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDevice2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblKey1;
        private System.Windows.Forms.Label lblKey2;
        private System.Windows.Forms.NumericUpDown numSignalCodeFrom;
        private System.Windows.Forms.NumericUpDown numSignalCodeTo;
        private System.Windows.Forms.CheckBox chkE1FlagFrom;
        private System.Windows.Forms.CheckBox chkE0FlagFrom;
        private System.Windows.Forms.CheckBox chkE1FlagTo;
        private System.Windows.Forms.CheckBox chkE0FlagTo;
        private System.Windows.Forms.CheckBox chkIgnore;
        private System.Windows.Forms.Button btnSetFrom;
        private System.Windows.Forms.Button btnSetTo;
        private System.Windows.Forms.Button btnMediaSelect;
        private System.Windows.Forms.Button btnVolDown;
        private System.Windows.Forms.Button btnVolUp;
        private System.Windows.Forms.Button btnMute;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPreviousTrack;
        private System.Windows.Forms.Button btnNextTrack;
        private System.Windows.Forms.Button btnMyComputer;
        private System.Windows.Forms.Button btnCalculator;
        private System.Windows.Forms.Button btnEmail;

    }
}