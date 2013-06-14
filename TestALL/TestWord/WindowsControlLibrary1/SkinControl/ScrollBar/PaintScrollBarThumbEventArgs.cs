using System;
using System.Drawing;
using System.Windows.Forms;
using CCWin.SkinClass;

namespace CCWin.SkinControl
{
    public class PaintScrollBarThumbEventArgs : IDisposable
    {
        private Graphics _graphics;
        private Rectangle _thumbRect;
        private ControlState _controlState;
        private Orientation _orientation;
        private bool _enabled;

        public PaintScrollBarThumbEventArgs(
           Graphics graphics,
           Rectangle thumbRect,
           ControlState controlState,
           Orientation orientation)
            : this(graphics, thumbRect, controlState, orientation, true)
        {
        }

        public PaintScrollBarThumbEventArgs(
            Graphics graphics,
            Rectangle thumbRect,
            ControlState controlState,
            Orientation orientation,
            bool enabled)
        {
            _graphics = graphics;
            _thumbRect = thumbRect;
            _controlState = controlState;
            _orientation = orientation;
            _enabled = enabled;
        }

        public Graphics Graphics
        {
            get { return _graphics; }
            set { _graphics = value; }
        }

        public Rectangle ThumbRectangle
        {
            get { return _thumbRect; }
            set { _thumbRect = value; }
        }

        public ControlState ControlState
        {
            get { return _controlState; }
            set { _controlState = value; }
        }

        public Orientation Orientation
        {
            get { return _orientation; }
            set { _orientation = value; }
        }

        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        public void Dispose()
        {
            _graphics = null;
        }
    }
}
