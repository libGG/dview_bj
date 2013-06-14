//created by lib
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DView.SXEQJB.TempleteMgr.Controls;

namespace DView.SXEQJB.TempleteMgr
{
    public partial class FrmImportTemp : DevExpress.XtraEditors.XtraForm
    {
        public FrmImportTemp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置模板参数表项内容
        /// </summary>
        /// <param name="name">模板名称</param>
        /// <param name="fileName">模板文件</param>
        public void SetFileName(string name,string fileName)
        {
            this.importTempleteTableCtl1.TempleteName = name;
            this.importTempleteTableCtl1.FileName = fileName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.importTempleteTableCtl1.Format))
            {
                XtraMessageBox.Show("没有设置格式", "提醒", MessageBoxButtons.OK);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// 获取模板参数
        /// </summary>
        /// <returns></returns>
        public ImportTempleteTableCtl GetTempleteModel()
        {
            return this.importTempleteTableCtl1;
        }
    }
}