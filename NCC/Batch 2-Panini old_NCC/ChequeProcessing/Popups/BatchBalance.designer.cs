namespace ChequeProcessing
{
    partial class BatchBalance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchBalance));
            this.TextCBatchTotal = new System.Windows.Forms.TextBox();
            this.TextBatchTotal = new System.Windows.Forms.TextBox();
            this.TextAmtDiff = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LabelOk1 = new System.Windows.Forms.Label();
            this.LabelError1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LabelOk2 = new System.Windows.Forms.Label();
            this.LabelError2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TextChecksDiff = new System.Windows.Forms.TextBox();
            this.TextTotalChecks = new System.Windows.Forms.TextBox();
            this.TextCTotalChecks = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextCBatchTotal
            // 
            this.TextCBatchTotal.Location = new System.Drawing.Point(119, 64);
            this.TextCBatchTotal.Name = "TextCBatchTotal";
            this.TextCBatchTotal.ReadOnly = true;
            this.TextCBatchTotal.Size = new System.Drawing.Size(120, 20);
            this.TextCBatchTotal.TabIndex = 0;
            // 
            // TextBatchTotal
            // 
            this.TextBatchTotal.Location = new System.Drawing.Point(119, 29);
            this.TextBatchTotal.Name = "TextBatchTotal";
            this.TextBatchTotal.ReadOnly = true;
            this.TextBatchTotal.Size = new System.Drawing.Size(120, 20);
            this.TextBatchTotal.TabIndex = 1;
            // 
            // TextAmtDiff
            // 
            this.TextAmtDiff.Location = new System.Drawing.Point(119, 99);
            this.TextAmtDiff.Name = "TextAmtDiff";
            this.TextAmtDiff.ReadOnly = true;
            this.TextAmtDiff.Size = new System.Drawing.Size(120, 20);
            this.TextAmtDiff.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Inatial Batch Total";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Calculated BatchTotal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Difference";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(223, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Batch Balancing";
            // 
            // LabelOk1
            // 
            this.LabelOk1.Image = ((System.Drawing.Image)(resources.GetObject("LabelOk1.Image")));
            this.LabelOk1.Location = new System.Drawing.Point(245, 99);
            this.LabelOk1.Name = "LabelOk1";
            this.LabelOk1.Size = new System.Drawing.Size(21, 21);
            this.LabelOk1.TabIndex = 9;
            // 
            // LabelError1
            // 
            this.LabelError1.Image = ((System.Drawing.Image)(resources.GetObject("LabelError1.Image")));
            this.LabelError1.Location = new System.Drawing.Point(245, 99);
            this.LabelError1.Name = "LabelError1";
            this.LabelError1.Size = new System.Drawing.Size(21, 21);
            this.LabelError1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TextCBatchTotal);
            this.groupBox1.Controls.Add(this.TextBatchTotal);
            this.groupBox1.Controls.Add(this.TextAmtDiff);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.LabelError1);
            this.groupBox1.Controls.Add(this.LabelOk1);
            this.groupBox1.Location = new System.Drawing.Point(12, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 142);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Batch Total";
            // 
            // ButtonOk
            // 
            this.ButtonOk.Location = new System.Drawing.Point(512, 246);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 0;
            this.ButtonOk.Text = "Ok";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LabelOk2);
            this.groupBox2.Controls.Add(this.LabelError2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.TextChecksDiff);
            this.groupBox2.Controls.Add(this.TextTotalChecks);
            this.groupBox2.Controls.Add(this.TextCTotalChecks);
            this.groupBox2.Location = new System.Drawing.Point(293, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 142);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total Cheques";
            // 
            // LabelOk2
            // 
            this.LabelOk2.Image = ((System.Drawing.Image)(resources.GetObject("LabelOk2.Image")));
            this.LabelOk2.Location = new System.Drawing.Point(261, 98);
            this.LabelOk2.Name = "LabelOk2";
            this.LabelOk2.Size = new System.Drawing.Size(21, 21);
            this.LabelOk2.TabIndex = 25;
            // 
            // LabelError2
            // 
            this.LabelError2.Image = ((System.Drawing.Image)(resources.GetObject("LabelError2.Image")));
            this.LabelError2.Location = new System.Drawing.Point(261, 98);
            this.LabelError2.Name = "LabelError2";
            this.LabelError2.Size = new System.Drawing.Size(21, 21);
            this.LabelError2.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(70, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Difference";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Scanned Total Cheques";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Initial Total Cheques";
            // 
            // TextChecksDiff
            // 
            this.TextChecksDiff.Location = new System.Drawing.Point(132, 99);
            this.TextChecksDiff.Name = "TextChecksDiff";
            this.TextChecksDiff.ReadOnly = true;
            this.TextChecksDiff.Size = new System.Drawing.Size(120, 20);
            this.TextChecksDiff.TabIndex = 20;
            // 
            // TextTotalChecks
            // 
            this.TextTotalChecks.Location = new System.Drawing.Point(132, 29);
            this.TextTotalChecks.Name = "TextTotalChecks";
            this.TextTotalChecks.ReadOnly = true;
            this.TextTotalChecks.Size = new System.Drawing.Size(120, 20);
            this.TextTotalChecks.TabIndex = 19;
            // 
            // TextCTotalChecks
            // 
            this.TextCTotalChecks.Location = new System.Drawing.Point(132, 64);
            this.TextCTotalChecks.Name = "TextCTotalChecks";
            this.TextCTotalChecks.ReadOnly = true;
            this.TextCTotalChecks.Size = new System.Drawing.Size(120, 20);
            this.TextCTotalChecks.TabIndex = 18;
            // 
            // BatchBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 281);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BatchBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Batch Balance";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextCBatchTotal;
        private System.Windows.Forms.TextBox TextBatchTotal;
        private System.Windows.Forms.TextBox TextAmtDiff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LabelError1;
        private System.Windows.Forms.Label LabelOk1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LabelOk2;
        private System.Windows.Forms.Label LabelError2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TextChecksDiff;
        private System.Windows.Forms.TextBox TextTotalChecks;
        private System.Windows.Forms.TextBox TextCTotalChecks;
    }
}