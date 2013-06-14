using System;
using System.Collections.Generic;
using System.Text;

namespace CCWin.Win32.Callback
{
    public delegate int HookProc(int ncode, IntPtr wParam, IntPtr lParam);
}
