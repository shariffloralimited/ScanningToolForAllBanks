using System;
using System.Collections.Generic;
using System.Text;

namespace ChequeProcessing
{
    public interface SelectorListener
    {
        void SetSelector(RoleSelector selector);
        void ShowThis();
    }

}
