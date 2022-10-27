using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ChequeProcessing
{
    public partial class ForceChangePassword : Form
    {
        Form f;
        UserInfo ui;
        private string ipAddress;
        private string loginId;
        //private int userID;
        //private int DaysPassed;
        //private int RoleID;

        public ForceChangePassword(UserInfo ui, string loginId, string ipAddress)
        {
            InitializeComponent();
            this.ui = ui;
            this.loginId = loginId;
            //this.userID = ui.UserID;
            this.ipAddress = ipAddress;
            //this.DaysPassed = ui.DaysPassed;
            txtUID.Text = this.loginId;
            //this.RoleID = ui.RoleID;
            ForceReset(ui.DaysPassed);
        }

        public void ForceReset(int daysPassed)
        {
            label5.Visible = true;
            if (daysPassed > 82 && daysPassed < 90)
            {
                int count = 90 - daysPassed;
                label5.Text = "Your Password will expire in " + count.ToString() + " days.";
            }
            if (daysPassed >= 90)
                label5.Text = "Your Password expired. Please Change Password";
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            lblError.ForeColor = Color.Red; 
            if (string.IsNullOrEmpty(txtNewPass.Text))
            {
                lblError.Text = "* Enter a new Password";
            }
            else if (txtNewPass.Text != txtConfrmPass.Text)
            {
                lblError.Text = "* Passwords didn't match";
            }
            else
            {
                UsersDB db = new UsersDB();
                PasswordPolicy policy = db.GetPasswordPolicy();
                int numUpperLetter = 0;
                int numLowerLetter = 0;
                int numAlphabets = 0;
                int numNumerics = 0;
                int numSpecialChars = 0;
                int status;
                for (int i = 0; i < txtNewPass.Text.Length; i++)
                {
                    char nextChar = txtNewPass.Text[i];
                    if (Char.IsDigit(nextChar))
                    {
                        numNumerics++;
                    }
                    else if (Char.IsUpper(nextChar))
                    {
                        numUpperLetter++;
                        numAlphabets++;
                    }
                    else if (Char.IsLower(nextChar))
                    {
                        numLowerLetter++;
                        numAlphabets++;
                    }
                    else if (!Regex.IsMatch(nextChar.ToString(), "[^0-9a-zA-Z+-.()*#!@ ]+", RegexOptions.IgnoreCase))
                    {
                        numSpecialChars++;
                    }
                }

                //if(!Regex.IsMatch(txtNewPass.Text, "[a-z0-9 ]+", RegexOptions.IgnoreCase))
                //    numSpecialChars++;

                if (txtNewPass.Text.Length < policy.MinPasswordLength)
                {
                    lblError.Text = "* Password should be minimum " +
                        policy.MinPasswordLength + " character length.";
                }
                else if (numAlphabets < policy.MinNumberOfAlphabets)
                {
                    lblError.Text = "* password should have minimum " +
                        policy.MinNumberOfAlphabets + " alphabetic characters";
                }
                else if (numNumerics < policy.MinNumberOfNumerics)
                {
                    lblError.Text = "* password should have minimum " +
                        policy.MinNumberOfNumerics + " numeric characters";
                }
                else if (numUpperLetter < policy.MinNumberOfUpperChar)
                {
                    lblError.Text = "* password should have minimum " +
                        policy.MinNumberOfUpperChar + " upper letters";
                }
                else if (numLowerLetter < policy.MinNumberOfLowerChar)
                {
                    lblError.Text = "* password should have minimum " +
                        policy.MinNumberOfLowerChar + " lower letters";
                }
                else if (numSpecialChars < policy.MinNumberOfSpecialChars)
                {
                    lblError.Text = "* password should have minimum " +
                        policy.MinNumberOfSpecialChars + " special characters";
                }
                else if ((status = db.ChangePassword(this.ui.UserID, txtOldPass.Text, txtNewPass.Text, this.ipAddress)) == 0)
                {
                    lblError.Text = "* Cannot use last " + policy.NumberOfLastPasswordsToAvoid
                        + " passwords you used.";
                }
                else if (status == -1)
                {
                    lblError.Text = "* Your old password is incorrect";
                }
                else
                {
                    lblError.ForeColor = Color.Green;
                    lblError.Text = "Password changed successfully";
                    RedirectToRegularProcess();
                    
                }
            }
        }

        private void RedirectToRegularProcess()
        {
            int UserRole = this.ui.RoleID;
            int UserID = this.ui.UserID;
            //if (UserRole == 1 || UserRole == 13)
            //{
            //    f = new ScannerScreen(ui);
            //}
            //else if (UserRole == 2 || UserRole == 3 || UserRole == 14 || UserRole == 15)
            //{
            //    f = new MakerCheckerScreen(ui);
            //}
            //else
            //{
            //    MessageBox.Show("Invalid Role information...");
            //}
            //if (f != null)
            //{
            //    f.Show();
                this.Hide();
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.ui.DaysPassed < 90)
            {
                if(!this.ui.ChangePwdNow)
                RedirectToRegularProcess();
            }
            else if(this.ui.DaysPassed >= 90)
                MessageBox.Show("You Must Change Password to login");
            //this.Dispose();
            else
                this.Dispose();
        }
    }
}