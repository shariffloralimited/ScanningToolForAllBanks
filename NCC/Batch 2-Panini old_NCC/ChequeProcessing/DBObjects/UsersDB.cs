using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace ChequeProcessing
{
    public class UserInfo
    {
        public string loginID;
        public int UserID;
        public int RoleID;
        public string BranchID;
        public string RoutingNo;
        public string BankCode;
        public string UserName;
        public string RoleName;
        public string RoleCD;
        public string BranchName;
        public string BankName;
        public string EntryHash;
        public string BranchHash;
        public int DaysPassed;
        public bool ChangePwdNow;
        public bool AllBranch;

    }

    class UsersDB
    {
        public UserInfo UserADLogin(string LoginID)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);
            SqlCommand myCommand = new SqlCommand("CPS_UserADLogin", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter paramLoginID = new SqlParameter("@LoginID", SqlDbType.NVarChar, 50);
            paramLoginID.Value = LoginID;
            myCommand.Parameters.Add(paramLoginID);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            parameterUserID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterUserID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            UserInfo ui = new UserInfo();

            ui.UserID = (int) parameterUserID.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return ui;
        }
        public UserInfo UserLogin(string LoginID, string Password)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);
            SqlCommand myCommand = new SqlCommand("CPS_UserLogin", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterLoginID = new SqlParameter("@LoginID", SqlDbType.VarChar, 50);
            parameterLoginID.Value = LoginID;
            myCommand.Parameters.Add(parameterLoginID);

            SqlParameter parameterPassword = new SqlParameter("@Password", SqlDbType.VarChar, 50);
            parameterPassword.Value = Encrypt(Password);
            myCommand.Parameters.Add(parameterPassword);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            parameterUserID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterBranchID = new SqlParameter("@BranchID", SqlDbType.Int, 4);
            parameterBranchID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterBranchID);

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.VarChar, 9);
            parameterRoutingNo.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterBankCode = new SqlParameter("@BankCode", SqlDbType.VarChar, 3);
            parameterBankCode.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterBankCode);

            SqlParameter parameterUserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
            parameterUserName.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterUserName);

            SqlParameter parameterBranchName = new SqlParameter("@BranchName", SqlDbType.VarChar, 50);
            parameterBranchName.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterBranchName);

            SqlParameter parameterBankName = new SqlParameter("@BankName", SqlDbType.VarChar, 50);
            parameterBankName.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterBankName);

            SqlParameter paramDaysPassed = new SqlParameter("@DaysPassed", SqlDbType.Int);
            paramDaysPassed.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(paramDaysPassed);

            SqlParameter paramChangePwdNow = new SqlParameter("@ChangePwdNow", SqlDbType.Bit);
            paramChangePwdNow.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(paramChangePwdNow);


            myConnection.Open();
            myCommand.ExecuteNonQuery();

            UserInfo ui = new UserInfo();

            ui.UserID = (int) parameterUserID.Value;
            ui.BranchID = parameterBranchID.Value.ToString();
            ui.RoutingNo = (string)parameterRoutingNo.Value;
            ui.BankCode = (string)parameterBankCode.Value;

            ui.UserName = (string)parameterUserName.Value;
            ui.BranchName = (string)parameterBranchName.Value;
            ui.BankName = (string)parameterBankName.Value;

            ui.DaysPassed = (int)(string.IsNullOrEmpty(paramDaysPassed.Value.ToString()) ? 0 : paramDaysPassed.Value);
            ui.ChangePwdNow = (bool)paramChangePwdNow.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return ui;
        }

        public DataTable GetRoles(int UserID)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);
            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetRoles", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter paramUserID = new SqlParameter("@UserID", SqlDbType.Int);
            paramUserID.Value = UserID;
            myAdapter.SelectCommand.Parameters.Add(paramUserID);

            DataTable dt = new DataTable();
            myConnection.Open();

            try
            {
                myAdapter.SelectCommand.ExecuteNonQuery();
                myAdapter.Fill(dt);
                myConnection.Close();
                myConnection.Dispose();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                myConnection.Close();
            }
            return dt;
        }


        public string Encrypt(string cleanString)
        {
            Byte[] clearBytes = new UnicodeEncoding().GetBytes(cleanString);
            Byte[] hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);

            return BitConverter.ToString(hashedBytes);
        }

        public int ChangePassword(int UserID, String OldPassword, String NewPassword, String IPAddress)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);
            SqlCommand myCommand = new SqlCommand("CPS_ChangePassword", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter paramUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            paramUserID.Value = UserID;
            myCommand.Parameters.Add(paramUserID);

            SqlParameter paramOldPassword = new SqlParameter("@OldPassword", SqlDbType.NVarChar, 50);
            paramOldPassword.Value = Encrypt(OldPassword);
            myCommand.Parameters.Add(paramOldPassword);

            SqlParameter paramNewPassword = new SqlParameter("@NewPassword", SqlDbType.NVarChar, 50);
            paramNewPassword.Value = Encrypt(NewPassword);
            myCommand.Parameters.Add(paramNewPassword);

            SqlParameter paramIPAddress = new SqlParameter("@IPAddress", SqlDbType.NVarChar, 40);
            paramIPAddress.Value = IPAddress;
            myCommand.Parameters.Add(paramIPAddress);

            SqlParameter paramStatus = new SqlParameter("@Status", SqlDbType.Int, 4);
            paramStatus.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(paramStatus);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            return (int)paramStatus.Value;
        }

        public PasswordPolicy GetPasswordPolicy()
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);
            SqlCommand myCommand = new SqlCommand("CPS_GetPasswordPolicy", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter paramMinPasswordLength = new SqlParameter("@MinPasswordLength", SqlDbType.Int, 4);
            paramMinPasswordLength.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(paramMinPasswordLength);

            SqlParameter paramMinNumberOfAlphabets = new SqlParameter("@MinNumberOfAlphabets", SqlDbType.Int, 4);
            paramMinNumberOfAlphabets.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(paramMinNumberOfAlphabets);

            SqlParameter paramMinNumberOfNumerics = new SqlParameter("@MinNumberOfNumerics", SqlDbType.Int, 4);
            paramMinNumberOfNumerics.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(paramMinNumberOfNumerics);

            SqlParameter paramMinNumberOfSpecialChars = new SqlParameter("@MinNumberOfSpecialChars", SqlDbType.Int, 4);
            paramMinNumberOfSpecialChars.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(paramMinNumberOfSpecialChars);

            SqlParameter paramNumberOfLastPasswordsToAvoid = new SqlParameter("@NumberOfLastPasswordsToAvoid", SqlDbType.Int, 4);
            paramNumberOfLastPasswordsToAvoid.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(paramNumberOfLastPasswordsToAvoid);

            SqlParameter paramMinNumberOfUpperChar = new SqlParameter("@MinNumberOfUpperChar", SqlDbType.Int, 4);
            paramMinNumberOfUpperChar.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(paramMinNumberOfUpperChar);

            SqlParameter paramMinNumberOfLowerChar = new SqlParameter("@MinNumberOfLowerChar", SqlDbType.Int, 4);
            paramMinNumberOfLowerChar.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(paramMinNumberOfLowerChar);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            PasswordPolicy policy = new PasswordPolicy();
            policy.MinNumberOfAlphabets = Convert.ToInt32(paramMinNumberOfAlphabets.Value);
            policy.MinNumberOfLowerChar = Convert.ToInt32(paramMinNumberOfLowerChar.Value);
            policy.MinNumberOfNumerics = Convert.ToInt32(paramMinNumberOfNumerics.Value);
            policy.MinNumberOfSpecialChars = Convert.ToInt32(paramMinNumberOfSpecialChars.Value);
            policy.MinNumberOfUpperChar = Convert.ToInt32(paramMinNumberOfUpperChar.Value);
            policy.MinPasswordLength = Convert.ToInt32(paramMinPasswordLength.Value);
            policy.NumberOfLastPasswordsToAvoid = Convert.ToInt32(paramNumberOfLastPasswordsToAvoid.Value);

            return policy;
        }

        public void ResetPassword(int userID, string password)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);
            SqlCommand myCommand = new SqlCommand("ACH_ResetPassword", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter paramUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            paramUserID.Value = userID;
            myCommand.Parameters.Add(paramUserID);

            SqlParameter paramPassword = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
            paramPassword.Value = Encrypt(password);
            myCommand.Parameters.Add(paramPassword);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        
        public string GetUserName(int UserID)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetUserName", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter paramUserID = new SqlParameter("@UserID", SqlDbType.Int);
            paramUserID.Value = UserID;
            myAdapter.SelectCommand.Parameters.Add(paramUserID);

            SqlParameter paramUserName = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
            paramUserName.Direction = ParameterDirection.Output;
            myAdapter.SelectCommand.Parameters.Add(paramUserName);

            myConnection.Open();
            string UserName = String.Empty;
            try
            {
                myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
                UserName = paramUserName.Value.ToString();
            }
            catch (Exception ex)
            {
                myConnection.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return UserName;
        }

        internal void LockUser(string LoginID)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);
            SqlCommand myCommand = new SqlCommand("ACH_LockUser", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@LoginID", SqlDbType.VarChar, 50).Value = LoginID;

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        internal UserDetail GetUserDetails(int UserID)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetUserDetailsByUserID", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter paramUserID = new SqlParameter("@UserID", SqlDbType.Int);
            paramUserID.Value = UserID;
            myAdapter.SelectCommand.Parameters.Add(paramUserID);

            SqlParameter paramUserName = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
            paramUserName.Direction = ParameterDirection.Output;
            myAdapter.SelectCommand.Parameters.Add(paramUserName);

            myAdapter.SelectCommand.Parameters.Add("@BranchName", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

            myConnection.Open();
            string UserName = String.Empty;
            UserDetail u = new UserDetail();
            try
            {
                myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
                u.UserName = myAdapter.SelectCommand.Parameters["@UserName"].Value.ToString();
                u.BranchName = myAdapter.SelectCommand.Parameters["@BranchName"].Value.ToString();
            }
            catch (Exception ex)
            {
                myConnection.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return u;
        }
    }
    class UserDetail
    {
        public string UserName { get; set; }
        public string BranchName { get; set; }
    }

}
