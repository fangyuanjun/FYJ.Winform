using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FYJ.Winform.Util;

namespace FYJ.Winform.Controls
{
    public partial class ColorSkin : UserControl
    {
        public ColorSkin()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }
        private Color _currentColor = Color.FromArgb(21, 160, 253);
        public delegate void ColorChangedEventHandler(HSLColor hsl, Color color);
        public event ColorChangedEventHandler ColorChanged;


        private void ChangePostion(Color color)
        {

            HSLColor hsl = new HSLColor(color);

            pictureBox_HL.SendToBack();
            label_HL.BackColor = Color.Transparent;
            label_HL.Parent = pictureBox_HL;
            label_HL.BringToFront();
            label_HL.Location = new Point(hsl.Hue > 352 ? 352 : hsl.Hue, hsl.Lightness > 0.91 ? 92 : (int)(hsl.Lightness * 100));  //最后括号重要

            pictureBox_S.SendToBack();
            label_S.BackColor = Color.Transparent;
            label_S.Parent = pictureBox_S;
            label_S.BringToFront();
            label_S.Location = new Point(hsl.Saturation > 0.96 ? 352 : (int)(hsl.Saturation * 360), 6);
            ChangeColor();

        }



        private void ChangeColor()
        {
            if (!DesignMode)
            {
                //StrongNameCodeAccessPermission.LinkDemand();
            }
            Bitmap bm = new Bitmap(360, 100);

            for (int i = 0; i < 360; i++)
            {

                for (int j = 0; j < 100; j++)
                {

                    bm.SetPixel(i, j, new HSLColor(255, i, (this.label_S.Location.X + 4) / 360.0, j / 100.0).Color);
                }

            }
            pictureBox_HL.Image = bm;



            Bitmap bm2 = new Bitmap(360, this.pictureBox_S.Size.Width);
            for (int i = 0; i < 360; i++)
            {

                for (int j = 0; j < this.pictureBox_S.Size.Width; j++)
                {
                    bm2.SetPixel(i, j, new HSLColor(255, this.label_HL.Location.X + 4, (i + 4) / 360.0, (this.label_HL.Location.Y + 4) / 100.0).Color);
                }

            }
            pictureBox_S.Image = bm2;



            HSLColor hc = new HSLColor();

            hc.Hue = this.label_HL.Location.X + 4;
            hc.Saturation = (this.label_S.Location.X + 4) / 360.0;
            hc.Lightness = (this.label_HL.Location.Y + 4) / 100.0;
            this.CurrentColor = hc.Color;
            this.CurrentHSL = hc;
            //  Bitmap image = new Bitmap("D:\\Desktop\\最小化_正常.bmp");
            //   AForge.Imaging.Filters.HueModifier filter = new AForge.Imaging.Filters.HueModifier(hc.Hue);
            //  this.pictureBox_HL.Image = filter.Apply(image);
            if (ColorChanged != null)    //极为重要！！！！
            {
                ColorChanged(hc, this.CurrentColor);            //触发事件

            }
        }

        public Color CurrentColor
        {
            get { return _currentColor; }
            set { _currentColor = value; }
        }

        public HSLColor CurrentHSL
        {
            get;
            set;
        }
        private void pictureBox_HL_MouseDown(object sender, MouseEventArgs e)
        {

            this.label_HL.Location = new Point(e.X - 4, e.Y - 4);
            // this.label2.Location = new Point(this.pictureBox1.Location.X+e.X,this.pictureBox1.Location.Y+e.Y);
            ChangeColor();
        }



        private void pictureBox_S_MouseDown(object sender, MouseEventArgs e)
        {
            this.label_S.Location = new Point(e.X - 4, e.Y - 4);
            ChangeColor();
        }

        private void ColorSkin_Load(object sender, EventArgs e)
        {
            ChangePostion(this.CurrentColor);   
        }

    }
}
