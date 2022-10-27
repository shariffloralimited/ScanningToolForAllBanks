using System;
using System.Collections.Generic;
using System.Text;

namespace ChequeProcessing
{
    public interface BatchTraceListener
    {
        void BatchReady(Guid BatchNo);
    }
}
