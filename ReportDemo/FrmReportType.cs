using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;

namespace ReportDemo
{
    public partial class FrmReportType : DevExpress.XtraEditors.XtraForm
    {
        bool b_Add = true;
        string m_ID;//父id
        XmlNode m_XmlNode = null;
        string xml = Application.StartupPath + "\\Config\\ReportCata.xml";
       
        public XmlElement element;
        public string Name;
        public string Description;
        public FrmReportType(string pID)
        {
            InitializeComponent();
            this.b_Add = true;
            this.Text = "增加报告类别";
            this.m_ID = pID;
        }
        public FrmReportType(XmlNode node)
        {
            InitializeComponent();
            this.b_Add = false;
            this.Text = "修改报告类别";
            this.m_XmlNode = node;
            this.txtName.Text = node.Attributes["name"].Value;
            this.memoDesc.Text = node.Attributes["Description"].Value;

        }
        private bool Check(XmlNode node)
        {
            if (this.txtName.Text.Trim() == "")
            {
                XtraMessageBox.Show("名称不能为空");
                return false;
            }
            if (b_Add)
            {
                //if (this.m_ThemeMapTypeDA.ExistenceThemeMapType(pThemeMapType, pThemeMapType.FID))
                //{
                //    XtraMessageBox.Show("名称重复，请重新设置");
                //    return false;
                //}
            }
            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Trim() == "")
            {
                XtraMessageBox.Show("名称不能为空");
                return;
            }
            XmlCommon xmlcommon = new XmlCommon(xml);
            XmlNode xmlNode = xmlcommon.GetNodeByPath("Config/ReportCatas");
            if (b_Add)
            {
                int newid = 0;
                foreach (XmlNode xn in xmlNode.ChildNodes)
                {
                    if (Convert.ToInt32(xn.Attributes["id"].Value) > newid)
                        newid = Convert.ToInt32(xn.Attributes["id"].Value);
                }
                element = xmlcommon.CreatElement("reportcata");
                element.SetAttribute("id", (newid+1).ToString());
                element.SetAttribute("fid", m_ID);
                element.SetAttribute("name", this.txtName.Text.Trim());
                element.SetAttribute("Description", this.memoDesc.Text.Trim());
                element.SetAttribute("path", "");
                xmlNode.AppendChild(element);
                xmlcommon.Close();//保存并关闭
                XtraMessageBox.Show("添加成功");
                this.DialogResult = DialogResult.OK;
                this.Close();


            }
            else
            {
                foreach (XmlNode xn in xmlNode.ChildNodes)
                {
                    if (xn.Attributes["id"].Value == m_XmlNode.Attributes["id"].Value)
                    {
                        xn.Attributes["name"].Value = this.txtName.Text.Trim();
                        xn.Attributes["Description"].Value = this.memoDesc.Text.Trim();
                        Name = this.txtName.Text.Trim();
                        Description = this.memoDesc.Text.Trim();
                    }
                }
                xmlcommon.Close();

                XtraMessageBox.Show("修改成功");

                this.DialogResult = DialogResult.OK;
                this.Close();


            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancle_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}