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
using System.Threading;
using CCWin.SkinClass;
using CCWin.Win32.Const;
using CCWin.Win32.Struct;
using CCWin.Win32;

namespace CCWin
{
    //绘图层
    public partial class CCSkinForm : Form
    {
        //控件层
        private CCSkinMain Main;
        //带参构造
        public CCSkinForm(CCSkinMain main)
        {
            //将控制层传值过来
            this.Main = main;
            InitializeComponent();
            //减少闪烁
            SetStyles();
            //初始化
            Init();
        }
        #region 初始化
        private void Init()
        {
            //置顶窗体
            TopMost = Main.TopMost;
            Main.BringToFront();
            //是否在任务栏显示
            ShowInTaskbar = false;
            //无边框模式
            FormBorderStyle = FormBorderStyle.None;
            //设置绘图层显示位置
            this.Location = new Point(Main.Location.X - 5, Main.Location.Y - 5);
            //设置ICO
            Icon = Main.Icon;
            ShowIcon = Main.ShowIcon;
            //设置大小
            Width = Main.Width + 10;
            Height = Main.Height + 10;
            //设置标题名
            Text = Main.Text;
            //绘图层窗体移动
            Main.LocationChanged += new EventHandler(Main_LocationChanged);
            Main.SizeChanged += new EventHandler(Main_SizeChanged);
            Main.VisibleChanged += new EventHandler(Main_VisibleChanged);
            //还原任务栏右键菜单
            //CommonClass.SetTaskMenu(Main);
            //加载背景
            SetBits();
            //窗口鼠标穿透效果
            CanPenetrate();
        }
        #endregion

        #region 还原任务栏右键菜单
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cParms = base.CreateParams;
                cParms.ExStyle |= 0x00080000; // WS_EX_LAYERED
                return cParms;
            }
        }
        public class CommonClass
        {
            public static void SetTaskMenu(Form form)
            {
                int windowLong = (NativeMethods.GetWindowLong(new HandleRef(form, form.Handle), -16));
                NativeMethods.SetWindowLong(new HandleRef(form, form.Handle), -16, windowLong | WS.WS_SYSMENU | WS.WS_MINIMIZEBOX);
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
                ControlStyles.ResizeRedraw|
                ControlStyles.DoubleBuffer, true);
            //强制分配样式重新应用到控件上
            UpdateStyles();
        }
        #endregion

        #region 控件层相关事件
        //移动主窗体时
        void Main_LocationChanged(object sender, EventArgs e)
        {
            Location = new Point(Main.Left - 5, Main.Top - 5);
        }

        //主窗体大小改变时
        void Main_SizeChanged(object sender, EventArgs e)
        {
            //设置大小
            Width = Main.Width + 10;
            Height = Main.Height + 10;
            SetBits();
        }

        //主窗体显示或隐藏时
        void Main_VisibleChanged(object sender, EventArgs e)
        {
            this.Visible = Main.Visible;
        }
        #endregion

        #region 使窗口有鼠标穿透功能
        /// <summary>
        /// 使窗口有鼠标穿透功能
        /// </summary>
        private void CanPenetrate()
        {
            int intExTemp = NativeMethods.GetWindowLong(this.Handle, GWL.GWL_EXSTYLE);
            int oldGWLEx = NativeMethods.SetWindowLong(this.Handle, GWL.GWL_EXSTYLE, WS_EX.WS_EX_TRANSPARENT | WS_EX.WS_EX_LAYERED);
        }
        #endregion

        #region 不规则无毛边方法
        public void SetBits()
        {
            //绘制绘图层背景
            Bitmap bitmap = new Bitmap(Main.Width + 10, Main.Height + 10);
            Rectangle _BacklightLTRB = new Rectangle(20, 20, 20, 20);//窗体光泽重绘边界
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.HighQuality; //高质量
            g.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量
            ImageDrawRect.DrawRect(g, Properties.Resources.main_light_bkg_top123, ClientRectangle, Rectangle.FromLTRB(_BacklightLTRB.X, _BacklightLTRB.Y, _BacklightLTRB.Width, _BacklightLTRB.Height), 1, 1);

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
        #endregion
    }
}
