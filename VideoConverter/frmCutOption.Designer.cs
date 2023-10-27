namespace VideoConverter
{
    partial class frmCutOption
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.dtpStarting = new System.Windows.Forms.DateTimePicker();
            this.dtpDuration = new System.Windows.Forms.DateTimePicker();
            this.btnOK = new System.Windows.Forms.Button();
            this.rbReserve = new System.Windows.Forms.RadioButton();
            this.rbOutroToRemove = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Starting:";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(12, 58);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(59, 12);
            this.lblDuration.TabIndex = 1;
            this.lblDuration.Text = "Duration:";
            // 
            // dtpStarting
            // 
            this.dtpStarting.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStarting.Location = new System.Drawing.Point(77, 17);
            this.dtpStarting.MaxDate = new System.DateTime(2090, 10, 26, 0, 0, 0, 0);
            this.dtpStarting.Name = "dtpStarting";
            this.dtpStarting.ShowUpDown = true;
            this.dtpStarting.Size = new System.Drawing.Size(93, 21);
            this.dtpStarting.TabIndex = 3;
            this.dtpStarting.Value = new System.DateTime(2023, 10, 26, 0, 0, 0, 0);
            // 
            // dtpDuration
            // 
            this.dtpDuration.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpDuration.Location = new System.Drawing.Point(77, 54);
            this.dtpDuration.MaxDate = new System.DateTime(2090, 10, 26, 0, 0, 0, 0);
            this.dtpDuration.Name = "dtpDuration";
            this.dtpDuration.ShowUpDown = true;
            this.dtpDuration.Size = new System.Drawing.Size(93, 21);
            this.dtpDuration.TabIndex = 4;
            this.dtpDuration.Value = new System.DateTime(2023, 10, 26, 0, 0, 0, 0);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(367, 109);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rbReserve
            // 
            this.rbReserve.AutoSize = true;
            this.rbReserve.Checked = true;
            this.rbReserve.Location = new System.Drawing.Point(191, 58);
            this.rbReserve.Name = "rbReserve";
            this.rbReserve.Size = new System.Drawing.Size(65, 16);
            this.rbReserve.TabIndex = 6;
            this.rbReserve.TabStop = true;
            this.rbReserve.Text = "Reserve";
            this.rbReserve.UseVisualStyleBackColor = true;
            // 
            // rbOutroToRemove
            // 
            this.rbOutroToRemove.AutoSize = true;
            this.rbOutroToRemove.Location = new System.Drawing.Point(273, 58);
            this.rbOutroToRemove.Name = "rbOutroToRemove";
            this.rbOutroToRemove.Size = new System.Drawing.Size(113, 16);
            this.rbOutroToRemove.TabIndex = 7;
            this.rbOutroToRemove.Text = "Outro to remove";
            this.rbOutroToRemove.UseVisualStyleBackColor = true;
            // 
            // frmCutOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 144);
            this.Controls.Add(this.rbOutroToRemove);
            this.Controls.Add(this.rbReserve);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dtpDuration);
            this.Controls.Add(this.dtpStarting);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmCutOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cut Option";
            this.Load += new System.EventHandler(this.frmCutOption_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.DateTimePicker dtpStarting;
        private System.Windows.Forms.DateTimePicker dtpDuration;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton rbReserve;
        private System.Windows.Forms.RadioButton rbOutroToRemove;
    }
}