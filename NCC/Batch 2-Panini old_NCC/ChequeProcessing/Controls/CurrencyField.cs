using System;
using System.Windows.Forms;

namespace Controls
{
    public partial class CurrencyField : TextBox
    {
        private int cursorPos;
        private int commaStart = -3;

        public CurrencyField()
        {
            InitializeComponent();
            Height = 32;
        }

        private string val;

        public string Value
        {
            get { return withoutCommas(Text); }
            set
            {
                val = withoutCommas(value);
                Text = withCommas(val);
            }
        }

        private void CurrencyField_KeyPress(object sender, KeyPressEventArgs e)
        {
            cursorPos = SelectionStart;
            int decimalPos = Text.IndexOf('.');
            int test = (int)e.KeyChar;
            // Ctrl + C = 3
            // Ctrl + V = 22
            if (!Char.IsDigit(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.'
                && (int)e.KeyChar != 22 && (int)e.KeyChar != 3)
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == '.' && decimalPos > 0){
                e.Handled = true;
                return;
            }
            if (Text.IndexOf('.') > 0 && Text.Length > decimalPos + 2
                && cursorPos > (decimalPos + 2) && (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
                return;
            }
            if (Char.IsDigit(e.KeyChar))
            {
                cursorPos = SelectionStart;
                
                if (SelectionLength > 0)
                {
                    cursorPos = SelectionStart - SelectionLength + 1;
                }
                string temp = Text;
                Text = temp.Substring(0, SelectionStart) + e.KeyChar + temp.Substring(SelectionStart+SelectionLength);
                val = withoutCommas(Text);
                Text = withCommas(val);

                if (cursorPos < 0)
                {
                    cursorPos = 0;
                }
                //if (Text.Length - cursorPos > 3 && (Text.Length - cursorPos + 1) % 2 == 0)
                //{
                //    SelectionStart = cursorPos;
                //}
                //else
                //{
                //    SelectionStart = cursorPos + 1;
                //}
                SelectionStart = cursorPos + 1;
                e.Handled = true;
            }
        }

        private void CurrencyField_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            {
                double temp;
                val = withoutCommas(Text);
                if (double.TryParse(val, out temp))
                {
                    cursorPos = SelectionStart;
                    Text = withCommas(val);
                    SelectionStart = cursorPos;

                }
                else
                {
                    Text = "";
                }
            }
            if (((Keys)e.KeyValue == Keys.Back && SelectionStart > 0) || ((Keys)e.KeyValue == Keys.Delete && SelectionStart <= Text.Length))
            {
                cursorPos = SelectionStart;
                val = withoutCommas(Text);

                Text = withCommas(val);

                SelectionStart = cursorPos;
            }
        }

        private string withoutCommas(string numText)
        {
            string retVal = String.Empty;
            int tempCurPos = cursorPos;
            for (int i = 0; i < numText.Length; i++)
            {
                if (Char.IsDigit(numText[i]) || numText[i] == '.')
                {
                    retVal = retVal + numText[i];
                }
                else if (numText[i] == ',' && tempCurPos > i)
                {
                    cursorPos--;
                }
            }
            return retVal;
        }
        private string withCommas(string numText)
        {
            string beforeDecimal = String.Empty;
            string afterDecimal = String.Empty;
            string retVal = String.Empty;
            int decimalPos = numText.IndexOf('.');

            if (numText.Length < 1)
            {
                return numText;
            }

            if (decimalPos == 0 && numText.Length == 1)
            {
                beforeDecimal = "0";
                afterDecimal = "";
            }
            else if (decimalPos == 0)
            {
                beforeDecimal = "0";
                afterDecimal = numText.Substring(1);
            }
            else if (decimalPos > 0)
            {
                afterDecimal = numText.Substring(decimalPos + 1);
                beforeDecimal = numText.Substring(0, numText.Length - afterDecimal.Length - 1);
                if (afterDecimal.Length > 2)
                {
                    afterDecimal = afterDecimal.Substring(0, 2);
                }
            }
            else
            {
                beforeDecimal = numText;
            }
            for (int i = beforeDecimal.Length - 1, j = commaStart; i  >= 0; i--, j++)
            {
                if (j >= 0 && j % 2 == 0)
                {
                    retVal = ',' + retVal;
                    if (i < cursorPos)
                    {
                        cursorPos++;
                    }
                }
                retVal = beforeDecimal[i] + retVal;
            }
            if (val.IndexOf('.') >= 0)
            {
                retVal = retVal + '.' + afterDecimal.PadRight(2, '0');
            }

            return retVal;
        }
    }
}
