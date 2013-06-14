using System;
using System.Drawing;
using System.Windows.Forms;

namespace CCWin.SkinControl
{
    public class PaintScrollBarTrackEventArgs : IDisposable
    {
        private Graphics _graphics;
        private Rectangle _trackRect;
        private Orientation _orientation;
        private bool _enabled;

        public PaintScrollBarTrackEventArgs(
            Graphics graphics,
            Rectangle trackRect,
            Orientation orientation)
            : this(graphics, trackRect, orientation, true)
        {
        }

        public PaintScrollBarTrackEventArgs(
            Graphics graphics,
            Rectangle trackRect,
            Orientation orientation,
            bool enabled)
        {
            _graphics = graphics;
            _trackRect = trackRect;
            _orientation = orientation;
            _enabled = enabled;
        }

        public Graphics Graphics
        {
            get { return _graphics; }
            set { _graphics = value; }
        }

        public Rectangle TrackRectangle
        {
            get { return _trackRect; }
            set { _trackRect = value; }
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
