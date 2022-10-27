using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChequeProcessing
{
    public partial class ServerSelector : Form
    {
        public ServerSelector()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbStrings.Text != "")
            {
                Lookups.Config.ConnectionString = cmbStrings.Text;
                this.Hide();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
