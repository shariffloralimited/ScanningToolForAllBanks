using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChequeProcessing
{
    public partial class SendToMaker : Form
    {
        BatchTraceListener Listner;
        public int UserID;
        public string IPAddress;
        public Cheque cheque;
        public Guid BatchNo;

        public SendToMaker()
        {
            InitializeComponent();
        }
        public SendToMaker(Cheque cheque, int UserID, string IPAddress, Guid BatchNo)
        {
            this.BatchNo = BatchNo;
            this.cheque = cheque;
            this.UserID = UserID;
            this.IPAddress = IPAddress;

            InitializeComponent();

            this.imagePanel1.ChangeDisplayMode(0);
            this.imagePanel1.SetFrontImage(cheque.ImgFront);
            this.imagePanel1.SetBackImage(cheque.ImgBack);
        }

        public void SetListener(BatchTraceListener Listner)
        {
            this.Listner = Listner;
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            if (TextReason.Text == null || TextReason.Text == "")
            {
                MessageBox.Show("Please Insert a Reason!");
                return;
            }
            ChequesDB db = new ChequesDB();
            cheque.RejectReason = TextReason.Text;
            db.SendToMaker(cheque.ChequeID, TextReason.Text, UserID, IPAddress);
            this.Hide();
            if (Listner != null)
            {
                Listner.BatchReady(new Guid("00000000-0000-0000-0000-000000000000"));
            }
            this.Dispose();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }
    }
}