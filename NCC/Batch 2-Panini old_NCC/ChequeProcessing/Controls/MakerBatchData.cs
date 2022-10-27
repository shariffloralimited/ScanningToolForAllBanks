using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ChequeProcessing;

namespace Controls
{
    public partial class MakerBatchData : UserControl
    {
        public int TotalCheques;
        public double CBatchTotal;
        public int DataReqd;
        public string BatchName;
        public double EBatchTotal;

        public MakerBatchData()
        {
            InitializeComponent();
        }

        public void SetBatch(ChequeProcessing.Batch batch)
        {
            if (batch == null)
            {
                DefaultInfo();
                return;
            }
            // Update by Mizan
            BatchDB db = new BatchDB();
            //MizanCalculatedBatchTotal c = db.GetCalculatedBatchTotalAndDataReqdByBatchID(batch.BatchID);
            this.TotalCheques = batch.CTotalCheques;
            this.CBatchTotal = batch.CBatchTotal; //c.CBatchTotal;
            this.DataReqd = batch.DataReqd;
            this.BatchName = batch.BatchName;
            this.EBatchTotal = batch.BatchTotal;
            ShowInfo();
        }

        private void ShowInfo()
        {
            textBox1.Text = TotalCheques.ToString();
            textBox2.Text = DataReqd.ToString();
            textBox3.Text = CBatchTotal.ToString();
            textBox4.Text = EBatchTotal.ToString();
            textBox6.Text = BatchName.ToString();
        }
        private void DefaultInfo()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox6.Text = string.Empty;
        }
    }
}