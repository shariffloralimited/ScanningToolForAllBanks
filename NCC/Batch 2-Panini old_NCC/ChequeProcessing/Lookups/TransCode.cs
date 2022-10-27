using System;
using System.Collections.Generic;
using System.Text;

namespace ChequeProcessing
{
    public static class TransCode
    {
        private static string[] validCodes;

        public static string[] ValidCodes
        {
            get {
                if (validCodes == null)
                {
                    ChequesDB db = new ChequesDB();
                    validCodes = db.GetTransCodes();
                }
                return TransCode.validCodes; }
            set { TransCode.validCodes = value; }
        }
    }
}
