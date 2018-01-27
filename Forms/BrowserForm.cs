using FYJ.Winform.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace FYJ.Winform.Forms
{
    public partial class BrowserForm : Form
    {
        public BrowserForm()
        {
            InitializeComponent();
        }

        [System.ComponentModel.ReadOnly(true)]
        public new bool MaximizeBox
        {
            get { return false; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.webBrowser1.DocumentText = "";
            this.webBrowser1.Document.MouseMove += Document_MouseMove;
        }

        void Document_MouseMove(object sender, HtmlElementEventArgs e)
        {
            Win32.ReleaseCapture();
            Win32.SendMessage(this.Handle, Win32.WM_SYSCOMMAND, Win32.SC_MOVE + Win32.HTCAPTION, 0);
        }

        #region  重载windows消息
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case Win32.WM_NCCALCSIZE:
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        #endregion
    }
}
