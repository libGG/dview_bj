using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ReportDemo.Controls;

namespace ReportDemo
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnhelp_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("����");
        }

        private void btnabout_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("����");
        }

        private void btnupdata_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("�޸�����");
        }

        private void btnskin_Click(object sender, EventArgs e)
        {
            FrmLookAndFeel mFrmLook = FrmLookAndFeel.GetInstance();
            mFrmLook.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                string defultSkin = XmlConfig.GetNodeValue("LookAndFeel");
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(defultSkin);
            }
            catch
            {
            }
            ReportCataManage();
            this.label2.Text = "��������";
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            ReportCataManage();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            ReportCataManage();
        }

        private void ReportCataManage()
        {
            this.Cursor = Cursors.WaitCursor;
            Control control = new ControlReportCataManage();
            this.splitContainerControl1.Panel2.Controls.Clear();
            this.splitContainerControl1.Panel2.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            this.Cursor = Cursors.Default;
            this.label2.Text = "��������";
            
        }
        /// <summary>
        /// ��ģ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            ReportTemplateManage();
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {
            ReportTemplateManage();
        }

        private void ReportTemplateManage()
        {
            this.Cursor = Cursors.WaitCursor;
            Control control = new ControlReportTemplateManage();
            this.splitContainerControl1.Panel2.Controls.Clear();
            this.splitContainerControl1.Panel2.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            this.Cursor = Cursors.Default;
            this.label2.Text = "��ģ�����";
        }
        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureEdit4_Click(object sender, EventArgs e)
        {
            ReportGene();
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {
            ReportGene();
        }
        private void ReportGene()
        {
            this.Cursor = Cursors.WaitCursor;
            Control control = new ControlReportGene();
            this.splitContainerControl1.Panel2.Controls.Clear();
            this.splitContainerControl1.Panel2.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            this.Cursor = Cursors.Default;
            this.label2.Text = "������������";
        }
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureEdit5_Click(object sender, EventArgs e)
        {
            ReportOutput();
        }
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelControl4_Click(object sender, EventArgs e)
        {
            ReportOutput();
        }
        private void ReportOutput()
        {
            this.Cursor = Cursors.WaitCursor;
            Control control = new ControlOutputManage();
            this.splitContainerControl1.Panel2.Controls.Clear();
            this.splitContainerControl1.Panel2.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            this.Cursor = Cursors.Default;
            this.label2.Text = "�����������";
        }   

    }
}