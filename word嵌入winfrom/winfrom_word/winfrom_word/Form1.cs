using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace winfrom_word
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenWord_Click(object sender, EventArgs e)
        {
            OpenWord(winWordControl1, "");
        }

        private void btnSaveWord_Click(object sender, EventArgs e)
        {
            string path = SaveWord(winWordControl1, "");
        }

        //打开word
        public void OpenWord(WinWordControl.WinWordControl winWordControl1, string wordUrl)
        {
            if (string.IsNullOrEmpty(wordUrl))
            {
                wordUrl = GetPath() + @"\SystemWord\template\template.doc";
            }
            else
            {
                wordUrl = GetPath() + wordUrl;
            }

            try
            {
                winWordControl1.CloseControl();
            }
            catch { }
            finally
            {
                winWordControl1.document = null;
                WinWordControl.WinWordControl.wd = null;
                WinWordControl.WinWordControl.wordWnd = 0;
            }
            try
            {
                winWordControl1.LoadDocument(wordUrl);
            }
            catch (Exception ex)
            {
                String err = ex.Message;
            }
        }

        /// <summary>
        /// 保存word
        /// </summary>
        /// <param name="winWordControl1">主控件</param>
        /// <param name="pFileName">文档名称</param>     
        /// <returns></returns>
        public string SaveWord(WinWordControl.WinWordControl winWordControl1, string pFileName)
        {
            if (string.IsNullOrEmpty(pFileName))
            {
                pFileName = DateTime.Now.ToString("yyMMddHHmmss");
            }       
            string path = @"\SystemWord\" + DateTime.Now.ToShortDateString() + "\\";
            string savePath = path + pFileName + ".doc";

            string dic = GetPath() + path;
            if (!System.IO.Directory.Exists(dic))
            {
                System.IO.Directory.CreateDirectory(dic);
            }

            string wordUrl = dic + pFileName + ".doc";

            object myNothing = System.Reflection.Missing.Value;

            object myFileName = wordUrl;

            object myWordFormatDocument = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument;

            object myLockd = false;

            object myPassword = "";

            object myAddto = true;

            try
            {
                winWordControl1.document.SaveAs(ref myFileName, ref myWordFormatDocument, ref myLockd, ref myPassword, ref myAddto, ref myPassword,
                    ref myLockd, ref myLockd, ref myLockd, ref myNothing, ref myNothing);
                /*
                this.winWordControl1.document.SaveAs(ref myFileName, ref myWordFormatDocument, ref myLockd, ref myPassword, ref myAddto, ref myPassword,
                ref myLockd, ref myLockd, ref myLockd, ref myLockd, ref myNothing, ref myNothing, ref myNothing,
                ref myNothing, ref myNothing, ref myNothing);
                */
            }
            catch
            {
                throw new Exception("导出word文档失败!");
            }
            return savePath;
        }

        public string GetPath()
        {
            return Application.StartupPath;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object timeout = 50000;
            try
            {
                winWordControl1.document.Application.Dialogs.Item(Word.WdWordDialog.wdDialogInsertBookmark).Show(ref timeout);
            }
            catch (Exception ex)
            { }
        
        }

        
    }
}