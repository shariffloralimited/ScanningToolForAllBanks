using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace MyControls
{
    public partial class RibsButton : System.Windows.Forms.Button
    {

        //Timer
        private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

        //Images
        private Image _img_on;
        private Image _img_click;
        private Image _img_back;
        private Image _img;
        private Image _img_fad;
        private String s_folder;
        private String s_filename;

        //Fading
        bool b_fad = true;
        int i_fad = 0; //0 nothing, 1 entering, 2 leaving
        int i_value = 255; //Level of transparency

        //Constructor
        public RibsButton()
        {
            this.BackColor = Color.Transparent;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FlatAppearance.BorderSize = 0;
            this.TextAlign = ContentAlignment.BottomCenter;
            this.ImageAlign = ContentAlignment.TopCenter;
            timer1.Interval = 10;
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        //Properties
        public Image img_on
        {
            get { return _img_on; }
            set { _img_on = value; }
        }
        public Image img_click
        {
            get { return _img_click; }
            set { _img_click = value; }
        }
        public Image img_back
        {
            get { return _img_back; }
            set
            {
                _img_back = value;
            }
        }
        public Image img
        {
            get { return _img; }
            set
            {
                _img = value;
                this.Image = _img;
            }
        }
        public string folder
        {
            get { return s_folder; }
            set
            {
                if (value != null)
                {
                    if ((char)value[value.Length - 1] != '\\')
                    {
                        s_folder = value + "\\";
                    }
                    else
                    {
                        s_folder = value;
                    }
                }

            }
        }
        public string filename
        {
            get { return s_filename; }
            set
            {
                s_filename = value;

                if (s_folder != null & s_filename != null)
                {
                    _img = Image.FromFile(s_folder + s_filename);
                    this.Image = _img;
                }
            }
        }


        //Methods
        public void PaintBackground()
        {
            object _img_temp = new object();
            if (i_fad == 1)
            {
                _img_temp = _img_on.Clone();
            }
            else if (i_fad == 2)
            {
                _img_temp = _img_back.Clone();
            }
            _img_fad = (Image)_img_temp;
            Graphics _grf = Graphics.FromImage(_img_fad);
            SolidBrush brocha = new SolidBrush(Color.FromArgb(i_value, 255, 255, 255));
            _grf.FillRectangle(brocha, 0, 0, _img_fad.Width, _img_fad.Height);
            this.BackgroundImage = _img_fad;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (i_fad)
            {
                case 1:
                    {
                        if (i_value == 0)
                        {
                            i_value = 255;
                        }
                        if (i_value > -1)
                        {
                            PaintBackground();
                            i_value -= 10;
                        }
                        else
                        {
                            i_value = 0;
                            PaintBackground();
                            timer1.Stop();
                        }
                        break;
                    }
                case 2:
                    {
                        if (i_value == 0)
                        {
                            i_value = 255;
                        }
                        if (i_value > -1)
                        {
                            PaintBackground();
                            i_value -= 10;
                        }
                        else
                        {
                            i_value = 0;
                            PaintBackground();
                            timer1.Stop();
                        }
                        break;

                    }
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            if (b_fad)
            {
                i_fad = 1;
                timer1.Start();
            }
            else
            {
                this.BackgroundImage = _img_on;
            }
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            if (b_fad) { i_fad = 2; timer1.Start(); }
            else
            {
                this.BackgroundImage = _img_back;
            }
            base.OnMouseLeave(e);

        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs mevent)
        {

            this.BackgroundImage = _img_click;
            base.OnMouseDown(mevent);
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs mevent)
        {
            this.BackgroundImage = _img_on;
            base.OnMouseUp(mevent);
        }


    }
}