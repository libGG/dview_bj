using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using DevExpress.XtraTreeList;
using System.Xml;
using DevExpress.XtraTreeList.Nodes;
using System.Windows.Forms;
using DView.SXEQJB.TempleteMgr.Properties;
using DView.SXEQJB.TempleteMgr.Dal;

namespace DView.SXEQJB.TempleteMgr
{
    public delegate void MBFocusedNodeChangedEventHandler(TreeListNode focusedNode);
    public partial class CategoriesTreeList : TreeList
    {
        TreeListNode myRootNode;
        ImageList imageList1 = new ImageList();
        private SXEQ_JBLB_DAL _JBLB_DAL = new SXEQ_JBLB_DAL();
        private SXEQ_JBMB_DAL _JBMB_DAL = new SXEQ_JBMB_DAL();

        #region 事件
        public event MBFocusedNodeChangedEventHandler MBFocusedNodeChanged;
        #endregion
        public CategoriesTreeList()
        {
            InitializeComponent();
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.Images.Add("Close", Resources.Closed);
            imageList1.Images.Add("Open", Resources.Open);
            imageList1.Images.Add("ThemeMap", Resources.ThemeMap);
            this.SelectImageList = imageList1;
            this.OptionsSelection.InvertSelection = true;
            this.OptionsView.ShowIndicator = false;
        }

        public CategoriesTreeList(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.Images.Add("Close", Resources.Closed);
            imageList1.Images.Add("Open", Resources.Open);
            imageList1.Images.Add("ThemeMap", Resources.ThemeMap);
            this.SelectImageList = imageList1;
            this.OptionsSelection.InvertSelection = true;
            this.OptionsView.ShowIndicator = false;
        }

        /// <summary>
        /// 初始化树
        /// </summary>
        public void InitTree()
        {
            myRootNode = this.AppendNode(new object[] { "报告类别" }, null);
            myRootNode.ImageIndex = 0;
            myRootNode.SelectImageIndex = 1;
            List<SXEQ_JBLB> lbs = this._JBLB_DAL.GetModelList("");
            foreach (SXEQ_JBLB var in lbs)
            {
                TreeListNode myNode = this.AppendNode(new object[] { var.name, var.memo }, myRootNode.Id, var);
                myNode.ImageIndex = 0;
                myNode.SelectImageIndex = 1;
                List<SXEQ_JBMB> mbs = this._JBMB_DAL.GetModelList(string.Format("category ='{0}'",var.fguid));
                foreach (SXEQ_JBMB item in mbs)
                {
                    //该Blob字段加到控件的Tag上，会影响效率，所以先赋值为null
                    item.filedoc = null;
                    TreeListNode myNode1 = this.AppendNode(new object[] { item.name, item.memo }, myNode.Id, item);
                    myNode1.ImageIndex = 2;
                    myNode1.SelectImageIndex = 2;
                }
            }
            this.FocusedNode = this.Nodes[0];
            this.ExpandAll();
            this.Refresh();
        }

        /// <summary>
        /// 得到选中的类型
        /// </summary>
        /// <returns></returns>
        public SXEQ_JBLB GetSelectType()
        {
            if (this.FocusedNode == null || this.FocusedNode.Tag == null)
            {
                return null;

            }
            return this.FocusedNode.Tag as SXEQ_JBLB;
        }
        /// <summary>
        /// 添加类别节点
        /// </summary>
        /// <param name="pNode"></param>
        /// <param name="pType"></param>
        public void AddNode(TreeListNode pNode, SXEQ_JBLB node)
        {
            TreeListNode myNode = this.AppendNode(new object[] { node.name, node.memo }, pNode.Id, node);
            if (myNode.Level == 0 || myNode.Level == 1)
            {
                myNode.ImageIndex = 0;
                myNode.SelectImageIndex = 1;
            }
            else if (myNode.Level == 2)
            {
                myNode.ImageIndex = 2;
                myNode.SelectImageIndex = 2;
            }
            myNode.ExpandAll();
            this.FocusedNode = myNode;
        }
        /// <summary>
        /// 更新类别节点
        /// </summary>
        /// <param name="pNode"></param>
        /// <param name="node"></param>
        public void UpdateNode(TreeListNode pNode, SXEQ_JBLB node)
        {
            pNode.SetValue(0, node.name);
            pNode.SetValue(1, node.memo);
            pNode.Tag = node;
            if (pNode.Level == 0 || pNode.Level == 1)
            {
                pNode.ImageIndex = 0;
                pNode.SelectImageIndex = 1;
            }
            else if (pNode.Level == 2)
            {
                pNode.ImageIndex = 2;
                pNode.SelectImageIndex = 2;
            }
            this.FocusedNode = pNode;
        }

        /// <summary>
        /// 添加模板节点
        /// </summary>
        /// <param name="pNode"></param>
        /// <param name="pType"></param>
        public TreeListNode AddTempNode(TreeListNode pNode, SXEQ_JBMB node)
        {
            TreeListNode myNode = this.AppendNode(new object[] { node.name, node.memo }, pNode.Id, node);
            if (myNode.Level == 0 || myNode.Level == 1)
            {
                myNode.ImageIndex = 0;
                myNode.SelectImageIndex = 1;
            }
            else if (myNode.Level == 2)
            {
                myNode.ImageIndex = 2;
                myNode.SelectImageIndex = 2;
            }
            //myNode.ExpandAll();
            this.FocusedNode = myNode;
            this.RefreshRowsInfo();
            return myNode;
        }
        /// <summary>
        /// 更新模板节点
        /// </summary>
        /// <param name="pNode"></param>
        /// <param name="node"></param>
        public void UpdateTempNode(TreeListNode pNode, SXEQ_JBMB node)
        {
            pNode.SetValue(0, node.name);
            pNode.SetValue(1, node.memo);
            pNode.Tag = node;
            if (pNode.Level == 0 || pNode.Level == 1)
            {
                pNode.ImageIndex = 0;
                pNode.SelectImageIndex = 1;
            }
            else if (pNode.Level == 2)
            {
                pNode.ImageIndex = 2;
                pNode.SelectImageIndex = 2;
            }
            this.FocusedNode = pNode;
        }

        public void DelNode(TreeListNode pNode)
        {
            this.DeleteNode(pNode);
        }

        private void CategoriesTreeList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (null != this.MBFocusedNodeChanged)
            {
                this.MBFocusedNodeChanged(e.Node);
            }
        }
    }
}
