using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// AdminGroup
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表AdminGroup)
        /// </summary>
        public static Model.AdminGroup ConvertToAdminGroup(DataRow dr)
        {
            Model.AdminGroup model = new Model.AdminGroup();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表AdminGroup)
        /// </summary>
        public static Model.AdminGroup ConvetToAdminGroup(SqlDataReader reader, string extParam)
        {
            Model.AdminGroup model = new Model.AdminGroup();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.AddTime = reader.IsDBNull(2) ? System.DateTime.MinValue : reader.GetDateTime(2);
            model.Enable = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
            model.Memo = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表AdminGroup)
        /// </summary>
        public int AdminGroupAdd(Model.AdminGroup model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO AdminGroup(");
            strSql.Append("Name,AddTime,Enable,Memo)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@AddTime,@Enable,@Memo)");
            SqlParameter[] parameters = {
		            new SqlParameter("@Name", SqlDbType.NVarChar,100),
		            new SqlParameter("@AddTime", SqlDbType.DateTime,8),
		            new SqlParameter("@Enable", SqlDbType.Int,4),
		            new SqlParameter("@Memo", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.AddTime;
            parameters[2].Value = model.Enable;
            parameters[3].Value = model.Memo;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表AdminGroup)
        /// </summary>
        public int AdminGroupUpdate(Model.AdminGroup model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE AdminGroup SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("Memo=@Memo");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,100),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@Memo", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.AddTime;
            parameters[3].Value = model.Enable;
            parameters[4].Value = model.Memo;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        /// <summary>
        /// 修改数据(表AdminGroup)
        /// </summary>
        public int AdminGroupUpdate_Name(Model.AdminGroup model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE AdminGroup SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("Memo=@Memo");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,100),
               new SqlParameter("@Memo", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Memo;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.AdminGroup GetModelByAdminGroup(int ID)
        {
            string sql = string.Format("SELECT * FROM AdminGroup WITH(NOLOCK) WHERE ID={0}", ID);
            Model.AdminGroup model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.AdminGroup();
                    }
                    model = ConvetToAdminGroup(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.AdminGroup> GetListAdminGroup(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.AdminGroup> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "AdminGroup", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.AdminGroup>();
                    }
                    list.Add(ConvetToAdminGroup(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.AdminGroup> GetPageAdminGroup(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.AdminGroup> list = new List<Yax.Model.AdminGroup>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "AdminGroup", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToAdminGroup(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
