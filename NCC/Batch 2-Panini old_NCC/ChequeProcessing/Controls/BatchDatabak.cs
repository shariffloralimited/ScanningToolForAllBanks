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
    public partial class BatchDatabak : UserControl
    {
        private int UserRole;
        private int UserID;

        public Batch batch;

        public BatchDatabak()
        {
            InitializeComponent();
            UsersDB db = new UsersDB();
        }

        public void SetUser(UserInfo User)
        {
            this.UserRole = User.RoleID;
            this.UserID = User.UserID;
            UsersDB db = new UsersDB();
            TextUserName.Text = db.GetUserName(UserID);

            if (UserRole == ChequeProcessing.UserRoles.BranchDataEntryChecker)
            {
                Label3.Text = "Approve Reqd";
            }
            else if (UserRole == ChequeProcessing.UserRoles.BranchDataEntryMaker)
            {
                Label3.Text = "Data Reqd.";
            }
        }

        public void SetBatch(ChequeProcessing.Batch batch)
        {
            if (batch == null)
            {
                DefaultInfo();
                return;
            }
            this.batch = batch;
            ShowInfo();
        }

        public override void Refresh()
        {
            if (this.batch == null)
            {
                DefaultInfo();
                return;
            }
            ShowInfo();
        }

        private void ShowInfo()
        {
            BatchDB bdb = new BatchDB();
            //MizanCalculatedBatchTotal c = bdb.GetCalculatedBatchTotalAndDataReqdByBatchID(batch.BatchID);

            if (UserRole == UserRoles.BranchDataEntryMaker)
            {
                //TextRelated.Text = c.DataReqd.ToString();
                TextRelated.Text = batch.DataReqd.ToString();
            }
            else if (UserRole == UserRoles.BranchDataEntryChecker)
            {
                TextRelated.Text = batch.ApprovalReqd.ToString();
            }
            else
            {
                TextRelated.Text = batch.totalMICRError.ToString();
            }
            if (UserID > 0)
            {
                UsersDB db = new UsersDB();

                TextUserName.Text = db.GetUserName(UserID);
            }

            TextCTotalCheques.Text  = batch.TotalCheques.ToString();
            TextCBatchTotal.Text = batch.CBatchTotal.ToString(); //c.CBatchTotal.ToString();
            txtCCY.Text             = batch.CCY.ToString();
            TextTotalCheques.Text   = batch.CTotalCheques.ToString();
            TextBatchTotal.Text     = batch.BatchTotal.ToString();
            TextBatchName.Text      = batch.BatchName.ToString();
        }
        private void DefaultInfo()
        {
            TextCTotalCheques.Text = string.Empty;
            TextTotalCheques.Text = string.Empty;
            TextRelated.Text = string.Empty;
            TextUserName.Text = string.Empty;
            TextBatchName.Text = string.Empty;
            TextCBatchTotal.Text = string.Empty;
            TextBatchTotal.Text = string.Empty;
        }
    }
}