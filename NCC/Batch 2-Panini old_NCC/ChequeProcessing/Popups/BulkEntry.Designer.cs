namespace ChequeProcessing
{
    partial class BulkEntry
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LabelCustomerActNo = new System.Windows.Forms.Label();
            this.TextAmount = new Controls.CurrencyField();
            this.label10 = new System.Windows.Forms.Label();
            this.TextCustomerActNo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(412, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "* A/C No Entered will be set for all cheques in the batch";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(316, 283);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(397, 283);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LabelCustomerActNo);
            this.groupBox1.Controls.Add(this.TextAmount);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.TextCustomerActNo);
            this.groupBox1.Location = new System.Drawing.Point(48, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 164);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bulk Data Entry";
            // 
            // LabelCustomerActNo
            // 
            this.LabelCustomerActNo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LabelCustomerActNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabelCustomerActNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCustomerActNo.ForeColor = System.Drawing.SystemColors.Desktop;
            this.LabelCustomerActNo.Location = new System.Drawing.Point(57, 72);
            this.LabelCustomerActNo.Name = "LabelCustomerActNo";
            this.LabelCustomerActNo.Size = new System.Drawing.Size(138, 24);
            this.LabelCustomerActNo.TabIndex = 175;
            this.LabelCustomerActNo.Text = "Dep Act. No.";
            this.LabelCustomerActNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextAmount
            // 
            this.TextAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextAmount.Location = new System.Drawing.Point(201, 30);
            this.TextAmount.Name = "TextAmount";
            this.TextAmount.Size = new System.Drawing.Size(163, 26);
            this.TextAmount.TabIndex = 0;
            this.TextAmount.Text = "0";
            this.TextAmount.Value = "0";
            this.TextAmount.Visible = false;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label10.Location = new System.Drawing.Point(57, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 24);
            this.label10.TabIndex = 176;
            this.label10.Text = "Amount";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Visible = false;
            // 
            // TextCustomerActNo
            // 
            this.TextCustomerActNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextCustomerActNo.Location = new System.Drawing.Point(201, 70);
            this.TextCustomerActNo.Name = "TextCustomerActNo";
            this.TextCustomerActNo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextCustomerActNo.Size = new System.Drawing.Size(163, 26);
            this.TextCustomerActNo.TabIndex = 1;
            // 
            // BulkEntry
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(495, 318);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Name = "BulkEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BulkEntry";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LabelCustomerActNo;
        public Controls.CurrencyField TextAmount;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox TextCustomerActNo;

    }
}