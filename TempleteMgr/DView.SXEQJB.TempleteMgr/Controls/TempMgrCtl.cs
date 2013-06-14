//created by lib
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DView.SXEQJB.TempleteMgr.Dal;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace DView.SXEQJB.TempleteMgr.Controls
{
    /// <summary>
    /// ģ�����
    /// </summary>
    public partial class TempMgrCtl : DevExpress.XtraEditors.XtraUserControl
    {
        #region ˽�г�Ա

        private TempleteMgr _tempMgr = new TempleteMgr();
        private SXEQ_JBLB_DAL _JBLB_DAL = new SXEQ_JBLB_DAL();
        private TreeListNode _curNode;
        private SXEQ_JBLB _curJBLB;
        private SXEQ_JBMB _curJBMB;
        #endregion

        #region ���캯��
        public TempMgrCtl()
        {
            InitializeComponent();
            this.initTree();
        }
        #endregion

        #region ���������б�

         /// <summary>
        /// ��ʼ����
        /// </summary>
        private void initTree()
        {
            this.categoriesTreeList1.InitTree();            
        }

        #endregion

        #region UI�ؼ��¼�����

        private void btnCustomize2_Click(object sender, EventArgs e)
        {
            this.addTemplete();
        }

        private void btnModify2_Click(object sender, EventArgs e)
        {
            this.tempModify();
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            this.tempDelete();
        }

        private void btnPreView2_Click(object sender, EventArgs e)
        {
            this.tempPreView();
        }

        private void categoriesTreeList1_MouseDown(object sender, MouseEventArgs e)
        {
            TreeList tree = sender as TreeList;
            if (null == tree) return;
            TreeListHitInfo hitInfo = tree.CalcHitInfo(new Point(e.X, e.Y));
            if (null == hitInfo.Node) return;
            this._curNode = hitInfo.Node;
            this.categoriesTreeList1.FocusedNode = this._curNode;
            if (this._curNode.Tag is SXEQ_JBLB)
            {
                this._curJBLB = this._curNode.Tag as SXEQ_JBLB;
            }
            else if (this._curNode.Tag is SXEQ_JBMB)
            {
                this._curJBMB = this._curNode.Tag as SXEQ_JBMB;
            }
            this.OnMBFocusedNodeChanged(this._curNode);
        }

        private void categoriesTreeList1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeList tree = sender as TreeList;
            if (null == tree) return;
            TreeListHitInfo hitInfo = tree.CalcHitInfo(new Point(e.X, e.Y));
            if (null == hitInfo.Node) return;
            this._curNode = hitInfo.Node;
            this.categoriesTreeList1.FocusedNode = this._curNode;
            if (this._curNode.Tag is SXEQ_JBLB)
            {
                this._curJBLB = this._curNode.Tag as SXEQ_JBLB;
            }
            else if (this._curNode.Tag is SXEQ_JBMB)
            {
                this._curJBMB = this._curNode.Tag as SXEQ_JBMB;
            }
            this.OnMBFocusedNodeChanged(this._curNode);
            this.btnPreView2.PerformClick();
        }

        #endregion

        #region ҵ���߼�����
        private void addTemplete()
        {
            FrmQueryCus frmQ = new FrmQueryCus();
            frmQ.OnImportTemp = importTemp;
            frmQ.OnCheckFrmEditOpened = new CheckFrmEditOpenedHandler(checkFrmEditOpened);
            //����OK��ʾҪ�½�һ���հ�ģ��
            if (frmQ.ShowDialog() == DialogResult.OK)
            {
                FrmTempEdit frm = new FrmTempEdit(true);
                frm.SetPGuid(this._curJBLB.fguid);
                frm.OnTempleteChanged = onTempleteChanged;
                frm.Show();
            }
        }

        private void importTemp(ImportTempleteTableCtl modelFrom)
        {
            SXEQ_JBMB model2 = new SXEQ_JBMB();
            model2.author = modelFrom.Author;
            model2.category = this._curJBLB.fguid;
            model2.fguid = Guid.NewGuid().ToString("D");
            model2.format = modelFrom.Format;
            model2.memo = modelFrom.Memo;
            model2.name = modelFrom.TempleteName;
            this._tempMgr.ImportTemplete(model2, modelFrom.FileName);
            TreeListNode focusedNode = this.categoriesTreeList1.AddTempNode(this._curNode, model2);
            this.categoriesTreeList1.FocusedNode = focusedNode;            
        }
        private void onTempleteChanged(SXEQ_JBMB model)
        {
            this.categoriesTreeList1.AddTempNode(this._curNode, model);
        }

        /// <summary>
        /// �ж�ģ��༭���ڵ�ǰ�Ƿ��Ѵ�
        /// </summary>
        /// <returns></returns>
        private bool checkFrmEditOpened(CustomStyle style)
        {
            foreach (Form var in Application.OpenForms)
            {
                if (var.Name == "FrmTempEdit")
                {
                    if (var.Text.Contains("�޸�"))
                    {
                        XtraMessageBox.Show("ģ���޸Ĵ����Ѿ��򿪣����ȹرոô���", "����");
                    }
                    else
                    {
                        XtraMessageBox.Show("ģ�嶨�ƴ����Ѿ��򿪣����ȹرոô���", "����");
                    }                    
                    if ((var.Text.Contains("�޸�") && CustomStyle.ModifyTemplete == style) || (var.Text.Contains("����") && CustomStyle.NewTemplete == style))
                    {
                        var.Activate();
                    }
                    return true ;
                }
            }
            return false;
        }
        
        /// <summary>
        /// ��ѡ�е����ڵ�仯ʱ�����Ĺ��ܰ�ť�Ŀ�����
        /// </summary>
        /// <param name="pNode"></param>
        private void OnMBFocusedNodeChanged(TreeListNode pNode)
        {
            if (pNode.Level == 0)
            {
                this.btnCustomize2.Enabled = false;
                this.btnModify2.Enabled = false;
                this.btnDelete2.Enabled = false;
                this.btnPreView2.Enabled = false;
            }
            else if (pNode.Level == 1)
            {
                this.btnCustomize2.Enabled = true;
                this.btnModify2.Enabled = false;
                this.btnDelete2.Enabled = false;
                this.btnPreView2.Enabled = false;
            }
            else if (pNode.Level == 2)
            {
                this.btnCustomize2.Enabled = false;
                this.btnModify2.Enabled = true;
                this.btnDelete2.Enabled = true;
                this.btnPreView2.Enabled = true;
            }
        }

        private void tempPreView()
        {
            if (null == this._curJBMB)
            {
                XtraMessageBox.Show("û��ѡ��ģ��", "����", MessageBoxButtons.OK);
                return;
            }
            FrmPreViewTemp frm = new FrmPreViewTemp();
            frm.SetFguid(this._curJBMB.fguid);
            frm.ShowDialog();
        }

        private void tempModify()
        {
            if (this.checkFrmEditOpened(CustomStyle.ModifyTemplete))
            {
                return;
            }
            bool hasWordProcess = CommonUtl.CheckProcessHasWord();
            if (hasWordProcess)
            {
                //XtraMessageBox.Show("��⵽ϵͳ��ǰ��Word���������У����ȹرյ�����Word����", "����", MessageBoxButtons.OK);
                if (FrmQueryCloseWord.GetInstance().ShowDialog() != DialogResult.OK)
                {
                    //���ѡ���ֶ��ر�����word���̻�ȡ�������˳�
                    return;
                }
            }
            FrmTempEdit frm = new FrmTempEdit(false);
            if (null == this._curJBMB)
            {
                XtraMessageBox.Show("û��ѡ��ģ��", "����", MessageBoxButtons.OK);
                return;
            }
            frm.Text = this._curJBMB.name + " - ģ���޸�";
            frm.TempleteGuid = this._curJBMB.fguid;
            frm.Show();
        }
        /// <summary>
        /// ɾ��ģ��
        /// </summary>
        private void tempDelete()
        {
            try
            {
                if (null == this._curJBMB)
                {
                    XtraMessageBox.Show("û��ѡ��ģ��", "����", MessageBoxButtons.OK);
                    return;
                }
                if (XtraMessageBox.Show(string.Format("ȷ��ɾ����ģ�壿"), "����", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this._tempMgr.DelSXEQ_JBMB(this._curJBMB.fguid);
                    this.categoriesTreeList1.DelNode(this._curNode);
                    this._curJBMB = null;
                    XtraMessageBox.Show("ɾ���ɹ�", "��ʾ", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "ɾ������", MessageBoxButtons.OK);
            }
        }
        #endregion

    }
}
