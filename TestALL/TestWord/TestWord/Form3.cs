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
            //int y, dy;                                                         //�������
            //y = this.ClientRectangle.Location.Y;
            //dy = this.ClientRectangle.Height / 256;
            //for (int i = 255; i >= 0; i--)                           //����forѭ�����䴰�屳��
            //{
            //    Color c = new Color();                           //������ɫ������
            //    c = Color.FromArgb(255, i, 0);
            //    SolidBrush sb = new SolidBrush(c);     //���廭ˢ��ɫ
            //    Pen p = new Pen(sb, 1);                         //���廭��
            //    e.Graphics.DrawRectangle(p, this.ClientRectangle.X, y, this.Width, y + dy);//���ƾ���
            //    y = y + dy;
            //}
        }
    }

}