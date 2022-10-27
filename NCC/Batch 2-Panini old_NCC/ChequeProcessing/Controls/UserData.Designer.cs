namespace Controls
{
    partial class UserData
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.LabelUser = new System.Windows.Forms.Label();
            this.TextUser = new System.Windows.Forms.TextBox();
            this.LabelAvlBatches = new System.Windows.Forms.Label();
            this.TextnBatch = new System.Windows.Forms.TextBox();
            this.Label = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.LabelUser);
            this.flowLayoutPanel1.Controls.Add(this.TextUser);
            this.flowLayoutPanel1.Controls.Add(this.LabelAvlBatches);
            this.flowLayoutPanel1.Controls.Add(this.TextnBatch);
            this.flowLayoutPanel1.Controls.Add(this.Label);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(283, 109);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 25);
            this.label1.TabIndex = 0;
            // 
            // LabelUser
            // 
            this.LabelUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelUser.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelUser.Location = new System.Drawing.Point(3, 28);
            this.LabelUser.Name = "LabelUser";
            this.LabelUser.Size = new System.Drawing.Size(81, 20);
            this.LabelUser.TabIndex = 12;
            this.LabelUser.Text = "Welcome ";
            this.LabelUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextUser
            // 
            this.TextUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextUser.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextUser.Location = new System.Drawing.Point(90, 28);
            this.TextUser.Name = "TextUser";
            this.TextUser.ReadOnly = true;
            this.TextUser.Size = new System.Drawing.Size(151, 20);
            this.TextUser.TabIndex = 15;
            // 
            // LabelAvlBatches
            // 
            this.LabelAvlBatches.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelAvlBatches.Location = new System.Drawing.Point(3, 51);
            this.LabelAvlBatches.Name = "LabelAvlBatches";
            this.LabelAvlBatches.Size = new System.Drawing.Size(55, 20);
            this.LabelAvlBatches.TabIndex = 13;
            this.LabelAvlBatches.Text = "You have";
            this.LabelAvlBatches.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextnBatch
            // 
            this.TextnBatch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextnBatch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextnBatch.Location = new System.Drawing.Point(64, 54);
            this.TextnBatch.Name = "TextnBatch";
            this.TextnBatch.ReadOnly = true;
            this.TextnBatch.Size = new System.Drawing.Size(36, 13);
            this.TextnBatch.TabIndex = 16;
            // 
            // Label
            // 
            this.Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label.Location = new System.Drawing.Point(106, 51);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(104, 20);
            this.Label.TabIndex = 14;
            this.Label.Text = "Batches to Process";
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UserData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UserData";
            this.Size = new System.Drawing.Size(283, 109);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabelUser;
        private System.Windows.Forms.TextBox TextUser;
        private System.Windows.Forms.Label LabelAvlBatches;
        private System.Windows.Forms.TextBox TextnBatch;
        private System.Windows.Forms.Label Label;


    }
}
