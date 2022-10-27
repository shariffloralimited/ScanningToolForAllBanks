using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Collections.Generic;


namespace ChequeProcessing
{
    class ChequesDB
    {
        public Guid InsertCheque(DateTime CheckDate, String CheckSLNo, String RoutingNo,
            String IssueActNo, String IssueTransCode, long Amount, String ImgFront,
            String ImgBack, int StatusID, Guid BatchNo, string BenefActNo, string itemSeqNo,
            string IPAddress, int UserID, string MICRVaildInd)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_InsertOutwardCheck", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterCheckDate = new SqlParameter("@CheckDate", SqlDbType.Int);
            parameterCheckDate.Value = Int32.Parse(CheckDate.ToString("ddMMyyyy"));
            myAdapter.SelectCommand.Parameters.Add(parameterCheckDate);

            SqlParameter parameterCheckSLNo = new SqlParameter("@CheckSLNo", SqlDbType.VarChar, 7);
            parameterCheckSLNo.Value = CheckSLNo;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckSLNo);

            SqlParameter parameterRoutingNo = new SqlParameter("@IssueRoutingNo", SqlDbType.VarChar, 9);
            parameterRoutingNo.Value = RoutingNo;
            myAdapter.SelectCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterIssueActNo = new SqlParameter("@CheckActNo", SqlDbType.VarChar, 13);
            parameterIssueActNo.Value = IssueActNo;
            myAdapter.SelectCommand.Parameters.Add(parameterIssueActNo);

            SqlParameter parameterIssueTransCode = new SqlParameter("@CheckTransCode", SqlDbType.VarChar, 2);
            parameterIssueTransCode.Value = IssueTransCode;
            myAdapter.SelectCommand.Parameters.Add(parameterIssueTransCode);

            SqlParameter parameterAmount = new SqlParameter("@CheckAmount", SqlDbType.BigInt);
            parameterAmount.Value = Amount;
            myAdapter.SelectCommand.Parameters.Add(parameterAmount);

            SqlParameter parameterStatusID = new SqlParameter("@StatusID", SqlDbType.Int);
            parameterStatusID.Value = StatusID;
            myAdapter.SelectCommand.Parameters.Add(parameterStatusID);

            SqlParameter parameterBatchNo = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier);
            parameterBatchNo.Value = BatchNo;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchNo);

            SqlParameter parameterBenefActNo = new SqlParameter("@BenefActNo", SqlDbType.NVarChar, 13);
            parameterBenefActNo.Value = BenefActNo;
            myAdapter.SelectCommand.Parameters.Add(parameterBenefActNo);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = UserID;
            myAdapter.SelectCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterMICRVaildInd = new SqlParameter("@MICRValidInd", SqlDbType.NChar, 1);
            parameterMICRVaildInd.Value = MICRVaildInd;
            myAdapter.SelectCommand.Parameters.Add(parameterMICRVaildInd);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.NVarChar, 40);
            parameterIPAddress.Value = IPAddress;
            myAdapter.SelectCommand.Parameters.Add(parameterIPAddress);

            SqlParameter parameterItemSeqNo = new SqlParameter("@ItemSeqNo", SqlDbType.NVarChar, 40);
            parameterItemSeqNo.Value = itemSeqNo;
            myAdapter.SelectCommand.Parameters.Add(parameterItemSeqNo);

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier);
            parameterCheckID.Direction = ParameterDirection.Output;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckID);
            Guid CheckID = new Guid("00000000-0000-0000-0000-000000000000");
            myConnection.Open();
            try
            {
                myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
                CheckID = (Guid)(parameterCheckID.Value);
            }
            catch (Exception e)
            {
                myConnection.Close();
                MessageBox.Show(e.Message);
            }
            return CheckID;

        }
        
        public int UpdateCheque(Guid CheckID, DateTime CheckDate, String CheckSLNo, String RoutingNo,
            String IssueActNo, String IssueTransCode, double Amount, Guid BatchNo, string BenefActNo,
            string MICRVaildInd, int StatusID, string BranchCode, string IPAddress, int UserID)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_UpdateOutwardCheck", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier);
            parameterCheckID.Value = CheckID;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterCheckDate = new SqlParameter("@CheckDate", SqlDbType.DateTime);
            parameterCheckDate.Value = Int32.Parse(CheckDate.ToString("ddMMyyyy")); 
            myAdapter.SelectCommand.Parameters.Add(parameterCheckDate);

            SqlParameter parameterCheckSLNo = new SqlParameter("@CheckSLNo", SqlDbType.NChar, 7);
            parameterCheckSLNo.Value = CheckSLNo;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckSLNo);

            SqlParameter parameterRoutingNo = new SqlParameter("@IssueRoutingNo", SqlDbType.NChar, 9);
            parameterRoutingNo.Value = RoutingNo;
            myAdapter.SelectCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterIssueActNo = new SqlParameter("@CheckActNo", SqlDbType.NChar, 13);
            parameterIssueActNo.Value = IssueActNo;
            myAdapter.SelectCommand.Parameters.Add(parameterIssueActNo);

            SqlParameter parameterIssueTransCode = new SqlParameter("@CheckTransCode", SqlDbType.NChar, 2);
            parameterIssueTransCode.Value = IssueTransCode;
            myAdapter.SelectCommand.Parameters.Add(parameterIssueTransCode);

            SqlParameter parameterAmount = new SqlParameter("@CheckAmount", SqlDbType.Money);
            parameterAmount.Value = Amount;
            myAdapter.SelectCommand.Parameters.Add(parameterAmount);

            SqlParameter parameterStatusID = new SqlParameter("@StatusID", SqlDbType.Int);
            parameterStatusID.Value = StatusID;
            myAdapter.SelectCommand.Parameters.Add(parameterStatusID);

            SqlParameter parameterBatchNo = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier);
            parameterBatchNo.Value = BatchNo;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchNo);

            SqlParameter parameterBenefActNo = new SqlParameter("@BenefActNo", SqlDbType.NVarChar, 13);
            parameterBenefActNo.Value = BenefActNo;
            myAdapter.SelectCommand.Parameters.Add(parameterBenefActNo);

            SqlParameter parameterBranchCode = new SqlParameter("@BranchCode", SqlDbType.NVarChar, 13);
            parameterBranchCode.Value = BranchCode;
            myAdapter.SelectCommand.Parameters.Add(parameterBranchCode);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = UserID;
            myAdapter.SelectCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterMICRVaildInd = new SqlParameter("@MICRValidInd", SqlDbType.NChar, 1);
            parameterMICRVaildInd.Value = MICRVaildInd;
            myAdapter.SelectCommand.Parameters.Add(parameterMICRVaildInd);


            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.NVarChar, 40);
            parameterIPAddress.Value = IPAddress;
            myAdapter.SelectCommand.Parameters.Add(parameterIPAddress);

            myConnection.Open();

            int nRows = 0;

            try
            {
                nRows = myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                myConnection.Close();
            }
            return nRows;
        }
        
        public int UpdateChequeMICR(Guid CheckID, String CheckSLNo, String RoutingNo,
            String IssueActNo, String IssueTransCode, string IPAddress, long EndorseNo, int UserID)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_UpdateOutwardCheckMICR", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier);
            parameterCheckID.Value = CheckID;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterCheckSLNo = new SqlParameter("@CheckSLNo", SqlDbType.NChar, 7);
            parameterCheckSLNo.Value = CheckSLNo;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckSLNo);

            SqlParameter parameterRoutingNo = new SqlParameter("@IssueRoutingNo", SqlDbType.NChar, 9);
            parameterRoutingNo.Value = RoutingNo;
            myAdapter.SelectCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterIssueActNo = new SqlParameter("@CheckActNo", SqlDbType.NChar, 13);
            parameterIssueActNo.Value = IssueActNo;
            myAdapter.SelectCommand.Parameters.Add(parameterIssueActNo);

            SqlParameter parameterIssueTransCode = new SqlParameter("@CheckTransCode", SqlDbType.NChar, 2);
            parameterIssueTransCode.Value = IssueTransCode;
            myAdapter.SelectCommand.Parameters.Add(parameterIssueTransCode);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = UserID;
            myAdapter.SelectCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterEndorseNo = new SqlParameter("@EndorseNo", SqlDbType.BigInt);
            parameterEndorseNo.Value = EndorseNo;
            myAdapter.SelectCommand.Parameters.Add(parameterEndorseNo);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.NVarChar, 40);
            parameterIPAddress.Value = IPAddress;
            myAdapter.SelectCommand.Parameters.Add(parameterIPAddress);

            myConnection.Open();

            int nRows = 0;

            try
            {
                nRows = myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                myConnection.Close();
            }
            return nRows;
        }
        public int InsertChequeImages(Guid CheckID, Guid BatchID, MemoryStream ImgFront, MemoryStream ImgBack, int UserID, string IPAddress)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_InsertChequeImages", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier);
            parameterCheckID.Value = CheckID;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterBatchID = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier);
            parameterBatchID.Value = BatchID;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchID);

            SqlParameter parameterImgFront = new SqlParameter("@FrontImage", SqlDbType.Image);
            parameterImgFront.Value = ImgFront.ToArray();
            myAdapter.SelectCommand.Parameters.Add(parameterImgFront);

            SqlParameter parameterImgBack = new SqlParameter("@BackImage", SqlDbType.Image);
            parameterImgBack.Value = ImgBack.ToArray();
            myAdapter.SelectCommand.Parameters.Add(parameterImgBack);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = UserID;
            myAdapter.SelectCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.NVarChar, 40);
            parameterIPAddress.Value = IPAddress;
            myAdapter.SelectCommand.Parameters.Add(parameterIPAddress);

            myConnection.Open();

            int nRows = 0;

            try
            {
                nRows = myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                myConnection.Close();
            }
            return nRows;
        }
        /*
        public int InsertProtectedData(Guid CheckID, string ProtectedFrontData, string ProtectedBackData)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_UpdateProtectedData", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier);
            parameterCheckID.Value = CheckID;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterProtectedFrontData = new SqlParameter("@ProtectedFrontData", SqlDbType.NVarChar, 64000);
            parameterProtectedFrontData.Value = ProtectedFrontData;
            myAdapter.SelectCommand.Parameters.Add(parameterProtectedFrontData);

            SqlParameter parameterProtectedBackData = new SqlParameter("@ProtectedBackData", SqlDbType.NVarChar, 64000);
            parameterProtectedBackData.Value = ProtectedBackData;
            myAdapter.SelectCommand.Parameters.Add(parameterProtectedBackData);

            myConnection.Open();

            int nRows = 0;

            try
            {
                nRows = myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                myConnection.Close();
            }
            return nRows;
        }
        */
        public int DeleteCheque(Guid CheckID, string DeleteReason, int UserID, string IPAddress)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_DeleteCheck", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier);
            parameterCheckID.Value = CheckID;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterImgFront = new SqlParameter("@DeleteReason", SqlDbType.NVarChar);
            parameterImgFront.Value = DeleteReason;
            myAdapter.SelectCommand.Parameters.Add(parameterImgFront);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = UserID;
            myAdapter.SelectCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.NVarChar, 40);
            parameterIPAddress.Value = IPAddress;
            myAdapter.SelectCommand.Parameters.Add(parameterIPAddress);

            myConnection.Open();

            int nRows = 0;

            try
            {
                nRows = myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                myConnection.Close();
            }
            return nRows;
        }
        
        public DataTable GetChequeImages(Guid CheckID)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetSingleImage", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier);
            parameterCheckID.Value = CheckID;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckID);

            myConnection.Open();

            DataTable table = new DataTable("Images");
            try
            {
                myAdapter.SelectCommand.ExecuteNonQuery();
                myAdapter.Fill(table);
                myConnection.Close();
                myConnection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                myConnection.Close();
            }
            return table;
        }
        
        public int EnterAmount(Guid CheckID, long CheckAmount, string BenefActNo,string BenefActName, string BranchCode, int UserID, string IPAddress)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_EnterCheckAmount", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier);
            parameterCheckID.Value = CheckID;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterAmount = new SqlParameter("@CheckAmount", SqlDbType.BigInt);
            parameterAmount.Value = CheckAmount;
            myAdapter.SelectCommand.Parameters.Add(parameterAmount);

            SqlParameter parameterBenefActNo = new SqlParameter("@BenefActNo", SqlDbType.NVarChar, 17);
            parameterBenefActNo.Value = BenefActNo;
            myAdapter.SelectCommand.Parameters.Add(parameterBenefActNo);

            SqlParameter parameterBenefActName = new SqlParameter("@BenefActName", SqlDbType.NVarChar, 50);
            parameterBenefActName.Value = BenefActName;
            myAdapter.SelectCommand.Parameters.Add(parameterBenefActName);

            SqlParameter parameterBranchCode = new SqlParameter("@BranchCode", SqlDbType.NVarChar, 50);
            parameterBranchCode.Value = BranchCode;
            myAdapter.SelectCommand.Parameters.Add(parameterBranchCode);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = UserID;
            myAdapter.SelectCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.NVarChar, 40);
            parameterIPAddress.Value = IPAddress;
            myAdapter.SelectCommand.Parameters.Add(parameterIPAddress);

            myConnection.Open();

            int nRows = 0;

            try
            {
                nRows = myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                myConnection.Close();
            }
            return nRows;

        }

        internal DataTable FindDuplicateCheckByBatchID(Guid batchID)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);
            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetDuplicateList", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            myAdapter.SelectCommand.Parameters.Add("@BatchID", SqlDbType.UniqueIdentifier).Value = batchID;

            DataTable table = new DataTable();
            try
            {
                myConnection.Open();
                myAdapter.SelectCommand.ExecuteNonQuery();
                myAdapter.Fill(table);
                myConnection.Close();
                myConnection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                myConnection.Close();
            }
            return table;
        }

        public int ApproveCheck(Guid CheckID, int UserID, string IPAddress)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_ApproveOutwardCheck", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier);
            parameterCheckID.Value = CheckID;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = UserID;
            myAdapter.SelectCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.NVarChar, 40);
            parameterIPAddress.Value = IPAddress;
            myAdapter.SelectCommand.Parameters.Add(parameterIPAddress);

            myConnection.Open();

            int nRows = 0;

            try
            {
                nRows = myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                myConnection.Close();
            }
            return nRows;
        }
        
        public int CompleteScanningForSingleCheck(Guid CheckID, int UserID, string IPAddress)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_CompleteScanningForSingleCheck", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier);
            parameterCheckID.Value = CheckID;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = UserID;
            myAdapter.SelectCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.NVarChar, 40);
            parameterIPAddress.Value = IPAddress;
            myAdapter.SelectCommand.Parameters.Add(parameterIPAddress);

            myConnection.Open();

            int nRows = 0;

            try
            {
                nRows = myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                myConnection.Close();
            }
            return nRows;
        }
        
        public int SendToMaker(Guid CheckID, string ReturnReason, int UserID, string IPAddress)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_SendToMaker", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier);
            parameterCheckID.Value = CheckID;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterReturnReason = new SqlParameter("@ReturnReason", SqlDbType.NVarChar, 40);
            parameterReturnReason.Value = ReturnReason;
            myAdapter.SelectCommand.Parameters.Add(parameterReturnReason);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = UserID;
            myAdapter.SelectCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.NVarChar, 40);
            parameterIPAddress.Value = IPAddress;
            myAdapter.SelectCommand.Parameters.Add(parameterIPAddress);

            myConnection.Open();

            int nRows = 0;

            try
            {
                nRows = myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                myConnection.Close();
            }
            return nRows;
        }
        /*
        public void InsertErrInfo(Guid CheckID, int Error)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("ACH_InsertErrorInfo", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier);
            parameterCheckID.Value = CheckID;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterError = new SqlParameter("@Error", SqlDbType.Int);
            parameterError.Value = Error;
            myAdapter.SelectCommand.Parameters.Add(parameterError);

            SqlParameter parameterErrID = new SqlParameter("@ErrID", SqlDbType.Int);
            parameterErrID.Direction = ParameterDirection.Output;
            myAdapter.SelectCommand.Parameters.Add(parameterErrID);

            myConnection.Open();
            try
            {
                myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
            }
            catch (Exception ex)
            {
                myConnection.Close();
            }
        }

        public int GetNextDepositSlipNo()
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("ACH_GetNextDepSlipNo", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterDepositeSlipNo = new SqlParameter("@DepositeSlipNo", SqlDbType.Int);
            parameterDepositeSlipNo.Direction = ParameterDirection.Output;
            myAdapter.SelectCommand.Parameters.Add(parameterDepositeSlipNo);

            myConnection.Open();
            int NextSlipNo = 0;
            try
            {
                myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
                NextSlipNo = Convert.ToInt32(parameterDepositeSlipNo.Value);

            }
            catch (Exception ex)
            {
                myConnection.Close();
            }
            return NextSlipNo;
        }
        */
        public DataTable GetCheckListByBatchNo(Guid BatchNo, int StatusID, bool Complete)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter;
            if (Complete)
            {
                myAdapter = new SqlDataAdapter("CPS_GetCompleteCheckListByBatchNo", myConnection);
            }
            else
            {
                myAdapter = new SqlDataAdapter("CPS_GetCheckListByBatchNo", myConnection);
            }
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterBatchNo = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier);
            parameterBatchNo.Value = BatchNo;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchNo);

            SqlParameter parameterStatusID = new SqlParameter("@StatusID", SqlDbType.Int);
            parameterStatusID.Value = StatusID;
            myAdapter.SelectCommand.Parameters.Add(parameterStatusID);


            DataTable dt = new DataTable("ChecksByBatchNo");
            try
            {
                myConnection.Open();
                myAdapter.Fill(dt);
                myConnection.Close();
                myConnection.Dispose();
                myAdapter.Dispose();
            }
            catch
            {
                myConnection.Dispose();
                myAdapter.Dispose();
            }
            return dt;
        }
        
        public DataTable GetCheckDetailByBatchNo(Guid BatchNo, int StatusID, bool Complete, int userId)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter;
            if (!Complete)
            {
                myAdapter = new SqlDataAdapter("CPS_GetCheckDetailByBatchNo", myConnection);
            }
            else
            {
                myAdapter = new SqlDataAdapter("CPS_GetCompleteCheckDetailByBatchNo", myConnection);
            }

            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterBatchNo = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier);
            parameterBatchNo.Value = BatchNo;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchNo);

            SqlParameter parameterStatusID = new SqlParameter("@StatusID", SqlDbType.Int);
            parameterStatusID.Value = StatusID;
            myAdapter.SelectCommand.Parameters.Add(parameterStatusID);

           // myAdapter.SelectCommand.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;

            DataTable dt = new DataTable("ChecksByBatchNo");
            try
            {
                myConnection.Open();
                myAdapter.Fill(dt);
                myConnection.Close();
                myConnection.Dispose();
                myAdapter.Dispose();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                myConnection.Dispose();
                myAdapter.Dispose();
            }
            return dt;
        }

        public string[] GetTransCodes()
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetTransCodes", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            DataTable dt = new DataTable("SortBucket");
            try
            {
                myConnection.Open();
                myAdapter.Fill(dt);
                myConnection.Close();
                myConnection.Dispose();
                myAdapter.Dispose();
            }
            catch
            {
                myConnection.Dispose();
                myAdapter.Dispose();
            }
            string[] arr = new string[dt.Rows.Count];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = dt.Rows[i].ItemArray[0].ToString();
            }
            return arr;
        }

        public List<string> GetTransCodeByCCY(string ccy)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlCommand myAdapter = new SqlCommand("CPS_GetTransCodeByCCY", myConnection);
            myAdapter.CommandType = CommandType.StoredProcedure;
            myAdapter.CommandTimeout = 600;

            myAdapter.Parameters.Add("@CCY", SqlDbType.Char, 3).Value = ccy;
            List<string> transCodelist = new List<string>();
            try
            {
                myConnection.Open();
                var reader = myAdapter.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                   
                    transCodelist.Add(reader["TransCode"].ToString());
                }
                myConnection.Close();
                myConnection.Dispose();
                myAdapter.Dispose();
            }
            catch
            {
                myConnection.Dispose();
                myAdapter.Dispose();
                return null;
            }
            return transCodelist;
        }

        public DataTable GetChecksFromSortBucket(int RoutingNo)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetChecksFromSortBucket", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int);
            parameterRoutingNo.Value = RoutingNo;
            myAdapter.SelectCommand.Parameters.Add(parameterRoutingNo);


            DataTable dt = new DataTable("SortBucket");
            try
            {
                myConnection.Open();
                myAdapter.Fill(dt);
                myConnection.Close();
                myConnection.Dispose();
                myAdapter.Dispose();
            }
            catch
            {
                myConnection.Dispose();
                myAdapter.Dispose();
            }
            return dt;
        }
        public int PullFromSortBucket(Guid CheckID, Guid BatchNo, int UserID, string IPAddress)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_PullFromSortBucket", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier);
            parameterCheckID.Value = CheckID;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterBatchNo = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier);
            parameterBatchNo.Value = BatchNo;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchNo);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = UserID;
            myAdapter.SelectCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.NVarChar, 50);
            parameterIPAddress.Value = IPAddress;
            myAdapter.SelectCommand.Parameters.Add(parameterIPAddress);

            int nRows = 0;

            try
            {
                myConnection.Open();
                nRows = myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                myConnection.Close();
            }
            return nRows;
        }

        public string GetNextItemSeqNo(Guid BatchID)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetNextItemSeqNo", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterBatchNo = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier);
            parameterBatchNo.Value = BatchID;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchNo);

            SqlParameter parameterItemSeqNo = new SqlParameter("@ItemSeqNo", SqlDbType.VarChar, 8);
            parameterItemSeqNo.Direction = ParameterDirection.Output;
            myAdapter.SelectCommand.Parameters.Add(parameterItemSeqNo);

            string now = "00000000" + DateTime.Now.ToBinary().ToString();
            string NextItemSeqNo = now.Substring(now.Length - 8);
            try
            {
                myConnection.Open();
                myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                NextItemSeqNo = parameterItemSeqNo.ToString();
            }
            catch (Exception e)
            {
                myConnection.Close();
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            myConnection.Dispose();
            return NextItemSeqNo;
        }


        public int MoveToSortBucket(Guid CheckID, int UserID, string IPAddress)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_MoveToSortBucket", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier);
            parameterCheckID.Value = CheckID;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = UserID;
            myAdapter.SelectCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.NVarChar, 50);
            parameterIPAddress.Value = IPAddress;
            myAdapter.SelectCommand.Parameters.Add(parameterIPAddress);

            int nRows = 0;

            try
            {
                myConnection.Open();
                nRows = myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                myConnection.Close();
            }
            return nRows;
        }


        internal void UpdateChequeAmountByChequeID(Guid CheckID, long CheckAmount)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_MizanUpdateCheckAmountByCheckID", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier);
            parameterCheckID.Value = CheckID;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterCheckAmount = new SqlParameter("@CheckAmount", SqlDbType.BigInt);
            parameterCheckAmount.Value = CheckAmount;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckAmount);

            try
            {
                myConnection.Open();
                myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                myConnection.Close();
            }
        }

        internal double GetCheckAmountByCheckID(Guid CheckID)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_MizanGetCheckAmountByCheckID", myConnection);
           

            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier);
            parameterCheckID.Value = CheckID;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckID);

            myAdapter.SelectCommand.Parameters.Add("@CheckAmount", SqlDbType.Money).Direction = ParameterDirection.Output;

            try
            {
                myConnection.Open();
                myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
                //myAdapter.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                myConnection.Dispose();
                myAdapter.Dispose();
            }
            return Convert.ToDouble(myAdapter.SelectCommand.Parameters["@CheckAmount"].Value);
        }

        internal void UpdateBenefActNameByChequeID(Guid CheckID, string BenefActNo)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_MizanUpdateBenefActNo", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier);
            parameterCheckID.Value = CheckID;
            myAdapter.SelectCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterBenefActNo = new SqlParameter("@BenefActNo", SqlDbType.VarChar, 18);
            parameterBenefActNo.Value = BenefActNo;
            myAdapter.SelectCommand.Parameters.Add(parameterBenefActNo);

            //SqlParameter parameterBenefActNo = new SqlParameter("@BenefName", SqlDbType.VarChar, 50);
            //parameterBenefActNo.Value = BenefActNo;
            //myAdapter.SelectCommand.Parameters.Add(parameterBenefActNo);

            try
            {
                myConnection.Open();
                myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                myConnection.Close();
            }
        }

       

        internal void UpdateBranchCodeAndRefNoByChequeID(Guid checkId, string branchCd, string refNo)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_MizanUpdateBranchCodeAndRefNoByChequeID", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            myAdapter.SelectCommand.Parameters.Add("@CheckID", SqlDbType.UniqueIdentifier).Value = checkId;

            myAdapter.SelectCommand.Parameters.Add("@BranchCD", SqlDbType.VarChar).Value = branchCd;

            myAdapter.SelectCommand.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = refNo;

            try
            {
                myConnection.Open();
                myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                myConnection.Close();
            }
        }
    }
}
