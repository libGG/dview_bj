//created by lib
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Data;

namespace DView.SXEQJB.TempleteMgr.Dal
{
    /// <summary>
    /// 模板类别表数据访问
    /// </summary>
    public class SXEQ_JBLB_DAL
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(SXEQ_JBLB model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SXEQ_JBLB(");
            strSql.Append("fguid,name,memo)");
            strSql.Append(" values (");
            strSql.Append(":fguid,:name,:memo)");
            OracleParameter[] parameters = {
					new OracleParameter(":fguid", OracleType.VarChar,36),
					new OracleParameter(":name", OracleType.NVarChar,50),
					new OracleParameter(":memo", OracleType.NVarChar,512)};
            parameters[0].Value = model.fguid;
            parameters[1].Value = model.name;
            parameters[2].Value = model.memo;

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
        public bool Update(SXEQ_JBLB model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SXEQ_JBLB set ");
            strSql.Append("name=:name,");
            strSql.Append("memo=:memo");
            strSql.Append(" where fguid=:fguid ");
            OracleParameter[] parameters = {
					new OracleParameter(":name", OracleType.NVarChar,50),
					new OracleParameter(":memo", OracleType.NVarChar,512),
					new OracleParameter(":fguid", OracleType.VarChar,36)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.memo;
            parameters[2].Value = model.fguid;

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
            strSql.Append("delete from SXEQ_JBLB ");
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
        /// 得到一个对象实体
        /// </summary>
        public SXEQ_JBLB GetModel(string fguid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select fguid,name,memo from SXEQ_JBLB ");
            strSql.Append(" where fguid=:fguid ");
            OracleParameter[] parameters = {
					new OracleParameter(":fguid", OracleType.VarChar)			};
            parameters[0].Value = fguid;

            SXEQ_JBLB model = new SXEQ_JBLB();
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
        public SXEQ_JBLB DataRowToModel(DataRow row)
        {
            SXEQ_JBLB model = new SXEQ_JBLB();
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
                if (row["memo"] != null)
                {
                    model.memo = row["memo"].ToString();
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
            strSql.Append("select fguid,name,memo ");
            strSql.Append(" FROM SXEQ_JBLB ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SXEQ_JBLB> GetModelList(string strWhere)
        {
            DataSet ds = GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SXEQ_JBLB> DataTableToList(DataTable dt)
        {
            List<SXEQ_JBLB> modelList = new List<SXEQ_JBLB>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                SXEQ_JBLB model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model =  DataRowToModel(dt.Rows[n]);
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
    /// 模板类别表数据模型
    /// </summary>
    public class SXEQ_JBLB
    {
        public SXEQ_JBLB()
        { }
        #region Model
        private string _fguid;
        private string _name;
        private string _memo;
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
        public string memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        #endregion Model

    }
}
