//created by lib
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Aspose.Words.Saving;
using Microsoft.Office.Interop.Word;

namespace DView.SXEQJB.TempleteMgr
{
    /// <summary>
    /// word文档格式转换，目前支持doc转换到pdf
    /// </summary>
    class Word2pdf
    {
        private  void test()
        {
            ConvertWordToPdf("c:\\aa.docx", "F:\\", "ImageFile", 0, 0);
            Console.WriteLine("完成");
        }

        /// <summary>
        /// 通过第三方破解DLL转换（Aspose.Words.dll）
        /// </summary>
        /// <param name="wordInputPath"></param>
        /// <param name="imageOutputPath"></param>
        /// <param name="imageName"></param>
        /// <param name="startPageNum"></param>
        /// <param name="endPageNum"></param>
        public void ConvertWordToPdf(string wordInputPath, string imageOutputPath,
    string imageName, int startPageNum, int endPageNum)
        {
            try
            {
                // open word file
                Aspose.Words.Document doc = new Aspose.Words.Document(wordInputPath);

                // validate parameter
                if (doc == null) { throw new Exception("Word文件无效或者Word文件被加密！"); }

                if (startPageNum <= 0) { startPageNum = 1; }
                if (endPageNum > doc.PageCount || endPageNum <= 0) { endPageNum = doc.PageCount; }
                if (startPageNum > endPageNum) { int tempPageNum = startPageNum; startPageNum = endPageNum; endPageNum = startPageNum; }

                PdfSaveOptions imageSaveOptions = new PdfSaveOptions();
                // start to convert each page
                //for (int i = startPageNum; i <= endPageNum; i++)
                //{
                //    imageSaveOptions.PageIndex = i - 1;
                //    doc.Save(Path.Combine(imageOutputPath, imageName) + "_" + i.ToString() + ".pdf" , imageSaveOptions);
                //}
                doc.Save("f:\\test.pdf", Aspose.Words.SaveFormat.Pdf);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void test2()
        {
            ConvertWord2PDF("c:\\aa.docx", "f:", "111");
        }

        /// <summary>
        /// 通过office自带接口(需先安装SaveAsPDFandXPS.exe)，此接口仅适用于office2007及以上版本
        /// </summary>
        /// <param name="wordInputPath"></param>
        /// <param name="pdfOutputPath"></param>
        /// <param name="pdfName"></param>
        public void ConvertWord2PDF(string wordInputPath, string pdfOutputPath, string pdfName)
        {
            try
            {
                string pdfExtension = ".pdf";

                // validate patameter
                if (!Directory.Exists(pdfOutputPath)) { Directory.CreateDirectory(pdfOutputPath); }
                if (pdfName.Trim().Length == 0) { pdfName = Path.GetFileNameWithoutExtension(wordInputPath); }
                if (!(Path.GetExtension(pdfName).ToUpper() == pdfExtension.ToUpper())) { pdfName = pdfName + pdfExtension; }

                object paramSourceDocPath = wordInputPath;
                object paramMissing = Type.Missing;

                string paramExportFilePath = Path.Combine(pdfOutputPath, pdfName);

                // create a word application object
                ApplicationClass wordApplication = new ApplicationClass();
                Microsoft.Office.Interop.Word.Document wordDocument = null;

                //set exportformat to pdf 
                WdExportFormat paramExportFormat = WdExportFormat.wdExportFormatPDF;
                bool paramOpenAfterExport = false;
                WdExportOptimizeFor paramExportOptimizeFor = WdExportOptimizeFor.wdExportOptimizeForPrint;
                WdExportRange paramExportRange = WdExportRange.wdExportAllDocument;
                int paramStartPage = 0;
                int paramEndPage = 0;
                WdExportItem paramExportItem = WdExportItem.wdExportDocumentContent;
                bool paramIncludeDocProps = true;
                bool paramKeepIRM = true;
                WdExportCreateBookmarks paramCreateBookmarks = WdExportCreateBookmarks.wdExportCreateWordBookmarks;
                bool paramDocStructureTags = true;
                bool paramBitmapMissingFonts = true;
                bool paramUseISO19005_1 = false;

                try
                {
                    // Open the source document.
                    wordDocument = wordApplication.Documents.Open(
                        ref paramSourceDocPath, ref paramMissing, ref paramMissing,
                        ref paramMissing, ref paramMissing, ref paramMissing,
                        ref paramMissing, ref paramMissing, ref paramMissing,
                        ref paramMissing, ref paramMissing, ref paramMissing,
                        ref paramMissing, ref paramMissing, ref paramMissing,
                        ref paramMissing);

                    // Export it in the specified format.
                    if (wordDocument != null)
                        wordDocument.ExportAsFixedFormat(paramExportFilePath,
                            paramExportFormat, paramOpenAfterExport,
                            paramExportOptimizeFor, paramExportRange, paramStartPage,
                            paramEndPage, paramExportItem, paramIncludeDocProps,
                            paramKeepIRM, paramCreateBookmarks, paramDocStructureTags,
                            paramBitmapMissingFonts, paramUseISO19005_1,
                            ref paramMissing);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    // Close and release the Document object.
                    if (wordDocument != null)
                    {
                        wordDocument.Close(ref paramMissing, ref paramMissing, ref paramMissing);
                        wordDocument = null;
                    }

                    // Quit Word and release the ApplicationClass object.
                    if (wordApplication != null)
                    {
                        wordApplication.Quit(ref paramMissing, ref paramMissing, ref paramMissing);
                        wordApplication = null;
                    }

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
