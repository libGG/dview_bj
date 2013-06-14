using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.ComponentModel;
using CCWin.Imaging;
using CCWin.SkinClass;

namespace CCWin.SkinControl
{
    public class SkinVScrollBar : VScrollBar, IScrollBarPaint
    {
        private ScrollBarManager _manager;
        public SkinVScrollBar()
            : base()
        {
        }

        #region 属性与变量
        private Color _base = Color.FromArgb(171, 230, 247);
        public Color Base
        {
            get { return _base; }
            set 
            {
                if (_base != value)
                {
                    _base = value;
                    this.Invalidate();
                }
            }
        }

        private Color _backNormal = Color.FromArgb(235, 249, 253);
        public Color BackNormal
        {
            get { return _backNormal; }
            set
            {
                if (_backNormal != value)
                {
                    _backNormal = value;
                    this.Invalidate();
                }
            }
        }

        private Color _backHover = Color.FromArgb(121, 216, 243);
        public Color BackHover
        {
            get { return _backHover; }
            set
            {
                if (_backHover != value)
                {
                    _backHover = value;
                    this.Invalidate();
                }
            }
        }

        private Color _backPressed = Color.FromArgb(70, 202, 239);
        public Color BackPressed
        {
            get { return _backPressed; }
            set
            {
                if (_backPressed != value)
                {
                    _backPressed = value;
                    this.Invalidate();
                }
            }
        }

        private Color _border = Color.FromArgb(89, 210, 249);
        public Color Border
        {
            get { return _border; }
            set
            {
                if (_border != value)
                {
                    _border = value;
                    this.Invalidate();
                }
            }
        }

        private Color _innerBorder = Color.FromArgb(200, 250, 250, 250);
        public Color InnerBorder
        {
            get { return _innerBorder; }
            set
            {
                if (_innerBorder != value)
                {
                    _innerBorder = value;
                    this.Invalidate();
                }
            }
        }

        private Color _fore = Color.FromArgb(48, 135, 192);
        public Color Fore
        {
            get { return _fore; }
            set
            {
                if (_fore != value)
                {
                    _fore = value;
                    this.Invalidate();
                }
            }
        }
        #endregion

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (_manager != null)
            {
                _manager.Dispose();
            }
            if (!this.DesignMode)
            {
                _manager = new ScrollBarManager(this);
            }
        }

        //protected override void OnSizeChanged(EventArgs e)
        //{
        //    base.OnSizeChanged(e);
        //    if (this.DesignMode)
        //    {
        //        if (_manager != null)
        //        {
        //            _manager.Dispose();
        //        }
        //        _manager = new ScrollBarManager(this);
        //    }
        //}

        //protected override void OnLocationChanged(EventArgs e)
        //{
        //    base.OnLocationChanged(e);
        //    if (this.DesignMode)
        //    {
        //        if (_manager != null)
        //        {
        //            _manager.Dispose();
        //        }
        //        _manager = new ScrollBarManager(this);
        //    }
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_manager != null)
                {
                    _manager.Dispose();
                    _manager = null;
                }
            }
            base.Dispose(disposing);
        }

        internal protected virtual void OnPaintScrollBarTrack(
            PaintScrollBarTrackEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.TrackRectangle;

            Color baseColor = GetGray(Base);

            ControlPaintEx.DrawScrollBarTrack(
                g, rect, baseColor, Color.White, e.Orientation);
        }

        internal protected virtual void OnPaintScrollBarArrow(
           PaintScrollBarArrowEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.ArrowRectangle;
            ControlState controlState = e.ControlState;
            ArrowDirection direction = e.ArrowDirection;
            bool bHorizontal = e.Orientation == Orientation.Horizontal;
            bool bEnabled = e.Enabled;

            Color backColor = BackNormal;
            Color baseColor = Base;
            Color borderColor = Border;
            Color innerBorderColor = InnerBorder;
            Color foreColor = Fore;

            bool changeColor = false;

            if (bEnabled)
            {
                switch (controlState)
                {
                    case ControlState.Hover:
                        baseColor = BackHover;
                        break;
                    case ControlState.Pressed:
                        baseColor = BackPressed;
                        changeColor = true;
                        break;
                    default:
                        baseColor = Base;
                        break;
                }
            }
            else
            {
                backColor = GetGray(backColor);
                baseColor = GetGray(Base);
                borderColor = GetGray(borderColor);
                foreColor = GetGray(foreColor);
            }

            using (SmoothingModeGraphics sg = new SmoothingModeGraphics(g))
            {
                ControlPaintEx.DrawScrollBarArraw(
                    g,
                    rect,
                    baseColor,
                    backColor,
                    borderColor,
                    innerBorderColor,
                    foreColor,
                    e.Orientation,
                    direction,
                    changeColor);
            }
        }

        internal protected virtual void OnPaintScrollBarThumb(
           PaintScrollBarThumbEventArgs e)
        {
            bool bEnabled = e.Enabled;
            if (!bEnabled)
            {
                return;
            }

            Graphics g = e.Graphics;
            Rectangle rect = e.ThumbRectangle;
            ControlState controlState = e.ControlState;

            Color backColor = BackNormal;
            Color baseColor = Base;
            Color borderColor = Border;
            Color innerBorderColor = InnerBorder;

            bool changeColor = false;

            switch (controlState)
            {
                case ControlState.Hover:
                    baseColor = BackHover;
                    break;
                case ControlState.Pressed:
                    baseColor = BackPressed;
                    changeColor = true;
                    break;
                default:
                    baseColor = Base;
                    break;
            }

            using (SmoothingModeGraphics sg = new SmoothingModeGraphics(g))
            {
                ControlPaintEx.DrawScrollBarThumb(
                    g,
                    rect,
                    baseColor,
                    backColor,
                    borderColor,
                    innerBorderColor,
                    e.Orientation,
                    changeColor);
            }
        }

        private Color GetGray(Color color)
        {
            return ColorConverterEx.RgbToGray(
                new RGB(color)).Color;
        }

        #region IScrollBarPaint 成员

        void IScrollBarPaint.OnPaintScrollBarArrow(PaintScrollBarArrowEventArgs e)
        {
            OnPaintScrollBarArrow(e);
        }

        void IScrollBarPaint.OnPaintScrollBarThumb(PaintScrollBarThumbEventArgs e)
        {
            OnPaintScrollBarThumb(e);
        }

        void IScrollBarPaint.OnPaintScrollBarTrack(PaintScrollBarTrackEventArgs e)
        {
            OnPaintScrollBarTrack(e);
        }

        #endregion
    }
}
