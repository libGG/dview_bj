using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CCWin
{
    public delegate void SkinFormBorderRenderEventHandler(
        object sender,
        SkinFormBorderRenderEventArgs e);

    public class SkinFormBorderRenderEventArgs : PaintEventArgs
    {
        private CCSkinMain _skinForm;
        private bool _active;

        public SkinFormBorderRenderEventArgs(
            CCSkinMain skinForm,
            Graphics g,
            Rectangle clipRect,
            bool active)
            : base(g, clipRect)
        {
            _skinForm = skinForm;
            _active = active;
        }

        public CCSkinMain SkinForm
        {
            get { return _skinForm; }
        }

        public bool Active
        {
            get { return _active; }
        }
    }
}
