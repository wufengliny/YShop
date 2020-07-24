using CommSQLHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DS_User
    {
        public List<object> Pager(int pageIndex, int pageSize, string strWhere, string strOrder)
        {
            MAspNetPager modelp = new MAspNetPager()
            {
                OrderString = strOrder,
                PageIndex = pageIndex,
                PageSize = pageSize,
                ReFieldsStr = "*",
                TableName = "S_user",
                WhereString = strWhere
            };
            return AspNetPagerList.PagerLsit<MS_User>(modelp);
        }
        public int Add(MS_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO S_User(");
            strSql.Append("GUID,Account,Pwd,LoginCount,RegIP,RegURL,AddTime,RegType,Enable,Memo,ErrorCount,UserType,VIP)");
            strSql.Append(" VALUES (");
            strSql.Append("@GUID,@Account,@Pwd,@LoginCount,@RegIP,@RegURL,@AddTime,@RegType,@Enable,@Memo,@ErrorCount,@UserType,@VIP)");
            SqlParameter[] parameters = {
                    new SqlParameter("@GUID", SqlDbType.NVarChar,100),
                    new SqlParameter("@Account", SqlDbType.NVarChar,100),
                    new SqlParameter("@Pwd", SqlDbType.NVarChar,100),
                    new SqlParameter("@LoginCount", SqlDbType.Int,4),
                    new SqlParameter("@RegIP", SqlDbType.NVarChar,100),
                    new SqlParameter("@RegURL", SqlDbType.NVarChar,100),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@RegType", SqlDbType.Int,4),
                    new SqlParameter("@Enable", SqlDbType.Int,4),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,500),
                    new SqlParameter("@ErrorCount", SqlDbType.Int,4),
                    new SqlParameter("@UserType", SqlDbType.NChar,4),
                    new SqlParameter("@VIP", SqlDbType.Bit,1)};
            parameters[0].Value = model.GUID;
            parameters[1].Value = model.Account;
            parameters[2].Value = model.Pwd;
            parameters[3].Value = model.LoginCount;
            parameters[4].Value = model.RegIP;
            parameters[5].Value = model.RegURL;
            parameters[6].Value = model.AddTime;
            parameters[7].Value = model.RegType;
            parameters[8].Value = model.Enable;
            parameters[9].Value = model.Memo;
            parameters[10].Value = model.ErrorCount;
            parameters[11].Value = model.UserType;
            parameters[12].Value = model.VIP;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }



        public int EditByAdmin(MS_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE S_User SET ");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("Memo=@Memo");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Pwd", SqlDbType.NVarChar,100),
               new SqlParameter("@Memo", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Pwd;
            parameters[2].Value = model.Memo;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int EditPwd(MS_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE S_User SET ");
            strSql.Append("Pwd=@Pwd ");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Pwd", SqlDbType.NVarChar,100)
              };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Pwd;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 禁用 启用
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int UpdateEnable(int ID, int Enable)
        {
            string str = " update S_User set Enable=" + Enable + " where ID=@ID";
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = ID;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, str, param);
        }
        public int UpdateLoginErr(int ID)
        {
            string str = " update S_User set ErrorCount=ErrorCount+1,LastErrTime=GETDATE() where ID=@ID";
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = ID;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, str, param);
        }
        public int UpdateLoginOK(string IP,DateTime dt, int ID)
        {
            string str = "  update S_User set ErrorCount=0,LoginCount=LoginCount+1,LastLoginIP=@LastLoginIP,LastLoginTime=@LastLoginTime where ID=@ID";
            SqlParameter[] parameters = {
                new SqlParameter("@LastLoginIP", SqlDbType.NVarChar,100),
               new SqlParameter("@LastLoginTime", SqlDbType.DateTime,8),
               new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = IP;
            parameters[1].Value = dt;
            parameters[2].Value = ID;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, str, parameters);
        }


        public int VIPLoad(int ID, DateTime endtime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE S_User SET ");
            strSql.Append("VIP=@VIP,");
            strSql.Append("VIPEndTime=@VIPEndTime");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@VIP", SqlDbType.Bit,1),
               new SqlParameter("@VIPEndTime", SqlDbType.DateTime,8)};
            parameters[0].Value =ID;
            parameters[1].Value = true;
            parameters[2].Value = endtime;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public MS_User GetModelByID(int ID)
        {
            string str = "select * from S_user where ID=@ID";
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = ID;
            return SQLHelper.ExecuteReaderObject<MS_User>(CommandType.Text, str, param);
        }
        public MS_User GetModelByAccount(string Account)
        {
            string str = "select * from S_user where Account=@Account";
            SqlParameter param = new SqlParameter("@Account", SqlDbType.NVarChar, 100);
            param.Value = Account;
            return SQLHelper.ExecuteReaderObject<MS_User>(CommandType.Text, str, param);
        }




    }
}
