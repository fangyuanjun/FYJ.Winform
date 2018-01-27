using FYJ.Winform.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FYJ.Winform.Controls
{
    public class ProgressBarEx : System.Windows.Forms.ProgressBar
    {
        [System.Runtime.InteropServices.DllImport("user32.dll ")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);

        [System.Runtime.InteropServices.DllImport("user32.dll ")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        private System.Drawing.Color _TextColor = System.Drawing.Color.Black;
        private System.Drawing.Font _TextFont = new System.Drawing.Font("SimSun ", 12);

        public System.Drawing.Color TextColor
        {
            get { return _TextColor; }
            set { _TextColor = value; this.Invalidate(); }
        }

        public System.Drawing.Font TextFont
        {
            get { return _TextFont; }
            set { _TextFont = value; this.Invalidate(); }
        }

        /// <summary>
        /// 是否在任务栏显示进度
        /// </summary>
        public bool IsShowTaskProgress
        {
            get;
            set;
        }

        private long _maximum;
        private int _ratio = 1; //系数  如果long之大于int.MaxValue  除以该系数后让值变得小于int.MaxValue
        private long _value;
        public new long Maximum
        {
            get { return _maximum; }
            set
            {
                if (value > int.MaxValue)
                {
                    _ratio = 10;
                    while (value / _ratio > int.MaxValue)
                    {
                        _ratio = _ratio * 10;
                    }

                    base.Maximum = (int)(value / _ratio);
                }
                else
                {
                    base.Maximum = (int)value;
                }

                _maximum = value;
            }
        }

        public new long Value
        {
            get { return _value; }
            set
            {
                _value = value;

                if (this.InvokeRequired)
                {
                    this.Invoke((Action)delegate()
                    {
                        base.Value = Math.Min((int)(value / _ratio), base.Maximum);
                        if (TaskbarManager.Instance.IsWin7OrSever2008R2 && IsShowTaskProgress)
                        {
                            TaskbarManager.Instance.TaskbarList.SetProgressValue(FindFormHandle(), (ulong)value, (ulong)this.Maximum);
                        }
                    });
                }
                else
                {
                    base.Value = Math.Min((int)(value / _ratio), base.Maximum);
                    if (TaskbarManager.Instance.IsWin7OrSever2008R2 && IsShowTaskProgress)
                    {
                        TaskbarManager.Instance.TaskbarList.SetProgressValue(FindFormHandle(), (ulong)value, (ulong)this.Maximum);
                    }
                }
            }
        }
        //查找所属Form的Handle
        private IntPtr FindFormHandle()
        {
            Control control = this.Parent;
            while (control != null)
            {
                if (control is Form)
                {
                    return control.Handle;
                }
                else
                {
                    control = control.Parent;
                }
            }

            return IntPtr.Zero;
        }

        protected override void WndProc(ref   Message m)
        {
            base.WndProc(ref   m);

            if (m.Msg == 0xf || m.Msg == 0x133)
            {
                //拦截系统消息，获得当前控件进程以便重绘。   
                //一些控件（如TextBox、Button等）是由系统进程绘制，重载OnPaint方法将不起作用.   
                //所有这里并没有使用重载OnPaint方法绘制TextBox边框。   
                //MSDN:重写   OnPaint   将禁止修改所有控件的外观。   
                //那些由   Windows   完成其所有绘图的控件（例如   Textbox）从不调用它们的   OnPaint   方法，   
                //因此将永远不会使用自定义代码。请参见您要修改的特定控件的文档，   
                //查看   OnPaint   方法是否可用。如果某个控件未将   OnPaint   作为成员方法列出，   
                //则您无法通过重写此方法改变其外观。   
                //MSDN:要了解可用的   Message.Msg、Message.LParam   和   Message.WParam   值，   
                //请参考位于   MSDN   Library   中的   Platform   SDK   文档参考。可在   Platform   SDK（“Core   SDK”一节）   
                //下载中包含的   windows.h   头文件中找到实际常数值，该文件也可在   MSDN   上找到。   

                IntPtr hDC = GetWindowDC(m.HWnd);
                if (hDC.ToInt32() == 0)
                {
                    return;
                }

                System.Drawing.Graphics g = Graphics.FromHdc(hDC);
                SolidBrush brush = new SolidBrush(_TextColor);
                string s = string.Format("{0}%", this.Maximum == 0 ? 0 : this.Value * 100 / this.Maximum);
                SizeF size = g.MeasureString(s, _TextFont);
                float x = (this.Width - size.Width) / 2;
                float y = (this.Height - size.Height) / 2;
                g.DrawString(s, _TextFont, brush, x, y);
                //返回结果   
                m.Result = IntPtr.Zero;
                //释放   
                ReleaseDC(m.HWnd, hDC);
            }
        }
    }
}
