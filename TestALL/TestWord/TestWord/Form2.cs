using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;

namespace TestWord
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //调用打开文件对话框获取要打开的文件WORD文件，RTF文件，文本文件路径名称 
            OpenFileDialog opd = new OpenFileDialog();  
            opd.InitialDirectory = @"E:\dview_work\山西\doc\";
            opd.Filter =  "Word文档(*.doc)|*.doc|文本文档(*.txt)|  *.txt|RTF文档(*.rtf)|*.rtf|所有文档(*.*)|*.*"; 
            opd.FilterIndex = 1; 
            if (opd.ShowDialog() ==   DialogResult.OK && opd.FileName.Length > 0) 
            {   //建立Word类的实例,缺点:不能正确读取表格,图片等等的显示
                ApplicationClass app = new ApplicationClass();
                Document doc = null;  
                object missing = System.Reflection.Missing.Value;  
                object FileName = opd.FileName; 
                object readOnly = false;  
                object isVisible = true; 
                object index = 0; 
                try { 
                    doc = app.Documents.Open(  ref FileName, ref missing, ref readOnly,  ref missing, ref missing,   ref missing, ref missing, ref missing,  ref missing, ref missing,   ref missing, ref isVisible, ref missing,  ref missing, ref missing, ref missing); 
                    doc.ActiveWindow.Selection.WholeStory(); 
                    doc.ActiveWindow.Selection.Copy();  
                    //从剪切板获取数据 
                    IDataObject data=Clipboard.GetDataObject(); 
                    //this.richTextBox1.Text=  data.GetData(DataFormats.Text).ToString(); 
                }  finally {  if (doc != null) 
                {
                    doc.Close(ref missing, ref missing, ref missing);
                    doc = null;
                }
                if (app != null)
                {
                    app.Quit(ref missing, ref missing, ref missing);
                    app = null;
                }
            }
        }  
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.FrmChild = null;
        }
    }
}