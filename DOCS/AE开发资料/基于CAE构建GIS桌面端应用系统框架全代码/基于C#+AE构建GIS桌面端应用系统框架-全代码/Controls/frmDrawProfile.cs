using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Drawing.Drawing2D;

using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
 
namespace Controls
{
    public partial class frmDrawProfile : Form
    {
        private IArray m_pSewerElevArray = null;
        public frmDrawProfile(IArray _ppSewerElevArray)
        {
            m_pSewerElevArray = _ppSewerElevArray;
            InitializeComponent();
        }

        private void frmDrawProfile_Paint(object sender, PaintEventArgs e)
        {
           //取得记录数量
            int count = m_pSewerElevArray.Count;
            //计算图表宽度
            int wd = 80 + 20 * (count - 1);
            //设置最小宽度
            if (wd < 800)
                wd = 800;
            //生成Bitmap对象
            //生成绘图对象
            Graphics g = e.Graphics;
            //定义黑色画笔
            Pen Bp = new Pen(Color.Black);
            //定义红色画笔
            Pen Rp = new Pen(Color.Red);
            //定义银灰色画笔
            Pen Sp = new Pen(Color.Silver);
            //定义大标题字体
            Font Bfont = new Font("Arial", 12, FontStyle.Bold);
            //定义一般字体
            Font font = new Font("Arial", 6);
            //定义大点的字体
            Font  Tfont = new Font("Arial", 9);
            //绘制底色
            g.DrawRectangle(new Pen(Color.White, 400), 0, 0, wd, 400);
            //定义黑色过度型笔刷
            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, wd, 400), Color.Black, Color.Black, 1.2F, true);
            //定义兰色过度型笔刷
            LinearGradientBrush Bluebrush = new LinearGradientBrush(new Rectangle(0, 0, wd, 400), Color.Blue, Color.Blue, 1.2F, true);
            //绘制大标题
            g.DrawString("管线高程剖面曲线图", Bfont, brush, 40, 5);
            //绘制边框
            g.DrawRectangle(Bp, 0, 0, wd - 1, 400 - 1);
            //绘制竖坐标线
            int i = 0;
            for (i = 0; i < count; i++)
            {
                g.DrawLine(Sp, 40 + 20 * i, 60, 40 + 20 * i, 360);
            }
            //绘制竖坐标标签
            for (i = 0; i < count; i ++)
            {
                clsProfileStruct s= m_pSewerElevArray.get_Element(i) as clsProfileStruct ;
                string st = s.M.ToString();
                g.DrawString(st, font, brush, 30 + 20 * i, 370);
            }
            //绘制横坐标线
            for (i = 0; i < 10; i++)
            {
                g.DrawLine(Sp, 40, 60 + 30 * i, 40 + 20 * (count - 1), 60 + 30 * i);
                int s = 500 - 50 * i * 5;
                g.DrawString(s.ToString(), font, brush, 10, 60 + 30 * i);
            }
            //绘制竖坐标轴
            g.DrawLine(Bp, 40, 55, 40, 360);
            //绘制横坐标轴
            g.DrawLine(Bp, 40, 360, 45 + 20 * (count - 1), 360);
            //定义曲线转折点
            Point[] p = new Point[count];
            for (i = 0; i < count; i++)
            {
                clsProfileStruct s= m_pSewerElevArray.get_Element(i) as clsProfileStruct ;
                p[i].X = 40 + 20 * i;
                p[i].Y = 360 - Convert.ToInt32(s.Z) / 5 ;
            }
            //绘制曲线
            g.DrawLines(Rp, p);
            for (i = 0; i < count; i++)
            {
                clsProfileStruct s = m_pSewerElevArray.get_Element(i) as clsProfileStruct;
                g.DrawString(s.Z.ToString(), font, Bluebrush, p[i].X, p[i].Y - 10);
                g.DrawRectangle(Rp, p[i].X - 1, p[i].Y - 1, 2, 2);
            }

            

        }
        //求取Ｘ和Ｙ轴刻度
        private double GetXYLabel(double dMaxValue)
        {
            if (dMaxValue / 10 < 1)
                return 10;
            else if (dMaxValue / 100 < 1)
                return 100;
            else if (dMaxValue / 1000 < 1)
                return 1000;
            else if (dMaxValue / 10000 < 1)
                return 10000;
            return 0;
        }
  　
        
        //求数组中Z数值的最大值
        private double FindZmaxValue()
        {
            double maxZ=0;
            for (int i = 0; i <=m_pSewerElevArray.Count - 1; i++)
            {
                clsProfileStruct pProfileData = m_pSewerElevArray.get_Element(i) as clsProfileStruct ;
                if (pProfileData.Z > maxZ)
                    maxZ = pProfileData.Z;
            }
            return maxZ;
        }
        //求数组中Z数值的最小值
        private double FindZminValue()
        {
            clsProfileStruct pProfileData = m_pSewerElevArray.get_Element(0) as clsProfileStruct ;
            double minZ = pProfileData.Z;
            for (int i = 0; i <= m_pSewerElevArray.Count - 1; i++)
            {
                pProfileData = m_pSewerElevArray.get_Element(i) as clsProfileStruct;
                if (pProfileData.Z < minZ)
                {
                    minZ = pProfileData.Z;
                }
            }
            return minZ;
        }
        //求数组中Ｍ值的最大值
        private double FindMmaxValue()
        {
            double maxM = 0;
            for (int i = 0; i <= m_pSewerElevArray.Count - 1; i++)
            {
                clsProfileStruct pProfileData = m_pSewerElevArray.get_Element(i) as clsProfileStruct;
                if (pProfileData.M  > maxM)
                    maxM = pProfileData.M;
            }
            return maxM;
        }
        //求数组中Ｍ值的最小值
        private double FindMminValue()
        {
            clsProfileStruct pProfileData = m_pSewerElevArray.get_Element(0) as clsProfileStruct;
            double minM = pProfileData.M;
            for (int i = 0; i <= m_pSewerElevArray.Count - 1; i++)
            {
                pProfileData = m_pSewerElevArray.get_Element(i) as clsProfileStruct;
                if (pProfileData.M < minM)
                {
                    minM = pProfileData.M;
                }
            }
            return minM;
        }
        //求SewerElev字段中的最大值
        private double FindSEmaxValue()
        {
            double maxSE = 0;
            for (int i = 0; i <= m_pSewerElevArray.Count - 1; i++)
            {
                clsProfileStruct pProfileData = m_pSewerElevArray.get_Element(i) as clsProfileStruct;
                if (pProfileData.dSewerElev > maxSE)
                    maxSE = pProfileData.dSewerElev;
            }
            return maxSE;
        }
        //求SewerElev字段中的最小值
        private double FindSEminValue()
        {
            clsProfileStruct pProfileData = m_pSewerElevArray.get_Element(0) as clsProfileStruct;
            double minSE = pProfileData.dSewerElev;
            for (int i = 0; i <= m_pSewerElevArray.Count - 1; i++)
            {
                pProfileData = m_pSewerElevArray.get_Element(i) as clsProfileStruct;
                if (pProfileData.dSewerElev < minSE)
                {
                    minSE = pProfileData.dSewerElev;
                }
            }
            return minSE;
        }

    }
}