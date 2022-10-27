namespace ChequeProcessing
{
    partial class OpenBatch
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.BatchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PresRoutingNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Locked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalChecks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClearingType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BatchID,
            this.BatchName,
            this.CCY,
            this.PresRoutingNo,
            this.BatchDate,
            this.Locked,
            this.StatusName,
            this.TotalChecks,
            this.ClearingType,
            this.BatchTotal});
            this.dataGridView1.Location = new System.Drawing.Point(15, 45);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(982, 558);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Currently available batches:";
            // 
            // ButtonOK
            // 
            this.ButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonOK.Location = new System.Drawing.Point(841, 609);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 23);
            this.ButtonOK.TabIndex = 2;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.Location = new System.Drawing.Point(922, 609);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 3;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // BatchID
            // 
            this.BatchID.DataPropertyName = "BatchID";
            this.BatchID.FillWeight = 40F;
            this.BatchID.HeaderText = "BatchID";
            this.BatchID.Name = "BatchID";
            this.BatchID.Visible = false;
            // 
            // BatchName
            // 
            this.BatchName.DataPropertyName = "BatchName";
            this.BatchName.HeaderText = "Batch Name";
            this.BatchName.Name = "BatchName";
            this.BatchName.ReadOnly = true;
            // 
            // CCY
            // 
            this.CCY.DataPropertyName = "CCY";
            this.CCY.HeaderText = "CCY";
            this.CCY.MaxInputLength = 3;
            this.CCY.Name = "CCY";
            // 
            // PresRoutingNo
            // 
            this.PresRoutingNo.DataPropertyName = "PresRoutingNo";
            this.PresRoutingNo.HeaderText = "PresRoutingNo";
            this.PresRoutingNo.Name = "PresRoutingNo";
            this.PresRoutingNo.ReadOnly = true;
            // 
            // BatchDate
            // 
            this.BatchDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.BatchDate.DataPropertyName = "BatchDate";
            this.BatchDate.HeaderText = "Batch Date";
            this.BatchDate.Name = "BatchDate";
            this.BatchDate.ReadOnly = true;
            this.BatchDate.Width = 84;
            // 
            // Locked
            // 
            this.Locked.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Locked.DataPropertyName = "LockedBy";
            this.Locked.HeaderText = "Locked By";
            this.Locked.Name = "Locked";
            this.Locked.ReadOnly = true;
            this.Locked.Width = 81;
            // 
            // StatusName
            // 
            this.StatusName.DataPropertyName = "StatusName";
            this.StatusName.HeaderText = "Batch Status";
            this.StatusName.Name = "StatusName";
            this.StatusName.ReadOnly = true;
            // 
            // TotalChecks
            // 
            this.TotalChecks.DataPropertyName = "BatchSize";
            this.TotalChecks.FillWeight = 70F;
            this.TotalChecks.HeaderText = "Total  Cheques";
            this.TotalChecks.Name = "TotalChecks";
            this.TotalChecks.ReadOnly = true;
            // 
            // ClearingType
            // 
            this.ClearingType.DataPropertyName = "ClearingType";
            this.ClearingType.FillWeight = 40F;
            this.ClearingType.HeaderText = "ClearingType";
            this.ClearingType.Name = "ClearingType";
            // 
            // BatchTotal
            // 
            this.BatchTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.BatchTotal.DataPropertyName = "BatchTotal";
            this.BatchTotal.HeaderText = "Batch Total";
            this.BatchTotal.Name = "BatchTotal";
            this.BatchTotal.ReadOnly = true;
            this.BatchTotal.Width = 85;
            // 
            // OpenBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 644);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenBatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Batch";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCY;
        private System.Windows.Forms.DataGridViewTextBoxColumn PresRoutingNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Locked;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalChecks;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClearingType;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchTotal;
    }
}