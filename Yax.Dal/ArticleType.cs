using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// ArticleType
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表ArticleType)
        /// </summary>
        public static Model.ArticleType ConvertToArticleType(DataRow dr)
        {
            Model.ArticleType model = new Model.ArticleType();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();
            model.Addtime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Addtime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["Addtime"].ToString());
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表ArticleType)
        /// </summary>
        public static Model.ArticleType ConvetToArticleType(SqlDataReader reader, string extParam)
        {
            Model.ArticleType model = new Model.ArticleType();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.Addtime = reader.IsDBNull(2) ? System.DateTime.MinValue : reader.GetDateTime(2);
            model.Enable = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表ArticleType)
        /// </summary>
        public int ArticleTypeAdd(Model.ArticleType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO ArticleType(");
            strSql.Append("Name,Addtime,Enable)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@Addtime,@Enable)");
            SqlParameter[] parameters = {
		            new SqlParameter("@Name", SqlDbType.NVarChar,100),
		            new SqlParameter("@Addtime", SqlDbType.DateTime,8),
		            new SqlParameter("@Enable", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Addtime;
            parameters[2].Value = model.Enable;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表ArticleType)
        /// </summary>
        public int ArticleTypeUpdate(Model.ArticleType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE ArticleType SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("Addtime=@Addtime,");
            strSql.Append("Enable=@Enable");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,100),
               new SqlParameter("@Addtime", SqlDbType.DateTime,8),
               new SqlParameter("@Enable", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Addtime;
            parameters[3].Value = model.Enable;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int ArticleTypeUpdateEnable(Model.ArticleType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE ArticleType SET ");
            strSql.Append("Enable=@Enable");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Enable", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Enable;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int ArticleTypeUpdateName(Model.ArticleType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE ArticleType SET ");
            strSql.Append("Name=@Name");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,100),
               };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.ArticleType GetModelByArticleType(int ID)
        {
            string sql = string.Format("SELECT * FROM ArticleType WITH(NOLOCK) WHERE ID={0}", ID);
            Model.ArticleType model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.ArticleType();
                    }
                    model = ConvetToArticleType(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.ArticleType> GetListArticleType(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.ArticleType> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "ArticleType", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.ArticleType>();
                    }
                    list.Add(ConvetToArticleType(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.ArticleType> GetPageArticleType(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.ArticleType> list = new List<Yax.Model.ArticleType>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "ArticleType", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToArticleType(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
