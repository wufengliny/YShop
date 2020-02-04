using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// GoodsUrl
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表GoodsUrl)
        /// </summary>
        public static Model.GoodsUrl ConvertToGoodsUrl(DataRow dr)
        {

            Model.GoodsUrl model = new Model.GoodsUrl();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Url = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Url"]) ? string.Empty : dr["Url"].ToString();
            model.UrlSmalll = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UrlSmalll"]) ? string.Empty : dr["UrlSmalll"].ToString();
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.GID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["GID"]) ? 0 : int.Parse(dr["GID"].ToString());

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表GoodsUrl)
        /// </summary>
        public static Model.GoodsUrl ConvetToGoodsUrl(SqlDataReader reader, string extParam)
        {
            Model.GoodsUrl model = new Model.GoodsUrl();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Url = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.UrlSmalll = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            model.Enable = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
            model.GID = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表GoodsUrl)
        /// </summary>
        public int GoodsUrlAdd(Model.GoodsUrl model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO GoodsUrl(");
            strSql.Append("Url,UrlSmalll,Enable,GID)");
            strSql.Append(" VALUES (");
            strSql.Append("@Url,@UrlSmalll,@Enable,@GID)");
            SqlParameter[] parameters = {
		            new SqlParameter("@Url", SqlDbType.NVarChar,500),
		            new SqlParameter("@UrlSmalll", SqlDbType.NVarChar,500),
		            new SqlParameter("@Enable", SqlDbType.Int,4),
		            new SqlParameter("@GID", SqlDbType.Int,4)};
            parameters[0].Value = model.Url;
            parameters[1].Value = model.UrlSmalll;
            parameters[2].Value = model.Enable;
            parameters[3].Value = model.GID;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表GoodsUrl)
        /// </summary>
        public int GoodsUrlUpdate(Model.GoodsUrl model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE GoodsUrl SET ");
            strSql.Append("Url=@Url,");
            strSql.Append("UrlSmalll=@UrlSmalll,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("GID=@GID");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Url", SqlDbType.NVarChar,500),
               new SqlParameter("@UrlSmalll", SqlDbType.NVarChar,500),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@GID", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Url;
            parameters[2].Value = model.UrlSmalll;
            parameters[3].Value = model.Enable;
            parameters[4].Value = model.GID;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        public int GoodsUrlUpdate_enable(Model.GoodsUrl model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE GoodsUrl SET ");
            strSql.Append("Enable=@Enable");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Enable", SqlDbType.Int,4)
              };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Enable;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int GoodsUrlUpdateInfo(Model.GoodsUrl model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE GoodsUrl SET ");
            strSql.Append("Url=@Url,");
            strSql.Append("UrlSmalll=@UrlSmalll");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Url", SqlDbType.NVarChar,500),
               new SqlParameter("@UrlSmalll", SqlDbType.NVarChar,500)
               };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Url;
            parameters[2].Value = model.UrlSmalll;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.GoodsUrl GetModelByGoodsUrl(int ID)
        {
            string sql = string.Format("SELECT * FROM GoodsUrl WITH(NOLOCK) WHERE ID={0}", ID);
            Model.GoodsUrl model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.GoodsUrl();
                    }
                    model = ConvetToGoodsUrl(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.GoodsUrl> GetListGoodsUrl(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.GoodsUrl> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "GoodsUrl", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.GoodsUrl>();
                    }
                    list.Add(ConvetToGoodsUrl(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.GoodsUrl> GetPageGoodsUrl(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.GoodsUrl> list = new List<Yax.Model.GoodsUrl>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "GoodsUrl", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToGoodsUrl(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
