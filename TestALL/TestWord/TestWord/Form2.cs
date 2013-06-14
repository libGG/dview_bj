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
            //���ô��ļ��Ի����ȡҪ�򿪵��ļ�WORD�ļ���RTF�ļ����ı��ļ�·������ 
            OpenFileDialog opd = new OpenFileDialog();  
            opd.InitialDirectory = @"E:\dview_work\ɽ��\doc\";
            opd.Filter =  "Word�ĵ�(*.doc)|*.doc|�ı��ĵ�(*.txt)|  *.txt|RTF�ĵ�(*.rtf)|*.rtf|�����ĵ�(*.*)|*.*"; 
            opd.FilterIndex = 1; 
            if (opd.ShowDialog() ==   DialogResult.OK && opd.FileName.Length > 0) 
            {   //����Word���ʵ��,ȱ��:������ȷ��ȡ���,ͼƬ�ȵȵ���ʾ
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
                    //�Ӽ��а��ȡ���� 
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