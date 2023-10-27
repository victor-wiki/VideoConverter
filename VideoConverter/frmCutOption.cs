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
    public partial class frmCutOption : Form
    {
        public CutOption Option;

        public frmCutOption()
        {
            InitializeComponent();
        }

        private void frmCutOption_Load(object sender, EventArgs e)
        {
            if (this.Option != null)
            {
                this.dtpStarting.Value = this.DurationToDateTime(this.Option.Starting);

                if(this.Option.CutType == CutType.Normal)
                {
                    this.rbReserve.Checked = true;
                }
                else if(this.Option.CutType == CutType.IntroOutro)
                {
                    this.rbOutroToRemove.Checked = true;
                }
               
                this.dtpDuration.Value = this.DurationToDateTime(this.Option.Duration);
            }
        }

        private DateTime DurationToDateTime(double duration)
        {
            TimeSpan ts = new TimeSpan(0, 0, (int)duration);

            return new DateTime(1971, 1, 1, 0, 0, 0).Add(ts);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Option = new CutOption();

            this.Option.Starting = this.GetTotalSeconds(this.dtpStarting.Value);      
            this.Option.CutType = this.rbReserve.Checked ? CutType.Normal : CutType.IntroOutro;
            this.Option.Duration = this.GetTotalSeconds(this.dtpDuration.Value);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private int GetTotalSeconds(DateTime dt)
        {
            return dt.Hour * 3600 + dt.Minute * 60 + dt.Second;
        }
    }
}
