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
    /// ����ģ���¼�����
    /// </summary>
    /// <param name="model">ImportTempleteTableCtl���ͣ�����һЩ������Ϣ</param>
    public delegate void ImportTempHandler(ImportTempleteTableCtl model);
    /// <summary>
    /// ���ģ��༭����״̬�¼�����
    /// </summary>
    /// <param name="style">ģ�嶨�����ͣ��������½��͵���</param>
    /// <returns></returns>
    public delegate bool CheckFrmEditOpenedHandler(CustomStyle style);

    public partial class FrmQueryCus : DevExpress.XtraEditors.XtraForm
    {
        #region ��������
        /// <summary>
        /// ������ģ���¼��Ĵ�����
        /// </summary>
        public ImportTempHandler OnImportTemp;
        /// <summary>
        /// ���ģ��༭����״̬�¼�������
        /// </summary>
        public CheckFrmEditOpenedHandler OnCheckFrmEditOpened;
        #endregion

        #region ���캯��
        public FrmQueryCus()
        {
            InitializeComponent();
        }
        #endregion

        #region UI�ؼ��¼�����
        private void btnNewTemp_Click(object sender, EventArgs e)
        {
            this.newTemplete();
        }

        private void btnImportTemp_Click(object sender, EventArgs e)
        {
            this.import();
        }
        #endregion

        #region ҵ���߼�����
        /// <summary>
        /// �½�ģ��
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
                //XtraMessageBox.Show("��⵽ϵͳ��ǰ��Word���������У����ȹرյ�����Word����", "����", MessageBoxButtons.OK);
                FrmQueryCloseWord.GetInstance().ShowDialog();
                this.DialogResult = DialogResult.None;
            }
        }
        /// <summary>
        /// ����ģ��
        /// </summary>
        private void import()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "ѡ��Ҫ�����wordģ��";
            ofd.Filter = "Word �ĵ�(*.doc;*.docx)|*.doc;*.docx";
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
                    XtraMessageBox.Show("����ɹ�", "��ʾ", MessageBoxButtons.OK);
                    isOk = true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "����ʧ��", MessageBoxButtons.OK);
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