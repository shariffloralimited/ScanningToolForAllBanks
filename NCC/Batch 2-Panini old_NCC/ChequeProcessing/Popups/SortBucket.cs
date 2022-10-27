using System;
using System.Data;
using System.Windows.Forms;

namespace ChequeProcessing
{
    public partial class SortBucket : Form
    {
        int UserID;
        Guid BatchNo;
        string RoutingNo;
        string IPAddress;
        BatchTraceListener Listner;
        public SortBucket(BatchTraceListener Listner, int UserID, Guid BatchNo, string RoutingNo, string IPAddress)
        {
            InitializeComponent();
            this.Listner = Listner;
            this.UserID = UserID;
            this.BatchNo = BatchNo;
            this.RoutingNo = RoutingNo;
            this.IPAddress = IPAddress;
            ChequesDB db = new ChequesDB();
            DataTable table = db.GetChecksFromSortBucket(Convert.ToInt32(RoutingNo));
            dataGridView1.DataSource = table;
            if (dataGridView1.RowCount == 0)
            {
                ButtonOK.Enabled = false;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            PullFromSortBucket();
        }
        public void PullFromSortBucket()
        {
            ChequesDB db = new ChequesDB();
            db.PullFromSortBucket(
                (Guid)dataGridView1.SelectedRows[0].Cells["CheckID"].Value,
                BatchNo,
                UserID,
                IPAddress);
            if (Listner != null)
            {
                Listner.BatchReady(BatchNo);
            }
            this.Hide();
            this.Dispose();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            PullFromSortBucket();
        }

    }
}