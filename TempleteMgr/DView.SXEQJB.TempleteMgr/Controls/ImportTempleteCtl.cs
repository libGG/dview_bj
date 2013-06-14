//created by lib
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace DView.SXEQJB.TempleteMgr.Controls
{
    /// <summary>
    /// ģ�����
    /// </summary>
    public partial class ImportTempleteTableCtl : DevExpress.XtraEditors.XtraUserControl
    {
        public ImportTempleteTableCtl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ģ������
        /// </summary>
        public string TempleteName
        {
            get { return txtTempName.Text.Trim(); }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                this.txtTempName.Text = value.Trim();
            }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string Author
        {
            get { return txtAuthor.Text.Trim(); }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                this.txtAuthor.Text = value.Trim(); 
            }
        }
        /// <summary>
        /// ��ע
        /// </summary>
        public string Memo
        {
            get { return txtMemo.Text.Trim(); }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                this.txtMemo.Text = value.Trim();
            }
        }

        /// <summary>
        /// ģ���ʽ�����磺word��pdf��ppt
        /// </summary>
        public string Format
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (checkWord.Checked)
                {
                    sb.Append("word;");
                }
                if (checkPdf.Checked)
                {
                    sb.Append("pdf;");
                }
                if (checkPpt.Checked)
                {
                    sb.Append("ppt;");
                }
                return sb.ToString().Trim(';');
            }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                string format = value.ToLower();
                checkWord.Checked = format.Contains("word");
                checkPdf.Checked = format.Contains("pdf");
                checkPpt.Checked = format.Contains("ppt");
            }
        }
        /// <summary>
        /// ģ���ļ�·��
        /// </summary>
        public string FileName
        {
            get { return this.txtFileName.Text.Trim(); }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                this.txtFileName.Text = value.Trim();
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "ѡ��Ҫ�����wordģ��";
            ofd.Filter = "Word �ĵ�(*.doc;*.docx)|*.doc;*.docx";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            this.txtFileName.Text = ofd.FileName.Trim();
            this.txtTempName.Text = Path.GetFileNameWithoutExtension(ofd.FileName);
        }
    }
}
