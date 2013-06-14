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
using System.IO;

namespace DView.SXEQJB.TempleteMgr
{
    /// <summary>
    /// 导入模板事件处理
    /// </summary>
    /// <param name="model">ImportTempleteTableCtl类型，包含一些参数信息</param>
    public delegate void ImportTempHandler(ImportTempleteTableCtl model);
    /// <summary>
    /// 检查模板编辑窗口状态事件处理
    /// </summary>
    /// <param name="style">模板定制类型，包含：新建和导入</param>
    /// <returns></returns>
    public delegate bool CheckFrmEditOpenedHandler(CustomStyle style);

    public partial class FrmQueryCus : DevExpress.XtraEditors.XtraForm
    {
        #region 公共变量
        /// <summary>
        /// 当导入模板事件的处理函数
        /// </summary>
        public ImportTempHandler OnImportTemp;
        /// <summary>
        /// 检查模板编辑窗口状态事件处理函数
        /// </summary>
        public CheckFrmEditOpenedHandler OnCheckFrmEditOpened;
        #endregion

        #region 构造函数
        public FrmQueryCus()
        {
            InitializeComponent();
        }
        #endregion

        #region UI控件事件处理
        private void btnNewTemp_Click(object sender, EventArgs e)
        {
            this.newTemplete();
        }

        private void btnImportTemp_Click(object sender, EventArgs e)
        {
            this.import();
        }
        #endregion

        #region 业务逻辑函数
        /// <summary>
        /// 新建模板
        /// </summary>
        private void newTemplete()
        {
            if (null != this.OnCheckFrmEditOpened)
            {
                if (this.OnCheckFrmEditOpened(CustomStyle.NewTemplete))
                {
                    this.DialogResult = DialogResult.None;
                    this.Close();
                    return;
                }
            }
            bool hasWordProcess = CommonUtl.CheckProcessHasWord();
            if (hasWordProcess)
            {
                //XtraMessageBox.Show("检测到系统当前有Word程序在运行，请先关闭掉所有Word程序！", "提醒", MessageBoxButtons.OK);
                FrmQueryCloseWord.GetInstance().ShowDialog();
                this.DialogResult = DialogResult.None;
            }
        }
        /// <summary>
        /// 导入模板
        /// </summary>
        private void import()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择要导入的word模板";
            ofd.Filter = "Word 文档(*.doc;*.docx)|*.doc;*.docx";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            FrmImportTemp frm = new FrmImportTemp();
            frm.SetFileName(Path.GetFileNameWithoutExtension(ofd.FileName),ofd.FileName.Trim());
            if (frm.ShowDialog() != DialogResult.OK) return;
            bool isOk = false;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                panelControl1.Enabled = false;
                if (null != this.OnImportTemp)
                {
                    this.OnImportTemp(frm.GetTempleteModel());
                    XtraMessageBox.Show("导入成功", "提示", MessageBoxButtons.OK);
                    isOk = true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "导入失败", MessageBoxButtons.OK);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                panelControl1.Enabled = true;
                if (isOk)
                {
                    this.Close();
                }
            }
        }
        #endregion 
    }
}