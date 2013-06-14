using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using CCWin.SkinClass;

namespace CCWin.SkinControl
{
    [ToolboxBitmap(typeof(Label))]
    public class SkinLabel : Label
    {
        #region 变量
        private ArtTextStyle _artTextStyle = ArtTextStyle.Border;
        private int _borderSize = 1;
        private Color _borderColor = Color.White;
        #endregion

        #region 无参构造
        public SkinLabel()
            : base()
        {
            SetStyles();
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        }
        #endregion

        #region 属性
        [Browsable(true)]
        [Category("Skin")]
        [DefaultValue(typeof(ArtTextStyle), "1")]
        [Description("字体样式（None:正常样式,Border:边框样式,Relievo:浮雕样式,Forme:印版样式,Anamorphosis:渐变样式）")]
        public ArtTextStyle ArtTextStyle
        {
            get { return _artTextStyle; }
            set
            {
                if (_artTextStyle != value)
                {
                    _artTextStyle = value;
                    base.Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Skin")]
        [DefaultValue(1)]
        [Description("样式效果宽度")]
        public int BorderSize
        {
            get { return _borderSize; }
            set
            {
                if (_borderSize != value)
                {
                    _borderSize = value;
                    base.Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Skin")]
        [DefaultValue(typeof(Color), "80, 0, 0, 0")]
        [Description("样式效果颜色")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                if (_borderColor != value)
                {
                    _borderColor = value;
                    base.Invalidate();
                }
            }
        }

        #endregion

        #region 重载事件
        protected override void OnPaint(PaintEventArgs e)
        {
            if (ArtTextStyle == ArtTextStyle.None)
            {
                base.OnPaint(e);
                return;
            }
            if (base.Text.Length == 0)
            {
                return;
            }

            RenderText(e.Graphics);
        }
        #endregion

        #region 根据范围宽度截取字符串(SetStrLeng)
        //根据范围宽度截取字符串
        public string SetStrLeng(string txt, Font font, int width)
        {
            Size sizef = TextRenderer.MeasureText(txt, font);
            while (sizef.Width > width && txt.Length != 0)
            {
                txt = txt.Substring(0, txt.Length - 1);
                sizef = TextRenderer.MeasureText(txt, font);
            }
            return txt;
        }
        #endregion

        #region 绘画方法
        private void RenderText(Graphics g)
        {
            using (TextRenderingHintGraphics textRenderGraphics
                = new TextRenderingHintGraphics(g))
            {
                PointF point = CalculateRenderTextStartPoint(g);
                switch (_artTextStyle)
                {
                    case ArtTextStyle.Border:
                        RenderBordText(g, point);
                        break;
                    case ArtTextStyle.Relievo:
                        RenderRelievoText(g, point);
                        break;
                    case ArtTextStyle.Forme:
                        RenderFormeText(g, point);
                        break;
                    case ArtTextStyle.Anamorphosis:
                        RenderAnamorphosisText(g, point);
                        break;
                }
            }
        }

        private void RenderAnamorphosisText(Graphics g, PointF point)
        {
            using (Brush brush = new SolidBrush(base.ForeColor))
            {
                Rectangle rc = new Rectangle(new Point(Convert.ToInt32(point.X), Convert.ToInt32(point.Y)), ClientRectangle.Size);
                Image img = UpdateForm.ImageLightEffect(Text, base.Font, ForeColor, BorderColor, BorderSize, rc, !AutoSize);
                g.DrawImage(img, point.X - (BorderSize / 2), point.Y - (BorderSize / 2));
            }
        }


        private void RenderFormeText(Graphics g, PointF point)
        {
            StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);
            sf.Trimming = AutoSize ? StringTrimming.None : StringTrimming.EllipsisWord;
            Rectangle rc = new Rectangle(new Point(Convert.ToInt32(point.X), Convert.ToInt32(point.Y)), ClientRectangle.Size);

            using (Brush brush = new SolidBrush(_borderColor))
            {
                for (int i = 1; i <= _borderSize; i++)
                {
                    g.DrawString(
                        Text,
                        base.Font,
                        brush,
                        new Rectangle(new Point(
                            Convert.ToInt32(point.X - i),
                            Convert.ToInt32(point.Y + i)),
                            ClientRectangle.Size),
                        sf);
                }
            }

            using (Brush brush = new SolidBrush(base.ForeColor))
            {
                g.DrawString(Text, Font, brush, rc, sf);
            }
        }

        private void RenderRelievoText(Graphics g, PointF point)
        {
            StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);
            sf.Trimming = AutoSize ? StringTrimming.None : StringTrimming.EllipsisWord;
            Rectangle rc = new Rectangle(new Point(Convert.ToInt32(point.X), Convert.ToInt32(point.Y)), ClientRectangle.Size);
            using (Brush brush = new SolidBrush(_borderColor))
            {
                for (int i = 1; i <= _borderSize; i++)
                {
                    g.DrawString(
                        Text,
                        base.Font,
                        brush,
                        new Rectangle(new Point(
                            Convert.ToInt32(point.X + i),
                            Convert.ToInt32(point.Y)),
                            ClientRectangle.Size),
                        sf);
                    g.DrawString(
                        Text,
                        base.Font,
                        brush,
                        new Rectangle(new Point(
                            Convert.ToInt32(point.X),
                            Convert.ToInt32(point.Y + i)),
                            ClientRectangle.Size),
                        sf);
                }
            }

            using (Brush brush = new SolidBrush(base.ForeColor))
            {
                g.DrawString(
                    Text, base.Font, brush, rc, sf);
            }
        }

        private void RenderBordText(Graphics g, PointF point)
        {
            StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);
            sf.Trimming = AutoSize ? StringTrimming.None : StringTrimming.EllipsisWord;
            Rectangle rc = new Rectangle(new Point(Convert.ToInt32(point.X), Convert.ToInt32(point.Y)), ClientRectangle.Size);
            using (Brush brush = new SolidBrush(_borderColor))
            {
                for (int i = 1; i <= _borderSize; i++)
                {
                    g.DrawString(
                        Text,
                        base.Font,
                        brush,
                        new Rectangle(new Point(
                            Convert.ToInt32(point.X - i),
                            Convert.ToInt32(point.Y)),
                            ClientRectangle.Size),
                        sf);
                    g.DrawString(
                        Text,
                        base.Font,
                        brush,
                        new Rectangle(new Point(
                            Convert.ToInt32(point.X),
                            Convert.ToInt32(point.Y - i)),
                            ClientRectangle.Size),
                        sf);
                    g.DrawString(
                        Text,
                        base.Font,
                        brush,
                        new Rectangle(new Point(
                            Convert.ToInt32(point.X + i),
                            Convert.ToInt32(point.Y)),
                            ClientRectangle.Size),
                        sf);
                    g.DrawString(
                        Text,
                        base.Font,
                        brush,
                        new Rectangle(new Point(
                            Convert.ToInt32(point.X),
                            Convert.ToInt32(point.Y + i)),
                            ClientRectangle.Size),
                        sf);
                }
            }

            using (Brush brush = new SolidBrush(base.ForeColor))
            {
                g.DrawString(
                    Text, base.Font, brush, rc, sf);
            }
        }

        private PointF CalculateRenderTextStartPoint(Graphics g)
        {
            PointF point = PointF.Empty;

            SizeF textSize = g.MeasureString(
                base.Text,
                base.Font,
                PointF.Empty,
                StringFormat.GenericTypographic);

            if (AutoSize)
            {
                point.X = Padding.Left;
                point.Y = Padding.Top;
            }
            else
            {
                ContentAlignment align = base.TextAlign;
                if (align == ContentAlignment.TopLeft ||
                    align == ContentAlignment.MiddleLeft ||
                    align == ContentAlignment.BottomLeft)
                {
                    point.X = Padding.Left;
                }

                else if (align == ContentAlignment.TopCenter ||
                         align == ContentAlignment.MiddleCenter ||
                         align == ContentAlignment.BottomCenter)
                {
                    point.X = (Width - textSize.Width) / 2f;
                }
                else
                {
                    point.X = Width - (Padding.Right + textSize.Width);
                }

                if (align == ContentAlignment.TopLeft ||
                    align == ContentAlignment.TopCenter ||
                    align == ContentAlignment.TopRight)
                {
                    point.Y = Padding.Top;
                }
                else if (align == ContentAlignment.MiddleLeft ||
                         align == ContentAlignment.MiddleCenter ||
                         align == ContentAlignment.MiddleRight)
                {
                    point.Y = (Height - textSize.Height) / 2f;
                }
                else
                {
                    point.Y = Height - (Padding.Bottom + textSize.Height);
                }
            }

            return point;
        }

        #endregion

        #region 减少闪烁方法
        private void SetStyles()
        {
            //设置自定义控件Style
            this.SetStyle(ControlStyles.ResizeRedraw, true);//调整大小时重绘
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);// 双缓冲
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);// 禁止擦除背景.
            this.SetStyle(ControlStyles.UserPaint, true);//自行绘制
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            UpdateStyles();
        }
        #endregion
    }
}
