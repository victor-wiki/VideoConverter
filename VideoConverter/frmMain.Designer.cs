namespace VideoConverter
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSaveFolder = new System.Windows.Forms.Button();
            this.txtSaveFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.nudQuality = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.lvMessage = new System.Windows.Forms.ListView();
            this.colFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCurrentTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProgress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExecute = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFileType = new System.Windows.Forms.TextBox();
            this.chkCustom = new System.Windows.Forms.CheckBox();
            this.btnCustomCmd = new System.Windows.Forms.Button();
            this.chkShutdownAfterProcess = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboQuality = new System.Windows.Forms.ComboBox();
            this.cboResolution = new System.Windows.Forms.ComboBox();
            this.cboVideoType = new System.Windows.Forms.ComboBox();
            this.panelResolution = new System.Windows.Forms.Panel();
            this.panelQuality = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpenExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPlay = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuality)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panelResolution.SuspendLayout();
            this.panelQuality.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Files:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(83, 31);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(783, 21);
            this.txtFile.TabIndex = 1;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.Location = new System.Drawing.Point(873, 29);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(35, 23);
            this.btnSelectFile.TabIndex = 2;
            this.btnSelectFile.Text = "...";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Save Folder:";
            // 
            // btnSaveFolder
            // 
            this.btnSaveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveFolder.Location = new System.Drawing.Point(873, 57);
            this.btnSaveFolder.Name = "btnSaveFolder";
            this.btnSaveFolder.Size = new System.Drawing.Size(35, 23);
            this.btnSaveFolder.TabIndex = 5;
            this.btnSaveFolder.Text = "...";
            this.btnSaveFolder.UseVisualStyleBackColor = true;
            this.btnSaveFolder.Click += new System.EventHandler(this.btnSaveFolder_Click);
            // 
            // txtSaveFolder
            // 
            this.txtSaveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaveFolder.Location = new System.Drawing.Point(83, 58);
            this.txtSaveFolder.Name = "txtSaveFolder";
            this.txtSaveFolder.Size = new System.Drawing.Size(783, 21);
            this.txtSaveFolder.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Resolution:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "Quality:";
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(3, 3);
            this.nudWidth.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(51, 21);
            this.nudWidth.TabIndex = 12;
            // 
            // nudHeight
            // 
            this.nudHeight.Location = new System.Drawing.Point(77, 3);
            this.nudHeight.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(51, 21);
            this.nudHeight.TabIndex = 13;
            // 
            // nudQuality
            // 
            this.nudQuality.Location = new System.Drawing.Point(3, 1);
            this.nudQuality.Maximum = new decimal(new int[] {
            51,
            0,
            0,
            0});
            this.nudQuality.Name = "nudQuality";
            this.nudQuality.Size = new System.Drawing.Size(51, 21);
            this.nudQuality.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(437, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "(The value range is 0 to 51. The value is bigger, the quality is lower.)";
            // 
            // lvMessage
            // 
            this.lvMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFileName,
            this.colMessage,
            this.colDuration,
            this.colCurrentTime,
            this.colStartTime,
            this.colProgress});
            this.lvMessage.FullRowSelect = true;
            this.lvMessage.HideSelection = false;
            this.lvMessage.Location = new System.Drawing.Point(5, 183);
            this.lvMessage.Name = "lvMessage";
            this.lvMessage.Size = new System.Drawing.Size(910, 211);
            this.lvMessage.TabIndex = 16;
            this.lvMessage.UseCompatibleStateImageBehavior = false;
            this.lvMessage.View = System.Windows.Forms.View.Details;
            this.lvMessage.DoubleClick += new System.EventHandler(this.lvMessage_DoubleClick);
            this.lvMessage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvMessage_MouseClick);
            // 
            // colFileName
            // 
            this.colFileName.Text = "File Name";
            this.colFileName.Width = 200;
            // 
            // colMessage
            // 
            this.colMessage.Text = "Message";
            this.colMessage.Width = 370;
            // 
            // colDuration
            // 
            this.colDuration.Text = "Duration";
            this.colDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDuration.Width = 80;
            // 
            // colCurrentTime
            // 
            this.colCurrentTime.Text = "Current Time";
            this.colCurrentTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colCurrentTime.Width = 100;
            // 
            // colStartTime
            // 
            this.colStartTime.Text = "Start Time";
            this.colStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colStartTime.Width = 80;
            // 
            // colProgress
            // 
            this.colProgress.Text = "Progress";
            this.colProgress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.Location = new System.Drawing.Point(854, 154);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(55, 23);
            this.btnExecute.TabIndex = 17;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "File Type:";
            // 
            // txtFileType
            // 
            this.txtFileType.Location = new System.Drawing.Point(172, 88);
            this.txtFileType.Name = "txtFileType";
            this.txtFileType.Size = new System.Drawing.Size(73, 21);
            this.txtFileType.TabIndex = 19;
            this.txtFileType.Visible = false;
            // 
            // chkCustom
            // 
            this.chkCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCustom.AutoSize = true;
            this.chkCustom.Location = new System.Drawing.Point(768, 159);
            this.chkCustom.Name = "chkCustom";
            this.chkCustom.Size = new System.Drawing.Size(15, 14);
            this.chkCustom.TabIndex = 22;
            this.chkCustom.UseVisualStyleBackColor = true;
            this.chkCustom.CheckedChanged += new System.EventHandler(this.chkCustom_CheckedChanged);
            // 
            // btnCustomCmd
            // 
            this.btnCustomCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustomCmd.Enabled = false;
            this.btnCustomCmd.Location = new System.Drawing.Point(789, 154);
            this.btnCustomCmd.Name = "btnCustomCmd";
            this.btnCustomCmd.Size = new System.Drawing.Size(59, 23);
            this.btnCustomCmd.TabIndex = 21;
            this.btnCustomCmd.Text = "Custom";
            this.btnCustomCmd.UseVisualStyleBackColor = true;
            this.btnCustomCmd.Click += new System.EventHandler(this.btnCustomCmd_Click);
            // 
            // chkShutdownAfterProcess
            // 
            this.chkShutdownAfterProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShutdownAfterProcess.AutoSize = true;
            this.chkShutdownAfterProcess.Location = new System.Drawing.Point(769, 400);
            this.chkShutdownAfterProcess.Name = "chkShutdownAfterProcess";
            this.chkShutdownAfterProcess.Size = new System.Drawing.Size(138, 16);
            this.chkShutdownAfterProcess.TabIndex = 23;
            this.chkShutdownAfterProcess.Text = "Shutdown PC if done";
            this.chkShutdownAfterProcess.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(915, 25);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // cboQuality
            // 
            this.cboQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuality.FormattingEnabled = true;
            this.cboQuality.Location = new System.Drawing.Point(83, 154);
            this.cboQuality.Name = "cboQuality";
            this.cboQuality.Size = new System.Drawing.Size(77, 20);
            this.cboQuality.TabIndex = 28;
            this.cboQuality.SelectedIndexChanged += new System.EventHandler(this.cboQuality_SelectedIndexChanged);
            // 
            // cboResolution
            // 
            this.cboResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboResolution.FormattingEnabled = true;
            this.cboResolution.Location = new System.Drawing.Point(83, 122);
            this.cboResolution.Name = "cboResolution";
            this.cboResolution.Size = new System.Drawing.Size(77, 20);
            this.cboResolution.TabIndex = 29;
            this.cboResolution.SelectedIndexChanged += new System.EventHandler(this.cboResolution_SelectedIndexChanged);
            // 
            // cboVideoType
            // 
            this.cboVideoType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVideoType.FormattingEnabled = true;
            this.cboVideoType.Location = new System.Drawing.Point(83, 88);
            this.cboVideoType.Name = "cboVideoType";
            this.cboVideoType.Size = new System.Drawing.Size(77, 20);
            this.cboVideoType.TabIndex = 30;
            this.cboVideoType.SelectedIndexChanged += new System.EventHandler(this.cboVideoType_SelectedIndexChanged);
            // 
            // panelResolution
            // 
            this.panelResolution.Controls.Add(this.nudHeight);
            this.panelResolution.Controls.Add(this.label5);
            this.panelResolution.Controls.Add(this.nudWidth);
            this.panelResolution.Location = new System.Drawing.Point(172, 121);
            this.panelResolution.Name = "panelResolution";
            this.panelResolution.Size = new System.Drawing.Size(195, 26);
            this.panelResolution.TabIndex = 31;
            this.panelResolution.Visible = false;
            // 
            // panelQuality
            // 
            this.panelQuality.Controls.Add(this.label6);
            this.panelQuality.Controls.Add(this.nudQuality);
            this.panelQuality.Location = new System.Drawing.Point(172, 153);
            this.panelQuality.Name = "panelQuality";
            this.panelQuality.Size = new System.Drawing.Size(575, 24);
            this.panelQuality.TabIndex = 32;
            this.panelQuality.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPlay,
            this.tsmiOpenExplorer});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(176, 48);
            // 
            // tsmiOpenExplorer
            // 
            this.tsmiOpenExplorer.Name = "tsmiOpenExplorer";
            this.tsmiOpenExplorer.Size = new System.Drawing.Size(175, 22);
            this.tsmiOpenExplorer.Text = "Open in explorer";
            this.tsmiOpenExplorer.Click += new System.EventHandler(this.tsmiOpenExplorer_Click);
            // 
            // tsmiPlay
            // 
            this.tsmiPlay.Name = "tsmiPlay";
            this.tsmiPlay.Size = new System.Drawing.Size(175, 22);
            this.tsmiPlay.Text = "Play";
            this.tsmiPlay.Click += new System.EventHandler(this.tsmiPlay_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 418);
            this.Controls.Add(this.panelQuality);
            this.Controls.Add(this.panelResolution);
            this.Controls.Add(this.cboVideoType);
            this.Controls.Add(this.cboResolution);
            this.Controls.Add(this.cboQuality);
            this.Controls.Add(this.chkShutdownAfterProcess);
            this.Controls.Add(this.chkCustom);
            this.Controls.Add(this.btnCustomCmd);
            this.Controls.Add(this.txtFileType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.lvMessage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSaveFolder);
            this.Controls.Add(this.txtSaveFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Video Converter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuality)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelResolution.ResumeLayout(false);
            this.panelResolution.PerformLayout();
            this.panelQuality.ResumeLayout(false);
            this.panelQuality.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSaveFolder;
        private System.Windows.Forms.TextBox txtSaveFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.NumericUpDown nudQuality;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lvMessage;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.ColumnHeader colFileName;
        private System.Windows.Forms.ColumnHeader colMessage;
        private System.Windows.Forms.ColumnHeader colStartTime;
        private System.Windows.Forms.ColumnHeader colCurrentTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFileType;
        private System.Windows.Forms.CheckBox chkCustom;
        private System.Windows.Forms.Button btnCustomCmd;
        private System.Windows.Forms.CheckBox chkShutdownAfterProcess;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboQuality;
        private System.Windows.Forms.ComboBox cboResolution;
        private System.Windows.Forms.ComboBox cboVideoType;
        private System.Windows.Forms.Panel panelResolution;
        private System.Windows.Forms.Panel panelQuality;
        private System.Windows.Forms.ColumnHeader colDuration;
        private System.Windows.Forms.ColumnHeader colProgress;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenExplorer;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlay;
    }
}

