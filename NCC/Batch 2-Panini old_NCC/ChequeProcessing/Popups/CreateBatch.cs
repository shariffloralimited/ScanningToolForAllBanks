using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Controls;
using System.Globalization;
using System.Configuration;
using System.Data.SqlClient;

namespace ChequeProcessing
{
    public partial class CreateBatch : Form
    {
        int UserID;
        int BatchOption;
        int UserRole;
        BatchTraceListener listnr;
        Guid BatchNo;
        bool ScanDateByAdmin = false;
        int OHVCT = 2359;
        int ORVCT = 2359;

        public CreateBatch(BatchTraceListener listnr, int UserID, int BatchOption, Guid BatchNo, int UserRole)
        {
            InitializeComponent();
            if (ChequeProcessing.Properties.Settings.Default.RoleID == 3)
                ButtonCreate.Enabled = false;
            this.UserID = UserID;
            this.UserRole = UserRole;
            InitializeComboBox();
            this.dateTimePicker1.Value = GetBatchDateFromBankSettings();
            this.listnr = listnr;
            this.BatchOption = BatchOption;
            this.BatchNo = BatchNo;
            this.cmbCurrency.SelectedIndex = 0;
            if (BatchOption == BatchOptions.Edit)
            {
                this.Text = "Batch Options";
                LoadBatch(BatchNo);
            }
            else if (BatchOption == BatchOptions.View)
            {
                this.Text = "Batch Options";
                LoadBatch(BatchNo);
                DisableEditing();
            }
            else if (BatchOption == BatchOptions.Edit)
            {
                LoadBatch(BatchNo);
            }
            else if (BatchOption == BatchOptions.EditForMaker)
            {
                this.Text = "Batch Options";
                LoadBatch(BatchNo);
                cmbCurrency.Enabled = false;
            }
            else
            {
                BatchDB db = new BatchDB();
                int BatchNoOfTheDay = db.GetNextBatchCount();
                string BatchName =
                    DateTime.Today.Year.ToString() +
                    DateTime.Today.Month.ToString("00") +
                    DateTime.Today.Day.ToString("00") +
                    "-" +
                    BatchNoOfTheDay.ToString("000");
                TextBatchName.Text = BatchName;
            }
            if (ComboBoxPresentingBranch.Items.Count == 1)
            {
                ComboBoxPresentingBranch.Enabled = false;
            }
        }
        public DateTime GetBatchDateFromBankSettings()
        {
            try
            {
                ScanDateByAdmin = bool.Parse(ConfigurationManager.AppSettings["ScanDatebyAdmin"]);
            }
            catch { }


            if(!ScanDateByAdmin)
                return SystemInfo.ScanDate;

            dateTimePicker1.Enabled = false;
            
            SettingsDB db = new SettingsDB();
            SqlDataReader reader = db.GetBatchDateFromBankSettings();
            reader.Read();
            OHVCT = Int32.Parse(reader["OHVCT"].ToString());
            ORVCT = Int32.Parse(reader["ORVCT"].ToString());
            string EndorseDate = reader["EndorseDate"].ToString();
            reader.Close();
            reader.Dispose();

            return DateTime.ParseExact(EndorseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);              
        }
        public void DisableEditing()
        {
            ComboBoxDocType.Enabled = false;
            ComboBoxPrsmntLevel.Enabled = false;
            ComboBoxClearingType.Enabled = false;
            ComboBoxPresentingBranch.Enabled = false;
            cmbCurrency.Enabled = false;
            dateTimePicker1.Enabled = false;
            TextBatchTotal.ReadOnly = true;
            TextTotalChecks.ReadOnly = true;
            TextBatchName.ReadOnly = true;
            CheckBoxCorpAcct.Enabled = false;
        }
        public void InitializeComboBox()
        {
            BanksDB db1 = new BanksDB();
            DataTable dt = db1.GetBranchesByUserID(UserID, UserRole);
            if (dt.Rows.Count > 1)
            {
                DataRow dr = dt.NewRow();
                dr["BranchName"] = "[Select Branch]";
                dr["RoutingNo"] = "000000000";
                dt.Rows.InsertAt(dr, 0);
            }


            ComboBoxPresentingBranch.DataSource = dt;
            ComboBoxPresentingBranch.DisplayMember = "BranchName";
            ComboBoxPresentingBranch.ValueMember = "RoutingNo";
            
            DataTable dtDocTypes = (new BatchDB()).GetDocumentTypes();
            this.ComboBoxDocType.DataSource = dtDocTypes;
            this.ComboBoxDocType.DisplayMember = "DocumentTypeName";
            this.ComboBoxDocType.ValueMember = "DocumentTypeInd";

            DataTable dtClearingTypes = (new BatchDB()).GetClearingTypes();
            this.ComboBoxClearingType.DataSource = dtClearingTypes;
            this.ComboBoxClearingType.DisplayMember = "ClearingTypeName";
            this.ComboBoxClearingType.ValueMember = "ClearingType";

            DataTable dtRepIndicators = (new BatchDB()).GetRepIndicators();
            this.ComboBoxPrsmntLevel.DataSource = dtRepIndicators;
            this.ComboBoxPrsmntLevel.DisplayMember = "RepIndName";
            this.ComboBoxPrsmntLevel.ValueMember = "RepInd";
        }
        private void CheckBoxCorpAcct_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxCorpAcct.Checked)
            {
                TextCorporateAccount.ReadOnly = false;
                TextCorporateAccount.Focus();
            }
            else
            {
                TextCorporateAccount.ReadOnly = true;
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }
        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            if (ComboBoxPresentingBranch.SelectedText == "000000000")
            {
                MessageBox.Show("Select a Branch first");
                return;
            }

            string ClearingType = ComboBoxClearingType.SelectedValue.ToString();
            if ((this.BatchOption == BatchOptions.New) &&(ScanDateByAdmin))
            {
                string Day0 = dateTimePicker1.Value.Day.ToString().PadLeft(2, '0');//ToString().Substring(0, 2)
                string Month0 = dateTimePicker1.Value.Month.ToString().PadLeft(2, '0');//ToString().Substring(3, 2)
                string Year0 = dateTimePicker1.Value.Year.ToString().PadLeft(2, '0');//.Substring(6, 4)


                string Day = System.DateTime.Today.Day.ToString().PadLeft(2,'0');
                string Month = System.DateTime.Today.Month.ToString().PadLeft(2, '0');
                string Year = System.DateTime.Today.Year.ToString().PadLeft(2,'0');

                int AdminDate = Int32.Parse(Year0 + Month0 + Day0);
                int SysDate =  Int32.Parse(Year + Month + Day);

                if (AdminDate < SysDate)
                {
                    MessageBox.Show("Backdated Endorse Date");
                    return;
                }

                string CurTime = System.DateTime.Now.ToString("HHmm");
                int CurVal = ORVCT;
                if (ClearingType == "9")
                    CurVal = OHVCT;

                if ((dateTimePicker1.Value == System.DateTime.Today))
                {
                   if(Int32.Parse(CurTime) > CurVal)
                   {
                       MessageBox.Show("Cutoff Time Expired");
                       return;
                   }
                }
            }

            string BatchDate = String.Format("{0:ddMMyy}", dateTimePicker1.Value);       
            int PrsmntLevel = Int32.Parse(ComboBoxPrsmntLevel.SelectedValue.ToString());
            string docTypeInd = ComboBoxDocType.SelectedValue.ToString();
            string Branch = ComboBoxPresentingBranch.SelectedValue.ToString();
            long batchTotal = 0;
            int TotalCheques = 0;
            bool NoCharge = chkNoCharge.Checked;
            try
            {
                string batchTotalText = TextBatchTotal.Value.Replace(",","");
                if(batchTotalText.IndexOf('.') < 0)
                    batchTotal = long.Parse(batchTotalText + "00");
                else
                    batchTotal = long.Parse(batchTotalText.Substring(0, batchTotalText.IndexOf('.')) +
                        (batchTotalText.Substring(batchTotalText.IndexOf('.') + 1) + "00").Substring(0, 2));
            }
            catch
            {
                MessageBox.Show("Please insert a valid Batch Total");
                return;
            }
            try
            {
                TotalCheques = Int32.Parse(TextTotalChecks.Text);
            }
            catch
            {
                MessageBox.Show("Please insert a valid Cheque Count");
                return;
            }
            bool endorsed = false;
            BatchDB db = new BatchDB();
            if (this.BatchOption == BatchOptions.New)
            {
                this.BatchNo = db.CreateNewBatch(BatchDate, PrsmntLevel, Branch, cmbCurrency.SelectedItem.ToString(),
                    ClearingType, batchTotal, endorsed, TotalCheques, docTypeInd, NoCharge, UserID, UserID);
                Properties.Settings.Default.LoadedBatchID = this.BatchNo;
                Properties.Settings.Default.BatchCurrency = cmbCurrency.SelectedItem.ToString();
            }
            else
            {
                db.UpdateOutwardBatch(this.BatchNo, BatchDate, PrsmntLevel, Branch, cmbCurrency.SelectedItem.ToString(),
                    ClearingType, batchTotal, endorsed, TotalCheques, docTypeInd, NoCharge, UserID);
                ChequeProcessing.Properties.Settings.Default.BatchCurrency = cmbCurrency.SelectedItem.ToString();
            }
            listnr.BatchReady(this.BatchNo);
            this.Hide();
            this.Dispose();

        }
        public void LoadBatch(Guid BatchNo)
        {
            this.Text = "Edit Batch";
            BatchDB db = new BatchDB();
            DataTable dt = db.GetSingleBatch(BatchNo, UserID);
            ComboBoxPresentingBranch.SelectedValue = dt.Rows[0].ItemArray[2].ToString();

            ComboBoxDocType.SelectedValue = dt.Rows[0].ItemArray[8].ToString();
            ComboBoxPrsmntLevel.SelectedValue = dt.Rows[0].ItemArray[4].ToString();
            ComboBoxClearingType.SelectedValue = dt.Rows[0].ItemArray[5].ToString();
            dateTimePicker1.Value = DateTime.ParseExact(dt.Rows[0].ItemArray[1].ToString(), "ddMMyy", CultureInfo.InvariantCulture);
            TextBatchTotal.Value = (double.Parse(dt.Rows[0].ItemArray[6].ToString()) / 100).ToString();
            TextTotalChecks.Text = dt.Rows[0].ItemArray[10].ToString();
            TextBatchName.Text = dt.Rows[0].ItemArray[3].ToString();
            chkNoCharge.Checked  = Boolean.Parse(dt.Rows[0].ItemArray[15].ToString());
            cmbCurrency.Text = dt.Rows[0].ItemArray[16].ToString();
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (sender == ComboBoxPresentingBranch)
                {
                    TextTotalChecks.Focus();
                }
                if (sender == TextTotalChecks)
                {
                    TextBatchTotal.Focus();
                }
                else if (sender == TextBatchTotal)
                {
                    ComboBoxClearingType.Focus();
                }
                else if (sender == ComboBoxClearingType)
                {
                    ComboBoxPrsmntLevel.Focus();
                }
                else if (sender == ComboBoxPrsmntLevel)
                {
                    ButtonCreate.Focus();
                }
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SystemInfo.ScanDate = dateTimePicker1.Value;
        }
        private void cmbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbCurrency.Text == "BDT")
            {
                ComboBoxClearingType.Enabled = true;
                ComboBoxClearingType.SelectedValue = "1";
            }
            else
            {
                ComboBoxClearingType.Enabled = false;
                ComboBoxClearingType.SelectedValue = "9";
            }
        }
    }

}