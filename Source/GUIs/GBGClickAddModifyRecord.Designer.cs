namespace GameBotGUI
{
    partial class GBGClickAddModifyRecord
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.cbRecordType = new System.Windows.Forms.ComboBox();
            this.lblX = new System.Windows.Forms.Label();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.lblY = new System.Windows.Forms.Label();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.lblMilliseconds = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Record Type:";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(12, 68);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(33, 13);
            this.lblData.TabIndex = 1;
            this.lblData.Text = "Data:";
            this.lblData.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(105, 104);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Save";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cbRecordType
            // 
            this.cbRecordType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRecordType.FormattingEnabled = true;
            this.cbRecordType.Location = new System.Drawing.Point(90, 21);
            this.cbRecordType.Name = "cbRecordType";
            this.cbRecordType.Size = new System.Drawing.Size(121, 21);
            this.cbRecordType.TabIndex = 4;
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(69, 68);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(14, 13);
            this.lblX.TabIndex = 5;
            this.lblX.Text = "X";
            this.lblX.Visible = false;
            // 
            // numX
            // 
            this.numX.Location = new System.Drawing.Point(85, 65);
            this.numX.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numX.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(67, 20);
            this.numX.TabIndex = 6;
            this.numX.Visible = false;
            // 
            // numY
            // 
            this.numY.Location = new System.Drawing.Point(182, 65);
            this.numY.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numY.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(67, 20);
            this.numY.TabIndex = 8;
            this.numY.Visible = false;
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(166, 68);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(14, 13);
            this.lblY.TabIndex = 7;
            this.lblY.Text = "Y";
            this.lblY.Visible = false;
            // 
            // numDuration
            // 
            this.numDuration.Location = new System.Drawing.Point(51, 65);
            this.numDuration.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(120, 20);
            this.numDuration.TabIndex = 9;
            this.numDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDuration.Visible = false;
            // 
            // lblMilliseconds
            // 
            this.lblMilliseconds.AutoSize = true;
            this.lblMilliseconds.Location = new System.Drawing.Point(176, 68);
            this.lblMilliseconds.Name = "lblMilliseconds";
            this.lblMilliseconds.Size = new System.Drawing.Size(63, 13);
            this.lblMilliseconds.TabIndex = 10;
            this.lblMilliseconds.Text = "milliseconds";
            this.lblMilliseconds.Visible = false;
            // 
            // GBGClickAddModifyRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 139);
            this.Controls.Add(this.lblMilliseconds);
            this.Controls.Add(this.numDuration);
            this.Controls.Add(this.numY);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.numX);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.cbRecordType);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GBGClickAddModifyRecord";
            this.Load += new System.EventHandler(this.GBGClickAddModifyRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cbRecordType;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.Label lblMilliseconds;
    }
}