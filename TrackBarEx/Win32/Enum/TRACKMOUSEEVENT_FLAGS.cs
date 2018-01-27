using System;

namespace CSharpWin.Win32.Enum
{
    internal enum TRACKMOUSEEVENT_FLAGS : uint
    {
        TME_HOVER = 1,
        TME_LEAVE = 2,
        TME_QUERY = 0x40000000,
        TME_CANCEL = 0x80000000
    }
}
