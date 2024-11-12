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
using System.Configuration;

namespace VideoConverter
{
    public partial class frmCustomCmd : Form
    {
        public CustomCommandType CustomCommandType;
        public string Command { get; private set; }
        public CutOption CutOption { get; set; }

        public frmCustomCmd()
        {
            InitializeComponent();
        }

        public frmCustomCmd(CustomCommandType commandType, string cmd)
        {
            InitializeComponent();

            this.CustomCommandType = commandType;
            this.Command = cmd;
        }

        private void frmCustomCmd_Load(object sender, EventArgs e)
        {
            this.BindComboItems(this.cboType, typeof(CustomCommandType));

            this.cboType.Text = this.CustomCommandType.ToString();

            if (!string.IsNullOrEmpty(this.Command))
            {
                this.txtCmd.Text = this.Command;
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.CustomCommandType = (CustomCommandType)Enum.Parse(typeof(CustomCommandType), this.cboType.Text);
            this.Command = this.txtCmd.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSourceFileName_Click(object sender, EventArgs e)
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

        private void btnTargetFileName_Click(object sender, EventArgs e)
        {
            this.InsertPlaceHolder("##TargetFile##");
        }

        private void txtCmd_TextChanged(object sender, EventArgs e)
        {

        }

        private void lnkReferences_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(this.lnkReferences.Text);
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboType.Text == nameof(CustomCommandType.Cut))
            {
                this.txtCmd.Text = ConfigurationManager.AppSettings["CutCommandTemplate"];

                this.btnOption.Visible = true;
            }
            else
            {
                this.btnOption.Visible = false;
            }
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            if (this.cboType.Text == nameof(CustomCommandType.Cut))
            {
                frmCutOption frm = new frmCutOption();

                if (this.CutOption != null)
                {
                    frm.Option = this.CutOption;
                }

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.CutOption = frm.Option;
                }
            }
        }

        private void btnSourceFileNameWithoutExt_Click(object sender, EventArgs e)
        {
            this.InsertPlaceHolder("##SourceFileWithoutExt##");
        }
    }
}
