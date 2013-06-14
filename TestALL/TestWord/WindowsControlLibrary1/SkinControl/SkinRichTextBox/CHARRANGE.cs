using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CCWin.SkinControl
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CHARRANGE
    {
        public int cpMin;
        public int cpMax;
    }
}
