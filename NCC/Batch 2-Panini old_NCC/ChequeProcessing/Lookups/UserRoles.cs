using System;
using System.Collections.Generic;
using System.Text;

namespace ChequeProcessing
{
    public static class UserRoles
    {
        public const int Scanman = 1;
        public const int BranchDataEntryMaker = 2;
        public const int ZonalDataEntryMaker = 8;
        public const int BranchDataEntryChecker = 3;
        public const int ZonalDataEntryChecker = 9;
        public const int Admin = 4;
        public const int ICEApprover = 5;
        public const int ICEChecker = 6;
        public const int ImageApprover = 7;
        public const int BEFTNMaker = 8;
        public const int BEFTNChecker = 9;
    }
}
