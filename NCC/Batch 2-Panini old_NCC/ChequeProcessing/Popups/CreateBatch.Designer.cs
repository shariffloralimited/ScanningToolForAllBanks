namespace ChequeProcessing
{
    partial class CreateBatch
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TextTotalChecks = new Controls.NumericField();
            this.TextBatchTotal = new Controls.CurrencyField();
            this.labelTotalCheques = new System.Windows.Forms.Label();
            this.ComboBoxPresentingBranch = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.TextBatchName = new System.Windows.Forms.TextBox();
            this.LabelBatchTotal = new System.Windows.Forms.Label();
            this.LabelDate = new System.Windows.Forms.Label();
            this.LabelBatchName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkNoCharge = new System.Windows.Forms.CheckBox();
            this.ComboBoxClearingType = new System.Windows.Forms.ComboBox();
            this.ComboBoxPrsmntLevel = new System.Windows.Forms.ComboBox();
            this.ComboBoxDocType = new System.Windows.Forms.ComboBox();
            this.LabePresLevel = new System.Windows.Forms.Label();
            this.LabelClearingHouse = new System.Windows.Forms.Label();
            this.LabelDocType = new System.Windows.Forms.Label();
            this.ButtonCreate = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CheckBoxCorpAcct = new System.Windows.Forms.CheckBox();
            this.TextCorporateAccount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbCurrency);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TextTotalChecks);
            this.groupBox1.Controls.Add(this.TextBatchTotal);
            this.groupBox1.Controls.Add(this.labelTotalCheques);
            this.groupBox1.Controls.Add(this.ComboBoxPresentingBranch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.TextBatchName);
            this.groupBox1.Controls.Add(this.LabelBatchTotal);
            this.groupBox1.Controls.Add(this.LabelDate);
            this.groupBox1.Controls.Add(this.LabelBatchName);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Info";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Items.AddRange(new object[] {
            "BDT",
            "USD",
            "GBP",
            "EUR",
            "JPY",
            "CAD"});
            this.cmbCurrency.Location = new System.Drawing.Point(501, 58);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(62, 21);
            this.cmbCurrency.TabIndex = 17;
            this.cmbCurrency.SelectedIndexChanged += new System.EventHandler(this.cmbCurrency_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(469, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Curr.";
            // 
            // TextTotalChecks
            // 
            this.TextTotalChecks.Location = new System.Drawing.Point(149, 99);
            this.TextTotalChecks.Name = "TextTotalChecks";
            this.TextTotalChecks.Size = new System.Drawing.Size(150, 20);
            this.TextTotalChecks.TabIndex = 1;
            this.TextTotalChecks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // TextBatchTotal
            // 
            this.TextBatchTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.TextBatchTotal.Location = new System.Drawing.Point(413, 99);
            this.TextBatchTotal.Name = "TextBatchTotal";
            this.TextBatchTotal.Size = new System.Drawing.Size(150, 20);
            this.TextBatchTotal.TabIndex = 2;
            this.TextBatchTotal.Value = "";
            this.TextBatchTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // labelTotalCheques
            // 
            this.labelTotalCheques.AutoSize = true;
            this.labelTotalCheques.Location = new System.Drawing.Point(42, 99);
            this.labelTotalCheques.Name = "labelTotalCheques";
            this.labelTotalCheques.Size = new System.Drawing.Size(66, 13);
            this.labelTotalCheques.TabIndex = 13;
            this.labelTotalCheques.Text = "Cheque Qty.";
            // 
            // ComboBoxPresentingBranch
            // 
            this.ComboBoxPresentingBranch.FormattingEnabled = true;
            this.ComboBoxPresentingBranch.Items.AddRange(new object[] {
            "Select..."});
            this.ComboBoxPresentingBranch.Location = new System.Drawing.Point(149, 58);
            this.ComboBoxPresentingBranch.Name = "ComboBoxPresentingBranch";
            this.ComboBoxPresentingBranch.Size = new System.Drawing.Size(314, 21);
            this.ComboBoxPresentingBranch.TabIndex = 15;
            this.ComboBoxPresentingBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Presenting Branch";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(415, 22);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(150, 20);
            this.dateTimePicker1.TabIndex = 14;
            this.dateTimePicker1.Value = new System.DateTime(2013, 12, 15, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // TextBatchName
            // 
            this.TextBatchName.BackColor = System.Drawing.Color.White;
            this.TextBatchName.Location = new System.Drawing.Point(149, 23);
            this.TextBatchName.Name = "TextBatchName";
            this.TextBatchName.ReadOnly = true;
            this.TextBatchName.Size = new System.Drawing.Size(150, 20);
            this.TextBatchName.TabIndex = 13;
            // 
            // LabelBatchTotal
            // 
            this.LabelBatchTotal.AutoSize = true;
            this.LabelBatchTotal.Location = new System.Drawing.Point(332, 99);
            this.LabelBatchTotal.Name = "LabelBatchTotal";
            this.LabelBatchTotal.Size = new System.Drawing.Size(62, 13);
            this.LabelBatchTotal.TabIndex = 13;
            this.LabelBatchTotal.Text = "Batch Total";
            // 
            // LabelDate
            // 
            this.LabelDate.AutoSize = true;
            this.LabelDate.Location = new System.Drawing.Point(318, 26);
            this.LabelDate.Name = "LabelDate";
            this.LabelDate.Size = new System.Drawing.Size(95, 13);
            this.LabelDate.TabIndex = 12;
            this.LabelDate.Text = "Endorsement Date";
            // 
            // LabelBatchName
            // 
            this.LabelBatchName.AutoSize = true;
            this.LabelBatchName.Location = new System.Drawing.Point(41, 26);
            this.LabelBatchName.Name = "LabelBatchName";
            this.LabelBatchName.Size = new System.Drawing.Size(66, 13);
            this.LabelBatchName.TabIndex = 11;
            this.LabelBatchName.Text = "Batch Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkNoCharge);
            this.groupBox2.Controls.Add(this.ComboBoxClearingType);
            this.groupBox2.Controls.Add(this.ComboBoxPrsmntLevel);
            this.groupBox2.Controls.Add(this.ComboBoxDocType);
            this.groupBox2.Controls.Add(this.LabePresLevel);
            this.groupBox2.Controls.Add(this.LabelClearingHouse);
            this.groupBox2.Controls.Add(this.LabelDocType);
            this.groupBox2.Location = new System.Drawing.Point(12, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(603, 113);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Clearing Info";
            // 
            // chkNoCharge
            // 
            this.chkNoCharge.AutoSize = true;
            this.chkNoCharge.Location = new System.Drawing.Point(394, 68);
            this.chkNoCharge.Name = "chkNoCharge";
            this.chkNoCharge.Size = new System.Drawing.Size(77, 17);
            this.chkNoCharge.TabIndex = 5;
            this.chkNoCharge.Text = "No Charge";
            this.chkNoCharge.UseVisualStyleBackColor = true;
            // 
            // ComboBoxClearingType
            // 
            this.ComboBoxClearingType.FormattingEnabled = true;
            this.ComboBoxClearingType.Location = new System.Drawing.Point(394, 28);
            this.ComboBoxClearingType.Name = "ComboBoxClearingType";
            this.ComboBoxClearingType.Size = new System.Drawing.Size(150, 21);
            this.ComboBoxClearingType.TabIndex = 4;
            this.ComboBoxClearingType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // ComboBoxPrsmntLevel
            // 
            this.ComboBoxPrsmntLevel.FormattingEnabled = true;
            this.ComboBoxPrsmntLevel.Location = new System.Drawing.Point(149, 66);
            this.ComboBoxPrsmntLevel.Name = "ComboBoxPrsmntLevel";
            this.ComboBoxPrsmntLevel.Size = new System.Drawing.Size(150, 21);
            this.ComboBoxPrsmntLevel.TabIndex = 11;
            this.ComboBoxPrsmntLevel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // ComboBoxDocType
            // 
            this.ComboBoxDocType.Enabled = false;
            this.ComboBoxDocType.FormattingEnabled = true;
            this.ComboBoxDocType.Location = new System.Drawing.Point(149, 28);
            this.ComboBoxDocType.Name = "ComboBoxDocType";
            this.ComboBoxDocType.Size = new System.Drawing.Size(150, 21);
            this.ComboBoxDocType.TabIndex = 10;
            // 
            // LabePresLevel
            // 
            this.LabePresLevel.AutoSize = true;
            this.LabePresLevel.Location = new System.Drawing.Point(41, 69);
            this.LabePresLevel.Name = "LabePresLevel";
            this.LabePresLevel.Size = new System.Drawing.Size(95, 13);
            this.LabePresLevel.TabIndex = 1;
            this.LabePresLevel.Text = "Presentment Level";
            // 
            // LabelClearingHouse
            // 
            this.LabelClearingHouse.AutoSize = true;
            this.LabelClearingHouse.Location = new System.Drawing.Point(314, 31);
            this.LabelClearingHouse.Name = "LabelClearingHouse";
            this.LabelClearingHouse.Size = new System.Drawing.Size(72, 13);
            this.LabelClearingHouse.TabIndex = 2;
            this.LabelClearingHouse.Text = "Clearing Type";
            // 
            // LabelDocType
            // 
            this.LabelDocType.AutoSize = true;
            this.LabelDocType.Location = new System.Drawing.Point(41, 31);
            this.LabelDocType.Name = "LabelDocType";
            this.LabelDocType.Size = new System.Drawing.Size(83, 13);
            this.LabelDocType.TabIndex = 0;
            this.LabelDocType.Text = "Document Type";
            // 
            // ButtonCreate
            // 
            this.ButtonCreate.Location = new System.Drawing.Point(421, 420);
            this.ButtonCreate.Name = "ButtonCreate";
            this.ButtonCreate.Size = new System.Drawing.Size(75, 23);
            this.ButtonCreate.TabIndex = 3;
            this.ButtonCreate.Text = "Ok";
            this.ButtonCreate.UseVisualStyleBackColor = true;
            this.ButtonCreate.Click += new System.EventHandler(this.ButtonCreate_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(502, 420);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 15;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CheckBoxCorpAcct);
            this.groupBox3.Controls.Add(this.TextCorporateAccount);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(13, 302);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(602, 87);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Corporate Account Info";
            this.groupBox3.Visible = false;
            // 
            // CheckBoxCorpAcct
            // 
            this.CheckBoxCorpAcct.AutoSize = true;
            this.CheckBoxCorpAcct.Location = new System.Drawing.Point(24, 23);
            this.CheckBoxCorpAcct.Name = "CheckBoxCorpAcct";
            this.CheckBoxCorpAcct.Size = new System.Drawing.Size(115, 17);
            this.CheckBoxCorpAcct.TabIndex = 17;
            this.CheckBoxCorpAcct.Text = "Corporate Account";
            this.CheckBoxCorpAcct.UseVisualStyleBackColor = true;
            this.CheckBoxCorpAcct.CheckedChanged += new System.EventHandler(this.CheckBoxCorpAcct_CheckedChanged);
            // 
            // TextCorporateAccount
            // 
            this.TextCorporateAccount.Location = new System.Drawing.Point(149, 52);
            this.TextCorporateAccount.Name = "TextCorporateAccount";
            this.TextCorporateAccount.ReadOnly = true;
            this.TextCorporateAccount.Size = new System.Drawing.Size(150, 20);
            this.TextCorporateAccount.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Account No.";
            // 
            // CreateBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(627, 455);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonCreate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateBatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Batch";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ButtonCreate;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label LabelBatchTotal;
        private System.Windows.Forms.Label LabelDate;
        private System.Windows.Forms.Label LabelBatchName;
        private System.Windows.Forms.Label LabelClearingHouse;
        private System.Windows.Forms.Label LabePresLevel;
        private System.Windows.Forms.Label LabelDocType;
        private System.Windows.Forms.TextBox TextBatchName;
        private System.Windows.Forms.ComboBox ComboBoxClearingType;
        private System.Windows.Forms.ComboBox ComboBoxPrsmntLevel;
        private System.Windows.Forms.ComboBox ComboBoxDocType;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TextCorporateAccount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CheckBoxCorpAcct;
        private System.Windows.Forms.ComboBox ComboBoxPresentingBranch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTotalCheques;
        private System.Windows.Forms.CheckBox chkNoCharge;
        private Controls.NumericField TextTotalChecks;
        private Controls.CurrencyField TextBatchTotal;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label label1;
    }
}

