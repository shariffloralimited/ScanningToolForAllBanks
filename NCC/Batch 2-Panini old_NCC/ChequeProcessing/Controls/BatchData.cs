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
    public partial class BatchData : UserControl
    {
        private int UserRole;
        private int UserID;

        public Batch batch;

        public BatchData()
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

            if (UserRole == ChequeProcessing.UserRoles.BranchDataEntryChecker || UserRole == ChequeProcessing.UserRoles.ZonalDataEntryChecker)
            {
                Label3.Text = "Approve Reqd";
            }
            else if (UserRole == ChequeProcessing.UserRoles.BranchDataEntryMaker || UserRole == ChequeProcessing.UserRoles.ZonalDataEntryMaker)
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

            if (UserRole == UserRoles.BranchDataEntryMaker || UserRole == UserRoles.ZonalDataEntryMaker)
            {
                //TextRelated.Text = c.DataReqd.ToString();
                TextRelated.Text = batch.DataReqd.ToString();
            }
            else if (UserRole == UserRoles.BranchDataEntryChecker || UserRole == UserRoles.ZonalDataEntryChecker)
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
            TextCTotalCheques.Text = batch.TotalCheques.ToString();
            txtCCY.Text             = batch.CCY.ToString();
            TextBatchName.Text      = batch.BatchName.ToString();
            TextCBatchTotal.Text = batch.CBatchTotal.ToString();
            TextTotalCheques.Text = batch.TotalCheques.ToString();
            TextBatchTotal.Text = batch.BatchTotal.ToString();
        }
        private void DefaultInfo()
        {
            TextRelated.Text = string.Empty;
            TextUserName.Text = string.Empty;
            TextBatchName.Text = string.Empty;
        }
    }
}