namespace GameBotGUI
{
    partial class GBGNodeCreateModify
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
            if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GBGNodeCreateModify));
            this.label1 = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.btnNodeSettings = new System.Windows.Forms.Button();
            this.btnTimeSettings = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnModifyRecord = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDeleteRecord = new System.Windows.Forms.Button();
            this.btnCaptureClicks = new System.Windows.Forms.Button();
            this.lbRecords = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(57, 10);
            this.txbName.MaxLength = 75;
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(232, 20);
            this.txbName.TabIndex = 1;
            // 
            // btnNodeSettings
            // 
            this.btnNodeSettings.Location = new System.Drawing.Point(9, 288);
            this.btnNodeSettings.Name = "btnNodeSettings";
            this.btnNodeSettings.Size = new System.Drawing.Size(138, 27);
            this.btnNodeSettings.TabIndex = 2;
            this.btnNodeSettings.Text = "Node Settings";
            this.btnNodeSettings.UseVisualStyleBackColor = true;
            this.btnNodeSettings.Click += new System.EventHandler(this.btnNodeSettings_Click);
            // 
            // btnTimeSettings
            // 
            this.btnTimeSettings.Location = new System.Drawing.Point(153, 288);
            this.btnTimeSettings.Name = "btnTimeSettings";
            this.btnTimeSettings.Size = new System.Drawing.Size(138, 27);
            this.btnTimeSettings.TabIndex = 3;
            this.btnTimeSettings.Text = "Time Settings";
            this.btnTimeSettings.UseVisualStyleBackColor = true;
            this.btnTimeSettings.Click += new System.EventHandler(this.btnTimeSettings_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMoveDown);
            this.groupBox1.Controls.Add(this.btnMoveUp);
            this.groupBox1.Controls.Add(this.btnModifyRecord);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnDeleteRecord);
            this.groupBox1.Controls.Add(this.btnCaptureClicks);
            this.groupBox1.Controls.Add(this.lbRecords);
            this.groupBox1.Location = new System.Drawing.Point(9, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 237);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Node Controls";
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Enabled = false;
            this.btnMoveDown.Location = new System.Drawing.Point(7, 206);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(89, 23);
            this.btnMoveDown.TabIndex = 7;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Enabled = false;
            this.btnMoveUp.Location = new System.Drawing.Point(7, 176);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(89, 23);
            this.btnMoveUp.TabIndex = 6;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnModifyRecord
            // 
            this.btnModifyRecord.Enabled = false;
            this.btnModifyRecord.Location = new System.Drawing.Point(187, 206);
            this.btnModifyRecord.Name = "btnModifyRecord";
            this.btnModifyRecord.Size = new System.Drawing.Size(89, 23);
            this.btnModifyRecord.TabIndex = 5;
            this.btnModifyRecord.Text = "Modify Record";
            this.btnModifyRecord.UseVisualStyleBackColor = true;
            this.btnModifyRecord.Click += new System.EventHandler(this.btnModifyRecord_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(97, 206);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(89, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(97, 176);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(89, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDeleteRecord
            // 
            this.btnDeleteRecord.Enabled = false;
            this.btnDeleteRecord.Location = new System.Drawing.Point(187, 176);
            this.btnDeleteRecord.Name = "btnDeleteRecord";
            this.btnDeleteRecord.Size = new System.Drawing.Size(89, 23);
            this.btnDeleteRecord.TabIndex = 2;
            this.btnDeleteRecord.Text = "Delete Record";
            this.btnDeleteRecord.UseVisualStyleBackColor = true;
            this.btnDeleteRecord.Click += new System.EventHandler(this.btnDeleteRecord_Click);
            // 
            // btnCaptureClicks
            // 
            this.btnCaptureClicks.Location = new System.Drawing.Point(6, 147);
            this.btnCaptureClicks.Name = "btnCaptureClicks";
            this.btnCaptureClicks.Size = new System.Drawing.Size(270, 23);
            this.btnCaptureClicks.TabIndex = 1;
            this.btnCaptureClicks.Text = "Capture Clicks";
            this.btnCaptureClicks.UseVisualStyleBackColor = true;
            this.btnCaptureClicks.Click += new System.EventHandler(this.btnCaptureClicks_Click);
            // 
            // lbRecords
            // 
            this.lbRecords.FormattingEnabled = true;
            this.lbRecords.Location = new System.Drawing.Point(7, 20);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(269, 121);
            this.lbRecords.TabIndex = 0;
            this.lbRecords.SelectedValueChanged += new System.EventHandler(this.lbRecords_SelectedValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(9, 324);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(282, 27);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // GBGNodeCreateModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 358);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTimeSettings);
            this.Controls.Add(this.btnNodeSettings);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GBGNodeCreateModify";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GBGNodeCreateModify_FormClosing);
            this.Load += new System.EventHandler(this.GBGCreateAndModify_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.Button btnNodeSettings;
        private System.Windows.Forms.Button btnTimeSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDeleteRecord;
        private System.Windows.Forms.Button btnCaptureClicks;
        private System.Windows.Forms.ListBox lbRecords;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnModifyRecord;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnMoveDown;
    }
}