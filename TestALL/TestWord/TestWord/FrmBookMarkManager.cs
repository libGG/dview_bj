using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using Microsoft.Office;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
//using Microsoft.Office.Interop.PowerPoint;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System.Windows.Forms;
using System.IO;

using System.ComponentModel;
using System.Data;

using DevExpress.XtraEditors;


namespace TestWord
{
    public partial class FrmBookMarkManager : DevExpress.XtraEditors.XtraForm
    {
        private object filename = @"E:\temp\工作安排_李波_20130527.doc";
        private Bookmarks _bookmarks;
        protected string _fileName;
        protected Microsoft.Office.Interop.Word.Application _app;
        protected Microsoft.Office.Interop.Word.Document _doc;
        protected object missing = System.Reflection.Missing.Value;
        public FrmBookMarkManager()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            this._app = new Microsoft.Office.Interop.Word.Application();
            _app.Visible = true;

            this._doc = _app.Documents.Open(ref filename, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
            _doc.Activate();
            listBoxControl1.DisplayMember = "Name";
            listBoxControl1.DataSource = BookmarksToList(_doc.Bookmarks);
            //listBoxControl1.ValueMember = "Name";
            
            //foreach (Bookmark var in this._doc.Bookmarks)
            //{
            //    this.listBoxControl1.Items.Add(var);
            //}
        }

        private IList<Bookmark> BookmarksToList(Bookmarks bks)
        {
            IList<Bookmark> books = new List<Bookmark>();
            foreach (Bookmark var in bks)
            {
                books.Add(var);               
            }
            return books;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            object range = _app.Selection.Range;
            Bookmark bknew = this._doc.Bookmarks.Add(txtBookmark.Text.Trim(), ref range);
            //listBoxControl1.Items.Add(bknew.Name);
            listBoxControl1.DataSource = BookmarksToList(_doc.Bookmarks);
            
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //Process cmd = new Process();
            //cmd.StartInfo.FileName = "ipconfig.exe";
            //cmd.StartInfo.RedirectStandardOutput = true;
            //cmd.StartInfo.RedirectStandardInput = true;
            //cmd.StartInfo.UseShellExecute = false;
            //cmd.StartInfo.CreateNoWindow = false;
            //cmd.Start();
            //string info = cmd.StandardOutput.ReadToEnd();
            //cmd.WaitForExit();
            //cmd.Close();
            ////richTextBox1.AppendText(INotifyPropertyChanged 
            //richTextBox1.AppendText(info);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void FrmBookMarkManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Process[] ps = Process.GetProcesses();
            //for (int i = 0; i < ps.Length; i++)
            //{
            //    Process var = ps[i];
            //    if (var.ProcessName.ToLower().Contains("word"))
            //    {
            //        var.Kill();
            //    }
            //}
            foreach (Process var in Process.GetProcesses())
            {
                //if (var.ProcessName.ToLower().Contains("word"))
                //{
                //    var.Kill();
                //}
            }
 
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Bookmark curbk = listBoxControl1.SelectedValue as Bookmark;
            curbk = listBoxControl1.SelectedItem as Bookmark;
            curbk.Delete();
            listBoxControl1.DataSource= this.BookmarksToList(this._doc.Bookmarks);
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            object what = WdGoToItem.wdGoToBookmark;
            object name = (listBoxControl1.SelectedItem as Bookmark).Name;
            object missing=null ;
            _app.Selection.GoTo(ref what,ref missing,ref missing, ref name);
            //_app.Selection.Bookmarks.
        }

        private void listBoxControl1_DoubleClick(object sender, EventArgs e)
        {
            if (null != listBoxControl1.SelectedItem)
            {
                object what = WdGoToItem.wdGoToBookmark;
                object name = (listBoxControl1.SelectedItem as Bookmark).Name;
                object which = null;
                object count = null;
                _app.Selection.GoTo(ref what, ref which, ref count, ref name);
            }
        }

        private void btnCurSelectedItem_Click(object sender, EventArgs e)
        {
            if (null != listBoxControl1.SelectedItem)
            {
                richTextBox1.Text = (listBoxControl1.SelectedItem as Bookmark).Name;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //richTextBox1.Clear();
            //object item = 0;
            //if (radioButtonName.Checked)
            //{
            //    richTextBox1.AppendText("按名称" + "\r\n");
            //    this._doc.Bookmarks.DefaultSorting = WdBookmarkSortBy.wdSortByName;
                
                 
            //    //listBoxControl1.SortOrder = SortOrder.Descending;
            //}
            //else if(radioButtonLocation.Checked)
            //{
            //    richTextBox1.AppendText("按位置" + "\r\n");
            //    this._doc.Bookmarks.DefaultSorting = WdBookmarkSortBy.wdSortByLocation ;
            //}
            ////listBoxControl1.DataSource = this.BookmarksToList(this._doc.Bookmarks);
            ////listBoxControl1.DataSource = this.BookmarksToList(this._doc.Bookmarks);
            //StringBuilder sb = new StringBuilder();
          
            //foreach (Bookmark var in _doc.Bookmarks)
            //{
            //    richTextBox1.AppendText(var.Name + " Creator "+var.Creator.ToString()+"\r\n");
            //    //return;
               
            //}

            //object timeout = 500000;
            //_app.Dialogs[WdWordDialog.wdDialogInsertBookmark].Show(ref timeout);
        }
    
    }
}