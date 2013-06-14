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
        /// 选择关闭Word对话框窗体实例对象
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
        /// 遍历所有进程，把Word进程kill掉
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
                XtraMessageBox.Show("自动关闭失败，请在任务管理器中尝试手动关闭“WINWORD.exe”进程\r\n" + ex.ToString(), "出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (hasOk)
                {
                    XtraMessageBox.Show("已关闭所有Word", "提示", MessageBoxButtons.OK);
                }
                this.Close();
            }
        }
    }
}