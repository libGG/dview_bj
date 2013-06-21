using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsApplication3
{
    public partial class Form2 : Form
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);


        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //获取计算器窗口句柄  
            IntPtr hwnd = FindWindow(null, "QQ2013");//计算器
            if (hwnd != IntPtr.Zero)
            {
                int calcID;
                //获取进程ID  
                GetWindowThreadProcessId(hwnd, out calcID);
                MessageBox.Show(calcID.ToString());//Marshal.GetActiveObject(
            }
            else
            {
                MessageBox.Show("没有找到计算器窗口");
            }  
        }



        #region "API usage declarations"

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string strclassName, string strWindowName);

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


        private const int MF_BYPOSITION = 0x400;
        private const int MF_REMOVE = 0x1000;


        const int SWP_DRAWFRAME = 0x20;
        const int SWP_NOMOVE = 0x2;
        const int SWP_NOSIZE = 0x1;
        const int SWP_NOZORDER = 0x4;

        #endregion
    }
}