using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoConverter
{
    public partial class frmCustomCmd : Form
    {
        public string Command { get; private set; }
        public frmCustomCmd()
        {
            InitializeComponent();
        }

        public frmCustomCmd(string cmd)
        {
            InitializeComponent();
            this.Command = cmd;
        }

        private void frmCustomCmd_Load(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.Command))
            {
                this.txtCmd.Text = this.Command;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Command = this.txtCmd.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSourceFilePath_Click(object sender, EventArgs e)
        {
            this.InsertPlaceHolder("##SourceFile##");
        }

        private void InsertPlaceHolder(string placeHolder)
        {
            if (this.txtCmd.SelectionLength > 0)
            {
                this.txtCmd.SelectionStart = this.txtCmd.SelectionStart + this.txtCmd.SelectionLength;
            }
            this.txtCmd.SelectedText = placeHolder;
        }

        private void btnTargetFilePath_Click(object sender, EventArgs e)
        {
            this.InsertPlaceHolder("##TargetFile##");
        }        
    }
}
