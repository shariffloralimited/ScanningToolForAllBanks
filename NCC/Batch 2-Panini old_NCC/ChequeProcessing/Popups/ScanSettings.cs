using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChequeProcessing
{
    public partial class ScanSettings : Form
    {
        private ScanSettingsListener listener;

        public static int toEndorse = 1;
        public ScanSettings()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            toEndorse = 0;
            long seqNo = 0;
            if (checkBox1.Checked)
            {
                if (radioButton1.Checked)
                {
                    toEndorse = 0;  // do not endorse next cheque
                }
                else
                {
                    toEndorse = 2;  // do not endorse all next cheques
                }
                try
                {
                    seqNo = long.Parse(textBox1.Text);
                }
                catch  { }
            }
            listener.SettingsChanged(toEndorse, seqNo);
            this.Dispose();
        }

        public void setListener(ScanSettingsListener listener)
        {
            this.listener = listener;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }
        }
    }
}