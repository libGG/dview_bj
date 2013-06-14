using System;
using System.Drawing;
using System.Runtime.InteropServices;
using CCWin.Win32.Const;

namespace CCWin.Win32.Struct
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TCHITTESTINFO
    {

        public TCHITTESTINFO(Point location)
        {
            Point = location;
            Flags = TCHT.TCHT_ONITEM;
        }

        public Point Point;
        public int Flags;
    }
}
