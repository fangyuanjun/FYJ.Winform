using System;
using System.Windows.Forms;
using CSharpWin.Win32.Const;

namespace CSharpWin.Win32
{
    internal class Helper
    {
        private Helper()
        {
        }

        public static bool LeftKeyPressed()
        {
            if (SystemInformation.MouseButtonsSwapped)
            {
                return (NativeMethods.GetKeyState(VK.VK_RBUTTON) < 0);
            }
            else
            {
                return (NativeMethods.GetKeyState(VK.VK_LBUTTON) < 0);
            }
        }
    }
}
