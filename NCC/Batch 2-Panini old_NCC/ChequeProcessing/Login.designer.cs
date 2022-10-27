namespace ChequeProcessing
{
    partial class Login
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
            this.TextPassword = new System.Windows.Forms.TextBox();
            this.ButtonLogin = new System.Windows.Forms.Button();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.TextLoginID = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextPassword
            // 
            this.TextPassword.Location = new System.Drawing.Point(165, 157);
            this.TextPassword.Name = "TextPassword";
            this.TextPassword.Size = new System.Drawing.Size(130, 20);
            this.TextPassword.TabIndex = 1;
            this.TextPassword.UseSystemPasswordChar = true;
            this.TextPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextPassword_KeyPress);
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.Location = new System.Drawing.Point(156, 202);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(75, 23);
            this.ButtonLogin.TabIndex = 2;
            this.ButtonLogin.Text = "Login";
            this.ButtonLogin.UseVisualStyleBackColor = true;
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // ButtonExit
            // 
            this.ButtonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonExit.Location = new System.Drawing.Point(237, 202);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(75, 23);
            this.ButtonExit.TabIndex = 3;
            this.ButtonExit.Text = "Exit";
            this.ButtonExit.UseVisualStyleBackColor = true;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // TextLoginID
            // 
            this.TextLoginID.Location = new System.Drawing.Point(165, 131);
            this.TextLoginID.Name = "TextLoginID";
            this.TextLoginID.Size = new System.Drawing.Size(130, 20);
            this.TextLoginID.TabIndex = 0;
            this.TextLoginID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextLoginID_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 23);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(333, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "V3.20180602";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ChequeProcessing.Properties.Resources.LoginPage;
            this.ClientSize = new System.Drawing.Size(411, 239);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TextLoginID);
            this.Controls.Add(this.ButtonExit);
            this.Controls.Add(this.ButtonLogin);
            this.Controls.Add(this.TextPassword);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login to Flora Cheque Processing And Archiving System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextPassword;
        private System.Windows.Forms.Button ButtonLogin;
        private System.Windows.Forms.Button ButtonExit;
        private System.Windows.Forms.TextBox TextLoginID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}