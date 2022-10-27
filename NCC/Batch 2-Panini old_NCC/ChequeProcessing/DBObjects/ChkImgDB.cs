using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace ChequeProcessing
{
    public class ChkImgDB
    {
        public SqlDataReader ACH_GetDefectImageInfo()
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);
            SqlCommand myCommand = new SqlCommand("ACH_GetDefectImageInfo", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return result;
        }

        /// <summary>
        /// Get the Image Defect List
        /// </summary>
        /// <returns>Defect List</returns>
        public DataTable ACH_GetDefectList()
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("ACH_GetDefectList", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            DataTable dtDefectList = new DataTable();
            myConnection.Open();
            myAdapter.Fill(dtDefectList);
            myConnection.Close();
            myConnection.Dispose();
            myAdapter.Dispose();
            return dtDefectList;
        }

        public SqlDataReader ACH_GetCheckImagesByBatch(Guid BatchNo)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);
            SqlCommand myCommand = new SqlCommand("ACH_GetCheckImages", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBatchNo = new SqlParameter("@BatchID", SqlDbType.Int, 4);
            parameterBatchNo.Value = BatchNo;
            myCommand.Parameters.Add(parameterBatchNo);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return result;
        }


        public DataTable ACH_GetCheckImagesByBatchAndDate(Guid BatchNo, string dateOfCheckImage)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);
            SqlCommand myCommand = new SqlCommand("ACH_GetCheckImages", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBatchNo = new SqlParameter("@BatchID", SqlDbType.Int, 4);
            parameterBatchNo.Value = BatchNo;
            myCommand.Parameters.Add(parameterBatchNo);

            myConnection.Open();
            DataTable result = new DataTable();
            result.Load(myCommand.ExecuteReader(CommandBehavior.CloseConnection));
            return result;
        }

        public SqlDataReader ACH_GetDsApCheckImages(Guid BatchNo)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);
            SqlCommand myCommand = new SqlCommand("ACH_GetDsApCheckImages", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBatchNo = new SqlParameter("@BatchID", SqlDbType.Int, 4);
            parameterBatchNo.Value = BatchNo;
            myCommand.Parameters.Add(parameterBatchNo);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return result;
        }
        public void ACH_ApproveImage(string CheckID)
        {
            Guid CheckIDGuid = new Guid(CheckID);
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);
            SqlCommand myCommand = new SqlCommand("ACH_ApproveImage", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = CheckIDGuid;
            myCommand.Parameters.Add(parameterCheckID);



            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }

        public void ACH_DisapproveImage(string CheckID)
        {
            Guid CheckIDGuid = new Guid(CheckID);
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);
            SqlCommand myCommand = new SqlCommand("ACH_DisapproveImage", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = CheckIDGuid;
            myCommand.Parameters.Add(parameterCheckID);



            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }

        public int ACH_InsertDefectImageInfo(string CheckID, int DefectCode, int FrontBackImage)
        {
            Guid CheckIDGuid = new Guid(CheckID);
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);
            SqlCommand myCommand = new SqlCommand("ACH_InsertDefectImageInfo", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = CheckIDGuid;
            myCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterDefectCode = new SqlParameter("@DefectCode ", SqlDbType.Int, 4);
            parameterDefectCode.Value = DefectCode;
            myCommand.Parameters.Add(parameterDefectCode);

            SqlParameter parameterFrontBackImage = new SqlParameter("@FrontBackImage", SqlDbType.Int, 4);
            parameterFrontBackImage.Value = FrontBackImage;
            myCommand.Parameters.Add(parameterFrontBackImage);

            SqlParameter parameterDefectCheckID = new SqlParameter("@DefectCheckID", SqlDbType.Int, 4);
            parameterDefectCheckID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterDefectCheckID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            return (int)parameterDefectCheckID.Value;
        }
    }
}