using System;
using System.Collections.Generic;
using System.Text;

namespace ChequeProcessing
{
    public interface ScannerRangerListener
    {
        void ChequeScanned(Cheque cheque);
        void ScanningCompleted();
        void ScanningSemiCompleted();
        void ScannerReady();
        void ShowScannerStatus(int Status);
        void ScanningStarted();
        void StartingUp();
        void CannotConnect();
    }
}
