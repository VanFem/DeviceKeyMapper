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
            this.btnDetectKey1 = new System.Windows.Forms.Button();
            this.btnRefresh1 = new System.Windows.Forms.Button();
            this.btnDetectDevice1 = new System.Windows.Forms.Button();
            this.btnDetectBoth1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDevice1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.lblKey1 = new System.Windows.Forms.Label();
            this.lblKey2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
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
            this.groupBox1.Size = new System.Drawing.Size(783, 123);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Map from:";
            // 
            // btnDetectKey1
            // 
            this.btnDetectKey1.Location = new System.Drawing.Point(94, 46);
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
            this.groupBox2.Size = new System.Drawing.Size(782, 123);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Map to:";
            // 
            // btnDetectKey2
            // 
            this.btnDetectKey2.Location = new System.Drawing.Point(94, 46);
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
            this.btnOK.Location = new System.Drawing.Point(620, 258);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(701, 258);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblKey1
            // 
            this.lblKey1.AutoSize = true;
            this.lblKey1.Location = new System.Drawing.Point(175, 51);
            this.lblKey1.Name = "lblKey1";
            this.lblKey1.Size = new System.Drawing.Size(118, 13);
            this.lblKey1.TabIndex = 9;
            this.lblKey1.Text = " [ Detect a key to map ]";
            // 
            // lblKey2
            // 
            this.lblKey2.AutoSize = true;
            this.lblKey2.Location = new System.Drawing.Point(178, 51);
            this.lblKey2.Name = "lblKey2";
            this.lblKey2.Size = new System.Drawing.Size(115, 13);
            this.lblKey2.TabIndex = 10;
            this.lblKey2.Text = "[ Detect a key to map ]";
            // 
            // MapSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 293);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MapSetup";
            this.Text = "Map Setup";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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

    }
}