using System;
using System.Runtime.InteropServices;

namespace CSharpWin.Win32.Struct
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct NMTTCUSTOMDRAW
    {
        internal NMCUSTOMDRAW nmcd;
        internal uint uDrawFlags;
    }
}
