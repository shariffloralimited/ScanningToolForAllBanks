using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ChequeProcessing
{
    class BanksDB
    {
        //public String GetBankNameByBankCode(string BankCode)
        //{
        //    SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

        //    SqlDataAdapter myAdapter = new SqlDataAdapter("ACH_GetChecksByBatchNo", myConnection);
        //    myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    myAdapter.SelectCommand.CommandTimeout = 600;

        //    SqlParameter parameterBankCode = new SqlParameter("@BankCode", SqlDbType.NChar, 3);
        //    parameterBankCode.Value = BankCode;
        //    myAdapter.SelectCommand.Parameters.Add(parameterBankCode);

        //    SqlParameter parameterBankName = new SqlParameter("@BankName", SqlDbType.NVarChar, 50);
        //    parameterBankName.Direction = ParameterDirection.Output;
        //    myAdapter.SelectCommand.Parameters.Add(parameterBankName);
        //    string BankName = "";

        //    myConnection.Open();

        //    try
        //    {
        //        myAdapter.SelectCommand.ExecuteNonQuery();
        //        myConnection.Close();
        //        myConnection.Dispose();
        //        BankName = Convert.ToString(parameterBankName.Value);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //        myConnection.Close();
        //    }
        //    return BankName;
        //}
        public DataTable GetBranchesByBankID(int BankID)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetBranchesByBankID", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterBankID = new SqlParameter("@BankID", SqlDbType.Int);
            parameterBankID.Value = BankID;
            myAdapter.SelectCommand.Parameters.Add(parameterBankID);

            DataTable dt = new DataTable("Branches");
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
        public DataTable GetBranchesByUserID(int UserID, int UserRole)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetBranchesByUserID", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = UserID;
            myAdapter.SelectCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterUserRole = new SqlParameter("@UserRole", SqlDbType.Int);
            parameterUserRole.Value = UserRole;
            myAdapter.SelectCommand.Parameters.Add(parameterUserRole);

            DataTable dt = new DataTable("Branches");
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
    }
}
