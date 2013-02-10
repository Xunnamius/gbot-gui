namespace GameBotGUI
{
    partial class GBGTimeSettings
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
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEntropy = new System.Windows.Forms.ComboBox();
            this.numForcedPause = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numForcedPause)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(105, 227);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Save";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Entropy:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Forced Pause:";
            // 
            // cbEntropy
            // 
            this.cbEntropy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEntropy.FormattingEnabled = true;
            this.cbEntropy.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High",
            "Disabled"});
            this.cbEntropy.Location = new System.Drawing.Point(65, 22);
            this.cbEntropy.Name = "cbEntropy";
            this.cbEntropy.Size = new System.Drawing.Size(121, 21);
            this.cbEntropy.TabIndex = 3;
            // 
            // numForcedPause
            // 
            this.numForcedPause.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numForcedPause.Location = new System.Drawing.Point(95, 128);
            this.numForcedPause.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numForcedPause.Name = "numForcedPause";
            this.numForcedPause.Size = new System.Drawing.Size(91, 20);
            this.numForcedPause.TabIndex = 4;
            this.numForcedPause.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "milliseconds";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(256, 58);
            this.label4.TabIndex = 6;
            this.label4.Text = "Entropy determines the approximate amount of time that will be \"wasted\" between e" +
    "ach action that makes up the body of this node. A great defence against anti-bot" +
    " scripts!";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(13, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(256, 58);
            this.label5.TabIndex = 7;
            this.label5.Text = "Forced Pause determines the MINIMUM amount of time that will be \"wasted\" between " +
    "each action. Stacks with Entropy.";
            // 
            // GBGTimeSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numForcedPause);
            this.Controls.Add(this.cbEntropy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.Name = "GBGTimeSettings";
            this.Text = "GBGTimeSettings";
            this.Load += new System.EventHandler(this.GBGTimeSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numForcedPause)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbEntropy;
        private System.Windows.Forms.NumericUpDown numForcedPause;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}