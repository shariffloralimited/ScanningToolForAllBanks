using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ChequeProcessing;


namespace ChequeProcessing
{
    public partial class DepositSlipSettings : Form
    {
        public DepositSlipSettings()
        {
            InitializeComponent();
            SettingsDB db = new SettingsDB();
            DataTable dt = db.GetDepSlipSettings(0);
            int ScanDeps = (int)dt.Rows[0].ItemArray[0];
            int DepsBefore = (int)dt.Rows[0].ItemArray[1];
            checkBox1.Checked = (ScanDeps == 1);
            if (DepsBefore == 0)
            {
                radioButton2.Checked = true;
            }
            else
            {
                radioButton1.Checked = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
            else
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SettingsDB db = new SettingsDB();
            db.UpdateDepSlipSettings(0, checkBox1.Checked, checkBox1.Checked);
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        
    }
}