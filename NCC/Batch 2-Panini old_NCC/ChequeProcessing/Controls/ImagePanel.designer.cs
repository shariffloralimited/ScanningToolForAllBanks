namespace Controls
{
    partial class ImagePanel
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
            this.components = new System.ComponentModel.Container();
            this.SplitContainerImg = new System.Windows.Forms.SplitContainer();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.frontOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frontBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomInToolStripMeuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomNormalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FitToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.sideBySideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upAndDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PicBoxFront = new System.Windows.Forms.PictureBox();
            this.PicBoxBack = new System.Windows.Forms.PictureBox();
            this.SplitContainerImg.Panel1.SuspendLayout();
            this.SplitContainerImg.Panel2.SuspendLayout();
            this.SplitContainerImg.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxFront)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxBack)).BeginInit();
            this.SuspendLayout();
            // 
            // SplitContainerImg
            // 
            this.SplitContainerImg.BackColor = System.Drawing.SystemColors.ControlDark;
            this.SplitContainerImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerImg.Location = new System.Drawing.Point(0, 0);
            this.SplitContainerImg.Margin = new System.Windows.Forms.Padding(10);
            this.SplitContainerImg.Name = "SplitContainerImg";
            this.SplitContainerImg.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainerImg.Panel1
            // 
            this.SplitContainerImg.Panel1.AutoScroll = true;
            this.SplitContainerImg.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.SplitContainerImg.Panel1.ContextMenuStrip = this.contextMenuStrip1;
            this.SplitContainerImg.Panel1.Controls.Add(this.PicBoxFront);
            // 
            // SplitContainerImg.Panel2
            // 
            this.SplitContainerImg.Panel2.AutoScroll = true;
            this.SplitContainerImg.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.SplitContainerImg.Panel2.ContextMenuStrip = this.contextMenuStrip1;
            this.SplitContainerImg.Panel2.Controls.Add(this.PicBoxBack);
            this.SplitContainerImg.Size = new System.Drawing.Size(624, 532);
            this.SplitContainerImg.SplitterDistance = 261;
            this.SplitContainerImg.SplitterWidth = 5;
            this.SplitContainerImg.TabIndex = 0;
            this.SplitContainerImg.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainerImg_SplitterMoved);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frontOnlyToolStripMenuItem,
            this.backOnlyToolStripMenuItem,
            this.frontBackToolStripMenuItem,
            this.zoomToolStripMenuItem,
            this.sideBySideToolStripMenuItem,
            this.upAndDownToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(158, 136);
            // 
            // frontOnlyToolStripMenuItem
            // 
            this.frontOnlyToolStripMenuItem.Name = "frontOnlyToolStripMenuItem";
            this.frontOnlyToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.frontOnlyToolStripMenuItem.Text = "Front Only";
            this.frontOnlyToolStripMenuItem.Click += new System.EventHandler(this.ChangeModeToolStripMenuItem_Click);
            // 
            // backOnlyToolStripMenuItem
            // 
            this.backOnlyToolStripMenuItem.Name = "backOnlyToolStripMenuItem";
            this.backOnlyToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.backOnlyToolStripMenuItem.Text = "Back Only";
            this.backOnlyToolStripMenuItem.Click += new System.EventHandler(this.ChangeModeToolStripMenuItem_Click);
            // 
            // frontBackToolStripMenuItem
            // 
            this.frontBackToolStripMenuItem.Name = "frontBackToolStripMenuItem";
            this.frontBackToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.frontBackToolStripMenuItem.Text = "Front and Back";
            this.frontBackToolStripMenuItem.Click += new System.EventHandler(this.ChangeModeToolStripMenuItem_Click);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZoomInToolStripMeuItem,
            this.ZoomOutToolStripMenuItem,
            this.ZoomNormalToolStripMenuItem,
            this.FitToolStripMenuItem5});
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.zoomToolStripMenuItem.Text = "Zoom";
            // 
            // ZoomInToolStripMeuItem
            // 
            this.ZoomInToolStripMeuItem.Name = "ZoomInToolStripMeuItem";
            this.ZoomInToolStripMeuItem.Size = new System.Drawing.Size(146, 22);
            this.ZoomInToolStripMeuItem.Text = "Zoom In";
            this.ZoomInToolStripMeuItem.Click += new System.EventHandler(this.ZoomToolStripMeuItem_Click);
            // 
            // ZoomOutToolStripMenuItem
            // 
            this.ZoomOutToolStripMenuItem.Name = "ZoomOutToolStripMenuItem";
            this.ZoomOutToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.ZoomOutToolStripMenuItem.Text = "Zoom Out";
            this.ZoomOutToolStripMenuItem.Click += new System.EventHandler(this.ZoomToolStripMeuItem_Click);
            // 
            // ZoomNormalToolStripMenuItem
            // 
            this.ZoomNormalToolStripMenuItem.Name = "ZoomNormalToolStripMenuItem";
            this.ZoomNormalToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.ZoomNormalToolStripMenuItem.Text = "Normal";
            this.ZoomNormalToolStripMenuItem.Click += new System.EventHandler(this.ZoomToolStripMeuItem_Click);
            // 
            // FitToolStripMenuItem5
            // 
            this.FitToolStripMenuItem5.Name = "FitToolStripMenuItem5";
            this.FitToolStripMenuItem5.Size = new System.Drawing.Size(146, 22);
            this.FitToolStripMenuItem5.Text = "Fit to Screen";
            this.FitToolStripMenuItem5.Click += new System.EventHandler(this.FitToolStripMenuItem_Click);
            // 
            // sideBySideToolStripMenuItem
            // 
            this.sideBySideToolStripMenuItem.Name = "sideBySideToolStripMenuItem";
            this.sideBySideToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.sideBySideToolStripMenuItem.Text = "Side by Side";
            this.sideBySideToolStripMenuItem.Click += new System.EventHandler(this.ChangeOrderToolStripMenuItem_Click);
            // 
            // upAndDownToolStripMenuItem
            // 
            this.upAndDownToolStripMenuItem.Name = "upAndDownToolStripMenuItem";
            this.upAndDownToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.upAndDownToolStripMenuItem.Text = "Up and Down";
            this.upAndDownToolStripMenuItem.Click += new System.EventHandler(this.ChangeOrderToolStripMenuItem_Click);
            // 
            // PicBoxFront
            // 
            this.PicBoxFront.BackColor = System.Drawing.SystemColors.Control;
            this.PicBoxFront.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicBoxFront.Location = new System.Drawing.Point(0, 0);
            this.PicBoxFront.Name = "PicBoxFront";
            this.PicBoxFront.Size = new System.Drawing.Size(624, 261);
            this.PicBoxFront.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxFront.TabIndex = 0;
            this.PicBoxFront.TabStop = false;
            this.PicBoxFront.Click += new System.EventHandler(this.PicBox_Click);
            // 
            // PicBoxBack
            // 
            this.PicBoxBack.BackColor = System.Drawing.SystemColors.Control;
            this.PicBoxBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicBoxBack.Location = new System.Drawing.Point(0, 0);
            this.PicBoxBack.Name = "PicBoxBack";
            this.PicBoxBack.Size = new System.Drawing.Size(624, 266);
            this.PicBoxBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxBack.TabIndex = 0;
            this.PicBoxBack.TabStop = false;
            this.PicBoxBack.Click += new System.EventHandler(this.PicBox_Click);
            // 
            // ImagePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SplitContainerImg);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "ImagePanel";
            this.Size = new System.Drawing.Size(624, 532);
            this.SplitContainerImg.Panel1.ResumeLayout(false);
            this.SplitContainerImg.Panel2.ResumeLayout(false);
            this.SplitContainerImg.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxFront)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainerImg;
        private System.Windows.Forms.PictureBox PicBoxFront;
        private System.Windows.Forms.PictureBox PicBoxBack;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem frontOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frontBackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZoomInToolStripMeuItem;
        private System.Windows.Forms.ToolStripMenuItem ZoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZoomNormalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FitToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem sideBySideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upAndDownToolStripMenuItem;
    }
}
