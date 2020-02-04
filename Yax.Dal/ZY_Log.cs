using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// ZY_Log
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表ZY_Log)
        /// </summary>
        public static Model.ZY_Log ConvetToZY_Log(SqlDataReader reader, string extParam)
        {
            Model.ZY_Log model = new Model.ZY_Log();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Type = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);//0 :登录日志  2：操作日志 3：错误日志
            model.Browser = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            model.Url = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
            model.IP = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
            model.UserID = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
            model.Addtime = reader.IsDBNull(6) ? System.DateTime.MinValue : reader.GetDateTime(6);
            model.Message = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
            model.UserName = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
            return model;
        }




        /// <summary>
        /// 数据转换成实体(表ZY_Log)
        /// </summary>
        public static Model.ZY_Log ConvertToZY_Log(DataRow dr)
        {
            Model.ZY_Log model = new Model.ZY_Log();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Type = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Type"]) ? 0 : int.Parse(dr["Type"].ToString());//0 :登录日志  1：操作日志2：系统日志
            model.Browser = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Browser"]) ? string.Empty : dr["Browser"].ToString();
            model.Url = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Url"]) ? string.Empty : dr["Url"].ToString();
            model.IP = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IP"]) ? string.Empty : dr["IP"].ToString();
            model.UserID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UserID"]) ? 0 : int.Parse(dr["UserID"].ToString());
            model.Addtime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Addtime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["Addtime"].ToString());
            model.Message = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Message"]) ? string.Empty : dr["Message"].ToString();
            model.UserName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UserName"]) ? string.Empty : dr["UserName"].ToString();

            return model;
        }
        /// <summary>
        /// 增加一条数据(表ZY_Log)
        /// </summary>
        public int ZY_LogAdd(Model.ZY_Log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO ZY_Log(");
            strSql.Append("Type,Browser,Url,IP,UserID,Addtime,Message,UserName)");
            strSql.Append(" VALUES (");
            strSql.Append("@Type,@Browser,@Url,@IP,@UserID,@Addtime,@Message,@UserName)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Type", SqlDbType.Int,4),
                    new SqlParameter("@Browser", SqlDbType.VarChar,100),
                    new SqlParameter("@Url", SqlDbType.NVarChar,1000),
                    new SqlParameter("@IP", SqlDbType.NVarChar,100),
                    new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@Addtime", SqlDbType.DateTime,8),
                    new SqlParameter("@Message", SqlDbType.NVarChar,-1),
             new SqlParameter("@UserName", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.Type;
            parameters[1].Value = model.Browser;
            parameters[2].Value = model.Url;
            parameters[3].Value = model.IP;
            parameters[4].Value = model.UserID;
            parameters[5].Value = model.Addtime;
            parameters[6].Value = model.Message;
            parameters[7].Value = model.UserName;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表ZY_Log)
        /// </summary>
        public int ZY_LogUpdate(Model.ZY_Log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE ZY_Log SET ");
            strSql.Append("Type=@Type,");
            strSql.Append("Browser=@Browser,");
            strSql.Append("Url=@Url,");
            strSql.Append("IP=@IP,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("Addtime=@Addtime,");
            strSql.Append("Message=@Message");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Type", SqlDbType.Int,4),
               new SqlParameter("@Browser", SqlDbType.VarChar,50),
               new SqlParameter("@Url", SqlDbType.NVarChar,1000),
               new SqlParameter("@IP", SqlDbType.NVarChar,100),
               new SqlParameter("@UserID", SqlDbType.Int,4),
               new SqlParameter("@Addtime", SqlDbType.DateTime,8),
               new SqlParameter("@Message", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Type;
            parameters[2].Value = model.Browser;
            parameters[3].Value = model.Url;
            parameters[4].Value = model.IP;
            parameters[5].Value = model.UserID;
            parameters[6].Value = model.Addtime;
            parameters[7].Value = model.Message;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.ZY_Log GetModelByZY_Log(int ID)
        {
            string sql = string.Format("SELECT * FROM ZY_Log WITH(NOLOCK) WHERE ID={0}", ID);
            Model.ZY_Log model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.ZY_Log();
                    }
                    model = ConvetToZY_Log(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.ZY_Log> GetListZY_Log(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.ZY_Log> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "ZY_Log", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.ZY_Log>();
                    }
                    list.Add(ConvetToZY_Log(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总页数，总记录数
        /// </summary>
        public List<Model.ZY_Log> GetListZY_LogByPage(string fldName, string tblName, string strWhere, string fldSort, int sortType, int pageSize, int currentPage, out int totalRecords, out int totalPages)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@TableName", SqlDbType.VarChar  ,200),
                    new SqlParameter("@FieldList", SqlDbType.VarChar , 2000),
                    new SqlParameter("@PrimaryKey",SqlDbType .VarChar ,100),
                    new SqlParameter("@Where", SqlDbType.VarChar ,2000),
                    new SqlParameter("@Order", SqlDbType.VarChar  ,1000),
                    new SqlParameter("@SortType", SqlDbType.Int),
                    new SqlParameter("@RecorderCount", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int)};
            parameters[0].Value = tblName;//表名
            parameters[1].Value = fldName;//显示列名，如果是全部字段则为*
            parameters[2].Value = "ID";//单一主键或唯一值键
            parameters[3].Value = strWhere;//查询条件 不含'where'字符，如id>10 and len(userid)>9  
            parameters[4].Value = fldSort;//排序 不含'order by'字符，如id asc,userid desc，必须指定asc或desc
            parameters[5].Value = sortType;//排序规则 1:正序asc 2:倒序desc 3:多列排序方法,注意当@SortType=3时生效，记住一定要在最后加上主键，否则会让你比较郁闷
            parameters[6].Value = 0;//记录总数 0:会返回总记录
            parameters[7].Value = pageSize;//每页输出的记录数
            parameters[8].Value = currentPage;//当前页数 

            List<Model.ZY_Log> list = null;
            totalPages = 0;
            totalRecords = 0;

            using (SqlDataReader reader =Yax.SqlHelper.SQLExecute.ExecuteReader("GetListByPage", parameters))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.ZY_Log>();
                    }

                    list.Add(ConvetToZY_Log(reader, "All"));
                }

                if (reader.NextResult())
                {
                    if (reader.Read())
                    {
                        totalPages = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    }
                }
                if (reader.NextResult())
                {
                    if (reader.Read())
                    {
                        totalRecords = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    }
                }

                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.ZY_Log> GetPageZY_Log(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.ZY_Log> list = new List<Yax.Model.ZY_Log>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "ZY_Log", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToZY_Log(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
