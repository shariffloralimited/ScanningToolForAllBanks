using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ChequeProcessing;
using System.Xml;

namespace Controls
{
    public partial class ChequeData : UserControl
    {
        public Cheque cheque;
        public ComponentFocusListener Listener;
        public bool Editable;
        public int UserRole;

        public static bool IsConnectedToCbs = bool.Parse(
            System.Configuration.ConfigurationSettings.AppSettings["IsConnectedToCbs"]);

        public ChequeData()
        {
            InitializeComponent();
            SetTextBoxesReadonly(UserRoles.BranchDataEntryChecker);
        }

        public void SetTextBoxesReadonly(int UserRole)
        {
            this.UserRole = UserRole;

            if (UserRole == UserRoles.Scanman)
            {
                TextActNo.ReadOnly = false;
                TextAmount.ReadOnly = true;
                TextAmount.Enabled = false;
                TextCustomerActNo.ReadOnly = true;
                TextRoutingNo.ReadOnly = false;
                TextSlNo.ReadOnly = false;
                TextTransCode.ReadOnly = false;
                //CheckDate.Enabled = false;
                //TextDate.ReadOnly = true;
                Editable = true;
                txtEndorse.ReadOnly = false;
                txtDepBranchCode.ReadOnly = false;
                if (cheque != null && cheque.IgnoreCheckDigit)
                {
                    chkIgnoreError.Enabled = true;
                }
            }
            else if (UserRole == UserRoles.BranchDataEntryMaker || UserRole == UserRoles.ZonalDataEntryMaker)
            {
                TextActNo.ReadOnly = false;
                TextAmount.ReadOnly = false;
                TextAmount.Enabled = true;
                TextCustomerActNo.ReadOnly = false;
                TextCustomerActNo.Enabled = true;
                txtRefNo.Enabled = true;
                TextRoutingNo.ReadOnly = false;
                TextSlNo.ReadOnly = false;
                TextTransCode.ReadOnly = false;
                //TextDate.ReadOnly= false;
                Editable = true;
                txtEndorse.ReadOnly = false;
            }
            else
            {
                TextActNo.ReadOnly = true;
                TextAmount.ReadOnly = true;
                TextAmount.Enabled = false;
                TextCustomerActNo.ReadOnly = true;
                TextRoutingNo.ReadOnly = true;
                TextSlNo.ReadOnly = true;
                TextTransCode.ReadOnly = true;
                txtRefNo.Enabled = false;
                TextCustomerActNo.Enabled = false;
                //TextDate.ReadOnly = true;
                //CheckDate.Enabled = false;
                Editable = false;
                txtEndorse.ReadOnly = true;
                chkIgnoreError.Enabled = false;

            }
        }

        private void CheckDate_CheckedChanged(object sender, EventArgs e)
        {
            //dateTimePicker1.Enabled = !dateTimePicker1.Enabled;
            //TextDate.ReadOnly = !TextDate.ReadOnly;
        }

        public void HideBenefitiaryInfo(bool Hide)
        {
            if (Hide)
            {
                GroupBenefitiaryInfo.Hide();
            }
            else
            {
                GroupBenefitiaryInfo.Show();
            }
        }

        public void SetCheque(Cheque cheque)
        {
            if (cheque == null)
            {
                if (this.cheque == null)
                {
                    return;
                }
                this.cheque = null;
                DefaultInfo();
                return;
            }
            this.cheque = cheque;
            ShowInfo();


            if (Editable)
            {
                ResetColorCode();
            }
            else
            {
                ColorCodeOff();
            }
            if (cheque.RejectReason != null && cheque.RejectReason != "")
            {
                GroupBoxRejectReason.Visible = true;
                TextRejectReason.Text = cheque.RejectReason;
            }
            else
            {
                GroupBoxRejectReason.Visible = false;
                TextRejectReason.Text = String.Empty;
            }
        }

        public void ColorCodeOff()
        {
            if (cheque == null)
            {
                return;
            }
            TextSlNo.BackColor = TextBox.DefaultBackColor;
            TextActNo.BackColor = TextBox.DefaultBackColor;
            TextRoutingNo.BackColor = TextBox.DefaultBackColor;
            TextTransCode.BackColor = TextBox.DefaultBackColor;
        }

        public void ResetColorCode()
        {
            cheque.CheckForErrors();
            if (cheque == null)
            {
                return;
            }
            if ((cheque.MICRError & ErrorTypes.InvalidChequeSlNo) != 0)
            {
                TextSlNo.BackColor = Color.Pink;
            }
            else if ((cheque.MICRError & ErrorTypes.BadChequeSlNo) != 0)
            {
                TextSlNo.BackColor = Color.Yellow;
            }
            else if (Editable)
            {
                TextSlNo.BackColor = Color.White;
            }
            else
            {
                TextSlNo.BackColor = Color.LightGray;
            }

            if ((cheque.MICRError & ErrorTypes.InvalidAccountNo) != 0)
            {
                TextActNo.BackColor = Color.Pink;
            }
            else if ((cheque.MICRError & ErrorTypes.BadAccountNo) != 0)
            {
                TextActNo.BackColor = Color.Yellow;
            }
            else if (Editable)
            {
                TextActNo.BackColor = Color.White;
            }
            else
            {
                TextActNo.BackColor = TextBox.DefaultBackColor;
            }

            ApplyColorCodeForRoutingNo();
           
            if ((cheque.MICRError & ErrorTypes.InvalidTransCode) != 0)
            {
                TextTransCode.BackColor = Color.Pink;
            }
            else if ((cheque.MICRError & ErrorTypes.BadTransCode) != 0)
            {
                TextTransCode.BackColor = Color.Yellow;
            }
            else if ((cheque.MICRError & ErrorTypes.UnknownTC) != 0)
            {
                TextTransCode.BackColor = Color.Aqua;
            }
            else if (Editable)
            {
                TextTransCode.BackColor = Color.White;
            }
            else
            {
                TextTransCode.BackColor = TextBox.DefaultBackColor;
            }
            Listener.ChangeGridColor(cheque.ChequeID);
        }

        public void ApplyColorCodeForRoutingNo()
        {
            if ((cheque.MICRError & ErrorTypes.InvalidRoutingNo) != 0)
            {
                TextRoutingNo.BackColor = Color.Pink;
            }
            else if ((cheque.MICRError & ErrorTypes.BadRoutingNo) != 0)
            {
                TextRoutingNo.BackColor = Color.Yellow;
            }
            else if ((cheque.MICRError & ErrorTypes.CheckDigitMismatch) != 0 && !cheque.IgnoreCheckDigit)
            {
                TextRoutingNo.BackColor = Color.Aqua;
                chkIgnoreError.Enabled = true;
            }
            else if (Editable)
            {
                TextRoutingNo.BackColor = Color.White;
            }
            else
            {
                TextRoutingNo.BackColor = TextBox.DefaultBackColor;
            }
        }
        
        public void NextMicrError()
        {

            if ((cheque.MICRError & ErrorTypes.InvalidRoutingNo |cheque.MICRError & ErrorTypes.BadRoutingNo) != 0)
            {
                TextRoutingNo.Focus();
            }
            else if ((cheque.MICRError & ErrorTypes.CheckDigitMismatch) != 0 && !cheque.IgnoreCheckDigit)
            {
                TextRoutingNo.Focus();
            }

            else if ((cheque.MICRError & ErrorTypes.InvalidChequeSlNo | cheque.MICRError & ErrorTypes.BadChequeSlNo) != 0)
            {
                TextSlNo.Focus();
            }
            else if ((cheque.MICRError & ErrorTypes.InvalidAccountNo | cheque.MICRError & ErrorTypes.BadAccountNo) != 0)
            {
                TextActNo.Focus();
            }
            else if ((cheque.MICRError & ErrorTypes.InvalidTransCode | cheque.MICRError & ErrorTypes.BadTransCode | cheque.MICRError & ErrorTypes.UnknownTC) != 0)
            {
                TextTransCode.Focus();
            }
            else
            {
                Listener.AllErrorSolved();
            }
        }

        public void ShowInfo()
        {
            if (cheque == null)
            {
                DefaultInfo();
            }
            Graphics g1 = PicBoxAmnt.CreateGraphics();
            this.Refresh();
            if (cheque.ImgFront != null)
            {
                g1.DrawImage(cheque.ImgFront, new Rectangle(0, 0, 220, 60),
                    new Rectangle(1000, 280, 460, 140), GraphicsUnit.Pixel);
            }
            g1.Dispose();
            TextActNo.Text = cheque.IssueActNo;

            //Updation by Mizan
            ChequesDB mdb = new ChequesDB();
            double checkAmount = mdb.GetCheckAmountByCheckID(cheque.ChequeID);
            cheque.Amount = checkAmount.ToString();
            //End
            
            try
            {
                double amt = double.Parse(cheque.Amount);
                TextAmount.Focus();
                if (amt == 0)
                {
                    TextAmount.Value = string.Empty;                    
                }
                else
                {
                    TextAmount.Value = amt.ToString();
                }
            }
            catch
            {
                TextAmount.Value = string.Empty;
                TextAmount.Focus();
            }
            TextStatus.Text = ChequeStatus.GetStatus(cheque.StatusID);
            txtAccInfo.Text = string.Empty;
            TextCustomerActNo.Text = "0";
            if (cheque.DepAccountNo == string.Empty)
                cheque.DepAccountNo = "0";
            TextCustomerActNo.Text = cheque.DepAccountNo;
            TextRoutingNo.Text = cheque.RoutingNo;
            TextSlNo.Text = cheque.CheckSLNo;
            TextTransCode.Text = cheque.IssueTransCode;
            txtDepBranchCode.Text = cheque.BranchCode;
            txtRefNo.Text = cheque.RefNo;
            // Changes made by mizan
            //TextCustomerActNo.Text = string.Empty;
            txtAccInfo.BackColor = Color.WhiteSmoke;
            if ((cheque.DepAccountNo != "0") && (IsConnectedToCbs))
            {
                CBS_getAccInfo();
            }
            else
            {
                txtAccInfo.Text = string.Empty;
            }
            if (cheque.endorseNo == 0)
            {
                txtEndorse.Text = String.Empty;
            }
            else
            {
                txtEndorse.Text = cheque.endorseNo.ToString().PadLeft(8, '0');
            }
            if (!cheque.ChequeDate.EndsWith("1900"))
            {
                //dateTimePicker1.Value = cheque.ChequeDate.Date;
                //dateControl1.dateValue = cheque.ChequeDate.Date.Day;
                //dateControl1.monthValue = cheque.ChequeDate.Date.Month;
                //dateControl1.yearValue = cheque.ChequeDate.Date.Year;
                //TextDate. = cheque.ChequeDate.Date;
            }
        }

        public void Focus()
        {
            TextAmount.Focus();
        }

        public void DefaultInfo()
        {
            TextStatus.Text = String.Empty;
            TextActNo.Text = String.Empty;
            TextAmount.Value = String.Empty;
            TextCustomerActNo.Text = "0";
            TextRoutingNo.Text = String.Empty;
            TextSlNo.Text = String.Empty;
            TextTransCode.Text = String.Empty;
            txtEndorse.Text = String.Empty;
            txtAccInfo.Text = string.Empty;
            TextActNo.BackColor = Color.DimGray;
            //dateTimePicker1.Value = new DateTime(2009, 1, 1);
            //dateControl1.currentDate = System.DateTime.Now;
            //dateControl1.dateValue = System.DateTime.Now.Day;
            //dateControl1.monthValue = System.DateTime.Now.Month;
            //dateControl1.yearValue = System.DateTime.Now.Year;
            //PicBoxAmnt.Tag = global::ChequeProcessing.Properties.Resources.AmountImage;
            PicBoxAmnt.Image = global::ChequeProcessing.Properties.Resources.AmountImage;
            GroupBoxRejectReason.Visible = false;
        }

        private void ComponentFocus_Leave(object sender, EventArgs e)
        {
            if (cheque == null)
            {
                return;
            }
            if (sender.GetType() == typeof(TextBox) && (((TextBox)sender).ReadOnly == true || ((TextBox)sender).Text == ""))
            {
                return;
            }
            if (Listener != null)
            {
                Listener.ComponentFocusLeave(sender, e);
            }
            
            //cheque.CheckForErrors();
            //ResetColorCode();
        }

        private void TextAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cheque == null)
            {
                return;
            }
            if (e.KeyChar == 13)
            {
                if (cheque.StatusID == ChequeStatus.JustScanned)
                {                    
                    NextMicrError();
                    if (cheque.StatusID < 3)
                    {
                        TextCustomerActNo.Focus();
                    }
                }
                else if(TextAmount.Text != string.Empty)
                {
                    //Update by Mizan


                    if (IsComplyWithHighValueRange())
                    {
                        cheque.Amount = TextAmount.Text;
                        UpdateCheckAmountByCheckID_TestPurpose(cheque.ChequeID, Convert.ToInt64(Convert.ToDouble(TextAmount.Value) * 100));
                        TextCustomerActNo.Focus();
                    }
                }
            }
        }

        private bool IsComplyWithHighValueRange()
        {
            bool IsComply = true;
            long chqamount = Int64.Parse(TextAmount.Text.Replace(",", "").Replace(".", ""));
            if ((chqamount < 500000) && (cheque.ClearingType == 9) && (Int32.Parse(cheque.IssueTransCode)) < 50)
            {
                MessageBox.Show("High Value Check must be 500000 and above");
                TextAmount.Text = "0";
                cheque.Amount = "0";
                IsComply = false;
            }
            return IsComply;
        }

        private void UpdateCheckAmountByCheckID_TestPurpose(Guid ChequeID, long CheckAmount)
        {
            ChequesDB db = new ChequesDB();
            db.UpdateChequeAmountByChequeID(ChequeID, CheckAmount);
        }
        private void TextCustomerActNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (MakerCheckerScreen.IsConnectedToCbs)
                {
                    if (TextCustomerActNo.Text.Length < 9)
                    {
                        MessageBox.Show("Invalid Account Number");
                        TextCustomerActNo.Focus();
                    }
                    else
                    {
                            CBS_getAccInfo();
                    }
                }
                else
                {
                    txtRefNo.Focus();
                }
            }
        }

        private void CBS_getAccInfo()
        {
            try
            {
                ChequeProcessing.CPSWS.Service1 cbs = new ChequeProcessing.CPSWS.Service1();
                var data = cbs.GetAccountInfoForCPS(TextCustomerActNo.Text);
                txtAccInfo.BackColor = Color.WhiteSmoke;
                if (string.IsNullOrEmpty(data.AccountInfo))
                {
                    txtAccInfo.Text = "";
                    MessageBox.Show("No Record Found");
                }
                else
                {
                    txtAccInfo.Text = data.AccountInfo;
                    if (data.StopPayment)
                    {
                        txtAccInfo.BackColor = Color.Red;
                        TextAmount.Text = string.Empty;
                        TextAmount.Focus();
                        UpdateCheckAmountByCheckID_TestPurpose(cheque.ChequeID, 0);
                    }
                    else
                    {
                        txtAccInfo.BackColor = Color.WhiteSmoke;
                    }
                    //cheque.ValidAccount = true;
                    txtAccInfo.Focus();
                }
            }
            catch
            {
                txtAccInfo.Text = "No Record Found.";
            }
            finally
            {
                ChequesDB db = new ChequesDB();
                db.UpdateBenefActNameByChequeID(cheque.ChequeID, TextCustomerActNo.Text);
            }
        }
        

        //private string GetStatus(ChequeProcessing.CPS_CBSWS_Service1.AccountInfo data)
        //{
        //    string status = "";
        //    if (data.blocked)
        //    {
        //        status = "BLOCKED";
        //    }
        //    if (data.closing)
        //    {
        //        if(status.Length > 0)
        //        status += " / CLOSED";
        //        else
        //            status += "CLOSED";
        //    }
        //    if (data.inactive)
        //    { if (status.Length > 0)
        //            status += " / INACTIVE";
        //        else
        //            status += "INACTIVE";
        //    }
        //    if (data.decOrLiq)
        //    {
        //        if (status.Length > 0)
        //            status += " / DECorLIQ";
        //        else
        //            status += "DECorLIQ";
        //    }
        //    if (status.Length == 0)
        //        status = "ACTIVE";

        //    return status;
        //}
        protected DataTable Flip(DataTable dt)
        {
            DataTable dt2 = new DataTable();
            for (int i = 0; i <= dt.Rows.Count; i++)
            {
                dt2.Columns.Add();
            }
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt2.Rows.Add();
                dt2.Rows[i][0] = dt.Columns[i].ColumnName;
            }
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    dt2.Rows[i][j + 1] = dt.Rows[j][i];
                }
            }
            return dt2;

        }

        private void TextMICR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && Editable)
            {
                Listener.ComponentFocusLeave(sender, e);
                cheque.CheckForErrors();
                ResetColorCode();
                NextMicrError();
            }
        }

        private void txtEndorse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && Listener != null)
            {
                Listener.ComponentFocusLeave(sender, e);
            }
        }

        //private void cmbActNames_Leave(object sender, EventArgs e)
        //{
        //    Listener.ComponentFocusLeave(sender, e);
        //}
        
        //private void cmbActNames_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 13 && Listener != null)
        //    {
        //        Listener.ComponentFocusLeave(sender, e);
        //        Listener.NextButtonFocus(sender, e);
        //    }
        //}

        private void MicrFocusLeave(object sender, EventArgs e)
        {
            try
            {
                Listener.ComponentFocusLeave(sender, e);
                cheque.CheckForErrors();
                ResetColorCode();
            }
            catch
            { }
        }

        private void txtAccInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && Listener != null)
            {
                //Listener.ComponentFocusLeave(sender, e);
                //Listener.NextButtonFocus(sender, e);
                if (string.IsNullOrEmpty(TextAmount.Text))
                {
                    TextAmount.Focus();
                }
                // Updated By Mizan
                else txtRefNo.Focus();
            }
        }

        private void txtAccInfo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextAmount.Text))
            {
                TextAmount.Focus();
            }
            else Listener.ComponentFocusLeave(sender, e);
        }

        private void TextAmount_Leave(object sender, EventArgs e)
        {
            if (TextAmount.Text != string.Empty)
            {
                //Update by Mizan
                //cheque.Amount = TextAmount.Text;  
                //UpdateCheckAmountByCheckID_TestPurpose(cheque.ChequeID, Convert.ToInt64(Convert.ToDouble(TextAmount.Value) * 100));
                IsComplyWithHighValueRange();
                BatchData d = new BatchData();
                d.Refresh();
                TextCustomerActNo.Focus();
            }
        }

        private void txtRefNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && Listener != null)
            {
                if (cheque != null)
                {
                    ChequesDB db = new ChequesDB();
                    db.UpdateBranchCodeAndRefNoByChequeID(cheque.ChequeID, txtDepBranchCode.Text, txtRefNo.Text);
                }
                Listener.ComponentFocusLeave(sender, e);
                Listener.NextButtonFocus(sender, e);
            }
        }
    }
}