namespace ChequeProcessing
{
    partial class SendToMaker
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
            this.LabelCustomerActNo = new System.Windows.Forms.Label();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TextReason = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imagePanel1 = new Controls.ImagePanel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.LabelCustomerActNo);
            this.groupBox1.Controls.Add(this.ButtonCancel);
            this.groupBox1.Controls.Add(this.ButtonSend);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TextReason);
            this.groupBox1.Location = new System.Drawing.Point(12, 356);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(835, 64);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Return Info";
            // 
            // LabelCustomerActNo
            // 
            this.LabelCustomerActNo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LabelCustomerActNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabelCustomerActNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCustomerActNo.ForeColor = System.Drawing.SystemColors.Desktop;
            this.LabelCustomerActNo.Location = new System.Drawing.Point(6, 16);
            this.LabelCustomerActNo.Name = "LabelCustomerActNo";
            this.LabelCustomerActNo.Size = new System.Drawing.Size(103, 20);
            this.LabelCustomerActNo.TabIndex = 158;
            this.LabelCustomerActNo.Text = "Return Reason";
            this.LabelCustomerActNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(752, 34);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 7;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonSend
            // 
            this.ButtonSend.Location = new System.Drawing.Point(671, 34);
            this.ButtonSend.Name = "ButtonSend";
            this.ButtonSend.Size = new System.Drawing.Size(75, 23);
            this.ButtonSend.TabIndex = 6;
            this.ButtonSend.Text = "Send";
            this.ButtonSend.UseVisualStyleBackColor = true;
            this.ButtonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // TextReason
            // 
            this.TextReason.Location = new System.Drawing.Point(115, 16);
            this.TextReason.Multiline = true;
            this.TextReason.Name = "TextReason";
            this.TextReason.Size = new System.Drawing.Size(509, 41);
            this.TextReason.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(311, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Send this Cheque back to maker";
            // 
            // imagePanel1
            // 
            this.imagePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagePanel1.Location = new System.Drawing.Point(12, 63);
            this.imagePanel1.Margin = new System.Windows.Forms.Padding(10);
            this.imagePanel1.Name = "imagePanel1";
            this.imagePanel1.Size = new System.Drawing.Size(835, 280);
            this.imagePanel1.TabIndex = 0;
            // 
            // SendToMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 432);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imagePanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SendToMaker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send To Maker";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ImagePanel imagePanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextReason;
        private System.Windows.Forms.Label LabelCustomerActNo;
        private System.Windows.Forms.Label label2;
    }
}