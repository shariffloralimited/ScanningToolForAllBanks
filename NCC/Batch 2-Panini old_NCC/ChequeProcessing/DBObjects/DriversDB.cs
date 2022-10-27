using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace ChequeProcessing
{
    class DriversDB
    {
        public void InsertCheque(DateTime CheckDate, String CheckSLNo, String IssueBankCode,
            String IssueDistrictCode, String IssueBranchCode, int CheckDigit, String IssueActNo,
            String IssueTransCode, double Amount, String RemBranchID, String ImgFront,
            String ImgBack, int StatusID)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("ACH_InsertCheckInfo", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterCheckDate = new SqlParameter("@CheckDate", SqlDbType.DateTime);
            parameterCheckDate.Value = CheckDate;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckDate);

            SqlParameter parameterCheckSLNo = new SqlParameter("@CheckSLNo", SqlDbType.NChar, 7);
            parameterCheckSLNo.Value = CheckSLNo;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckSLNo);

            SqlParameter parameterIssueBankCode = new SqlParameter("@IssueBankCode", SqlDbType.NChar, 3);
            parameterIssueBankCode.Value = IssueBankCode;
            myAdapter.SelectCommand.Parameters.Add(parameterIssueBankCode);

            SqlParameter parameterIssueDistrictCode = new SqlParameter("@IssueDistrictCode", SqlDbType.NChar, 2);
            parameterIssueDistrictCode.Value = IssueDistrictCode;
            myAdapter.SelectCommand.Parameters.Add(parameterIssueDistrictCode);

            SqlParameter parameterIssueBranchCode = new SqlParameter("@IssueBranchCode", SqlDbType.NChar, 3);
            parameterIssueBranchCode.Value = IssueBranchCode;
            myAdapter.SelectCommand.Parameters.Add(parameterIssueBranchCode);

            SqlParameter parameterCheckDigit = new SqlParameter("@CheckDigit", SqlDbType.TinyInt);
            parameterCheckDigit.Value = CheckDigit;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckDigit);

            SqlParameter parameterIssueActNo = new SqlParameter("@IssueActNo", SqlDbType.NChar, 13);
            parameterIssueActNo.Value = IssueActNo;
            myAdapter.SelectCommand.Parameters.Add(parameterIssueActNo);

            SqlParameter parameterIssueTransCode = new SqlParameter("@IssueTransCode", SqlDbType.NChar, 2);
            parameterIssueTransCode.Value = IssueTransCode;
            myAdapter.SelectCommand.Parameters.Add(parameterIssueTransCode);

            SqlParameter parameterAmount = new SqlParameter("@Amount", SqlDbType.Money);
            parameterAmount.Value = Amount;
            myAdapter.SelectCommand.Parameters.Add(parameterAmount);

            SqlParameter parameterRemBranchID = new SqlParameter("@RemBranchID", SqlDbType.NChar, 3);
            parameterRemBranchID.Value = RemBranchID;
            myAdapter.SelectCommand.Parameters.Add(parameterRemBranchID);

            SqlParameter parameterImgFront = new SqlParameter("@ImgFront", SqlDbType.NVarChar, 250);
            parameterImgFront.Value = ImgFront;
            myAdapter.SelectCommand.Parameters.Add(parameterImgFront);

            SqlParameter parameterImgBack = new SqlParameter("@ImgBack", SqlDbType.NVarChar, 250);
            parameterImgBack.Value = ImgBack;
            myAdapter.SelectCommand.Parameters.Add(parameterImgBack);

            SqlParameter parameterStatusID = new SqlParameter("@StatusID", SqlDbType.NChar, 3);
            parameterStatusID.Value = StatusID;
            myAdapter.SelectCommand.Parameters.Add(parameterStatusID);

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier);
            parameterCheckID.Direction = ParameterDirection.Output;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckID);

            //Guid ChequeID;
            myConnection.Open();
            try
            {
                myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
                // return null;
            }
            catch (Exception ex)
            {
                myConnection.Close();
                //  return null;
            }
            //return ChequeID;
        }
        //public SqlDataReader DailyReport(DateTime EntryDate)
        //{
        //    SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);
        //    SqlCommand myCommand = new SqlCommand("ACH_DailyReport", myConnection);
        //    myCommand.CommandType = CommandType.StoredProcedure;

        //    SqlParameter parameterEntryDate = new SqlParameter("@EntryDate", SqlDbType.DateTime);
        //    parameterEntryDate.Value = EntryDate;
        //    myCommand.Parameters.Add(parameterEntryDate);

        //    myConnection.Open();
        //    SqlDataReader result = myCommand.ExecuteReader();
        //    myCommand.Dispose();

        //    return result;
        //}
        public DataTable DailyReport(DateTime EntryDate)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);
            SqlDataAdapter myAdapter = new SqlDataAdapter("ACH_DailyReport", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterEntryDate = new SqlParameter("@EntryDate", SqlDbType.DateTime);
            parameterEntryDate.Value = EntryDate;
            myAdapter.SelectCommand.Parameters.Add(parameterEntryDate);

            DataTable dt = new DataTable("DailyReport");
            myConnection.Open();
            myAdapter.Fill(dt);
            myConnection.Close();
            myConnection.Dispose();
            myAdapter.Dispose();
            return dt;
        }

    }
}
