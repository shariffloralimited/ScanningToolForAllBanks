using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChequeProcessing
{
    public partial class BatchBalance : Form
    {
        Guid BatchNo;

        double BatchTotalDiff;
        int TotalChequesDiff;

        public BatchBalance(Guid BatchNo)
        {
            InitializeComponent();
            this.BatchNo = BatchNo;
            BatchDB db = new BatchDB();
            BatchInfo bi = db.BatchBalance(BatchNo);

            TextBatchTotal.Text = bi.NBatchTotal.ToString();
            TextTotalChecks.Text = bi.NTotalCheques.ToString();
            TextCTotalChecks.Text = bi.CTotalCheques.ToString();
            TextCBatchTotal.Text = bi.CBatchTotal.ToString();

            BatchTotalDiff = bi.NBatchTotal - bi.CBatchTotal;
            TotalChequesDiff = bi.NTotalCheques - bi.CTotalCheques;


            if (BatchTotalDiff == 0)
            {
                LabelError1.Hide();
                LabelOk1.Show();
            }
            else
            {
                LabelError1.Show();
                LabelOk1.Hide();
            }
            TextAmtDiff.Text = String.Format("{0:N}",BatchTotalDiff);
            
            if (TotalChequesDiff == 0)
            {
                LabelError2.Hide();
                LabelOk2.Show();
            }
            else
            {
                LabelError2.Show();
                LabelOk2.Hide();
            }
            TextChecksDiff.Text = TotalChequesDiff.ToString();
        }

        public bool Balance()
        {
            return ((TotalChequesDiff == 0) && (BatchTotalDiff == 0));
        }
        public bool BalanceCheques()
        {
            return ((TotalChequesDiff == 0));
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }
    }
}
