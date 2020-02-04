using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// UserLoginIP
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表UserLoginIP)
        /// </summary>
        public static Model.UserLoginIP ConvertToUserLoginIP(DataRow dr)
        {
            Model.UserLoginIP model = new Model.UserLoginIP();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.IP = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IP"]) ? string.Empty : dr["IP"].ToString();
            model.Count = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Count"]) ? 0 : int.Parse(dr["Count"].ToString());
            model.UID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UID"]) ? 0 : int.Parse(dr["UID"].ToString());
            model.Account = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Account"]) ? string.Empty : dr["Account"].ToString();

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表UserLoginIP)
        /// </summary>
        public static Model.UserLoginIP ConvetToUserLoginIP(SqlDataReader reader, string extParam)
        {
            Model.UserLoginIP model = new Model.UserLoginIP();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.IP = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.Count = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
            model.UID = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
            model.Account = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表UserLoginIP)
        /// </summary>
        public int UserLoginIPAdd(Model.UserLoginIP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO UserLoginIP(");
            strSql.Append("IP,Count,UID,Account)");
            strSql.Append(" VALUES (");
            strSql.Append("@IP,@Count,@UID,@Account)");
            SqlParameter[] parameters = {
                    new SqlParameter("@IP", SqlDbType.NVarChar,100),
                    new SqlParameter("@Count", SqlDbType.Int,4),
                    new SqlParameter("@UID", SqlDbType.Int,4),
                    new SqlParameter("@Account", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.IP;
            parameters[1].Value = model.Count;
            parameters[2].Value = model.UID;
            parameters[3].Value = model.Account;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表UserLoginIP)
        /// </summary>
        public int UserLoginIPUpdate(Model.UserLoginIP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE UserLoginIP SET ");
            strSql.Append("IP=@IP,");
            strSql.Append("Count=@Count,");
            strSql.Append("UID=@UID,");
            strSql.Append("Account=@Account");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@IP", SqlDbType.NVarChar,100),
               new SqlParameter("@Count", SqlDbType.Int,4),
               new SqlParameter("@UID", SqlDbType.Int,4),
               new SqlParameter("@Account", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.IP;
            parameters[2].Value = model.Count;
            parameters[3].Value = model.UID;
            parameters[4].Value = model.Account;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.UserLoginIP GetModelByUserLoginIP(int ID)
        {
            string sql = string.Format("SELECT * FROM UserLoginIP WITH(NOLOCK) WHERE ID={0}", ID);
            Model.UserLoginIP model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.UserLoginIP();
                    }
                    model = ConvetToUserLoginIP(reader, "All");
                }
            }
            return model;
        }

        public Model.UserLoginIP GetModelByUserLoginIPBYIP(string  ip,int uid)
        {
            string sql = string.Format("SELECT * FROM UserLoginIP  WHERE IP='{0}' and UID={1}", ip,uid);
            Model.UserLoginIP model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.UserLoginIP();
                    }
                    model = ConvetToUserLoginIP(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.UserLoginIP> GetListUserLoginIP(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.UserLoginIP> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "UserLoginIP", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.UserLoginIP>();
                    }
                    list.Add(ConvetToUserLoginIP(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.UserLoginIP> GetPageUserLoginIP(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.UserLoginIP> list = new List<Yax.Model.UserLoginIP>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "UserLoginIP", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToUserLoginIP(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
