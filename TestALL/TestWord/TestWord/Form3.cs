using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestWord
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
            //int y, dy;                                                         //定义变量
            //y = this.ClientRectangle.Location.Y;
            //dy = this.ClientRectangle.Height / 256;
            //for (int i = 255; i >= 0; i--)                           //利用for循环渐变窗体背景
            //{
            //    Color c = new Color();                           //定义颜色对象案例
            //    c = Color.FromArgb(255, i, 0);
            //    SolidBrush sb = new SolidBrush(c);     //定义画刷颜色
            //    Pen p = new Pen(sb, 1);                         //定义画笔
            //    e.Graphics.DrawRectangle(p, this.ClientRectangle.X, y, this.Width, y + dy);//绘制矩形
            //    y = y + dy;
            //}
        }
    }

}