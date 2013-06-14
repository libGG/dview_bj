using System;
using System.Runtime.InteropServices;

namespace CCWin.Win32.Struct
{
    [StructLayout(LayoutKind.Sequential)]
    public struct STYLESTRUCT
    {
        public int styleOld;
        public int styleNew;
    }
}
