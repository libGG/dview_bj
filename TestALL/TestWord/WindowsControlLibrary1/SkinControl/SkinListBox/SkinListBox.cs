using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using CCWin.Win32;
using CCWin.Win32.Struct;
using CCWin.Win32.Const;
using CCWin.SkinClass;

namespace CCWin.SkinControl
{
    [ToolboxBitmap(typeof(ListBox))]
    public class SkinListBox : ListBox
    {
        #region 变量
        private Color _rowBackColor1 = Color.White;
        private Color _rowBackColor2 = Color.FromArgb(254, 216, 249);
        private Color _selectedColor = Color.FromArgb(102, 206, 255);
        private Color _borderColor = Color.FromArgb(55, 126, 168);
        private SkinListBoxItemCollection _items;
        #endregion

        #region 无参构造
        public SkinListBox()
            : base()
        {
            _items = new SkinListBoxItemCollection(this);
            base.DrawMode = DrawMode.OwnerDrawFixed;
            this.SetStyle(ControlStyles.UserPaint, true);//自行绘制
            this.SetStyle(ControlStyles.DoubleBuffer, true);// 双缓冲
            this.SetStyle(ControlStyles.ResizeRedraw, true);//调整大小时重绘
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);// 双缓冲            
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
        #endregion

        #region 属性
        [Localizable(true)]
        [MergableProperty(false)]
        [DesignerSerializationVisibility(
            DesignerSerializationVisibility.Content)]
        public new SkinListBoxItemCollection Items
        {
            get { return _items; }
        }

        private RoundStyle item_roundStyle = RoundStyle.None;
        [Category("Item")]
        [DefaultValue(typeof(RoundStyle), "0")]
        [Description("设置或获取Item圆角的样式")]
        public RoundStyle ItemRoundStyle
        {
            get { return item_roundStyle; }
            set
            {
                if (item_roundStyle != value)
                {
                    item_roundStyle = value;
                    base.Invalidate();
                }
            }
        }

        private int itemradius = 8;
        /// <summary>
        /// 圆角大小
        /// </summary>
        [DefaultValue(typeof(int), "8")]
        [Category("Item")]
        [Description("Item圆角大小")]
        public int ItemRadius
        {
            get
            {
                return itemradius;
            }
            set
            {
                if (itemradius != value)
                {
                    itemradius = value < 4 ? 4 : value;
                    this.Invalidate();
                }
            }
        }

        private bool imageVisble = true;
        [DefaultValue(typeof(bool), "true")]
        [Category("Item")]
        [Description("Item是否需要Image图标")]
        public bool ImageVisble
        {
            get { return imageVisble; }
            set
            {
                imageVisble = value;
                base.Invalidate();
            }
        }


        private bool itemBorderVisble = true;
        [DefaultValue(typeof(bool), "true")]
        [Category("Item")]
        [Description("Item选中与悬浮时是否需要边框效果")]
        public bool ItemBorderVisble
        {
            get { return itemBorderVisble; }
            set
            {
                itemBorderVisble = value;
                base.Invalidate();
            }
        }

        private bool itemGlassVisble = true;
        [DefaultValue(typeof(bool), "true")]
        [Category("Item")]
        [Description("Item选中时是否需要Glass填充")]
        public bool ItemGlassVisble
        {
            get { return itemGlassVisble; }
            set
            {
                itemGlassVisble = value;
                base.Invalidate();
            }
        }

        private bool itemHoverGlassVisble = false;
        [DefaultValue(typeof(bool), "false")]
        [Category("Item")]
        [Description("Item悬浮时是否需要Glass填充")]
        public bool ItemHoverGlassVisble
        {
            get { return itemHoverGlassVisble; }
            set
            {
                itemHoverGlassVisble = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "White")]
        [Category("Item")]
        [Description("Item渐变行颜色1")]
        public Color RowBackColor1
        {
            get { return _rowBackColor1; }
            set
            {
                _rowBackColor1 = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "254, 216, 249")]
        [Category("Item")]
        [Description("Item渐变行颜色2")]
        public Color RowBackColor2
        {
            get { return _rowBackColor2; }
            set
            {
                _rowBackColor2 = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "102, 206, 255")]
        [Category("Item")]
        [Description("Item选中后颜色")]
        public Color SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                _selectedColor = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "55, 126, 168")]
        [Category("Skin")]
        [Description("边框颜色")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                base.Invalidate(true);
            }
        }

        internal ListBox.ObjectCollection OldItems
        {
            get { return base.Items; }
        }

        private RECT AbsoluteClientRECT
        {
            get
            {
                RECT lpRect = new RECT();
                CreateParams createParams = CreateParams;
                NativeMethods.AdjustWindowRectEx(
                    ref lpRect,
                    createParams.Style,
                    false,
                    createParams.ExStyle);
                int left = -lpRect.Left;
                int right = -lpRect.Top;
                NativeMethods.GetClientRect(
                    base.Handle,
                    ref lpRect);

                lpRect.Left += left;
                lpRect.Right += left;
                lpRect.Top += right;
                lpRect.Bottom += right;
                return lpRect;
            }
        }

        private Rectangle AbsoluteClientRectangle
        {
            get
            {
                RECT absoluteClientRECT = AbsoluteClientRECT;

                Rectangle rect = Rectangle.FromLTRB(
                    absoluteClientRECT.Left,
                    absoluteClientRECT.Top,
                    absoluteClientRECT.Right,
                    absoluteClientRECT.Bottom);
                CreateParams cp = base.CreateParams;
                bool bHscroll = (cp.Style &
                    WS.WS_HSCROLL) != 0;
                bool bVscroll = (cp.Style &
                    WS.WS_VSCROLL) != 0;

                if (bHscroll)
                {
                    rect.Height += SystemInformation.HorizontalScrollBarHeight;
                }

                if (bVscroll)
                {
                    rect.Width += SystemInformation.VerticalScrollBarWidth;
                }

                return rect;
            }
        }

        #endregion

        #region 重绘事件
        SkinListBoxItem mouseitem;
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < Items.Count; i++)
            {
                Rectangle bounds = this.GetItemRectangle(i);
                SkinListBoxItem item = Items[i];
                if (mouseitem == Items[i] && mouseitem != this.SelectedItem)   //悬浮时
                {
                    RenderBackgroundInternal(
                             g,
                             bounds,
                             Color.FromArgb(255, 128, 0),
                             Color.FromArgb(255, 128, 0),
                             Color.FromArgb(200, 255, 255, 255),
                             ItemRoundStyle,
                             ItemRadius,
                             0.45f,
                             ItemBorderVisble,
                             ItemHoverGlassVisble,
                             LinearGradientMode.Vertical);
                }
                else  //非悬浮时
                {
                    if (this.SelectedItem == Items[i])//选中时
                    {
                        RenderBackgroundInternal(
                           g,
                           bounds,
                           _selectedColor,
                           _selectedColor,
                           Color.FromArgb(200, 255, 255, 255),
                           ItemRoundStyle,
                           ItemRadius,
                           0.45f,
                           ItemBorderVisble,
                           ItemGlassVisble,
                           LinearGradientMode.Vertical);
                    }
                    else
                    {
                        Color backColor;
                        if (i % 2 == 0)
                        {
                            backColor = _rowBackColor2;
                        }
                        else
                        {
                            backColor = _rowBackColor1;
                        }
                        using (SolidBrush brush = new SolidBrush(backColor))
                        {
                            g.FillRectangle(brush, bounds);
                        }
                    }
                }
                Image image = item.Image;
                //获得Img绘画范围
                Rectangle imageRect = new Rectangle(
                    bounds.X + 2,
                    bounds.Y + 2,
                    bounds.Height - 4,
                    bounds.Height - 4);

                //是否启用Img
                int ImgRight = ImageVisble ? imageRect.Right : 0;

                //获得文字绘画范围
                Rectangle textRect = new Rectangle(
                    ImgRight + 2,
                    bounds.Y,
                    bounds.Width - imageRect.Right - 2,
                    bounds.Height);

                string text = item.ToString();
                TextFormatFlags formatFlags =
                    TextFormatFlags.VerticalCenter;
                if (RightToLeft == RightToLeft.Yes)
                {
                    imageRect.X = bounds.Right - imageRect.Right;
                    textRect.X = bounds.Right - textRect.Right;
                    formatFlags |= TextFormatFlags.RightToLeft;
                    formatFlags |= TextFormatFlags.Right;
                }
                else
                {
                    formatFlags |= TextFormatFlags.Left;
                }

                if (image != null && ImageVisble)
                {
                    g.InterpolationMode =
                        InterpolationMode.HighQualityBilinear;
                    g.DrawImage(
                        image,
                        imageRect,
                        0,
                        0,
                        image.Width,
                        image.Height,
                        GraphicsUnit.Pixel);
                }

                TextRenderer.DrawText(
                    g,
                    text,
                    Font,
                    textRect,
                    ForeColor,
                    formatFlags);

                //g.DrawString(item.Text, new Font("微软雅黑", 9), new SolidBrush(Color.Black), bounds.Left + 2, bounds.Top + 4);
            }
        }
        #endregion

        #region 悬浮项时
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            for (int i = 0; i < Items.Count; i++)
            {
                Rectangle bounds = this.GetItemRectangle(i);
                if (bounds.Contains(e.X, e.Y))
                {
                    if (Items[i] != mouseitem)
                    {
                        mouseitem = Items[i];
                        this.Invalidate();
                    }
                }
            }
        }
        #endregion

        #region 点击项时
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            this.Invalidate();
        }
        #endregion

        #region Windows消息事件
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM.WM_NCPAINT:
                    WmNcPaint(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void WmNcPaint(ref Message m)
        {
            base.WndProc(ref m);
            if (base.BorderStyle == BorderStyle.None)
            {
                return;
            }

            IntPtr hDC = NativeMethods.GetWindowDC(m.HWnd);
            if (hDC == IntPtr.Zero)
            {
                throw new Win32Exception();
            }
            try
            {
                Color backColor = BackColor;
                Color borderColor = _borderColor;

                Rectangle bounds = new Rectangle(0, 0, Width, Height);
                using (Graphics g = Graphics.FromHdc(hDC))
                {
                    using (Region region = new Region(bounds))
                    {
                        region.Exclude(AbsoluteClientRectangle);
                        using (Brush brush = new SolidBrush(backColor))
                        {
                            g.FillRegion(brush, region);
                        }
                    }

                    ControlPaint.DrawBorder(
                        g,
                        bounds,
                        borderColor,
                        ButtonBorderStyle.Solid);
                }
            }
            finally
            {
                NativeMethods.ReleaseDC(m.HWnd, hDC);
            }
            m.Result = IntPtr.Zero;
        }

        #endregion

        #region 绘画方法
        public void RenderBackgroundInternal(
           Graphics g,
           Rectangle rect,
           Color baseColor,
           Color borderColor,
           Color innerBorderColor,
           RoundStyle style,
           int roundWidth,
           float basePosition,
           bool drawBorder,
           bool drawGlass,
           LinearGradientMode mode)
        {
            if (drawBorder)
            {
                rect.Width--;
                rect.Height--;
            }

            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect, Color.Transparent, Color.Transparent, mode))
            {
                Color[] colors = new Color[4];
                colors[0] = GetColor(baseColor, 0, 35, 24, 9);
                colors[1] = GetColor(baseColor, 0, 13, 8, 3);
                colors[2] = baseColor;
                colors[3] = GetColor(baseColor, 0, 68, 69, 54);

                ColorBlend blend = new ColorBlend();
                blend.Positions = new float[] { 0.0f, basePosition, basePosition + 0.05f, 1.0f };
                blend.Colors = colors;
                brush.InterpolationColors = blend;
                if (style != RoundStyle.None)
                {
                    using (GraphicsPath path =
                        GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
                    {
                        g.FillPath(brush, path);
                    }

                    if (drawGlass)
                    {
                        if (baseColor.A > 80)
                        {
                            Rectangle rectTop = rect;

                            if (mode == LinearGradientMode.Vertical)
                            {
                                rectTop.Height = (int)(rectTop.Height * basePosition);
                            }
                            else
                            {
                                rectTop.Width = (int)(rect.Width * basePosition);
                            }
                            using (GraphicsPath pathTop = GraphicsPathHelper.CreatePath(
                                rectTop, roundWidth, RoundStyle.Top, false))
                            {
                                using (SolidBrush brushAlpha =
                                    new SolidBrush(Color.FromArgb(80, 255, 255, 255)))
                                {
                                    g.FillPath(brushAlpha, pathTop);
                                }
                            }
                        }
                        RectangleF glassRect = rect;
                        if (mode == LinearGradientMode.Vertical)
                        {
                            glassRect.Y = rect.Y + rect.Height * basePosition;
                            glassRect.Height = (rect.Height - rect.Height * basePosition) * 2;
                        }
                        else
                        {
                            glassRect.X = rect.X + rect.Width * basePosition;
                            glassRect.Width = (rect.Width - rect.Width * basePosition) * 2;
                        }
                        DrawGlass(g, glassRect, 170, 0);
                    }

                    if (drawBorder)
                    {
                        using (GraphicsPath path =
                            GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
                        {
                            using (Pen pen = new Pen(borderColor))
                            {
                                g.DrawPath(pen, path);
                            }
                        }

                        rect.Inflate(-1, -1);
                        using (GraphicsPath path =
                            GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
                        {
                            using (Pen pen = new Pen(innerBorderColor))
                            {
                                g.DrawPath(pen, path);
                            }
                        }
                    }
                }
                else
                {
                    g.FillRectangle(brush, rect);

                    if (drawGlass)
                    {
                        if (baseColor.A > 80)
                        {
                            Rectangle rectTop = rect;
                            if (mode == LinearGradientMode.Vertical)
                            {
                                rectTop.Height = (int)(rectTop.Height * basePosition);
                            }
                            else
                            {
                                rectTop.Width = (int)(rect.Width * basePosition);
                            }
                            using (SolidBrush brushAlpha =
                                new SolidBrush(Color.FromArgb(80, 255, 255, 255)))
                            {
                                g.FillRectangle(brushAlpha, rectTop);
                            }
                        }
                        RectangleF glassRect = rect;
                        if (mode == LinearGradientMode.Vertical)
                        {
                            glassRect.Y = rect.Y + rect.Height * basePosition;
                            glassRect.Height = (rect.Height - rect.Height * basePosition) * 2;
                        }
                        else
                        {
                            glassRect.X = rect.X + rect.Width * basePosition;
                            glassRect.Width = (rect.Width - rect.Width * basePosition) * 2;
                        }
                        DrawGlass(g, glassRect, 200, 0);
                    }

                    if (drawBorder)
                    {
                        using (Pen pen = new Pen(borderColor))
                        {
                            g.DrawRectangle(pen, rect);
                        }

                        rect.Inflate(-1, -1);
                        using (Pen pen = new Pen(innerBorderColor))
                        {
                            g.DrawRectangle(pen, rect);
                        }
                    }
                }
            }
        }

        private void DrawGlass(
            Graphics g, RectangleF glassRect, int alphaCenter, int alphaSurround)
        {
            DrawGlass(g, glassRect, Color.White, alphaCenter, alphaSurround);
        }

        private void DrawGlass(
            Graphics g,
            RectangleF glassRect,
            Color glassColor,
            int alphaCenter,
            int alphaSurround)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(glassRect);
                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = Color.FromArgb(alphaCenter, glassColor);
                    brush.SurroundColors = new Color[] { 
                        Color.FromArgb(alphaSurround, glassColor) };
                    brush.CenterPoint = new PointF(
                        glassRect.X + glassRect.Width / 2,
                        glassRect.Y + glassRect.Height / 2);
                    g.FillPath(brush, path);
                }
            }
        }

        private Color GetColor(
            Color colorBase, int a, int r, int g, int b)
        {
            int a0 = colorBase.A;
            int r0 = colorBase.R;
            int g0 = colorBase.G;
            int b0 = colorBase.B;

            if (a + a0 > 255) { a = 255; } else { a = Math.Max(a + a0, 0); }
            if (r + r0 > 255) { r = 255; } else { r = Math.Max(r + r0, 0); }
            if (g + g0 > 255) { g = 255; } else { g = Math.Max(g + g0, 0); }
            if (b + b0 > 255) { b = 255; } else { b = Math.Max(b + b0, 0); }

            return Color.FromArgb(a, r, g, b);
        }

        #endregion
    }
}
