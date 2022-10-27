using System.Windows.Forms;
using Microsoft.Win32;

namespace ChequeProcessing
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static string rval1 = "0";
        private static string rval2 = "0";

        [System.STAThread]

        static void Main()
        {
            //Application.Run(new Form1());
            //RegistryKey rkey1 = Registry.LocalMachine.CreateSubKey("SOFTWARE").CreateSubKey(
            //    "Secure", RegistryKeyPermissionCheck.ReadWriteSubTree); ;
            //RegistryKey rkey2 = Registry.LocalMachine.CreateSubKey("SOFTWARE").CreateSubKey("Microsoft").CreateSubKey(
            //    ".NETFramework").CreateSubKey("v2.0.50727", RegistryKeyPermissionCheck.ReadWriteSubTree);
            //try
            //{
            //    rval1 = rkey1.GetValue("RSA").ToString();
            //    rval2 = rkey2.GetValue("Version").ToString();
            //}
            //catch
            //{
            //    Application.Exit();
            //}

            //if (rval1 != "2" && rval2 != "v2.0.50727")
            //{
            //    rkey1.SetValue("RSA", "");
            //    rkey1.SetValue("Version", "");

            //    Application.Exit();
            //}
            //else
            //{
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Login());
            //}
        }
    }
}
