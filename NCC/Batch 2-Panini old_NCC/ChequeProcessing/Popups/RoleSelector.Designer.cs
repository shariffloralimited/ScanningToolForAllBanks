namespace ChequeProcessing
{
    partial class RoleSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoleSelector));
            this.btnChecker = new MyControls.RibsButton();
            this.btnMaker = new MyControls.RibsButton();
            this.btnScan = new MyControls.RibsButton();
            this.btnExit = new MyControls.RibsButton();
            this.SuspendLayout();
            // 
            // btnChecker
            // 
            this.btnChecker.BackColor = System.Drawing.Color.Transparent;
            this.btnChecker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChecker.Enabled = false;
            this.btnChecker.filename = null;
            this.btnChecker.FlatAppearance.BorderSize = 0;
            this.btnChecker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChecker.folder = null;
            this.btnChecker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChecker.ForeColor = System.Drawing.Color.Blue;
            this.btnChecker.Image = global::ChequeProcessing.Properties.Resources.ChequeApprove;
            this.btnChecker.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChecker.img = global::ChequeProcessing.Properties.Resources.ChequeApprove;
            this.btnChecker.img_back = ((System.Drawing.Image)(resources.GetObject("btnChecker.img_back")));
            this.btnChecker.img_click = ((System.Drawing.Image)(resources.GetObject("btnChecker.img_click")));
            this.btnChecker.img_on = ((System.Drawing.Image)(resources.GetObject("btnChecker.img_on")));
            this.btnChecker.Location = new System.Drawing.Point(292, 36);
            this.btnChecker.Name = "btnChecker";
            this.btnChecker.Size = new System.Drawing.Size(102, 83);
            this.btnChecker.TabIndex = 2;
            this.btnChecker.Text = "Checker";
            this.btnChecker.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnChecker.UseVisualStyleBackColor = false;
            this.btnChecker.Click += new System.EventHandler(this.btnChecker_Click);
            // 
            // btnMaker
            // 
            this.btnMaker.BackColor = System.Drawing.Color.Transparent;
            this.btnMaker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMaker.Enabled = false;
            this.btnMaker.filename = null;
            this.btnMaker.FlatAppearance.BorderSize = 0;
            this.btnMaker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaker.folder = null;
            this.btnMaker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaker.ForeColor = System.Drawing.Color.Blue;
            this.btnMaker.Image = global::ChequeProcessing.Properties.Resources.BatchLoad;
            this.btnMaker.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMaker.img = global::ChequeProcessing.Properties.Resources.BatchLoad;
            this.btnMaker.img_back = ((System.Drawing.Image)(resources.GetObject("btnMaker.img_back")));
            this.btnMaker.img_click = ((System.Drawing.Image)(resources.GetObject("btnMaker.img_click")));
            this.btnMaker.img_on = ((System.Drawing.Image)(resources.GetObject("btnMaker.img_on")));
            this.btnMaker.Location = new System.Drawing.Point(161, 36);
            this.btnMaker.Name = "btnMaker";
            this.btnMaker.Size = new System.Drawing.Size(102, 83);
            this.btnMaker.TabIndex = 1;
            this.btnMaker.Text = "Maker";
            this.btnMaker.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMaker.UseVisualStyleBackColor = false;
            this.btnMaker.Click += new System.EventHandler(this.btnMaker_Click);
            // 
            // btnScan
            // 
            this.btnScan.BackColor = System.Drawing.Color.Transparent;
            this.btnScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnScan.Enabled = false;
            this.btnScan.filename = null;
            this.btnScan.FlatAppearance.BorderSize = 0;
            this.btnScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScan.folder = null;
            this.btnScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScan.ForeColor = System.Drawing.Color.Blue;
            this.btnScan.Image = global::ChequeProcessing.Properties.Resources.Pause;
            this.btnScan.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnScan.img = global::ChequeProcessing.Properties.Resources.Pause;
            this.btnScan.img_back = ((System.Drawing.Image)(resources.GetObject("btnScan.img_back")));
            this.btnScan.img_click = ((System.Drawing.Image)(resources.GetObject("btnScan.img_click")));
            this.btnScan.img_on = ((System.Drawing.Image)(resources.GetObject("btnScan.img_on")));
            this.btnScan.Location = new System.Drawing.Point(32, 36);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(102, 83);
            this.btnScan.TabIndex = 0;
            this.btnScan.Text = "Scan";
            this.btnScan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnScan.UseVisualStyleBackColor = false;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.filename = null;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.folder = null;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Blue;
            this.btnExit.Image = global::ChequeProcessing.Properties.Resources.Exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.img = global::ChequeProcessing.Properties.Resources.Exit;
            this.btnExit.img_back = ((System.Drawing.Image)(resources.GetObject("btnExit.img_back")));
            this.btnExit.img_click = ((System.Drawing.Image)(resources.GetObject("btnExit.img_click")));
            this.btnExit.img_on = ((System.Drawing.Image)(resources.GetObject("btnExit.img_on")));
            this.btnExit.Location = new System.Drawing.Point(415, 36);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 83);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // RoleSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 155);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnChecker);
            this.Controls.Add(this.btnMaker);
            this.Controls.Add(this.btnScan);
            this.Name = "RoleSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RoleSelector";
            this.ResumeLayout(false);

        }

        #endregion

        private MyControls.RibsButton btnScan;
        private MyControls.RibsButton btnMaker;
        private MyControls.RibsButton btnChecker;
        private MyControls.RibsButton btnExit;
    }
}