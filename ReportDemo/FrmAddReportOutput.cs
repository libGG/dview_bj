using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;

namespace ReportDemo
{
    public partial class FrmAddReportOutput : DevExpress.XtraEditors.XtraForm
    {
        bool b_Add = true;
        XmlNode pNode;
        List<string> TemplateIds;
        public XmlElement element;
        string xml = Application.StartupPath + "\\Config\\ReportOutput.xml";
        public string Name = "";
        public string Description = "";
        public string reportids = "";
        public string isauto = "";
        public string isautoupload = "";
        public string isprint = "";
        public string ismessage = "";
        public FrmAddReportOutput()
        {
            InitializeComponent();

            this.categoriesTreeList1.InitTree();
            this.categoriesTreeList1.OptionsView.ShowCheckBoxes = true;
            this.categoriesTreeList1.Columns[1].Visible = false;
            this.Text = "���ӱ����������";
            this.b_Add = true;
        }
        
        public FrmAddReportOutput(XmlNode node)
        {
            InitializeComponent();

            this.categoriesTreeList1.InitTree();
            this.categoriesTreeList1.OptionsView.ShowCheckBoxes = true;
            this.categoriesTreeList1.Columns[1].Visible = false;
            this.Text = "�޸ı����������";
            this.b_Add = false;
            pNode = node;
            this.txtName.Text = node.Attributes["name"].Value;
            this.memoDesc.Text = node.Attributes["Description"].Value;
            if (node.Attributes["isauto"].Value == "��")
            {
                this.checkEdit1.Checked = true;
            }
            if (node.Attributes["isautoupload"].Value == "��")
            {
                this.checkEdit2.Checked = true;
            }
            if (node.Attributes["isprint"].Value == "��")
            {
                this.checkEdit3.Checked = true;
            }
            if (node.Attributes["ismessage"].Value == "��")
            {
                this.checkEdit4.Checked = true;
            }
            this.TemplateIds = new List<string>(node.Attributes["reportids"].Value.Split(new char[] { '|' }));// pThemeMapOutPutMecha.TemplateIDs;
            SetTreeByTemplateIds(TemplateIds);

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Trim() == "")
            {
                XtraMessageBox.Show("���Ʋ���Ϊ��");
                return;
            }
            XmlCommon xmlcommon = new XmlCommon(xml);
            XmlNode xmlNode = xmlcommon.GetNodeByPath("Config/ReportOutput");
            if (GetReportIdsByTreeNode().Count == 0)
            {
                XtraMessageBox.Show("��ѡ��Ҫ����ı���!");
                return;
            }
            string tempstr = string.Join("|", GetReportIdsByTreeNode().ToArray());
            if (string.IsNullOrEmpty(tempstr))
            {
                XtraMessageBox.Show("��ѡ��Ҫ����ı���!");
                return;
            }
            if (b_Add)
            {
                int newid = 0;
                foreach (XmlNode xn in xmlNode.ChildNodes)
                {
                    if (Convert.ToInt32(xn.Attributes["id"].Value) > newid)
                        newid = Convert.ToInt32(xn.Attributes["id"].Value);
                }
                element = xmlcommon.CreatElement("output");
                element.SetAttribute("id", (newid + 1).ToString());
                element.SetAttribute("name", this.txtName.Text.Trim());
                element.SetAttribute("Description", this.memoDesc.Text.Trim());
                
                element.SetAttribute("reportids", tempstr);
                element.SetAttribute("isauto", this.checkEdit1.Checked == true ? "��" : "��");
                element.SetAttribute("isautoupload", this.checkEdit2.Checked == true ? "��" : "��");
                element.SetAttribute("isprint", this.checkEdit3.Checked == true ? "��" : "��");
                element.SetAttribute("ismessage", this.checkEdit4.Checked == true ? "��" : "��");
                xmlNode.AppendChild(element);
                xmlcommon.Close();//���沢�ر�
                XtraMessageBox.Show("��ӳɹ�");
                this.DialogResult = DialogResult.OK;
                this.Close();


            }
            else
            {
                foreach (XmlNode xn in xmlNode.ChildNodes)
                {
                    if (xn.Attributes["id"].Value == pNode.Attributes["id"].Value)
                    {
                        xn.Attributes["name"].Value =Name= this.txtName.Text.Trim();
                        xn.Attributes["Description"].Value=Description = this.memoDesc.Text.Trim();
                        xn.Attributes["reportids"].Value = reportids = tempstr;
                        xn.Attributes["isauto"].Value =isauto= this.checkEdit1.Checked == true ? "��" : "��";
                        xn.Attributes["isautoupload"].Value =isautoupload= this.checkEdit2.Checked == true ? "��" : "��";
                        xn.Attributes["isprint"].Value = isprint= this.checkEdit3.Checked == true ? "��" : "��";
                        xn.Attributes["ismessage"].Value =ismessage= this.checkEdit4.Checked == true ? "��" : "��";
                       
                    }
                }
                xmlcommon.Close();

                XtraMessageBox.Show("�޸ĳɹ�");

                this.DialogResult = DialogResult.OK;
                this.Close();


            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        /// <summary>
        /// ���������ר��ͼģ�弯��
        /// </summary>
        private List<string> GetReportIdsByTreeNode()
        {
            List<string> idstr = new List<string>();
            foreach (TreeListNode myNode in this.categoriesTreeList1.Nodes[0].Nodes)
            {
                foreach (TreeListNode myNode1 in myNode.Nodes)
                {
                    XmlNode nd = myNode1.Tag as XmlNode;
                    if (nd != null &&myNode1.Checked&& myNode1.Level == 2)
                    {
                        idstr.Add(nd.Attributes["id"].Value);
                    }
                }

            }
            return idstr;
        }
        private void SetTreeByTemplateIds(List<string > reportids)
        {
            foreach (TreeListNode myNode in this.categoriesTreeList1.Nodes[0].Nodes)
            {
                foreach (TreeListNode myNode1 in myNode.Nodes)
                {
                    XmlNode nd = myNode1.Tag as XmlNode;
                    if (reportids.IndexOf(nd.Attributes["id"].Value) != -1)
                    {
                        myNode1.Checked = true;
                        this.CheckControl(myNode1);
                    }
                }

            }
           
        }
        /// <summary>
        /// ϵ�нڵ� Checked ���Կ���
        /// </summary>
        /// <param name="e"></param>
        private void CheckControl(TreeListNode node)
        {

            if (node != null)
            {
                CheckParentNode(node, node.Checked);
            }
            if (node.Nodes.Count > 0)
            {
                CheckAllChildNodes(node, node.Checked);
            }

        }
        /// <summary>
        /// ϵ�нڵ� Checked ���Կ���
        /// </summary>
        /// <param name="e"></param>
        private void CheckControl(NodeEventArgs e)
        {
            if (e.Node != null)
            {
                CheckParentNode(e.Node, e.Node.Checked);
            }
            if (e.Node.Nodes.Count > 0)
            {
                CheckAllChildNodes(e.Node, e.Node.Checked);
            }
        }
        //�ı������ӽڵ��״̬
        private void CheckAllChildNodes(TreeListNode pn, bool IsChecked)
        {
            foreach (TreeListNode tn in pn.Nodes)
            {
                tn.Checked = IsChecked;
                if (tn.Nodes.Count > 0)
                {
                    CheckAllChildNodes(tn, IsChecked);
                }
            }
        }
        //�ı丸�ڵ��ѡ��״̬
        private void CheckParentNode(TreeListNode curNode, bool IsChecked)
        {
            bool bAllChecked = true;
            bool bAllUnchecked = true;
            bool bChecked = false;
            if (curNode.ParentNode != null)
            {
                foreach (TreeListNode node in curNode.ParentNode.Nodes)
                {
                    if (!node.Checked)
                    {
                        bAllChecked = false;
                    }
                    if (node.Checked)
                    {
                        bChecked = true;
                        bAllUnchecked = false;
                    }
                }
                if (bChecked)
                {
                    curNode.ParentNode.Checked = true;
                }
                if (bAllChecked)
                {
                    curNode.ParentNode.Checked = true;
                    CheckParentNode(curNode.ParentNode, true);
                }
                if (bAllUnchecked)
                {
                    curNode.ParentNode.Checked = false;
                    CheckParentNode(curNode.ParentNode, false);
                }
            }
        }

        private void categoriesTreeList1_AfterCheckNode(object sender, NodeEventArgs e)
        {
            this.CheckControl(e);
        }
    }
}