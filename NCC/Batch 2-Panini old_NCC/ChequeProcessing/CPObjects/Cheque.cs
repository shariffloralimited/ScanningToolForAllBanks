using System;
using System.Data;
using System.Drawing;
using System.IO;

namespace ChequeProcessing
{
    public class Cheque
    {
        public int StatusID;
        public int ClearingType;
        public Guid ChequeID;

        public String MICR;
        public String CheckSLNo;
        public String RoutingNo;
        public String IssueActNo;
        public String IssueTransCode;

        public string BenefitiaryActName = string.Empty;

        private String amount;

        public String Amount
        {
            get
            {
                if (string.IsNullOrEmpty(amount))
                {
                    amount = "0";
                }
                return amount;
            }
            set { amount = value; }
        }
        public String DepAccountNo;

        public Image ImgFront;
        public Image ImgBack;
        public MemoryStream ImgFrontStream;
        public MemoryStream ImgBackStream;

        public String ImgFrontName;
        public String ImgBackName;

        public int MICRError;
        public bool ImageError;
        public bool InvalidRoutingNo;

        public string CDate;
        public string FilePath = System.Configuration.ConfigurationManager.AppSettings["TempImagePath"];
        public string BankCode = System.Configuration.ConfigurationManager.AppSettings["BankCD"];
        public bool IsDepSlip;

        public bool Complete;
        public bool Approved;
        public bool SentToMaker;
        public bool Modified;
        public bool Repaired;
        public bool MicrModified;

        public bool IgnoreCheckDigit;

        public string RejectReason;
        public string Status;

        public bool Editable;
        public bool Protected;

        public long endorseNo;

        public string itemSeqNo;
        private string branchCode = "";
        private string refNo = "";
        public string BranchCode
        {
            get { return branchCode; }
            set { branchCode = value; }
        }

        public string RefNo
        {
            get { return refNo; }
            set { refNo = value; }
        }
        public Cheque()
        {
            IsDepSlip = true;
            CheckForErrors();
        }

        public Cheque(string micr, MemoryStream ImgFront, MemoryStream ImgBack, string seqNo)
        {
            DepAccountNo = String.Empty;
            IsDepSlip = false;
            this.MICR = micr;
            this.itemSeqNo = seqNo;

            if (MICR.Contains("@") || MICR.Contains("!"))
            {
                MICR = MICR.Replace('@', '*');
                MICR = MICR.Replace('!', '*');
            }
            ExtractMicr();
            
            CheckForErrors();

            this.ImgFrontStream = ImgFront;
            this.ImgBackStream  = ImgBack;
        }

        public Cheque(DataRow row)
        {
            ChequeID = (Guid)row.ItemArray[0];
            CDate = row.ItemArray[1].ToString().PadLeft(8,'0');
            CheckSLNo = row.ItemArray[2].ToString();
            RoutingNo = row.ItemArray[3].ToString();
            IssueActNo = row.ItemArray[4].ToString();
            IssueTransCode = row.ItemArray[5].ToString();
            Amount = row.ItemArray[6].ToString();
            DepAccountNo = row.ItemArray[9].ToString();
            branchCode = row.ItemArray[15].ToString();
            RefNo = row.ItemArray[16].ToString();
            ClearingType = Int32.Parse(row.ItemArray[17].ToString());
            if (Amount.Length > 1)
            {
                Amount = Amount.Substring(0, Amount.Length - 2) + '.' + Amount.Substring(Amount.Length - 2);
            }
            StatusID = Int32.Parse(row.ItemArray[7].ToString());
            if (StatusID == ChequeStatus.SentToMaker)
            {
                SentToMaker = true;
            }
            if (StatusID == ChequeStatus.Approved)
            {
                Approved = true;
            }
            Status = ChequeStatus.GetStatus(StatusID);
            MICR = row.ItemArray[8].ToString();

            try
            {
                endorseNo = long.Parse(row.ItemArray[10].ToString());
            }
            catch { }

            RejectReason = row.ItemArray[13].ToString();
            //Protected = (Int32.Parse(row.ItemArray[10].ToString()) != 1);

            CheckForErrors();
            LoadImages();
        }

        private void ExtractMicr()
        {
            int indC1 = MICR.IndexOf('c');
            int indC2 = MICR.IndexOf("c ");
            int indC3 = MICR.LastIndexOf('c');
            int indD1 = MICR.IndexOf('d');

            if (indC1 >= 0)
            {
                try
                {
                    CheckSLNo = MICR.Substring(1, 7).Trim();
                }
                catch
                {
                    CheckSLNo = string.Empty;
                }
            }
            else
            {
                CheckSLNo = "*******";
            }
            if (indC2 >= 0 && indC2 < 15)
            {
                try{
                    RoutingNo = MICR.Substring(indC2 + 2, 9).Trim();
                }
                catch
                {
                    RoutingNo = string.Empty;
                }
            }
            else
            {
                RoutingNo = "*********";
            }
            if (indD1 >= 0 && indD1 < 25)
            {
                try{
                    IssueActNo = MICR.Substring(indD1 + 2, 13).Trim();
                }
                catch
                {
                    IssueActNo = string.Empty;
                }
            }
            else
            {
                IssueActNo = "*************";
            }
            if (indC3 >= 0)
            {
                try{
                    IssueTransCode = MICR.Substring(indC3 + 2, 2).Trim();
                }
                catch
                {
                    IssueTransCode = string.Empty;
                }
            }
            else
            {
                IssueTransCode = "**";
            }
        }

        public bool CheckDigitOk(String RoutingNo, int wght)
        {
            if (RoutingNo.Length != 9)
            {
                return false;
            }
            int length = (int)Math.Log10(wght) + 1;
            int[] WghtArray = new int[length];
            for (int i = length - 1; i >= 0 && wght > 0; i--)
            {
                WghtArray[i] = wght % 10;
                wght /= 10;
            }
            int num = 0;
            for (int i = 0; i < RoutingNo.Length - 1; i++)
            {
                num += (int)(RoutingNo[i] - '0') * WghtArray[i % length];
            }
            num = (10 - num % 10) % 10;
            return (num == (int)(RoutingNo[RoutingNo.Length - 1] - '0'));
        }

        public static Cheque[] CreateCheques(DataTable dt)
        {
            Cheque[] cheques = new Cheque[1000];
            for (int ind = 0; ind < dt.Rows.Count; ind++)
            {
                cheques[ind] = new Cheque(dt.Rows[ind]);
            }
            return cheques;
        }

        public void CheckForErrors()
        {
            MICRError = 0;
            if (CheckSLNo.Contains("*"))
            {
                MICRError |= ErrorTypes.BadChequeSlNo;
            }
            if (RoutingNo.Contains("*"))
            {
                MICRError |= ErrorTypes.BadRoutingNo;
            }

            if (RoutingNo.StartsWith(BankCode))
            {
                MICRError |= ErrorTypes.BadRoutingNo;
            }

            //long chqamount = Int64.Parse(Amount.Replace(",", "").Replace(".", ""));

            //if ((chqamount < 50000000) && (ClearingType == 9))
            //{
            //    MICRError |= ErrorTypes.BadRoutingNo;
            //} 

            
            if (IssueActNo.Contains("*"))
            {
                MICRError |= ErrorTypes.BadAccountNo;
            }
            if (string.IsNullOrEmpty(IssueTransCode))
            {
                MICRError |= ErrorTypes.InvalidTransCode;
            }
            
            if (IssueTransCode.Contains("*"))
            {
                MICRError |= ErrorTypes.BadTransCode;
            }
            if (CheckSLNo.Length != 7 || !IsValidMICR(CheckSLNo))
            {
                MICRError |= ErrorTypes.InvalidChequeSlNo;
            }
            if (RoutingNo.Length != 9 || !IsValidMICR(RoutingNo))
            {
                MICRError |= ErrorTypes.InvalidRoutingNo;
            }
            if (IssueActNo.Length != 13 || !IsValidMICR(IssueActNo))
            {
                MICRError |= ErrorTypes.InvalidAccountNo;
            }
            if (IssueTransCode.Length != 2 || !IsValidMICR(IssueTransCode))
            {
                MICRError |= ErrorTypes.InvalidTransCode;
            }

            if (!string.IsNullOrEmpty(IssueTransCode))
            {
                try
                {
                    if (!CheckCurrency(Convert.ToInt16(IssueTransCode)))
                    {
                        MICRError |= ErrorTypes.InvalidTransCode;
                    }
                }
                catch
                {
                    MICRError |= ErrorTypes.InvalidTransCode;
                }
            }

            //if (Properties.Settings.Default.BatchCurrency == "BDT")
            //{
            //    if(!string.IsNullOrEmpty(IssueTransCode))
            //    {
            //        if (Convert.ToInt16(IssueTransCode) > 55)
            //        {
            //            MICRError |= ErrorTypes.InvalidTransCode;
            //        }
            //    }
            //}
            //if (Properties.Settings.Default.BatchCurrency != "BDT")
            //{
                    
            //}

            bool validTC = false;
            for (int i = 0; i < TransCode.ValidCodes.Length; i++)
            {
                if (TransCode.ValidCodes[i] == IssueTransCode)
                {
                    validTC = true;
                    break;
                }
            }
            if (!validTC)
            {
                MICRError |= ErrorTypes.UnknownTC;
            }
            if (!CheckDigitOk(RoutingNo, 571))
            {
                MICRError |= ErrorTypes.CheckDigitMismatch;
                InvalidRoutingNo = true;
            }
        }

        private bool CheckCurrency(int IssueTransCode)
        {
            ChequesDB db = new ChequesDB();
            var list = db.GetTransCodeByCCY(Properties.Settings.Default.BatchCurrency);
            if (list != null && list.Contains(IssueTransCode.ToString()))
                return true;
            else
                return false;
        }
        public bool IsValidMICR(string numberString)
        {
            char[] ca = numberString.ToCharArray();
            for (int i = 0; i < ca.Length; i++)
            {
                if ((ca[i] > 57 || ca[i] < 48 ) && ca[i] != '*')
                    return false;
            }
            return true;
        }

        public string ChequeDate
        {
            get
            {
                if (this.CDate == null)
                {
                    return "01011900";
                }
                return CDate;
            }
            set
            {
                this.CDate = value;
            }
        }

        public bool isReady()
        {
            CheckForErrors();
            if (MICRError == 0)
            {
                return true;
            }
            else if (MICRError == ErrorTypes.CheckDigitMismatch && IgnoreCheckDigit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsComplete()
        {
            if (!Complete)
            {
                Complete = true;
                
                CheckForErrors();
                double amt = 0;
                try
                {
                    amt = double.Parse(amount);
                }
                catch { }
                if (Amount == null||amount == null || amount == "" || amt == 0|| DepAccountNo == null || DepAccountNo.Trim() == "")
                {
                    Complete =  false;
                }
            }
            
            return Complete;
        }

        public void LoadImages()
        {
            ChequesDB db = new ChequesDB();
            DataTable dt = db.GetChequeImages(ChequeID);
            if (dt.Rows.Count > 0)
            {
                ImgFront = ImageConverter.ByteArrayToImage((byte[])dt.Rows[0].ItemArray[0]);
                ImgBack = ImageConverter.ByteArrayToImage((byte[])dt.Rows[0].ItemArray[1]);
            }
        }
    }
}
