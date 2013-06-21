using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using Microsoft.Office;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.PowerPoint;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System.Windows.Forms;
using System.IO;

namespace ReportDemo
{
    public class WordOperator
    {
        #region 构造函数

        /// <summary>
        /// 新建、有界面
        /// </summary>
        public WordOperator()
        {
            Init(true);
        }

        public WordOperator(string fileName, bool isShow)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                //Debug.Assert(false);

                throw new Exception("无效文件名");
            }

            Init(isShow);
        }
        //add by cdd 20120822
        public WordOperator(string templatePath)
        {
            Init(templatePath, true);
        }


        ~WordOperator()
        {
            //必须显式调用
            //Close();
        }
        #endregion

        #region protected 方法

        protected virtual void Init(bool isShow)
        {
            _app = new Microsoft.Office.Interop.Word.ApplicationClass();

            _doc = _app.Documents.Add(ref missing, ref missing, ref missing, ref missing);

            try
            {
                _doc.Activate();
            }
            catch (Exception)
            {

            }

            _app.Visible = isShow;
        }
        /// <summary>
        /// add by cdd 20120822
        /// </summary>
        /// <param name="templatePath"></param>
        /// <param name="isShow"></param>
        protected virtual void Init(string templatePath, bool isShow)
        {
            _app = new Microsoft.Office.Interop.Word.ApplicationClass();

            _doc = _app.Documents.Add(ref missing, ref missing, ref missing, ref missing);

            try
            {
                _doc.Activate();
            }
            catch (Exception)
            {

            }

            _app.Visible = isShow;
            LoadDotFile(templatePath);
        }

        #endregion

        #region 数据成员

        protected string _fileName;
        protected Microsoft.Office.Interop.Word.Application _app;
        protected Microsoft.Office.Interop.Word.Document _doc;
        protected object missing = System.Reflection.Missing.Value;

        #endregion

        #region public 方法

        /// <summary>
        /// 文字写入Word
        /// </summary>
        /// <param name="sText">写入的文字</param>
        /// <returns>是否写入成功</returns>
        public bool TexttoWord(string sText)
        {
            try
            {
                object UNIT = WdUnits.wdLine as object;
                object Count = 1;
                object Extend = null;
                _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                _app.Selection.Font.Size = 12;
                _app.Selection.Font.Name = "宋体";
                _app.Selection.Font.Color = WdColor.wdColorBlack;
                _app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                _app.Selection.Text = sText;// + "\n";
                _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 文字写入Word
        /// </summary>
        /// <param name="sText">写入的文字</param>
        /// <returns>是否写入成功</returns>
        public bool TexttoWord(TextInfo txtInfo)
        {
            try
            {
                object UNIT = WdUnits.wdLine as object;
                object Count = 1;
                object Extend = null;
                _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                _app.Selection.Font.Size = txtInfo.TxtFont.Size;
                _app.Selection.Font.Name = txtInfo.TxtFont.Name;
                if (txtInfo.TxtColor == Color.Red)
                    _app.Selection.Font.Color = WdColor.wdColorRed;
                else
                    _app.Selection.Font.Color = WdColor.wdColorBlack;
                if (txtInfo.Alignment == AlignmentType.e_type_left)
                    _app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                else if (txtInfo.Alignment == AlignmentType.e_type_middle)
                    _app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                else
                    _app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                _app.Selection.Text = txtInfo.Txt;
                _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 标题写入Word
        /// </summary>
        /// <param name="sTitle">标题字符串</param>
        /// <param name="sTitleNO">标题编号</param>
        /// <param name="sTitleGrade">标题级别</param>
        /// <returns>是否写入成功</returns>
        public bool TitleToWord(string sTitle, string sTitleNO, int sTitleGrade)
        {
            try
            {
                if (sTitleGrade == 1)   //一级标题
                {
                    object UNIT = WdUnits.wdLine as object;
                    object Count = 1;
                    object Extend = null;
                    _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                    _app.Selection.HomeKey(ref UNIT, ref Extend);
                    _app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    _app.Selection.Font.Size = 20;
                    _app.Selection.Font.Name = "黑体";
                    _app.Selection.Font.Color = WdColor.wdColorBlack;
                    _app.Selection.Text = sTitleNO + sTitle;
                    _app.Selection.InsertParagraphAfter();
                    //_app.Selection.InsertParagraphAfter();
                    _app.Selection.EndKey(ref UNIT, ref Extend);
                }

                if (sTitleGrade == 2)  //二级标题
                {
                    object UNIT = WdUnits.wdLine as object;
                    object Count = 1;
                    object Extend = null;
                    _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                    _app.Selection.HomeKey(ref UNIT, ref Extend);
                    _app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    _app.Selection.Font.Size = 18;
                    _app.Selection.Font.Name = "黑体";
                    _app.Selection.Font.Color = WdColor.wdColorBlack;
                    _app.Selection.Text = (sTitleNO + sTitle);
                    _app.Selection.InsertParagraphAfter();
                    //_app.Selection.InsertParagraphAfter();
                    _app.Selection.EndKey(ref UNIT, ref Extend);
                }

                if (sTitleGrade == 3)     //三级标题
                {
                    object UNIT = WdUnits.wdLine as object;
                    object Count = 1;
                    object Extend = null;
                    _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                    _app.Selection.HomeKey(ref UNIT, ref Extend);
                    _app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    _app.Selection.Font.Size = 15;
                    _app.Selection.Font.Name = "黑体";
                    _app.Selection.Font.Color = WdColor.wdColorBlack;
                    _app.Selection.Text = (sTitleNO + sTitle);
                    _app.Selection.InsertParagraphAfter();
                    //_app.Selection.InsertParagraphAfter();
                    _app.Selection.EndKey(ref UNIT, ref Extend);
                }

                if (sTitleGrade == 4)                //四级标题
                {
                    object UNIT = WdUnits.wdLine as object;
                    object Count = 1;
                    object Extend = null;
                    _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                    _app.Selection.HomeKey(ref UNIT, ref Extend);
                    _app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    _app.Selection.Font.Size = 12;
                    _app.Selection.Font.Name = "黑体";
                    _app.Selection.Text = (sTitleNO + sTitle);
                    _app.Selection.InsertParagraphAfter();
                    //_app.Selection.InsertParagraphAfter();
                    _app.Selection.EndKey(ref UNIT, ref Extend);
                }

                _app.Selection.Font.Size = 12;
                _app.Selection.Font.Name = "宋体";
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 标题写入Word
        /// </summary>
        /// <returns>是否写入成功</returns>
        public bool TitleToWord(TextInfo txtInfo)
        {
            try
            {
                object UNIT = WdUnits.wdLine as object;
                object Count = 1;
                object Extend = null;
                _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                _app.Selection.HomeKey(ref UNIT, ref Extend);
                if (txtInfo.Alignment == AlignmentType.e_type_left)
                    _app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                else if (txtInfo.Alignment == AlignmentType.e_type_middle)
                    _app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                else
                    _app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                _app.Selection.Font.Size = txtInfo.TxtFont.Size;
                _app.Selection.Font.Name = txtInfo.TxtFont.Name;
                _app.Selection.Text = txtInfo.Txt;
                _app.Selection.Font.Color = (WdColor.wdColorRed);
                _app.Selection.InsertParagraphAfter();
                _app.Selection.EndKey(ref UNIT, ref Extend);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void InsertLine()
        {
            try
            {
                object UNIT = WdUnits.wdLine as object;
                object Count = 1;
                object Extend = null;
                _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                _app.Selection.HomeKey(ref UNIT, ref Extend);
                _app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                InlineShape line = _app.Selection.InlineShapes.AddHorizontalLineStandard(ref missing);
                //line.Width = 2;
                _app.Selection.Font.Color = WdColor.wdColorRed;
                _app.Selection.InsertParagraphAfter();
                _app.Selection.EndKey(ref UNIT, ref Extend);
            }
            catch
            {
            }
        }
        /// <summary>
        /// 在Word中插入表
        /// </summary>
        /// <param name="sDT">要插入的表</param>
        /// <param name="sTableNO">表编号</param>
        /// <param name="sTableName">表名</param>
        /// <returns>是否成功</returns>
        public bool TableToWord(System.Data.DataTable sDT, string sTableNO, string sTableName)
        {
            try
            {
                object UNIT = WdUnits.wdLine as object;
                object Count = 1;
                object Extend = null;
                _app.Selection.Text = "\n";
                _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);

                _app.Selection.InsertParagraphAfter();

                Microsoft.Office.Interop.Word.Table sTable;
                Microsoft.Office.Interop.Word.Range sRange;
                int iRowCount = sDT.Rows.Count;
                int iColCount = sDT.Columns.Count;
                if ((iRowCount == 0) | (iColCount == 0))
                {
                    _app.Selection.Font.Size = 12;
                    _app.Selection.Font.Name = "宋体";
                    return true;
                }
                _app.Selection.Font.Name = "宋体";
                _app.Selection.Font.Size = 12;
                sRange = _app.Selection.Range;
                object DefaultTableBehavior = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
                object AutoFitBehavior = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
                sTable = _app.Selection.Tables.Add(sRange, iRowCount + 1, iColCount, ref DefaultTableBehavior, ref AutoFitBehavior);
                sTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                sTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleDouble;
                //设置字段（列）的宽度
                for (int i = 1; i <= iColCount; i++)
                {
                    sTable.Columns[i].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthAuto;
                    sTable.Cell(1, i).Range.InsertAfter((string.IsNullOrEmpty(sDT.Columns[i - 1].Caption) ? sDT.Columns[i - 1].ColumnName : sDT.Columns[i - 1].Caption));
                    sTable.Cell(1, i).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    sTable.Cell(1, i).Range.Font.Name = "黑体";
                }

                for (int i = 0; i < iRowCount; i++)
                {
                    System.Data.DataRow sDR = sDT.Rows[i];
                    for (int j = 0; j < iColCount; j++)
                    {
                        if (sDR[j] != null)
                        {
                            sTable.Cell(i + 2, j + 1).Range.InsertAfter(sDR[j].ToString());
                            sTable.Cell(i + 2, j + 1).Range.Font.Name = "宋体";
                        }
                        else
                        {
                            sTable.Cell(i + 2, j + 1).Range.InsertAfter(" ");
                            sTable.Cell(i + 2, j + 1).Range.Font.Name = "宋体";
                        }
                    }
                }

                //设置表格居中
                sTable.Select();

                _app.CommandBars["formatting"].Controls["居中（&C)"].Execute();
                object d = null;
                _app.Selection.Collapse(ref d);

                Count = 1;
                //_app.Selection.Text = "\n";
                //_app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);

                Count = 1;
                //object Extend = null;
                //_app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                _app.Selection.HomeKey(ref UNIT, ref Extend);
                _app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                _app.Selection.Font.Size = 12;
                _app.Selection.Font.Name = "黑体";
                _app.Selection.Text = (sTableNO + sTableName);
                _app.Selection.InsertParagraphAfter();
                //_app.Selection.InsertParagraphAfter();
                //_app.Selection.EndKey(ref UNIT, ref Extend);
                _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                return true;
            }
            catch
            {
                return false;
            }


        }

        /// <summary>
        /// 在Word中插入表
        /// </summary>
        /// <param name="sDT">要插入的表</param>
        /// <param name="sTableNO">表编号</param>
        /// <param name="sTableName">表名</param>
        /// <returns>是否成功</returns>
        public bool TableToWord(DevExpress.XtraGrid.Views.Grid.GridView sGridView, string sTableNO, string sTableName)
        {
            try
            {
                object UNIT = WdUnits.wdLine as object;
                object Count = 1;
                object Extend = null;
                _app.Selection.Text = "\n";
                _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);

                _app.Selection.InsertParagraphAfter();

                Microsoft.Office.Interop.Word.Table sTable;
                Microsoft.Office.Interop.Word.Range sRange;

                int iRowCount = sGridView.RowCount;
                int iColCount = 0;
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in sGridView.Columns)
                {
                    if (col.Visible) iColCount++;
                }
                if ((iRowCount == 0) | (iColCount == 0))
                {
                    _app.Selection.Font.Size = 12;
                    _app.Selection.Font.Name = "宋体";
                    return true;
                }
                _app.Selection.Font.Name = "宋体";
                _app.Selection.Font.Size = 12;
                sRange = _app.Selection.Range;
                object DefaultTableBehavior = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
                object AutoFitBehavior = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
                sTable = _app.Selection.Tables.Add(sRange, iRowCount + 1, iColCount, ref DefaultTableBehavior, ref AutoFitBehavior);
                sTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                sTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleDouble;
                //设置字段（列）的宽度
                int i = 1;
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in sGridView.Columns)
                {
                    if (col.Visible)
                    {
                        sTable.Columns[i].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthAuto;
                        sTable.Cell(1, i).Range.InsertAfter((string.IsNullOrEmpty(col.Caption) ? col.FieldName : col.Caption));
                        sTable.Cell(1, i).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        sTable.Cell(1, i).Range.Font.Name = "黑体";
                        i++;
                    }
                }

                i = 1;
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in sGridView.Columns)
                {
                    if (col.Visible)
                    {
                        for (int j = 0; j < iRowCount; j++)
                        {
                            try
                            {
                                sTable.Cell(j + 2, i).Range.InsertAfter(sGridView.GetRowCellValue(j, col).ToString());
                                sTable.Cell(j + 2, i).Range.Font.Name = "宋体";
                            }
                            catch
                            {
                                sTable.Cell(j + 2, i).Range.InsertAfter("");
                                sTable.Cell(j + 2, i).Range.Font.Name = "宋体";
                            }
                        }
                        i++;
                    }
                }

                //设置表格居中
                sTable.Select();

                _app.CommandBars["formatting"].Controls["居中（&C)"].Execute();
                object d = null;
                _app.Selection.Collapse(ref d);

                Count = 1;
                //_app.Selection.Text = "\n";
                //_app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);

                Count = 1;
                //object Extend = null;
                //_app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                _app.Selection.HomeKey(ref UNIT, ref Extend);
                _app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                _app.Selection.Font.Size = 12;
                _app.Selection.Font.Name = "黑体";
                _app.Selection.Text = (sTableNO + sTableName);
                _app.Selection.InsertParagraphAfter();
                //_app.Selection.InsertParagraphAfter();
                //_app.Selection.EndKey(ref UNIT, ref Extend);
                _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                return true;
            }
            catch
            {
                return false;
            }


        }
        /// <summary>
        /// 在Word中插入树中的数据
        /// </summary>
        /// <param name="sTreeList">要插入的树</param>
        /// <param name="sTableNO">表编号</param>
        /// <param name="sTableName">表名</param>
        /// <returns>是否成功</returns>
        public bool TreeListToWord(TreeList sTreeList, string sTableNO, string sTableName)
        {
            try
            {
                object UNIT = WdUnits.wdLine as object;
                object Count = 1;
                object Extend = null;
                _app.Selection.Text = "\n";
                _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);

                _app.Selection.InsertParagraphAfter();

                Microsoft.Office.Interop.Word.Table sTable;
                Microsoft.Office.Interop.Word.Range sRange;

                int iRowCount = 0;//sGridView.RowCount;
                for (int i = 0; i < sTreeList.Nodes.Count; i++)
                {
                    iRowCount++;
                    for (int j = 0; j < sTreeList.Nodes[i].Nodes.Count; j++)
                    {
                        iRowCount++;
                    }
                }
                int iColCount = 0;
                foreach (TreeListColumn col in sTreeList.Columns)
                {
                    if (col.Visible) iColCount++;
                }
                if ((iRowCount == 0) | (iColCount == 0))
                {
                    _app.Selection.Font.Size = 12;
                    _app.Selection.Font.Name = "宋体";
                    return true;
                }
                _app.Selection.Font.Name = "宋体";
                _app.Selection.Font.Size = 12;
                sRange = _app.Selection.Range;
                object DefaultTableBehavior = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
                object AutoFitBehavior = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
                sTable = _app.Selection.Tables.Add(sRange, iRowCount + 1, iColCount, ref DefaultTableBehavior, ref AutoFitBehavior);
                sTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                sTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleDouble;
                //设置字段（列）的宽度
                int colIndex = 1;
                foreach (TreeListColumn col in sTreeList.Columns)
                {
                    if (col.Visible)
                    {
                        sTable.Columns[colIndex].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthAuto;
                        sTable.Cell(1, colIndex).Range.InsertAfter((string.IsNullOrEmpty(col.Caption) ? col.FieldName : col.Caption));
                        sTable.Cell(1, colIndex).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        sTable.Cell(1, colIndex).Range.Font.Name = "黑体";
                        colIndex++;
                    }
                }

                colIndex = 1;
                int rowIndex = 2;
                for (int k = 0; k < sTreeList.Nodes.Count; k++)
                {
                    foreach (TreeListColumn col in sTreeList.Columns)
                    {
                        if (col.Visible)
                        {
                            try
                            {
                                sTable.Cell(rowIndex, colIndex).Range.InsertAfter(sTreeList.Nodes[k].GetValue(col.FieldName).ToString());
                                sTable.Cell(rowIndex, colIndex).Range.Font.Name = "宋体";
                            }
                            catch
                            {
                                sTable.Cell(rowIndex, colIndex).Range.InsertAfter("");
                                sTable.Cell(rowIndex, colIndex).Range.Font.Name = "宋体";
                            }
                        }
                        colIndex++;
                    }
                    colIndex = 1;
                    rowIndex++;
                    for (int p = 0; p < sTreeList.Nodes[k].Nodes.Count; p++)
                    {
                        foreach (TreeListColumn col in sTreeList.Columns)
                        {
                            if (col.Visible)
                            {
                                try
                                {
                                    sTable.Cell(rowIndex, colIndex).Range.InsertAfter(sTreeList.Nodes[k].Nodes[p].GetValue(col.FieldName).ToString());
                                    sTable.Cell(rowIndex, colIndex).Range.Font.Name = "宋体";
                                }
                                catch
                                {
                                    sTable.Cell(rowIndex, colIndex).Range.InsertAfter("");
                                    sTable.Cell(rowIndex, colIndex).Range.Font.Name = "宋体";
                                }
                            }
                            colIndex++;
                        }
                        colIndex = 1;
                        rowIndex++;
                    }
                    colIndex = 1;
                    rowIndex++;
                }



                //设置表格居中
                sTable.Select();

                _app.CommandBars["formatting"].Controls["居中（&C)"].Execute();
                object d = null;
                _app.Selection.Collapse(ref d);

                Count = 1;
                //_app.Selection.Text = "\n";
                //_app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);

                Count = 1;
                //object Extend = null;
                //_app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                _app.Selection.HomeKey(ref UNIT, ref Extend);
                _app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                _app.Selection.Font.Size = 12;
                _app.Selection.Font.Name = "黑体";
                _app.Selection.Text = (sTableNO + sTableName);
                _app.Selection.InsertParagraphAfter();
                //_app.Selection.InsertParagraphAfter();
                //_app.Selection.EndKey(ref UNIT, ref Extend);
                _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                return true;
            }
            catch
            {
                return false;
            }


        }

        /// <summary>
        /// 在Word中插入图片
        /// </summary>
        /// <param name="sPicFileName">图片的文件名</param>
        /// <param name="sPicNo">图编号</param>
        /// <param name="sPicName">图名</param>
        /// <returns>是否成功</returns>
        public bool PictureToWord(string sPicFileName, string sPicNo, string sPicName)
        {
            try
            {
                object UNIT = WdUnits.wdLine as object;
                object Count = 1;
                object Extend = null;
                _app.Selection.Text = "\n";
                _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                object missing = System.Reflection.Missing.Value;
                _app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                object sLinkfile = false;
                object sSaveFile = true;
                _app.Selection.InlineShapes.AddPicture(sPicFileName, ref sLinkfile, ref sSaveFile, ref missing);

                //添加图片标题

                //object Extend = null;
                _app.Selection.Text = "\n";
                _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                _app.Selection.HomeKey(ref UNIT, ref missing);
                _app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                _app.Selection.Font.Size = 12;
                _app.Selection.Font.Name = "黑体";
                _app.Selection.Text = (sPicNo + sPicName);
                _app.Selection.InsertParagraphAfter();
                //_app.Selection.InsertParagraphAfter();
                _app.Selection.EndKey(ref UNIT, ref missing);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Save()
        {
            try
            {
                if (string.IsNullOrEmpty(_fileName))
                    _doc.Save();
                else
                {
                    object fileName = _fileName;

                    _doc.SaveAs(ref fileName, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                }
            }
            catch (Exception ex)
            {
                //Debug.Assert(false,ex.Message);
            }
        }

        public void Close(bool isSave)
        {
            try
            {
                if (isSave)
                    Save();

                object saved = (object)false;
                _doc.Close(ref saved, ref missing, ref missing);

                _app.Quit(ref saved, ref missing, ref missing);
            }
            catch (Exception ex)
            {
                //Debug.Assert(false,ex.Message);
            }
        }
        /// <summary>
        /// 设置文字书签
        /// </summary>
        /// <param name="ob_bookmarkName"></param>
        /// <param name="textInfo"></param>
        public void SetTextBookmark(object ob_bookmarkName, string textInfo)
        {
            if (!string.IsNullOrEmpty(textInfo))
            {
                _doc.Bookmarks.get_Item(ref ob_bookmarkName).Range.Text = textInfo;
            }
        }
        /// <summary>
        /// 设置图片书签
        /// </summary>
        public void SetPicBookmark(object ob_bookmarkName, string sPicFileName)
        {
            object objTrue = true;
            object objFalse = false;
            if (!string.IsNullOrEmpty(sPicFileName) && File.Exists(sPicFileName))
            {
                _doc.Bookmarks.get_Item(ref ob_bookmarkName).Select();
                object range = _doc.Bookmarks.get_Item(ref ob_bookmarkName).Range;
                InlineShape shape = _doc.Application.Selection.Range.InlineShapes.AddPicture(sPicFileName, ref objFalse, ref objTrue, ref range);
            }
        }
        /// <summary>
        /// 设置表格书签
        /// </summary>
        public void SetTableBookmark(object ob_bookmarkName, DevExpress.XtraGrid.Views.Grid.GridView sGridView)
        {
            Microsoft.Office.Interop.Word.Table sTable;

            int iRowCount = sGridView.RowCount;
            int iColCount = 0;
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in sGridView.Columns)
            {
                if (col.Visible) iColCount++;
            }
            object DefaultTableBehavior = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
            object AutoFitBehavior = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
            sTable = _doc.Bookmarks.get_Item(ref ob_bookmarkName).Range.Tables.Add(_doc.Bookmarks.get_Item(ref ob_bookmarkName).Range, iRowCount + 1, iColCount, ref DefaultTableBehavior, ref AutoFitBehavior);
            sTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            sTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleDouble;
            //设置字段（列）的宽度
            int i = 1;
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in sGridView.Columns)
            {
                if (col.Visible)
                {
                    sTable.Columns[i].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthAuto;
                    sTable.Cell(1, i).Range.InsertAfter((string.IsNullOrEmpty(col.Caption) ? col.FieldName : col.Caption));
                    sTable.Cell(1, i).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    sTable.Cell(1, i).Range.Font.Name = "黑体";
                    i++;
                }
            }

            i = 1;
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in sGridView.Columns)
            {
                if (col.Visible)
                {
                    for (int j = 0; j < iRowCount; j++)
                    {
                        try
                        {
                            sTable.Cell(j + 2, i).Range.InsertAfter(sGridView.GetRowCellValue(j, col).ToString());
                            sTable.Cell(j + 2, i).Range.Font.Name = "宋体";
                        }
                        catch
                        {
                            sTable.Cell(j + 2, i).Range.InsertAfter("");
                            sTable.Cell(j + 2, i).Range.Font.Name = "宋体";
                        }
                    }
                    i++;
                }
            }

            //设置表格居中
            sTable.Select();
            this._app.Selection.Tables[1].Rows.Alignment = WdRowAlignment.wdAlignRowCenter;//表格居中
        }
        /// <summary>
        /// 设置表格书签1
        /// </summary>
        /// <param name="ob_bookmarkName"></param>
        /// <param name="sDataTable"></param>
        public void SetDataTableBookmark(object ob_bookmarkName, System.Data.DataTable sDataTable)
        {
            Microsoft.Office.Interop.Word.Table sTable;

            int iRowCount = sDataTable.Rows.Count;
            int iColCount = 0;
            foreach (System.Data.DataColumn col in sDataTable.Columns)
            {
                iColCount++;
            }
            object DefaultTableBehavior = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
            object AutoFitBehavior = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
            sTable = _doc.Bookmarks.get_Item(ref ob_bookmarkName).Range.Tables.Add(_doc.Bookmarks.get_Item(ref ob_bookmarkName).Range, iRowCount + 1, iColCount, ref DefaultTableBehavior, ref AutoFitBehavior);
            sTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            sTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleDouble;
            //设置字段（列）的宽度
            int i = 1;
            foreach (System.Data.DataColumn col in sDataTable.Columns)
            {

                sTable.Columns[i].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthAuto;
                sTable.Cell(1, i).Range.InsertAfter((string.IsNullOrEmpty(col.Caption) ? col.ColumnName : col.Caption));
                sTable.Cell(1, i).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                sTable.Cell(1, i).Range.Font.Name = "黑体";
                sTable.Cell(1, i).Range.Font.Size = 12;
                i++;
            }

            i = 1;
            foreach (System.Data.DataColumn col in sDataTable.Columns)
            {

                for (int j = 0; j < iRowCount; j++)
                {
                    try
                    {
                        sTable.Cell(j + 2, i).Range.InsertAfter(sDataTable.Rows[j][col].ToString());
                        sTable.Cell(j + 2, i).Range.Font.Name = "宋体";
                        sTable.Cell(j + 2, i).Range.Font.Size = 12;
                    }
                    catch
                    {
                        sTable.Cell(j + 2, i).Range.InsertAfter("");
                        sTable.Cell(j + 2, i).Range.Font.Name = "宋体";
                        sTable.Cell(j + 2, i).Range.Font.Size = 12;
                    }
                }
                i++;
            }

            //设置表格居中
            sTable.Select();
            this._app.Selection.Tables[1].Rows.Alignment = WdRowAlignment.wdAlignRowCenter;//表格居中
        }

        /// <summary>
        /// 设置图标书签
        /// </summary>
        public void SetChartBookmark(object ob_bookmarkName, string[] files)
        {
            object objTrue = true;
            object objFalse = false;
            if (files != null && files.Length > 0)
            {
                _doc.Bookmarks.get_Item(ref ob_bookmarkName).Select();
                object range = _doc.Bookmarks.get_Item(ref ob_bookmarkName).Range;
                for (int k = files.Length - 1; k >= 0; k--)
                {
                    InlineShape shape = _doc.Application.Selection.Range.InlineShapes.AddPicture(files[k], ref objFalse, ref objTrue, ref range);


                }
            }
        }

        #endregion

        #region 加载word模板 add by cdd 20120822
        /// <summary>
        /// 附加dot模版文件
        /// </summary>
        private void LoadDotFile(string strDotFile)
        {
            if (!string.IsNullOrEmpty(strDotFile))
            {
                Microsoft.Office.Interop.Word.Document wDot = null;
                if (_app != null)
                {
                    _doc = _app.ActiveDocument;

                    //_app.Selection.WholeStory();

                    //_app.Selection.Copy();
                    wDot = CreateWordDocument(strDotFile, true);

                    wDot.Activate();
                    //_app.Selection.Paste();
                    _app.Selection.WholeStory();
                    _app.Selection.Copy();
                    wDot.Close(ref missing, ref missing, ref missing);

                    _doc.Activate();
                    _app.Selection.Paste();
                    _app.Selection.WholeStory();
                    _app.Selection.PasteAndFormat(WdRecoveryType.wdPasteDefault);

                }
            }
        }

        ///  
        /// 打开Word文档,并且返回对象oDoc
        /// 完整Word文件路径+名称  
        /// 返回的Word.Document oDoc对象 
        public Microsoft.Office.Interop.Word.Document CreateWordDocument(string FileName, bool HideWin)
        {
            if (FileName == "") return null;

            _app.Visible = HideWin;
            _app.Caption = "";
            _app.Options.CheckSpellingAsYouType = false;
            _app.Options.CheckGrammarAsYouType = false;

            Object filename = FileName;
            Object ConfirmConversions = false;
            Object ReadOnly = true;
            Object AddToRecentFiles = false;

            Object PasswordDocument = System.Type.Missing;
            Object PasswordTemplate = System.Type.Missing;
            Object Revert = System.Type.Missing;
            Object WritePasswordDocument = System.Type.Missing;
            Object WritePasswordTemplate = System.Type.Missing;
            Object Format = System.Type.Missing;
            Object Encoding = System.Type.Missing;
            Object Visible = System.Type.Missing;
            Object OpenAndRepair = System.Type.Missing;
            Object DocumentDirection = System.Type.Missing;
            Object NoEncodingDialog = System.Type.Missing;
            Object XMLTransform = System.Type.Missing;
            try
            {
                Microsoft.Office.Interop.Word.Document wordDoc = _app.Documents.Open(ref filename, ref ConfirmConversions,
                ref ReadOnly, ref AddToRecentFiles, ref PasswordDocument, ref PasswordTemplate,
                ref Revert, ref WritePasswordDocument, ref WritePasswordTemplate, ref Format,
                ref Encoding, ref Visible, ref OpenAndRepair, ref DocumentDirection,
                ref NoEncodingDialog, ref XMLTransform);
                return wordDoc;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        #endregion

        public class TextInfo
        {
            /// <summary>
            /// 文本内容
            /// </summary>
            public string Txt;
            /// <summary>
            /// 文本字体
            /// </summary>
            public System.Drawing.Font TxtFont;
            /// <summary>
            /// 文本颜色
            /// </summary>
            public Color TxtColor = Color.Black;
            /// <summary>
            /// 背景颜色
            /// </summary>
            public Color BackColor = Color.Transparent;
            /// <summary>
            /// 对齐方式
            /// </summary>
            public AlignmentType Alignment;
        }

        public enum AlignmentType
        {
            e_type_left,
            e_type_middle,
            e_type_right
        };
    }
}
