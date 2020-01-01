using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoConvertCore;

namespace VideoConverter
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            ConvertSetting setting = SettingManager.GetSetting();
            this.nudTaskParallelLimit.Value = setting.TaskParallelLimit;
            this.chkEnableLog.Checked = setting.EnableLog;
            this.chkEnableDebug.Checked = setting.EnableDebug;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ConvertSetting setting = new ConvertSetting();
            setting.TaskParallelLimit = (int)this.nudTaskParallelLimit.Value;
            setting.EnableLog = this.chkEnableLog.Checked;
            setting.EnableDebug = this.chkEnableDebug.Checked;
            SettingManager.SaveSetting(setting);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
