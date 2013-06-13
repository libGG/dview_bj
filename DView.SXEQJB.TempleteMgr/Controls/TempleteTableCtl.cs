//created by lib
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DView.SXEQJB.TempleteMgr.Controls
{
    /// <summary>
    /// 模板参数
    /// </summary>
    public partial class TempleteTableCtl : DevExpress.XtraEditors.XtraUserControl
    {
        public TempleteTableCtl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 模板名称
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
        /// 制作人
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
        /// 备注
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
        /// 模板格式，例如：word，pdf，ppt
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
    }
}
