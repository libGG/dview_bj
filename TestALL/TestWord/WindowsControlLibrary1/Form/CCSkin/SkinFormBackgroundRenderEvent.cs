using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CCWin
{
     public delegate void SkinFormBackgroundRenderEventHandler(
        object sender,
        SkinFormBackgroundRenderEventArgs e);

    public class SkinFormBackgroundRenderEventArgs : PaintEventArgs
    {
        private CCSkinMain _skinForm;

        public SkinFormBackgroundRenderEventArgs(
            CCSkinMain skinForm,
            Graphics g,
            Rectangle clipRect)
            : base(g, clipRect)
        {
            _skinForm = skinForm;
        }

        public CCSkinMain SkinForm
        {
            get { return _skinForm; }
        }
    }
}
