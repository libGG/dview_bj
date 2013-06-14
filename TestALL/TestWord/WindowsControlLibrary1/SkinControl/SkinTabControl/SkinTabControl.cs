using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using CCWin.SkinClass;
using CCWin.Win32.Const;

namespace CCWin.SkinControl
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxBitmap(typeof(TabControl))]
    public class SkinTabControl : TabControl
    {
        #region 变量
        private Image _titleBackground = Properties.Resources.main_tab_highlighttwo;
        private Color _baseColor = Color.White;
        private Color _backColor = Color.Transparent;
        private Color _borderColor = Color.White;
        private Color _pageColor = Color.White;
        /// <summary>
        /// 是否获取了焦点
        /// </summary>
        private bool _isFocus = false;
        /// <summary>
        /// 选项卡箭头区域
        /// </summary>
        private Rectangle _btnArrowRect = Rectangle.Empty;
        #endregion

        #region 构造函数
        /// <summary>
        /// 
        /// </summary>
        public SkinTabControl()
            : base()
        {
            base.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor, true);
            base.SizeMode = TabSizeMode.Fixed;
            base.ItemSize = new Size(70, 36);
            base.UpdateStyles();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(typeof(Color), "102, 180, 228")]
        [CategoryAttribute("Skin")]
        public Color BaseColor
        {
            get { return this._baseColor; }
            set
            {
                this._baseColor = value;
                base.Invalidate(true);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(typeof(Color), "Transparent")]
        [CategoryAttribute("Skin")]
        [Browsable(true)]
        public override Color BackColor
        {
            get { return this._backColor; }
            set
            {
                this._backColor = value;
                base.Invalidate(true);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(typeof(Color), "102, 180, 228")]
        [CategoryAttribute("Skin")]
        public Color BorderColor
        {
            get { return this._borderColor; }
            set
            {
                this._borderColor = value;
                base.Invalidate(true);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("所有TabPage的背景颜色")]
        [CategoryAttribute("Skin")]
        public Color PageColor
        {
            get { return this._pageColor; }
            set
            {
                this._pageColor = value;
                if (this.TabPages.Count > 0)
                {
                    for (int i = 0; i < this.TabPages.Count; i++)
                    {
                        this.TabPages[i].BackColor = this._pageColor;
                    }
                }
                base.Invalidate(true);
            }
        }
        #endregion

        #region 重载事件
        /// <summary>
        /// 重载重绘事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.DrawBackground(g);
            this.DrawTabPages(g);
        }

        /// <summary>
        /// 鼠标在组件上移动时
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            //if (!this.DesignMode)
            //    base.Invalidate();
        }

        /// <summary>
        /// 鼠标离开组件时
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            //if (!this.DesignMode)
            //    base.Invalidate();
        }
        /// <summary>
        /// 按下鼠标时
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!this.DesignMode)
            {
                if (e.Button == MouseButtons.Left && this._btnArrowRect.Contains(e.Location))
                {
                    this._isFocus = true;
                    base.Invalidate(this._btnArrowRect);
                }
            }
        }
        /// <summary>
        /// 拦截系统消息
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg != WM.WM_CONTEXTMENU)//0x007B鼠标右键
            {
                base.WndProc(ref m);
            }
        }
        #endregion

        #region 绘画方法
        /// <summary>
        /// 绘制背景
        /// </summary>
        /// <param name="g"></param>
        private void DrawBackground(Graphics g)
        {
            //绘画背景色
            int width = this.ClientRectangle.Width;
            int height = this.ClientRectangle.Height - this.DisplayRectangle.Height;
            Color backColor = this.Enabled ? this._backColor : SystemColors.Control;
            using (SolidBrush brush = new SolidBrush(backColor))
            {
                g.FillRectangle(brush, this.ClientRectangle);
            }
            //绘制Tab按钮栏背景
            //Rectangle bgRect = new Rectangle(2, 2, this.Width - 2, this.ItemSize.Height);
            //this.DrawImage(g, this._titleBackground, bgRect);//绘制背景图
        }
        /// <summary>
        /// 绘图
        /// </summary>
        /// <param name="g"></param>
        /// <param name="image"></param>
        /// <param name="rect"></param>
        private void DrawImage(Graphics g, Image image, Rectangle rect)
        {
            g.DrawImage(image, new Rectangle(rect.X, rect.Y, 5, rect.Height), 0, 0, 5, image.Height,
                GraphicsUnit.Pixel);
            g.DrawImage(image, new Rectangle(rect.X + 5, rect.Y, rect.Width - 10, rect.Height), 5, 0, image.Width - 10, image.Height, GraphicsUnit.Pixel);
            g.DrawImage(image, new Rectangle(rect.X + rect.Width - 5, rect.Y, 5, rect.Height), image.Width - 5, 0, 5, image.Height, GraphicsUnit.Pixel);
        }

        Image Icon;
        private void DrawTabPages(Graphics g)
        {
            using (SolidBrush brush = new SolidBrush(this._pageColor))
            {
                int x = 2;
                int y = this.ItemSize.Height;
                int width = this.Width - 2;
                int height = this.Height - this.ItemSize.Height;
                g.FillRectangle(brush, x, y, width, height);
                g.DrawRectangle(new Pen(this._borderColor), x, y, width - 1, height - 1);
            }
            Rectangle tabRect = Rectangle.Empty;
            Point cursorPoint = this.PointToClient(MousePosition);
            for (int i = 0; i < base.TabCount; i++)
            {
                TabPage page = this.TabPages[i];
                tabRect = this.GetTabRect(i);
                Color baseColor = Color.Yellow;
                Icon = (this.TabPages[i].ImageIndex != -1) && (this.ImageList != null) ? this.ImageList.Images[this.TabPages[i].ImageIndex] : null;
                Image baseTabHeaderImage = null;
                Image btnArrowImage = null;

                if (this.SelectedIndex == i)//是否选中
                {
                    baseTabHeaderImage = Properties.Resources.tab_dots_down;
                    Point contextMenuLocation = this.PointToScreen(new Point(this._btnArrowRect.Left, this._btnArrowRect.Top + this._btnArrowRect.Height + 5));
                    ContextMenuStrip contextMenuStrip = this.TabPages[i].ContextMenuStrip;
                    if (contextMenuStrip != null)
                    {
                        contextMenuStrip.Closed -= new ToolStripDropDownClosedEventHandler(contextMenuStrip_Closed);
                        contextMenuStrip.Closed += new ToolStripDropDownClosedEventHandler(contextMenuStrip_Closed);
                        if (contextMenuLocation.X + contextMenuStrip.Width >
                            Screen.PrimaryScreen.WorkingArea.Width - 20)
                        {
                            contextMenuLocation.X = Screen.PrimaryScreen.WorkingArea.Width -
                                contextMenuStrip.Width - 50;
                        }
                        if (tabRect.Contains(cursorPoint))
                        {
                            if (this._isFocus)
                            {
                                btnArrowImage = Properties.Resources.tab_dots_down;
                                contextMenuStrip.Show(contextMenuLocation);
                            }
                            else
                            {
                                btnArrowImage = Properties.Resources.tab_dots_normal;
                            }
                            this._btnArrowRect = new Rectangle(tabRect.X + tabRect.Width - btnArrowImage.Width, tabRect.Y, btnArrowImage.Width, btnArrowImage.Height);
                        }
                        else if (this._isFocus)
                        {
                            btnArrowImage = Properties.Resources.tab_dots_down;
                            contextMenuStrip.Show(contextMenuLocation);
                        }
                    }
                }
                else if (tabRect.Contains(cursorPoint))//鼠标滑过
                {
                    baseTabHeaderImage = Properties.Resources.tab_dots_mouseover;
                }
                if (baseTabHeaderImage != null)
                {
                    if (this.SelectedIndex == i)
                    {
                        if (this.SelectedIndex == this.TabCount - 1)
                            tabRect.Inflate(2, 0);
                        else
                            tabRect.Inflate(1, 0);
                    }
                    this.DrawImage(g, baseTabHeaderImage, tabRect);
                    if (btnArrowImage != null)
                    {
                        //当鼠标进入当前选中的的选项卡时，显示下拉按钮
                        g.DrawImage(btnArrowImage, this._btnArrowRect);
                    }
                }
                if(Icon != null)
                {
                    g.DrawImage(Icon, tabRect.X + (tabRect.Width - Icon.Width) / 2, tabRect.Y + (tabRect.Height - Icon.Height) / 2);
                }
                TextRenderer.DrawText(g, page.Text, page.Font, tabRect, page.ForeColor);
            }
        }

        #endregion

        void contextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this._isFocus = false;
            base.Invalidate(this._btnArrowRect);
        }
    }
}
