using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// Chat_msg
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表Chat_msg)
        /// </summary>
        public static Model.Chat_msg ConvertToChat_msg(DataRow dr)
        {
            Model.Chat_msg model = new Model.Chat_msg();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.FromID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["FromID"]) ? 0 : int.Parse(dr["FromID"].ToString());
            model.Path = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Path"]) ? string.Empty : dr["Path"].ToString();
            model.msg = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["msg"]) ? string.Empty : dr["msg"].ToString();
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表Chat_msg)
        /// </summary>
        public static Model.Chat_msg ConvetToChat_msg(SqlDataReader reader, string extParam)
        {
            Model.Chat_msg model = new Model.Chat_msg();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.FromID = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
            model.Path = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            model.msg = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
            model.AddTime = reader.IsDBNull(4) ? System.DateTime.MinValue : reader.GetDateTime(4);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表Chat_msg)
        /// </summary>
        public int Chat_msgAdd(Model.Chat_msg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Chat_msg(");
            strSql.Append("FromID,Path,msg,AddTime)");
            strSql.Append(" VALUES (");
            strSql.Append("@FromID,@Path,@msg,@AddTime)");
            SqlParameter[] parameters = {
                    new SqlParameter("@FromID", SqlDbType.Int,4),
                    new SqlParameter("@Path", SqlDbType.NVarChar,500),
                    new SqlParameter("@msg", SqlDbType.NVarChar,1000),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8)};
            parameters[0].Value = model.FromID;
            parameters[1].Value = model.Path;
            parameters[2].Value = model.msg;
            parameters[3].Value = model.AddTime;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表Chat_msg)
        /// </summary>
        public int Chat_msgUpdate(Model.Chat_msg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Chat_msg SET ");
            strSql.Append("FromID=@FromID,");
            strSql.Append("Path=@Path,");
            strSql.Append("msg=@msg,");
            strSql.Append("AddTime=@AddTime");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@FromID", SqlDbType.Int,4),
               new SqlParameter("@Path", SqlDbType.NVarChar,500),
               new SqlParameter("@msg", SqlDbType.NVarChar,1000),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.FromID;
            parameters[2].Value = model.Path;
            parameters[3].Value = model.msg;
            parameters[4].Value = model.AddTime;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.Chat_msg GetModelByChat_msg(int ID)
        {
            string sql = string.Format("SELECT * FROM Chat_msg WITH(NOLOCK) WHERE ID={0}", ID);
            Model.Chat_msg model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.Chat_msg();
                    }
                    model = ConvetToChat_msg(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Chat_msg> GetListChat_msg(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.Chat_msg> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "Chat_msg", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.Chat_msg>();
                    }
                    list.Add(ConvetToChat_msg(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.Chat_msg> GetPageChat_msg(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.Chat_msg> list = new List<Yax.Model.Chat_msg>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "Chat_msg", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToChat_msg(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
