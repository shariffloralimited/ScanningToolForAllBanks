using System;
using System.Collections.Generic;
using System.Text;

namespace ChequeProcessing
{
    public static class ChequeStatus
    {
        public const int    AllStatus = 0,
                            JustScanned = 1,
                            ScanningComplete = 2,
                            SentToMaker = 3,
                            AmountEntered = 4,
                            Approved = 5;

        public static String GetStatus(int StatusID)
        {
            switch (StatusID)
            {
                case JustScanned:
                    return "Just Scanned";
                case ScanningComplete:
                    return "Scanning Complete";
                case AmountEntered:
                    return "Amount Entered";
                case Approved:
                    return "Approved";
                case SentToMaker:
                    return "Sent To Maker";
                default:
                    return null;
            }
        }
    }

}
