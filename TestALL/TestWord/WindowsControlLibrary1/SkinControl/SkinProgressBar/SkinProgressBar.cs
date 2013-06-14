using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using CCWin.Win32;
using CCWin.SkinClass;
using CCWin.Win32.Const;
using CCWin.Win32.Struct;

namespace CCWin.SkinControl
{
    [ToolboxBitmap(typeof(ProgressBar))]
    public class SkinProgressBar : ProgressBar
    {
        #region ����
        private BufferedGraphicsContext _context;
        private BufferedGraphics _bufferedGraphics;
        private bool _bPainting = false;
        private int _trackX = -100;
        private Timer _timer;
        private string _formatString = "{0:0.0%}";
        private const int Internal = 10;
        private const int MarqueeWidth = 100;
        #endregion

        #region �޲ι���
        public SkinProgressBar()
            : base()
        {
            _context = BufferedGraphicsManager.Current;
            _context.MaximumBuffer = new Size(Width + 1, Height + 1);
            _bufferedGraphics = _context.Allocate(
                CreateGraphics(),
                new Rectangle(Point.Empty, Size));
            ForeColor = Color.Red;
            this.ResizeRedraw = true;
        }
        #endregion

        #region ����
        private bool barGlass = true;
        [DefaultValue(typeof(bool), "true")]
        [Category("Bar")]
        [Description("�������Ƿ�������ɫ����")]
        public bool BarGlass
        {
            get { return barGlass; }
            set
            {
                if (barGlass != value)
                {
                    barGlass = value;
                    base.Invalidate();
                }
            }
        }


        private bool glass = true;
        [DefaultValue(typeof(bool), "true")]
        [Category("Skin")]
        [Description("�ؼ��Ƿ�������ɫ����")]
        public bool Glass
        {
            get { return glass; }
            set
            {
                if (glass != value)
                {
                    glass = value;
                    base.Invalidate();
                }
            }
        }

        private BackStyle barBackStyle = BackStyle.Tile;
        [DefaultValue(typeof(BackStyle), "0")]
        [Category("Bar")]
        [Description("��������ͼ�����ģʽ")]
        public BackStyle BarBackStyle
        {
            get { return barBackStyle; }
            set
            {
                if (barBackStyle != value)
                {
                    barBackStyle = value;
                    base.Invalidate();
                }
            }
        }

        private Size barMinusSize = new Size(1,1);
        [DefaultValue(typeof(Size), "1,1")]
        [Category("Bar")]
        [Description("�Լ���ߡ�")]
        public Size BarMinusSize
        {
            get { return barMinusSize; }
            set
            {
                if (barMinusSize != value)
                {

                    barMinusSize = value;
                    base.Invalidate();
                }
            }
        }

        private bool txtShow = true;
        [Category("Skin")]
        [DefaultValue(typeof(bool), "true")]
        [Description("�Ƿ���ʾ���Ȱٷֱ�")]
        public bool TxtShow 
        {
            get { return txtShow; }
            set
            {
                if (txtShow != value)
                {
                    txtShow = value;
                    base.Invalidate();
                }
            }
        }

        private int radius = 2;
        [Category("Skin")]
        [DefaultValue(typeof(int),"2")]
        [Description("�ؼ�Բ�Ǵ�С")]
        public int Radius
        {
            get { return radius; }
            set
            {
                if (radius != value)
                {
                    radius = value < 1 ? 1 : value;
                    SetRegion();
                    base.Invalidate();
                }
            }
        }

        private RoundStyle radiusStyle = RoundStyle.All;
        [Category("Skin")]
        [DefaultValue(typeof(RoundStyle), "1")]
        [Description("�ؼ�Բ����ʽ")]
        public RoundStyle RadiusStyle
        {
            get { return radiusStyle; }
            set
            {
                if (radiusStyle != value)
                {
                    radiusStyle = value;
                    SetRegion();
                    base.Invalidate();
                }
            }
        }

        private int barradius = 2;
        [Category("Bar")]
        [DefaultValue(typeof(int), "2")]
        [Description("������Բ�Ǵ�С")]
        public int BarRadius
        {
            get { return barradius; }
            set
            {
                if (barradius != value)
                {
                    barradius = value < 1 ? 1 : value;
                    base.Invalidate();
                }
            }
        }

        private RoundStyle barradiusStyle = RoundStyle.All;
        [Category("Bar")]
        [DefaultValue(typeof(RoundStyle), "1")]
        [Description("������Բ����ʽ")]
        public RoundStyle BarRadiusStyle
        {
            get { return barradiusStyle; }
            set
            {
                if (barradiusStyle != value)
                {
                    barradiusStyle = value;
                    base.Invalidate();
                }
            }
        }

        private Image back;
        [Category("Skin")]
        [Description("�ؼ�����ͼƬ")]
        public Image Back
        {
            get { return back; }
            set
            {
                if (back != value)
                {
                    back = value;
                    base.Invalidate();
                }
            }
        }

        private Image barBack;
        [Category("Bar")]
        [Description("������ͼƬ")]
        public Image BarBack
        {
            get { return barBack; }
            set
            {
                if (barBack != value)
                {
                    barBack = value;
                    base.Invalidate();
                }
            }
        }

        /// <summary>
        /// ��ʾ���������Ϣ�ĸ�ʽ���ַ�����
        /// </summary>
        [Category("Skin")]
        [DefaultValue("{0:0.0%}")]
        public string FormatString
        {
            get { return _formatString; }
            set
            {
                if (_formatString != value)
                {
                    _formatString = value;
                    base.Invalidate();
                }
            }
        }

        private Color _trackBack = Color.FromArgb(185, 185, 185);
        [Category("Skin")]
        [DefaultValue(typeof(Color), "185, 185, 185")]
        public Color TrackBack
        {
            get 
            {
                return _trackBack; 
            }
            set 
            {
                if (_trackBack != value)
                {
                    _trackBack = value;
                    base.Invalidate();
                }
            }
        }

        private Color _trackFore = Color.FromArgb(15, 181, 43);
        [Category("Bar")]
        [DefaultValue(typeof(Color), "15, 181, 43")]
        public Color TrackFore
        {
            get
            {
                return _trackFore;
            }
            set
            {
                if (_trackFore != value)
                {
                    _trackFore = value;
                    base.Invalidate();
                }
            }
        }

        private Color _border = Color.FromArgb(158, 158, 158);
        [Category("Skin")]
        [DefaultValue(typeof(Color), "158, 158, 158")]
        public Color Border
        {
            get
            {
                return _border;
            }
            set
            {
                if (_border != value)
                {
                    _border = value;
                    base.Invalidate();
                }
            }
        }

        private Color _innerBorder = Color.FromArgb(200, 250, 250, 250);
        [Category("Skin")]
        [DefaultValue(typeof(Color),"200, 250, 250, 250")]
        public Color InnerBorder
        {
            get
            {
                return _innerBorder;
            }
            set
            {
                if (_innerBorder != value)
                {
                    _innerBorder = value;
                    base.Invalidate();
                }
            }
        }

        public new ProgressBarStyle Style
        {
            get { return base.Style; }
            set
            {
                if (base.Style != value)
                {
                    base.Style = value;

                    if (value == ProgressBarStyle.Marquee)
                    {
                        if (_timer != null)
                        {
                            _timer.Dispose();
                        }

                        _timer = new Timer();
                        _timer.Interval = Internal;
                        _timer.Tick += delegate(object sender, EventArgs e)
                        {
                            _trackX += (int)Math.Ceiling((float)Width / base.MarqueeAnimationSpeed);
                            if (_trackX > Width)
                            {
                                _trackX = -MarqueeWidth;
                            }
                            base.Invalidate();
                        };

                        if (!base.DesignMode)
                        {
                            _timer.Start();
                        }
                    }
                    else
                    {
                        if (_timer != null)
                        {
                            _timer.Dispose();
                            _timer = null;
                        }
                    }
                }
            }
        }

        [Browsable(true)]
        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }
        #endregion

        #region �����¼�
        //�ؼ��״δ���ʱ������
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetRegion();
        }

        //�ı䴰���Сʱ
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            SetRegion();

            _context.MaximumBuffer = new Size(Width + 1, Height + 1);
            if (_bufferedGraphics != null)
            {
                _bufferedGraphics.Dispose();
                _bufferedGraphics = null;
            }

            _bufferedGraphics = _context.Allocate(
                CreateGraphics(),
                new Rectangle(Point.Empty, Size));
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM.WM_PAINT:
                    if (!_bPainting)
                    {
                        _bPainting = true;

                        PAINTSTRUCT ps = new PAINTSTRUCT();

                        NativeMethods.BeginPaint(m.HWnd, ref ps);

                        try
                        {
                            DrawProgressBar(m.HWnd);
                        }
                        catch
                        {
                        }

                        NativeMethods.ValidateRect(m.HWnd, ref ps.rcPaint);
                        NativeMethods.EndPaint(m.HWnd, ref ps);

                        _bPainting = false;
                        m.Result = Result.TRUE;
                    }
                    else
                    {
                        base.WndProc(ref m);
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (_timer != null)
                {
                    _timer.Dispose();
                    _timer = null;
                }

                if (_bufferedGraphics != null)
                {
                    _bufferedGraphics.Dispose();
                    _bufferedGraphics = null;
                }

                if (_context != null)
                {
                    _context = null;
                }
            }
        }

        #endregion

        #region �滭����
        private void DrawProgressBar(IntPtr hWnd)
        {
            Graphics g = _bufferedGraphics.Graphics;
            g.Clear(Color.Transparent);
            Rectangle rect = new Rectangle(Point.Empty, Size);

            bool bBlock = Style != ProgressBarStyle.Marquee || base.DesignMode;
            float basePosition = bBlock ? .30f : .45f;

            SmoothingModeGraphics sg = new SmoothingModeGraphics(g);
            if (Back != null)
            {
                Bitmap btm = new Bitmap(Back,this.Size);
                UpdateForm.CreateControlRegion(this, btm, 200);
                g.DrawImage(Back, rect);
            }
            else
            {
                RenderHelper.RenderBackgroundInternal(
                    g,
                    rect,
                    TrackBack,
                    Border,
                    InnerBorder,
                    RadiusStyle,
                    Radius,
                    basePosition,
                    true,
                    Glass,
                    LinearGradientMode.Vertical);
            }
            Rectangle trackRect = rect;
            trackRect.Inflate(-BarMinusSize.Width, -BarMinusSize.Height);
            if (bBlock)
            {
                trackRect.Width = (int)(((double)Value / (Maximum - Minimum)) * trackRect.Width);
                if (BarBack != null)
                {
                    if(BarBackStyle == BackStyle.Tile)
                    {
                        using (TextureBrush Txbrus = new TextureBrush(BarBack))
                        {
                            Txbrus.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                            g.FillRectangle(Txbrus, trackRect);
                        }

                    }
                    else
                    {
                        Bitmap btm = new Bitmap(BarBack, this.Size);
                        g.DrawImageUnscaledAndClipped(btm, trackRect);
                    }
                }
                else
                {
                    RenderHelper.RenderBackgroundInternal(
                        g,
                        trackRect,
                        TrackFore,
                        Border,
                        InnerBorder,
                        BarRadiusStyle,
                        BarRadius,
                        basePosition,
                        false,
                        BarGlass,
                        LinearGradientMode.Vertical);
                }
                if (!string.IsNullOrEmpty(_formatString) && TxtShow)
                {
                    TextRenderer.DrawText(
                        g,
                        string.Format(_formatString, (double)Value / (Maximum - Minimum)),
                        base.Font,
                        rect,
                        base.ForeColor,
                        TextFormatFlags.VerticalCenter |
                        TextFormatFlags.HorizontalCenter |
                        TextFormatFlags.SingleLine |
                        TextFormatFlags.WordEllipsis);
                }
            }
            else
            {
                GraphicsState state = g.Save();

                g.SetClip(trackRect);

                trackRect.X = _trackX;
                trackRect.Width = MarqueeWidth;

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(trackRect);
                    g.SetClip(path, CombineMode.Intersect);
                }

                RenderHelper.RenderBackgroundInternal(
                    g,
                    trackRect,
                    TrackFore,
                    Border,
                    InnerBorder,
                    RoundStyle.None,
                    8,
                    basePosition,
                    false,
                    BarGlass,
                    LinearGradientMode.Vertical);

                using (LinearGradientBrush brush = new LinearGradientBrush(
                    trackRect, InnerBorder, Color.Transparent, 0f))
                {
                    Blend blend = new Blend();
                    blend.Factors = new float[] { 0f, 1f, 0f };
                    blend.Positions = new float[] { 0f, .5f, 1f };
                    brush.Blend = blend;

                    g.FillRectangle(brush, trackRect);
                }

                g.Restore(state);
            }

            sg.Dispose();

            IntPtr hDC = NativeMethods.GetDC(hWnd);
            _bufferedGraphics.Render(hDC);
            NativeMethods.ReleaseDC(hWnd, hDC);
        }

        //ʵ��Բ��
        private void SetRegion()
        {
            RegionHelper.CreateRegion(this, new Rectangle(Point.Empty, Size), Radius, RadiusStyle);
        }
        #endregion
    }
}
