using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChequeProcessing.Popups
{
    public partial class DuplicateCheckList : Form
    {
        public DuplicateCheckList()
        {
           
        }
        public DuplicateCheckList(DataTable dt)
        {
            InitializeComponent();
            dataGridView1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
