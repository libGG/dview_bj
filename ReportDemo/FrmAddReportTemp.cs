using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace ReportDemo
{
    public partial class FrmAddReportTemp : DevExpress.XtraEditors.XtraForm
    {
      

        public FrmAddReportTemp()
        {
            InitializeComponent();
        }

        public string docPath = "";

      
       
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            docPath = this.txtName.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenTemplate_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "选择报表模板";
            op.Filter = "报表模板(*.doc)|*.doc";
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtName.Text = op.FileName;
            }
        }

        private void FrmAddReportTemp_Load(object sender, EventArgs e)
        {
            this.txtOperator.Text = "管理员";
        }
    }
}