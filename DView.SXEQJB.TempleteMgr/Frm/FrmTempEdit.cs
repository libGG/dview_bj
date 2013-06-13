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
using Microsoft.Office;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;

namespace DView.SXEQJB.TempleteMgr
{
    /// <summary>
    /// 导入新建模板后的处理函数
    /// </summary>
    /// <param name="SXEQ_JBMB">模板管理表数据模型</param>
    public delegate void TempleteChangedHandler(SXEQ_JBMB model);
    public partial class FrmTempEdit : DevExpress.XtraEditors.XtraForm
    {
        #region 私有变量

        /// <summary>
        /// 是否是新建模板，默认是修改false，新建true
        /// </summary>
        private bool _isNew = false;
        /// <summary>
        /// 模板对象实体，用在修改模板的时候
        /// </summary>
        private SXEQ_JBMB _model = new SXEQ_JBMB();
        /// <summary>
        /// 文件在本地计算机上的全路径
        /// </summary>
        private string _fileName;

        private TempleteMgr _tempMgr = new TempleteMgr();

        private Microsoft.Office.Interop.Word.Document _doc = null;
        private Microsoft.Office.Interop.Word.Application _app = null;

        /// <summary>
        /// 模板类别的fguid
        /// </summary>
        private string _pguid;
        #endregion

        #region 公共变量
        /// <summary>
        /// 当前修改模板的fguid，用于查询
        /// </summary>
        public string TempleteGuid;

        public TempleteChangedHandler OnTempleteChanged;
        #endregion

        #region 构造函数
        /// <summary>
        /// 模板管理窗体，构造函数
        /// </summary>
        /// <param name="isNew">是否是新建模板，默认是修改false，新建true</param>
        public FrmTempEdit(bool isNew)
        {
            InitializeComponent();
            this._isNew = isNew;
            this.FramerCtlNew.Titlebar = false;
            this.FramerCtlNew.Menubar = false;
                    
        }
        #endregion

        #region 业务逻辑函数

        /// <summary>
        /// 从Dsoframer控件获取word相关对象
        /// </summary>
        /// <param name="wordCtl">Dsoframer控件对象</param>
        private void init(AxDSOFramer.AxFramerControl wordCtl)
        {
            this._doc = wordCtl.ActiveDocument as Microsoft.Office.Interop.Word.Document;
            this._app = _doc.Application;
        }
        /// <summary>
        /// 设置模板的外键，类别
        /// </summary>
        /// <param name="pguid"></param>
        public void SetPGuid(string pguid)
        {
            this._pguid = pguid;
        }

        /// <summary>
        /// 新建word文档
        /// </summary>
        private void createNewWord()
        {
            try
            {
                this.FramerCtlNew.CreateNew("Word.Document");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("本机没有安装word软件，请先安装！\r\n" + ex.ToString(), "错误", MessageBoxButtons.OK);
                this.Close();
            }
        }

        /// <summary>
        /// 初始化模板参数
        /// </summary>
        private void initTemplete()
        {
            if (this._isNew)
            {
                this.createNewWord();
            }
            else
            {
                if (string.IsNullOrEmpty(this.TempleteGuid)) //StrongTypingException
                {
                    throw new Exception("没有获取到模板的fguid");
                }
                this.initModify(out this._fileName, this.TempleteGuid, out this._model);
                this.templete.Format = this._model.format;
                this.templete.Author = this._model.author;
                this.templete.TempleteName = this._model.name;
                this.templete.Memo = this._model.memo;
            }
            this.init(this.FramerCtlNew);  
        }

        /// <summary>
        /// 初始化修改模板
        /// </summary>
        /// <param name="fileName">文档在临时目录的文件名</param>
        /// <param name="fguid">模板fguid</param>
        /// <param name="model">模板实体对象</param>
        private void initModify(out string fileName,string fguid,out SXEQ_JBMB model)
        {
            model = this._tempMgr.JBMB_DAL.GetModel(fguid);
            fileName = System.IO.Path.GetTempPath()+"\\" + DateTime.Now.ToString("yyyy-MM-dd hh-MM-ss") + ".doc";
            System.IO.File.WriteAllBytes(fileName, model.filedoc);
            this.FramerCtlNew.Open(fileName);
        }

        /// <summary>
        /// 更新模板
        /// </summary>
        private void updateTemplete()
        {
            this._model.author = this.templete.Author;
            //this._model.category = "类别";
            this._model.format = this.templete.Format;
            this._model.memo = this.templete.Memo;
            this._model.name = this.templete.TempleteName;
            this._model.filedoc = this.saveWord(this._fileName);
            this._model.bookmark = this._tempMgr.GetBookmark(this._fileName+"_copy");

            this._tempMgr.JBMB_DAL.Update(this._model);
            if (this.OnTempleteChanged != null)
            {
                this.OnTempleteChanged(this._model);
            }
            XtraMessageBox.Show("修改完成", "提示",  MessageBoxButtons.OK);
        }

        /// <summary>
        /// 新建模板
        /// </summary>
        private void addTemplete()
        {
            SXEQ_JBMB model = new SXEQ_JBMB();
            model.author = this.templete.Author;
            model.category = this._pguid;
            model.fguid = Guid.NewGuid().ToString("D");
            model.format = this.templete.Format;
            if (string.IsNullOrEmpty(model.format))
            {
                XtraMessageBox.Show("没有设置格式", "提醒", MessageBoxButtons.OK);
                return;
            }
            model.memo = this.templete.Memo;
            model.name = this.templete.TempleteName;
            string fileName = System.IO.Path.GetTempPath() + "\\" + DateTime.Now.ToString("yyyy-MM-dd hh-MM-ss") + ".doc";
            model.filedoc = this.saveWord(fileName);
            model.bookmark = this._tempMgr.GetBookmark(fileName + "_copy");
            if (string.IsNullOrEmpty(model.bookmark))
            {
                XtraMessageBox.Show("该模板文档没有书签", "失败", MessageBoxButtons.OK);
                return;
            }
            this._tempMgr.JBMB_DAL.Add(model);
            if (this.OnTempleteChanged != null)
            {
                this.OnTempleteChanged(model);
            }
            XtraMessageBox.Show("定制完成", "提示", MessageBoxButtons.OK);
        }
        /// <summary>
        /// 保存word文件到临时目录，并返回该文件的二进制形式
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <returns></returns>
        private byte[] saveWord(string fileName)
        {
            if (this._isNew)
            {
                this.FramerCtlNew.Save(fileName, true, "", "");
            }
            else
            {
                this.FramerCtlNew.Save();
            }
            return this._tempMgr.SaveWord(fileName);
        }

        private void openBookmarkMgr()
        {
            //如果word当前不可用，调用该对话框会异常
            //if (!this.panelControlWord.Enabled) return;//Execute()
            object timeout = 50000;
            this._app.Dialogs[WdWordDialog.wdDialogInsertBookmark].Show(ref timeout);
        }

        private void saveToServer()
        {
            try
            {
                this.panelControlWord.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                if (this._isNew)
                {
                    this.addTemplete();
                }
                else
                {
                    this.updateTemplete();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "出错", MessageBoxButtons.OK);
            }
            finally
            {
                this.panelControlWord.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void saveToLocal()
        {
            this.FramerCtlNew.ShowDialog(DSOFramer.dsoShowDialogType.dsoDialogSaveCopy);
        }

        #endregion

        #region UI控件事件处理
        private void btnBookmark2_Click(object sender, EventArgs e)
        {
            this.openBookmarkMgr();
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            this.saveToServer();
        }

        private void btnSaveToLocal2_Click(object sender, EventArgs e)
        {
            this.saveToLocal();
        }

        private void FrmNewTemplete_Shown(object sender, EventArgs e)
        {
            this.initTemplete();
        }
        #endregion
    }
}