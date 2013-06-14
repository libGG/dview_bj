using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using CCWin.SkinClass;

namespace CCWin
{
    //控件层
    public partial class SkinMain : Form
    {
        //绘制层
        public SkinForm skin;
        public SkinMain()
        {
            InitializeComponent();
            //减少闪烁
            SetStyles();
            //初始化
            Init();
        }
        #region 初始化
        private void Init()
        {
            //不显示在Windows任务栏中
            ShowInTaskbar = false;
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

        #region 变量属性
        //不显示FormBorderStyle属性
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FormBorderStyle FormBorderStyle
        {
            get { return base.FormBorderStyle; }
            set { base.FormBorderStyle = FormBorderStyle.None; }
        }

        private Image skinback;
        [Category("Skin")]
        [Description("该窗体的背景图像")]
        public Image SkinBack
        {
            get { return skinback; }
            set
            {
                if (skinback != value)
                {
                    skinback = value;
                    if (value != null && show && !DesignMode)
                    {
                        UpdateForm.CreateControlRegion(this, TrankBack(), 255);
                    }
                    this.Invalidate();
                    if (skin != null)
                    {
                        skin.BackgroundImage = TrankBack();
                    }
                }
            }
        }

        private Color _skintrankcolor = Color.Transparent;
        [Category("Skin")]
        [Description("背景需要透明的颜色")]
        [DefaultValue(typeof(Color), "Color.Transparent")]
        public Color SkinTrankColor
        {
            get { return _skintrankcolor; }
            set
            {
                if (_skintrankcolor != value)
                {
                    _skintrankcolor = value;
                    this.Invalidate();
                    if (skin != null)
                    {
                        skin.BackgroundImage = TrankBack();
                    }
                }
            }
        }

        private bool _skinshowintaskbar = true;
        [Category("Skin")]
        [Description("绘图层是否出现在Windows任务栏中。")]
        [DefaultValue(typeof(bool), "true")]
        public bool SkinShowInTaskbar
        {
            get { return _skinshowintaskbar; }
            set
            {
                if (_skinshowintaskbar != value)
                {
                    _skinshowintaskbar = value;
                }
            }
        }

        private bool _skinmobile = true;
        [Category("Skin")]
        [Description("窗体是否可以移动")]
        [DefaultValue(typeof(bool), "true")]
        public bool SkinMobile
        {
            get { return _skinmobile; }
            set
            {
                if (_skinmobile != value)
                {
                    _skinmobile = value;
                }
            }
        }

        //获取窗体应用的背景
        public Bitmap TrankBack()
        {
            Bitmap bitmap = new Bitmap(this.SkinBack);
            if(SkinTrankColor != Color.Transparent)
            {
                bitmap.MakeTransparent(SkinTrankColor);
            }
            bitmap = new Bitmap(bitmap, this.Size);
            return bitmap;
        }
        #endregion

        #region 重载事件
        //重绘时
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (SkinBack != null)
            {
                g.DrawImage(TrankBack(), 0, 0, Width, Height);
            }
            base.OnPaint(e);
        }

        //窗体关闭时
        protected override void OnClosing(CancelEventArgs e)
        {
            this.Owner.Close();
            base.OnClosing(e);
        }
        
        //Visble值改变时
        bool show = false;
        protected override void OnVisibleChanged(EventArgs e)
        {
            if (!DesignMode)
            {
                if (skin != null)
                {
                    skin.Visible = this.Visible;
                }
                else
                {
                    UpdateForm.CreateControlRegion(this, TrankBack(), 255);
                    show = true;
                    skin = new SkinForm(this);
                    skin.Show();
                }
            }
            base.OnVisibleChanged(e);
        }

        //大小改变时
        protected override void OnSizeChanged(EventArgs e)
        {
            if (SkinBack != null && show)
            {
                UpdateForm.CreateControlRegion(this, TrankBack(), 255);
                skin.Size = this.Size;
            }
            base.OnSizeChanged(e);
        }
        #endregion
    }
}
