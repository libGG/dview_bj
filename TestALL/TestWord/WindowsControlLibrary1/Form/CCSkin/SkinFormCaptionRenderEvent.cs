using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CCWin
{
    public delegate void SkinFormCaptionRenderEventHandler(
        object sender,
        SkinFormCaptionRenderEventArgs e);

    public class SkinFormCaptionRenderEventArgs : PaintEventArgs
    {
        private CCSkinMain _skinForm;
        private bool _active;

        public SkinFormCaptionRenderEventArgs(
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
