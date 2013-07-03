using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        private Point _pointori;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            g.FillRectangle(blueBrush, this._pointori.X, this._pointori.Y, Math.Abs(this._pointori.X - e.X), Math.Abs(this._pointori.Y - e.Y));
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            this._pointori = new Point(e.X, e.Y);
        }
    }
}