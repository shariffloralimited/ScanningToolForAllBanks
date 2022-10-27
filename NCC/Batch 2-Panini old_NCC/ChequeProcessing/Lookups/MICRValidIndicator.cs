using System;
using System.Collections.Generic;
using System.Text;

namespace ChequeProcessing
{
    public static class MICRValidIndicator
    {
        public const string GoodRead = "1",
                            GoodReadMissingField = "2",
                            ReadErrorEncountered = "3",
                            MissingFieldAndReadErrorEncountered = "4";
    }
}
