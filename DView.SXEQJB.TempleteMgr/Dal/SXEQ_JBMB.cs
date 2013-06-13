//created by lib
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using System.Data.OleDb;

namespace DView.SXEQJB.TempleteMgr.Dal
{
    /// <summary>
    /// 模板管理表数据访问
    /// </summary>
    public class SXEQ_JBMB_DAL
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(SXEQ_JBMB model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SXEQ_JBMB(");
            strSql.Append("fguid,name,category,bookmark,author,memo,format,filedoc)");
            strSql.Append(" values (");
            strSql.Append(":fguid,:name,:category,:bookmark,:author,:memo,:format,:filedoc)");
            OracleParameter[] parameters = {
					new OracleParameter(":fguid", OracleType.VarChar,36),
					new OracleParameter(":name", OracleType.NVarChar,50),
					new OracleParameter(":category", OracleType.VarChar,36),
					new OracleParameter(":bookmark", OracleType.NVarChar,512),
					new OracleParameter(":author", OracleType.NVarChar,50),
					new OracleParameter(":memo", OracleType.NVarChar,512),
					new OracleParameter(":format", OracleType.VarChar,50),
                    new OracleParameter(":filedoc", OracleType.Blob)};
            parameters[0].Value = model.fguid;
            parameters[1].Value = model.name;
            parameters[2].Value = model.category;
            parameters[3].Value = model.bookmark;
            parameters[4].Value = model.author;
            parameters[5].Value = model.memo;
            parameters[6].Value = model.format;
            parameters[7].Value = model.filedoc;

            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SXEQ_JBMB model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SXEQ_JBMB set ");
            strSql.Append("name=:name,");
            strSql.Append("filedoc=:filedoc,");
            strSql.Append("category=:category,");
            strSql.Append("bookmark=:bookmark,");
            strSql.Append("author=:author,");
            strSql.Append("memo=:memo,");
            strSql.Append("format=:format");
            strSql.Append(" where fguid=:fguid ");
            OracleParameter[] parameters = {
					new OracleParameter(":fguid", OracleType.VarChar,36),
					new OracleParameter(":name", OracleType.NVarChar,50),
					new OracleParameter(":category", OracleType.VarChar,36),
					new OracleParameter(":bookmark", OracleType.NVarChar,512),
					new OracleParameter(":author", OracleType.NVarChar,50),
					new OracleParameter(":memo", OracleType.NVarChar,512),
					new OracleParameter(":format", OracleType.VarChar,50),
                    new OracleParameter(":filedoc", OracleType.Blob)};
            parameters[0].Value = model.fguid;
            parameters[1].Value = model.name;
            parameters[2].Value = model.category;
            parameters[3].Value = model.bookmark;
            parameters[4].Value = model.author;
            parameters[5].Value = model.memo;
            parameters[6].Value = model.format;
            parameters[7].Value = model.filedoc;

            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string fguid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SXEQ_JBMB ");
            strSql.Append(" where fguid=:fguid ");
            OracleParameter[] parameters = {
					new OracleParameter(":fguid", OracleType.VarChar,36)			};
            parameters[0].Value = fguid;

            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string fguidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SXEQ_JBMB ");
            strSql.Append(" where fguid in (" + fguidlist + ")  ");
            int rows = DbHelperOra.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SXEQ_JBMB GetModel(string fguid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select fguid,name,filedoc,category,bookmark,author,memo,format from SXEQ_JBMB ");
            strSql.Append(" where fguid=:fguid ");
            OracleParameter[] parameters = {
					new OracleParameter(":fguid", OracleType.VarChar,36)			};
            parameters[0].Value = fguid;

            SXEQ_JBMB model = new SXEQ_JBMB();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SXEQ_JBMB DataRowToModel(DataRow row)
        {
            SXEQ_JBMB model = new SXEQ_JBMB();
            if (row != null)
            {
                if (row["fguid"] != null)
                {
                    model.fguid = row["fguid"].ToString();
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["filedoc"] != null && row["filedoc"].ToString() != "")
                {
                    model.filedoc = (byte[])row["filedoc"];
                }
                if (row["category"] != null)
                {
                    model.category = row["category"].ToString();
                }
                if (row["bookmark"] != null)
                {
                    model.bookmark = row["bookmark"].ToString();
                }
                if (row["author"] != null)
                {
                    model.author = row["author"].ToString();
                }
                if (row["memo"] != null)
                {
                    model.memo = row["memo"].ToString();
                }
                if (row["format"] != null)
                {
                    model.format = row["format"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select fguid,Name,filedoc,category,bookmark,author,memo,format ");
            strSql.Append(" FROM SXEQ_JBMB ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SXEQ_JBMB> GetModelList(string strWhere)
        {
            DataSet ds = GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SXEQ_JBMB> DataTableToList(DataTable dt)
        {
            List<SXEQ_JBMB> modelList = new List<SXEQ_JBMB>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                SXEQ_JBMB model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
    }

    /// <summary>
    /// 模板管理表数据模型
    /// </summary>
    public class SXEQ_JBMB
    {
        public SXEQ_JBMB()
        {}
        #region Model
        private string _fguid;
        private string _name;
        private byte[] _filedoc;
        private string _category;
        private string _bookmark;
        private string _author;
        private string _memo;
        private string _format;
        /// <summary>
        /// 
        /// </summary>
        public string fguid
        {
            set { _fguid = value; }
            get { return _fguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] filedoc
        {
            set { _filedoc = value; }
            get { return _filedoc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string category
        {
            set { _category = value; }
            get { return _category; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bookmark
        {
            set { _bookmark = value; }
            get { return _bookmark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string author
        {
            set { _author = value; }
            get { return _author; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string format
        {
            set { _format = value; }
            get { return _format; }
        }
        #endregion Model

    }
}


