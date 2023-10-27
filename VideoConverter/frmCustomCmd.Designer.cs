namespace VideoConverter
{
    partial class frmCustomCmd
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
            this.txtCmd = new System.Windows.Forms.RichTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSourceFilePath = new System.Windows.Forms.Button();
            this.btnTargetFilePath = new System.Windows.Forms.Button();
            this.lnkReferences = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.btnOption = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Content:";
            // 
            // txtCmd
            // 
            this.txtCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCmd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCmd.Location = new System.Drawing.Point(69, 35);
            this.txtCmd.Name = "txtCmd";
            this.txtCmd.Size = new System.Drawing.Size(797, 85);
            this.txtCmd.TabIndex = 1;
            this.txtCmd.Text = "";
            this.txtCmd.TextChanged += new System.EventHandler(this.txtCmd_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(697, 158);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(794, 158);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSourceFilePath
            // 
            this.btnSourceFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSourceFilePath.Location = new System.Drawing.Point(69, 126);
            this.btnSourceFilePath.Name = "btnSourceFilePath";
            this.btnSourceFilePath.Size = new System.Drawing.Size(135, 23);
            this.btnSourceFilePath.TabIndex = 4;
            this.btnSourceFilePath.Text = "Source File Name";
            this.btnSourceFilePath.UseVisualStyleBackColor = true;
            this.btnSourceFilePath.Click += new System.EventHandler(this.btnSourceFilePath_Click);
            // 
            // btnTargetFilePath
            // 
            this.btnTargetFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTargetFilePath.Location = new System.Drawing.Point(223, 126);
            this.btnTargetFilePath.Name = "btnTargetFilePath";
            this.btnTargetFilePath.Size = new System.Drawing.Size(135, 23);
            this.btnTargetFilePath.TabIndex = 5;
            this.btnTargetFilePath.Text = "Target File Name";
            this.btnTargetFilePath.UseVisualStyleBackColor = true;
            this.btnTargetFilePath.Click += new System.EventHandler(this.btnTargetFilePath_Click);
            // 
            // lnkReferences
            // 
            this.lnkReferences.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkReferences.AutoSize = true;
            this.lnkReferences.Location = new System.Drawing.Point(147, 168);
            this.lnkReferences.Name = "lnkReferences";
            this.lnkReferences.Size = new System.Drawing.Size(269, 12);
            this.lnkReferences.TabIndex = 6;
            this.lnkReferences.TabStop = true;
            this.lnkReferences.Text = "https://ffmpeg.org/ffmpeg.html#Video-Options";
            this.lnkReferences.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReferences_LinkClicked);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "References:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Type:";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(69, 6);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(121, 20);
            this.cboType.TabIndex = 9;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // btnOption
            // 
            this.btnOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOption.Location = new System.Drawing.Point(791, 126);
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(75, 23);
            this.btnOption.TabIndex = 10;
            this.btnOption.Text = "Option";
            this.btnOption.UseVisualStyleBackColor = true;
            this.btnOption.Visible = false;
            this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // frmCustomCmd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 189);
            this.Controls.Add(this.btnOption);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lnkReferences);
            this.Controls.Add(this.btnTargetFilePath);
            this.Controls.Add(this.btnSourceFilePath);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtCmd);
            this.Controls.Add(this.label1);
            this.Name = "frmCustomCmd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custom Command";
            this.Load += new System.EventHandler(this.frmCustomCmd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtCmd;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSourceFilePath;
        private System.Windows.Forms.Button btnTargetFilePath;
        private System.Windows.Forms.LinkLabel lnkReferences;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Button btnOption;
    }
}