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
        #region ���캯��

        /// <summary>
        /// �½����н���
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

                throw new Exception("��Ч�ļ���");
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
            //������ʽ����
            //Close();
        }
        #endregion

        #region protected ����

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

        #region ���ݳ�Ա

        protected string _fileName;
        protected Microsoft.Office.Interop.Word.Application _app;
        protected Microsoft.Office.Interop.Word.Document _doc;
        protected object missing = System.Reflection.Missing.Value;

        #endregion

        #region public ����

        /// <summary>
        /// ����д��Word
        /// </summary>
        /// <param name="sText">д�������</param>
        /// <returns>�Ƿ�д��ɹ�</returns>
        public bool TexttoWord(string sText)
        {
            try
            {
                object UNIT = WdUnits.wdLine as object;
                object Count = 1;
                object Extend = null;
                _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                _app.Selection.Font.Size = 12;
                _app.Selection.Font.Name = "����";
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
        /// ����д��Word
        /// </summary>
        /// <param name="sText">д�������</param>
        /// <returns>�Ƿ�д��ɹ�</returns>
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
        /// ����д��Word
        /// </summary>
        /// <param name="sTitle">�����ַ���</param>
        /// <param name="sTitleNO">������</param>
        /// <param name="sTitleGrade">���⼶��</param>
        /// <returns>�Ƿ�д��ɹ�</returns>
        public bool TitleToWord(string sTitle, string sTitleNO, int sTitleGrade)
        {
            try
            {
                if (sTitleGrade == 1)   //һ������
                {
                    object UNIT = WdUnits.wdLine as object;
                    object Count = 1;
                    object Extend = null;
                    _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                    _app.Selection.HomeKey(ref UNIT, ref Extend);
                    _app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    _app.Selection.Font.Size = 20;
                    _app.Selection.Font.Name = "����";
                    _app.Selection.Font.Color = WdColor.wdColorBlack;
                    _app.Selection.Text = sTitleNO + sTitle;
                    _app.Selection.InsertParagraphAfter();
                    //_app.Selection.InsertParagraphAfter();
                    _app.Selection.EndKey(ref UNIT, ref Extend);
                }

                if (sTitleGrade == 2)  //��������
                {
                    object UNIT = WdUnits.wdLine as object;
                    object Count = 1;
                    object Extend = null;
                    _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                    _app.Selection.HomeKey(ref UNIT, ref Extend);
                    _app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    _app.Selection.Font.Size = 18;
                    _app.Selection.Font.Name = "����";
                    _app.Selection.Font.Color = WdColor.wdColorBlack;
                    _app.Selection.Text = (sTitleNO + sTitle);
                    _app.Selection.InsertParagraphAfter();
                    //_app.Selection.InsertParagraphAfter();
                    _app.Selection.EndKey(ref UNIT, ref Extend);
                }

                if (sTitleGrade == 3)     //��������
                {
                    object UNIT = WdUnits.wdLine as object;
                    object Count = 1;
                    object Extend = null;
                    _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                    _app.Selection.HomeKey(ref UNIT, ref Extend);
                    _app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    _app.Selection.Font.Size = 15;
                    _app.Selection.Font.Name = "����";
                    _app.Selection.Font.Color = WdColor.wdColorBlack;
                    _app.Selection.Text = (sTitleNO + sTitle);
                    _app.Selection.InsertParagraphAfter();
                    //_app.Selection.InsertParagraphAfter();
                    _app.Selection.EndKey(ref UNIT, ref Extend);
                }

                if (sTitleGrade == 4)                //�ļ�����
                {
                    object UNIT = WdUnits.wdLine as object;
                    object Count = 1;
                    object Extend = null;
                    _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                    _app.Selection.HomeKey(ref UNIT, ref Extend);
                    _app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    _app.Selection.Font.Size = 12;
                    _app.Selection.Font.Name = "����";
                    _app.Selection.Text = (sTitleNO + sTitle);
                    _app.Selection.InsertParagraphAfter();
                    //_app.Selection.InsertParagraphAfter();
                    _app.Selection.EndKey(ref UNIT, ref Extend);
                }

                _app.Selection.Font.Size = 12;
                _app.Selection.Font.Name = "����";
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// ����д��Word
        /// </summary>
        /// <returns>�Ƿ�д��ɹ�</returns>
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
        /// ��Word�в����
        /// </summary>
        /// <param name="sDT">Ҫ����ı�</param>
        /// <param name="sTableNO">����</param>
        /// <param name="sTableName">����</param>
        /// <returns>�Ƿ�ɹ�</returns>
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
                    _app.Selection.Font.Name = "����";
                    return true;
                }
                _app.Selection.Font.Name = "����";
                _app.Selection.Font.Size = 12;
                sRange = _app.Selection.Range;
                object DefaultTableBehavior = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
                object AutoFitBehavior = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
                sTable = _app.Selection.Tables.Add(sRange, iRowCount + 1, iColCount, ref DefaultTableBehavior, ref AutoFitBehavior);
                sTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                sTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleDouble;
                //�����ֶΣ��У��Ŀ��
                for (int i = 1; i <= iColCount; i++)
                {
                    sTable.Columns[i].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthAuto;
                    sTable.Cell(1, i).Range.InsertAfter((string.IsNullOrEmpty(sDT.Columns[i - 1].Caption) ? sDT.Columns[i - 1].ColumnName : sDT.Columns[i - 1].Caption));
                    sTable.Cell(1, i).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    sTable.Cell(1, i).Range.Font.Name = "����";
                }

                for (int i = 0; i < iRowCount; i++)
                {
                    System.Data.DataRow sDR = sDT.Rows[i];
                    for (int j = 0; j < iColCount; j++)
                    {
                        if (sDR[j] != null)
                        {
                            sTable.Cell(i + 2, j + 1).Range.InsertAfter(sDR[j].ToString());
                            sTable.Cell(i + 2, j + 1).Range.Font.Name = "����";
                        }
                        else
                        {
                            sTable.Cell(i + 2, j + 1).Range.InsertAfter(" ");
                            sTable.Cell(i + 2, j + 1).Range.Font.Name = "����";
                        }
                    }
                }

                //���ñ�����
                sTable.Select();

                _app.CommandBars["formatting"].Controls["���У�&C)"].Execute();
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
                _app.Selection.Font.Name = "����";
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
        /// ��Word�в����
        /// </summary>
        /// <param name="sDT">Ҫ����ı�</param>
        /// <param name="sTableNO">����</param>
        /// <param name="sTableName">����</param>
        /// <returns>�Ƿ�ɹ�</returns>
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
                    _app.Selection.Font.Name = "����";
                    return true;
                }
                _app.Selection.Font.Name = "����";
                _app.Selection.Font.Size = 12;
                sRange = _app.Selection.Range;
                object DefaultTableBehavior = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
                object AutoFitBehavior = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
                sTable = _app.Selection.Tables.Add(sRange, iRowCount + 1, iColCount, ref DefaultTableBehavior, ref AutoFitBehavior);
                sTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                sTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleDouble;
                //�����ֶΣ��У��Ŀ��
                int i = 1;
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in sGridView.Columns)
                {
                    if (col.Visible)
                    {
                        sTable.Columns[i].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthAuto;
                        sTable.Cell(1, i).Range.InsertAfter((string.IsNullOrEmpty(col.Caption) ? col.FieldName : col.Caption));
                        sTable.Cell(1, i).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        sTable.Cell(1, i).Range.Font.Name = "����";
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
                                sTable.Cell(j + 2, i).Range.Font.Name = "����";
                            }
                            catch
                            {
                                sTable.Cell(j + 2, i).Range.InsertAfter("");
                                sTable.Cell(j + 2, i).Range.Font.Name = "����";
                            }
                        }
                        i++;
                    }
                }

                //���ñ�����
                sTable.Select();

                _app.CommandBars["formatting"].Controls["���У�&C)"].Execute();
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
                _app.Selection.Font.Name = "����";
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
        /// ��Word�в������е�����
        /// </summary>
        /// <param name="sTreeList">Ҫ�������</param>
        /// <param name="sTableNO">����</param>
        /// <param name="sTableName">����</param>
        /// <returns>�Ƿ�ɹ�</returns>
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
                    _app.Selection.Font.Name = "����";
                    return true;
                }
                _app.Selection.Font.Name = "����";
                _app.Selection.Font.Size = 12;
                sRange = _app.Selection.Range;
                object DefaultTableBehavior = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
                object AutoFitBehavior = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
                sTable = _app.Selection.Tables.Add(sRange, iRowCount + 1, iColCount, ref DefaultTableBehavior, ref AutoFitBehavior);
                sTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                sTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleDouble;
                //�����ֶΣ��У��Ŀ��
                int colIndex = 1;
                foreach (TreeListColumn col in sTreeList.Columns)
                {
                    if (col.Visible)
                    {
                        sTable.Columns[colIndex].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthAuto;
                        sTable.Cell(1, colIndex).Range.InsertAfter((string.IsNullOrEmpty(col.Caption) ? col.FieldName : col.Caption));
                        sTable.Cell(1, colIndex).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        sTable.Cell(1, colIndex).Range.Font.Name = "����";
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
                                sTable.Cell(rowIndex, colIndex).Range.Font.Name = "����";
                            }
                            catch
                            {
                                sTable.Cell(rowIndex, colIndex).Range.InsertAfter("");
                                sTable.Cell(rowIndex, colIndex).Range.Font.Name = "����";
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
                                    sTable.Cell(rowIndex, colIndex).Range.Font.Name = "����";
                                }
                                catch
                                {
                                    sTable.Cell(rowIndex, colIndex).Range.InsertAfter("");
                                    sTable.Cell(rowIndex, colIndex).Range.Font.Name = "����";
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



                //���ñ�����
                sTable.Select();

                _app.CommandBars["formatting"].Controls["���У�&C)"].Execute();
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
                _app.Selection.Font.Name = "����";
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
        /// ��Word�в���ͼƬ
        /// </summary>
        /// <param name="sPicFileName">ͼƬ���ļ���</param>
        /// <param name="sPicNo">ͼ���</param>
        /// <param name="sPicName">ͼ��</param>
        /// <returns>�Ƿ�ɹ�</returns>
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

                //���ͼƬ����

                //object Extend = null;
                _app.Selection.Text = "\n";
                _app.Selection.MoveDown(ref UNIT, ref Count, ref Extend);
                _app.Selection.HomeKey(ref UNIT, ref missing);
                _app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                _app.Selection.Font.Size = 12;
                _app.Selection.Font.Name = "����";
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
        /// ����������ǩ
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
        /// ����ͼƬ��ǩ
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
        /// ���ñ����ǩ
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
            //�����ֶΣ��У��Ŀ��
            int i = 1;
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in sGridView.Columns)
            {
                if (col.Visible)
                {
                    sTable.Columns[i].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthAuto;
                    sTable.Cell(1, i).Range.InsertAfter((string.IsNullOrEmpty(col.Caption) ? col.FieldName : col.Caption));
                    sTable.Cell(1, i).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    sTable.Cell(1, i).Range.Font.Name = "����";
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
                            sTable.Cell(j + 2, i).Range.Font.Name = "����";
                        }
                        catch
                        {
                            sTable.Cell(j + 2, i).Range.InsertAfter("");
                            sTable.Cell(j + 2, i).Range.Font.Name = "����";
                        }
                    }
                    i++;
                }
            }

            //���ñ�����
            sTable.Select();
            this._app.Selection.Tables[1].Rows.Alignment = WdRowAlignment.wdAlignRowCenter;//������
        }
        /// <summary>
        /// ���ñ����ǩ1
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
            //�����ֶΣ��У��Ŀ��
            int i = 1;
            foreach (System.Data.DataColumn col in sDataTable.Columns)
            {

                sTable.Columns[i].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthAuto;
                sTable.Cell(1, i).Range.InsertAfter((string.IsNullOrEmpty(col.Caption) ? col.ColumnName : col.Caption));
                sTable.Cell(1, i).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                sTable.Cell(1, i).Range.Font.Name = "����";
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
                        sTable.Cell(j + 2, i).Range.Font.Name = "����";
                        sTable.Cell(j + 2, i).Range.Font.Size = 12;
                    }
                    catch
                    {
                        sTable.Cell(j + 2, i).Range.InsertAfter("");
                        sTable.Cell(j + 2, i).Range.Font.Name = "����";
                        sTable.Cell(j + 2, i).Range.Font.Size = 12;
                    }
                }
                i++;
            }

            //���ñ�����
            sTable.Select();
            this._app.Selection.Tables[1].Rows.Alignment = WdRowAlignment.wdAlignRowCenter;//������
        }

        /// <summary>
        /// ����ͼ����ǩ
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

        #region ����wordģ�� add by cdd 20120822
        /// <summary>
        /// ����dotģ���ļ�
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
        /// ��Word�ĵ�,���ҷ��ض���oDoc
        /// ����Word�ļ�·��+����  
        /// ���ص�Word.Document oDoc���� 
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
            /// �ı�����
            /// </summary>
            public string Txt;
            /// <summary>
            /// �ı�����
            /// </summary>
            public System.Drawing.Font TxtFont;
            /// <summary>
            /// �ı���ɫ
            /// </summary>
            public Color TxtColor = Color.Black;
            /// <summary>
            /// ������ɫ
            /// </summary>
            public Color BackColor = Color.Transparent;
            /// <summary>
            /// ���뷽ʽ
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
