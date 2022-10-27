using System;
using System.Collections.Generic;
using System.Text;

namespace ChequeProcessing
{
    public class PasswordPolicy
    {
        public int MinPasswordLength;
        public int MinNumberOfAlphabets;
        public int MinNumberOfNumerics;
        public int MinNumberOfSpecialChars;
        public int NumberOfLastPasswordsToAvoid;
        public int MinNumberOfUpperChar;
        public int MinNumberOfLowerChar;
    }
}
