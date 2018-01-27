using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace FYJ.Winform.Util
{
    public class TaskMenu
    {
        private TaskMenu() {
        }
        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        private static extern int GetWindowLong(HandleRef hWnd, int nIndex);
        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        private static extern IntPtr SetWindowLong(HandleRef hWnd, int nIndex, int dwNewLong);

        private const int WS_SYSMENU = 0x00080000;

        public static void ShowSYSMENU(Form form)
        {
            int windowLong = (GetWindowLong(new HandleRef(form, form.Handle), -16));
            SetWindowLong(new HandleRef(form, form.Handle), -16, windowLong | WS_SYSMENU | 0x20000 | 0x40000);
            InitSYSMENU(form);
        }

        public static void InitSYSMENU(Form form)
        {
            int menu = Win32.GetSystemMenu(form.Handle.ToInt32(), 0);

            if (!form.ControlBox)
            {
                Win32.DeleteMenu(menu, Win32.SC_CLOSE, 0x0);//关闭
                Win32.DeleteMenu(menu, Win32.SC_MINIMIZE, 0x0);//最小化
                Win32.DeleteMenu(menu, Win32.SC_MAXIMIZE, 0x0);//最大化
            }
            else
            {
                if (!form.MinimizeBox)
                {
                    Win32.DeleteMenu(menu, Win32.SC_MINIMIZE, 0x0);//最小化
                }
                if (!form.MaximizeBox)
                {
                    Win32.DeleteMenu(menu, Win32.SC_MAXIMIZE, 0x0);//最大化
                }
            }
            
        }
    }
}
