using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChequeProcessing
{
    public partial class BulkEntry : Form
    {
        public string amount = string.Empty;
        public string acctno = string.Empty;
        public BulkEntry()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            amount = this.TextAmount.Value;
            acctno = this.TextCustomerActNo.Text;
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();        
        }
    }
}