using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ChequeProcessing
{
    public partial class SplittedContainer : UserControl
    {
        ImageNavigateListener Listener;
        public SplittedContainer()
        {
            InitializeComponent();
            chequeData1.HideBenefitiaryInfo(true);

            CheckIDGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CheckIDGridView.Columns[0].FillWeight = 100;

            for (int i = 0; i < CheckIDGridView.Rows.GetRowCount(DataGridViewElementStates.Displayed); i++)
            {
                DataGridViewRow theRow = CheckIDGridView.Rows[i];
                if (i % 2 == 1)
                {
                    theRow.DefaultCellStyle.BackColor = Color.AliceBlue;
                }
            }
            FullGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FullGridView.Columns[0].FillWeight = 100;

            for (int i = 0; i < FullGridView.Rows.GetRowCount(DataGridViewElementStates.Displayed); i++)
            {
                DataGridViewRow theRow = FullGridView.Rows[i];
                if (i % 2 == 1)
                {
                    theRow.DefaultCellStyle.BackColor = Color.AliceBlue;
                }
            }
        }

        public void SetListener(ImageNavigateListener Listener)
        {
            this.Listener = Listener;
        }

        public bool LeftPanelCollapsed
        {
            set
            {
                splitContainer1.Panel1Collapsed = value;
            }
            get
            {
                return splitContainer1.Panel1Collapsed;
            }
        }

        public bool RightBottomPanelCollapsed
        {
            get
            {
                return splitContainer4.Panel2Collapsed;
            }
            set
            {
                splitContainer4.Panel2Collapsed = value;
            }
        }

        public bool LeftBottomPanelCollapsed
        {
            get
            {
                return splitContainer3.Panel2Collapsed;
            }
            set
            {
                splitContainer3.Panel2Collapsed = value;
            }
        }

        public void ReportView(bool report)
        {
            if (report)
            {
                splitContainer1.Panel2Collapsed = true;
                splitContainer3.Orientation = Orientation.Vertical;
                splitContainer3.SplitterDistance = 218;
            }
            else
            {
                splitContainer1.Panel2Collapsed = false;
                splitContainer3.Orientation = Orientation.Horizontal;
                splitContainer3.SplitterDistance = 160;
            }
        }

        private void NavigateButton_Click(object sender, EventArgs e)
        {
            if (sender == ButtonNext)
            {
                Listener.ImageNavigated(true);
            }
            else
            {
                Listener.ImageNavigated(false);
            }
        }

    }
}
