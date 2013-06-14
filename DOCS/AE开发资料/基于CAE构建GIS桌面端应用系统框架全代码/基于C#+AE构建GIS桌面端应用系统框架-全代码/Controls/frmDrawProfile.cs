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
           //ȡ�ü�¼����
            int count = m_pSewerElevArray.Count;
            //����ͼ����
            int wd = 80 + 20 * (count - 1);
            //������С���
            if (wd < 800)
                wd = 800;
            //����Bitmap����
            //���ɻ�ͼ����
            Graphics g = e.Graphics;
            //�����ɫ����
            Pen Bp = new Pen(Color.Black);
            //�����ɫ����
            Pen Rp = new Pen(Color.Red);
            //��������ɫ����
            Pen Sp = new Pen(Color.Silver);
            //������������
            Font Bfont = new Font("Arial", 12, FontStyle.Bold);
            //����һ������
            Font font = new Font("Arial", 6);
            //�����������
            Font  Tfont = new Font("Arial", 9);
            //���Ƶ�ɫ
            g.DrawRectangle(new Pen(Color.White, 400), 0, 0, wd, 400);
            //�����ɫ�����ͱ�ˢ
            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, wd, 400), Color.Black, Color.Black, 1.2F, true);
            //������ɫ�����ͱ�ˢ
            LinearGradientBrush Bluebrush = new LinearGradientBrush(new Rectangle(0, 0, wd, 400), Color.Blue, Color.Blue, 1.2F, true);
            //���ƴ����
            g.DrawString("���߸߳���������ͼ", Bfont, brush, 40, 5);
            //���Ʊ߿�
            g.DrawRectangle(Bp, 0, 0, wd - 1, 400 - 1);
            //������������
            int i = 0;
            for (i = 0; i < count; i++)
            {
                g.DrawLine(Sp, 40 + 20 * i, 60, 40 + 20 * i, 360);
            }
            //�����������ǩ
            for (i = 0; i < count; i ++)
            {
                clsProfileStruct s= m_pSewerElevArray.get_Element(i) as clsProfileStruct ;
                string st = s.M.ToString();
                g.DrawString(st, font, brush, 30 + 20 * i, 370);
            }
            //���ƺ�������
            for (i = 0; i < 10; i++)
            {
                g.DrawLine(Sp, 40, 60 + 30 * i, 40 + 20 * (count - 1), 60 + 30 * i);
                int s = 500 - 50 * i * 5;
                g.DrawString(s.ToString(), font, brush, 10, 60 + 30 * i);
            }
            //������������
            g.DrawLine(Bp, 40, 55, 40, 360);
            //���ƺ�������
            g.DrawLine(Bp, 40, 360, 45 + 20 * (count - 1), 360);
            //��������ת�۵�
            Point[] p = new Point[count];
            for (i = 0; i < count; i++)
            {
                clsProfileStruct s= m_pSewerElevArray.get_Element(i) as clsProfileStruct ;
                p[i].X = 40 + 20 * i;
                p[i].Y = 360 - Convert.ToInt32(s.Z) / 5 ;
            }
            //��������
            g.DrawLines(Rp, p);
            for (i = 0; i < count; i++)
            {
                clsProfileStruct s = m_pSewerElevArray.get_Element(i) as clsProfileStruct;
                g.DrawString(s.Z.ToString(), font, Bluebrush, p[i].X, p[i].Y - 10);
                g.DrawRectangle(Rp, p[i].X - 1, p[i].Y - 1, 2, 2);
            }

            

        }
        //��ȡ�غͣ���̶�
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
  ��
        
        //��������Z��ֵ�����ֵ
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
        //��������Z��ֵ����Сֵ
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
        //�������У�ֵ�����ֵ
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
        //�������У�ֵ����Сֵ
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
        //��SewerElev�ֶ��е����ֵ
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
        //��SewerElev�ֶ��е���Сֵ
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