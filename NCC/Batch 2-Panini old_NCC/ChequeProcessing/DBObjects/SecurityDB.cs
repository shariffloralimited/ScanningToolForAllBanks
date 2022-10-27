using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ChequeProcessing
{
    class SecurityDB
    {
        public DataTable GetDigitalSignOptions(int DigitalSignID)
        {
            SqlConnection myConnection = new SqlConnection(Lookups.Config.ConnectionString);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CPS_GetSingleDigitalSignOption", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myAdapter.SelectCommand.CommandTimeout = 600;

            SqlParameter parameterDigitalSignID = new SqlParameter("@DigitalSignID", SqlDbType.Int);
            parameterDigitalSignID.Value = DigitalSignID;
            myAdapter.SelectCommand.Parameters.Add(parameterDigitalSignID);

            DataTable dt = new DataTable("DigitalSignID");

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
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return dt;
        }


    }
}
