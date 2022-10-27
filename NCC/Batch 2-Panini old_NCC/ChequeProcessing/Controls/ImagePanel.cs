using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Controls
{
    public partial class ImagePanel : UserControl
    {
        public enum ImageDisplayOrder { Horizontal, Vertical };
        public enum ImageDisplayMode { FrontOnly, BackOnly, FrontAndBack };
        private Image FrontImg;
        private Image BackImg;
        private int DisplayMode;
        private int DisplayOrder;

        public ImagePanel()
        {
            InitializeComponent();
            DisplayMode = (int)ImageDisplayMode.FrontAndBack;
            DisplayOrder = (int)ImageDisplayOrder.Horizontal;
        }

        public void ChangeDisplayOrder(int order)
        {
            DisplayOrder = order;
            if (order == (int)ImageDisplayOrder.Horizontal)
            {
                this.SplitContainerImg.Orientation = System.Windows.Forms.Orientation.Horizontal;
            }
            else
            {
                this.SplitContainerImg.Orientation = System.Windows.Forms.Orientation.Vertical;
            }
            HandleFitToWindow(PicBoxFront, true);
            HandleFitToWindow(PicBoxBack, true);
        }

        public void SetFrontImage(Image im)
        {
            FrontImg = im;
            this.PicBoxFront.Tag = FrontImg;
            if (FrontImg != null)
            {
                HandleFitToWindow(PicBoxFront, true);
            }
            else{
                PicBoxFront.Image = null;
            }
        }

        public void SetBackImage(Image im)
        {
            BackImg = im;
            this.PicBoxBack.Tag = BackImg;
            if (BackImg != null)
            {
                HandleFitToWindow(PicBoxBack, true);
            }
            else
            {
                PicBoxBack.Image = null;
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            HandleFitToWindow(PicBoxBack, true);
            HandleFitToWindow(PicBoxFront, true);
        }

        public void ChangeDisplayMode(int mode)
        {
            DisplayMode = mode;
            if (mode == (int)ImageDisplayMode.BackOnly)
            {
                SplitContainerImg.Panel1Collapsed = true;
                SplitContainerImg.Panel2Collapsed = false;
                HandleFitToWindow(PicBoxBack, true);
            }
            else if (mode == (int)ImageDisplayMode.FrontOnly)
            {
                SplitContainerImg.Panel1Collapsed = false;
                SplitContainerImg.Panel2Collapsed = true;
                HandleFitToWindow(PicBoxFront, true);
            }
            else
            {
                SplitContainerImg.Panel1Collapsed = false;
                SplitContainerImg.Panel2Collapsed = false;

                if (DisplayOrder == (int)ImageDisplayOrder.Vertical)
                {
                    SplitContainerImg.SplitterDistance = SplitContainerImg.Width / 2;
                }
                else
                {
                    SplitContainerImg.SplitterDistance = SplitContainerImg.Height / 2;
                }
                HandleFitToWindow(PicBoxFront, true);
                HandleFitToWindow(PicBoxBack, true);
            }
        }

        public void HandleFitToWindow(PictureBox picBox, bool doFit)
        {
            try
            {
                if (picBox.Tag != null)
                {
                    if (doFit)
                    {
                        Image tempImage = (Image)picBox.Tag;

                        Size fitImageSize = GetScaledImageDimension(
                            tempImage.Width, tempImage.Height, picBox.Width, picBox.Height);
                        Bitmap imgOutput = new Bitmap(tempImage, fitImageSize.Width, fitImageSize.Height);
                        picBox.Image = null;
                        picBox.SizeMode = PictureBoxSizeMode.CenterImage;
                        picBox.Image = imgOutput;
                    }

                    else
                    {
                        picBox.Image = null;
                        picBox.SizeMode = PictureBoxSizeMode.Normal;
                        picBox.Image = (Image)picBox.Tag;
                    }
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Size GetScaledImageDimension(int curImWidth, int curImHeight, int desImWidth, int desImHeight)
        {
            double scaleImageMult = 0;
            double WidthFactor = (double)desImWidth / (double)curImWidth;
            double HeightFactor = (double)desImHeight / (double)curImHeight;
                if (WidthFactor > HeightFactor)
                {
                    scaleImageMult = HeightFactor;
                }
                else
                {
                    scaleImageMult = WidthFactor;
                }
            int newWidth = (int)(curImWidth * scaleImageMult);
            int newHeight = (int)(curImHeight * scaleImageMult);
            return new Size(newWidth, newHeight);
        }

        private void SplitContainerImg_SplitterMoved(object sender, SplitterEventArgs e)
        {
            PicBoxFront.Width = SplitContainerImg.Width;
            PicBoxBack.Width = SplitContainerImg.Width;
            HandleFitToWindow(PicBoxFront, true);
            HandleFitToWindow(PicBoxBack, true);
        }

        private void ChangeModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender == backOnlyToolStripMenuItem)
            {
                ChangeDisplayMode((int)ImageDisplayMode.BackOnly);
            }
            else if (sender == frontOnlyToolStripMenuItem)
            {
                ChangeDisplayMode((int)ImageDisplayMode.FrontOnly);
            }
            else
            {
                ChangeDisplayMode((int)ImageDisplayMode.FrontAndBack);
            }
        }

        private void ChangeOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender == sideBySideToolStripMenuItem)
            {
                ChangeDisplayOrder((int)ImageDisplayOrder.Vertical);
            }
            else
            {
                ChangeDisplayOrder((int)ImageDisplayOrder.Horizontal);
            }
        }

        private void ZoomToolStripMeuItem_Click(object sender, EventArgs e)
        {
            if (sender == ZoomInToolStripMeuItem)
            {
                this.Cursor = Cursors.Cross;
            }
            else if (sender == ZoomOutToolStripMenuItem)
            {
                this.Cursor = Cursors.Hand;
            }
            else if (sender == ZoomNormalToolStripMenuItem)
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void PicBox_Click(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            if (this.Cursor == Cursors.Cross)
            {
                picBox.Dock = DockStyle.None;
                picBox.Width = (int)(picBox.Width * 1.1);
                picBox.Height = (int)(picBox.Height * 1.1);
                HandleFitToWindow(picBox, true);
            }
            else if (this.Cursor == Cursors.Hand)
            {
                picBox.Dock = DockStyle.None;
                picBox.Width = (int)(picBox.Width * .90909);
                picBox.Height = (int)(picBox.Height * .90909);
                HandleFitToWindow(picBox, true);
            }
        }

        private void FitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicBoxBack.Dock = DockStyle.Fill;
            PicBoxFront.Dock = DockStyle.Fill;
            HandleFitToWindow(PicBoxFront, true);
            HandleFitToWindow(PicBoxBack, true);
        }
    }
}
