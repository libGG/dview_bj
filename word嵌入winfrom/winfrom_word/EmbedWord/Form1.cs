using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace EmbedWord
{
    public partial class Form1 : Form
    {
        //private 
        public Form1()
        {
            InitializeComponent();
        }















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


        private const int MF_BYPOSITION = 0x400;
        private const int MF_REMOVE = 0x1000;


        const int SWP_DRAWFRAME = 0x20;
        const int SWP_NOMOVE = 0x2;
        const int SWP_NOSIZE = 0x1;
        const int SWP_NOZORDER = 0x4;

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}