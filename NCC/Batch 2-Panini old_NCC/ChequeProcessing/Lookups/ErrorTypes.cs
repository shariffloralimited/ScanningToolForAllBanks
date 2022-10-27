namespace ChequeProcessing
{
    public static class ErrorTypes
    {
        public const int InvalidRoutingNo   = 1;
        public const int InvalidChequeSlNo  = 2;
        public const int InvalidAccountNo   = 4;
        public const int InvalidTransCode   = 8;

        public const int BadRoutingNo       = 16;
        public const int BadChequeSlNo      = 32;
        public const int BadAccountNo       = 64;
        public const int BadTransCode       = 128;

        public const int BadMICR            = BadRoutingNo 
                                            | BadChequeSlNo 
                                            | BadAccountNo 
                                            | BadTransCode;
        public const int InvalidMICR        = InvalidRoutingNo 
                                            | InvalidChequeSlNo 
                                            | InvalidAccountNo 
                                            | InvalidTransCode;

        public const int CheckDigitMismatch = 256;
        public const int UnknownTC          = 512;
        public const int BadImage           = 1024;
    }
}
