using CommSQLHelper;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity.ModelView;

namespace DAL
{
    public class DS_Admin
    {
        public List<object> Pager(int pageIndex,int pageSize, string strWhere, string strOrder)
        {
            string str = " select  sa.*,sg.Name groupName from S_Admin sa left join S_AdminGroup sg on sa.AdminGroupID=sg.ID ";
            str += strWhere ;
            MAspNetPager modelp = new MAspNetPager()
            {
                OrderString = strOrder,
                PageIndex = pageIndex,
                PageSize = pageSize,
                ReFieldsStr = "*",
                TableName = "("+str+ ") as admintable ",
            };
            return AspNetPagerList.PagerLsit<S_AdminViewModel>(modelp);
        }

        public MS_Admin GetModelByID(int ID)
        {
            string str = "select * from S_Admin where ID=@ID";
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = ID;
            return SQLHelper.ExecuteReaderObject<MS_Admin>(CommandType.Text, str, param);
        }
        public MS_Admin GetModelByGUID(string GUID)
        {
            string str = "select * from S_Admin where GUID=@GUID";
            SqlParameter param = new SqlParameter("@GUID", SqlDbType.NVarChar, 100);
            param.Value = GUID;
            return SQLHelper.ExecuteReaderObject<MS_Admin>(CommandType.Text, str, param);
        }
        public MS_Admin GetModelByName(string Name)
        {
            string str = "select * from S_Admin where Name=@Name";
            SqlParameter param = new SqlParameter("@Name", SqlDbType.NVarChar, 20);
            param.Value = Name;
            return SQLHelper.ExecuteReaderObject<MS_Admin>(CommandType.Text, str, param);
        }
        public int Add(MS_Admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO S_Admin(");
            strSql.Append("Name,Pwd,LastLoginIP,LoginCount,RegIP,AddTime,UpdateTime,Enable,Memo,ErrorCount,RealName,Phone,AdminGroupID,SecondPwd,GUID)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@Pwd,@LastLoginIP,@LoginCount,@RegIP,@AddTime,@UpdateTime,@Enable,@Memo,@ErrorCount,@RealName,@Phone,@AdminGroupID,@SecondPwd,@GUID)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,20),
                    new SqlParameter("@Pwd", SqlDbType.NVarChar,64),
                    new SqlParameter("@LastLoginIP", SqlDbType.NVarChar,32),
                    new SqlParameter("@LoginCount", SqlDbType.Int,4),
                    new SqlParameter("@RegIP", SqlDbType.NVarChar,32),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Enable", SqlDbType.Bit,1),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,500),
                    new SqlParameter("@ErrorCount", SqlDbType.Int,4),
                    new SqlParameter("@RealName", SqlDbType.NVarChar,20),
                    new SqlParameter("@Phone", SqlDbType.NVarChar,22),
                    new SqlParameter("@AdminGroupID", SqlDbType.Int,4),
                    new SqlParameter("@SecondPwd", SqlDbType.NVarChar,64),
             new SqlParameter("@GUID", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Pwd;
            parameters[2].Value = model.LastLoginIP;
            parameters[3].Value = model.LoginCount;
            parameters[4].Value = model.RegIP;
            parameters[5].Value = model.AddTime;
            parameters[6].Value = model.UpdateTime;
            parameters[7].Value = model.Enable;
            parameters[8].Value = model.Memo;
            parameters[9].Value = model.ErrorCount;
            parameters[10].Value = model.RealName;
            parameters[11].Value = model.Phone;
            parameters[12].Value = model.AdminGroupID;
            parameters[13].Value = model.SecondPwd;
            parameters[14].Value = model.GUID;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        public int Update(MS_Admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE S_Admin SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("RealName=@RealName,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("AdminGroupID=@AdminGroupID ");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,20),
               new SqlParameter("@Pwd", SqlDbType.NVarChar,64),
               new SqlParameter("@Memo", SqlDbType.NVarChar,500),
               new SqlParameter("@RealName", SqlDbType.NVarChar,20),
               new SqlParameter("@Phone", SqlDbType.NVarChar,22),
               new SqlParameter("@AdminGroupID", SqlDbType.Int,4)
             };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Pwd;
            parameters[3].Value = model.Memo;
            parameters[4].Value = model.RealName;
            parameters[5].Value = model.Phone;
            parameters[6].Value = model.AdminGroupID;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        public int UpdateLogin(MS_Admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE S_Admin SET ");
            strSql.Append("LastLoginTime=@LastLoginTime,");
            strSql.Append("LastLoginIP=@LastLoginIP,");
            strSql.Append("ErrorCount=@ErrorCount,");
            strSql.Append("LoginCount=@LoginCount,");
            strSql.Append("IsOnline=@IsOnline,");
            strSql.Append("LastActiveTime=@LastActiveTime ");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@LastLoginTime", SqlDbType.DateTime,8),
               new SqlParameter("@LastLoginIP", SqlDbType.NVarChar,32),
               new SqlParameter("@ErrorCount", SqlDbType.Int,4),
               new SqlParameter("@LoginCount", SqlDbType.Int,4),
               new SqlParameter("@IsOnline", SqlDbType.Bit,1),
               new SqlParameter("@LastActiveTime", SqlDbType.DateTime,8)
             };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.LastLoginTime;
            parameters[2].Value = model.LastLoginIP;
            parameters[3].Value = model.ErrorCount;
            parameters[4].Value = model.LoginCount;
            parameters[5].Value = model.IsOnline;
            parameters[6].Value = model.LastActiveTime;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        public int UpdateLoginError(MS_Admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE S_Admin SET ");
            strSql.Append("ErrorCount=@ErrorCount,");
            strSql.Append("LastErrTime=@LastErrTime");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@ErrorCount", SqlDbType.Int,4),
               new SqlParameter("@LastErrTime", SqlDbType.DateTime,8)
             };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ErrorCount;
            parameters[2].Value = model.LastErrTime;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int LoginOut(int AdminId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE S_Admin SET ");
            strSql.Append("IsOnline=@IsOnline,");
            strSql.Append("LastActiveTime=@LastActiveTime ");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@IsOnline", SqlDbType.Bit,1),
               new SqlParameter("@LastActiveTime", SqlDbType.DateTime,8)
             };
            parameters[0].Value =AdminId;
            parameters[1].Value = 0;
            parameters[2].Value = DateTime.Now;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int UpdatePwd(MS_Admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE S_Admin SET ");
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

        public int Delete(int id)
        {
            string str = " delete from S_Admin where id=@id ";
            SqlParameter param = new SqlParameter("@id",SqlDbType.Int,4);
            param.Value = id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, str, param);
        }
        /// <summary>
        /// 禁用,启用管理员账户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DisOrEnable(int id,bool enable)
        {
            string str = " update  S_Admin set Enable=@Enable where id=@id ";
            SqlParameter[] paramters = {
                new SqlParameter("@Enable",SqlDbType.Bit,1),
                new SqlParameter("@id",SqlDbType.Int,4)
            };
            paramters[0].Value = enable;
            paramters[1].Value = id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, str, paramters);
        }
        public int GetAdminCountByGroup(int adminGroupID)
        {
            string str = "select Count(ID) from S_Admin where AdminGroupID=@AdminGroupID";
            SqlParameter param = new SqlParameter("@AdminGroupID",SqlDbType.Int,4);
            param.Value = adminGroupID;
            var obj= SQLHelper.ExecuteScalar(CommandType.Text,str,param);
            int res = 0;
            int.TryParse(obj.ToString(),out res);
            return res;
        }


    }
}
