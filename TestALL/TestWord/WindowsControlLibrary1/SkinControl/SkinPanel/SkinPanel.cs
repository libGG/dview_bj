using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Drawing.Drawing2D;
using CCWin.SkinClass;

namespace CCWin.SkinControl
{
    [ToolboxBitmap(typeof(Panel))]
    public partial class SkinPanel : Panel
    {
        public SkinPanel()
        {
            //初始化
            Init();
            this.ResizeRedraw = true;
            this.BackColor = System.Drawing.Color.Transparent;//背景设为透明
        }
        #region 初始化
        public void Init()
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);//调整大小时重绘
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);// 双缓冲
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);// 禁止擦除背景.
            this.SetStyle(ControlStyles.UserPaint, true);//自行绘制
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.UpdateStyles();
        }
        #endregion

        #region 属性与变量
        private ControlState _controlState;
        /// <summary>
        /// 控件状态
        /// </summary>
        public ControlState ControlState
        {
            get { return _controlState; }
            set
            {
                if (_controlState != value)
                {
                    _controlState = value;
                    base.Invalidate();
                }
            }
        }

        private bool palace = false;
        /// <summary>
        /// 是否开启九宫绘图
        /// </summary>
        [Category("Skin")]
        [DefaultValue(typeof(bool), "false")]
        [Description("是否开启九宫绘图")]
        public bool Palace
        {
            get { return palace; }
            set
            {
                if (palace != value)
                {
                    palace = value;
                    this.Invalidate();
                }
            }
        }

        private Rectangle backrectangle = new Rectangle(10, 10, 10, 10);
        /// <summary>
        /// 九宫绘画区域
        /// </summary>
        [Category("Skin")]
        [DefaultValue(typeof(Rectangle), "10,10,10,10")]
        [Description("九宫绘画区域")]
        public Rectangle BackRectangle
        {
            get { return backrectangle; }
            set
            {
                if (backrectangle != value)
                {
                    backrectangle = value;
                }
                this.Invalidate();
            }
        }

        private Image mouseback;
        /// <summary>
        /// 悬浮时
        /// </summary>
        [Category("MouseEnter")]
        [Description("悬浮时背景")]
        public Image MouseBack
        {
            get { return mouseback; }
            set
            {
                if (mouseback != value)
                {
                    mouseback = value;
                    this.Invalidate();
                }
            }
        }

        private Image downback;
        /// <summary>
        /// 点击时
        /// </summary>
        [Category("MouseDown")]
        [Description("点击时背景")]
        public Image DownBack
        {
            get { return downback; }
            set
            {
                if (downback != value)
                {
                    downback = value;
                    this.Invalidate();
                }
            }
        }

        private Image normlback;
        /// <summary>
        /// 初始时
        /// </summary>
        [Category("MouseNorml")]
        [Description("初始时背景")]
        public Image NormlBack
        {
            get { return normlback; }
            set
            {
                if (normlback != value)
                {
                    normlback = value;
                    this.Invalidate();
                }
            }
        }

        private int radius = 0;
        /// <summary>
        /// 圆角大小
        /// </summary>
        [DefaultValue(typeof(int), "0")]
        [Category("Skin")]
        [Description("圆角大小")]
        public int Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (radius != value)
                {
                    radius = value < 0 ? 0 : value;
                    this.Invalidate();
                }
            }
        }
        #endregion

        #region 重载事件
        //鼠标悬浮时
        protected override void OnMouseEnter(EventArgs e)
        {
            _controlState = ControlState.Hover;
            this.Invalidate();
            base.OnMouseEnter(e);
        }

        //鼠标离开时
        protected override void OnMouseLeave(EventArgs e)
        {
            _controlState = ControlState.Normal;
            this.Invalidate();
            base.OnMouseLeave(e);
        }

        //鼠标点击时
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                _controlState = ControlState.Pressed;
                this.Invalidate();
            }
            base.OnMouseDown(e);
        }

        //鼠标按下时
        protected override void OnMouseUp(MouseEventArgs e)
        {
            _controlState = ControlState.Hover;
            this.Invalidate();
            base.OnMouseUp(e);
        }

        //重绘
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //取得当前需要绘画的图像
            Bitmap btm = null;
            switch (_controlState)
            {
                case ControlState.Pressed:
                    btm = (Bitmap)DownBack;
                    break;
                case ControlState.Hover:
                    btm = (Bitmap)MouseBack;
                    break;
                default:
                    btm = (Bitmap)NormlBack;
                    break;
            }
            if (btm != null)
            {
                //是否启用九宫绘图
                if (Palace)
                {
                    ImageDrawRect.DrawRect(g, btm, new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height), Rectangle.FromLTRB(BackRectangle.X, BackRectangle.Y, BackRectangle.Width, BackRectangle.Height), 1, 1);
                }
                else
                {
                    BackgroundImage = btm;
                }
            }
            //绘制圆角
            UpdateForm.CreateRegion(this, radius);
            base.OnPaint(e);
        }
        #endregion
    }
}