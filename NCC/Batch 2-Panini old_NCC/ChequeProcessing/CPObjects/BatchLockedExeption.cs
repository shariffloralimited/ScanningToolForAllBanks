using System;
using System.Data;
using System.Configuration;

namespace ChequeProcessing
{
    public class BatchLockedExeption : Exception
    {
        public BatchLockedExeption() :base ("This Batch is locked by some other user")
        {
            
        }
    }
}
