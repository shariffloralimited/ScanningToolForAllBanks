using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Controls
{
    public partial class NumericField : TextBox
    {
        private int cursorPos;

        public NumericField()
        {
            InitializeComponent();
        }

        private void NumericField_KeyPress(object sender, KeyPressEventArgs e)
        {
            cursorPos = SelectionStart;
            int test = (int)e.KeyChar;
            // Ctrl + C = 3
            // Ctrl + V = 22
            if (!Char.IsDigit(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && (Keys)e.KeyChar != Keys.Delete
                && (int)e.KeyChar != 22 && (int)e.KeyChar != 3 || e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }
    }
}
