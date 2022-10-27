using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChequeProcessing
{
    public partial class OpenBatch : Form
    {
        int BatchOption;
        int UserID;
        int StatusID;
        int UserRole;
        BatchTraceListener Listner;

        public OpenBatch(BatchTraceListener Listner, int BatchOption, int UserID, int UserRole)
        {
            try
            {
                InitializeComponent();
                this.Listner = Listner;
                this.UserID = UserID;
                this.BatchOption = BatchOption;
                this.UserRole = UserRole;
                BatchDB db = new BatchDB();
                DataTable table = null;
                table = db.GetBatchesByUserRole(UserID, UserRole);
                dataGridView1.DataSource = table;
                if (dataGridView1.RowCount == 0)
                {
                    ButtonOK.Enabled = false;
                }
                ReloadBatches();
            }
            catch  (Exception ex)
            {
                
            }
        }

        private void ReloadBatches()
        {
            BatchDB db = new BatchDB();
            DataTable table = null;
            table = db.GetBatchesByUserRole(UserID, UserRole);
            dataGridView1.DataSource = table;
            if (dataGridView1.RowCount == 0)
            {
                ButtonOK.Enabled = false;
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            
            BatchSelected();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            BatchSelected();
        }

        private void BatchSelected()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            BatchDB db = new BatchDB();
            Guid BatchNum;
            int SelectedIndex = dataGridView1.SelectedRows[0].Index;
            if (SelectedIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[SelectedIndex];

                BatchNum = (Guid)(dataGridView1.Rows[SelectedIndex].Cells["BatchID"].Value);
                Properties.Settings.Default.LoadedBatchID = BatchNum;
                Properties.Settings.Default.BatchCurrency = dataGridView1.Rows[SelectedIndex].Cells["CCY"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Please select a batch!");
                return;
            }
            if (!db.IsBatchEditable(BatchNum, UserID))
            {
                MessageBox.Show("This Batch is locked by some other user");
                ReloadBatches();
                return;
            }
            if (BatchOption == BatchOptions.Open)
            {
                Listner.BatchReady(BatchNum);
            }
            else
            {
                CreateBatch form = new CreateBatch(this.Listner, this.UserID, this.BatchOption, BatchNum, UserRole);
                form.ShowDialog();
            }
            this.Hide();
            this.Dispose();
        }
    }
}