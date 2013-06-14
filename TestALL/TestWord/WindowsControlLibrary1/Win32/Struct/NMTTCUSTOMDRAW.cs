using System;
using System.Runtime.InteropServices;

namespace CCWin.Win32.Struct
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NMTTCUSTOMDRAW
    {
        public NMCUSTOMDRAW nmcd;
        public uint uDrawFlags;
    }
}
