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
    /// <summary>
    /// 用户权限数据类
    /// </summary>
    public class DS_Power
    {
        /// <summary>
        /// 权限添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int PowerAdd(MS_Power model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO S_Power(");
            strSql.Append("MenuID,AdminGroup,Mark,AddTime)");
            strSql.Append(" VALUES (");
            strSql.Append("@MenuID,@AdminGroup,@Mark,@AddTime)");
            SqlParameter[] parameters = {
                    new SqlParameter("@MenuID", SqlDbType.Int,4),
                    new SqlParameter("@AdminGroup", SqlDbType.Int,4),
                    new SqlParameter("@Mark", SqlDbType.NVarChar,100),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8)};
            parameters[0].Value = model.MenuID;
            parameters[1].Value = model.AdminGroup;
            parameters[2].Value = model.Mark;
            parameters[3].Value = model.AddTime;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int DeletePower(int admingroupID)
        {
            string str = "delete from S_Power where AdminGroup=@admingroupID";
            SqlParameter param = new SqlParameter("@admingroupID", SqlDbType.Int, 4);
            param.Value = admingroupID;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, str, param);
        }


        public IList<MS_Power> List()
        {
            string Fileds = " AdminGroup,Mark,MenuID ";
            string str = " select " + Fileds + " from S_Power Order by AdminGroup asc";
            return SQLHelper.ExecuteReaderList<MS_Power>(CommandType.Text, str);
        }
        public IList<MS_Power> GetPowersByAdmingroup(int AdminGroup)
        {
            string Fileds = " AdminGroup,Mark,MenuID ";
            string str = " select " + Fileds + " from S_Power where AdminGroup=@AdminGroup";
            SqlParameter param = new SqlParameter("@AdminGroup", SqlDbType.Int, 4);
            param.Value = AdminGroup;
            return SQLHelper.ExecuteReaderList<MS_Power>(CommandType.Text, str,param);
        }
    }
}
