using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using WindowsFormsApplication1;

namespace WindowsApplication3
{
    public partial class Form1 : Form
    {
        #region "API usage declarations"

        [DllImport("user32.dll")]
        public static extern int FindWindow(string strclassName, string strWindowName);

        [DllImport("user32.dll")]
        static extern int SetParent(int hWndChild, int hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(
            int hWnd,               // handle to window
            int hWndInsertAfter,    // placement-order handle
            int X,                  // horizontal position
            int Y,                  // vertical position
            int cx,                 // width
            int cy,                 // height
            uint uFlags             // window-positioning options
            );

        [DllImport("user32.dll", EntryPoint = "MoveWindow")]
        static extern bool MoveWindow(
            int Wnd,
            int X,
            int Y,
            int Width,
            int Height,
            bool Repaint
            );

        [DllImport("user32.dll", EntryPoint = "DrawMenuBar")]
        static extern Int32 DrawMenuBar(
            Int32 hWnd
            );

        [DllImport("user32.dll", EntryPoint = "GetMenuItemCount")]
        static extern Int32 GetMenuItemCount(
            Int32 hMenu
            );

        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")]
        static extern Int32 GetSystemMenu(
            Int32 hWnd,
            bool Revert
            );

        [DllImport("user32.dll", EntryPoint = "RemoveMenu")]
        static extern Int32 RemoveMenu(
            Int32 hMenu,
            Int32 nPosition,
            Int32 wFlags
            );



        [DllImport("user32.dll", EntryPoint = "GetWindowLongA", SetLastError = true)]
        private static extern long GetWindowLong(IntPtr hwnd, int nIndex);

        public static IntPtr SetWindowLong(HandleRef hWnd, int nIndex, int dwNewLong)
        {
            if (IntPtr.Size == 4)
            {
                return SetWindowLongPtr32(hWnd, nIndex, dwNewLong);
            }
            return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
        }
        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLongPtr32(HandleRef hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLongPtr64(HandleRef hWnd, int nIndex, int dwNewLong);



        private const int MF_BYPOSITION = 0x400;
        private const int MF_REMOVE = 0x1000;


        const int SWP_DRAWFRAME = 0x20;
        const int SWP_NOMOVE = 0x2;
        const int SWP_NOSIZE = 0x1;
        const int SWP_NOZORDER = 0x4;





        private const int SWP_NOOWNERZORDER = 0x200;
        private const int SWP_NOREDRAW = 0x8;
        //private const int SWP_NOZORDER = 0x4;
        private const int SWP_SHOWWINDOW = 0x0040;
        private const int WS_EX_MDICHILD = 0x40;
        private const int SWP_FRAMECHANGED = 0x20;
        private const int SWP_NOACTIVATE = 0x10;
        private const int SWP_ASYNCWINDOWPOS = 0x4000;
        //private const int SWP_NOMOVE = 0x2;
        //private const int SWP_NOSIZE = 0x1;
        private const int GWL_STYLE = (-16);
        private const int WS_VISIBLE = 0x10000000;
        private const int WM_CLOSE = 0x10;
        private const int WS_CHILD = 0x40000000;

        private const int SW_HIDE = 0; //{隐藏, 并且任务栏也没有最小化图标}
        private const int SW_SHOWNORMAL = 1; //{用最近的大小和位置显示, 激活}
        private const int SW_NORMAL = 1; //{同 SW_SHOWNORMAL}
        private const int SW_SHOWMINIMIZED = 2; //{最小化, 激活}
        private const int SW_SHOWMAXIMIZED = 3; //{最大化, 激活}
        private const int SW_MAXIMIZE = 3; //{同 SW_SHOWMAXIMIZED}
        private const int SW_SHOWNOACTIVATE = 4; //{用最近的大小和位置显示, 不激活}
        private const int SW_SHOW = 5; //{同 SW_SHOWNORMAL}
        private const int SW_MINIMIZE = 6; //{最小化, 不激活}
        private const int SW_SHOWMINNOACTIVE = 7; //{同 SW_MINIMIZE}
        private const int SW_SHOWNA = 8; //{同 SW_SHOWNOACTIVATE}
        private const int SW_RESTORE = 9; //{同 SW_SHOWNORMAL}
        private const int SW_SHOWDEFAULT = 10; //{同 SW_SHOWNORMAL}
        private const int SW_MAX = 10; //{同 SW_SHOWNORMAL}

        #endregion

        //private Microsoft.Office.Interop.Word._Application _app;
        private Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
        int wordWnd;
        private string _caption = "";
        public Form1()
        {
            app.Caption = _caption =DateTime.Now.ToShortTimeString();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //app.Caption = "hello word!";
            wordWnd = FindWindow(null, _caption);//"Opusapp" 
            app.Visible = true;
            SetParent(wordWnd, (int)this.Handle);
          
            SetWindowLong(new HandleRef(this, (IntPtr)wordWnd), GWL_STYLE, WS_VISIBLE);
            SetWindowLong(new HandleRef(this, (IntPtr)wordWnd), -16, 369164288);
            
            //Process.Start("winword.exe");
            // Move the window to overlay it on this window
            MoveWindow(wordWnd, 0, 0, this.Width, this.Height, true);//true
            //int a = app.ActiveWindow.Application.CommandBars.Count;
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Process p = Process.GetProcessById(wordWnd);
            //app.DocumentBeforeClose += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeCloseEventHandler(app_DocumentBeforeClose);
        }

        void app_DocumentBeforeClose(Microsoft.Office.Interop.Word.Document Doc, ref bool Cancel)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        //protected override void OnResize(EventArgs e)
        //{
        //    MoveWindow(wordWnd, 0, 0, this.Width, this.Height, true);//true
        //    base.OnResize(e);
        //}

        private void 插入书签ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object timeout = 5000;
            app.Dialogs[Microsoft.Office.Interop.Word.WdWordDialog.wdDialogInsertBookmark].Show(ref timeout);

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //MoveWindow(wordWnd, 0, 0, this.Width, this.Height, true);//true
            int borderWidth = SystemInformation.Border3DSize.Width;
            int borderHeight = SystemInformation.Border3DSize.Height;
            int captionHeight = SystemInformation.CaptionHeight;
            int statusHeight = SystemInformation.ToolWindowCaptionHeight;
            MoveWindow(
                wordWnd,
                -2 * borderWidth,
                -2 * borderHeight - captionHeight,
                this.Bounds.Width + 4 * borderWidth,
                this.Bounds.Height + captionHeight + 4 * borderHeight + statusHeight,
                true);
        }


    }
}