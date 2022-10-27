using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChequeProcessing
{
    public partial class RoleSelector : Form
    {
        public UserInfo ui;
        public DataTable roles;
        SelectorListener f;
        bool isScanman = false;

        ScannerScreen scannerScreen;
        MakerCheckerScreen makerCheckerScreen;

        public RoleSelector()
        {
            InitializeComponent();

            
        }
        public void Start()
        {
            
            this.Show();
            List<int> list1 = new List<int>();
            List<string> list2 = new List<string>();
            for (int i = 0; i < roles.Rows.Count; i++)
            {
                int roleid = Int32.Parse(roles.Rows[i].ItemArray[0].ToString());
                string rolecd = roles.Rows[i].ItemArray[1].ToString();


                if ((rolecd == "BROUSC") || (rolecd == "BROUMK") || (rolecd == "BROUCK") || (rolecd == "ZNOUSC") || (rolecd == "ZNOUMK") || (rolecd == "ZNOUCK"))
                {
                    list1.Add(roleid);
                    list2.Add(rolecd);
                }
            }

            if (list2.Count == 0)
            {
                MessageBox.Show("Invalid User information...");
            }

            else if (list2.Count == 1)
            {
                ui.RoleID = list1[0];
                ui.RoleCD = list2[0];

                if ((ui.RoleCD == "BROUSC") || (ui.RoleCD == "ZNOUSC"))
                {
                    scannerScreen = new ScannerScreen(ui);
                    scannerScreen.SetSelector(this);
                    isScanman = true;
                    
                }
                else if ((ui.RoleCD == "BROUMK") || (ui.RoleCD == "BROUCK") || (ui.RoleCD == "ZNOUMK") || (ui.RoleCD == "ZNOUCK"))
                {
                    makerCheckerScreen = new MakerCheckerScreen(ui);
                    makerCheckerScreen.SetSelector(this);
                    isScanman = false;
                    ChequeProcessing.Properties.Settings.Default.RoleCD = ui.RoleCD;
                }
                else
                {
                    MessageBox.Show("Invalid User information...");
                }
            }
            else{
                for (int i = 0; i < list2.Count; i++)
                {
                    if ((list2[i] == "BROUSC") || (list2[i] == "ZNOUSC"))
                    {
                        btnScan.Enabled = true;
                        btnScan.filename = list1[i].ToString();
                    }
                    if ((list2[i] == "BROUMK") || (list2[i] ==  "ZNOUMK"))
                    {
                        btnMaker.Enabled = true;
                        btnMaker.filename = list1[i].ToString();
                    }
                    if ((list2[i] == "BROUCK") || (list2[i] == "ZNOUCK"))
                    {
                        btnChecker.Enabled = true;
                        btnChecker.filename = list1[i].ToString();
                    }
                }
			}

            if (isScanman && scannerScreen != null)
            {
                this.Hide();
                scannerScreen.Show();
                //this.Dispose();
            }
            else if (!isScanman && makerCheckerScreen != null)
            {
                this.Hide();
                makerCheckerScreen.Show();
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            ui.RoleID = Int32.Parse(btnScan.filename);
            ChequeProcessing.Properties.Settings.Default.RoleID = ui.RoleID;
            ChequeProcessing.Properties.Settings.Default.RoleCD = ui.RoleCD;
            scannerScreen = new ScannerScreen(ui);
            scannerScreen.SetSelector(this);
            isScanman = true;
            this.Hide();
            scannerScreen.Show();
        }

        private void btnMaker_Click(object sender, EventArgs e)
        {
            ui.RoleID = Int32.Parse(btnMaker.filename);
            ui.RoleCD = "MAKER";
            ChequeProcessing.Properties.Settings.Default.RoleID = ui.RoleID;
            ChequeProcessing.Properties.Settings.Default.RoleCD = ui.RoleCD;
            makerCheckerScreen = new MakerCheckerScreen(ui);
            makerCheckerScreen.SetSelector(this);
            isScanman = false;
            this.Hide();
            makerCheckerScreen.Show();
        }

        private void btnChecker_Click(object sender, EventArgs e)
        {
            ui.RoleID = Int32.Parse(btnChecker.filename);
            ui.RoleCD = "CHECKER";
            ChequeProcessing.Properties.Settings.Default.RoleID = ui.RoleID;
            ChequeProcessing.Properties.Settings.Default.RoleCD = ui.RoleCD;
            makerCheckerScreen = new MakerCheckerScreen(ui);
            makerCheckerScreen.SetSelector(this);
            isScanman = false;
            this.Hide();
            makerCheckerScreen.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
            this.Dispose();
        }
    }
}
