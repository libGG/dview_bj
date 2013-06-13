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
    /// �����½�ģ���Ĵ�����
    /// </summary>
    /// <param name="SXEQ_JBMB">ģ����������ģ��</param>
    public delegate void TempleteChangedHandler(SXEQ_JBMB model);
    public partial class FrmTempEdit : DevExpress.XtraEditors.XtraForm
    {
        #region ˽�б���

        /// <summary>
        /// �Ƿ����½�ģ�壬Ĭ�����޸�false���½�true
        /// </summary>
        private bool _isNew = false;
        /// <summary>
        /// ģ�����ʵ�壬�����޸�ģ���ʱ��
        /// </summary>
        private SXEQ_JBMB _model = new SXEQ_JBMB();
        /// <summary>
        /// �ļ��ڱ��ؼ�����ϵ�ȫ·��
        /// </summary>
        private string _fileName;

        private TempleteMgr _tempMgr = new TempleteMgr();

        private Microsoft.Office.Interop.Word.Document _doc = null;
        private Microsoft.Office.Interop.Word.Application _app = null;

        /// <summary>
        /// ģ������fguid
        /// </summary>
        private string _pguid;
        #endregion

        #region ��������
        /// <summary>
        /// ��ǰ�޸�ģ���fguid�����ڲ�ѯ
        /// </summary>
        public string TempleteGuid;

        public TempleteChangedHandler OnTempleteChanged;
        #endregion

        #region ���캯��
        /// <summary>
        /// ģ������壬���캯��
        /// </summary>
        /// <param name="isNew">�Ƿ����½�ģ�壬Ĭ�����޸�false���½�true</param>
        public FrmTempEdit(bool isNew)
        {
            InitializeComponent();
            this._isNew = isNew;
            this.FramerCtlNew.Titlebar = false;
            this.FramerCtlNew.Menubar = false;
                    
        }
        #endregion

        #region ҵ���߼�����

        /// <summary>
        /// ��Dsoframer�ؼ���ȡword��ض���
        /// </summary>
        /// <param name="wordCtl">Dsoframer�ؼ�����</param>
        private void init(AxDSOFramer.AxFramerControl wordCtl)
        {
            this._doc = wordCtl.ActiveDocument as Microsoft.Office.Interop.Word.Document;
            this._app = _doc.Application;
        }
        /// <summary>
        /// ����ģ�����������
        /// </summary>
        /// <param name="pguid"></param>
        public void SetPGuid(string pguid)
        {
            this._pguid = pguid;
        }

        /// <summary>
        /// �½�word�ĵ�
        /// </summary>
        private void createNewWord()
        {
            try
            {
                this.FramerCtlNew.CreateNew("Word.Document");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("����û�а�װword��������Ȱ�װ��\r\n" + ex.ToString(), "����", MessageBoxButtons.OK);
                this.Close();
            }
        }

        /// <summary>
        /// ��ʼ��ģ�����
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
                    throw new Exception("û�л�ȡ��ģ���fguid");
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
        /// ��ʼ���޸�ģ��
        /// </summary>
        /// <param name="fileName">�ĵ�����ʱĿ¼���ļ���</param>
        /// <param name="fguid">ģ��fguid</param>
        /// <param name="model">ģ��ʵ�����</param>
        private void initModify(out string fileName,string fguid,out SXEQ_JBMB model)
        {
            model = this._tempMgr.JBMB_DAL.GetModel(fguid);
            fileName = System.IO.Path.GetTempPath()+"\\" + DateTime.Now.ToString("yyyy-MM-dd hh-MM-ss") + ".doc";
            System.IO.File.WriteAllBytes(fileName, model.filedoc);
            this.FramerCtlNew.Open(fileName);
        }

        /// <summary>
        /// ����ģ��
        /// </summary>
        private void updateTemplete()
        {
            this._model.author = this.templete.Author;
            //this._model.category = "���";
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
            XtraMessageBox.Show("�޸����", "��ʾ",  MessageBoxButtons.OK);
        }

        /// <summary>
        /// �½�ģ��
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
                XtraMessageBox.Show("û�����ø�ʽ", "����", MessageBoxButtons.OK);
                return;
            }
            model.memo = this.templete.Memo;
            model.name = this.templete.TempleteName;
            string fileName = System.IO.Path.GetTempPath() + "\\" + DateTime.Now.ToString("yyyy-MM-dd hh-MM-ss") + ".doc";
            model.filedoc = this.saveWord(fileName);
            model.bookmark = this._tempMgr.GetBookmark(fileName + "_copy");
            if (string.IsNullOrEmpty(model.bookmark))
            {
                XtraMessageBox.Show("��ģ���ĵ�û����ǩ", "ʧ��", MessageBoxButtons.OK);
                return;
            }
            this._tempMgr.JBMB_DAL.Add(model);
            if (this.OnTempleteChanged != null)
            {
                this.OnTempleteChanged(model);
            }
            XtraMessageBox.Show("�������", "��ʾ", MessageBoxButtons.OK);
        }
        /// <summary>
        /// ����word�ļ�����ʱĿ¼�������ظ��ļ��Ķ�������ʽ
        /// </summary>
        /// <param name="fileName">�ļ�·��</param>
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
            //���word��ǰ�����ã����øöԻ�����쳣
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
                XtraMessageBox.Show(ex.ToString(), "����", MessageBoxButtons.OK);
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

        #region UI�ؼ��¼�����
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