namespace VideoConverter
{
    partial class frmSetting
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.nudTaskParallelLimit = new System.Windows.Forms.NumericUpDown();
            this.chkEnableDebug = new System.Windows.Forms.CheckBox();
            this.chkEnableLog = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudThreadNumber = new System.Windows.Forms.NumericUpDown();
            this.chkUseDefaultThreadNumber = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudTaskParallelLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreadNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(449, 138);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(368, 138);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "Task Parallel Number:";
            // 
            // nudTaskParallelLimit
            // 
            this.nudTaskParallelLimit.Location = new System.Drawing.Point(149, 7);
            this.nudTaskParallelLimit.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudTaskParallelLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTaskParallelLimit.Name = "nudTaskParallelLimit";
            this.nudTaskParallelLimit.Size = new System.Drawing.Size(50, 21);
            this.nudTaskParallelLimit.TabIndex = 26;
            this.nudTaskParallelLimit.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // chkEnableDebug
            // 
            this.chkEnableDebug.AutoSize = true;
            this.chkEnableDebug.Location = new System.Drawing.Point(14, 112);
            this.chkEnableDebug.Name = "chkEnableDebug";
            this.chkEnableDebug.Size = new System.Drawing.Size(96, 16);
            this.chkEnableDebug.TabIndex = 29;
            this.chkEnableDebug.Text = "Enable Debug";
            this.chkEnableDebug.UseVisualStyleBackColor = true;
            // 
            // chkEnableLog
            // 
            this.chkEnableLog.AutoSize = true;
            this.chkEnableLog.Location = new System.Drawing.Point(14, 76);
            this.chkEnableLog.Name = "chkEnableLog";
            this.chkEnableLog.Size = new System.Drawing.Size(84, 16);
            this.chkEnableLog.TabIndex = 28;
            this.chkEnableLog.Text = "Enable Log";
            this.chkEnableLog.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(157, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 12);
            this.label9.TabIndex = 40;
            this.label9.Text = "for each process";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 39;
            this.label1.Text = "Thread number:";
            // 
            // nudThreadNumber
            // 
            this.nudThreadNumber.Location = new System.Drawing.Point(103, 40);
            this.nudThreadNumber.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudThreadNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThreadNumber.Name = "nudThreadNumber";
            this.nudThreadNumber.Size = new System.Drawing.Size(45, 21);
            this.nudThreadNumber.TabIndex = 38;
            this.nudThreadNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkUseDefaultThreadNumber
            // 
            this.chkUseDefaultThreadNumber.AutoSize = true;
            this.chkUseDefaultThreadNumber.Location = new System.Drawing.Point(282, 45);
            this.chkUseDefaultThreadNumber.Name = "chkUseDefaultThreadNumber";
            this.chkUseDefaultThreadNumber.Size = new System.Drawing.Size(90, 16);
            this.chkUseDefaultThreadNumber.TabIndex = 41;
            this.chkUseDefaultThreadNumber.Text = "Use default";
            this.chkUseDefaultThreadNumber.UseVisualStyleBackColor = true;
            this.chkUseDefaultThreadNumber.CheckedChanged += new System.EventHandler(this.chkUseDefaultThreadNumber_CheckedChanged);
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 173);
            this.Controls.Add(this.chkUseDefaultThreadNumber);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudThreadNumber);
            this.Controls.Add(this.chkEnableDebug);
            this.Controls.Add(this.chkEnableLog);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nudTaskParallelLimit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.MinimizeBox = false;
            this.Name = "frmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudTaskParallelLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreadNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudTaskParallelLimit;
        private System.Windows.Forms.CheckBox chkEnableDebug;
        private System.Windows.Forms.CheckBox chkEnableLog;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudThreadNumber;
        private System.Windows.Forms.CheckBox chkUseDefaultThreadNumber;
    }
}