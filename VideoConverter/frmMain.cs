using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VideoConvertCore;

namespace VideoConverter
{
    public partial class frmMain : Form, IObserver<FeedbackInfo>
    {
        private ConvertHandler convertHandler = new ConvertHandler();
        private int initColumnWidthExludeMessage = 0;

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.InitControls();           
        }

        public frmMain()
        {
            InitializeComponent();
            ListView.CheckForIllegalCrossThreadCalls = false;
            Form.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.FileName = "";
            DialogResult result = this.openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.txtFile.Text = string.Join("|", this.openFileDialog1.FileNames);
            }
        }

        private void btnSaveFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.txtSaveFolder.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            this.ConvertVideo();
        }

        private void ConvertVideo()
        {
            this.convertHandler.Clearup();

            string strFilePath = this.txtFile.Text;
            string saveFolder = this.txtSaveFolder.Text;

            if (string.IsNullOrEmpty(strFilePath))
            {
                MessageBox.Show("Please choose the file for converting!");
                return;
            }

            string[] filePaths = strFilePath.Split('|');

            foreach (string filePath in filePaths)
            {
                FileInfo file = new FileInfo(filePath);
                string strStartTime = DateTime.Now.ToString("HH:mm:ss");
                string strTime = "00:00:00";

                VideoInfo videoInfo = VideoHelper.GetVideoInfo(filePath);
                if (!this.lvMessage.Items.ContainsKey(file.Name))
                {
                    ListViewItem li = new ListViewItem();
                    li.Tag = videoInfo;
                    li.Name = file.Name;
                    li.Text = file.Name;
                    li.SubItems.Add("Ready");//Message
                    li.SubItems.Add(videoInfo.DurationString);//Duration
                    li.SubItems.Add(""); //Current Time
                    li.SubItems.Add("");//Start Time
                    li.SubItems.Add("0%"); //Progress

                    this.lvMessage.Items.Add(li);
                }
                else
                {
                    ListViewItem li = this.lvMessage.Items[file.Name];
                    li.Tag = videoInfo;
                    li.SubItems[1].Text = "Ready"; //Message
                    li.SubItems[2].Text = videoInfo.DurationString; //Duration                    
                    li.SubItems[3].Text = strTime; //Current Time
                    li.SubItems[4].Text = ""; //Start Time
                    li.SubItems[4].Tag = null;
                    li.SubItems[5].Text = "0%"; //Progress
                    li.BackColor = Color.White;
                }
            }           

            this.btnExecute.Enabled = false;

            this.convertHandler.FilePaths = filePaths.ToList();

            switch (this.cboVideoType.Text)
            {
                case nameof(VideoType.Original):
                    this.convertHandler.Option.FileType = "";
                    break;
                case nameof(VideoType.Custom):
                    this.convertHandler.Option.FileType = this.txtFileType.Text;
                    break;
                default:
                    this.convertHandler.Option.FileType = this.cboVideoType.Text;
                    break;
            }

            int? width = default(int?);
            int? height = default(int?);
            switch (this.cboResolution.Text)
            {
                case nameof(VideoResolution.P1080):
                    width = 1920; height = 1080;
                    break;
                case nameof(VideoResolution.P720):
                    width = 1280; height = 720;
                    break;
                case nameof(VideoResolution.P480):
                    width = 720; height = 480;
                    break;
                case nameof(VideoResolution.P360):
                    width = 480; height = 360;
                    break;
                case nameof(VideoResolution.Custom):
                    if (this.nudWidth.Value > 0)
                    {
                        width = (int)this.nudWidth.Value;
                    }
                    if (this.nudHeight.Value > 0)
                    {
                        height = (int)this.nudHeight.Value;
                    }
                    break;
            }

            this.convertHandler.Option.SaveFolder = saveFolder;
            this.convertHandler.Option.ResolutionWidth = width;
            this.convertHandler.Option.ResolutionHeight = height;

            if (this.cboQuality.Text == VideoQuality.Custom.ToString())
            {
                this.convertHandler.Option.Quality = (int)this.nudQuality.Value;
            }
            else
            {
                this.convertHandler.Option.Quality = (int)Enum.Parse(typeof(VideoQuality), this.cboQuality.Text);
            }

            this.convertHandler.Subscribe(this);

            ConvertSetting setting = SettingManager.GetSetting();
            this.convertHandler.Setting = setting;

            LogHelper.EnableDebug = setting.EnableDebug;
            FeedbackHelper.EnableLog = setting.EnableLog;

            this.convertHandler.Convert();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.convertHandler.RunningCount > 0)
            {
                DialogResult result = MessageBox.Show("There is running task, are you sure to exit?", "Confirm", MessageBoxButtons.YesNo);

                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }

            if (!e.Cancel)
            {
                this.convertHandler.Terminate();
            }
        }

        private void btnCustomCmd_Click(object sender, EventArgs e)
        {
            frmCustomCmd frmCustomCmd = new frmCustomCmd(this.convertHandler.Option.CustomCommand);
            DialogResult result = frmCustomCmd.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.convertHandler.Option.CustomCommand = frmCustomCmd.Command;
            }
        }

        private void chkCustom_CheckedChanged(object sender, EventArgs e)
        {
            this.btnCustomCmd.Enabled = this.chkCustom.Checked;
            if (!this.chkCustom.Checked)
            {
                this.convertHandler.Option.CustomCommand = "";
            }
        }

        private void Shutdown()
        {
            Process process = new Process();
            process.StartInfo.FileName = "shutdown";
            process.StartInfo.Arguments = "/s";
            process.Start();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSetting frmSetting = new frmSetting();
            frmSetting.ShowDialog();
            if (frmSetting.DialogResult == DialogResult.OK)
            {
                this.convertHandler.Setting = SettingManager.GetSetting();
            }
        }

        private void InitControls()
        {
            this.BindComboItems(this.cboVideoType, typeof(VideoType));
            this.BindComboItems(this.cboResolution, typeof(VideoResolution));
            this.BindComboItems(this.cboQuality, typeof(VideoQuality));

            this.cboVideoType.SelectedIndex = 0;
            this.cboResolution.SelectedIndex = 0;
            this.cboQuality.SelectedIndex = 0;

            foreach (ColumnHeader col in this.lvMessage.Columns)
            {
                if (col.DisplayIndex != 1)
                {
                    this.initColumnWidthExludeMessage += col.Width;
                }
            }
        }

        private void BindComboItems(ComboBox cbo, Type type)
        {
            var items = Enum.GetNames(type);
            foreach (var item in items)
            {
                cbo.Items.Add(item);
            }
        }

        public void OnError(Exception error)
        {
        }

        public void OnCompleted()
        {
        }

        public void OnNext(FeedbackInfo feedback)
        {
            VideoInfo videoInfo = feedback.Source as VideoInfo;

            if (this.IsDisposed)
            {
                return;
            }

            int finishCount = 0;
            Action showResult = () =>
            {
                if (videoInfo != null && videoInfo.FilePath != null)
                {
                    int finishedCount = 0;

                    foreach (ListViewItem item in this.lvMessage.Items)
                    {
                        VideoInfo v = item.Tag as VideoInfo;

                        if (v != null)
                        {
                            if (v.TaskState == ConvertTaskState.Finished)
                            {
                                finishCount++;
                            }

                            if (v.FilePath == videoInfo.FilePath)
                            {
                                v.TaskState = videoInfo.TaskState;
                                v.TargetFilePath = videoInfo.TargetFilePath;

                                item.SubItems[1].Text = feedback.Content;

                                if (item.SubItems[4].Tag == null)
                                {
                                    item.SubItems[4].Text = DateTime.Now.ToString("HH:mm:ss");
                                    item.SubItems[4].Tag = DateTime.Now;
                                }

                                bool isFinished = false;

                                if (videoInfo.TaskState == ConvertTaskState.Finished)
                                {
                                    isFinished = true;

                                    this.lvMessage.Items[videoInfo.Name].BackColor = Color.LightGreen;
                                }
                                else if (videoInfo.TaskState == ConvertTaskState.Error)
                                {
                                    this.lvMessage.Items[videoInfo.Name].BackColor = Color.Pink;
                                }

                                TimeSpan currentTime = videoInfo.CurrentTime;

                                if (currentTime != null && currentTime.TotalSeconds > 0)
                                {
                                    item.SubItems[3].Text = $"{currentTime.Hours.ToString().PadLeft(2, '0')}:{currentTime.Minutes.ToString().PadLeft(2, '0')}:{currentTime.Seconds.ToString().PadLeft(2, '0')}";

                                    double percent = (currentTime.TotalSeconds * 1.0) / v.Duration.TotalSeconds;

                                    if (isFinished)
                                    {
                                        percent = 1;
                                    }

                                    item.SubItems[5].Text = (percent * 100 == (int)(percent * 100) || percent >= 1) ? percent.ToString("p0") : percent.ToString("p1");
                                }
                                else if (isFinished)
                                {
                                    item.SubItems[5].Text = "100%";
                                }

                                if (v.TaskState == ConvertTaskState.Finished)
                                {
                                    finishCount++;
                                }
                            }
                        }
                    }

                    this.lvMessage.Update();

                    this.lblFinished.Text = $"{finishCount}/{this.lvMessage.Items.Count}";
                }
            };

            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(showResult);
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
            }
            else
            {
                showResult();
            }

            if (feedback.IsDone)
            {
                this.btnExecute.Enabled = true;

                if (this.chkShutdownAfterProcess.Checked && finishCount == this.lvMessage.Items.Count)
                {
                    this.Shutdown();
                }
                else
                {
                    MessageBox.Show("Done", "Information");
                }
            }
        }

        private void cboVideoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtFileType.Visible = this.cboVideoType.Text == VideoType.Custom.ToString();
        }

        private void cboResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.panelResolution.Visible = this.cboResolution.Text == VideoResolution.Custom.ToString();
        }

        private void cboQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.panelQuality.Visible = this.cboQuality.Text == VideoQuality.Custom.ToString();
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            this.lvMessage.Columns[1].Width = this.lvMessage.Width - this.initColumnWidthExludeMessage - 25;
        }

        private void lvMessage_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.lvMessage.FocusedItem.Bounds.Contains(e.Location))
                {
                    VideoInfo videoInfo = this.lvMessage.FocusedItem.Tag as VideoInfo;

                    this.contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }


        private void tsmiOpenExplorer_Click(object sender, EventArgs e)
        {
            this.OpenFileInExplorer();
        }

        private void tsmiPlay_Click(object sender, EventArgs e)
        {
            this.PlayVideo();
        }

        private void PlayVideo()
        {
            if (this.lvMessage.FocusedItem != null)
            {
                VideoInfo videoInfo = this.lvMessage.FocusedItem.Tag as VideoInfo;

                if (videoInfo != null)
                {
                    if (videoInfo.TaskState == ConvertTaskState.Finished && File.Exists(videoInfo.TargetFilePath))
                    {
                        Process.Start(videoInfo.TargetFilePath);
                    }
                    else if (File.Exists(videoInfo.FilePath))
                    {
                        Process.Start(videoInfo.FilePath);
                    }
                }
            }
        }

        private void tsmiPlay_DoubleClick(object sender, EventArgs e)
        {
            this.OpenFileInExplorer();
        }

        private void OpenFileInExplorer()
        {
            if (this.lvMessage.FocusedItem != null)
            {
                VideoInfo videoInfo = this.lvMessage.FocusedItem.Tag as VideoInfo;

                if (videoInfo != null)
                {
                    string filePath = "";

                    if (videoInfo.TaskState == ConvertTaskState.Finished && File.Exists(videoInfo.TargetFilePath))
                    {
                        filePath = videoInfo.TargetFilePath;
                    }
                    else if (File.Exists(videoInfo.FilePath))
                    {
                        filePath = videoInfo.FilePath;
                    }

                    string cmd = "explorer.exe";
                    string arg = "/select," + filePath;
                    Process.Start(cmd, arg);
                }
            }
        }

        private void lvMessage_DoubleClick(object sender, EventArgs e)
        {
            this.PlayVideo();
        }

        private void tsmiRemoveSelected_Click(object sender, EventArgs e)
        {
            if (this.lvMessage.SelectedItems != null)
            {
                for (int i = this.lvMessage.SelectedItems.Count - 1; i >= 0; i--)
                {
                    VideoInfo videoInfo = this.lvMessage.SelectedItems[i].Tag as VideoInfo;

                    if (videoInfo != null && this.convertHandler.FilePaths.Contains(videoInfo.FilePath))
                    {
                        this.convertHandler.RemoveFile(videoInfo.FilePath);
                    }

                    this.lvMessage.SelectedItems[i].Remove();
                }
            }
        }
    }

    public enum VideoType
    {
        Original = 0,
        mp4 = 1,
        avi = 2,
        flv = 3,
        wmv = 4,
        mov = 5,
        mkv = 6,
        mpg = 7,
        ogg = 8,
        vob = 9,
        Custom = -1
    }

    public enum VideoResolution
    {
        Original = 0,
        P1080 = 1,
        P720 = 2,
        P480 = 3,
        P360 = 4,
        Custom = -1
    }

    public enum VideoQuality
    {
        High = 0,
        Medium = 25,
        Low = 50,
        Custom = -1
    }
}
