using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChequeProcessing
{
    public partial class ChangePassword : Form
    {
        private int userID;
        private string ipAddress;

        public ChangePassword(int userID, string loginID, string ipAddress)
        {
            InitializeComponent();
            this.userID = userID;
            this.ipAddress = ipAddress;
            txtUID.Text = loginID;
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
                    else if (Char.IsSymbol(nextChar))
                    {
                        numSpecialChars++;
                    }
                }

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
                else if (numLowerLetter < policy.MinNumberOfSpecialChars)
                {
                    lblError.Text = "* password should have minimum " +
                        policy.MinNumberOfSpecialChars + " special characters";
                }
                else if ((status = db.ChangePassword(userID, txtOldPass.Text, txtNewPass.Text, ipAddress)) == 0)
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
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}