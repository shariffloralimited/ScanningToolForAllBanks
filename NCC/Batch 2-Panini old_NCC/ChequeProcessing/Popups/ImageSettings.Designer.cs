namespace ChequeProcessing
{
    partial class ImageSettings
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
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonDefault = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TextLocation = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ComboBoxImageSize = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ComboBoxYRes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboBoxXRes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboBoxFileType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboBoxImeMode = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(468, 184);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 4;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(387, 184);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 5;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonDefault
            // 
            this.ButtonDefault.Location = new System.Drawing.Point(306, 184);
            this.ButtonDefault.Name = "ButtonDefault";
            this.ButtonDefault.Size = new System.Drawing.Size(75, 23);
            this.ButtonDefault.TabIndex = 6;
            this.ButtonDefault.Text = "Default";
            this.ButtonDefault.UseVisualStyleBackColor = true;
            this.ButtonDefault.Click += new System.EventHandler(this.ButtonDefault_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TextLocation);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ComboBoxImageSize);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ComboBoxYRes);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ComboBoxXRes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ComboBoxFileType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ComboBoxImeMode);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 155);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image Properties";
            // 
            // TextLocation
            // 
            this.TextLocation.Location = new System.Drawing.Point(99, 105);
            this.TextLocation.Name = "TextLocation";
            this.TextLocation.Size = new System.Drawing.Size(150, 20);
            this.TextLocation.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Image Location:";
            // 
            // ComboBoxImageSize
            // 
            this.ComboBoxImageSize.FormattingEnabled = true;
            this.ComboBoxImageSize.Items.AddRange(new object[] {
            "Auto Detect",
            "1600 x 700 px"});
            this.ComboBoxImageSize.Location = new System.Drawing.Point(362, 105);
            this.ComboBoxImageSize.Name = "ComboBoxImageSize";
            this.ComboBoxImageSize.Size = new System.Drawing.Size(150, 21);
            this.ComboBoxImageSize.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Image Size:";
            // 
            // ComboBoxYRes
            // 
            this.ComboBoxYRes.FormattingEnabled = true;
            this.ComboBoxYRes.Items.AddRange(new object[] {
            "200 dpi",
            "300 dpi"});
            this.ComboBoxYRes.Location = new System.Drawing.Point(362, 69);
            this.ComboBoxYRes.Name = "ComboBoxYRes";
            this.ComboBoxYRes.Size = new System.Drawing.Size(150, 21);
            this.ComboBoxYRes.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Y Resolution:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "X Resolution:";
            // 
            // ComboBoxXRes
            // 
            this.ComboBoxXRes.FormattingEnabled = true;
            this.ComboBoxXRes.Items.AddRange(new object[] {
            "200 dpi",
            "300 dpi"});
            this.ComboBoxXRes.Location = new System.Drawing.Point(362, 33);
            this.ComboBoxXRes.Name = "ComboBoxXRes";
            this.ComboBoxXRes.Size = new System.Drawing.Size(150, 21);
            this.ComboBoxXRes.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "File Type:";
            // 
            // ComboBoxFileType
            // 
            this.ComboBoxFileType.FormattingEnabled = true;
            this.ComboBoxFileType.Items.AddRange(new object[] {
            "TIFF",
            "JPEG",
            "GIF",
            "BMP"});
            this.ComboBoxFileType.Location = new System.Drawing.Point(99, 69);
            this.ComboBoxFileType.Name = "ComboBoxFileType";
            this.ComboBoxFileType.Size = new System.Drawing.Size(150, 21);
            this.ComboBoxFileType.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Image Mode:";
            // 
            // ComboBoxImeMode
            // 
            this.ComboBoxImeMode.FormattingEnabled = true;
            this.ComboBoxImeMode.Items.AddRange(new object[] {
            "Binary",
            "Binary Fine",
            "Binary Photo Quality",
            "Binary Text Enhanced",
            "Grayscale (4 bit)",
            "Grayscale (8 bit)",
            "Grayscale Smoothing",
            "Color",
            "Color Smoothing"});
            this.ComboBoxImeMode.Location = new System.Drawing.Point(99, 33);
            this.ComboBoxImeMode.Name = "ComboBoxImeMode";
            this.ComboBoxImeMode.Size = new System.Drawing.Size(150, 21);
            this.ComboBoxImeMode.TabIndex = 20;
            // 
            // ImageSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 219);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ButtonDefault);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonCancel);
            this.Name = "ImageSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonDefault;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TextLocation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ComboBoxImageSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComboBoxYRes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboBoxXRes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboBoxFileType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboBoxImeMode;
    }
}