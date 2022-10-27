using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ChequeProcessing
{
    public class BatchInfo
    {
        public Guid BatchNo;
        public int NTotalCheques;
        public int CTotalCheques;
        public double NBatchTotal;
        public double CBatchTotal;
    }
    
    public class Batch
    {
        public Guid BatchID;
        public string BatchName;
        public int CTotalCheques;
        public int TotalCheques;
        public int totalMICRError;
        public int totalImageError;
        public double BatchTotal;
        public double CBatchTotal;
        public int DataReqd;
        public bool Approved;
        public Cheque[] cheques;
        public double RunningTotal;
        public int ApprovalReqd;
        public string presentingRoutingNo;
        public int ClearingType;
        public int presentmment;
        public string batchDate;
        public int batchCounter;
        public bool NoCharge;
        public string CCY;
        public int scanNo = 0;

        public bool toEndorse;

        public bool saved;

        public Batch()
        {
        }

        public Batch(Guid BatchNo, int UserID)
        {
            this.BatchID = BatchNo;

            BatchDB db = new BatchDB();
            DataTable tblBatchData = db.GetSingleBatch(BatchNo, UserID);
            if (tblBatchData.Rows.Count > 0)
            {
                this.batchDate = tblBatchData.Rows[0].ItemArray[1].ToString();
                this.BatchName = tblBatchData.Rows[0].ItemArray[3].ToString();
                this.BatchTotal = Convert.ToDouble(tblBatchData.Rows[0].ItemArray[6]) / 100;
                this.CTotalCheques = Convert.ToInt32(tblBatchData.Rows[0].ItemArray[10]);
                this.TotalCheques = Convert.ToInt32(tblBatchData.Rows[0].ItemArray[11]);
                this.presentingRoutingNo = tblBatchData.Rows[0].ItemArray[2].ToString();
                this.ClearingType = Convert.ToInt32(tblBatchData.Rows[0].ItemArray[5]);
                this.presentmment = Convert.ToInt32(tblBatchData.Rows[0].ItemArray[4]);
                this.toEndorse = Convert.ToBoolean(tblBatchData.Rows[0].ItemArray[7]);
                this.batchCounter = Convert.ToInt32(tblBatchData.Rows[0].ItemArray[14]);
                this.NoCharge = Convert.ToBoolean(tblBatchData.Rows[0].ItemArray[15].ToString());
                this.CCY = tblBatchData.Rows[0].ItemArray[16].ToString();
                this.totalImageError = 0;
                this.totalMICRError = 0;
                this.cheques = new Cheque[1000];
            }
            else
            {
                throw new BatchLockedExeption();
            }
            db = null;
            tblBatchData = null;
        }

        public Batch(Guid BatchNo, int UserID, DataTable ChequeDetail)
            : this(BatchNo, UserID)
        {
            BatchDB db = new BatchDB();
            Cheque[] cheques = Cheque.CreateCheques(ChequeDetail);
            this.cheques = cheques;
            this.TotalCheques = ChequeDetail.Rows.Count;
            //this.Approved = true;
            for (int i = 0; i < TotalCheques; i++)
            {
                if (cheques[i] == null)
                {
                    CTotalCheques--;
                    continue;
                }
                if ((cheques[i].MICRError & ErrorTypes.BadMICR) != 0 ||
                    (cheques[i].MICRError & ErrorTypes.InvalidMICR) != 0 ||
                    (cheques[i].MICRError & ErrorTypes.CheckDigitMismatch) != 0
                    )
                {
                    totalMICRError++;
                }
                if ((cheques[i].MICRError & ErrorTypes.BadImage) != 0)
                {
                    totalImageError++;
                }
                if (!cheques[i].IsComplete())
                {
                    DataReqd++;
                }
                if (!cheques[i].Approved && cheques[i].StatusID != ChequeStatus.Approved)
                {
                    this.Approved = false;
                    this.ApprovalReqd++;
                }
            }
            CBatchTotal = db.GetBatchTotal(BatchNo);
        }

        public void Update()
        {
            BatchDB db = new BatchDB();
            CBatchTotal = 0;
            this.DataReqd = 0;
            this.totalMICRError = 0;
            this.Approved = true;
            this.ApprovalReqd = 0;
            for (int i = 0; i < TotalCheques; i++)
            {
                if (!cheques[i].isReady())
                {
                    totalMICRError++;
                }
                if (!cheques[i].IsComplete())
                {
                    DataReqd++;
                }
                // Update by mizan
                
                if (!cheques[i].Approved && cheques[i].StatusID != ChequeStatus.Approved)
                {
                    this.Approved = false;
                    this.ApprovalReqd++;
                }
                try
                {
                    CBatchTotal += Double.Parse(cheques[i].Amount);
                }
                catch { }
            }
        }
    }
}
