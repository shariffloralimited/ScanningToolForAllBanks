using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Controls
{
    public partial class UserData : UserControl
    {
        public string UserName;
        public int AvlBatches;
        public int TotalImageError;
        public int DataEntryRequired;
        public double BatchTotal;

        public UserData()
        {
            InitializeComponent();
        }

        public void SetInfo(string UserName, int AvlBatches)
        {
            this.UserName = UserName;
            this.AvlBatches = AvlBatches;
            ShowInfo();
        }

        private void ShowInfo()
        {
            TextUser.Text = UserName;
            TextnBatch.Text = AvlBatches.ToString();
        }
    }
}