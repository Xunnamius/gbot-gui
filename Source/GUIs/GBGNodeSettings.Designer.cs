namespace GameBotGUI
{
    partial class GBGNodeSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GBGNodeSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chbxEnabled = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.cbPriority = new System.Windows.Forms.ComboBox();
            this.numLRuns = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cbMouseSpeed = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numLOffsetX = new System.Windows.Forms.NumericUpDown();
            this.numLOffsetY = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numLRuns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLOffsetY)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enabled:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 302);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mouse Speed:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Runs:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Priority:";
            // 
            // chbxEnabled
            // 
            this.chbxEnabled.AutoSize = true;
            this.chbxEnabled.Checked = true;
            this.chbxEnabled.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chbxEnabled.Location = new System.Drawing.Point(66, 25);
            this.chbxEnabled.Name = "chbxEnabled";
            this.chbxEnabled.Size = new System.Drawing.Size(15, 14);
            this.chbxEnabled.TabIndex = 4;
            this.chbxEnabled.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(105, 468);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Save";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cbPriority
            // 
            this.cbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPriority.Enabled = false;
            this.cbPriority.FormattingEnabled = true;
            this.cbPriority.Location = new System.Drawing.Point(66, 95);
            this.cbPriority.Name = "cbPriority";
            this.cbPriority.Size = new System.Drawing.Size(121, 21);
            this.cbPriority.TabIndex = 6;
            // 
            // numLRuns
            // 
            this.numLRuns.Location = new System.Drawing.Point(66, 216);
            this.numLRuns.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numLRuns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLRuns.Name = "numLRuns";
            this.numLRuns.Size = new System.Drawing.Size(74, 20);
            this.numLRuns.TabIndex = 7;
            this.numLRuns.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "total execution(s)";
            // 
            // cbMouseSpeed
            // 
            this.cbMouseSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMouseSpeed.FormattingEnabled = true;
            this.cbMouseSpeed.Location = new System.Drawing.Point(94, 299);
            this.cbMouseSpeed.Name = "cbMouseSpeed";
            this.cbMouseSpeed.Size = new System.Drawing.Size(121, 21);
            this.cbMouseSpeed.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(257, 35);
            this.label6.TabIndex = 10;
            this.label6.Text = "Disabling this node will make it as if it doesn\'t even exist. You\'ll be able to r" +
    "e-enable it later if you so wish.";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(257, 69);
            this.label7.TabIndex = 11;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(12, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(257, 31);
            this.label8.TabIndex = 12;
            this.label8.Text = "Runs represents the number of times this node will be run before moving on to the" +
    " next node.";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(12, 326);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(257, 45);
            this.label9.TabIndex = 13;
            this.label9.Text = "Mouse speed represents how fast mouse-related actions will be executed. \"Random\" " +
    "is recommended.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 394);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Local Offset:";
            // 
            // numLOffsetX
            // 
            this.numLOffsetX.Location = new System.Drawing.Point(94, 391);
            this.numLOffsetX.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numLOffsetX.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.numLOffsetX.Name = "numLOffsetX";
            this.numLOffsetX.Size = new System.Drawing.Size(50, 20);
            this.numLOffsetX.TabIndex = 15;
            // 
            // numLOffsetY
            // 
            this.numLOffsetY.Location = new System.Drawing.Point(178, 391);
            this.numLOffsetY.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numLOffsetY.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.numLOffsetY.Name = "numLOffsetY";
            this.numLOffsetY.Size = new System.Drawing.Size(50, 20);
            this.numLOffsetY.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(147, 396);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "X";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(231, 396);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Y";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(12, 417);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(257, 31);
            this.label13.TabIndex = 20;
            this.label13.Text = "The local offset will apply to and summarily shift all mouse click records within" +
    " this node.";
            // 
            // GBGNodeSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 503);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.numLOffsetY);
            this.Controls.Add(this.numLOffsetX);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbMouseSpeed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numLRuns);
            this.Controls.Add(this.cbPriority);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chbxEnabled);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GBGNodeSettings";
            this.Text = "GBGNodeSettings";
            this.Load += new System.EventHandler(this.GBGNodeSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numLRuns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLOffsetY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chbxEnabled;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cbPriority;
        private System.Windows.Forms.NumericUpDown numLRuns;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbMouseSpeed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numLOffsetX;
        private System.Windows.Forms.NumericUpDown numLOffsetY;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
    }
}