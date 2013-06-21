using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SmileWei.EmbeddedApp.WinForm
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnBrowseApp_Click(object sender, EventArgs e)
        {
            if (openApp.ShowDialog(this)== DialogResult.OK)
            {
                appBox.AppFilename = openApp.FileName;
                appBox.Start();
                if (appBox.IsStarted)
                {
                    txtAppFilename.Text = appBox.AppFilename;
                }
            }
        }

        private void lblEmbedAgain_Click(object sender, EventArgs e)
        {
            appBox.EmbedAgain();
        }

        private void lblEmbedHandle_Click(object sender, EventArgs e)
        {
            var frmHandle = new FormHandle();
            if (frmHandle.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                var handle = frmHandle.GetHandle();
                SetParent(handle, this.Handle);
                SetWindowLong(handle, GWL_STYLE, WS_VISIBLE);                
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private const int GWL_STYLE = (-16);
        private const long WS_VISIBLE = 0x10000000;
        [DllImport("user32.dll", EntryPoint = "SetWindowLongA", SetLastError = true)]
        private static extern long SetWindowLong(IntPtr hwnd, int nIndex, long dwNewLong);

    }
}
