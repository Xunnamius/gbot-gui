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
            this.label2.Location = new System.Drawing.Point(12, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Execution Scheme:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 175);
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
            this.btnOk.Location = new System.Drawing.Point(125, 402);
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
            this.chbxEnableIntranodeForcedPause.Location = new System.Drawing.Point(185, 175);
            this.chbxEnableIntranodeForcedPause.Name = "chbxEnableIntranodeForcedPause";
            this.chbxEnableIntranodeForcedPause.Size = new System.Drawing.Size(15, 14);
            this.chbxEnableIntranodeForcedPause.TabIndex = 6;
            this.chbxEnableIntranodeForcedPause.UseVisualStyleBackColor = true;
            // 
            // cbInternodeEntropy
            // 
            this.cbInternodeEntropy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInternodeEntropy.FormattingEnabled = true;
            this.cbInternodeEntropy.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High"});
            this.cbInternodeEntropy.Location = new System.Drawing.Point(125, 20);
            this.cbInternodeEntropy.Name = "cbInternodeEntropy";
            this.cbInternodeEntropy.Size = new System.Drawing.Size(121, 21);
            this.cbInternodeEntropy.TabIndex = 7;
            // 
            // cbExecutionScheme
            // 
            this.cbExecutionScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExecutionScheme.FormattingEnabled = true;
            this.cbExecutionScheme.Items.AddRange(new object[] {
            "Ordered",
            "Priority",
            "Random"});
            this.cbExecutionScheme.Location = new System.Drawing.Point(125, 246);
            this.cbExecutionScheme.Name = "cbExecutionScheme";
            this.cbExecutionScheme.Size = new System.Drawing.Size(121, 21);
            this.cbExecutionScheme.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(15, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(297, 42);
            this.label5.TabIndex = 9;
            this.label5.Text = "Entropy determines the approximate amount of time that will be \"wasted\" when swit" +
    "ching between nodes using your chosen Execution Scheme (below).";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(297, 29);
            this.label6.TabIndex = 10;
            this.label6.Text = "This setting will determine if the node-specific entropy settings will be ignored" +
    " or not. Not checked = ignored.";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(297, 29);
            this.label7.TabIndex = 11;
            this.label7.Text = "This setting will determine if the node-specific force pause settings will be ign" +
    "ored or not. Not checked = ignored.";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(12, 278);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(297, 95);
            this.label8.TabIndex = 12;
            this.label8.Text = resources.GetString("label8.Text");
            // 
            // GBGApplicationSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 437);
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
            this.Name = "GBGApplicationSettings";
            this.Text = "GBGApplicationSettings";
            this.Load += new System.EventHandler(this.GBGApplicationSettings_Load);
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
    }
}