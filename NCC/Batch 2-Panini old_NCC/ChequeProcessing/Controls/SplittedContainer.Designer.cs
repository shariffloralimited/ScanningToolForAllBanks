namespace ChequeProcessing
{
    partial class SplittedContainer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplittedContainer));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CheckIDGridView = new System.Windows.Forms.DataGridView();
            this.CheckID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullGridView = new System.Windows.Forms.DataGridView();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.ButtonNext = new System.Windows.Forms.Button();
            this.ButtonPrev = new System.Windows.Forms.Button();
            this.ChequeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckSLNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoutingNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssueTransCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepositorsActNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchData1 = new Controls.BatchData();
            this.imagePanel1 = new Controls.ImagePanel();
            this.chequeData1 = new Controls.ChequeData();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckIDGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullGridView)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer1.Size = new System.Drawing.Size(1008, 555);
            this.splitContainer1.SplitterDistance = 218;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel1.Controls.Add(this.batchData1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel2.Controls.Add(this.panel1);
            this.splitContainer3.Size = new System.Drawing.Size(218, 555);
            this.splitContainer3.SplitterDistance = 158;
            this.splitContainer3.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.CheckIDGridView);
            this.panel1.Controls.Add(this.FullGridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(218, 393);
            this.panel1.TabIndex = 0;
            // 
            // CheckIDGridView
            // 
            this.CheckIDGridView.AllowUserToAddRows = false;
            this.CheckIDGridView.AllowUserToDeleteRows = false;
            this.CheckIDGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CheckIDGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CheckIDGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CheckIDGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckID});
            this.CheckIDGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckIDGridView.Location = new System.Drawing.Point(0, 0);
            this.CheckIDGridView.Name = "CheckIDGridView";
            this.CheckIDGridView.ReadOnly = true;
            this.CheckIDGridView.RowHeadersVisible = false;
            this.CheckIDGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CheckIDGridView.Size = new System.Drawing.Size(216, 391);
            this.CheckIDGridView.TabIndex = 1;
            // 
            // CheckID
            // 
            this.CheckID.HeaderText = "ChequeID";
            this.CheckID.Name = "CheckID";
            this.CheckID.ReadOnly = true;
            // 
            // FullGridView
            // 
            this.FullGridView.AllowUserToAddRows = false;
            this.FullGridView.AllowUserToDeleteRows = false;
            this.FullGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FullGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FullGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FullGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChequeID,
            this.CheckSLNo,
            this.RoutingNo,
            this.ActNo,
            this.IssueTransCode,
            this.Amount,
            this.DepositorsActNo});
            this.FullGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FullGridView.Location = new System.Drawing.Point(0, 0);
            this.FullGridView.Name = "FullGridView";
            this.FullGridView.ReadOnly = true;
            this.FullGridView.RowHeadersVisible = false;
            this.FullGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FullGridView.Size = new System.Drawing.Size(216, 391);
            this.FullGridView.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer4.Panel1.Controls.Add(this.imagePanel1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer4.Panel2.Controls.Add(this.ButtonNext);
            this.splitContainer4.Panel2.Controls.Add(this.ButtonPrev);
            this.splitContainer4.Panel2.Controls.Add(this.chequeData1);
            this.splitContainer4.Size = new System.Drawing.Size(786, 555);
            this.splitContainer4.SplitterDistance = 555;
            this.splitContainer4.TabIndex = 0;
            // 
            // ButtonNext
            // 
            this.ButtonNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ButtonNext.Location = new System.Drawing.Point(120, 519);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(75, 23);
            this.ButtonNext.TabIndex = 2;
            this.ButtonNext.Text = ">>";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.NavigateButton_Click);
            // 
            // ButtonPrev
            // 
            this.ButtonPrev.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ButtonPrev.Location = new System.Drawing.Point(39, 519);
            this.ButtonPrev.Name = "ButtonPrev";
            this.ButtonPrev.Size = new System.Drawing.Size(75, 23);
            this.ButtonPrev.TabIndex = 1;
            this.ButtonPrev.Text = "<<";
            this.ButtonPrev.UseVisualStyleBackColor = true;
            this.ButtonPrev.Click += new System.EventHandler(this.NavigateButton_Click);
            // 
            // ChequeID
            // 
            this.ChequeID.HeaderText = "ChequeID";
            this.ChequeID.Name = "ChequeID";
            this.ChequeID.ReadOnly = true;
            // 
            // CheckSLNo
            // 
            this.CheckSLNo.HeaderText = "CheckSLNo";
            this.CheckSLNo.Name = "CheckSLNo";
            this.CheckSLNo.ReadOnly = true;
            // 
            // RoutingNo
            // 
            this.RoutingNo.HeaderText = "RoutingNo";
            this.RoutingNo.Name = "RoutingNo";
            this.RoutingNo.ReadOnly = true;
            // 
            // ActNo
            // 
            this.ActNo.HeaderText = "Act No";
            this.ActNo.Name = "ActNo";
            this.ActNo.ReadOnly = true;
            // 
            // IssueTransCode
            // 
            this.IssueTransCode.HeaderText = "Transit Code";
            this.IssueTransCode.Name = "IssueTransCode";
            this.IssueTransCode.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // DepositorsActNo
            // 
            this.DepositorsActNo.HeaderText = "Depositors Act No";
            this.DepositorsActNo.Name = "DepositorsActNo";
            this.DepositorsActNo.ReadOnly = true;
            // 
            // batchData1
            // 
            this.batchData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.batchData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.batchData1.Location = new System.Drawing.Point(0, 0);
            this.batchData1.Name = "batchData1";
            this.batchData1.Size = new System.Drawing.Size(218, 158);
            this.batchData1.TabIndex = 1;
            // 
            // imagePanel1
            // 
            this.imagePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagePanel1.Location = new System.Drawing.Point(0, 0);
            this.imagePanel1.Margin = new System.Windows.Forms.Padding(10);
            this.imagePanel1.Name = "imagePanel1";
            this.imagePanel1.Size = new System.Drawing.Size(555, 555);
            this.imagePanel1.TabIndex = 4;
            // 
            // chequeData1
            // 
            this.chequeData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chequeData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chequeData1.Location = new System.Drawing.Point(0, 0);
            this.chequeData1.Name = "chequeData1";
            this.chequeData1.Size = new System.Drawing.Size(227, 555);
            this.chequeData1.TabIndex = 0;
            // 
            // SplittedContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "SplittedContainer";
            this.Size = new System.Drawing.Size(1008, 555);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CheckIDGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullGridView)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        public Controls.BatchData batchData1;
        public System.Windows.Forms.DataGridView FullGridView;
        public Controls.ChequeData chequeData1;
        public Controls.ImagePanel imagePanel1;
        private System.Windows.Forms.Button ButtonNext;
        private System.Windows.Forms.Button ButtonPrev;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckID;
        public System.Windows.Forms.DataGridView CheckIDGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckSLNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoutingNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssueTransCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepositorsActNo;
    }
}
