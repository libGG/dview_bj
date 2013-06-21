using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Words.Saving;
using System.IO;

namespace Aspose.Word2Image
{
    class word2pdf
    {
        static void Main(string[] args)
        {
            ConvertWordToPdf("c:\\aa.docx", "F:\\", "ImageFile", 0, 0);
            Console.WriteLine("完成");
        }

        public static void ConvertWordToPdf(string wordInputPath, string imageOutputPath,
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

    }
}
