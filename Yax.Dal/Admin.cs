using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// Admin
    /// </summary>
    public partial class DataProvider
    {

        /// <summary>
        /// 数据转换成实体(表Admin)
        /// </summary>
        public static Model.Admin ConvertToAdmin(DataRow dr,string view="table")
        {
            Model.Admin model = new Model.Admin();
            model.ID =Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();
            model.Pwd = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Pwd"]) ? string.Empty : dr["Pwd"].ToString();
            model.LastLoginTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["LastLoginTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["LastLoginTime"].ToString());
            model.LastLoginIP = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["LastLoginIP"]) ? string.Empty : dr["LastLoginIP"].ToString();
            model.LoginCount = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["LoginCount"]) ? 0 : int.Parse(dr["LoginCount"].ToString());
            model.RegIP = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["RegIP"]) ? string.Empty : dr["RegIP"].ToString();
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.UpdateTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UpdateTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["UpdateTime"].ToString());
            model.Effect = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Effect"]) ? 0 : int.Parse(dr["Effect"].ToString());
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();
            model.ErrorCount = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ErrorCount"]) ? 0 : int.Parse(dr["ErrorCount"].ToString());
            model.LastErrTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["LastErrTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["LastErrTime"].ToString()); //上一次输入密码错误时间
            model.RealName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["RealName"]) ? string.Empty : dr["RealName"].ToString();//真实姓名
            model.Phone = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Phone"]) ? string.Empty : dr["Phone"].ToString();
            model.KGroup = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["KGroup"]) ? 0 : int.Parse(dr["KGroup"].ToString());//管理员所在的组
            model.SecondPwd = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["SecondPwd"]) ? string.Empty : dr["SecondPwd"].ToString();
            return model;
        }

        /// <summary>
        /// 数据转换成实体(表Admin)
        /// </summary>
        public static Model.Admin ConvetToAdmin(SqlDataReader reader, string extParam)
        {
            Model.Admin model = new Model.Admin();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.Pwd = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            model.LastLoginTime = reader.IsDBNull(3) ? System.DateTime.MinValue : reader.GetDateTime(3);
            model.LastLoginIP = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
            model.LoginCount = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
            model.RegIP = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
            model.AddTime = reader.IsDBNull(7) ? System.DateTime.MinValue : reader.GetDateTime(7);
            model.UpdateTime = reader.IsDBNull(8) ? System.DateTime.MinValue : reader.GetDateTime(8);
            model.Effect = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);
            model.Memo = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
            model.ErrorCount = reader.IsDBNull(11) ? 0 : reader.GetInt32(11);
            model.LastErrTime = reader.IsDBNull(12) ? System.DateTime.MinValue : reader.GetDateTime(12);//上一次输入密码错误时间
            model.RealName = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);//真实姓名
            model.Phone = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);
            model.KGroup = reader.IsDBNull(15) ? 0 : reader.GetInt32(15);//管理员所在的组
            model.SecondPwd = reader.IsDBNull(16) ? string.Empty : reader.GetString(16);
            return model;
        }
        /// <summary>
        /// 增加一条数据(表Admin)
        /// </summary>
        public int AdminAdd(Model.Admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Admin(");
            strSql.Append("Name,Pwd,LastLoginTime,LastLoginIP,LoginCount,RegIP,AddTime,UpdateTime,Effect,Memo,ErrorCount,LastErrTime,RealName,Phone,KGroup,SecondPwd)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@Pwd,@LastLoginTime,@LastLoginIP,@LoginCount,@RegIP,@AddTime,@UpdateTime,@Effect,@Memo,@ErrorCount,@LastErrTime,@RealName,@Phone,@KGroup,@SecondPwd)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,100),
                    new SqlParameter("@Pwd", SqlDbType.NVarChar,500),
                    new SqlParameter("@LastLoginTime", SqlDbType.DateTime,8),
                    new SqlParameter("@LastLoginIP", SqlDbType.NVarChar,100),
                    new SqlParameter("@LoginCount", SqlDbType.Int,4),
                    new SqlParameter("@RegIP", SqlDbType.NVarChar,100),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Effect", SqlDbType.Int,4),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
                    new SqlParameter("@ErrorCount", SqlDbType.Int,4),
                    new SqlParameter("@LastErrTime", SqlDbType.DateTime,8),
                    new SqlParameter("@RealName", SqlDbType.NVarChar,100),
                    new SqlParameter("@Phone", SqlDbType.NVarChar,100),
                    new SqlParameter("@KGroup", SqlDbType.Int,4),
                    new SqlParameter("@SecondPwd", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Pwd;
            parameters[2].Value = model.LastLoginTime;
            parameters[3].Value = model.LastLoginIP;
            parameters[4].Value = model.LoginCount;
            parameters[5].Value = model.RegIP;
            parameters[6].Value = model.AddTime;
            parameters[7].Value = model.UpdateTime;
            parameters[8].Value = model.Effect;
            parameters[9].Value = model.Memo;
            parameters[10].Value = model.ErrorCount;
            parameters[11].Value = model.LastErrTime;
            parameters[12].Value = model.RealName;
            parameters[13].Value = model.Phone;
            parameters[14].Value = model.KGroup;
            parameters[15].Value = model.SecondPwd;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表Admin)
        /// </summary>
        public int AdminUpdate(Model.Admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Admin SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("LastLoginTime=@LastLoginTime,");
            strSql.Append("LastLoginIP=@LastLoginIP,");
            strSql.Append("LoginCount=@LoginCount,");
            strSql.Append("RegIP=@RegIP,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("Effect=@Effect,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("ErrorCount=@ErrorCount,");
            strSql.Append("LastErrTime=@LastErrTime,");
            strSql.Append("RealName=@RealName,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("KGroup=@KGroup,");
            strSql.Append("SecondPwd=@SecondPwd");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,100),
               new SqlParameter("@Pwd", SqlDbType.NVarChar,500),
               new SqlParameter("@LastLoginTime", SqlDbType.DateTime,8),
               new SqlParameter("@LastLoginIP", SqlDbType.NVarChar,100),
               new SqlParameter("@LoginCount", SqlDbType.Int,4),
               new SqlParameter("@RegIP", SqlDbType.NVarChar,100),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
               new SqlParameter("@Effect", SqlDbType.Int,4),
               new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
               new SqlParameter("@ErrorCount", SqlDbType.Int,4),
               new SqlParameter("@LastErrTime", SqlDbType.DateTime,8),
               new SqlParameter("@RealName", SqlDbType.NVarChar,100),
               new SqlParameter("@Phone", SqlDbType.NVarChar,100),
               new SqlParameter("@KGroup", SqlDbType.Int,4),
               new SqlParameter("@SecondPwd", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Pwd;
            parameters[3].Value = model.LastLoginTime;
            parameters[4].Value = model.LastLoginIP;
            parameters[5].Value = model.LoginCount;
            parameters[6].Value = model.RegIP;
            parameters[7].Value = model.AddTime;
            parameters[8].Value = model.UpdateTime;
            parameters[9].Value = model.Effect;
            parameters[10].Value = model.Memo;
            parameters[11].Value = model.ErrorCount;
            parameters[12].Value = model.LastErrTime;
            parameters[13].Value = model.RealName;
            parameters[14].Value = model.Phone;
            parameters[15].Value = model.KGroup;
            parameters[16].Value = model.SecondPwd;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int AdminUpdatePWD(Model.Admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Admin set ");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("UpdateTime=@UpdateTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
		            new SqlParameter("@ID", SqlDbType.Int,4),
		            new SqlParameter("@Pwd", SqlDbType.NVarChar,500),
		            new SqlParameter("@UpdateTime", SqlDbType.DateTime,8)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Pwd;
            parameters[2].Value = DateTime.Now;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int AdminUpdateSecondPWD(Model.Admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Admin set ");
            strSql.Append("SecondPwd=@SecondPwd,");
            strSql.Append("UpdateTime=@UpdateTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@SecondPwd", SqlDbType.NVarChar,500),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime,8)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SecondPwd;
            parameters[2].Value = DateTime.Now;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int AdminUpdate_info(Model.Admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Admin SET ");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("RealName=@RealName,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("KGroup=@KGroup");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Pwd", SqlDbType.NVarChar,500),
               new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
               new SqlParameter("@Effect", SqlDbType.Int,4),
               new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
               new SqlParameter("@RealName", SqlDbType.NVarChar,100),
                   new SqlParameter("@KGroup", SqlDbType.Int,100),
               new SqlParameter("@Phone", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Pwd;
            parameters[2].Value = model.UpdateTime;
            parameters[3].Value = model.Effect;
            parameters[4].Value = model.Memo;
            parameters[5].Value = model.RealName;
            parameters[6].Value = model.KGroup;
            parameters[7].Value = model.Phone;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int AdminUpdateErr(Model.Admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Admin set ");
            strSql.Append("ErrorCount=@ErrorCount,");
            strSql.Append("LastErrTime=@LastErrTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
		            new SqlParameter("@ID", SqlDbType.Int,4),
		            new SqlParameter("@ErrorCount", SqlDbType.Int,4),
		            new SqlParameter("@LastErrTime", SqlDbType.DateTime,8)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ErrorCount;
            parameters[2].Value = model.LastErrTime;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int AdminUpdateEnable(int id,int effect)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Admin set ");
            strSql.Append("Effect=@Effect");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
		            new SqlParameter("@ID", SqlDbType.Int,4),
		            new SqlParameter("@Effect", SqlDbType.Int,8)};
            parameters[0].Value =id;
            parameters[1].Value = effect;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.Admin GetModelByAdmin(int ID)
        {
            string sql = string.Format("SELECT * FROM Admin WITH(NOLOCK) WHERE ID={0}", ID);
            Model.Admin model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.Admin();
                    }
                    model = ConvetToAdmin(reader, "All");
                }
            }
            return model;
        }
        public Model.Admin GetModelByAdminName(string name)
        {
            string sql = string.Format("SELECT * FROM Admin WITH(NOLOCK) WHERE name='{0}' and effect=1", name);
            Model.Admin model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.Admin();
                    }
                    model = ConvetToAdmin(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Admin> GetListAdmin(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.Admin> list = null;
            using (SqlDataReader reader =Yax.SqlHelper.DBHelper.GetList(top, fldName, "Admin", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.Admin>();
                    }
                    list.Add(ConvetToAdmin(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.Admin> GetPageAdmin(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.Admin> list = new List<Yax.Model.Admin>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "Admin", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToAdmin(dt.Rows[i]));
                }
            }
            return list;
        }


        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public DataTable GetPageAdmin_view(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.Admin> list = new List<Yax.Model.Admin>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "View_Admin", out TotalRecord);
            return dt;
        }



    
    }
}
