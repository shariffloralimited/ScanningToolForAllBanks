using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChequeProcessing
{
    public partial class SplashScreen : Form
    {
        private Label Label;
        private Label label1;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public SplashScreen()
        {
            InitializeComponent();
        }

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

        public void SetText(string text)
        {
            Label.Text = text;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label
            // 
            this.Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label.AutoSize = true;
            this.Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label.Location = new System.Drawing.Point(77, 41);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(41, 13);
            this.Label.TabIndex = 0;
            this.Label.Text = "label1";
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Image = global::ChequeProcessing.Properties.Resources.ASPxLoader;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 57);
            this.label1.TabIndex = 1;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(351, 95);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Label);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}