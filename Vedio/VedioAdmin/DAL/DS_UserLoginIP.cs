using CommSQLHelper;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DS_UserLoginIP
    {
        /// <summary>
        /// 增加一条数据(表S_UserLoginIP)
        /// </summary>
        public int Add(MS_UserLoginIP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO S_UserLoginIP(");
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

            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int CountByUID(int UID)
        {
            string str = "select count(ID) from S_UserLoginIP where UID=@UID";
            SqlParameter param = new SqlParameter("@UID", SqlDbType.Int, 4);
            param.Value = UID;
            object obj= SQLHelper.ExecuteScalar(CommandType.Text, str, param);
            return int.Parse(obj.ToString());
        }
        public MS_UserLoginIP GetModelByIPUID(string IP,int UID)
        {
            string str = "select * from S_UserLoginIP where IP=@IP and UID=@UID";
            SqlParameter[] parameters = {
                    new SqlParameter("@IP", SqlDbType.NVarChar,100),
                    new SqlParameter("@UID", SqlDbType.Int,4)};
            parameters[0].Value = IP;
            parameters[1].Value = UID;
            return SQLHelper.ExecuteReaderObject<MS_UserLoginIP>(CommandType.Text, str, parameters);
        }

        public MS_UserLoginIP UpdateCount(int ID)
        {
            string str = "update S_UserLoginIP set Count=Count+1 where ID=@ID";
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = ID;
            return SQLHelper.ExecuteReaderObject<MS_UserLoginIP>(CommandType.Text, str, param);
        }
    }
}
