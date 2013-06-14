using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CCWin
{
    public delegate void SkinFormControlBoxRenderEventHandler(
        object sender,
        SkinFormControlBoxRenderEventArgs e);

    public class SkinFormControlBoxRenderEventArgs : PaintEventArgs
    {
        private CCSkinMain _form;
        private bool _active;
        private ControlBoxState _controlBoxState;
        private ControlBoxStyle _controlBoxStyle;

        public SkinFormControlBoxRenderEventArgs(
            CCSkinMain form,
            Graphics graphics,
            Rectangle clipRect,
            bool active,
            ControlBoxStyle controlBoxStyle,
            ControlBoxState controlBoxState)
            : base(graphics, clipRect)
        {
            _form = form;
            _active = active;
            _controlBoxState = controlBoxState;
            _controlBoxStyle = controlBoxStyle;
        }

        public CCSkinMain Form
        {
            get { return _form; }
        }

        public bool Active
        {
            get { return _active; }
        }

        public ControlBoxStyle ControlBoxStyle
        {
            get { return _controlBoxStyle; }
        }

        public ControlBoxState ControlBoxtate
        {
            get { return _controlBoxState; }
        }
    }
}
