using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
namespace Yax.SQLServerDAL
{
    /// <summary>
    /// Config
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表Config)
        /// </summary>
        public static Model.Config ConvertToConfig(DataRow dr)
        {
            Model.Config model = new Model.Config();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.KeyName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["KeyName"]) ? string.Empty : dr["KeyName"].ToString();
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();
            model.Value = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Value"]) ? string.Empty : dr["Value"].ToString();
            model.GroupName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["GroupName"]) ? string.Empty : dr["GroupName"].ToString();
            model.AddUser = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddUser"]) ? 0 : int.Parse(dr["AddUser"].ToString());
            model.LastModifyUser = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["LastModifyUser"]) ? 0 : int.Parse(dr["LastModifyUser"].ToString());
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.UpdateTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UpdateTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["UpdateTime"].ToString());
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.Sort = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Sort"]) ? 0 : int.Parse(dr["Sort"].ToString());
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表Config)
        /// </summary>
        public static Model.Config ConvetToConfig(SqlDataReader reader, string extParam)
        {
            Model.Config model = new Model.Config();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.KeyName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.Name = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            model.Value = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
            model.GroupName = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
            model.AddUser = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
            model.LastModifyUser = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
            model.AddTime = reader.IsDBNull(7) ? System.DateTime.MinValue : reader.GetDateTime(7);
            model.UpdateTime = reader.IsDBNull(8) ? System.DateTime.MinValue : reader.GetDateTime(8);
            model.Enable = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);
            model.Sort = reader.IsDBNull(10) ? 0 : reader.GetInt32(10);
            model.Memo = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表Config)
        /// </summary>
        public int ConfigAdd(Model.Config model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Config(");
            strSql.Append("KeyName,Name,Value,GroupName,AddUser,LastModifyUser,AddTime,UpdateTime,Enable,Sort,Memo)");
            strSql.Append(" VALUES (");
            strSql.Append("@KeyName,@Name,@Value,@GroupName,@AddUser,@LastModifyUser,@AddTime,@UpdateTime,@Enable,@Sort,@Memo)");
            SqlParameter[] parameters = {
		            new SqlParameter("@KeyName", SqlDbType.NVarChar,100),
		            new SqlParameter("@Name", SqlDbType.NVarChar,100),
		            new SqlParameter("@Value", SqlDbType.NVarChar,4000),
		            new SqlParameter("@GroupName", SqlDbType.NVarChar,100),
		            new SqlParameter("@AddUser", SqlDbType.Int,4),
		            new SqlParameter("@LastModifyUser", SqlDbType.Int,4),
		            new SqlParameter("@AddTime", SqlDbType.DateTime,8),
		            new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
		            new SqlParameter("@Enable", SqlDbType.Int,4),
		            new SqlParameter("@Sort", SqlDbType.Int,4),
		            new SqlParameter("@Memo", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.KeyName;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Value;
            parameters[3].Value = model.GroupName;
            parameters[4].Value = model.AddUser;
            parameters[5].Value = model.LastModifyUser;
            parameters[6].Value = model.AddTime;
            parameters[7].Value = model.UpdateTime;
            parameters[8].Value = model.Enable;
            parameters[9].Value = model.Sort;
            parameters[10].Value = model.Memo;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表Config)
        /// </summary>
        public int ConfigUpdate(Model.Config model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Config SET ");
            strSql.Append("KeyName=@KeyName,");
            strSql.Append("Name=@Name,");
            strSql.Append("Value=@Value,");
            strSql.Append("GroupName=@GroupName,");
            strSql.Append("AddUser=@AddUser,");
            strSql.Append("LastModifyUser=@LastModifyUser,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("Memo=@Memo");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@KeyName", SqlDbType.NVarChar,100),
               new SqlParameter("@Name", SqlDbType.NVarChar,100),
               new SqlParameter("@Value", SqlDbType.NVarChar,4000),
               new SqlParameter("@GroupName", SqlDbType.NVarChar,100),
               new SqlParameter("@AddUser", SqlDbType.Int,4),
               new SqlParameter("@LastModifyUser", SqlDbType.Int,4),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@Sort", SqlDbType.Int,4),
               new SqlParameter("@Memo", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.KeyName;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Value;
            parameters[4].Value = model.GroupName;
            parameters[5].Value = model.AddUser;
            parameters[6].Value = model.LastModifyUser;
            parameters[7].Value = model.AddTime;
            parameters[8].Value = model.UpdateTime;
            parameters[9].Value = model.Enable;
            parameters[10].Value = model.Sort;
            parameters[11].Value = model.Memo;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int ConfigUpdate_enable(Model.Config model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Config SET ");
            strSql.Append("Enable=@Enable ");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Enable", SqlDbType.Int,4)
              };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Enable;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int ConfigUpdateInfo(Model.Config model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Config SET ");
            strSql.Append("Value=@Value,");
            strSql.Append("LastModifyUser=@LastModifyUser,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("Name=@Name");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Value", SqlDbType.NVarChar,4000),
               new SqlParameter("@LastModifyUser", SqlDbType.Int,4),
               new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
               new SqlParameter("@Memo", SqlDbType.NVarChar,500),
                   new SqlParameter("@Sort", SqlDbType.Int,4),
             new SqlParameter("@Name", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Value;
            parameters[2].Value = model.LastModifyUser;
            parameters[3].Value = model.UpdateTime;
            parameters[4].Value = model.Memo;
            parameters[5].Value = model.Sort;
            parameters[6].Value = model.Name;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        public int ConfigUpdateValue(Model.Config model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Config SET ");
            strSql.Append("Value=@Value");
            strSql.Append(" WHERE KeyName=@KeyName");
            SqlParameter[] parameters = {
                new SqlParameter("@KeyName", SqlDbType.NVarChar,100),
               new SqlParameter("@Value", SqlDbType.NVarChar,4000)
             };
            parameters[0].Value = model.KeyName;
            parameters[1].Value = model.Value;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.Config GetModelByConfig(int ID)
        {
            string sql = string.Format("SELECT * FROM Config WITH(NOLOCK) WHERE ID={0}", ID);
            Model.Config model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.Config();
                    }
                    model = ConvetToConfig(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Config> GetListConfig(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.Config> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "Config", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.Config>();
                    }
                    list.Add(ConvetToConfig(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 缓存中获取
        /// </summary>
        /// <param name="keyname"></param>
        /// <returns></returns>
        public Model.Config GetListConfig_cache_bykey(string keyname)
        {
            Model.Config model=null;
            List<Model.Config> list;
            object obj = Yax.Common.DataCache.GetCache("configlist");
            if(obj==null)
            {
                int totalnum = 0;
                list = GetPageConfig(1, 1000, "Enable=1", "id desc", "*", out totalnum);
                Yax.Common.DataCache.SetCache("configlist", list);
            }
            else
            {
                list = (List<Model.Config>)obj;
            }
            if(list.Count>0)
            {
                model= list.Where(p => p.KeyName == keyname).FirstOrDefault();
            }
            return model;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.Config> GetPageConfig(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.Config> list = new List<Yax.Model.Config>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "Config", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToConfig(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
