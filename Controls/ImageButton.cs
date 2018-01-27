using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FYJ.Winform.Util;

namespace FYJ.Winform.Controls
{
    [DefaultEvent("Click")]
   public class ImageButton :System.Windows.Forms.PictureBox
    {
        public ImageButton()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            //this.SetStyle(ControlStyles.ResizeRedraw, true);
            Version v = System.Environment.Version;
            //if (v.Major == 2)
            //{
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            //}
            //else
            //{
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            // }
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            //this.FlatAppearance.BorderSize = 0;
            //this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         
        }

      
        [Browsable(true)]
        public  String Text2
        {
            get;
            set;
        }

        [Browsable(true)]
        public Image DrawImage
        {
            get;
            set;
        }

       private  Font _font = new Font("宋体", 10f, FontStyle.Regular);
        [Browsable(true)]
       public Font DrawFont
       {
           get { return _font; }
           set { _font = value; }
       }
        private Brush _brush = Brushes.Black;
        [Browsable(true)]
        public Brush DrawBrush
        {
            get { return _brush; }
            set { _brush = value; }
        }
        protected bool isBorder = false;

        private Color _mouseEnterColor = Color.FromArgb(192, 192, 255);
        [Browsable(true)]
        public Color MouseEnterColor
        {
            get { return _mouseEnterColor; }
            set { _mouseEnterColor = value; }
        }

        TextImageRelation _textImageRelation = TextImageRelation.ImageAboveText;
        [Browsable(true)]
        public TextImageRelation TextImageRelation
        {
            get { return _textImageRelation; }
            set { _textImageRelation = value; }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.DoubleBuffered = false;
            if (isBorder)
            {
               // pe.Graphics.Clear(MouseEnterColor);
                Bitmap Bmp = global::FYJ.Winform.Properties.Resources.allbtn_highlight;
                Graphics g=pe.Graphics;
                g.DrawImage(Bmp, new Rectangle(0, 0, 5, 5), 0, 0, 5, 5, GraphicsUnit.Pixel);//左上角
                g.DrawImage(Bmp, new Rectangle(5, 0, this.Width-10, 5), 5, 0, Bmp.Width-10, 5, GraphicsUnit.Pixel);//上边框
                g.DrawImage(Bmp, new Rectangle(this.Width-5, 0, 5, 5), Bmp.Width-5, 0, 5,5, GraphicsUnit.Pixel);//右上角
                g.DrawImage(Bmp, new Rectangle(0, 5, 5, this.Height-10), 0, 5, 5, Bmp.Height-10, GraphicsUnit.Pixel);//左边框
                g.DrawImage(Bmp, new Rectangle(5, 5, this.Width-10, this.Height-10), 5, 5, Bmp.Width-10, Bmp.Height-10, GraphicsUnit.Pixel);//中部
                g.DrawImage(Bmp, new Rectangle(this.Width-5, 5, 5, this.Height-10), Bmp.Width-5, 5, 5, Bmp.Height-10, GraphicsUnit.Pixel);//右边框
                g.DrawImage(Bmp, new Rectangle(0,this.Height-5, 5, 5), 0,Bmp.Height-5, 5,5, GraphicsUnit.Pixel);//左下角
                g.DrawImage(Bmp, new Rectangle(5, this.Height-5, this.Width-10, 5),5, Bmp.Height-5,Bmp.Width-10, 5, GraphicsUnit.Pixel);
                g.DrawImage(Bmp, new Rectangle(this.Width-5, this.Height-5, 5, 5), Bmp.Width-5,Bmp.Height-5, 5, 5, GraphicsUnit.Pixel);
                //pe.Graphics.DrawImage(Bmp, new Rectangle(0, 0, 2, this.Height), 0, 0, 2, Bmp.Height, GraphicsUnit.Pixel);
                //pe.Graphics.DrawImage(Bmp, new Rectangle(2, 0, this.Width - 5, this.Height), 2, 0, Bmp.Width - 5, Bmp.Height, GraphicsUnit.Pixel);
                //pe.Graphics.DrawImage(Bmp, new Rectangle(this.Width - 3, 0, 3, this.Height), Bmp.Width - 3, 0, 3, Bmp.Height, GraphicsUnit.Pixel);
                Bmp.Dispose();
                
            }
            SizeF stringSize = pe.Graphics.MeasureString(Text2, DrawFont);

            if (DrawImage != null)
            {
                if (TextImageRelation == TextImageRelation.ImageAboveText)
                {
                    pe.Graphics.DrawImage(this.DrawImage, new Rectangle((this.Width - DrawImage.Width) / 2, (this.Height - DrawImage.Height - 5 - (int)(stringSize.Height)) / 2, DrawImage.Width, DrawImage.Height));
                    if (Text2 != null)
                        pe.Graphics.DrawString(Text2, DrawFont, DrawBrush, new PointF((this.Width - stringSize.Width) / 2, (this.Height - DrawImage.Height - 5 - stringSize.Height) / 2 + DrawImage.Height + 5));
                }

                if (TextImageRelation == TextImageRelation.ImageBeforeText)
                {
                    pe.Graphics.DrawImage(this.DrawImage, new Rectangle(0, ((this.Height - DrawImage.Height) / 2), DrawImage.Width, DrawImage.Height));
                    if (Text2 != null)
                        pe.Graphics.DrawString(Text2, DrawFont, DrawBrush, new PointF(DrawImage.Width + 5, (this.Height - stringSize.Height) / 2+2));
                }
            }
           
           // this.Region = new Region(new Rectangle((this.Width - DrawImage.Width) / 2, (this.Height - DrawImage.Height - 5 - (int)(stringSize.Height)) / 2, DrawImage.Width, DrawImage.Height));
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isBorder = true;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isBorder = false;
            this.Invalidate();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case 0x0014:
                    m.Result = (IntPtr)1;
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
       
    }
}
