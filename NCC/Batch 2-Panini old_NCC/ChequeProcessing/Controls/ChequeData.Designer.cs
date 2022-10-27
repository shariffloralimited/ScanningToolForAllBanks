namespace Controls
{
    partial class ChequeData
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
            this.GroupBoxChequeInfo = new System.Windows.Forms.GroupBox();
            this.chkIgnoreError = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TextActNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TextTransCode = new System.Windows.Forms.TextBox();
            this.TextRoutingNo = new System.Windows.Forms.TextBox();
            this.TextSlNo = new System.Windows.Forms.TextBox();
            this.PicBoxAmnt = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.GroupBenefitiaryInfo = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDepBranchCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRefNo = new System.Windows.Forms.TextBox();
            this.txtAccInfo = new System.Windows.Forms.TextBox();
            this.LabelCustomerActNo = new System.Windows.Forms.Label();
            this.TextCustomerActNo = new System.Windows.Forms.TextBox();
            this.GroupBoxRejectReason = new System.Windows.Forms.GroupBox();
            this.TextRejectReason = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEndorse = new System.Windows.Forms.Label();
            this.txtEndorse = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextStatus = new System.Windows.Forms.TextBox();
            this.gbxAmount = new System.Windows.Forms.GroupBox();
            this.TextAmount = new Controls.CurrencyField();
            this.GroupBoxChequeInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxAmnt)).BeginInit();
            this.GroupBenefitiaryInfo.SuspendLayout();
            this.GroupBoxRejectReason.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbxAmount.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBoxChequeInfo
            // 
            this.GroupBoxChequeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxChequeInfo.Controls.Add(this.chkIgnoreError);
            this.GroupBoxChequeInfo.Controls.Add(this.label8);
            this.GroupBoxChequeInfo.Controls.Add(this.TextActNo);
            this.GroupBoxChequeInfo.Controls.Add(this.label9);
            this.GroupBoxChequeInfo.Controls.Add(this.label4);
            this.GroupBoxChequeInfo.Controls.Add(this.label3);
            this.GroupBoxChequeInfo.Controls.Add(this.TextTransCode);
            this.GroupBoxChequeInfo.Controls.Add(this.TextRoutingNo);
            this.GroupBoxChequeInfo.Controls.Add(this.TextSlNo);
            this.GroupBoxChequeInfo.Location = new System.Drawing.Point(5, 3);
            this.GroupBoxChequeInfo.Name = "GroupBoxChequeInfo";
            this.GroupBoxChequeInfo.Size = new System.Drawing.Size(263, 139);
            this.GroupBoxChequeInfo.TabIndex = 153;
            this.GroupBoxChequeInfo.TabStop = false;
            this.GroupBoxChequeInfo.Text = "Cheque Info.";
            // 
            // chkIgnoreError
            // 
            this.chkIgnoreError.AutoSize = true;
            this.chkIgnoreError.Enabled = false;
            this.chkIgnoreError.Location = new System.Drawing.Point(123, 65);
            this.chkIgnoreError.Name = "chkIgnoreError";
            this.chkIgnoreError.Size = new System.Drawing.Size(99, 17);
            this.chkIgnoreError.TabIndex = 163;
            this.chkIgnoreError.Text = "Ignore this error";
            this.chkIgnoreError.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label8.Location = new System.Drawing.Point(6, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 20);
            this.label8.TabIndex = 158;
            this.label8.Text = "Account No";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextActNo
            // 
            this.TextActNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextActNo.Location = new System.Drawing.Point(120, 82);
            this.TextActNo.MaxLength = 13;
            this.TextActNo.Name = "TextActNo";
            this.TextActNo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextActNo.Size = new System.Drawing.Size(132, 22);
            this.TextActNo.TabIndex = 6;
            this.TextActNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextMICR_KeyPress);
            this.TextActNo.Leave += new System.EventHandler(this.MicrFocusLeave);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label9.Location = new System.Drawing.Point(6, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 20);
            this.label9.TabIndex = 158;
            this.label9.Text = "Trans Code";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 158;
            this.label4.Text = "Routing No.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(6, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 157;
            this.label3.Text = "Cheque Sl No.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextTransCode
            // 
            this.TextTransCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextTransCode.Location = new System.Drawing.Point(120, 111);
            this.TextTransCode.MaxLength = 2;
            this.TextTransCode.Name = "TextTransCode";
            this.TextTransCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextTransCode.Size = new System.Drawing.Size(132, 22);
            this.TextTransCode.TabIndex = 7;
            this.TextTransCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextMICR_KeyPress);
            this.TextTransCode.Leave += new System.EventHandler(this.MicrFocusLeave);
            // 
            // TextRoutingNo
            // 
            this.TextRoutingNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextRoutingNo.Location = new System.Drawing.Point(120, 41);
            this.TextRoutingNo.MaxLength = 9;
            this.TextRoutingNo.Name = "TextRoutingNo";
            this.TextRoutingNo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextRoutingNo.Size = new System.Drawing.Size(132, 22);
            this.TextRoutingNo.TabIndex = 5;
            this.TextRoutingNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextMICR_KeyPress);
            this.TextRoutingNo.Leave += new System.EventHandler(this.MicrFocusLeave);
            // 
            // TextSlNo
            // 
            this.TextSlNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextSlNo.Location = new System.Drawing.Point(120, 13);
            this.TextSlNo.MaxLength = 7;
            this.TextSlNo.Name = "TextSlNo";
            this.TextSlNo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextSlNo.Size = new System.Drawing.Size(132, 22);
            this.TextSlNo.TabIndex = 4;
            this.TextSlNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextMICR_KeyPress);
            this.TextSlNo.Leave += new System.EventHandler(this.MicrFocusLeave);
            // 
            // PicBoxAmnt
            // 
            this.PicBoxAmnt.Image = global::ChequeProcessing.Properties.Resources.AmountImage;
            this.PicBoxAmnt.InitialImage = null;
            this.PicBoxAmnt.Location = new System.Drawing.Point(28, 14);
            this.PicBoxAmnt.Name = "PicBoxAmnt";
            this.PicBoxAmnt.Size = new System.Drawing.Size(210, 52);
            this.PicBoxAmnt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxAmnt.TabIndex = 168;
            this.PicBoxAmnt.TabStop = false;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label10.Location = new System.Drawing.Point(6, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 24);
            this.label10.TabIndex = 158;
            this.label10.Text = "Amount";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GroupBenefitiaryInfo
            // 
            this.GroupBenefitiaryInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBenefitiaryInfo.Controls.Add(this.label6);
            this.GroupBenefitiaryInfo.Controls.Add(this.txtDepBranchCode);
            this.GroupBenefitiaryInfo.Controls.Add(this.label1);
            this.GroupBenefitiaryInfo.Controls.Add(this.txtRefNo);
            this.GroupBenefitiaryInfo.Controls.Add(this.txtAccInfo);
            this.GroupBenefitiaryInfo.Controls.Add(this.LabelCustomerActNo);
            this.GroupBenefitiaryInfo.Controls.Add(this.TextCustomerActNo);
            this.GroupBenefitiaryInfo.Location = new System.Drawing.Point(5, 253);
            this.GroupBenefitiaryInfo.Name = "GroupBenefitiaryInfo";
            this.GroupBenefitiaryInfo.Size = new System.Drawing.Size(262, 175);
            this.GroupBenefitiaryInfo.TabIndex = 152;
            this.GroupBenefitiaryInfo.TabStop = false;
            this.GroupBenefitiaryInfo.Text = "Benefitiary Info.";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(10, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 20);
            this.label6.TabIndex = 163;
            this.label6.Text = "Dep. Br. Code";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDepBranchCode
            // 
            this.txtDepBranchCode.Enabled = false;
            this.txtDepBranchCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepBranchCode.Location = new System.Drawing.Point(123, 115);
            this.txtDepBranchCode.Name = "txtDepBranchCode";
            this.txtDepBranchCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDepBranchCode.Size = new System.Drawing.Size(130, 22);
            this.txtDepBranchCode.TabIndex = 162;
            this.txtDepBranchCode.Leave += new System.EventHandler(this.ComponentFocus_Leave);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(9, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 161;
            this.label1.Text = "Reference No.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRefNo
            // 
            this.txtRefNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefNo.Location = new System.Drawing.Point(123, 144);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRefNo.Size = new System.Drawing.Size(130, 22);
            this.txtRefNo.TabIndex = 160;
            this.txtRefNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRefNo_KeyPress);
            // 
            // txtAccInfo
            // 
            this.txtAccInfo.Location = new System.Drawing.Point(9, 43);
            this.txtAccInfo.Multiline = true;
            this.txtAccInfo.Name = "txtAccInfo";
            this.txtAccInfo.ReadOnly = true;
            this.txtAccInfo.Size = new System.Drawing.Size(244, 66);
            this.txtAccInfo.TabIndex = 1;
            this.txtAccInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAccInfo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccInfo_KeyPress);
            this.txtAccInfo.Leave += new System.EventHandler(this.txtAccInfo_Leave);
            // 
            // LabelCustomerActNo
            // 
            this.LabelCustomerActNo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LabelCustomerActNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabelCustomerActNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCustomerActNo.ForeColor = System.Drawing.SystemColors.Desktop;
            this.LabelCustomerActNo.Location = new System.Drawing.Point(9, 16);
            this.LabelCustomerActNo.Name = "LabelCustomerActNo";
            this.LabelCustomerActNo.Size = new System.Drawing.Size(108, 20);
            this.LabelCustomerActNo.TabIndex = 157;
            this.LabelCustomerActNo.Text = "Dep Act. No.";
            this.LabelCustomerActNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextCustomerActNo
            // 
            this.TextCustomerActNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextCustomerActNo.Location = new System.Drawing.Point(122, 15);
            this.TextCustomerActNo.MaxLength = 13;
            this.TextCustomerActNo.Name = "TextCustomerActNo";
            this.TextCustomerActNo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextCustomerActNo.Size = new System.Drawing.Size(130, 22);
            this.TextCustomerActNo.TabIndex = 2;
            this.TextCustomerActNo.Text = "0";
            this.TextCustomerActNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextCustomerActNo_KeyPress);
            this.TextCustomerActNo.Leave += new System.EventHandler(this.ComponentFocus_Leave);
            // 
            // GroupBoxRejectReason
            // 
            this.GroupBoxRejectReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxRejectReason.Controls.Add(this.TextRejectReason);
            this.GroupBoxRejectReason.Location = new System.Drawing.Point(5, 512);
            this.GroupBoxRejectReason.Name = "GroupBoxRejectReason";
            this.GroupBoxRejectReason.Size = new System.Drawing.Size(262, 38);
            this.GroupBoxRejectReason.TabIndex = 153;
            this.GroupBoxRejectReason.TabStop = false;
            this.GroupBoxRejectReason.Text = "Reject Reason";
            this.GroupBoxRejectReason.Visible = false;
            // 
            // TextRejectReason
            // 
            this.TextRejectReason.Location = new System.Drawing.Point(8, 14);
            this.TextRejectReason.Multiline = true;
            this.TextRejectReason.Name = "TextRejectReason";
            this.TextRejectReason.Size = new System.Drawing.Size(244, 20);
            this.TextRejectReason.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblEndorse);
            this.groupBox1.Controls.Add(this.txtEndorse);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TextStatus);
            this.groupBox1.Location = new System.Drawing.Point(5, 434);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 72);
            this.groupBox1.TabIndex = 157;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cheque status";
            // 
            // lblEndorse
            // 
            this.lblEndorse.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblEndorse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEndorse.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndorse.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblEndorse.Location = new System.Drawing.Point(6, 48);
            this.lblEndorse.Name = "lblEndorse";
            this.lblEndorse.Size = new System.Drawing.Size(108, 20);
            this.lblEndorse.TabIndex = 172;
            this.lblEndorse.Text = "Endorse Text";
            this.lblEndorse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEndorse
            // 
            this.txtEndorse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndorse.Location = new System.Drawing.Point(120, 46);
            this.txtEndorse.Name = "txtEndorse";
            this.txtEndorse.ReadOnly = true;
            this.txtEndorse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEndorse.Size = new System.Drawing.Size(132, 22);
            this.txtEndorse.TabIndex = 171;
            this.txtEndorse.Leave += new System.EventHandler(this.ComponentFocus_Leave);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 172;
            this.label2.Text = "Cheque Status";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextStatus
            // 
            this.TextStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextStatus.Location = new System.Drawing.Point(119, 17);
            this.TextStatus.Name = "TextStatus";
            this.TextStatus.ReadOnly = true;
            this.TextStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextStatus.Size = new System.Drawing.Size(132, 22);
            this.TextStatus.TabIndex = 171;
            // 
            // gbxAmount
            // 
            this.gbxAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxAmount.Controls.Add(this.TextAmount);
            this.gbxAmount.Controls.Add(this.PicBoxAmnt);
            this.gbxAmount.Controls.Add(this.label10);
            this.gbxAmount.Location = new System.Drawing.Point(5, 144);
            this.gbxAmount.Name = "gbxAmount";
            this.gbxAmount.Size = new System.Drawing.Size(262, 103);
            this.gbxAmount.TabIndex = 150;
            this.gbxAmount.TabStop = false;
            this.gbxAmount.Text = "Amount Info";
            // 
            // TextAmount
            // 
            this.TextAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextAmount.Location = new System.Drawing.Point(119, 70);
            this.TextAmount.MaxLength = 20;
            this.TextAmount.Name = "TextAmount";
            this.TextAmount.Size = new System.Drawing.Size(133, 26);
            this.TextAmount.TabIndex = 169;
            this.TextAmount.Value = "";
            this.TextAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextAmount_KeyPress);
            this.TextAmount.Leave += new System.EventHandler(this.TextAmount_Leave);
            // 
            // ChequeData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxAmount);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GroupBoxRejectReason);
            this.Controls.Add(this.GroupBenefitiaryInfo);
            this.Controls.Add(this.GroupBoxChequeInfo);
            this.Name = "ChequeData";
            this.Size = new System.Drawing.Size(270, 549);
            this.GroupBoxChequeInfo.ResumeLayout(false);
            this.GroupBoxChequeInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxAmnt)).EndInit();
            this.GroupBenefitiaryInfo.ResumeLayout(false);
            this.GroupBenefitiaryInfo.PerformLayout();
            this.GroupBoxRejectReason.ResumeLayout(false);
            this.GroupBoxRejectReason.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbxAmount.ResumeLayout(false);
            this.gbxAmount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxChequeInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox GroupBenefitiaryInfo;
        private System.Windows.Forms.Label LabelCustomerActNo;
        public System.Windows.Forms.TextBox TextCustomerActNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox PicBoxAmnt;
        private System.Windows.Forms.GroupBox GroupBoxRejectReason;
        private System.Windows.Forms.TextBox TextRejectReason;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox TextStatus;
        private System.Windows.Forms.GroupBox gbxAmount;
        private System.Windows.Forms.Label lblEndorse;
        public System.Windows.Forms.TextBox txtEndorse;
        public System.Windows.Forms.CheckBox chkIgnoreError;
        public System.Windows.Forms.TextBox TextTransCode;
        public System.Windows.Forms.TextBox TextRoutingNo;
        public System.Windows.Forms.TextBox TextSlNo;
        public System.Windows.Forms.TextBox TextActNo;
        public System.Windows.Forms.TextBox txtAccInfo;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtRefNo;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtDepBranchCode;
        public CurrencyField TextAmount;

    }
}
