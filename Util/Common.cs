using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace FYJ.Winform.Util
{
   public class Common
    {
        /// <summary>
        /// 重绘边框(1个像素宽度)
        /// </summary>
        /// <param name="control"></param>
        /// <param name="color">颜色</param>
        public static void DrawControlBorder(Control control, Color color)
        {
            Graphics g = control.CreateGraphics();
            Pen pen = new Pen(color, 1);
            g.DrawLine(pen, new Point(0, 0), new Point(control.Width-1, 0));  //上边框
            g.DrawLine(pen, new Point(0, control.Height - 1), new Point(control.Width-1, control.Height - 1));  //下边框
            g.DrawLine(pen, new Point(0, 0), new Point(0, control.Height-1));  //左边框
            //右边框  因为有些没有画右边框 所以有影响
            g.DrawLine(pen, new Point(control.Width - 1, 0), new Point(control.Width - 1, control.Height-1));  //右边框
        }


        #region  画边框
        public static void DrawBorder(Control c, Graphics g, Color color)
        {
           
            if (c is Form)
            {
              //  ((Form)c).TransparencyKey = Color.FromArgb(255, 0, 255);
            }

            Pen borderPen = new Pen(color, 1);
            Pen transPen = new Pen(Color.FromArgb(255, 0, 255), 1);   //画透明部分的画笔
            // Pen transBorderPen = new Pen(Color.FromArgb(157,155,175),1);  //四个边角线
            Pen transBorderPen = borderPen;   //边角线   暂时与边框线相同吧

            int w = (int)borderPen.Width;
            g.DrawLine(borderPen, new Point(0, 0), new Point(c.Width, 0));  //上边框
            g.DrawLine(borderPen, new Point(0, c.Height - w), new Point(c.Width, c.Height - w));  //下边框
            g.DrawLine(borderPen, new Point(0, 0), new Point(0, c.Height));  //左边框
            g.DrawLine(borderPen, new Point(c.Width - w, 0), new Point(c.Width - w, c.Height));  //右边框

            //渐变
            //    LinearGradientBrush linGrBrush = new LinearGradientBrush(
            //  new Point(0, 10),
            // new Point(200, 10),
            //Color.FromArgb(255, 255, 0, 0),  // Opaque red
            //  Color.FromArgb(255, 0, 0, 255)); // Opaque blue

            //    Pen pen = new Pen(linGrBrush);

            //    g.DrawLine(pen, 0, 10, 200, 10);



            GraphicsPath transPath_左下角 = new GraphicsPath();
            GraphicsPath borderPath_左下角 = new GraphicsPath();
            transPath_左下角.AddLine(new Point(0, c.Height - 3), new Point(0, c.Height));
            transPath_左下角.AddLine(new Point(1, c.Height - 2), new Point(1, c.Height));
            transPath_左下角.AddLine(new Point(2, c.Height - 1), new Point(2, c.Height));
            g.DrawPath(transPen, transPath_左下角);
            borderPath_左下角.AddLine(new Point(0, c.Height - 4), new Point(1, c.Height - 4));
            borderPath_左下角.AddLine(new Point(1, c.Height - 3), new Point(2, c.Height - 3));
            borderPath_左下角.AddLine(new Point(2, c.Height - 2), new Point(3, c.Height - 2));
            g.DrawPath(transBorderPen, borderPath_左下角);


            //Matrix mtrx = new Matrix();
            //mtrx.Rotate(90);
            //RectangleF rct = transPath_左下角.GetBounds(mtrx);
            //g.TranslateTransform(-rct.X, -rct.Y);
            //g.RotateTransform(90);
            //g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            //g.DrawPath(transPen, transPath_左下角);

            //RectangleF rct2 = borderPath_左下角.GetBounds(mtrx);
            //g.TranslateTransform(-rct2.X, -rct2.Y);
            //g.RotateTransform(90);
            //g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            //g.DrawPath(transBorderPen, borderPath_左下角);

            GraphicsPath transPath_左上角 = new GraphicsPath();
            GraphicsPath borderPath_左上角 = new GraphicsPath();
            transPath_左上角.AddLine(new Point(0, 0), new Point(2, 0));
            transPath_左上角.AddLine(new Point(0, 1), new Point(1, 1));
            transPath_左上角.AddLine(new Point(0, 2), new Point(0, 2));
            g.DrawPath(transPen, transPath_左上角);
            borderPath_左上角.AddLine(new Point(0, 3), new Point(1, 3));
            borderPath_左上角.AddLine(new Point(1, 2), new Point(2, 2));
            borderPath_左上角.AddLine(new Point(2, 1), new Point(3, 1));
            g.DrawPath(transBorderPen, borderPath_左上角);

            GraphicsPath transPath_右上角 = new GraphicsPath();
            GraphicsPath borderPath_右上角 = new GraphicsPath();
            transPath_右上角.AddLine(new Point(c.Width - 3, 0), new Point(c.Width, 0));
            transPath_右上角.AddLine(new Point(c.Width - 2, 1), new Point(c.Width, 1));
            transPath_右上角.AddLine(new Point(c.Width - 1, 2), new Point(c.Width, 2));
            g.DrawPath(transPen, transPath_右上角);
            borderPath_右上角.AddLine(new Point(c.Width - 4, 1), new Point(c.Width - 3, 1));
            borderPath_右上角.AddLine(new Point(c.Width - 3, 2), new Point(c.Width - 2, 2));
            borderPath_右上角.AddLine(new Point(c.Width - 2, 3), new Point(c.Width - 1, 3));
            g.DrawPath(transBorderPen, borderPath_右上角);

            GraphicsPath transPath_右下角 = new GraphicsPath();
            GraphicsPath borderPath_右下角 = new GraphicsPath();
            transPath_右下角.AddLine(new Point(c.Width - 3, c.Height - 1), new Point(c.Width, c.Height - 1));
            transPath_右下角.AddLine(new Point(c.Width - 2, c.Height - 2), new Point(c.Width, c.Height - 2));
            transPath_右下角.AddLine(new Point(c.Width - 1, c.Height - 3), new Point(c.Width, c.Height - 3));
            g.DrawPath(transPen, transPath_右下角);
            borderPath_右下角.AddLine(new Point(c.Width - 4, c.Height - 2), new Point(c.Width - 3, c.Height - 2));
            borderPath_右下角.AddLine(new Point(c.Width - 3, c.Height - 3), new Point(c.Width - 2, c.Height - 3));
            borderPath_右下角.AddLine(new Point(c.Width - 2, c.Height - 4), new Point(c.Width - 1, c.Height - 4));
            g.DrawPath(transBorderPen, borderPath_右下角);
        }

        private void DrawBorder2(Control c,Graphics g, Pen pen )
        {
            int w = (int)pen.Width;
            g.DrawLine(pen, new Point(0, 0), new Point(c.Width, 0));  //上边框
            g.DrawLine(pen, new Point(0, c.Height - w), new Point(c.Width, c.Height - w));  //下边框
            g.DrawLine(pen, new Point(0, 0), new Point(0, c.Height));  //左边框
            g.DrawLine(pen, new Point(c.Width - w, 0), new Point(c.Width - w, c.Height));  //右边框

            int angle = 10;
            int x = 0;
            int y = 0;
            g.DrawArc(pen, x, y, angle, angle, 180, 90);                                 //左上角
            g.DrawArc(pen, c.Width - angle, y, angle, angle, 270, 90);                 // 右上角
            g.DrawArc(pen, c.Width - angle, c.Height - angle, angle, angle, 0, 90);  // 右下角
            g.DrawArc(pen, x, c.Height - angle, angle, angle, 90, 90);                 // 左下角
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();
            //   左上角
            path.AddArc(arcRect, 180, 90);
            //   右上角
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);
            //   右下角
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);
            //   左下角
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }
        #endregion

        #region 窗体移动
        public static void MainForm_MouseMove(object sender, MouseEventArgs e,Form frm)
        {
            if (frm.MaximizeBox == false) return;
            if (frm.WindowState == FormWindowState.Maximized) return;

            if (e.X < 4 && e.Y < 4)   //左上
            {
                ((Control)sender).Cursor = Cursors.SizeNWSE;
                if (e.Button == MouseButtons.Left)
                {
                    Win32.ReleaseCapture();
                    Win32.SendMessage(frm.Handle, 274, 61440 + 4, 0);
                }
            }
            else
                if (e.X < 4 && e.Y > 4 && e.Y < frm.Height - 4)   //左边
                {
                    ((Control)sender).Cursor = Cursors.SizeWE;
                    if (e.Button == MouseButtons.Left)
                    {
                        Win32.ReleaseCapture();
                        Win32.SendMessage(frm.Handle, 274, 61440 + 1, 0);
                    }
                }
                else
                    if (e.X < 4 && e.Y > frm.Height - 4)   //左下
                    {
                        ((Control)sender).Cursor = Cursors.SizeNESW;
                        if (e.Button == MouseButtons.Left)
                        {
                            Win32.ReleaseCapture();
                            Win32.SendMessage(frm.Handle, 274, 61440 + 7, 0);
                        }
                    }
                    else
                        if (e.X > frm.Width - 4 && e.Y < 4)   //右上
                        {
                            ((Control)sender).Cursor = Cursors.SizeNESW;
                            if (e.Button == MouseButtons.Left)
                            {
                                Win32.ReleaseCapture();
                                Win32.SendMessage(frm.Handle, 274, 61440 + 5, 0);
                            }
                        }
                        else
                            if (e.X > frm.Width - 4 && e.Y > 4 && e.Y < frm.Height - 4)   //右边
                            {
                                ((Control)sender).Cursor = Cursors.SizeWE;
                                if (e.Button == MouseButtons.Left)
                                {
                                    Win32.ReleaseCapture();
                                    Win32.SendMessage(frm.Handle, 274, 61440 + 2, 0);
                                }
                            }
                            else
                                if (e.X > frm.Width - 4 && e.X > 4 && e.Y > frm.Height - 4)   //右下
                                {
                                    ((Control)sender).Cursor = Cursors.SizeNWSE;
                                    if (e.Button == MouseButtons.Left)
                                    {
                                        Win32.ReleaseCapture();
                                        Win32.SendMessage(frm.Handle, 274, 61440 + 8, 0);
                                    }
                                }
                                else
                                    if (e.X > 4 && e.X < frm.Width - 4 && e.Y < 4)   //顶部
                                    {
                                        ((Control)sender).Cursor = Cursors.SizeNS;
                                        if (e.Button == MouseButtons.Left)
                                        {
                                            Win32.ReleaseCapture();
                                            Win32.SendMessage(frm.Handle, 274, 61440 + 5, 0);
                                        }
                                    }
                                    else
                                        if (e.X > 4 && e.X < frm.Width - 4 && e.Y > frm.Height - 4)   //底部
                                        {
                                            ((Control)sender).Cursor = Cursors.SizeNS;
                                            if (e.Button == MouseButtons.Left)
                                            {
                                                Win32.ReleaseCapture();
                                                Win32.SendMessage(frm.Handle, 274, 61440 + 6, 0);
                                            }
                                        }
                                        else
                                            ((Control)sender).Cursor = Cursors.Default;
        }

        #endregion

        #region  窗口拖动改变大小的一种方法
        //private const int WM_NCHITTEST = 0x84; //移动鼠标，按住或释放鼠标时发生的系统消息
        //private const int HTCLIENT = 0x1;//工作区
        //private const int HTSYSMENU = 3;//系统菜单
        //private const int HTCAPTION = 0x2; //标题栏

        //private const int HTLEFT = 10;//向左
        //private const int HTRIGHT = 11;//向右
        //private const int HTTOP = 12;//向上
        //private const int HTTOPLEFT = 13;//向左上
        //private const int HTTOPRIGHT = 14;//向右上
        //private const int HTBOTTOM = 15;//向下
        //private const int HTBOTTOMLEFT = 16;//向左下
        //private const int HTBOTTOMRIGHT = 17;//向右下
        //private int m_BorderWidth = 2;
        //private int m_CaptionHeight = 20;

        //private const int BorderWidth = 5;//自己定义的窗体边的宽度

        ////可以调整窗体的大小和移动窗体的位置
        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == WM_NCHITTEST)
        //    {
        //        base.WndProc(ref m);
        //        if (DesignMode)
        //        {
        //            return;
        //        }
        //        if ((int)m.Result == HTCLIENT)
        //        {
        //            m.HWnd = this.Handle;

        //            System.Drawing.Rectangle rect = this.RectangleToScreen(this.ClientRectangle);
        //            Point C_Pos = Cursor.Position;

        //            if ((Cursor.Position.X <= rect.Left + m_BorderWidth) && (C_Pos.Y <= rect.Top + m_BorderWidth))
        //                m.Result = (IntPtr)HTTOPLEFT;//左上
        //            else if ((C_Pos.X >= rect.Left + rect.Width - m_BorderWidth) && (C_Pos.Y <= rect.Top + m_BorderWidth))
        //                m.Result = (IntPtr)HTTOPRIGHT;//右上
        //            else if ((C_Pos.X <= rect.Left + m_BorderWidth) && (C_Pos.Y >= rect.Top + rect.Height - m_BorderWidth))
        //                m.Result = (IntPtr)HTBOTTOMLEFT;//左下
        //            else if ((C_Pos.X >= rect.Left + rect.Width - m_BorderWidth) && (C_Pos.Y >= rect.Top + rect.Height - m_BorderWidth))
        //                m.Result = (IntPtr)HTBOTTOMRIGHT;//右下
        //            else if (C_Pos.X <= rect.Left + m_BorderWidth - 1)
        //                m.Result = (IntPtr)HTLEFT;//左
        //            else if (C_Pos.X >= rect.Left + rect.Width - m_BorderWidth)
        //                m.Result = (IntPtr)HTRIGHT;//右
        //            else if (C_Pos.Y <= rect.Top + m_BorderWidth - 1)
        //                m.Result = (IntPtr)HTTOP;//上
        //            else if (C_Pos.Y >= rect.Top + rect.Height - m_BorderWidth)
        //                m.Result = (IntPtr)HTBOTTOM;//下
        //            else if (C_Pos.Y <= rect.Top + m_CaptionHeight + m_BorderWidth)
        //            {
        //                if (C_Pos.X <= rect.Left + m_BorderWidth + m_CaptionHeight)
        //                {
        //                    m.Result = (IntPtr)HTSYSMENU;//模拟系统菜单,双击可以关闭窗体
        //                }
        //                else
        //                {
        //                    m.Result = (IntPtr)HTCAPTION;//模拟标题栏,移动或双击可以最大或最小化窗体
        //                }
        //            }
        //        }
        //        return;
        //    }
        //    else
        //    {
        //        base.WndProc(ref m);
        //    }
        //}

        #endregion

        #region  处理控件region 以免覆盖主窗体边框线
        public static void RegionControlBorder(Control c)
        {
            int width = c.Size.Width;
            int height = c.Size.Height;
            
            Rectangle rg = new Rectangle(new Point(1, 1), new Size(width - 2, height - 2));
            Rectangle rg_上 = new Rectangle(new Point(0,0),new Size(width-2,1));
           // c.Region = new Region(rg);
           // c.Region.Exclude(rg_上);
           
            int Rgn = Win32.CreateRoundRectRgn(0, 0, width, height, 5, 5);
            Win32.SetWindowRgn(c.Handle, Rgn, true);
          
            Rectangle rg_左下1 = new Rectangle(new Point(1, height - 4), new Size(1, 4));
            Rectangle rg_左下2 = new Rectangle(new Point(2, height - 3), new Size(1, 3));
            Rectangle rg_左下3 = new Rectangle(new Point(3, height - 2), new Size(1, 2));

            Rectangle rg_左上1 = new Rectangle(new Point(1, 0), new Size(1, 4));
            Rectangle rg_左上2 = new Rectangle(new Point(2, 0), new Size(1, 3));
            Rectangle rg_左上3 = new Rectangle(new Point(3, 0), new Size(1, 2));

            Rectangle rg_右下1 = new Rectangle(new Point(width - 2, height - 4), new Size(1, 4));
            Rectangle rg_右下2 = new Rectangle(new Point(width - 3, height - 3), new Size(1, 3));
            Rectangle rg_右下3 = new Rectangle(new Point(width - 4, height - 2), new Size(1, 2));

            Rectangle rg_右上1 = new Rectangle(new Point(width - 2, 0), new Size(1, 4));
            Rectangle rg_右上2 = new Rectangle(new Point(width - 3, 0), new Size(1, 3));
            Rectangle rg_右上3 = new Rectangle(new Point(width - 4, 0), new Size(1, 2));

            Region rgn = new Region();
            rgn.MakeEmpty();      //一定要这样写  c.Region.Exclude(rg_左下1)这样写的话只有在第一次的时候才可以...
            rgn.Union(rg);

            rgn.Exclude(rg_左下1);
            rgn.Exclude(rg_左下2);
            rgn.Exclude(rg_左下3);
            rgn.Exclude(rg_左上1);
            rgn.Exclude(rg_左上2);
            rgn.Exclude(rg_左上3);
            rgn.Exclude(rg_右下1);
            rgn.Exclude(rg_右下2);
            rgn.Exclude(rg_右下3);
            rgn.Exclude(rg_右上1);
            rgn.Exclude(rg_右上2);
            rgn.Exclude(rg_右上3);
           // Invalidate(updateRegion);
           // c.Invalidate(rgn);
           // c.SuspendLayout();
            //c.Region = rgn;
           
           // c.SuspendLayout();
         
        }

        #endregion


        /// <summary>
        /// 参数 0-1   1表示不透明
        /// </summary>
        /// <param name="opacity"></param>
        private static Image ChangeImageOpacity(Image srcImage, float opacity)
        {
            float[][] nArray ={ new float[] {1, 0, 0, 0, 0},
                                new float[] {0, 1, 0, 0, 0},
                                new float[] {0, 0, 1, 0, 0},
                                new float[] {0, 0, 0, opacity, 0},
                                new float[] {0, 0, 0, 0, 1}};
            ColorMatrix matrix = new ColorMatrix(nArray);
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            Bitmap resultImage = new Bitmap(srcImage.Width, srcImage.Height);
            Graphics g = Graphics.FromImage(resultImage);
            g.DrawImage(srcImage, new Rectangle(0, 0, srcImage.Width, srcImage.Height), 0, 0, srcImage.Width, srcImage.Height, GraphicsUnit.Pixel, attributes);
            return resultImage;
        }

       
    }
}
