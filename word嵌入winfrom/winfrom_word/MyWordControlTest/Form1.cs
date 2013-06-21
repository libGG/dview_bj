using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyWordControlTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();
            //appWord.Visible = true;
            //appWord.Activate();
            Microsoft.Office.Interop.Word.ApplicationClass app = new Microsoft.Office.Interop.Word.ApplicationClass();
            app.Visible = true;
        }
    }
}