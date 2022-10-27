using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Configuration;

namespace ChequeProcessing.Lookups
{
    static class Config
    {
        static string connectionString;

        public static string ConnectionString
        {
            set
            {
                connectionString = value;
            }
            get
            {
                //return ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
                return "server=" + ConfigurationManager.AppSettings[connectionString] + ";" + "Database = ACH; uid = achuser; pwd = achuser321;";
            }
        }
    }
}
