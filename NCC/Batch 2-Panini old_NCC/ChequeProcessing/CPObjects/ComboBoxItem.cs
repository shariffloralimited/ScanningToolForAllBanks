using System;
using System.Collections.Generic;
using System.Text;

namespace ChequeProcessing
{
    public class ComboBoxItem
    {
        string text;
        string value;

        public ComboBoxItem(string text, string value)
        {
            this.text = text;
            this.value = value;
        }

        public string Text
        {
            get
            {
                return this.text;
            }
        }

        public string Value
        {
            get
            {
                return this.value;
            }
        }
    }
}
