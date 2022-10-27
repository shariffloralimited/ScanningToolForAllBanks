using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace ChequeProcessing
{
    class SettingsDB
    {
        public void UpdateImageSettings(int SettingsType, int XRes, int YRes, int ImageMode, int FileType,
            int ImageWidth, int ImageHeight, string ImagePath)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("ACH_UpdateImageSettings", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterSettingsType = new SqlParameter("@SettingsType", SqlDbType.Int);
            parameterSettingsType.Value = SettingsType;
            myAdapter.SelectCommand.Parameters.Add(parameterSettingsType);

            SqlParameter parameterXRes = new SqlParameter("@XRes", SqlDbType.Int);
            parameterXRes.Value = XRes;
            myAdapter.SelectCommand.Parameters.Add(parameterXRes);

            SqlParameter parameterYRes = new SqlParameter("@YRes", SqlDbType.Int);
            parameterYRes.Value = YRes;
            myAdapter.SelectCommand.Parameters.Add(parameterYRes);

            SqlParameter parameterImageMode = new SqlParameter("@ImageMode", SqlDbType.Int);
            parameterImageMode.Value = ImageMode;
            myAdapter.SelectCommand.Parameters.Add(parameterImageMode);

            SqlParameter parameterFileType = new SqlParameter("@FileType", SqlDbType.Int);
            parameterFileType.Value = FileType;
            myAdapter.SelectCommand.Parameters.Add(parameterFileType);

            SqlParameter parameterImageHeight = new SqlParameter("@ImageHeight", SqlDbType.Int);
            parameterImageHeight.Value = ImageHeight;
            myAdapter.SelectCommand.Parameters.Add(parameterImageHeight);

            SqlParameter parameterImagePath = new SqlParameter("@ImagePath", SqlDbType.NVarChar);
            parameterImagePath.Value = ImagePath;
            myAdapter.SelectCommand.Parameters.Add(parameterImagePath);

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

        public void UpdateDepSlipSettings(int SettingsType, bool ScanDepSlips, bool SlipsBefore)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("ACH_UpdateDepSlipSettings", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterSettingsType = new SqlParameter("@SettingsType", SqlDbType.Int);
            parameterSettingsType.Value = SettingsType;
            myAdapter.SelectCommand.Parameters.Add(parameterSettingsType);

            SqlParameter parameterScanDepSlips = new SqlParameter("@ScanDepSlips", SqlDbType.Int);
            parameterScanDepSlips.Value = ScanDepSlips ? 1 : 0;
            myAdapter.SelectCommand.Parameters.Add(parameterScanDepSlips);

            SqlParameter parameterSlipsBefore = new SqlParameter("@SlipsBefore", SqlDbType.Int);
            parameterSlipsBefore.Value = SlipsBefore ? 1 : 0;
            myAdapter.SelectCommand.Parameters.Add(parameterSlipsBefore);
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

        public DataTable GetDepSlipSettings(int SettingsType)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetDepSlipSettings", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterSettingsType = new SqlParameter("@SettingsType", SqlDbType.Int);
            parameterSettingsType.Value = SettingsType;
            myAdapter.SelectCommand.Parameters.Add(parameterSettingsType);

            DataTable dt = new DataTable("DepSlipSettings");

            try
            {
                myConnection.Open();
                myAdapter.SelectCommand.ExecuteNonQuery();
                myAdapter.Fill(dt);
                myConnection.Close();
                myConnection.Dispose();
            }
            catch (Exception ex)
            {
                myConnection.Close();
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public DataTable GetImageSettings(int SettingsType)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("ACH_GetImageSettings", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterSettingsType = new SqlParameter("@SettingsType", SqlDbType.Int);
            parameterSettingsType.Value = SettingsType;
            myAdapter.SelectCommand.Parameters.Add(parameterSettingsType);

            DataTable dt = null;

            try
            {
                myConnection.Open();
                myAdapter.SelectCommand.ExecuteNonQuery();
                myAdapter.Fill(dt);
                myConnection.Close();
                myConnection.Dispose();
            }
            catch (Exception ex)
            {
                myConnection.Close();
            }
            return dt;
        }


        internal SqlDataReader GetBatchDateFromBankSettings()
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlCommand com = new SqlCommand("CPS_GetEndorseDate", myConnection);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandTimeout = 600;

            myConnection.Open();
            return com.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
