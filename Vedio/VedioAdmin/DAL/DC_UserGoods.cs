using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommSQLHelper;
using Entity;

namespace DAL
{
    public class DC_UserGoods
    {
        /// <summary>
        /// 增加一条数据(表C_UserGoods)
        /// </summary>
        public int Add(MC_UserGoods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO C_UserGoods(");
            strSql.Append("UID,VedioID,VedioName,AddTime)");
            strSql.Append(" VALUES (");
            strSql.Append("@UID,@VedioID,@VedioName,@AddTime)");
            SqlParameter[] parameters = {
                    new SqlParameter("@UID", SqlDbType.Int,4),
                    new SqlParameter("@VedioID", SqlDbType.Int,4),
                    new SqlParameter("@VedioName", SqlDbType.NVarChar,200),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.VedioID;
            parameters[2].Value = model.VedioName;
            parameters[3].Value = model.AddTime;

            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int Delete(int VedioID, int UID)
        {
            string str = " delete from C_UserGoods where VedioID=@VedioID and  UID=@UID";
            SqlParameter[] parameters = {
                    new SqlParameter("@VedioID", SqlDbType.Int,4),
                    new SqlParameter("@UID", SqlDbType.Int,4),
                };
            parameters[0].Value = VedioID;
            parameters[1].Value = UID;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, str, parameters);
        }
        public MC_UserGoods GetModel(int VedioID, int UID)
        {
            string str = "select top 1 * from C_UserGoods where VedioID=@VedioID and  UID=@UID";
            SqlParameter[] parameters = {
                    new SqlParameter("@VedioID", SqlDbType.Int,4),
                    new SqlParameter("@UID", SqlDbType.Int,4),
                };
            parameters[0].Value = VedioID;
            parameters[1].Value = UID;
            return SQLHelper.ExecuteReaderObject<MC_UserGoods>(CommandType.Text, str, parameters);
        }

    }
}
