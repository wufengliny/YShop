using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// UserLike
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表UserLike)
        /// </summary>
        public static Model.UserLike ConvertToUserLike(DataRow dr)
        {
            Model.UserLike model = new Model.UserLike();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.UID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UID"]) ? 0 : int.Parse(dr["UID"].ToString());
            model.GID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["GID"]) ? 0 : int.Parse(dr["GID"].ToString());
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();
            model.Category = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Category"]) ? string.Empty : dr["Category"].ToString();//类型

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表UserLike)
        /// </summary>
        public static Model.UserLike ConvetToUserLike(SqlDataReader reader, string extParam)
        {
            Model.UserLike model = new Model.UserLike();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.UID = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
            model.GID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
            model.AddTime = reader.IsDBNull(3) ? System.DateTime.MinValue : reader.GetDateTime(3);
            model.Enable = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
            model.Name = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
            model.Category = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);//类型

            return model;
        }
        /// <summary>
        /// 增加一条数据(表UserLike)
        /// </summary>
        public int UserLikeAdd(Model.UserLike model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO UserLike(");
            strSql.Append("UID,GID,AddTime,Enable,Name,Category)");
            strSql.Append(" VALUES (");
            strSql.Append("@UID,@GID,@AddTime,@Enable,@Name,@Category)");
            SqlParameter[] parameters = {
                    new SqlParameter("@UID", SqlDbType.Int,4),
                    new SqlParameter("@GID", SqlDbType.Int,4),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Enable", SqlDbType.Int,4),
                    new SqlParameter("@Name", SqlDbType.NVarChar,100),
                    new SqlParameter("@Category", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.GID;
            parameters[2].Value = model.AddTime;
            parameters[3].Value = model.Enable;
            parameters[4].Value = model.Name;
            parameters[5].Value = model.Category;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表UserLike)
        /// </summary>
        public int UserLikeUpdate(Model.UserLike model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE UserLike SET ");
            strSql.Append("UID=@UID,");
            strSql.Append("GID=@GID,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("Name=@Name,");
            strSql.Append("Category=@Category");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@UID", SqlDbType.Int,4),
               new SqlParameter("@GID", SqlDbType.Int,4),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,100),
               new SqlParameter("@Category", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UID;
            parameters[2].Value = model.GID;
            parameters[3].Value = model.AddTime;
            parameters[4].Value = model.Enable;
            parameters[5].Value = model.Name;
            parameters[6].Value = model.Category;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.UserLike GetModelByUserLike(int ID)
        {
            string sql = string.Format("SELECT * FROM UserLike WITH(NOLOCK) WHERE ID={0}", ID);
            Model.UserLike model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.UserLike();
                    }
                    model = ConvetToUserLike(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.UserLike> GetListUserLike(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.UserLike> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "UserLike", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.UserLike>();
                    }
                    list.Add(ConvetToUserLike(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.UserLike> GetPageUserLike(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.UserLike> list = new List<Yax.Model.UserLike>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "UserLike", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToUserLike(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
