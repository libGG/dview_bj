using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        Process process = null;
        IntPtr appWin;
        private string exeName = "";


        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
        [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId", SetLastError = true,
            CharSet = CharSet.Unicode, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        private static extern long GetWindowThreadProcessId(long hWnd, long lpdwProcessId);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongA", SetLastError = true)]
        private static extern long GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongA", SetLastError = true)]
        private static extern long SetWindowLong(IntPtr hwnd, int nIndex, long dwNewLong);
        //private static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetWindowPos(IntPtr hwnd, long hWndInsertAfter, long x, long y, long cx, long cy, long wFlags);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);
        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hwnd, uint Msg, long wParam, long lParam);
        private const int SWP_NOOWNERZORDER = 0x200;
        private const int SWP_NOREDRAW = 0x8;
        private const int SWP_NOZORDER = 0x4;
        private const int SWP_SHOWWINDOW = 0x0040;
        private const int WS_EX_MDICHILD = 0x40;
        private const int SWP_FRAMECHANGED = 0x20;
        private const int SWP_NOACTIVATE = 0x10;
        private const int SWP_ASYNCWINDOWPOS = 0x4000;
        private const int SWP_NOMOVE = 0x2;
        private const int SWP_NOSIZE = 0x1;
        private const int GWL_STYLE = (-16);
        private const int WS_VISIBLE = 0x10000000;
        private const int WM_CLOSE = 0x10;
        private const int WS_CHILD = 0x40000000;
        public string ExeName
        {
            get
            {
                return exeName;
            }
            set
            {
                exeName = value;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.exeName = @"C:\Program Files (x86)\Microsoft Office\Office12\WINWORD.exe";
            //try
            //{
            //    // Start the process 
            //    process = System.Diagnostics.Process.Start(this.exeName);
            //    // Wait for process to be created and enter idle condition 
            //    process.WaitForInputIdle();
            //    // Get the main handle
            //    appWin = process.MainWindowHandle;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(this, ex.Message, "Error");
            //}
            //// Put it into this form
            //SetParent(appWin, this.Handle);
            //// Remove border and whatnot
            //SetWindowLong(appWin, GWL_STYLE, WS_VISIBLE);
            //// Move the window to overlay it on this window
            //MoveWindow(appWin, 0, 0, this.Width, this.Height, true);
            load();

        }


        private void load()
        {
            //Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();

            //获取计算器窗口句柄  
            IntPtr hwnd = FindWindow("Opusapp", null);//计算器
            if (hwnd != IntPtr.Zero)
            {
                int calcID;
                //获取进程ID  
                GetWindowThreadProcessId(hwnd, out calcID);
                Process p = Process.GetProcessById(calcID); //MainWindowHandle主窗口句柄，Handle
                MessageBox.Show(calcID.ToString());
            }
            else
            {
                MessageBox.Show("没有找到计算器窗口");
            }  
            //object aa= Marshal.getobject
            //app.Visible = true;
            //SetParent(hwnd, this.Handle);
            //// Remove border and whatnot
            //SetWindowLong(hwnd, GWL_STYLE, WS_VISIBLE);
            //// Move the window to overlay it on this window
            //MoveWindow(hwnd, 0, 0, this.Width, this.Height, true);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //process.Kill();
            }
            catch { }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.appWin != IntPtr.Zero)
            {
                MoveWindow(appWin, 0, 0, this.Width, this.Height, true);
            }
            //base.OnResize(e);
        }
    }
}