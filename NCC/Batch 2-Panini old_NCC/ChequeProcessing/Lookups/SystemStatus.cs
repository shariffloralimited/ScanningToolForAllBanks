using System;
using System.Collections.Generic;
using System.Text;

namespace ChequeProcessing
{
    public static class SystemStatus
    {
        public const int NotConnected   = 0;
        public const int Connected      = 1;
        public const int Connecting     = 2;
        public const int Scanned        = 12;
        public const int Saved          = 13;
        public const int SavedAll       = 14;
        public const int ChequeNotFound = 4;
        public const int ImageError     = 5;
        public const int MICRError      = 6;
        public const int SomeError      = 8;
        public const int Alert          = 9;
        public const int Scanning       = 10;
        public const int BatchLoaded    = 111;
        public const int BatchClosed    = 112;
        public const int BatchDeleted   = 113;
        public const int BatchSent      = 114;
    }
}
