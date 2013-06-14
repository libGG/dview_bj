using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestDSOFramer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "word文档";
            ofd.Filter = "Word 文档(*.doc;*.docx)|*.doc;*.docx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                object readStyle = true;
                this.axFramerControl1.Open(ofd.FileName, readStyle, "Word.Document", "", "");
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.axFramerControl1.PrintPreview();
        }
    }
}