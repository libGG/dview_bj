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
    /// ����ģ�������
    /// </summary>
    public class TempleteMgr
    {
        private SXEQ_JBMB_DAL _JBMB_DAL = new SXEQ_JBMB_DAL();
        #region ����
        /// <summary>
        /// ģ��������ݷ�����
        /// </summary>
        public SXEQ_JBMB_DAL JBMB_DAL
        {
            get { return _JBMB_DAL; }
        }
        #endregion
        /// <summary>
        /// ����ģ��
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
                throw new Exception("��ģ���ĵ���û����ǩ:" + fileName);
            }
            this._JBMB_DAL.Add(model);
        }
        /// <summary>
        /// ����word�ļ�����ʱĿ¼�������ظ��ļ��Ķ�������ʽ
        /// </summary>
        /// <param name="fileName">�ļ�·��</param>
        /// <returns></returns>
        public byte[] SaveWord(string fileName)
        {
            string file_copy = fileName + "_copy";
            File.Copy(fileName, file_copy, true);
            FileStream file = new FileStream(file_copy, FileMode.Open, FileAccess.Read);
            Byte[] imgByte = new Byte[file.Length];//��ͼƬת�� Byte�� ��������  
            file.Read(imgByte, 0, imgByte.Length);//�Ѷ����������뻺����  
            file.Flush();
            file.Close();
            file.Dispose();
            return imgByte;
        }
        /// <summary>
        /// ����ģ��fguid��ȡģ���ļ�
        /// 1����ѯ���ݿ��ȡ��¼
        /// 2����filedoc������ֵת���ɱ����ļ���������ʱĿ¼�У���ʱ��������ļ�
        /// 3�����ظ��ļ���·��
        /// </summary>
        /// <param name="fguid">ģ��fguid</param>
        /// <returns></returns>
        public string GetWord(string fguid,out SXEQ_JBMB model)
        {
            model = this._JBMB_DAL.GetModel(fguid);
            string fileName = System.IO.Path.GetTempPath() + "\\" + DateTime.Now.ToString("yyyy-MM-dd hh-MM-ss") + ".doc";
            System.IO.File.WriteAllBytes(fileName, model.filedoc);
            return fileName;
        }

        /// <summary>
        /// ��ȡword�ĵ�����ǩ
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
            //�ر�Word�ļ�
            object SaveChanges = false; //�������
            object OriginalFormat = System.Type.Missing;
            object RouteDocument = System.Type.Missing;
            //�ر��ĵ�
            oDoc.Close(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
            //�˳�����
            oWord.Quit(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
            //��ȡ����ǩ�󣬰�*_copy��ʱ�ļ�ɾ��
            File.Delete(fileName.ToString());
            return sb.ToString().Trim(';');
        }

        /// <summary>
        /// ɾ��ģ��
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
                throw new Exception("ɾ��ʧ�ܣ�",ex);
            }
        }
    }
}
