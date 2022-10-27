using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace ChequeProcessing
{
    class BatchDB
    {
        public int InitializeData()
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_InitializeData", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            int nRows = 0;
            try
            {
                myConnection.Open();
                nRows = myAdapter.SelectCommand.ExecuteNonQuery();

                myConnection.Close();
            }
            catch (Exception e)
            {
                myConnection.Close();
            }

            myConnection.Dispose();
            myAdapter.Dispose();
            return nRows;

        }

        public int UpdateOutwardBatch(Guid BatchNo, string BatchDate, int Presentment,
            string DepRoutingNo, string CCY, string ClearingType, long BatchTotal, bool Endorsed,
            int TotalChecks, string DocumentTypeInd, bool NoCharge, int LockedBy)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_UpdateOutwardBatch", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterBatchNo = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier);
            parameterBatchNo.Value = BatchNo;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchNo);

            SqlParameter parameterBatchDate = new SqlParameter("@BatchDate", SqlDbType.VarChar, 8);
            parameterBatchDate.Value = BatchDate;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchDate);

            SqlParameter parameterPresentment = new SqlParameter("@Presentment", SqlDbType.Int);
            parameterPresentment.Value = Presentment;
            myAdapter.SelectCommand.Parameters.Add(parameterPresentment);

            SqlParameter parameterPBankRoutingNo = new SqlParameter("@PresRoutingNo", SqlDbType.NChar, 9);
            parameterPBankRoutingNo.Value = DepRoutingNo;
            myAdapter.SelectCommand.Parameters.Add(parameterPBankRoutingNo);

            myAdapter.SelectCommand.Parameters.Add("@CCY", SqlDbType.VarChar, 3).Value = CCY;

            SqlParameter parameterClearingType = new SqlParameter("@ClearingType", SqlDbType.NChar, 2);
            parameterClearingType.Value = ClearingType;
            myAdapter.SelectCommand.Parameters.Add(parameterClearingType);

            SqlParameter parameterBatchTotal = new SqlParameter("@BatchTotal", SqlDbType.BigInt);
            parameterBatchTotal.Value = BatchTotal;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchTotal);

            SqlParameter parameterEndorsed = new SqlParameter("@Endorsed", SqlDbType.Bit);
            parameterEndorsed.Value = Endorsed;
            myAdapter.SelectCommand.Parameters.Add(parameterEndorsed);

            SqlParameter parameterTotalChecks = new SqlParameter("@TotalChecks", SqlDbType.Int);
            parameterTotalChecks.Value = TotalChecks;
            myAdapter.SelectCommand.Parameters.Add(parameterTotalChecks);

            SqlParameter parameterDocumentType = new SqlParameter("@DocumentTypeInd", SqlDbType.NChar, 1);
            parameterDocumentType.Value = DocumentTypeInd;
            myAdapter.SelectCommand.Parameters.Add(parameterDocumentType);

            SqlParameter parameterNoCharge = new SqlParameter("@NoCharge", SqlDbType.Bit);
            parameterNoCharge.Value = NoCharge;
            myAdapter.SelectCommand.Parameters.Add(parameterNoCharge);

            SqlParameter parameterLockedBy = new SqlParameter("@LockedBy", SqlDbType.Int);
            parameterLockedBy.Value = LockedBy;
            myAdapter.SelectCommand.Parameters.Add(parameterLockedBy);

            int nRows = 0;
            try
            {
                myConnection.Open();
                nRows = myAdapter.SelectCommand.ExecuteNonQuery();

                myConnection.Close();
            }
            catch (Exception e)
            {
                myConnection.Close();
            }

            myConnection.Dispose();
            myAdapter.Dispose();
            return nRows;
        }

        public Guid CreateNewBatch(string BatchDate, int Presentment, string PBankRoutingNo,
            string CCY, string ClearingType, long BatchTotal, bool Endorsed, int TotalChecks,
            string DocumentTypeInd, bool NoCharge, int Creator, int LockedBy)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_CreateNewBatch", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterBatchDate = new SqlParameter("@BatchDate", SqlDbType.VarChar, 8);
            parameterBatchDate.Value = BatchDate;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchDate);

            SqlParameter parameterPresentment = new SqlParameter("@RepInd", SqlDbType.Int);
            parameterPresentment.Value = Presentment;
            myAdapter.SelectCommand.Parameters.Add(parameterPresentment);

            SqlParameter parameterPBankRoutingNo = new SqlParameter("@PresRoutingNo", SqlDbType.NChar, 9);
            parameterPBankRoutingNo.Value = PBankRoutingNo;
            myAdapter.SelectCommand.Parameters.Add(parameterPBankRoutingNo);

            SqlParameter parameterCcy = new SqlParameter("@CCY", SqlDbType.VarChar, 3);
            parameterCcy.Value = CCY;
            myAdapter.SelectCommand.Parameters.Add(parameterCcy);

            SqlParameter parameterClearingType = new SqlParameter("@ClearingType", SqlDbType.NChar, 2);
            parameterClearingType.Value = ClearingType;
            myAdapter.SelectCommand.Parameters.Add(parameterClearingType);


            SqlParameter parameterBatchTotal = new SqlParameter("@BatchTotal", SqlDbType.BigInt);
            parameterBatchTotal.Value = BatchTotal;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchTotal);

            SqlParameter parameterEndorsed = new SqlParameter("@Endorsed", SqlDbType.Bit);
            parameterEndorsed.Value = Endorsed;
            myAdapter.SelectCommand.Parameters.Add(parameterEndorsed);

            SqlParameter parameterTotalChecks = new SqlParameter("@TotalChecks", SqlDbType.Int);
            parameterTotalChecks.Value = TotalChecks;
            myAdapter.SelectCommand.Parameters.Add(parameterTotalChecks);

            SqlParameter parameterDocumentType = new SqlParameter("@DocumentTypeInd", SqlDbType.NChar, 1);
            parameterDocumentType.Value = DocumentTypeInd;
            myAdapter.SelectCommand.Parameters.Add(parameterDocumentType);

            SqlParameter parameterCreator = new SqlParameter("@Creator", SqlDbType.Int);
            parameterCreator.Value = Creator;
            myAdapter.SelectCommand.Parameters.Add(parameterCreator);

            SqlParameter parameterLockedBy = new SqlParameter("@LockedBy", SqlDbType.Int);
            parameterLockedBy.Value = LockedBy;
            myAdapter.SelectCommand.Parameters.Add(parameterLockedBy);

            SqlParameter parameterNoCharge = new SqlParameter("@NoCharge", SqlDbType.Bit);
            parameterNoCharge.Value = NoCharge;
            myAdapter.SelectCommand.Parameters.Add(parameterNoCharge);

            SqlParameter parameterBatchNo = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier);
            parameterBatchNo.Direction = ParameterDirection.Output;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchNo);

            Guid BatchID = new Guid("00000000-0000-0000-0000-000000000000");
            try
            {
                myConnection.Open();
                myAdapter.SelectCommand.ExecuteNonQuery();
                BatchID = (Guid)(parameterBatchNo.Value);

                myConnection.Close();
            }
            catch (Exception e)
            {
                myConnection.Close();
                MessageBox.Show(e.Message);
            }

            myConnection.Dispose();
            myAdapter.Dispose();
            return BatchID;
        }

        public void LockBatch(Guid BatchNo, int UserID)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_LockBatch", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = UserID;
            myAdapter.SelectCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterBatchNo = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier);
            parameterBatchNo.Value = BatchNo;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchNo);

            try
            {
                myConnection.Open();
                myAdapter.SelectCommand.ExecuteNonQuery();

                myConnection.Close();
            }
            catch (Exception e)
            {
                myConnection.Close();
                System.Windows.Forms.MessageBox.Show(e.Message);
            }

            myConnection.Dispose();
            myAdapter.Dispose();

        }

        public void UnlockBatch(Guid BatchNo)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_UnlockBatch", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterBatchNo = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier);
            parameterBatchNo.Value = BatchNo;

            myAdapter.SelectCommand.Parameters.Add(parameterBatchNo);

            try
            {
                myConnection.Open();
                myAdapter.SelectCommand.ExecuteNonQuery();

                myConnection.Close();
            }
            catch (Exception e)
            {
                myConnection.Close();
                System.Windows.Forms.MessageBox.Show(e.Message);
            }

            myConnection.Dispose();
            myAdapter.Dispose();

        }

        public BatchInfo BatchBalance(Guid BatchNo)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);
            SqlCommand myCommand = new SqlCommand("CPS_BatchBalancing", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBatchNo = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier);
            parameterBatchNo.Value = BatchNo;
            myCommand.Parameters.Add(parameterBatchNo);

            SqlParameter parameterInCheckCnt = new SqlParameter("@InCheckCnt", SqlDbType.Int);
            parameterInCheckCnt.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterInCheckCnt);

            SqlParameter parameterInBatchTotal = new SqlParameter("@InBatchTotal", SqlDbType.BigInt);
            parameterInBatchTotal.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterInBatchTotal);

            SqlParameter parameterOutCheckCnt = new SqlParameter("@OutCheckCnt", SqlDbType.Int);
            parameterOutCheckCnt.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterOutCheckCnt);

            SqlParameter parameterOutBatchTotal = new SqlParameter("@OutBatchTotal", SqlDbType.BigInt);
            parameterOutBatchTotal.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterOutBatchTotal);

            SqlParameter parameterOutBatchSendable = new SqlParameter("@OutBatchSendable", SqlDbType.BigInt);
            parameterOutBatchSendable.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterOutBatchSendable);

            BatchInfo bi = new BatchInfo();
            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();

                bi.BatchNo = BatchNo;
                bi.NTotalCheques = Convert.ToInt32(parameterInCheckCnt.Value);
                bi.NBatchTotal = Convert.ToDouble(parameterInBatchTotal.Value) / 100;
                bi.CTotalCheques = Convert.ToInt32(parameterOutCheckCnt.Value);
                bi.CBatchTotal = Convert.ToDouble(parameterOutBatchTotal.Value) / 100;

                myConnection.Close();
            }
            catch
            {
                myConnection.Close();
            }
            myConnection.Dispose();
            myCommand.Dispose();

            return bi;
        }

        public void UpdateBatchStatus(Guid BatchNo, int BatchStatus)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_UpdateBatchStatus", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterBatchNo = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier);
            parameterBatchNo.Value = BatchNo;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchNo);

            SqlParameter parameterBatchStatus = new SqlParameter("@BatchStatus", SqlDbType.Int);
            parameterBatchStatus.Value = BatchStatus;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchStatus);
            int nRows = 0;
            try
            {
                myConnection.Open();
                nRows = myAdapter.SelectCommand.ExecuteNonQuery();

                myConnection.Close();
            }
            catch (Exception e)
            {
                myConnection.Close();
                System.Windows.Forms.MessageBox.Show(e.Message);
            }

            myConnection.Dispose();
            myAdapter.Dispose();

        }

        public void SendBatch(Guid BatchNo, int UserID, string RoleCD)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_SendBatch", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterBatchNo = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier);
            parameterBatchNo.Value = BatchNo;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchNo);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = UserID;
            myAdapter.SelectCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterRoleCD = new SqlParameter("@RoleCD", SqlDbType.VarChar, 7);
            parameterRoleCD.Value = RoleCD;
            myAdapter.SelectCommand.Parameters.Add(parameterRoleCD);

            int nRows = 0;
            try
            {
                myConnection.Open();
                nRows = myAdapter.SelectCommand.ExecuteNonQuery();

                myConnection.Close();
            }
            catch (Exception e)
            {
                myConnection.Close();
                System.Windows.Forms.MessageBox.Show(e.Message);
            }

            myConnection.Dispose();
            myAdapter.Dispose();

        }

        public DataTable GetSingleBatch(Guid BatchNo, int UserID)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetSingleOutwardBatch", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterBatchNo = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier, 50);
            parameterBatchNo.Value = BatchNo;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchNo);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = UserID;
            myAdapter.SelectCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterOutIsLocked = new SqlParameter("@IsLocked", SqlDbType.Int);
            parameterOutIsLocked.Direction = ParameterDirection.Output;
            myAdapter.SelectCommand.Parameters.Add(parameterOutIsLocked);

            DataTable dt = new DataTable("GetSingleBatch");
            try
            {
                myConnection.Open();
                myAdapter.Fill(dt);
                myConnection.Close();
                if (Convert.ToInt32(parameterOutIsLocked.Value) == 1)
                {
                    dt = null;
                }
            }
            catch (Exception e)
            {
                myConnection.Close();
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            myConnection.Dispose();
            myAdapter.Dispose();
            return dt;
        }

        public DataTable GetOutwardBatchesByStatusID(int StatusID)
        {

            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetOutwardBatchesByStatusID", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterStatusID = new SqlParameter("@StatusID", SqlDbType.Int);
            parameterStatusID.Value = StatusID;
            myAdapter.SelectCommand.Parameters.Add(parameterStatusID);

            DataTable dt = new DataTable("Batches");
            try
            {
                myConnection.Open();
                myAdapter.Fill(dt);
                myConnection.Close();
            }
            catch (Exception e)
            {
                myConnection.Close();
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            myConnection.Dispose();
            myAdapter.Dispose();
            return dt;
        }

        public DataTable GetOutwardBatchesForMaker()
        {

            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetOutwardBatchesForMaker", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;


            DataTable dt = new DataTable("Batches");
            try
            {
                myConnection.Open();
                myAdapter.Fill(dt);
                myConnection.Close();
            }
            catch (Exception e)
            {
                myConnection.Close();
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            myConnection.Dispose();
            myAdapter.Dispose();
            return dt;
        }

        public double GetBatchTotal(Guid BatchNo)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetBatchTotal", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterBatchNo = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier);
            parameterBatchNo.Value = BatchNo;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchNo);

            SqlParameter parameterTotal = new SqlParameter("@Total", SqlDbType.BigInt);
            parameterTotal.Direction = ParameterDirection.Output;
            myAdapter.SelectCommand.Parameters.Add(parameterTotal);

            double Total = 0;

            try
            {
                myConnection.Open();
                myAdapter.SelectCommand.ExecuteNonQuery();

                myConnection.Close();
                Total = Convert.ToDouble(parameterTotal.Value) / 100;
            }
            catch (Exception e)
            {
                myConnection.Close();
                System.Windows.Forms.MessageBox.Show(e.Message);
            }

            myConnection.Dispose();
            myAdapter.Dispose();

            return Total;
        }

        public int GetTotalChecks(Guid BatchNo)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetTotalChecks", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterBatchNo = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier);
            parameterBatchNo.Value = BatchNo;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchNo);

            SqlParameter parameterTotalChecks = new SqlParameter("@TotalChecks", SqlDbType.Int);
            parameterTotalChecks.Direction = ParameterDirection.Output;
            myAdapter.SelectCommand.Parameters.Add(parameterTotalChecks);

            int Total = 0;

            try
            {
                myConnection.Open();
                myAdapter.SelectCommand.ExecuteNonQuery();

                myConnection.Close();
                Total = Convert.ToInt32(parameterTotalChecks.Value);
            }
            catch (Exception e)
            {
                myConnection.Close();
                System.Windows.Forms.MessageBox.Show(e.Message);
            }

            myConnection.Dispose();
            myAdapter.Dispose();

            return Total;
        }

        public int DeleteBatch(Guid BatchNo, int UserID, string IPAddress)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_DeleteBatch", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterBatchNo = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier);
            parameterBatchNo.Value = BatchNo;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchNo);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = UserID;
            myAdapter.SelectCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.VarChar, 20);
            parameterIPAddress.Value = IPAddress;
            myAdapter.SelectCommand.Parameters.Add(parameterIPAddress);

            int nRows = 0;
            try
            {
                myConnection.Open();
                nRows = myAdapter.SelectCommand.ExecuteNonQuery();

                myConnection.Close();
            }
            catch (Exception e)
            {
                myConnection.Close();
                System.Windows.Forms.MessageBox.Show(e.Message);
            }

            myConnection.Dispose();
            myAdapter.Dispose();

            return nRows;
        }


        public int GetNextBatchCount()
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetLastBatchNo", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterBatchNo = new SqlParameter("@BatchNo", SqlDbType.Int);
            parameterBatchNo.Direction = ParameterDirection.Output;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchNo);

            int LastBatchNo = 0;
            try
            {
                myConnection.Open();
                myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                LastBatchNo = Convert.ToInt32(parameterBatchNo.Value);
            }
            catch (Exception e)
            {
                myConnection.Close();
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            myConnection.Dispose();
            return LastBatchNo + 1;
        }

        public bool IsBatchEditable(Guid BatchNo, int UserID)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_IsBatchEditable", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterBatchNo = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier);
            parameterBatchNo.Value = BatchNo;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchNo);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = UserID;
            myAdapter.SelectCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterEditable = new SqlParameter("@Editable", SqlDbType.Bit);
            parameterEditable.Direction = ParameterDirection.Output;
            myAdapter.SelectCommand.Parameters.Add(parameterEditable);

            bool IsEditable = false;
            try
            {
                myConnection.Open();
                myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                IsEditable = Convert.ToBoolean(parameterEditable.Value);
            }
            catch (Exception e)
            {
                myConnection.Close();
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            myConnection.Dispose();
            return IsEditable;
        }

        public double GetOffChecksTotalAmount(Guid BatchNo)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetOffChecksTotalAmount", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterBatchNo = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier);
            parameterBatchNo.Value = BatchNo;
            myAdapter.SelectCommand.Parameters.Add(parameterBatchNo);

            SqlParameter parameterNTotalAmount = new SqlParameter("@NTotalAmount", SqlDbType.BigInt);
            parameterNTotalAmount.Direction = ParameterDirection.Output;
            myAdapter.SelectCommand.Parameters.Add(parameterNTotalAmount);

            double NTotalAmount = 0;
            try
            {
                myConnection.Open();
                myAdapter.SelectCommand.ExecuteNonQuery();
                myConnection.Close();
                NTotalAmount = Convert.ToDouble(parameterNTotalAmount.Value) / 100;
            }
            catch (Exception e)
            {
                myConnection.Close();
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            myConnection.Dispose();
            return NTotalAmount;
        }

        public DataTable GetBatchesByUserID(int UserID)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetBatchesOfAUser", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = UserID;
            myAdapter.SelectCommand.Parameters.Add(parameterUserID);

            DataTable dt = new DataTable("Batches");
            try
            {
                myConnection.Open();
                myAdapter.Fill(dt);
                myConnection.Close();
            }
            catch (Exception e)
            {
                myConnection.Close();
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            myConnection.Dispose();
            myAdapter.Dispose();
            return dt;
        }

        public DataTable GetDocumentTypes()
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetDocumentTypes", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;


            DataTable dt = new DataTable("DocumentTypes");
            try
            {
                myConnection.Open();
                myAdapter.Fill(dt);
                myConnection.Close();
            }
            catch (Exception e)
            {
                myConnection.Close();
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            myConnection.Dispose();
            myAdapter.Dispose();
            return dt;
        }
        public DataTable GetRepIndicators()
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetRepIndicators", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;


            DataTable dt = new DataTable("RepIndicator");
            try
            {
                myConnection.Open();
                myAdapter.Fill(dt);
                myConnection.Close();
            }
            catch (Exception e)
            {
                myConnection.Close();
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            myConnection.Dispose();
            myAdapter.Dispose();
            return dt;
        }

        public DataTable GetClearingTypes()
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetClearingTypes", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;


            DataTable dt = new DataTable("ClearingTypes");
            try
            {
                myConnection.Open();
                myAdapter.Fill(dt);
                myConnection.Close();
            }
            catch (Exception e)
            {
                myConnection.Close();
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            myConnection.Dispose();
            myAdapter.Dispose();
            return dt;
        }

        internal DataTable GetBatchesByUserRole(int UserID, int UserRole)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetBatchesByUserRole1", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = UserID;
            myAdapter.SelectCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterUserRole = new SqlParameter("@UserRole", SqlDbType.Int);
            parameterUserRole.Value = UserRole;
            myAdapter.SelectCommand.Parameters.Add(parameterUserRole);

            DataTable dt = new DataTable("Batches");
            try
            {
                myConnection.Open();
                myAdapter.Fill(dt);
                myConnection.Close();
            }
            catch (Exception e)
            {
                myConnection.Close();
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            myConnection.Dispose();
            myAdapter.Dispose();
            return dt;
        }

        internal MizanCalculatedBatchTotal GetCalculatedBatchTotalAndDataReqdByBatchID(Guid BatchID)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlCommand myCommand = new SqlCommand("CPS_MizanGetCalculatedBatchTotalByBatchID", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandTimeout = 600;

            SqlParameter parameterBatchID = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier);
            parameterBatchID.Value = BatchID;
            myCommand.Parameters.Add(parameterBatchID);

            myCommand.Parameters.Add("@CBatchTotal", SqlDbType.Money).Direction = ParameterDirection.Output;
            myCommand.Parameters.Add("@DataRequired", SqlDbType.SmallInt).Direction = ParameterDirection.Output;

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception e)
            {
                myConnection.Close();
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            myConnection.Dispose();
            MizanCalculatedBatchTotal c = new MizanCalculatedBatchTotal();
            c.CBatchTotal = Convert.ToDouble(myCommand.Parameters["@CBatchTotal"].Value);
            c.DataReqd = Convert.ToInt32(myCommand.Parameters["@DataRequired"].Value);

            return c;
        }
    }

    public class MizanCalculatedBatchTotal
    {
        public double CBatchTotal { get; set; }
        public int DataReqd { get; set; }
        
    }
}
