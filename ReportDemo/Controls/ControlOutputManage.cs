using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using ReportDemo.Properties;

namespace ReportDemo.Controls
{
    public partial class ControlOutputManage : DevExpress.XtraEditors.XtraUserControl
    {
        public ControlOutputManage()
        {
            InitializeComponent();
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.Images.Add("Close", Resources.Closed);
            imageList1.Images.Add("Open", Resources.Open);
            imageList1.Images.Add("ThemeMap", Resources.ThemeMap);
            this.treeList1.SelectImageList = imageList1;
            this.treeList1.OptionsSelection.InvertSelection = true;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList2.SelectImageList = imageList1;
            this.treeList2.OptionsSelection.InvertSelection = true;
            this.treeList2.OptionsView.ShowIndicator = false;
            InitTree();
        }
        private TreeListNode pNode;
        private XmlNode selectedType;
        ImageList imageList1 = new ImageList();
        string xml = Application.StartupPath + "\\Config\\ReportOutput.xml";
        private void InitTree()
        {
            try
            {

                //update by cdd
               
                XmlCommon xmlcommon = new XmlCommon(xml);
                XmlNode xmlNode = xmlcommon.GetNodeByPath("Config/ReportOutput");

                foreach (XmlNode node in xmlNode.ChildNodes)
                {

                    TreeListNode myNode = this.treeList1.AppendNode(new object[] { node.Attributes["name"].Value, node.Attributes["Description"].Value, node.Attributes["isauto"].Value, node.Attributes["isautoupload"].Value, node.Attributes["isprint"].Value, node.Attributes["ismessage"].Value }, null, node);
                    myNode.ImageIndex = 0;
                    myNode.SelectImageIndex = 1;

                }

                this.treeList1.FocusedNode = this.treeList1.Nodes[0];
                this.treeList1.ExpandAll();
                this.treeList1.Refresh();
                pNode = this.treeList1.FocusedNode;
                selectedType = pNode.Tag as XmlNode;
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
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnadd_Click(object sender, EventArgs e)
        {
            FrmAddReportOutput myDialog = new FrmAddReportOutput();
            myDialog.ShowDialog();
            if (myDialog.DialogResult == DialogResult.OK)
            {
                pNode= this.treeList1.AppendNode(new object[] { myDialog.element.Attributes["name"].Value, myDialog.element.Attributes["Description"].Value, myDialog.element.Attributes["isauto"].Value, myDialog.element.Attributes["isautoupload"].Value, myDialog.element.Attributes["isprint"].Value, myDialog.element.Attributes["ismessage"].Value }, null, myDialog.element);

            }
            this.treeList1.FocusedNode = pNode;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (selectedType == null)
            {
                XtraMessageBox.Show("请选择要修改的报表输出机制");
                return;
            }
            FrmAddReportOutput myDialog = new FrmAddReportOutput(selectedType);
            myDialog.ShowDialog();

            if (myDialog.DialogResult == DialogResult.OK)
            {
                selectedType.Attributes["name"].Value = myDialog.Name;
                selectedType.Attributes["Description"].Value = myDialog.Description;
                selectedType.Attributes["reportids"].Value=myDialog.reportids;
                selectedType.Attributes["isauto"].Value=myDialog.isauto;
                selectedType.Attributes["isautoupload"].Value=myDialog.isautoupload;
                selectedType.Attributes["isprint"].Value=myDialog.isprint;
                selectedType.Attributes["ismessage"].Value=myDialog.ismessage;
                pNode.SetValue(0, myDialog.Name);
                pNode.SetValue(1, myDialog.Description);
                pNode.SetValue(2, myDialog.isauto);
                pNode.SetValue(3, myDialog.isautoupload);
                pNode.SetValue(4, myDialog.isprint);
                pNode.SetValue(5, myDialog.ismessage);
                pNode.Tag=selectedType;

            }
            this.treeList1.FocusedNode = pNode;
            treeList1_FocusedNodeChanged(this.treeList1, null);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (pNode == null || selectedType == null)
                return;
            try
            {
                bool isexist = false;

                XmlCommon xmlcommon = new XmlCommon(xml);
                XmlNode xmlNode = xmlcommon.GetNodeByPath("Config/ReportOutput");
                
               
                    if (XtraMessageBox.Show(string.Format("确定删除报表输出机制？"), "提醒", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        xmlcommon.RemoveNodeByID(xmlNode, false, (pNode.Tag as XmlNode).Attributes["id"].Value);
                        xmlcommon.Close();
                        this.treeList1.DeleteNode(pNode);
                        XtraMessageBox.Show("删除成功", "提示");

                    }
                    this.treeList1.FocusedNode = this.treeList1.Nodes[0];

            }
            catch (Exception ex)
            {

            }
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            this.treeList2.Nodes.Clear();
            pNode = this.treeList1.FocusedNode;
            selectedType = pNode.Tag as XmlNode;
            if (pNode == null || selectedType == null || selectedType.Attributes["reportids"] == null || selectedType.Attributes["reportids"].Value.Trim() == "")
                return;

            string[] idstrs = selectedType.Attributes["reportids"].Value.Split(new char[] { '|' });

            string xml = Application.StartupPath + "\\Config\\ReportCata.xml";
            XmlCommon xmlcommon = new XmlCommon(xml);
            XmlNode xmlNode = xmlcommon.GetNodeByPath("Config/ReportCatas");
            foreach (XmlNode nd in xmlNode.ChildNodes)
            {
                foreach (string id in idstrs)
                {
                    if (nd.Attributes["id"].Value == id)
                    {
                        TreeListNode myNode = this.treeList2.AppendNode(new object[] { nd.Attributes["name"].Value, nd.Attributes["Description"].Value }, null, nd);
                        myNode.ImageIndex = 2;
                        myNode.SelectImageIndex = 2;
                    }
                }
            }
            this.treeList2.FocusedNode = this.treeList1.Nodes[0];
            this.treeList2.ExpandAll();
            this.treeList2.Refresh();


        }
        private void categoriesTree1_MouseDown(object sender, MouseEventArgs e)
        {
            TreeListHitInfo hitInfo = (sender as TreeList).CalcHitInfo(new Point(e.X, e.Y));
            pNode = hitInfo.Node;
            if (pNode == null)
                return;
            this.treeList1.FocusedNode = pNode;
            selectedType = pNode.Tag as XmlNode;

        }
    }
}
