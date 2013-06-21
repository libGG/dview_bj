using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Xml;
using System.IO;

namespace ReportDemo.Controls
{
    public partial class ControlReportTemplateManage : DevExpress.XtraEditors.XtraUserControl
    {
        public ControlReportTemplateManage()
        {
            InitializeComponent();
            this.categoriesTreeList1.InitTree();
        }
        TreeListNode pNode;
        XmlNode selectedType;
        string xml = Application.StartupPath + "\\Config\\ReportCata.xml";
        private void ControlReportTemplateManage_Load(object sender, EventArgs e)
        {
            try
            {
                this.categoriesTreeList1.FocusedNode = this.categoriesTreeList1.Nodes[0].Nodes[0].Nodes[0];
                pNode=this.categoriesTreeList1.Nodes[0].Nodes[0].Nodes[0];
                selectedType = pNode.Tag as XmlNode;
            }
            catch
            { }
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
            if (pNode.Level == 0||pNode.Level == 1)
            {
                this.btnadd.Enabled = false;
                this.btnaddreport.Enabled = false;
            }
            
            else if (pNode.Level == 2)
            {
                this.btnadd.Enabled = true;
                this.btnaddreport.Enabled = true;
            }
        }
        /// <summary>
        /// 模板定制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (selectedType == null)
                return;
            FrmAddReportTemp myDialog = new FrmAddReportTemp();
            myDialog.ShowDialog();
            if (myDialog.DialogResult == DialogResult.OK)
            {
                XmlCommon xmlcommon = new XmlCommon(xml);
                XmlNode xmlNode = xmlcommon.GetNodeByPath("Config/ReportCatas");
                foreach (XmlNode xn in xmlNode.ChildNodes)
                {
                    if (xn.Attributes["id"].Value == selectedType.Attributes["id"].Value)
                    {
                        if (Path.GetDirectoryName(myDialog.docPath) == Application.StartupPath+"\\报表模板")
                        {
                            xn.Attributes["path"].Value = Path.GetFileNameWithoutExtension(myDialog.docPath)+".doc";
                        }
                        else
                        {
                            xn.Attributes["path"].Value = myDialog.docPath;
                        }
                        selectedType = xn;
                    }
                }
                xmlcommon.Close();
                this.categoriesTreeList1.UpdateNode(pNode, selectedType);
                XtraMessageBox.Show("模板定制成功");
            }

        }
        /// <summary>
        /// 模板浏览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnaddreport_Click(object sender, EventArgs e)
        {
            if (selectedType == null)
                return;
            if (selectedType.Attributes["path"] == null)
            {
                XtraMessageBox.Show("该报告不存在模板文件，请定制模板！");
                return;
            }
            string temppath = selectedType.Attributes["path"].Value;
            if (temppath.IndexOf("\\")==-1)
                temppath = Application.StartupPath + "\\报表模板\\" + temppath;
            try
            {
                if (string.IsNullOrEmpty(temppath) || (!File.Exists(temppath)))
                {
                    XtraMessageBox.Show("该报告不存在模板文件，请定制模板！");
                    return;
                }
                
                    WordOperator woperate = new WordOperator(temppath);
               
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
