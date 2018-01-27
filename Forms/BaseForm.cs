using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FYJ.Winform.Util;
using FYJ.Winform.Controls;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace FYJ.Winform.Forms
{
    public partial class BaseForm : System.Windows.Forms.Form
    {
        private Size oldSize;
        public BaseForm()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                //StrongNameCodeAccessPermission.Demand();
            }
        }

        public bool AllowMove
        {
            get { return _allowMove; }
            set { _allowMove = value; }
        }
        private bool _allowMove = true;

        #region 初始化
        protected override void OnLoad(EventArgs e)
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            //this.SetStyle(ControlStyles.ResizeRedraw, true);
            Version v = System.Environment.Version;
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            TaskMenu.ShowSYSMENU(this);
            int Rgn = Win32.CreateRoundRectRgn(0, 0, this.Width + 1, this.Height + 1, 5, 5);
            Win32.SetWindowRgn(this.Handle, Rgn, true);

            this.BackgroundImageLayout = MyFormTemp.CurrentImageLayout;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = MyFormTemp.CurrentBackgroundColor;
            if (MyFormTemp.CurrentBackgroundImage != null)
            {
                this.BackgroundImage = MyFormTemp.CurrentBackgroundImage;
            }
            if (this.StartPosition == FormStartPosition.CenterScreen && (!this.DesignMode))
            {
                this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
            }
            ResizeControl();
            // this.TransparencyKey = Color.FromArgb(255,0,255);
            // this.TransparencyKey = BackColor;

            base.OnLoad(e);
            oldSize = this.Size;
        }
        #endregion

        #region  重载windows消息
        protected override void WndProc(ref Message m)
        {
            if (DesignMode)
            {
                switch (m.Msg)
                {
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
                    default:
                        base.WndProc(ref m);
                        break;
                }

                return;
            }
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
                //最关键控制让系统的标题栏和边框不再绘制
                case Win32.WM_NCCALCSIZE:
                    break;
                case Win32.WM_SYSCOMMAND:

                    if (m.WParam == (IntPtr)Win32.SC_RESTORE || m.WParam.ToInt32() == Win32.SC_RESTORE + 2)
                    {
                        this.Size = oldSize;
                    }
                    else if (m.WParam == (IntPtr)Win32.SC_MINIMIZE || m.WParam.ToInt32() == Win32.SC_MINIMIZE + 2)
                    {
                        //if (oldSize.Width == 0)
                        // oldSize = this.Size;
                    }
                    base.WndProc(ref m);
                    break;

                case Win32.WM_NCHITTEST:
                    Point vPoint = new Point((int)m.LParam & 0xFFFF, (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (MaximizeBox)
                    {
                        if (vPoint.X <= 3)
                        {
                            if (vPoint.Y <= 3)
                                m.Result = (IntPtr)Win32.HTTOPLEFT;
                            else if (vPoint.Y >= Height - 3)
                                m.Result = (IntPtr)Win32.HTBOTTOMLEFT;
                            else m.Result = (IntPtr)Win32.HTLEFT;
                        }
                        else if (vPoint.X >= Width - 3)
                        {
                            if (vPoint.Y <= 3)
                                m.Result = (IntPtr)Win32.HTTOPRIGHT;
                            else if (vPoint.Y >= Height - 3)
                                m.Result = (IntPtr)Win32.HTBOTTOMRIGHT;
                            else m.Result = (IntPtr)Win32.HTRIGHT;
                        }
                        else if (vPoint.Y <= 3)
                        {
                            m.Result = (IntPtr)Win32.HTTOP;
                        }
                        else if (vPoint.Y >= Height - 3)
                            m.Result = (IntPtr)Win32.HTBOTTOM;
                    }
                    if (AllowMove)
                    {
                        if (vPoint.Y < Height - 3 && vPoint.Y > 2 && (vPoint.X > 3 && vPoint.X < Width - 3))
                            m.Result = (IntPtr)Win32.HTCAPTION;
                    }
                    else
                    {
                        if (vPoint.Y < 31 && vPoint.Y > 2 && (vPoint.X > 3 && vPoint.X < Width - 3))
                            m.Result = (IntPtr)Win32.HTCAPTION;
                    }

                    break;
                case Win32.WM_NCLBUTTONDBLCLK://禁止双击最大化
                    if (MaximizeBox)
                    {
                        base.WndProc(ref m);
                        this.Invalidate(false);
                        UpdateMaxButton();
                    }
                    break;
                case 0x00a4:
                    {
                        if (this.ContextMenuStrip != null)
                            this.ContextMenuStrip.Show(System.Windows.Forms.Control.MousePosition);
                    }
                    break;
                //case 0x0006:
                //    {
                //        base.WndProc(ref m);
                //        Win32.LockWindowUpdate(IntPtr.Zero);
                //        this.InvalidateEx();

                //        break;
                //    }
                case 0x0014:  //WM_ERASEBKGND
                    m.Result = (IntPtr)1;
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        #endregion

        #region 激活与未激活窗口变化
        private Brush titleColor = Brushes.Black;

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            titleColor = Brushes.Black;
            this.Invalidate(new Rectangle(this.Icon.Width, 7, 100, 31));
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            titleColor = Brushes.WhiteSmoke;
            this.Invalidate(new Rectangle(this.Icon.Width, 7, 100, 31));
        }
        #endregion

        #region 调整控件位置
        private void ResizeControl()
        {
            if (this.ControlBox)
            {
                this.ButtonClose.Left = this.Width - ButtonClose.Width;
            }
            else
            {
                this.ButtonClose.Visible = false;
                this.ButtonMax.Visible = false;
                this.ButtonMin.Visible = false;
                return;
            }
            if (this.MaximizeBox == false)
            {
                this.ButtonMin.Location = new Point(this.ButtonMin.Location.X + this.ButtonMax.Size.Width, this.ButtonMin.Location.Y);
                this.ButtonMax.Visible = false;
            }
            this.ButtonMin.Visible = MinimizeBox;

            if (this.MinimizeBox)
            {
                if (this.MaximizeBox)
                {
                    this.ButtonMax.Left = ButtonClose.Left - ButtonMax.Width;
                    this.ButtonMin.Left = ButtonMax.Left - ButtonMin.Width;
                }
                else
                {
                    this.ButtonMin.Left = ButtonClose.Left - ButtonMin.Width;
                }
            }
        }
        #endregion

        #region 绘制
        protected virtual void DrawBackground(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Bitmap Bmp = global::FYJ.Winform.Properties.Resources.base_form_bg;
            g.DrawImage(Bmp, new Rectangle(0, 0, 5, 31), 0, 0, 5, 31, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(5, 0, this.Width - 10, 31), 5, 0, Bmp.Width - 10, 31, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(this.Width - 5, 0, 5, 31), Bmp.Width - 5, 0, 5, 31, GraphicsUnit.Pixel);

            g.DrawImage(Bmp, new Rectangle(0, 31, 2, 25), 0, 31, 2, 25, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(2, 31, this.Width - 4, 25), 2, 31, 5, 25, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(this.Width - 2, 31, 2, 25), Bmp.Width - 2, 31, 2, 25, GraphicsUnit.Pixel);

            g.DrawImage(Bmp, new Rectangle(0, 56, 5, Height - 90), 0, Bmp.Height - 230, 5, 130, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(5, 56, this.Width - 10, Height - 90), 5, Bmp.Height - 230, Bmp.Width - 10, 130, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(this.Width - 5, 56, 5, Height - 90), Bmp.Width - 5, Bmp.Height - 230, 5, 130, GraphicsUnit.Pixel);

            g.DrawImage(Bmp, new Rectangle(0, this.Height - 34, 5, 34), 0, Bmp.Height - 34, 5, 34, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(5, this.Height - 34, this.Width - 10, 34), 5, Bmp.Height - 34, Bmp.Width - 10, 34, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(this.Width - 5, this.Height - 34, 5, 34), Bmp.Width - 5, Bmp.Height - 34, 5, 34, GraphicsUnit.Pixel);

            int strX = 10;
            if (this.ShowIcon)
            {
                strX = 30;
                g.DrawIcon(Icon, new Rectangle(8, 7, 16, 16));
            }

            if (!String.IsNullOrEmpty(this.Text))
            {
                Font f = null;
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    f = new Font("微软雅黑", 11F, FontStyle.Bold);
                    g.DrawString(this.Text, f, titleColor, strX, 4);
                    //g.DrawImage(Bmp, new Rectangle(strX, 4, (int)SkinUtil.GetStrWidth(Text, f), 20), 0, 0, Bmp.Width, Bmp.Height, GraphicsUnit.Pixel);
                }
                else
                {
                    f = new Font("宋体", 11F, FontStyle.Bold);
                    g.DrawString(this.Text, f, titleColor, strX, 8);
                }
                // g.DrawString(this.Text, new Font("宋体", 11F, FontStyle.Regular), Brushes.WhiteSmoke, strX, 8);
            }

            Bmp.Dispose();
        }
        #endregion

        #region  三个按钮事件
        private void ButtonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void UpdateMaxButton()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.ButtonMax.ToolTipString = "最大化";
                this.ButtonMax.BackgroundImage = global::FYJ.Winform.Properties.Resources.btn_max_normal;   //这句写到下三条语句最前
                this.ButtonMax.MouseNormalImage = global::FYJ.Winform.Properties.Resources.btn_max_normal;
                this.ButtonMax.MouseEnterImage = global::FYJ.Winform.Properties.Resources.btn_max_highlight;
                this.ButtonMax.MouseDownImage = global::FYJ.Winform.Properties.Resources.btn_max_down;

            }
            else
            {
                this.ButtonMax.ToolTipString = "向下还原";
                this.ButtonMax.BackgroundImage = global::FYJ.Winform.Properties.Resources.btn_restore_normal; //这个句写到下三条语句最前
                this.ButtonMax.MouseNormalImage = global::FYJ.Winform.Properties.Resources.btn_restore_normal;
                this.ButtonMax.MouseEnterImage = global::FYJ.Winform.Properties.Resources.btn_restore_highlight;
                this.ButtonMax.MouseDownImage = global::FYJ.Winform.Properties.Resources.btn_restore_down;

            }
        }

        private void ButtonMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                Win32.SendMessage(this.Handle, Win32.WM_SYSCOMMAND, Win32.SC_MAXIMIZE, 0);
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                Win32.SendMessage(this.Handle, Win32.WM_SYSCOMMAND, Win32.SC_RESTORE, 0);
            }
            UpdateMaxButton();
            this.Invalidate(false);
        }

        protected virtual void ButtonClose_Click(object sender, EventArgs e)
        {
            Win32.SendMessage(this.Handle, Win32.WM_SYSCOMMAND, Win32.SC_CLOSE, 0);
            this.Close();
        }
        #endregion

        #region  override
        protected override void OnPaint(PaintEventArgs e)
        {
            // base.OnPaint(e);
            DrawBackground(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (this.WindowState != FormWindowState.Maximized)
            {
                int Rgn = Win32.CreateRoundRectRgn(0, 0, this.Width + 1, this.Height + 1, 5, 5);
                Win32.SetWindowRgn(this.Handle, Rgn, true);
            }
            else
            {
                int Rgn = Win32.CreateRoundRectRgn(0, 0, this.Width + 1, this.Height + 1, 0, 0);
                Win32.SetWindowRgn(this.Handle, Rgn, true);
            }
            Size size = Screen.PrimaryScreen.WorkingArea.Size;
            MaximizedBounds = new Rectangle(0, 0, size.Width, size.Height - 1);
            //if (this.FormBorderStyle == FormBorderStyle.None)
            //{
            //    MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
            //}
            //else
            //{

            //}
            //GC.Collect();
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            oldSize = this.Size;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cParms = base.CreateParams;
                if (!this.DesignMode)
                {
                    cParms.ExStyle |= 0x02000000;  //WS_CLIPCHILDREN
                }
                return cParms;
            }
        }
        #endregion
    }
}
