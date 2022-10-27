using System;
using System.Data;
using System.Windows.Forms;
using System.Net;

namespace ChequeProcessing
{
    public partial class ScannerScreen : Form, BatchTraceListener, ComponentFocusListener, ScannerRangerListener, ScanSettingsListener, SelectorListener
    {
        private int UserID;
        private int UserRole;
        private Batch currentBatch;
        private int CurStatus;

        private string loginID;
        private int PrevLineNo;

        private string BankRoutingNo;

        private int toEndorse = 1;
        private string startSeqNo;

        private bool chequeShown;

        public int CurrentView;

        private ScannerRanger scanner;
        private SplashScreen MyScreen;

        private bool initializing;

        DataTable ChequeList;
        DataTable ChequeDetail;

        IPAddress[] address = Dns.GetHostAddresses(Dns.GetHostName());

        private int selectedIndex;
        private int TotImages;

        private string today;

        public RoleSelector selector;
        private int ItemSeqIncementor = 1;
        public ScannerScreen(UserInfo ui)
        {
            InitializeComponent();
           // ribsButton3.Enabled = false;
            ButtonDiscard.Enabled = false;
            DetailGridView.Dock = DockStyle.Fill;
            ListGridView.Dock = DockStyle.Fill;
            DetailGridView.AutoGenerateColumns = false;
            ListGridView.AutoGenerateColumns = false;

            this.UserID = ui.UserID;
            this.UserRole = ui.RoleID;
            this.loginID = ui.loginID;

            this.today = String.Format("{0:ddMMyy}", DateTime.Today);

            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CreateSpecificCulture("da-DK");
            System.Globalization.DateTimeStyles styles = System.Globalization.DateTimeStyles.None;

            PanelChequeView.Dock = DockStyle.Fill;

            ChequesDB db = new ChequesDB();

            selectedIndex = 0;
            ButtonPrev.Enabled = false;
            ButtonNext.Enabled = false;

            BatchInfo1.SetUser(ui);

            ChequeInfo.SetTextBoxesReadonly(UserRoles.Scanman);
            ChequeInfo.chkIgnoreError.CheckedChanged += new EventHandler(chkIgnoreError_CheckedChanged);
            ChequeInfo.HideBenefitiaryInfo(true);
            ChequeInfo.Listener = this;
            DressCheckList();
           // BindUserDetails(this.UserID);
        }

        //private void BindUserDetails(int UserID)
        //{
        //    UsersDB db = new UsersDB();
        //    UserDetail u = db.GetUserDetails(UserID);
        //    lblUserBranch.Text = "Branch: " + u.BranchName;
        //    lblUserName.Text = "Name: " + u.UserName;
        //}

        #region Action Event Handler Code...

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            StartScan();
        }

        private void ButtonScanSettings_Click(object sender, EventArgs e)
        {
            ScanSettings frm = new ScanSettings();
            frm.setListener(this);
            frm.ShowDialog();
        }

        private void ButtonStopScan_Click(object sender, EventArgs e)
        {
            if (scanner != null)
            {
                scanner.StopScan();
            }
        }

        private void ButtonReload_Click(object sender, EventArgs e)
        {
            if (currentBatch == null)
            {
                MessageBox.Show("Create or Load a Batch First", "No Batch", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable ChequeDetailEmpty = new DataTable();
            DataTable ChequeListEmpty = new DataTable();
            DetailGridView.DataSource = ChequeListEmpty = ChequeDetail.Clone();
            ListGridView.DataSource = ChequeDetailEmpty = ChequeDetail.Clone();
            LoadCurrentBatch(true);
        }

        private void ButtonBadMICRs_Click(object sender, EventArgs e)
        {

        }

        private void ButtonSaveBatch_Click(object sender, EventArgs e)
        {
            SaveAndSend(false);
        }

        private void ButtonSendBatch_Click(object sender, EventArgs e)
        {
            if (currentBatch == null)
            {
                MessageBox.Show(
                    "No batch found to send! Try creating a new batch or loading an existing batch",
                    "No Batch Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
            BatchBalance balance = new BatchBalance(currentBatch.BatchID);
            if (!balance.BalanceCheques())
            {
                MessageBox.Show("The no. of cheques is not equal to batch size. Cannot send batch.",
                    "Cannot send batch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveAndSend(true);
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            CreateBatch form = new CreateBatch(this, UserID, BatchOptions.New, new Guid("00000000-0000-0000-0000-000000000000"), UserRole);
            form.ShowDialog();
        }

        private void ButtonLogoff_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Logoff?", "Confirm Logoff",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LogOff();
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Exit?", "Confirm Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CloseCurrentBatch();
                Environment.Exit(0);
            }
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            if (MyScreen == null)
            {
                MyScreen = new SplashScreen();
            }
            MyScreen.SetText("Connecting Scanner...");
            MyScreen.Visible = true;
            if (scanner == null)
            {
                scanner = new ScannerRanger(this);
            }
            scanner.StartUp();
        }

        private void ButtonListView_Click(object sender, EventArgs e)
        {
            SwitchView(ViewOption.ListView);
        }

        private void ButtonDetailView_Click(object sender, EventArgs e)
        {
            SwitchView(ViewOption.DetailView);
        }

        private void ButtonPrev_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 1)
            {
                return;
            }
            else
            {
                selectedIndex--;
                ButtonNext.Enabled = true;
                ListGridView.Rows[selectedIndex].Selected = true;
            }
            HandleButtonDisabling();
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (selectedIndex >= TotImages)
            {
                return;
            }
            else
            {
                selectedIndex++;
                ButtonPrev.Enabled = true;
                ListGridView.Rows[selectedIndex].Selected = true;
            }
            HandleButtonDisabling();
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            OpenBatch form = new OpenBatch(this, BatchOptions.Open, UserID, UserRole);
            form.ShowDialog();
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (currentBatch == null)
            {
                MessageBox.Show("Load a batch First");
            }
            else
            {
                SaveAndSend(false);
                CreateBatch form = new CreateBatch(this, UserID, BatchOptions.Edit, currentBatch.BatchID,  UserRole);
                form.ShowDialog();
            }
        }

        private void Tab_Click(object sender, EventArgs e)
        {
            if (sender == TabRepair)
            {
                SwitchView(ViewOption.DetailView);
                if (currentBatch != null && currentBatch.cheques[selectedIndex] != null)
                {
                    ChequeInfo.SetTextBoxesReadonly(UserRoles.Scanman);
                    ChequeInfo.ResetColorCode();
                    ChequeInfo.NextMicrError();
                }
            }
            else
            {
                ChequeInfo.SetTextBoxesReadonly(UserRoles.BranchDataEntryChecker);
            }
            ShowCurrentCheque();
        }

        private void ScannerScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogOff();
            this.Dispose();
        }

        private void ButtonDeleteCheque_Click(object sender, EventArgs e)
        {
            if (currentBatch == null)
            {
                MessageBox.Show("Batch is not available to delete", "No Batch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (selectedIndex < 0 || selectedIndex >= ListGridView.RowCount)
            {
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete this Cheque?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SaveAndSend(false);
                ChequesDB db = new ChequesDB();
                db.DeleteCheque(
                    currentBatch.cheques[selectedIndex].ChequeID,
                    "",
                    UserID,
                    address[0].ToString()
                );
                LoadCurrentBatch(false);
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (currentBatch == null)
            {
                MessageBox.Show("Batch is not available to delete", "No Batch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete this Batch?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BatchDB db = new BatchDB();
                db.DeleteBatch(currentBatch.BatchID, UserID, address[0].ToString());
                CloseCurrentBatch();
                SetStatus(SystemStatus.BatchDeleted);
            }
        }

        private void ButtonInitialize_Click(object sender, EventArgs e)
        {
            BatchDB db = new BatchDB();
            int n = db.InitializeData();
            if (n > 0)
            {
                MessageBox.Show("Initialization of batches Successful!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Could not initialize! No Batches Found", "No Batch", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (currentBatch == null)
            {
                return;
            }
            if (ListGridView.SelectedRows.Count > 0 && !initializing)
            {
                selectedIndex = ListGridView.SelectedRows[0].Index;
                ShowCurrentCheque();
            }
            initializing = false;
            HandleButtonDisabling();
        }

        #endregion
        public void StartingUp()
        {
            SetStatus(SystemStatus.Connecting);
        }

        public void CannotConnect()
        {
            MyScreen.Visible = false;
            SetStatus(SystemStatus.NotConnected);
        }

        public void ChequeScanned(Cheque cheque)
        {
            string MICRValidation;
            long Amount;
            Guid ChequeID;
            ChequesDB db = new ChequesDB();

            if (toEndorse == 1)
            {
                toEndorse = 0;
            }

            currentBatch.cheques[selectedIndex] = cheque;
            if ((currentBatch.cheques[selectedIndex].MICRError & ErrorTypes.BadMICR) == 0)
            {
                MICRValidation = MICRValidIndicator.GoodRead;
            }
            else
            {
                MICRValidation = MICRValidIndicator.GoodReadMissingField;
            }
            Amount = 0;
            if (currentBatch.cheques[selectedIndex].Amount != "")
            {
                try
                {
                    Amount = Int64.Parse(currentBatch.cheques[selectedIndex].Amount);
                }
                catch
                {
                }
            }

            ChequeID = db.InsertCheque(
                new DateTime(1900, 1, 1),
                currentBatch.cheques[selectedIndex].CheckSLNo,
                currentBatch.cheques[selectedIndex].RoutingNo,
                currentBatch.cheques[selectedIndex].IssueActNo,
                currentBatch.cheques[selectedIndex].IssueTransCode,
                Amount,
                currentBatch.cheques[selectedIndex].ImgFrontName,
                currentBatch.cheques[selectedIndex].ImgBackName,
                ChequeStatus.JustScanned,
                currentBatch.BatchID,
                "", // (Beneficiary Act. No.)To be edited later.....
                // Changes made by mizan for item sequence number
                GetItemSeqNo(currentBatch.batchCounter,selectedIndex),
                //currentBatch.cheques[selectedIndex].itemSeqNo,
                address[0].ToString(),
                UserID,
                MICRValidation);
            db.InsertChequeImages(ChequeID, currentBatch.BatchID,
                currentBatch.cheques[selectedIndex].ImgFrontStream,
                currentBatch.cheques[selectedIndex].ImgBackStream,
                UserID,
                address[0].ToString());
            selectedIndex++;
            TotImages++;
        }

        public string GetItemSeqNo(int batchCounter, int curIndex)
        {           
            string source = "1";
            string dDate = System.DateTime.Today.ToString("yyyyMMdd").Substring(3);

            string strItemSequenceNo = source + dDate + batchCounter.ToString().PadLeft(3, '0') + ItemSeqIncementor.ToString().PadLeft(3, '0');
            ItemSeqIncementor++;
            return strItemSequenceNo;
        }
        public void ScanningCompleted()
        {
            MyScreen.Visible = false;
            LoadCurrentBatch(false);
            ButtonStartScan.Enabled = true;
            ButtonStopScan.Enabled = false;
            SetStatus(SystemStatus.Scanned);
            toEndorse = 0;
        }

        public void ScanningSemiCompleted()
        {
            MyScreen.Visible = false;
            LoadCurrentBatch(false);
            ButtonStartScan.Enabled = true;
            ButtonStopScan.Enabled = false;
            StartScan();
            SetStatus(SystemStatus.Scanned);
        }

        public void ScannerReady()
        {
            MyScreen.Visible = false;
            ButtonStartScan.Enabled = true;
            SetStatus(SystemStatus.Connected);
        }

        public void ScanningStarted()
        {
            ButtonStartScan.Enabled = false;
            ButtonStopScan.Enabled = true;
        }

        public void ShowScannerStatus(int Status)
        {
        }

        public void DressCheckList()
        {
            for (int i = 0; i < DetailGridView.RowCount; i++)
            {
                DataGridViewRow drv1 = ListGridView.Rows[i];
                DataGridViewRow drv2 = DetailGridView.Rows[i];
                if (currentBatch.cheques[i].RejectReason != null && currentBatch.cheques[i].RejectReason.StartsWith("DUPLICATE:"))
                {
                    drv1.DefaultCellStyle.BackColor = System.Drawing.Color.Coral;
                    drv2.DefaultCellStyle.BackColor = System.Drawing.Color.Coral;
                }
                else if ((currentBatch.cheques[i].MICRError & ErrorTypes.InvalidMICR) != 0)
                {
                    drv1.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                    drv2.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                }
                else if ((currentBatch.cheques[i].MICRError & ErrorTypes.BadMICR) != 0)
                {
                    drv1.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                    drv2.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                }
                else if ((currentBatch.cheques[i].MICRError & ErrorTypes.CheckDigitMismatch) != 0 ||
                    (currentBatch.cheques[i].MICRError & ErrorTypes.UnknownTC) != 0)
                {
                    drv1.DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                    drv2.DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                }
            }
        }

        private void StartScan()
        {
            ChequesDB chequesDB = new ChequesDB();
            if (currentBatch == null)
            {
                MessageBox.Show("Open or Create a Batch First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            toEndorse = ScanSettings.toEndorse; 
            if (toEndorse != 0)
            {
                if (currentBatch.toEndorse == false)
                {
                    toEndorse = 1;
                }
            }
            if (MyScreen == null)
            {
                MyScreen = new SplashScreen();
            }
            MyScreen.SetText("Scanning! Please wait...");
            MyScreen.Visible = true;
            if (toEndorse == 0)
            {
                DateTime beginDate = new DateTime(1900, 1, 1);
                int curDate = DateTime.Today.Subtract(beginDate).Days;
                int curTime = (int)(DateTime.Now.Subtract(DateTime.Today).TotalSeconds);
                startSeqNo = GetItemSeqNo(currentBatch.batchCounter, 0);
            }
            int lineNo = currentBatch.presentmment;
            //if (lineNo > 1)
            //    lineNo = lineNo + 2;
            scanner.StartScan
                ((toEndorse == 1),
                startSeqNo,
                currentBatch.presentingRoutingNo,
                currentBatch.batchDate,
                lineNo);
            selectedIndex = 0;
            PrevLineNo = currentBatch.presentmment;
            ScanSettings.toEndorse = 1;
        }
        
        public void LoadCurrentBatch(bool Complete)
        {
            ChequesDB db = new ChequesDB();

            ChequeDetail = db.GetCheckDetailByBatchNo(currentBatch.BatchID, ChequeStatus.JustScanned, Complete,UserID);

            initializing = true;

            currentBatch = new Batch(currentBatch.BatchID, UserID, ChequeDetail);

            DetailGridView.DataSource = ChequeDetail;
            ListGridView.DataSource = ChequeDetail;

            BatchInfo1.SetBatch(currentBatch);

            TotImages = currentBatch.TotalCheques;
            if (!chequeShown)
            {
                selectedIndex = 0;
            }
            ShowCurrentCheque();

            BatchDB db1 = new BatchDB();
            db1.LockBatch(currentBatch.BatchID, UserID);

            DressCheckList();
            SetStatus(SystemStatus.BatchLoaded);

            DataTable dt = db.FindDuplicateCheckByBatchID(currentBatch.BatchID);
            if (dt.Rows.Count > 0)
            {
                Popups.DuplicateCheckList form = new Popups.DuplicateCheckList(dt);
                form.ShowDialog();
            }
        }

        private void CloseCurrentBatch()
        {
            if (currentBatch == null)
            {
                return;
            }
            if (currentBatch.BatchID.ToString() != "00000000-0000-0000-0000-000000000000")
            {
                BatchDB db = new BatchDB();
                db.UnlockBatch(currentBatch.BatchID);
            }
            DataTable ChequeDetailEmpty = new DataTable();
            DataTable ChequeListEmpty = new DataTable();
            DetailGridView.DataSource = ChequeListEmpty = ChequeDetail.Clone();
            ListGridView.DataSource = ChequeDetailEmpty = ChequeDetail.Clone();
            ChequeInfo.SetCheque(null);
            imagePanel1.SetBackImage(null);
            imagePanel1.SetFrontImage(null);
            BatchInfo1.SetBatch(null);
            currentBatch = null;
            SetStatus(SystemStatus.BatchClosed);
            chequeShown = false;
        }

        private void LogOff()
        {
            if (MyScreen == null)
            {
                MyScreen = new SplashScreen();
            }
            MyScreen.SetText("Logging off. Please wait...");
            MyScreen.Visible = true;
            CloseCurrentBatch();
            
            if (scanner != null)
            {
                scanner.ShutDown();
                scanner.Dispose();
            }
            this.Hide();
            try
            {
                selector.Show();
                MyScreen.Visible = false;
                this.Dispose();
            }
            catch
            {
                MyScreen.Visible = false;
                this.Dispose();
            }
        }

        public void BatchReady(Guid BatchNo)
        {
            if (this.currentBatch == null || this.currentBatch.BatchID.ToString() == "00000000-0000-0000-0000-000000000000")
            {

            }
            else
            {
                CloseCurrentBatch();
            }
            try
            {
                this.currentBatch = new Batch(BatchNo, UserID);
                LoadCurrentBatch(false);
                //if (PrevLineNo != currentBatch.presentmment && scanner != null)
                //{
                //    ButtonStartScan.Enabled = false;
                //    scanner.ShutDown();
                //}
            }
            catch (BatchLockedExeption ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetStatus(int status)
        {
            CurStatus = status;
            switch (CurStatus)
            {
                case SystemStatus.Connected:
                    StatusImage.Image = global::ChequeProcessing.Properties.Resources.Connected;
                    StatusText.Text = "Scanner is connected.";
                    break;
                case SystemStatus.Connecting:
                    StatusImage.Image = global::ChequeProcessing.Properties.Resources.Connected;
                    StatusText.Text = "Connecting Scanner.";
                    break;
                case SystemStatus.BatchSent:
                    StatusImage.Image = global::ChequeProcessing.Properties.Resources.Connected;
                    StatusText.Text = "Batch Sent successfully.";
                    break;
                case SystemStatus.NotConnected:
                    StatusImage.Image = global::ChequeProcessing.Properties.Resources.NotConnected;
                    StatusText.Text = "Scanner is not connected.";
                    break;
                case SystemStatus.Scanned:
                    StatusImage.Image = global::ChequeProcessing.Properties.Resources.ScanSuccessfully;
                    StatusText.Text = "Scanned Successfully";
                    break;
                case SystemStatus.ChequeNotFound:
                    StatusImage.Image = global::ChequeProcessing.Properties.Resources.CheNotFound;
                    StatusText.Text = "Cheque Not Found";
                    break;
                case SystemStatus.Saved:
                    StatusImage.Image = global::ChequeProcessing.Properties.Resources.ScanSuccessfully;
                    StatusText.Text = "Saved Successfully.";
                    break;
                case SystemStatus.SavedAll:
                    StatusImage.Image = global::ChequeProcessing.Properties.Resources.ScanSuccessfully;
                    StatusText.Text = "Saved All Successfully.";
                    break;
                case SystemStatus.BatchClosed:
                    StatusImage.Image = global::ChequeProcessing.Properties.Resources.Connected;
                    StatusText.Text = "Batch Closed";
                    break;
                case SystemStatus.BatchLoaded:
                    StatusImage.Image = global::ChequeProcessing.Properties.Resources.Connected;
                    StatusText.Text = "Batch Loaded";
                    break;
                case SystemStatus.BatchDeleted:
                    StatusImage.Image = global::ChequeProcessing.Properties.Resources.Connected;
                    StatusText.Text = "Batch Deleted";
                    break;
                default:
                    StatusImage.Image = global::ChequeProcessing.Properties.Resources.SomeError;
                    StatusText.Text = "Some Error Occured";
                    break;
            }
        }

        public void ShowCurrentCheque()
        {
            if (currentBatch == null || currentBatch.cheques == null || currentBatch.cheques[selectedIndex] == null)
            {
                imagePanel1.SetFrontImage(null);
                imagePanel1.SetBackImage(null);
                ChequeInfo.SetCheque(null);
                return;
            }
            ChequeInfo.SetCheque(currentBatch.cheques[selectedIndex]);
            imagePanel1.SetFrontImage(currentBatch.cheques[selectedIndex].ImgFront);
            imagePanel1.SetBackImage(currentBatch.cheques[selectedIndex].ImgBack);

            HandleButtonDisabling();
        }

        public void HandleButtonDisabling()
        {
            if (TotImages == 1)
            {
                ButtonPrev.Enabled = false;
                ButtonNext.Enabled = false;
            }
            else if (selectedIndex == 0)
            {
                ButtonPrev.Enabled = false;
                ButtonNext.Enabled = true;
            }
            else if (selectedIndex == TotImages - 1)
            {
                ButtonNext.Enabled = false;
                ButtonPrev.Enabled = true;
            }
            else
            {
                ButtonNext.Enabled = true;
                ButtonPrev.Enabled = true;
            }
        }

        public void SaveAndSend(bool Send)
        {
            if (currentBatch == null)
            {
                if (Send)
                {
                    MessageBox.Show("Batch is not available to send", "No Batch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Batch is not available to save", "No Batch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            ChequesDB db = new ChequesDB();
            BatchDB db2 = new BatchDB();

            for (int i = 0; i < currentBatch.TotalCheques; i++)
            {
                if (currentBatch.cheques[i].Modified)
                {
                    db.UpdateChequeMICR(
                        currentBatch.cheques[i].ChequeID,
                        currentBatch.cheques[i].CheckSLNo,
                        currentBatch.cheques[i].RoutingNo,
                        currentBatch.cheques[i].IssueActNo,
                        currentBatch.cheques[i].IssueTransCode,
                        address[0].ToString(),
                        currentBatch.cheques[i].endorseNo,
                        UserID);
                }
            }
            if (Send)
            {
                DataTable dt = db.FindDuplicateCheckByBatchID(currentBatch.BatchID);
                if (dt.Rows.Count > 0)
                {
                    Popups.DuplicateCheckList form = new Popups.DuplicateCheckList(dt);
                    form.ShowDialog();
                    return;
                }

                for (int i = 0; i < TotImages; i++)
                {
                    if (!currentBatch.cheques[i].isReady())
                    {
                        MessageBox.Show("Cannot Send Batch! All Errors are not repaired", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                for (int i = 0; i < TotImages; i++)
                {
                    db.CompleteScanningForSingleCheck(
                        currentBatch.cheques[i].ChequeID,
                        UserID,
                        address[0].ToString());
                }
                if (MessageBox.Show("Are you sure you want to Send this Batch?", "Confirm Send", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    db2.SendBatch(currentBatch.BatchID, UserID, "S");
                    CloseCurrentBatch();
                    SetStatus(SystemStatus.BatchSent);
                }
            }
            else
                SetStatus(SystemStatus.Saved);
        }

        public void UpdateBatchInfo()
        {
            currentBatch.Update();
            BatchInfo1.SetBatch(currentBatch);
        }

        
        public void ComponentFocusLeave(object sender, EventArgs e)
        {
            if (currentBatch == null)
                return;
            if (sender == ChequeInfo.TextActNo)
            {
                if (ChequeInfo.TextActNo.Text != currentBatch.cheques[selectedIndex].IssueActNo)
                {
                    currentBatch.cheques[selectedIndex].Modified = true;
                    currentBatch.cheques[selectedIndex].IssueActNo = ChequeInfo.TextActNo.Text;
                    UpdateBatchInfo();
                }
            }
            else if (sender == ChequeInfo.TextRoutingNo)
            {
                if (ChequeInfo.TextRoutingNo.Text != currentBatch.cheques[selectedIndex].RoutingNo)
                {
                    currentBatch.cheques[selectedIndex].Modified = true;
                    currentBatch.cheques[selectedIndex].RoutingNo = ChequeInfo.TextRoutingNo.Text;
                    UpdateBatchInfo();
                }
            }
            else if (sender == ChequeInfo.TextSlNo)
            {
                if (ChequeInfo.TextSlNo.Text != currentBatch.cheques[selectedIndex].CheckSLNo)
                {
                    currentBatch.cheques[selectedIndex].Modified = true;
                    currentBatch.cheques[selectedIndex].CheckSLNo = ChequeInfo.TextSlNo.Text;
                    UpdateBatchInfo();
                }
            }
            else if (sender == ChequeInfo.TextTransCode)
            {
                if (ChequeInfo.TextTransCode.Text != currentBatch.cheques[selectedIndex].IssueTransCode)
                {
                    currentBatch.cheques[selectedIndex].Modified = true;
                    currentBatch.cheques[selectedIndex].IssueTransCode = ChequeInfo.TextTransCode.Text;
                    UpdateBatchInfo();
                }
            }
            else if (sender == ChequeInfo.txtEndorse)
            {
                if (long.Parse(ChequeInfo.txtEndorse.Text) != currentBatch.cheques[selectedIndex].endorseNo)
                {
                    currentBatch.cheques[selectedIndex].Modified = true;
                    currentBatch.cheques[selectedIndex].endorseNo = Int32.Parse(ChequeInfo.txtEndorse.Text);
                    UpdateBatchInfo();
                }
            }
        }

        public void ComponentFocusEnter(object sender, EventArgs e)
        {
        }

        public void NextButtonFocus(object sender, EventArgs e)
        {
        }

        private void SwitchView(int View)
        {
            if (CurrentView == View)
            {
                return;
            }
            if (View == ViewOption.DetailView)
            {
                splitContainer1.Panel2Collapsed = false;
                splitContainer1.SplitterDistance = 262;
                splitContainer3.Orientation = Orientation.Horizontal;
                splitContainer3.SplitterDistance = 262;
                DetailGridView.Visible = false;
                ShowCurrentCheque();
            }
            else if (View == ViewOption.ListView)
            {
                splitContainer1.Panel2Collapsed = true;
                splitContainer3.Orientation = Orientation.Vertical;
                splitContainer3.SplitterDistance = 262;
                DetailGridView.Visible = true;
                DressCheckList();
            }
            CurrentView = View;
        }

        private void ScannerScreen_Load(object sender, EventArgs e)
        {
            SwitchView(ViewOption.ListView);
            //splitContainer3.SplitterDistance = 262;
        }

        public void SettingsChanged(int toEndorse, long seqNo)
        {
            this.toEndorse = toEndorse;
            this.startSeqNo = seqNo.ToString("00000000000");
        }
        private void chkIgnoreError_CheckedChanged(object sender, EventArgs e)
        {
            if (currentBatch != null && TotImages > 0)
            {
                currentBatch.cheques[selectedIndex].IgnoreCheckDigit = ChequeInfo.chkIgnoreError.Checked;
                ChequeInfo.ApplyColorCodeForRoutingNo();
            }
        }

        public void ChangeGridColor(Guid chequeID)
        {
            for (int i = 0; i < DetailGridView.RowCount; i++)
            {
                DataGridViewRow drv1 = ListGridView.Rows[i];
                DataGridViewRow drv2 = DetailGridView.Rows[i];

                if (currentBatch.cheques[i].ChequeID == chequeID)
                {
                    if (currentBatch.cheques[i].RejectReason != null && currentBatch.cheques[i].RejectReason.StartsWith("DUPLICATE:"))
                    {
                        drv1.DefaultCellStyle.BackColor = System.Drawing.Color.Coral;
                        drv2.DefaultCellStyle.BackColor = System.Drawing.Color.Coral;
                    }
                    else if (currentBatch.cheques[i].MICRError == 0)
                    {
                        if (i % 2 == 1)
                        {
                            drv1.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                            drv2.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                        }
                        else
                        {

                            drv1.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                            drv2.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                        }
                    }
                    else
                    {

                        if ((currentBatch.cheques[i].MICRError & ErrorTypes.InvalidMICR) != 0)
                        {
                            drv1.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                            drv2.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                        }
                        else if ((currentBatch.cheques[i].MICRError & ErrorTypes.BadMICR) != 0)
                        {
                            drv1.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                            drv2.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                        }
                        else if ((currentBatch.cheques[i].MICRError & ErrorTypes.CheckDigitMismatch) != 0)
                        {
                            drv1.DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                            drv2.DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                        }

                    }
                    break;
                }
            }

        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            ChangePassword form = new ChangePassword(UserID, loginID, address[0].ToString());
            form.ShowDialog();
        }

        public void AllErrorSolved()
        {
            bool hasError = false;
            for (int i = 0; i < currentBatch.TotalCheques; i++)
            {
                if (currentBatch.cheques[(selectedIndex + i) % currentBatch.TotalCheques].MICRError != 0)
                {
                    selectedIndex = (selectedIndex + i) % currentBatch.TotalCheques;
                    ShowCurrentCheque();
                    ChequeInfo.NextMicrError();
                    hasError = true;
                    break;
                }
            } if (!hasError)
            {
                MessageBox.Show("No MICR error left to repair.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void SetSelector(RoleSelector selector)
        {
            this.selector = selector;
        }
        public void ShowThis()
        {
            this.Show();
        }
    }
}