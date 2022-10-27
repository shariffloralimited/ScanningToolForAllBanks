using System;
using System.Data;
using System.Windows.Forms;
using System.Net;
using System.Drawing;

namespace ChequeProcessing
{

    public partial class MakerCheckerScreen : Form, BatchTraceListener, ComponentFocusListener, SelectorListener
    {
        private int UserID;
        private int UserRole;
        private string RoleCD;
        private int BranchCD;
        private Batch CurrentBatch;
        private int CurStatus;
        private string loginID;

        private BulkEntry entryForm;

        private int CurrentView;

        DataTable ChequeList;
        DataTable ChequeDetail;

        public static bool IsConnectedToCbs = bool.Parse(System.Configuration.ConfigurationSettings.AppSettings["IsConnectedToCbs"]);
        //public static bool ValidateFromCBS = bool.Parse(System.Configuration.ConfigurationSettings.AppSettings["ValidateFromCBS"]);

        IPAddress[] address = Dns.GetHostAddresses(Dns.GetHostName());

        private int SelectedIndex;
        private int TotImages;

        private string ArchPath;
        private string FilePath;

        private SendToMaker SendToMakerForm;

        public RoleSelector selector;

        
        public MakerCheckerScreen(UserInfo ui)
        {
            InitializeComponent();
            ribsButton5.Enabled = true;
            ButtonDiscard3.Visible = false;


            this.UserID = ui.UserID;
            this.UserRole = ui.RoleID;
            this.loginID = ui.loginID;

            if (ui.RoleCD == "BROUCK")
            {
                this.RoleCD = "CHECKER";
            }
            if (ui.RoleCD == "ZNOUCK")
            {
                this.RoleCD = "CHECKER";
            }
            if (ui.RoleCD == "CHECKER")
            {
                this.RoleCD = "CHECKER";
            }
            //ArchPath = System.Configuration.ConfigurationSettings.AppSettings["ArchivePath"];
            //FilePath = System.Configuration.ConfigurationSettings.AppSettings["TempImagePath"];

            SwitchView(ViewOption.ListView);

            DetailGridView.Dock = DockStyle.Fill;
            ListGridView.Dock = DockStyle.Fill;
            DetailGridView.AutoGenerateColumns = false;
            ListGridView.AutoGenerateColumns = false;


            PanelChequeView.Dock = DockStyle.Fill;

            ChequesDB db = new ChequesDB();

            SelectedIndex = 0;
            ButtonPrev.Enabled = false;
            ButtonNext.Enabled = false;

            if (RoleCD == "CHECKER")
            {
                //this.Text = "Checker Screen";
                TabRepair.Visible = false;
            }
            else
            {
                TabApprove.Visible = false;
            }

            BatchInfo1.SetUser(ui);

            ChequeInfo1.SetTextBoxesReadonly(UserRoles.BranchDataEntryChecker);

            ChequeInfo1.Listener = this;
            ButtonPullFromSortBucket.Visible = false;

            //BindUserDetails(this.UserID);
        }

        #region Action Event Handler Code...
        //private void BindUserDetails(int UserID)
        //{
        //    UsersDB db = new UsersDB();
        //    UserDetail u = db.GetUserDetails(UserID);
        //    lblUserBranch.Text = "Branch: " + u.BranchName;
        //    lblUserName.Text = "Name: " + u.UserName;
        //}

        private void ButtonBatchOption_Click(object sender, EventArgs e)
        {
            if (CurrentBatch == null)
            {
                return;
            }
            if (ChequeProcessing.Properties.Settings.Default.RoleCD == "CHECKER")
            {
                CreateBatch form = new CreateBatch(this, UserID, BatchOptions.View, CurrentBatch.BatchID, UserRole);
                form.ShowDialog();
            }
            else if (ChequeProcessing.Properties.Settings.Default.RoleCD == "MAKER")
            {
                SaveAndSend(false);
                CreateBatch form = new CreateBatch(this, UserID, BatchOptions.EditForMaker, CurrentBatch.BatchID, UserRole);
                form.ShowDialog();
            }
            else if (ChequeProcessing.Properties.Settings.Default.RoleCD == "BROUMK")
            {
                SaveAndSend(false);
                CreateBatch form = new CreateBatch(this, UserID, BatchOptions.EditForMaker, CurrentBatch.BatchID, UserRole);
                form.ShowDialog();
            }
            else if (ChequeProcessing.Properties.Settings.Default.RoleCD == "ZNOUMK")
            {
                SaveAndSend(false);
                CreateBatch form = new CreateBatch(this, UserID, BatchOptions.EditForMaker, CurrentBatch.BatchID, UserRole);
                form.ShowDialog();
            }
        }

        private void ButtonBalancing_Click(object sender, EventArgs e)
        {

            if (CurrentBatch == null)
            {
                MessageBox.Show("Load a batch First");
                return;
            }
            SaveAndSend(false);
            BatchBalance form = new BatchBalance(CurrentBatch.BatchID);
            form.ShowDialog();
        }

        private void ButtonSendToMaker_Click(object sender, EventArgs e)
        {
            if (CurrentBatch == null || CurrentBatch.TotalCheques == 0)
            {
                MessageBox.Show("Batch is not available to send back");
                return;
            }

            SendToMakerForm = new SendToMaker(CurrentBatch.cheques[SelectedIndex], UserID, address[0].ToString(), CurrentBatch.BatchID);
            SendToMakerForm.SetListener(this);
            SendToMakerForm.ShowDialog();

            LoadCurrentBatch(false);

            if (ChequeDetail.Rows.Count == 0)
            {
                CloseCurrentBatch();
            }
            
        }

        private void ButtonSaveBatch_Click(object sender, EventArgs e)
        {
            if (CurrentBatch == null)
            {
                MessageBox.Show("Batch is not available to save");
                return;
            }
            SaveAndSend(false);
        }

        private void ButtonSendBatch_Click(object sender, EventArgs e)
        {
            if (CurrentBatch == null)
            {
                MessageBox.Show("Batch is not available to send");
                return;
            }
            SaveAndSend(false);
            BatchBalance form = new BatchBalance(CurrentBatch.BatchID);
            bool balanced = form.Balance();
            form.ShowDialog();
            if (balanced)
            {
                SaveAndSend(true);
                SetStatus(SystemStatus.BatchSent);
            }
            else
            {
                MessageBox.Show("Cannot Send batch. Batch is not balanced.");
            }
        }

        private void ButtonLogoff_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Logoff?", "Confirm Logoff", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LogOff();
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Exit?", "Confirm Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CloseCurrentBatch();
                Environment.Exit(0);
            }
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
            ShowPrevCheque();
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            ShowNextCheque();
        }

        private void ListGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (CurrentBatch == null)
            {
                return;
            }
            if (ListGridView.SelectedRows.Count == 1)
            {
                SelectedIndex = ListGridView.SelectedRows[0].Index;
                ShowCurrentCheque();
            }
            HandleButtonDisabling();
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            OpenBatch form = new OpenBatch(this, BatchOptions.Open, UserID, UserRole);
            form.ShowDialog();
        }

        private void ButtonViewAll_Click(object sender, EventArgs e)
        {
            if (CurrentBatch != null)
            {
                DataTable ChequeDetailEmpty = new DataTable();
                DataTable ChequeListEmpty = new DataTable();
                DetailGridView.DataSource = ChequeListEmpty = ChequeDetail.Clone();
                ListGridView.DataSource = ChequeDetailEmpty = ChequeDetail.Clone();
                LoadCurrentBatch(true);
            }
            else
            {
                MessageBox.Show("Batch is not available to view");
            }
        }

        private void ButtonApprove_Click(object sender, EventArgs e)
        {
            if (CurrentBatch != null && CurrentBatch.TotalCheques > 0)
            {
                CurrentBatch.cheques[SelectedIndex].Approved = true;
                CurrentBatch.cheques[SelectedIndex].StatusID = ChequeStatus.Approved;
                ChequeInfo1.SetCheque(CurrentBatch.cheques[SelectedIndex]);
                CurrentBatch.Update();
                BatchInfo1.SetBatch(CurrentBatch);
                //ListGridView.
                ShowNextCheque();
            }
            else
            {
                MessageBox.Show("Batch is not available to approve");
            }
        }

        private void ButtonApproveAll_Click(object sender, EventArgs e)
        {
            if (CurrentBatch != null)
            {
                for (int i = 0; i < CurrentBatch.TotalCheques; i++)
                {
                    if (!CurrentBatch.cheques[i].SentToMaker)
                    {
                        CurrentBatch.cheques[i].Approved = true;
                        CurrentBatch.cheques[i].StatusID = ChequeStatus.Approved;
                    }
                }

                CurrentBatch.Update();
                BatchInfo1.SetBatch(CurrentBatch);
                ChequeInfo1.SetCheque(CurrentBatch.cheques[SelectedIndex]);
            }
            else
            {
                MessageBox.Show("Batch is not available to approve");
            }
        }

        private void ButtonPullFromSortBucket_Click(object sender, EventArgs e)
        {
            if (CurrentBatch == null)
            {
                MessageBox.Show("Batch is not available to pull from sort bucket");
                return;
            }
            SortBucket form = new SortBucket(this, UserID, CurrentBatch.BatchID, CurrentBatch.presentingRoutingNo, address[0].ToString());
            form.ShowDialog();
        }

        private void ButtonEntryReqd_Click(object sender, EventArgs e)
        {
            if (CurrentBatch != null)
            {
                LoadCurrentBatch(false);
            }

        }

        private void ButtonApprovalReqd_Click(object sender, EventArgs e)
        {
            if (CurrentBatch != null)
            {
                LoadCurrentBatch(false);
            }
            else
            {
                MessageBox.Show("Batch is not available");
            }
        }

        #endregion

        public void LoadCurrentBatch(bool Complete)
        {
            //CurrentBatch = new Batch(CurrentBatch.BatchNo, Cheque.CreateCheques(ChequeDetail));
            ChequesDB db = new ChequesDB();

            if (ChequeProcessing.Properties.Settings.Default.RoleCD == "MAKER")
            {
                ChequeDetail = db.GetCheckDetailByBatchNo(CurrentBatch.BatchID, ChequeStatus.ScanningComplete, Complete, UserID);
                if (ChequeDetail.Rows.Count == 0)
                {
                    ChequeDetail = db.GetCheckDetailByBatchNo(CurrentBatch.BatchID, ChequeStatus.SentToMaker, true, UserID);
                }
            }
            else
            {
                ChequeDetail = db.GetCheckDetailByBatchNo(CurrentBatch.BatchID, ChequeStatus.AmountEntered, Complete, UserID);
            }

            ListGridView.DataSource = ChequeDetail;
            DetailGridView.DataSource = ChequeDetail;

            CurrentBatch = new Batch(CurrentBatch.BatchID, UserID, ChequeDetail);

            TotImages = CurrentBatch.TotalCheques;

            BatchInfo1.SetBatch(CurrentBatch);

            DressCheckList();

            ShowCurrentCheque();

            BatchDB db1 = new BatchDB();
            db1.LockBatch(CurrentBatch.BatchID, UserID);

            SetStatus(SystemStatus.BatchLoaded);

        }

        private void CloseCurrentBatch()
        {
            if (CurrentBatch == null)
            {
                return;
            }
            if (CurrentBatch.BatchID.ToString() != "00000000-0000-0000-0000-000000000000")
            {
                BatchDB db = new BatchDB();
                db.UnlockBatch(CurrentBatch.BatchID);
            }
            DataTable ChequeDetailEmpty = new DataTable();
            DataTable ChequeListEmpty = new DataTable();
            DetailGridView.DataSource = ChequeListEmpty = ChequeDetail.Clone();
            ListGridView.DataSource = ChequeDetailEmpty = ChequeDetail.Clone();
            ChequeInfo1.SetCheque(null);
            imagePanel1.SetBackImage(null);
            imagePanel1.SetFrontImage(null);
            BatchInfo1.SetBatch(null);
            CurrentBatch = null;
            SetStatus(SystemStatus.BatchClosed);
        }

        private void LogOff()
        {
            try
            {
                CloseCurrentBatch();
                if (selector != null)
                    selector.Show();
                this.Hide();
                this.Dispose();
            }
            catch
            {
                this.Hide();
                this.Dispose();
            }
        }

        public void BatchReady(Guid BatchNo)
        {
            if (BatchNo.ToString() == "00000000-0000-0000-0000-000000000000")
            { // The selected check is sent Back
                CurrentBatch.cheques[SelectedIndex].StatusID = ChequeStatus.SentToMaker;
                CurrentBatch.cheques[SelectedIndex].SentToMaker = true;
                CurrentBatch.Update();
                BatchInfo1.SetBatch(CurrentBatch);
                ChequeInfo1.SetCheque(CurrentBatch.cheques[SelectedIndex]);
                return;
            }

            if (this.CurrentBatch == null || this.CurrentBatch.BatchID.ToString() == "00000000-0000-0000-0000-000000000000")
            {

            }
            else
            {
                CloseCurrentBatch();
            }
            try
            {
                this.CurrentBatch = new Batch(BatchNo, UserID);
                LoadCurrentBatch(false);
            }
            catch (BatchLockedExeption ex)
            {
                this.CurrentBatch = null;
                MessageBox.Show(ex.Message);
            }
        }

        private void SetStatus(int status)
        {
            CurStatus = status;
            if (CurStatus == SystemStatus.Connected)
            {
                StatusImage.Image = global::ChequeProcessing.Properties.Resources.Connected;
                StatusText.Text = "Scanner is connected.";
            }
            else if (CurStatus == SystemStatus.NotConnected)
            {
                StatusImage.Image = global::ChequeProcessing.Properties.Resources.NotConnected;
                StatusText.Text = "Scanner is not connected.";
            }
            else if (CurStatus == SystemStatus.BatchSent)
            {
                StatusImage.Image = global::ChequeProcessing.Properties.Resources.Connected;
                StatusText.Text = "Batch Sent successfully.";
            }
            else if (CurStatus == SystemStatus.Scanned)
            {
                StatusImage.Image = global::ChequeProcessing.Properties.Resources.ScanSuccessfully;
                StatusText.Text = "Scanned Successfully";
                
            }
            else if (CurStatus == SystemStatus.ChequeNotFound)
            {
                StatusImage.Image = global::ChequeProcessing.Properties.Resources.CheNotFound;
                StatusText.Text = "Cheque Not Found";
            }
            else if (CurStatus == SystemStatus.Saved)
            {
                StatusImage.Image = global::ChequeProcessing.Properties.Resources.ScanSuccessfully;
                StatusText.Text = "Uploaded Successfully";
            }
            else if (CurStatus == SystemStatus.SavedAll)
            {
                StatusImage.Image = global::ChequeProcessing.Properties.Resources.ScanSuccessfully;
                StatusText.Text = "All Cheques were uploaded.";
            }
            else if (CurStatus == SystemStatus.BatchClosed)
            {
                StatusImage.Image = global::ChequeProcessing.Properties.Resources.Connected;
                StatusText.Text = "Batch Closed";
            }
            else if (CurStatus == SystemStatus.BatchLoaded)
            {
                StatusImage.Image = global::ChequeProcessing.Properties.Resources.Connected;
                StatusText.Text = "Batch Loaded";
            }
            else
            {
                StatusImage.Image = global::ChequeProcessing.Properties.Resources.SomeError;
                StatusText.Text = "Some Error Occured";
            }
        }

        public void ShowCurrentCheque()
        {
            if (CurrentBatch == null || CurrentBatch.cheques[SelectedIndex] == null)
            {
                return;
            }
            ChequeInfo1.SetCheque(CurrentBatch.cheques[SelectedIndex]);
            imagePanel1.SetFrontImage(CurrentBatch.cheques[SelectedIndex].ImgFront);
            imagePanel1.SetBackImage(CurrentBatch.cheques[SelectedIndex].ImgBack);
        }

        public void ShowPrevCheque()
        {
            if (SelectedIndex < 1)
            {
                return;
            }
            SelectedIndex--;
            ButtonNext.Enabled = true;
            ListGridView.Rows[SelectedIndex].Selected = true;
            HandleButtonDisabling();
        }

        public void ShowNextCheque()
        {
            if (CurrentBatch == null) return;
            if (SelectedIndex >= CurrentBatch.TotalCheques - 1)
            {
                ChequeInfo1.SetCheque(null);
                imagePanel1.SetBackImage(null);
                imagePanel1.SetFrontImage(null);
                return;
            }
            SelectedIndex++;
            ListGridView.Rows[SelectedIndex].Selected = true;
            HandleButtonDisabling();
        }

        public void HandleButtonDisabling()
        {
            if (TotImages <= 1)
            {
                ButtonPrev.Enabled = false;
                ButtonNext.Enabled = false;
            }
            else if (SelectedIndex == 0)
            {
                ButtonPrev.Enabled = false;
                ButtonNext.Enabled = true;
            }
            else if (SelectedIndex == CurrentBatch.TotalCheques - 1)
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
            if (CurrentBatch == null)
            {
                return;
            }
            long Amount;
            int StatusID = 0;

            ChequesDB db = new ChequesDB();
            if (ChequeProcessing.Properties.Settings.Default.RoleCD == "MAKER")
            {
                StatusID = ChequeStatus.AmountEntered;
                for (int i = 0; i < CurrentBatch.TotalCheques; i++)
                {
                    if (CurrentBatch.cheques[i].StatusID == ChequeStatus.SentToMaker && !Send)
                    {
                        continue;
                    }
                    if (CurrentBatch.cheques[i].Modified || CurrentBatch.cheques[i].IsComplete())
                    {
                        Amount = 0;
                        if (CurrentBatch.cheques[i].Amount != "")
                        {
                            if (CurrentBatch.cheques[i].Amount.Contains(","))
                                CurrentBatch.cheques[i].Amount = CurrentBatch.cheques[i].Amount.Replace(",", "");
                            if (CurrentBatch.cheques[i].Amount.IndexOf('.') < 0)
                            {
                                Amount = long.Parse(CurrentBatch.cheques[i].Amount + "00");
                            }
                            else
                            {
                                Amount = long.Parse(CurrentBatch.cheques[i].Amount.Remove(
                                    CurrentBatch.cheques[i].Amount.IndexOf('.'), 1));
                            }
                        }
                        db.EnterAmount(
                            CurrentBatch.cheques[i].ChequeID,
                            Amount,
                            CurrentBatch.cheques[i].DepAccountNo,
                            CurrentBatch.cheques[i].BenefitiaryActName,
                            CurrentBatch.cheques[i].BranchCode,
                            UserID,
                            address[0].ToString());
                    } if (CurrentBatch.cheques[i].MicrModified )
                    {
                        db.UpdateChequeMICR(
                            CurrentBatch.cheques[i].ChequeID,
                            CurrentBatch.cheques[i].CheckSLNo,
                            CurrentBatch.cheques[i].RoutingNo,
                            CurrentBatch.cheques[i].IssueActNo,
                            CurrentBatch.cheques[i].IssueTransCode,
                            address[0].ToString(),
                            CurrentBatch.cheques[i].endorseNo,
                            UserID);
                    }
                }
            }
            else if (ChequeProcessing.Properties.Settings.Default.RoleCD == "CHECKER")
            {
                StatusID = ChequeStatus.Approved;
                for (int i = 0; i < CurrentBatch.TotalCheques; i++)
                {
                    if (CurrentBatch.cheques[i].SentToMaker)
                    {
                        StatusID = ChequeStatus.SentToMaker;

                        db.SendToMaker(
                            CurrentBatch.cheques[i].ChequeID,
                            CurrentBatch.cheques[i].RejectReason,
                            UserID,
                            address[0].ToString());
                    }
                    else if (CurrentBatch.cheques[i].Approved)
                    {
                        db.ApproveCheck(
                            CurrentBatch.cheques[i].ChequeID,
                            UserID,
                            address[0].ToString());
                    }
                }
            }
            if (Send)
            {
                // Update by Mizan
                string RejectMessage = string.Empty;
                if (Properties.Settings.Default.RoleCD == "MAKER")
                {
                    for (int i = 0; i < TotImages; i++)
                    {
                        if (!CurrentBatch.cheques[i].IsComplete())
                        {
                            MessageBox.Show("Cannot Send Batch! Data Entry not complete for all checks.");
                            return;
                        }
                    }
                }
                else if (Properties.Settings.Default.RoleCD == "CHECKER")
                {
                    for (int i = 0; i < TotImages; i++)
                    {
                        if (CurrentBatch.cheques[i].Approved == false)
                        {
                            //MessageBox.Show("Cannot Send Batch! All cheques are not approved.");
                            //return;
                        }
                        if(CurrentBatch.cheques[i].SentToMaker == true)
                        {
                            RejectMessage = " to Maker";
                            //MessageBox.Show("Cannot Send Batch! All cheques are not approved.");
                            //return;
                        }
                        if (!CurrentBatch.cheques[i].Approved && !CurrentBatch.cheques[i].SentToMaker)
                        {
                            MessageBox.Show("Cannot Send Batch! All cheques are not approved.");
                            return;
                        }
                    }
                }
                if (MessageBox.Show("Are you sure you want to Send this Batch" + RejectMessage+ "?", "Confirm Send", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    BatchDB db2 = new BatchDB();
                    db2.SendBatch(CurrentBatch.BatchID, UserID, Properties.Settings.Default.RoleCD);

                    CloseCurrentBatch();
                    SetStatus(SystemStatus.BatchSent);
                }
            }
            else
            {
                SetStatus(SystemStatus.Saved);
            }
        }

        public void ComponentFocusLeave(object sender, EventArgs e)
        {
            if (CurrentBatch == null)
                return;
            if (sender == ChequeInfo1.TextActNo)
            {
                if (ChequeInfo1.TextActNo.Text != CurrentBatch.cheques[SelectedIndex].IssueActNo)
                {
                    CurrentBatch.cheques[SelectedIndex].IssueActNo = ChequeInfo1.TextActNo.Text;
                    CurrentBatch.cheques[SelectedIndex].Modified = true;
                    CurrentBatch.Update();
                }
            }
            else if (sender == ChequeInfo1.TextRoutingNo)
            {
                if (ChequeInfo1.TextRoutingNo.Text != CurrentBatch.cheques[SelectedIndex].RoutingNo)
                {
                    CurrentBatch.cheques[SelectedIndex].RoutingNo = ChequeInfo1.TextRoutingNo.Text;
                    CurrentBatch.cheques[SelectedIndex].MicrModified = true;
                    CurrentBatch.Update();
                }
            }
            else if (sender == ChequeInfo1.TextSlNo)
            {
                if (ChequeInfo1.TextSlNo.Text != CurrentBatch.cheques[SelectedIndex].CheckSLNo)
                {
                    CurrentBatch.cheques[SelectedIndex].CheckSLNo = ChequeInfo1.TextSlNo.Text;
                    CurrentBatch.cheques[SelectedIndex].MicrModified = true;
                    CurrentBatch.Update();
                }
            }
            else if (sender == ChequeInfo1.TextTransCode)
            {
                if (ChequeInfo1.TextTransCode.Text != CurrentBatch.cheques[SelectedIndex].IssueTransCode)
                {
                    CurrentBatch.cheques[SelectedIndex].IssueTransCode = ChequeInfo1.TextTransCode.Text;
                    CurrentBatch.cheques[SelectedIndex].MicrModified = true;
                    CurrentBatch.Update();
                }
            }
            else if (sender == ChequeInfo1.TextAmount)
            {
                double amt = 0;
                try
                {
                    amt = double.Parse(ChequeInfo1.TextAmount.Value);
                }
                catch { }
                if (amt != double.Parse(CurrentBatch.cheques[SelectedIndex].Amount))
                {
                    CurrentBatch.cheques[SelectedIndex].Amount = ChequeInfo1.TextAmount.Value;
                    CurrentBatch.cheques[SelectedIndex].Modified = true;
                    CurrentBatch.Update();
                }
            }
            else if (sender == ChequeInfo1.TextCustomerActNo)
            {
                if (ChequeInfo1.TextCustomerActNo.Text != CurrentBatch.cheques[SelectedIndex].DepAccountNo)
                {
                    CurrentBatch.cheques[SelectedIndex].DepAccountNo = ChequeInfo1.TextCustomerActNo.Text;
                    CurrentBatch.cheques[SelectedIndex].Modified = true;
                    CurrentBatch.Update();
                }
            }
            else if (sender == ChequeInfo1.txtDepBranchCode)
            {
                if (ChequeInfo1.txtDepBranchCode.Text != CurrentBatch.cheques[SelectedIndex].BranchCode)
                {
                    CurrentBatch.cheques[SelectedIndex].BranchCode = ChequeInfo1.txtDepBranchCode.Text;
                    CurrentBatch.cheques[SelectedIndex].Modified = true;
                }
            }
            else if (sender == ChequeInfo1.txtRefNo)
            {
                if (ChequeInfo1.txtRefNo.Text != CurrentBatch.cheques[SelectedIndex].RefNo)
                {
                    CurrentBatch.cheques[SelectedIndex].RefNo = ChequeInfo1.txtRefNo.Text;
                    CurrentBatch.cheques[SelectedIndex].Modified = true;
                }
            }
        }

        public void ComponentFocusEnter(object sender, EventArgs e)
        {
        }

        public void NextButtonFocus(object sender, EventArgs e)
        {
            //ListGridView.Focus();
            ShowNextCheque();
            CurrentBatch.Update();
            BatchInfo1.SetBatch(CurrentBatch);
        }

        private void ButtonSendToSortBucket_Click(object sender, EventArgs e)
         {
            //if (CurrentBatch != null)
            //{
            //    if (CurrentBatch.TotalCheques > 0 && MessageBox.Show("Are you sure to send this cheque to Sort Bucket?", 
            //        "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        SaveAndSend(false);
            //        ChequesDB db = new ChequesDB();
            //        db.MoveToSortBucket(CurrentBatch.cheques[SelectedIndex].ChequeID, UserID, address[0].ToString());
            //        LoadCurrentBatch(false);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Batch is not available to send");
            //    return;
            //}
            if (CurrentBatch == null)
            {
                MessageBox.Show("Batch is not available to delete", "No Batch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (SelectedIndex < 0 || SelectedIndex >= ListGridView.RowCount)
            {
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete this Cheque?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SaveAndSend(false);
                ChequesDB db = new ChequesDB();
                db.DeleteCheque(
                    CurrentBatch.cheques[SelectedIndex].ChequeID,
                    "",
                    UserID,
                    address[0].ToString()
                );
                //CurrentBatch.cheques[SelectedIndex].DepAccountNo = string.Empty;
                LoadCurrentBatch(false);

                if (CurrentBatch.TotalCheques == 0)
                {
                    BatchDB bdb = new BatchDB();
                    bdb.DeleteBatch(CurrentBatch.BatchID, UserID, address[0].ToString());
                    CloseCurrentBatch();
                }

            }
        }

        private void MakerCheckerScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogOff();
            this.Dispose();
        }

        private void Tab_Click(object sender, EventArgs e)
        {
            if (sender == TabRepair || sender == TabApprove)
            {
                SwitchView(ViewOption.DetailView);
            }
            if (CurrentBatch != null)
            {
                ShowCurrentCheque();
            }
            if (sender == TabRepair && CurrentBatch != null && CurrentBatch.cheques[SelectedIndex] != null)
            {
                ChequeInfo1.SetTextBoxesReadonly(UserRoles.BranchDataEntryMaker);
                ChequeInfo1.Focus();
            }
            else
            {
                ChequeInfo1.SetTextBoxesReadonly(UserRoles.BranchDataEntryChecker);
            }
        }

        public void DressCheckList()
        {
            for (int i = 0; i < DetailGridView.RowCount; i++)
            {
                DataGridViewRow drv1 = ListGridView.Rows[i];
                DataGridViewRow drv2 = DetailGridView.Rows[i];

                if (CurrentBatch.cheques[i].RejectReason != null && CurrentBatch.cheques[i].RejectReason != "")
                {
                    drv1.DefaultCellStyle.BackColor = System.Drawing.Color.Coral;
                    drv2.DefaultCellStyle.BackColor = System.Drawing.Color.Coral;
                }
                else if ((CurrentBatch.cheques[i].MICRError & ErrorTypes.InvalidMICR) != 0)
                {
                    drv1.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                    drv2.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                }
                else if ((CurrentBatch.cheques[i].MICRError & ErrorTypes.BadMICR) != 0)
                {
                    drv1.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                    drv2.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                }
                else if ((CurrentBatch.cheques[i].MICRError & ErrorTypes.CheckDigitMismatch) != 0)
                {
                    drv1.DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                    drv2.DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                }
            }
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
                ListGridView.Focus();
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

        private void ListGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39)
            {
                ChequeInfo1.Focus();
                e.Handled = true;
            }
        }

        public void ChangeGridColor(Guid chequeID)
        {
            for (int i = 0; i < DetailGridView.RowCount; i++)
            {
                DataGridViewRow drv1 = ListGridView.Rows[i];
                DataGridViewRow drv2 = DetailGridView.Rows[i];

                if (CurrentBatch.cheques[i].ChequeID == chequeID)
                {
                    if (CurrentBatch.cheques[i].RejectReason != null && CurrentBatch.cheques[i].RejectReason.StartsWith("DUPLICATE:"))
                    {
                        drv1.DefaultCellStyle.BackColor = System.Drawing.Color.Coral;
                        drv2.DefaultCellStyle.BackColor = System.Drawing.Color.Coral;
                    }
                    else if (CurrentBatch.cheques[i].MICRError == 0)
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

                        if ((CurrentBatch.cheques[i].MICRError & ErrorTypes.InvalidMICR) != 0)
                        {
                            drv1.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                            drv2.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                        }
                        else if ((CurrentBatch.cheques[i].MICRError & ErrorTypes.BadMICR) != 0)
                        {
                            drv1.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                            drv2.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                        }
                        else if ((CurrentBatch.cheques[i].MICRError & ErrorTypes.CheckDigitMismatch) != 0)
                        {
                            drv1.DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                            drv2.DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                        }

                    }
                    break;
                }
            }

        }

        private void MakerCheckerScreen_Load(object sender, EventArgs e)
        {

        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            ChangePassword form = new ChangePassword(UserID, loginID, address[0].ToString());
            form.ShowDialog();
        }

        private void btnBulkEntry_Click(object sender, EventArgs e)
        {
            if (CurrentBatch == null || CurrentBatch.TotalCheques == 0)
            {
                MessageBox.Show("No Batch is loaded or contains zero cheques");
                return;
            }
            entryForm = new BulkEntry();
            entryForm.ShowDialog();
            if (entryForm.amount != string.Empty)
            {
                for (int i = 0; i < CurrentBatch.TotalCheques; i++)
                {
                    CurrentBatch.cheques[i].Amount = entryForm.amount;
                }
            }
            if (entryForm.acctno != string.Empty)
            {
                for (int i = 0; i < CurrentBatch.TotalCheques; i++)
                {
                    CurrentBatch.cheques[i].DepAccountNo = entryForm.acctno;
                }
            }
            CurrentBatch.Update();
            BatchInfo1.SetBatch(CurrentBatch);
            ShowCurrentCheque();
        }

        public void AllErrorSolved()
        {
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