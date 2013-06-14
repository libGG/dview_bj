//created by lib
using System;
using System.Collections.Generic;
using System.Text;
using DView.SXEQJB.TempleteMgr.Dal;
using System.IO;
using Microsoft.Office.Interop.Word;

namespace DView.SXEQJB.TempleteMgr
{
    /// <summary>
    /// 报告模板管理类
    /// </summary>
    public class TempleteMgr
    {
        private SXEQ_JBMB_DAL _JBMB_DAL = new SXEQ_JBMB_DAL();
        #region 属性
        /// <summary>
        /// 模板管理数据访问类
        /// </summary>
        public SXEQ_JBMB_DAL JBMB_DAL
        {
            get { return _JBMB_DAL; }
        }
        #endregion
        /// <summary>
        /// 导入模板
        /// </summary>
        public void ImportTemplete(SXEQ_JBMB src,string fileName)
        {
            SXEQ_JBMB model = new SXEQ_JBMB();
            model.author = src.author;
            model.category = src.category;
            model.fguid = src.fguid;
            model.format = src.format;
            model.memo = src.memo;
            model.name = src.name;
            model.filedoc = this.SaveWord(fileName);
            model.bookmark = this.GetBookmark(fileName + "_copy");
            if(string.IsNullOrEmpty(model.bookmark))
            {
                throw new Exception("该模板文档内没有书签:" + fileName);
            }
            this._JBMB_DAL.Add(model);
        }
        /// <summary>
        /// 保存word文件到临时目录，并返回该文件的二进制形式
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <returns></returns>
        public byte[] SaveWord(string fileName)
        {
            string file_copy = fileName + "_copy";
            File.Copy(fileName, file_copy, true);
            FileStream file = new FileStream(file_copy, FileMode.Open, FileAccess.Read);
            Byte[] imgByte = new Byte[file.Length];//把图片转成 Byte型 二进制流  
            file.Read(imgByte, 0, imgByte.Length);//把二进制流读入缓冲区  
            file.Flush();
            file.Close();
            file.Dispose();
            return imgByte;
        }
        /// <summary>
        /// 根据模板fguid获取模板文件
        /// 1，查询数据库获取记录
        /// 2，将filedoc二进制值转换成本地文件，放在临时目录中，以时间戳命名文件
        /// 3，返回该文件的路径
        /// </summary>
        /// <param name="fguid">模板fguid</param>
        /// <returns></returns>
        public string GetWord(string fguid,out SXEQ_JBMB model)
        {
            model = this._JBMB_DAL.GetModel(fguid);
            string fileName = System.IO.Path.GetTempPath() + "\\" + DateTime.Now.ToString("yyyy-MM-dd hh-MM-ss") + ".doc";
            System.IO.File.WriteAllBytes(fileName, model.filedoc);
            return fileName;
        }

        /// <summary>
        /// 获取word文档的书签
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string GetBookmark(object fileName)
        {
            object oMissing = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word._Application oWord;
            Microsoft.Office.Interop.Word._Document oDoc;
            oWord = new Microsoft.Office.Interop.Word.Application();
            oWord.Visible = false;
            oDoc = oWord.Documents.Open(ref fileName,
            ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
            ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
            ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            StringBuilder sb = new StringBuilder();
            foreach (Bookmark var in oDoc.Bookmarks)
            {
                sb.Append(var.Name);
                sb.Append(";");
            }
            //关闭Word文件
            object SaveChanges = false; //保存更改
            object OriginalFormat = System.Type.Missing;
            object RouteDocument = System.Type.Missing;
            //关闭文档
            oDoc.Close(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
            //退出程序
            oWord.Quit(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
            //获取完书签后，把*_copy临时文件删除
            File.Delete(fileName.ToString());
            return sb.ToString().Trim(';');
        }

        /// <summary>
        /// 删除模板
        /// </summary>
        /// <param name="fguid"></param>
        public void DelSXEQ_JBMB(string fguid)
        {
            try
            {
                this._JBMB_DAL.Delete(fguid);
            }
            catch (Exception ex)
            {
                throw new Exception("删除失败！",ex);
            }
        }
    }
}
