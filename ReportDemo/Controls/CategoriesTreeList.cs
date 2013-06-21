using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using DevExpress.XtraTreeList;
using System.Xml;
using DevExpress.XtraTreeList.Nodes;
using System.Windows.Forms;
using ReportDemo.Properties;

namespace ReportDemo.Controls
{
    public partial class CategoriesTreeList : TreeList
    {
        TreeListNode myRootNode;
        ImageList imageList1 = new ImageList();
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
            try
            {
                myRootNode = this.AppendNode(new object[] { "报告类别" }, null);
                myRootNode.ImageIndex = 0;
                myRootNode.SelectImageIndex = 1;
                //update by cdd
                string xml = Application.StartupPath + "\\Config\\ReportCata.xml";
                XmlCommon xmlcommon = new XmlCommon(xml);
                XmlNode xmlNode = xmlcommon.GetNodeByPath("Config/ReportCatas");

                foreach (XmlNode node in xmlNode.ChildNodes)
                {
                    if (node.Attributes["fid"].Value == "0")
                    {
                        TreeListNode myNode = this.AppendNode(new object[] { node.Attributes["name"].Value, node.Attributes["Description"].Value }, myRootNode.Id, node);
                        myNode.ImageIndex = 0;
                        myNode.SelectImageIndex = 1;
                        foreach (XmlNode node1 in xmlNode.ChildNodes)
                        {
                            if (node1.Attributes["fid"].Value == node.Attributes["id"].Value)
                            {
                                TreeListNode myNode1 = this.AppendNode(new object[] { node1.Attributes["name"].Value, node1.Attributes["Description"].Value }, myNode.Id, node1);
                                myNode1.ImageIndex = 2;
                                myNode1.SelectImageIndex = 2;
                            }
                        }
                    }
                }

                this.FocusedNode = this.Nodes[0];
                this.ExpandAll();
                this.Refresh();
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

        }
        /// <summary>
        /// 得到选中的类型
        /// </summary>
        /// <returns></returns>
        public XmlNode GetSelectType()
        {
            if (this.FocusedNode == null || this.FocusedNode.Tag == null)
            {
                return null;

            }
            return this.FocusedNode.Tag as XmlNode;
        }
        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="pNode"></param>
        /// <param name="pType"></param>
        public void AddNode(TreeListNode pNode, XmlNode node)
        {
            TreeListNode myNode = this.AppendNode(new object[] { node.Attributes["name"].Value, node.Attributes["Description"].Value }, pNode.Id, node);
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

        public void UpdateNode(TreeListNode pNode, XmlNode node)
        {
            pNode.SetValue(0, node.Attributes["name"].Value);
            pNode.SetValue(1, node.Attributes["Description"].Value);
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
        public void AddMapNode(TreeListNode pNode, XmlNode node)
        {
            TreeListNode myNode = this.AppendNode(new object[] { node.Attributes["name"].Value, node.Attributes["Description"].Value }, pNode.Id, node);
            myNode.ImageIndex = 2;
            myNode.SelectImageIndex = 2;
            this.FocusedNode = myNode;
        }
        public void UpdateMapNode(TreeListNode pNode, XmlNode node)
        {
            pNode.SetValue(0, node.Attributes["name"].Value);
            pNode.SetValue(1, node.Attributes["Description"].Value);
            pNode.Tag = node;
            pNode.ImageIndex = 2;
            pNode.SelectImageIndex = 2;
            this.FocusedNode = pNode;
        }

        public void DelNode(TreeListNode pNode)
        {
            this.DeleteNode(pNode);
        }
    }
}
