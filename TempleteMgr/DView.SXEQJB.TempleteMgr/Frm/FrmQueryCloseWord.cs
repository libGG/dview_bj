//created by lib
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;

namespace DView.SXEQJB.TempleteMgr
{
    public partial class FrmQueryCloseWord : DevExpress.XtraEditors.XtraForm
    {
        private static FrmQueryCloseWord _instance = null;

        /// <summary>
        /// ѡ��ر�Word�Ի�����ʵ������
        /// </summary>
        public static FrmQueryCloseWord GetInstance()
        {
            if (null == _instance)
            {
                _instance = new FrmQueryCloseWord();
            }
            return _instance;
        }

        public FrmQueryCloseWord()
        {
            InitializeComponent();
        }

        private void btnAutomatic_Click(object sender, EventArgs e)
        {
            this.closeAllWordAutomatic();
        }
        /// <summary>
        /// �������н��̣���Word����kill��
        /// </summary>
        private void closeAllWordAutomatic()
        {
            bool hasOk = false;
            Process[] ps = Process.GetProcesses();
            try
            {
                foreach (Process var in ps)
                {
                    if (var.ProcessName.ToLower() == "winword")
                    {
                        var.Kill();
                    }
                }
                hasOk = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("�Զ��ر�ʧ�ܣ���������������г����ֶ��رա�WINWORD.exe������\r\n" + ex.ToString(), "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (hasOk)
                {
                    XtraMessageBox.Show("�ѹر�����Word", "��ʾ", MessageBoxButtons.OK);
                }
                this.Close();
            }
        }
    }
}