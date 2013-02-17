namespace GameBotGUI
{
    partial class GBGApplicationSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GBGApplicationSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.chbxEnableIntranodeEntropy = new System.Windows.Forms.CheckBox();
            this.chbxEnableIntranodeForcedPause = new System.Windows.Forms.CheckBox();
            this.cbInternodeEntropy = new System.Windows.Forms.ComboBox();
            this.cbExecutionScheme = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.numGOffsetY = new System.Windows.Forms.NumericUpDown();
            this.numGOffsetX = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chbxMinimizeOnRun = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.numGlobalRuns = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.chbxRunIndefinitely = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numGOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGlobalRuns)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Internode Entropy:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Execution Scheme:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Enable Intranode Forced Pause:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Enable Intranode Entropy:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(125, 546);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Save";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chbxEnableIntranodeEntropy
            // 
            this.chbxEnableIntranodeEntropy.AutoSize = true;
            this.chbxEnableIntranodeEntropy.Checked = true;
            this.chbxEnableIntranodeEntropy.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chbxEnableIntranodeEntropy.Location = new System.Drawing.Point(185, 105);
            this.chbxEnableIntranodeEntropy.Name = "chbxEnableIntranodeEntropy";
            this.chbxEnableIntranodeEntropy.Size = new System.Drawing.Size(15, 14);
            this.chbxEnableIntranodeEntropy.TabIndex = 5;
            this.chbxEnableIntranodeEntropy.UseVisualStyleBackColor = true;
            // 
            // chbxEnableIntranodeForcedPause
            // 
            this.chbxEnableIntranodeForcedPause.AutoSize = true;
            this.chbxEnableIntranodeForcedPause.Checked = true;
            this.chbxEnableIntranodeForcedPause.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chbxEnableIntranodeForcedPause.Location = new System.Drawing.Point(185, 168);
            this.chbxEnableIntranodeForcedPause.Name = "chbxEnableIntranodeForcedPause";
            this.chbxEnableIntranodeForcedPause.Size = new System.Drawing.Size(15, 14);
            this.chbxEnableIntranodeForcedPause.TabIndex = 6;
            this.chbxEnableIntranodeForcedPause.UseVisualStyleBackColor = true;
            // 
            // cbInternodeEntropy
            // 
            this.cbInternodeEntropy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInternodeEntropy.FormattingEnabled = true;
            this.cbInternodeEntropy.Location = new System.Drawing.Point(125, 20);
            this.cbInternodeEntropy.Name = "cbInternodeEntropy";
            this.cbInternodeEntropy.Size = new System.Drawing.Size(121, 21);
            this.cbInternodeEntropy.TabIndex = 7;
            // 
            // cbExecutionScheme
            // 
            this.cbExecutionScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExecutionScheme.Enabled = false;
            this.cbExecutionScheme.FormattingEnabled = true;
            this.cbExecutionScheme.Location = new System.Drawing.Point(125, 233);
            this.cbExecutionScheme.Name = "cbExecutionScheme";
            this.cbExecutionScheme.Size = new System.Drawing.Size(121, 21);
            this.cbExecutionScheme.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(297, 42);
            this.label5.TabIndex = 9;
            this.label5.Text = "Entropy determines the approximate amount of time that will be \"wasted\" when swit" +
    "ching between nodes using your chosen Execution Scheme (below).";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(297, 29);
            this.label6.TabIndex = 10;
            this.label6.Text = "This setting will determine if the node-specific entropy settings will be ignored" +
    " (disabled) or not. Not checked = disabled.";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(297, 29);
            this.label7.TabIndex = 11;
            this.label7.Text = "This setting will determine if the node-specific pause settings will be ignored (" +
    "disabled) or not. Not checked = disabled.";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(12, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(297, 95);
            this.label8.TabIndex = 12;
            this.label8.Text = resources.GetString("label8.Text");
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(12, 395);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(297, 31);
            this.label13.TabIndex = 26;
            this.label13.Text = "The global offset will apply to and summarily shift all mouse click records withi" +
    "n every single node without exception.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(231, 374);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Y";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(147, 374);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "X";
            // 
            // numGOffsetY
            // 
            this.numGOffsetY.Location = new System.Drawing.Point(178, 369);
            this.numGOffsetY.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numGOffsetY.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.numGOffsetY.Name = "numGOffsetY";
            this.numGOffsetY.Size = new System.Drawing.Size(50, 20);
            this.numGOffsetY.TabIndex = 23;
            // 
            // numGOffsetX
            // 
            this.numGOffsetX.Location = new System.Drawing.Point(94, 369);
            this.numGOffsetX.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numGOffsetX.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.numGOffsetX.Name = "numGOffsetX";
            this.numGOffsetX.Size = new System.Drawing.Size(50, 20);
            this.numGOffsetX.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 372);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Global Offset:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 512);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Minimize Window on Run:";
            // 
            // chbxMinimizeOnRun
            // 
            this.chbxMinimizeOnRun.AutoSize = true;
            this.chbxMinimizeOnRun.Checked = true;
            this.chbxMinimizeOnRun.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chbxMinimizeOnRun.Location = new System.Drawing.Point(185, 512);
            this.chbxMinimizeOnRun.Name = "chbxMinimizeOnRun";
            this.chbxMinimizeOnRun.Size = new System.Drawing.Size(15, 14);
            this.chbxMinimizeOnRun.TabIndex = 28;
            this.chbxMinimizeOnRun.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(12, 467);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(297, 31);
            this.label14.TabIndex = 31;
            this.label14.Text = "The global offset will apply to and summarily shift all mouse click records withi" +
    "n every single node without exception.";
            // 
            // numGlobalRuns
            // 
            this.numGlobalRuns.Enabled = false;
            this.numGlobalRuns.Location = new System.Drawing.Point(94, 441);
            this.numGlobalRuns.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numGlobalRuns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGlobalRuns.Name = "numGlobalRuns";
            this.numGlobalRuns.Size = new System.Drawing.Size(68, 20);
            this.numGlobalRuns.TabIndex = 30;
            this.numGlobalRuns.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 444);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Global Runs:";
            // 
            // chbxRunIndefinitely
            // 
            this.chbxRunIndefinitely.AutoSize = true;
            this.chbxRunIndefinitely.Checked = true;
            this.chbxRunIndefinitely.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chbxRunIndefinitely.Location = new System.Drawing.Point(195, 444);
            this.chbxRunIndefinitely.Name = "chbxRunIndefinitely";
            this.chbxRunIndefinitely.Size = new System.Drawing.Size(99, 17);
            this.chbxRunIndefinitely.TabIndex = 32;
            this.chbxRunIndefinitely.Text = "Run Indefinitely";
            this.chbxRunIndefinitely.UseVisualStyleBackColor = true;
            this.chbxRunIndefinitely.CheckedChanged += new System.EventHandler(this.chbxRunIndefinitely_CheckedChanged);
            // 
            // GBGApplicationSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 581);
            this.Controls.Add(this.chbxRunIndefinitely);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.numGlobalRuns);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.chbxMinimizeOnRun);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.numGOffsetY);
            this.Controls.Add(this.numGOffsetX);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbExecutionScheme);
            this.Controls.Add(this.cbInternodeEntropy);
            this.Controls.Add(this.chbxEnableIntranodeForcedPause);
            this.Controls.Add(this.chbxEnableIntranodeEntropy);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GBGApplicationSettings";
            this.Text = "GBGApplicationSettings";
            this.Load += new System.EventHandler(this.GBGApplicationSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numGOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGlobalRuns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox chbxEnableIntranodeEntropy;
        private System.Windows.Forms.CheckBox chbxEnableIntranodeForcedPause;
        private System.Windows.Forms.ComboBox cbInternodeEntropy;
        private System.Windows.Forms.ComboBox cbExecutionScheme;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numGOffsetY;
        private System.Windows.Forms.NumericUpDown numGOffsetX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chbxMinimizeOnRun;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numGlobalRuns;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chbxRunIndefinitely;
    }
}