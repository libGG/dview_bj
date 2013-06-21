using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using System.Xml;

namespace ReportDemo.Controls
{
    public partial class ControlReportCataManage : DevExpress.XtraEditors.XtraUserControl
    {
        public ControlReportCataManage()
        {
            InitializeComponent();
            this.categoriesTreeList1.InitTree();
        }
        //选中的专题图类型
        TreeListNode pNode;
        XmlNode selectedType;
        string xml = Application.StartupPath + "\\Config\\ReportCata.xml";
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (pNode == null)
                return;
            string fid="0";
            if (pNode.Tag != null)
            { 
                fid=((pNode.Tag) as XmlNode).Attributes["id"].Value;
            }
            FrmReportType myDialog = selectedType == null ? new FrmReportType( fid ): new FrmReportType(selectedType);//当为null时添加父专题图,不为null时添加子专题图
            myDialog.ShowDialog();
            if (myDialog.DialogResult == DialogResult.OK)
            {
                this.categoriesTreeList1.AddNode(pNode, myDialog.element);
                
            }
            this.categoriesTreeList1.FocusedNode = pNode;
        }
        private void btnaddreport_Click(object sender, EventArgs e)
        {
            if (pNode == null)
                return;
            string fid = "0";
            if (pNode.Tag != null)
            {
                fid = ((pNode.Tag) as XmlNode).Attributes["id"].Value;
            }
            FrmReportType myDialog = new FrmReportType(fid);
            myDialog.ShowDialog();
            if (myDialog.DialogResult == DialogResult.OK)
            {
                this.categoriesTreeList1.AddNode(pNode, myDialog.element);

            }
            this.categoriesTreeList1.FocusedNode = pNode;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (selectedType == null)
            {
                XtraMessageBox.Show("报表根节点信息无法修改");
                return;
            }
            
            FrmReportType myDialog = new FrmReportType(selectedType);
            myDialog.ShowDialog();
            
            if (myDialog.DialogResult == DialogResult.OK)
            {
                selectedType.Attributes["name"].Value = myDialog.Name;
                selectedType.Attributes["Description"].Value = myDialog.Description;
                this.categoriesTreeList1.UpdateNode(pNode, selectedType);

            }
            this.categoriesTreeList1.FocusedNode = pNode;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (pNode == null || pNode.ParentNode == null || selectedType == null)
                return;
            try
            {
                bool isexist = false;

                XmlCommon xmlcommon = new XmlCommon(xml);
                XmlNode xmlNode = xmlcommon.GetNodeByPath("Config/ReportCatas");
                foreach (XmlNode nd in xmlNode.ChildNodes)
                {
                    if (nd.Attributes["fid"].Value == (pNode.Tag as XmlNode).Attributes["id"].Value)
                    {
                        isexist = true;
                    }
                }
                if (isexist)
                {
                    if (XtraMessageBox.Show("该类别下报表,确定全部删除", "提醒", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        xmlcommon.RemoveNodeByID(xmlNode, true, (pNode.Tag as XmlNode).Attributes["id"].Value);
                        xmlcommon.Close();
                        this.categoriesTreeList1.DelNode(pNode);
                        XtraMessageBox.Show("删除成功", "提示");
                       
                    }

                }
                else
                {
                    if (XtraMessageBox.Show(string.Format("确定删除报表分类？"), "提醒", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        xmlcommon.RemoveNodeByID(xmlNode, false, (pNode.Tag as XmlNode).Attributes["id"].Value);
                        xmlcommon.Close();
                        this.categoriesTreeList1.DelNode(pNode);
                        XtraMessageBox.Show("删除成功", "提示");
                        
                    }
                }
                this.categoriesTreeList1.FocusedNode = pNode.ParentNode;

            }
            catch (Exception ex)
            {
               
            }
        }

        private void btnquery_Click(object sender, EventArgs e)
        {

        }

        private void ControlReportCataManage_Load(object sender, EventArgs e)
        {
           
            pNode = this.categoriesTreeList1.FocusedNode;
            this.categoriesTreeList1.FocusedNode = pNode;
            if (pNode == null) return;
            this.btnaddreport.Enabled = false;
        }

        private void categoriesTree1_MouseDown(object sender, MouseEventArgs e)
        {
            TreeListHitInfo hitInfo = (sender as TreeList).CalcHitInfo(new Point(e.X, e.Y));
            pNode = hitInfo.Node;
            if (pNode == null)
                return;
            this.categoriesTreeList1.FocusedNode = pNode;
            selectedType = pNode.Tag as XmlNode;

            State(pNode);
        }

        private void State(TreeListNode pNode)
        {
            if (pNode.Level == 0)
            {
                this.btnadd.Enabled = true;
                this.btnaddreport.Enabled = false;
            }
            else if (pNode.Level == 1)
            {
                this.btnadd.Enabled = false;
                this.btnaddreport.Enabled = true;
            }
            else if (pNode.Level == 2)
            {
                this.btnadd.Enabled = false;
                this.btnaddreport.Enabled = false;
            }
        }

       
    }
}
