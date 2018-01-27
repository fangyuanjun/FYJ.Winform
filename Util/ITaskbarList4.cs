using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;


namespace FYJ.Winform.Util
{
    [ComImportAttribute()]
    [GuidAttribute("c43dc798-95d1-4bea-9030-bb99e2983a1a")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ITaskbarList4
    {
        // ITaskbarList
        [PreserveSig]
        void HrInit();

        [PreserveSig]
        void AddTab(IntPtr hwnd);

        [PreserveSig]
        void DeleteTab(IntPtr hwnd);

        [PreserveSig]
        void ActivateTab(IntPtr hwnd);

        [PreserveSig]
        void SetActiveAlt(IntPtr hwnd);

        // ITaskbarList2
        [PreserveSig]
        void MarkFullscreenWindow(
            IntPtr hwnd,
            [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

        // ITaskbarList3

        [PreserveSig]
        void SetProgressValue(IntPtr hwnd, UInt64 ullCompleted, UInt64 ullTotal);

        [PreserveSig]
        void SetProgressState(IntPtr hwnd, TBPFLAG tbpFlags);

        [PreserveSig]
        void RegisterTab(IntPtr hwndTab, IntPtr hwndMDI);

        [PreserveSig]
        void UnregisterTab(IntPtr hwndTab);

        [PreserveSig]
        void SetTabOrder(IntPtr hwndTab, IntPtr hwndInsertBefore);

        [PreserveSig]
        void SetTabActive(IntPtr hwndTab, IntPtr hwndInsertBefore, uint dwReserved);

        [PreserveSig]
        long ThumbBarAddButtons(    //之前返回类型是HRESULT
            IntPtr hwnd,
            uint cButtons,
            [MarshalAs(UnmanagedType.LPArray)] THUMBBUTTON[] pButtons);

        [PreserveSig]
        long ThumbBarUpdateButtons(    //之前返回类型是HRESULT
            IntPtr hwnd,
            uint cButtons,
            [MarshalAs(UnmanagedType.LPArray)] THUMBBUTTON[] pButtons);

        [PreserveSig]
        void ThumbBarSetImageList(IntPtr hwnd, IntPtr himl);

        [PreserveSig]
        void SetOverlayIcon(
          IntPtr hwnd,
          IntPtr hIcon,
          [MarshalAs(UnmanagedType.LPWStr)] string pszDescription);

        [PreserveSig]
        void SetThumbnailTooltip(
            IntPtr hwnd,
            [MarshalAs(UnmanagedType.LPWStr)] string pszTip);

        [PreserveSig]
        void SetThumbnailClip(
            IntPtr hwnd,
            ref RECT prcClip);

        // ITaskbarList4
        void SetTabProperties(IntPtr hwndTab, STPFLAG stpFlags);
    }

   
    public struct RECT
    {
        public int Bottom;
        public int Left;
        public int Right;
        public int Top;
    }

    internal enum TBPFLAG
    {
        TBPF_NOPROGRESS = 0,
        TBPF_INDETERMINATE = 0x1,
        TBPF_NORMAL = 0x2,
        TBPF_ERROR = 0x4,
        TBPF_PAUSED = 0x8
    }

    internal enum STPFLAG
    {
        STPF_NONE = 0x0,
        STPF_USEAPPTHUMBNAILALWAYS = 0x1,
        STPF_USEAPPTHUMBNAILWHENACTIVE = 0x2,
        STPF_USEAPPPEEKALWAYS = 0x4,
        STPF_USEAPPPEEKWHENACTIVE = 0x8
    }

    internal enum THBMASK
    {
        THB_BITMAP = 0x1,
        THB_ICON = 0x2,
        THB_TOOLTIP = 0x4,
        THB_FLAGS = 0x8
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]

    internal struct THUMBBUTTON
    {

        /// <summary>
        /// WPARAM value for a THUMBBUTTON being clicked.
        /// </summary>

        internal const int THBN_CLICKED = 0x1800;

        [MarshalAs(UnmanagedType.U4)]
        internal THBMASK dwMask;

        internal uint iId;
        internal uint iBitmap;
        internal IntPtr hIcon;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        internal string szTip;

        [MarshalAs(UnmanagedType.U4)]
        internal THBFLAGS dwFlags;
    }

    [Flags]
    internal enum THBFLAGS
    {
        THBF_ENABLED = 0x00000000,
        THBF_DISABLED = 0x00000001,
        THBF_DISMISSONCLICK = 0x00000002,
        THBF_NOBACKGROUND = 0x00000004,
        THBF_HIDDEN = 0x00000008,
        THBF_NONINTERACTIVE = 0x00000010
    }

    [GuidAttribute("56FDF344-FD6D-11d0-958A-006097C9A090")]
    [ClassInterfaceAttribute(ClassInterfaceType.None)]
    [ComImportAttribute()]
    internal class CTaskbarList { }

}
