using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestWord
{
    public partial class Form1 : Form
    {
        public static Form2 FrmChild = null;
        public Form1()
        {
            InitializeComponent();


            axFramerControl1.Toolbars = true;
            axFramerControl1.Menubar = true;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            axFramerControl1.PrintPreview();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axFramerControl1.Toolbars = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            axFramerControl1.Save();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql =@"insert into sxeq_jbmb (FGUID, NAME, CATEGORY, BOOKMARK, AUTHOR, MEMO, FORMAT)
values ('fdd11111111112', 'dfsf', 'sdfsf', 'sfs', 'fsdsf', 'sfs', 'dfsd')";
            int count = DbHelperOra.ExecuteSql(sql);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            axFramerControl1.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            bool b = textEdit1.Text == null;
            textEdit1.Text = null;
            b = textEdit1.Text == null;
            string s="";
            s = null;
            s.Trim();
            s = s.ToLower();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //if (null == FrmChild)
            //{
            //    FrmChild = new Form2();
            //    FrmChild.Show();
            //}
            //else
            //{
            //    FrmChild.Activate();
            //    FrmChild.Focus();
            //}
            foreach (Form var in Application.OpenForms)
            {
                if (var.Name == "Form2")
                {
                    MessageBox.Show("该窗体已打开");
                    var.Activate();
                    return;
                }
            }
            Form2 frm = new Form2();
            frm.Show();
        }
    }
}