using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using FYJ.Winform.Util;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace FYJ.Winform.Controls
{
    public class TabControlEx:System.Windows.Forms.TabControl
    {
        private const int CLOSE_SIZE = 8;
        public TabControlEx()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //清空控件
          
            //绘制的方式OwnerDrawFixed表示由窗体绘制大小也一样
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.SizeMode = TabSizeMode.Fixed;
            //this.Padding = new System.Drawing.Point(CLOSE_SIZE, CLOSE_SIZE);
        }

        #region   属性
        private bool _canClose = true;
        public bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }
        private Color _activeBorderColor =Color.FromArgb(47, 180, 240);
        public Color ActiveBorderColor
        {
            get { return _activeBorderColor; }
            set { _activeBorderColor = value; }
        }
        private Color _closeBorderColor = Color.FromArgb(47, 180, 240);
        public Color CloseBorderColor
        {
            get { return _closeBorderColor; }
            set { _closeBorderColor = value; }
        }
        public Color _normalBorderColor = Color.Gray;
        public Color NormalBorderColor
        {
            get { return _normalBorderColor; }
            set { _normalBorderColor = value; }
        }
        #endregion

        internal void DrawTab(Graphics g, TabPage tabPage, int nIndex)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            // g.TextRenderingHint = TextRenderingHint.AntiAlias;
            Rectangle recBounds = this.GetTabRect(nIndex);
            
            bool bSelected = (this.SelectedIndex == nIndex);
            Point[] pt = new Point[7];
            pt[0] = new Point(recBounds.Left, recBounds.Bottom);
            pt[1] = new Point(recBounds.Left, recBounds.Top + 3);
            pt[2] = new Point(recBounds.Left + 3, recBounds.Top);
            pt[3] = new Point(recBounds.Right - 3, recBounds.Top);
            pt[4] = new Point(recBounds.Right, recBounds.Top + 3);
            pt[5] = new Point(recBounds.Right, recBounds.Bottom);
            pt[6] = new Point(recBounds.Left, recBounds.Bottom);

            Brush br = new SolidBrush(tabPage.BackColor);
            //默认的左右边框没有被选中时的标题边框颜色
            g.DrawPolygon(new Pen(new SolidBrush(NormalBorderColor)), pt);

            if (bSelected)
            {
                Pen pen = new Pen(Color.White);
                //选中时背景
                g.FillPolygon(new SolidBrush(Color.White), pt);
                br.Dispose();

                //左右被选中时颜色
                g.DrawPolygon(new Pen(ActiveBorderColor), pt);
                //选中时清除下边框线
                g.DrawLine(new Pen(Color.White, 5f), recBounds.Left + 1, recBounds.Bottom - 2, recBounds.Right - 1, recBounds.Bottom - 2);
                pen.Dispose();

                if (CanClose)
                {
                    int paddingRight = 8;
                    //画关闭符号
                    using (Pen objpen = new Pen(Color.Red, 2))
                    {
                        //"\"线
                        Point p1 = new Point(recBounds.X + recBounds.Width - CLOSE_SIZE - paddingRight, (recBounds.Height - CLOSE_SIZE) / 2);
                        Point p2 = new Point(recBounds.X + recBounds.Width - CLOSE_SIZE, ((recBounds.Height - CLOSE_SIZE) / 2) + CLOSE_SIZE);
                        g.DrawLine(objpen, p1, p2);

                        // "/"线
                        Point p3 = new Point(recBounds.X + recBounds.Width - paddingRight, (recBounds.Height - CLOSE_SIZE) / 2);
                        Point p4 = new Point(recBounds.X + recBounds.Width - CLOSE_SIZE - paddingRight, ((recBounds.Height - CLOSE_SIZE) / 2) + CLOSE_SIZE);
                        g.DrawLine(objpen, p3, p4);
                    }

                    if (isClose)
                    {
                        g.DrawRectangle(new Pen(new SolidBrush(CloseBorderColor)), new Rectangle(recBounds.X + recBounds.Width - CLOSE_SIZE - paddingRight - 2, (recBounds.Height - CLOSE_SIZE) / 2 - 2, 12, 12));
                    }
                }
            }
            else
            {
                //没有选中时的下边框颜色
                g.DrawLine(new Pen(NormalBorderColor), recBounds.Left + 1, recBounds.Bottom, recBounds.Right - 1, recBounds.Bottom);
            }

            // draw string
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            br = new SolidBrush(Color.Black);
            g.DrawString(tabPage.Text, Font, br, recBounds, stringFormat);
            br.Dispose();

            
        }

       
        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            for (int i = 0; i < this.TabCount; i++)
                DrawTab(e.Graphics, this.TabPages[i], i);
            //Rectangle rect = this.ClientRectangle;
            //GraphicsPath path = new GraphicsPath();
            //int radius = 5;
            //bool correction = true;
            //int radiusCorrection = correction ? 1 : 0;
            //path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            //path.AddArc(
            //    rect.Right - radius - radiusCorrection,
            //    rect.Y,
            //    radius,
            //    radius,
            //    270,
            //    90);
            //path.AddLine(
            //    rect.Right - radiusCorrection, rect.Bottom - radiusCorrection,
            //    rect.X, rect.Bottom - radiusCorrection);
            //this.Region = new Region(path);
        }

        private ToolTip toolTip1 = new ToolTip();
        bool isClose = false;
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            toolTip1.SetToolTip(this, "关闭");
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!CanClose)
                return;
            if (!isClose)
                return;
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                int x = e.X, y = e.Y;

                //计算关闭区域   
                Rectangle myTabRect = this.GetTabRect(this.SelectedIndex);

                myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 8)-2, (myTabRect.Height - CLOSE_SIZE) / 2-2);
                myTabRect.Width = CLOSE_SIZE+4;
                myTabRect.Height = CLOSE_SIZE+4;

                //如果鼠标在区域内就关闭选项卡   
                bool isCloseRect = x > myTabRect.X && x < myTabRect.Right
                 && y > myTabRect.Y && y < myTabRect.Bottom;

                if (isCloseRect == true)
                {
                    this.TabPages.Remove(this.SelectedTab);
                }
                //else
                //    this.OnClick(e);    不要  否则会执行2次
            }

        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            this.Invalidate(false);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!CanClose)
                return;

                int x = e.X, y = e.Y;

                //计算关闭区域   
                Rectangle myTabRect = this.GetTabRect(this.SelectedIndex);

                myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 8) - 2, (myTabRect.Height - CLOSE_SIZE) / 2 - 2);
                myTabRect.Width = CLOSE_SIZE + 4;
                myTabRect.Height = CLOSE_SIZE + 4;

                //如果鼠标在区域内就关闭选项卡   
                bool isCloseRect = x > myTabRect.X && x < myTabRect.Right
                 && y > myTabRect.Y && y < myTabRect.Bottom;

                if (isCloseRect == true)
                {
                    isClose = true;
                    
                }
                else
                {
                    isClose = false;
                    toolTip1.Hide(this);
                }

                this.Invalidate(new Rectangle(0,0,this.Width,this.ItemSize.Height), false);
        }


       
        /// <summary>
        /// 修改控件或窗体的边框，例如Textbox或是Form窗体
        /// </summary>
        /// <param name="m">消息</param>
        /// <param name="control">控件对象</param>
        /// <param name="Nwidth">边框像素</param>
        /// <param name="objcolor">边框颜色</param>
        internal  void ResetBorderColor(Message m, Control control, int Nwidth, Color objcolor)
        {
            //根据颜色和边框像素取得一条线
            System.Drawing.Pen pen = pen = new Pen(objcolor, Nwidth);
            //得到当前的句柄
            IntPtr hDC = Win32.GetWindowDC(m.HWnd);
            if (hDC.ToInt32() == 0)
            {
                return;
            }

            if (pen != null)
            {
                //绘制边框 
                System.Drawing.Graphics g = Graphics.FromHdc(hDC);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                //g.DrawRectangle(pen, 0, 0, control.Width-Nwidth , control.Height-Nwidth );
                g.FillRectangle(new SolidBrush(Color.White),new Rectangle(0,0,5,this.Height));  //处理左边框
                //g.FillRectangle(new SolidBrush(Color.White),new Rectangle(0,0,control.Width,5)); //处理上边框
                g.FillRectangle(new SolidBrush(Color.White), new Rectangle(control.Width-5, 0, 5, control.Height)); //处理右边框
                g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, control.Height-5, control.Width, 5)); //处理下边框
                pen.Dispose();
            }

            //释放 
            Win32.ReleaseDC(m.HWnd, hDC);
        }

      
        /// <summary>
        /// 重新设置边框    this.SetStyle(ControlStyles.UserPaint, true);   加了可以不要这个了
        /// </summary>
        /// <param name="m">当前的Windows消息</param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            //if (m.Msg == 0xf || m.Msg == 0x133)
            //{
            //    this.ResetBorderColor(m, this, 1, Color.Red);
            //}
           
        }

    }
}
