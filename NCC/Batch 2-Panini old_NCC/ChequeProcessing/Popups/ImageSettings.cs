using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChequeProcessing
{
    public partial class ImageSettings : Form
    {
        public ImageSettings()
        {
            InitializeComponent();
            SettingsDB db = new SettingsDB();
            DataTable dt = db.GetDepSlipSettings(0);
            int ScanDeps = (int)dt.Rows[0].ItemArray[0];
            int DepsBefore = (int)dt.Rows[0].ItemArray[1];
        }


        private void ButtonSave_Click(object sender, EventArgs e)
        {
            SettingsDB db = new SettingsDB();
            //db.UpdateDepSlipSettings(0, checkBox1.Checked, checkBox1.Checked);
            this.Dispose();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ButtonDefault_Click(object sender, EventArgs e)
        {
            //ComboBoxFileType
        }
    }
}