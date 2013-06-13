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
        /// <summary>
        /// 设置即将预览模板的fguid
        /// </summary>
        /// <param name="fguid"></param>
        public void SetFguid(string fguid)
        {
            this._fguid = fguid;
        }

        private void FrmPreViewTemp_Load(object sender, EventArgs e)
        {
            SXEQ_JBMB model = new SXEQ_JBMB();
            this._fileName = this._tempMgr.GetWord(this._fguid, out model);
            object readStyle = true;
            this.axFramerControlPreView.Open(this._fileName, readStyle, "Word.Document", "", "");
            this.Text = model.name + " - 模板预览";
        }

        private void FrmPreViewTemp_Shown(object sender, EventArgs e)
        {
            this.axFramerControlPreView.PrintPreview();
            this.Visible = true;
        }

        private void FrmPreViewTemp_FormClosed(object sender, FormClosedEventArgs e)
        {
            //System.Net.WebRequestMethods.File
            //删除临时文件
            File.Delete(this._fileName);
        }
    }
}