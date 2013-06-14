using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using CCWin.SkinClass;
using CCWin.Win32;
using CCWin.Win32.Const;

namespace CCWin
{
    //绘图层
    public partial class SkinForm : Form
    {
        //控件层
        private SkinMain Main;
        //带参构造
        public SkinForm(SkinMain main)
        {
            InitializeComponent();
            //将控制层传值过来
            this.Main = main;
            //减少闪烁
            SetStyles();
            //初始化
            Init();
        }
        #region 初始化
        private void Init()
        {
            //最顶层
            TopMost = Main.TopMost;
            //是否在任务栏显示
            ShowInTaskbar = Main.SkinShowInTaskbar;
            //无边框模式
            FormBorderStyle = FormBorderStyle.None;
            //自动拉伸背景图以适应窗口
            BackgroundImageLayout = ImageLayout.Stretch;
            //设置绘图层显示位置
            this.Location = Main.Location;
            //设置ICO
            Icon = Main.Icon;
            //是否显示ICO
            ShowIcon = Main.ShowIcon;
            //设置大小
            Size = Main.Size;
            //设置标题名
            Text = Main.Text;
            //设置背景
            Bitmap bitmaps = new Bitmap(Main.SkinBack, Size);
            if (Main.SkinTrankColor != Color.Transparent)
            {
                bitmaps.MakeTransparent(Main.SkinTrankColor);
            }
            BackgroundImage = bitmaps;
            //控制层与绘图层合为一体
            Main.Owner = this;
            //绘制层窗体移动
            this.MouseDown += new MouseEventHandler(Frm_MouseDown);
            this.MouseMove += new MouseEventHandler(Frm_MouseMove);
            this.MouseUp += new MouseEventHandler(Frm_MouseUp);
            this.LocationChanged += new EventHandler(Frm_LocationChanged);
            //控制层层窗体移动
            Main.MouseDown += new MouseEventHandler(Frm_MouseDown);
            Main.MouseMove += new MouseEventHandler(Frm_MouseMove);
            Main.MouseUp += new MouseEventHandler(Frm_MouseUp);
            Main.LocationChanged += new EventHandler(Frm_LocationChanged);
        }
        #endregion

        #region 无标题栏的窗口移动
        private Point mouseOffset; //记录鼠标指针的坐标
        private bool isMouseDown = false; //记录鼠标按键是否按下
        //窗体按下时
        private void Frm_MouseDown(object sender, MouseEventArgs e)
        {
            if (Main.SkinMobile)
            {
                //点击窗体时，记录鼠标位置，启动移动
                if (e.Button == MouseButtons.Left)
                {
                    mouseOffset = new Point(-e.X, -e.Y);
                    isMouseDown = true;
                }
            }
        }

        //窗体移动时
        private void Frm_MouseMove(object sender, MouseEventArgs e)
        {
            if (Main.SkinMobile)
            {
                //将调用此事件的窗口保存下
                Form frm = (Form)sender;
                //确定开启了移动模式后
                if (isMouseDown)
                {
                    //移动的位置计算
                    Point mousePos = Control.MousePosition;
                    mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                    //判断是绘图层还是控件层调用了移动事件,并作出相应回馈
                    frm.Location = mousePos;
                }
            }
        }

        //窗体按下并释放按钮时
        private void Frm_MouseUp(object sender, MouseEventArgs e)
        {
            if (Main.SkinMobile)
            {
                // 修改鼠标状态isMouseDown的值
                // 确保只有鼠标左键按下并移动时，才移动窗体
                if (e.Button == MouseButtons.Left)
                {
                    //松开鼠标时，停止移动
                    isMouseDown = false;
                    //Top高度小于0的时候，等于0
                    if (this.Top < 0)
                    {
                        this.Top = Main.Top = 0;
                    }
                }
            }
        }

        //窗体移动时
        private void Frm_LocationChanged(object sender, EventArgs e)
        { 
            //将调用此事件的窗口保存下
            Form frm = (Form)sender;
            if (frm == this)
            {
                Main.Location = frm.Location;
            }
            else 
            {
                this.Location = frm.Location;
            }
        }
        #endregion

        #region 减少闪烁
        private void SetStyles()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer, true);
            //强制分配样式重新应用到控件上
            UpdateStyles();
            base.AutoScaleMode = AutoScaleMode.None;
        }
        #endregion

        #region 不规则无毛边方法
        public void SetBits()
        {
            if (BackgroundImage != null)
            {
                //绘制绘图层背景
                Bitmap bitmap = new Bitmap(BackgroundImage, base.Width, base.Height);
                if (!Bitmap.IsCanonicalPixelFormat(bitmap.PixelFormat) || !Bitmap.IsAlphaPixelFormat(bitmap.PixelFormat))
                    throw new ApplicationException("图片必须是32位带Alhpa通道的图片。");
                IntPtr oldBits = IntPtr.Zero;
                IntPtr screenDC = NativeMethods.GetDC(IntPtr.Zero);
                IntPtr hBitmap = IntPtr.Zero;
                IntPtr memDc = NativeMethods.CreateCompatibleDC(screenDC);

                try
                {
                    NativeMethods.Point topLoc = new NativeMethods.Point(Left, Top);
                    NativeMethods.Size bitMapSize = new NativeMethods.Size(Width, Height);
                    NativeMethods.BLENDFUNCTION blendFunc = new NativeMethods.BLENDFUNCTION();
                    NativeMethods.Point srcLoc = new NativeMethods.Point(0, 0);

                    hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                    oldBits = NativeMethods.SelectObject(memDc, hBitmap);

                    blendFunc.BlendOp = AC.AC_SRC_OVER;
                    blendFunc.SourceConstantAlpha = Byte.Parse("255");
                    blendFunc.AlphaFormat = AC.AC_SRC_ALPHA;
                    blendFunc.BlendFlags = 0;

                    NativeMethods.UpdateLayeredWindow(Handle, screenDC, ref topLoc, ref bitMapSize, memDc, ref srcLoc, 0, ref blendFunc, NativeMethods.ULW_ALPHA);
                }
                finally
                {
                    if (hBitmap != IntPtr.Zero)
                    {
                        NativeMethods.SelectObject(memDc, oldBits);
                        NativeMethods.DeleteObject(hBitmap);
                    }
                    NativeMethods.ReleaseDC(IntPtr.Zero, screenDC);
                    NativeMethods.DeleteDC(memDc);
                }
            }
        }
        #endregion

        #region 重载事件
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cParms = base.CreateParams;
                cParms.ExStyle |= 0x00080000; // WS_EX_LAYERED
                return cParms;
            }
        }

        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            base.OnBackgroundImageChanged(e);
            SetBits();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetBits();
        }
        #endregion
    }
}
