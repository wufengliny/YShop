using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// M_RegUserCode
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表M_RegUserCode)
        /// </summary>
        public static Model.M_RegUserCode ConvertToM_RegUserCode(DataRow dr)
        {
            Model.M_RegUserCode model = new Model.M_RegUserCode();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.AgentID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AgentID"]) ? 0 : int.Parse(dr["AgentID"].ToString());
            model.RegCode = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["RegCode"]) ? string.Empty : dr["RegCode"].ToString();
            model.AgentAccount = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AgentAccount"]) ? string.Empty : dr["AgentAccount"].ToString();
            model.UseTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UseTime"]) ? 0 : int.Parse(dr["UseTime"].ToString());//0 未使用 1 已使用
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.RegUID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["RegUID"]) ? 0 : int.Parse(dr["RegUID"].ToString());//使用者的UID
            model.RegAccount = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["RegAccount"]) ? string.Empty : dr["RegAccount"].ToString();//使用者账号
            model.RegTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["RegTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["RegTime"].ToString());
            model.RType = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["RType"]) ? 0 : int.Parse(dr["RType"].ToString());//1 永久VIP 2年VIP 
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表M_RegUserCode)
        /// </summary>
        public static Model.M_RegUserCode ConvetToM_RegUserCode(SqlDataReader reader, string extParam)
        {
            Model.M_RegUserCode model = new Model.M_RegUserCode();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.AgentID = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
            model.RegCode = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            model.AgentAccount = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
            model.UseTime = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);//0 未使用 1 已使用
            model.AddTime = reader.IsDBNull(5) ? System.DateTime.MinValue : reader.GetDateTime(5);
            model.RegUID = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);//使用者的UID
            model.RegAccount = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);//使用者账号
            model.RegTime = reader.IsDBNull(8) ? System.DateTime.MinValue : reader.GetDateTime(8);
            model.RType = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);//1 永久VIP 2年VIP 
            model.Memo = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表M_RegUserCode)
        /// </summary>
        public int M_RegUserCodeAdd(Model.M_RegUserCode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO M_RegUserCode(");
            strSql.Append("AgentID,RegCode,AgentAccount,UseTime,AddTime,RegUID,RegAccount,RegTime,RType,Memo)");
            strSql.Append(" VALUES (");
            strSql.Append("@AgentID,@RegCode,@AgentAccount,@UseTime,@AddTime,@RegUID,@RegAccount,@RegTime,@RType,@Memo)");
            SqlParameter[] parameters = {
                    new SqlParameter("@AgentID", SqlDbType.Int,4),
                    new SqlParameter("@RegCode", SqlDbType.NVarChar,100),
                    new SqlParameter("@AgentAccount", SqlDbType.NVarChar,100),
                    new SqlParameter("@UseTime", SqlDbType.Int,4),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@RegUID", SqlDbType.Int,4),
                    new SqlParameter("@RegAccount", SqlDbType.NVarChar,100),
                    new SqlParameter("@RegTime", SqlDbType.DateTime,8),
                    new SqlParameter("@RType", SqlDbType.Int,4),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.AgentID;
            parameters[1].Value = model.RegCode;
            parameters[2].Value = model.AgentAccount;
            parameters[3].Value = model.UseTime;
            parameters[4].Value = model.AddTime;
            parameters[5].Value = model.RegUID;
            parameters[6].Value = model.RegAccount;
            parameters[7].Value = model.RegTime;
            parameters[8].Value = model.RType;
            parameters[9].Value = model.Memo;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表M_RegUserCode)
        /// </summary>
        public int M_RegUserCodeUpdate(Model.M_RegUserCode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE M_RegUserCode SET ");
            strSql.Append("AgentID=@AgentID,");
            strSql.Append("RegCode=@RegCode,");
            strSql.Append("AgentAccount=@AgentAccount,");
            strSql.Append("UseTime=@UseTime,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("RegUID=@RegUID,");
            strSql.Append("RegAccount=@RegAccount,");
            strSql.Append("RegTime=@RegTime,");
            strSql.Append("RType=@RType,");
            strSql.Append("Memo=@Memo");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@AgentID", SqlDbType.Int,4),
               new SqlParameter("@RegCode", SqlDbType.NVarChar,100),
               new SqlParameter("@AgentAccount", SqlDbType.NVarChar,100),
               new SqlParameter("@UseTime", SqlDbType.Int,4),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@RegUID", SqlDbType.Int,4),
               new SqlParameter("@RegAccount", SqlDbType.NVarChar,100),
               new SqlParameter("@RegTime", SqlDbType.DateTime,8),
               new SqlParameter("@RType", SqlDbType.Int,4),
               new SqlParameter("@Memo", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.AgentID;
            parameters[2].Value = model.RegCode;
            parameters[3].Value = model.AgentAccount;
            parameters[4].Value = model.UseTime;
            parameters[5].Value = model.AddTime;
            parameters[6].Value = model.RegUID;
            parameters[7].Value = model.RegAccount;
            parameters[8].Value = model.RegTime;
            parameters[9].Value = model.RType;
            parameters[10].Value = model.Memo;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.M_RegUserCode GetModelByM_RegUserCode(int ID)
        {
            string sql = string.Format("SELECT * FROM M_RegUserCode WITH(NOLOCK) WHERE ID={0}", ID);
            Model.M_RegUserCode model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.M_RegUserCode();
                    }
                    model = ConvetToM_RegUserCode(reader, "All");
                }
            }
            return model;
        }

        public Model.M_RegUserCode GetModelByM_RegUserCodeBYCode(string code)
        {
            string sql = string.Format("SELECT * FROM M_RegUserCode WITH(NOLOCK) WHERE RegCode='{0}'", code);
            Model.M_RegUserCode model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.M_RegUserCode();
                    }
                    model = ConvetToM_RegUserCode(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.M_RegUserCode> GetListM_RegUserCode(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.M_RegUserCode> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "M_RegUserCode", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.M_RegUserCode>();
                    }
                    list.Add(ConvetToM_RegUserCode(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.M_RegUserCode> GetPageM_RegUserCode(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.M_RegUserCode> list = new List<Yax.Model.M_RegUserCode>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "M_RegUserCode", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToM_RegUserCode(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
