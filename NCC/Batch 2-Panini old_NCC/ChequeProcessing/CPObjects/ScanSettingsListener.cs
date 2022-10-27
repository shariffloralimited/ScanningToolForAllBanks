using System;
using System.Collections.Generic;
using System.Text;

namespace ChequeProcessing
{
    public interface ScanSettingsListener
    {
        void SettingsChanged(int toEndorse, long seqNo);
    }
}
