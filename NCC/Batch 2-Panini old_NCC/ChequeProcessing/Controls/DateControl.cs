using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Controls
{
    public partial class DateControl : UserControl
    {
        private bool nonNumberEntered = false;
        private bool nonNumberEnteredForTextBox2 = false;
        private bool nonNumberEnteredForTextBox3 = false;

        public DateControl()
        {
            InitializeComponent();
        }

        private int calendarDate = 0;
        private int calendarMonth = 0;
        private int calendarYear = 0;
        private DateTime currentDateTime;


        public DateTime currentDate
        {
            get { return currentDateTime; }
            set { currentDateTime = value; }
        }

        private void SetDate()
        {
            if (calendarDate == 0)
            {
                MessageBox.Show("Invalid Date");
                return;
            }
            if (calendarMonth == 0)
            {
                MessageBox.Show("Invalid Month");
                return;
            }
            if (calendarYear == 0)
            {
                MessageBox.Show("Invalid Year");
                return;
            }
            currentDate = new DateTime(calendarYear, calendarMonth, calendarDate);
        }

        public void SetEnabled(bool Enabled)
        {
            if (!Enabled)
            {
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                this.BackColor = Panel.DefaultBackColor;
            }
            else
            {
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                this.BackColor = Color.White;
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEntered = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nonNumberEntered = false;
                textBox2.Focus();
            }
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                if (textBox1.Text.Length == 2)
                {
                    if (Convert.ToInt16(textBox1.Text.ToString()) > 31)
                    {
                        textBox1.Text = "31";
                    }
                    else if (Convert.ToInt16(textBox1.Text.ToString()) == 0)
                    {
                        textBox1.Text = "1";
                    }
                    textBox2.Focus();
                }
                calendarDate = Convert.ToInt16(textBox1.Text.Trim());
            }
        }
        
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEnteredForTextBox2 = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEnteredForTextBox2 = true;
                    }
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEnteredForTextBox2 == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nonNumberEnteredForTextBox2 = false;
                textBox3.Focus();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() != "")
            {
                if (textBox2.Text.Length == 2)
                {
                    if (Convert.ToInt16(textBox2.Text.ToString()) > 12)
                    {
                        textBox2.Text = "12";
                    }
                    else if (Convert.ToInt16(textBox2.Text.ToString()) == 0)
                    {
                        textBox2.Text = "1";
                    }
                    textBox3.Focus();
                }
                calendarMonth = Convert.ToInt16(textBox2.Text.Trim());
            }
        }
        
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEnteredForTextBox3 = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEnteredForTextBox3 = true;
                    }
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEnteredForTextBox3 == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nonNumberEnteredForTextBox3 = false;
                SetDate();
                MessageBox.Show(currentDate.ToString());
                textBox1.Focus();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() != "")
            {
                if (textBox3.Text.Length == 4)
                {
                    if (Convert.ToInt16(textBox3.Text.ToString()) > 3000)
                    {
                        textBox3.Text = "3000";
                    }
                    else if (Convert.ToInt16(textBox3.Text.ToString()) == 0)
                    {
                        textBox3.Text = System.DateTime.Today.Year.ToString();
                    }
                    nonNumberEnteredForTextBox3 = false;
                }
                calendarYear = Convert.ToInt16(textBox3.Text.Trim());
            }
        }
    }
}
