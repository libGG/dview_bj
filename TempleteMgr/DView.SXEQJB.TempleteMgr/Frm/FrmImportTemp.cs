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
        /// ����ģ�������������
        /// </summary>
        /// <param name="name">ģ������</param>
        /// <param name="fileName">ģ���ļ�</param>
        public void SetFileName(string name,string fileName)
        {
            this.importTempleteTableCtl1.TempleteName = name;
            this.importTempleteTableCtl1.FileName = fileName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.importTempleteTableCtl1.Format))
            {
                XtraMessageBox.Show("û�����ø�ʽ", "����", MessageBoxButtons.OK);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// ��ȡģ�����
        /// </summary>
        /// <returns></returns>
        public ImportTempleteTableCtl GetTempleteModel()
        {
            return this.importTempleteTableCtl1;
        }
    }
}