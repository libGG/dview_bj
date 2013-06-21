using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public class NativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, UInt32 uflags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(int hWnd, int msg, int wParam, int lParam);
        public delegate int EnumWindowsProc(IntPtr hwnd, int lParam);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindow(IntPtr hWnd, int uCmd);

        [DllImport("user32")]
        public static extern IntPtr WindowFromPoint(Point point);//根据鼠标指针所在位置，得到窗口句柄


        #region 预定义

        public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        public static readonly IntPtr HWND_TOP = new IntPtr(0);
        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        public static readonly UInt32 SWP_NOSIZE = 1;
        public static readonly UInt32 SWP_NOMOVE = 2;
        public static readonly UInt32 SWP_NOZORDER = 4;
        public static readonly UInt32 SWP_NOREDRAW = 8;
        public static readonly UInt32 SWP_NOACTIVATE = 16;
        public static readonly UInt32 SWP_FRAMECHANGED = 32;
        public static readonly UInt32 SWP_SHOWWINDOW = 64;
        public static readonly UInt32 SWP_HIDEWINDOW = 128;
        public static readonly UInt32 SWP_NOCOPYBITS = 256;
        public static readonly UInt32 SWP_NOOWNERZORDER = 512;
        public static readonly UInt32 SWP_NOSENDCHANGING = 1024;

        #endregion
        
        public static int GW_CHILD = 5;
        public static int GW_HWNDNEXT = 2;
        public static readonly Int32 WM_QUIT = 0x0012;
        public static readonly Int32 WM_HIDE = 0x0;
    }
}
