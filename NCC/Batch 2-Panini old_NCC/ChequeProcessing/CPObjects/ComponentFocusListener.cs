using System;

namespace ChequeProcessing
{
    public interface ComponentFocusListener
    {
        void ComponentFocusLeave(object sender, EventArgs e);
        void ComponentFocusEnter(object sender, EventArgs e);
        void NextButtonFocus(object sender, EventArgs e);
        void ChangeGridColor(Guid chequeID);
        void AllErrorSolved();
    }
}
