using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FYJ.Winform.Util;
using System.IO;
using System.Runtime.InteropServices;

namespace FYJ.Winform.Controls
{
    public partial class SkinForm : System.Windows.Forms.Form
    {
        public SkinForm()
        {
          
            this.SetStyle(
             // ControlStyles.Opaque |
              ControlStyles.UserPaint |
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.SupportsTransparentBackColor |
              ControlStyles.OptimizedDoubleBuffer
              , true);
         
            InitializeComponent();
        }

        public delegate void ColorChangedEventHandler(HSLColor hsl, Color color);
        public event ColorChangedEventHandler ColorChanged;

        public delegate void SkinFileChangedEventHandler(String filePath);
        public event SkinFileChangedEventHandler SkinFileChanged;

        public delegate void OpacityChangedEventHandler(double opacity);
        public event OpacityChangedEventHandler OpacityFileChanged;
        private PicSkin picSkin1;
      
        bool isPictureBoxEx_picActive = false;
        bool isPictureBoxEx_colorActive = true;
        void pictureBoxEx_pic_Paint(object sender, PaintEventArgs e)
        {
            if (isPictureBoxEx_picActive)
            {
                SolidBrush  brush=new SolidBrush(Color.FromArgb(83,131,168));
                e.Graphics.FillRectangle(brush, (sender as Control).ClientRectangle);
                e.Graphics.DrawImage(this.pictureBoxEx_pic.MouseNormalImage, (sender as Control).ClientRectangle);
            }
          
        }

        void pictureBoxEx_color_Paint(object sender, PaintEventArgs e)
        {
            if (isPictureBoxEx_colorActive)
            {
                SolidBrush brush = new SolidBrush(Color.FromArgb(83, 131, 168));
                e.Graphics.FillRectangle(brush, (sender as Control).ClientRectangle);
                e.Graphics.DrawImage(this.pictureBoxEx_color.MouseNormalImage, (sender as Control).ClientRectangle);
            }
        }

        void picSkin1_SkinFileChanged(string filePath)
        {
            SkinFileChanged(filePath);
        }

        void colorSkin1_ColorChanged(HSLColor hsl, Color color)
        {
            ColorChanged(hsl, color);
        }

       
        private void pictureBoxExPic_Click(object sender, EventArgs e)
        {
            this.picSkin1.Visible = true;
            this.colorSkin1.Visible = false;
            isPictureBoxEx_picActive = true;
            isPictureBoxEx_colorActive = false;
            this.pictureBoxEx_pic.Invalidate();
            this.pictureBoxEx_color.Invalidate();
        }

        private void pictureBoxExColor_Click(object sender, EventArgs e)
        {
            this.picSkin1.Visible = false;
            this.colorSkin1.Visible = true;
            isPictureBoxEx_picActive = false;
            isPictureBoxEx_colorActive = true;
            this.pictureBoxEx_pic.Invalidate();
            this.pictureBoxEx_color.Invalidate();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (picSkin1 == null)
            {
                picSkin1 = new PicSkin();
                this.picSkin1.SkinFileChanged += new PicSkin.SkinFileChangedEventHandler(picSkin1_SkinFileChanged);
                picSkin1.Size = colorSkin1.Size;
                picSkin1.Location = colorSkin1.Location;
                picSkin1.Name = "picSkin";
                if (!this.Controls.ContainsKey("picSkin"))
                {
                    this.Controls.Add(picSkin1);
                }
            }
            this.colorSkin1.ColorChanged += new ColorSkin.ColorChangedEventHandler(colorSkin1_ColorChanged);
            this.pictureBoxEx_color.Paint += new PaintEventHandler(pictureBoxEx_color_Paint);
            this.pictureBoxEx_pic.Paint += new PaintEventHandler(pictureBoxEx_pic_Paint);
            this.toolTip1.SetToolTip(this.trackBarEx1,"透明度");
            this.trackBarEx1.Value =100- (int)(MyFormTemp.DrawOpacity * 100);
        }

       

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //e.Graphics.DrawImage(global::FYJ.Winform.Properties.Resources.MainBkg, this.ClientRectangle);
            //using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, this.BackColor)))
            //{
            //    e.Graphics.FillRectangle(brush, this.ClientRectangle);
            //}
        }

        private void trackBarEx1_Scroll(object sender, EventArgs e)
        {
            if (OpacityFileChanged != null)
            {
                OpacityFileChanged((100 - this.trackBarEx1.Value) / 100.0);
            }
           
        }

        ///// <summary>
        ///// 重载窗体风格参数构建
        ///// </summary>
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //       //cp.ExStyle |= (int)Global.WS_EX_TRANSPARENT; //这个值为:0x00000020
        //        cp.ExStyle |= (int)0x00000020;
        //        return cp;
        //    }
        //}

    }
}
