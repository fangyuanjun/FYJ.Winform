using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FYJ.Winform.Util;

namespace FYJ.Winform.Forms
{
    public partial class ChildForm : Form
    {
        public ChildForm()
        {
          
           

            InitializeComponent();
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
            this.BackColor = MyFormTemp.CurrentBackgroundColor;
            if (MyFormTemp.CurrentBackgroundImage != null)
            {
                this.BackgroundImage = MyFormTemp.CurrentBackgroundImage;
                if (this.Parent != null && this.Parent is Form)
                    this.BackgroundImageLayout = (this.Parent as Form).BackgroundImageLayout;
            }
           // this.TransparencyKey = this.BackColor;
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Invalidate();
        }

        #region  重载windows消息
        protected override void WndProc(ref Message m)
        {

            switch (m.Msg)
            {
                case Win32.WM_NCPAINT:
                    break;
                case Win32.WM_NCACTIVATE:
                    if (m.WParam == (IntPtr)0)
                    {
                        m.Result = (IntPtr)1;
                    }
                    if (m.WParam == (IntPtr)2097152)
                    {
                        m.Result = (IntPtr)1;
                    }
                    break;
                case Win32.WM_NCCALCSIZE:
                    break;
                case 0x00a4:
                    {
                        if (this.ContextMenuStrip != null)
                            this.ContextMenuStrip.Show(System.Windows.Forms.Control.MousePosition);
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
             base.OnPaint(e);
             Graphics g = e.Graphics;
             int titleHeight = 130;
             Bitmap Bmp = global::FYJ.Winform.Properties.Resources.main_form_bg;

             g.DrawImage(Bmp, new Rectangle(0, 0, 2, 25), 2, titleHeight + 10, 2, 25, GraphicsUnit.Pixel);
             g.DrawImage(Bmp, new Rectangle(2, 0, this.Width - 4, 25), 2, titleHeight + 10, 5, 25, GraphicsUnit.Pixel);
             g.DrawImage(Bmp, new Rectangle(this.Width - 2, 0, 2, 25), Bmp.Width - 4, titleHeight + 10, 2, 25, GraphicsUnit.Pixel);

             g.DrawImage(Bmp, new Rectangle(0, 25, 5, Height - 25), 2, titleHeight + 25, 5, Bmp.Height - 34 - 25 - titleHeight - 20, GraphicsUnit.Pixel);
             g.DrawImage(Bmp, new Rectangle(5, 25, this.Width - 10, Height - 25), 5, titleHeight + 25, Bmp.Width - 10, Bmp.Height - 34 - 25 - titleHeight - 20, GraphicsUnit.Pixel);
             g.DrawImage(Bmp, new Rectangle(this.Width - 5, 25, 5, Height - 25), Bmp.Width - 7, titleHeight + 25, 5, Bmp.Height - 34 - 25 - titleHeight - 20, GraphicsUnit.Pixel);

             Bmp.Dispose();
        }
        //protected override void DrawBackground(Graphics g)
        //{


        //}

         //后来加的 
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cParms = base.CreateParams;

        //        cParms.ExStyle |= 0x02000000;  //WS_CLIPCHILDREN
        //        return cParms;
        //    }
        //}
    }
}
