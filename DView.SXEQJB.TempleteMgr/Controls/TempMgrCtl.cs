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
    /// 模板管理
    /// </summary>
    public partial class TempMgrCtl : DevExpress.XtraEditors.XtraUserControl
    {
        #region 私有成员

        private TempleteMgr _tempMgr = new TempleteMgr();
        private SXEQ_JBLB_DAL _JBLB_DAL = new SXEQ_JBLB_DAL();
        private TreeListNode _curNode;
        private SXEQ_JBLB _curJBLB;
        private SXEQ_JBMB _curJBMB;
        #endregion

        #region 构造函数
        public TempMgrCtl()
        {
            InitializeComponent();
            this.initTree();
        }
        #endregion

        #region 加载数据列表

         /// <summary>
        /// 初始化树
        /// </summary>
        private void initTree()
        {
            this.categoriesTreeList1.InitTree();            
        }

        #endregion

        #region UI控件事件处理

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

        #region 业务逻辑函数
        private void addTemplete()
        {
            FrmQueryCus frmQ = new FrmQueryCus();
            frmQ.OnImportTemp = importTemp;
            frmQ.OnCheckFrmEditOpened = new CheckFrmEditOpenedHandler(checkFrmEditOpened);
            //返回OK表示要新建一个空白模板
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
        /// 判断模板编辑窗口当前是否已打开
        /// </summary>
        /// <returns></returns>
        private bool checkFrmEditOpened(CustomStyle style)
        {
            foreach (Form var in Application.OpenForms)
            {
                if (var.Name == "FrmTempEdit")
                {
                    if (var.Text.Contains("修改"))
                    {
                        XtraMessageBox.Show("模板修改窗口已经打开，请先关闭该窗口", "提醒");
                    }
                    else
                    {
                        XtraMessageBox.Show("模板定制窗口已经打开，请先关闭该窗口", "提醒");
                    }                    
                    if ((var.Text.Contains("修改") && CustomStyle.ModifyTemplete == style) || (var.Text.Contains("定制") && CustomStyle.NewTemplete == style))
                    {
                        var.Activate();
                    }
                    return true ;
                }
            }
            return false;
        }
        
        /// <summary>
        /// 当选中的树节点变化时，更改功能按钮的可用性
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
                XtraMessageBox.Show("没有选中模板", "提醒", MessageBoxButtons.OK);
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
                //XtraMessageBox.Show("检测到系统当前有Word程序在运行，请先关闭掉所有Word程序！", "提醒", MessageBoxButtons.OK);
                if (FrmQueryCloseWord.GetInstance().ShowDialog() != DialogResult.OK)
                {
                    //如果选择手动关闭其它word进程或取消，则退出
                    return;
                }
            }
            FrmTempEdit frm = new FrmTempEdit(false);
            if (null == this._curJBMB)
            {
                XtraMessageBox.Show("没有选中模板", "提醒", MessageBoxButtons.OK);
                return;
            }
            frm.Text = this._curJBMB.name + " - 模板修改";
            frm.TempleteGuid = this._curJBMB.fguid;
            frm.Show();
        }
        /// <summary>
        /// 删除模板
        /// </summary>
        private void tempDelete()
        {
            try
            {
                if (null == this._curJBMB)
                {
                    XtraMessageBox.Show("没有选中模板", "提醒", MessageBoxButtons.OK);
                    return;
                }
                if (XtraMessageBox.Show(string.Format("确定删除该模板？"), "提醒", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this._tempMgr.DelSXEQ_JBMB(this._curJBMB.fguid);
                    this.categoriesTreeList1.DelNode(this._curNode);
                    this._curJBMB = null;
                    XtraMessageBox.Show("删除成功", "提示", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "删除出错", MessageBoxButtons.OK);
            }
        }
        #endregion

    }
}
