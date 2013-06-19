//created by lib
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DView.SXEQJB.TempleteMgr.Dal;
using System.IO;

namespace DView.SXEQJB.TempleteMgr
{
    /// <summary>
    /// 预览word模板文档
    /// </summary>
    public partial class FrmPreViewTemp : DevExpress.XtraEditors.XtraForm
    {
        #region 私有成员变量

        /// <summary>
        /// 模板管理类
        /// </summary>
        private TempleteMgr _tempMgr = new TempleteMgr();
        /// <summary>
        /// 模板的fguid
        /// </summary>
        private string _fguid;
        /// <summary>
        /// 模板文件名，全路径，存放在临时目录中
        /// </summary>
        private string _fileName;

        #endregion

        #region 构造函数
        public FrmPreViewTemp()
        {
            InitializeComponent();
            axFramerControlPreView.Titlebar = false;
            axFramerControlPreView.Toolbars = false;
            axFramerControlPreView.Menubar = false;
            this.Visible = false;
        }
        #endregion

        #region UI控件事件处理
        private void FrmPreViewTemp_Load(object sender, EventArgs e)
        {
            this.loadDoc();
        }

        private void FrmPreViewTemp_Shown(object sender, EventArgs e)
        {
            this.axFramerControlPreView.PrintPreview();
            this.Visible = true;
        }

        private void FrmPreViewTemp_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.deleteTempFile();
        }
        #endregion
        
        /// <summary>
        /// 设置即将预览模板的fguid
        /// </summary>
        /// <param name="fguid"></param>
        public void SetFguid(string fguid)
        {
            this._fguid = fguid;
        }

        /// <summary>
        /// 删除临时文件
        /// </summary>
        private void deleteTempFile()
        {
            //System.Net.WebRequestMethods.File
            //删除临时文件
            File.Delete(this._fileName);
        }

        /// <summary>
        /// 加载doc文件到预览窗口
        /// </summary>
        private void loadDoc()
        {
            try
            {
                SXEQ_JBMB model = new SXEQ_JBMB();
                this._fileName = this._tempMgr.GetWord(this._fguid, out model);
                object readStyle = true;
                this.axFramerControlPreView.Open(this._fileName, readStyle, "Word.Document", "", "");
                this.Text = model.name + " - 模板预览";
            }
            catch (Exception ex)
            {
                string info = string.Format(@"加载word文件失败，可能原因：\r\n①本机没有安装office软件，
                    ②本机可能装有wsp，不能在同时装有office和wps机子上运行本程序\r\n{0}", ex);
                XtraMessageBox.Show(info, "提醒", MessageBoxButtons.OK);      
            }
        }
    }
}