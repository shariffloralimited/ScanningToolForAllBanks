using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ChequeProcessing.Lookups;
using System.Net;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Configuration;

namespace ChequeProcessing
{
    public partial class Login : Form
    {
        IPAddress[] address = Dns.GetHostAddresses(Dns.GetHostName());
        Form f;
        int tries = 0;
        ServerSelector select;
        UsersDB db = new UsersDB();

        protected string BranchNumonic = "";
        public bool IsAuthenticated(string srvr, string usr, string pwd)
        {
            bool authenticated = false;
            SearchResult result = UTILITY.DirectoryHelper.serachLogin(usr, pwd);

            if (result != null)
            {
                ResultPropertyCollection col = result.Properties;
                foreach (string key in col.PropertyNames)
                {
                    string str = "";
                    foreach (object curcol in col[key])
                    {
                        str = str + curcol;
                    }
                    if (key == "physicaldeliveryofficename")
                    {
                        BranchNumonic = str;
                    }
                }
                authenticated = true;
            }
            return authenticated;
        }
        public Login()
        {
            InitializeComponent();
            Config.ConnectionString = "DCConnection";
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            MakeLogin();
        }
        private void TextPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                MakeLogin();
            }
        }
        private void MakeLogin()
        {

            if (tries > 2)
            {
                db.LockUser(TextLoginID.Text);
                MessageBox.Show("User is locked...");
                return;
            }


            if (ConfigurationManager.AppSettings["ADLogin"].ToString().ToUpper() == "TRUE")
            {
                if (!IsAuthenticated(ConfigurationManager.AppSettings["ADServer"], TextLoginID.Text, TextPassword.Text))
                {
                    MessageBox.Show("Login Failed (AD Login)");
                    return;
                }
                ADLogin();
            }
            else
            {
                DBLogin();
            }
        }

        private void ADLogin()
        {
            UserInfo ui = db.UserADLogin(TextLoginID.Text);
            if (ui == null)
            {
                System.Windows.Forms.MessageBox.Show("Cannot Connect the Server. Please make sure the server is Ready.");
                return;
            }
            else if (ui.UserID == 0)
            {
                MessageBox.Show("Login Failed (AD Login)");
                tries++;
                return;
            }

            ui.loginID = TextLoginID.Text;
            DataTable roles = db.GetRoles(ui.UserID);
            RoleSelector selecctor = new RoleSelector();
            selecctor.ui = ui;
            selecctor.roles = roles;
            selecctor.Start();
            this.Hide();
        }
        private void DBLogin()
        {
            UserInfo ui = db.UserLogin(TextLoginID.Text, TextPassword.Text);
            if (ui == null)
            {
                System.Windows.Forms.MessageBox.Show("Cannot Connect the Server. Please make sure the server is Ready.");
                return;
            }
            else if (ui.UserID == 0)
            {
                MessageBox.Show("Login Failed.");
                tries++;
                return;
            }

            else if (ui.ChangePwdNow == true)
            {
                f = new ForceChangePassword(ui, TextLoginID.Text, address[0].ToString());
                if (f != null)
                {
                    f.ShowDialog();
                    this.Hide();
                }
            }
            else if (ui.DaysPassed > 83 && ui.DaysPassed < 91)
            {
                f = new ForceChangePassword(ui, TextLoginID.Text, address[0].ToString());
                if (f != null)
                {
                    f.ShowDialog();
                    this.Hide();
                }
            }

            else if (ui.DaysPassed > 90)
            {
                f = new ForceChangePassword(ui, TextLoginID.Text, address[0].ToString());
                if (f != null)
                {
                    f.ShowDialog();
                    this.Hide();
                }
            }

            ui.loginID = TextLoginID.Text;
            DataTable roles = db.GetRoles(ui.UserID);
            RoleSelector selecctor = new RoleSelector();
            selecctor.ui = ui;
            selecctor.roles = roles;
            selecctor.Start();
            this.Hide();
        }


        private void TextLoginID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                TextPassword.Focus();
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(select == null){
                select =  new ServerSelector();
            }
            select.Show();
        }
    }
}