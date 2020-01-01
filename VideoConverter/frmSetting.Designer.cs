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
            ((System.ComponentModel.ISupportInitialize)(this.nudTaskParallelLimit)).BeginInit();
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
            this.chkEnableDebug.Location = new System.Drawing.Point(14, 75);
            this.chkEnableDebug.Name = "chkEnableDebug";
            this.chkEnableDebug.Size = new System.Drawing.Size(96, 16);
            this.chkEnableDebug.TabIndex = 29;
            this.chkEnableDebug.Text = "Enable debug";
            this.chkEnableDebug.UseVisualStyleBackColor = true;
            // 
            // chkEnableLog
            // 
            this.chkEnableLog.AutoSize = true;
            this.chkEnableLog.Location = new System.Drawing.Point(14, 39);
            this.chkEnableLog.Name = "chkEnableLog";
            this.chkEnableLog.Size = new System.Drawing.Size(84, 16);
            this.chkEnableLog.TabIndex = 28;
            this.chkEnableLog.Text = "Enable log";
            this.chkEnableLog.UseVisualStyleBackColor = true;
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 173);
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
    }
}