using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// PhoneMsg
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表PhoneMsg)
        /// </summary>
        public static Model.PhoneMsg ConvertToPhoneMsg(DataRow dr)
        {
            Model.PhoneMsg model = new Model.PhoneMsg();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Phone = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Phone"]) ? string.Empty : dr["Phone"].ToString();
            model.Msg = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Msg"]) ? string.Empty : dr["Msg"].ToString();
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.Size = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Size"]) ? 0 : int.Parse(dr["Size"].ToString());
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();
            model.IP = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IP"]) ? string.Empty : dr["IP"].ToString();

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表PhoneMsg)
        /// </summary>
        public static Model.PhoneMsg ConvetToPhoneMsg(SqlDataReader reader, string extParam)
        {
            Model.PhoneMsg model = new Model.PhoneMsg();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Phone = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.Msg = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            model.AddTime = reader.IsDBNull(3) ? System.DateTime.MinValue : reader.GetDateTime(3);
            model.Size = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
            model.Memo = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
            model.IP = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表PhoneMsg)
        /// </summary>
        public int PhoneMsgAdd(Model.PhoneMsg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO PhoneMsg(");
            strSql.Append("Phone,Msg,AddTime,Size,Memo,IP)");
            strSql.Append(" VALUES (");
            strSql.Append("@Phone,@Msg,@AddTime,@Size,@Memo,@IP)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Phone", SqlDbType.NVarChar,100),
                    new SqlParameter("@Msg", SqlDbType.NVarChar,1000),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Size", SqlDbType.Int,4),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,200),
                    new SqlParameter("@IP", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.Phone;
            parameters[1].Value = model.Msg;
            parameters[2].Value = model.AddTime;
            parameters[3].Value = model.Size;
            parameters[4].Value = model.Memo;
            parameters[5].Value = model.IP;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表PhoneMsg)
        /// </summary>
        public int PhoneMsgUpdate(Model.PhoneMsg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE PhoneMsg SET ");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Msg=@Msg,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Size=@Size,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("IP=@IP");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Phone", SqlDbType.NVarChar,100),
               new SqlParameter("@Msg", SqlDbType.NVarChar,1000),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@Size", SqlDbType.Int,4),
               new SqlParameter("@Memo", SqlDbType.NVarChar,200),
               new SqlParameter("@IP", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Phone;
            parameters[2].Value = model.Msg;
            parameters[3].Value = model.AddTime;
            parameters[4].Value = model.Size;
            parameters[5].Value = model.Memo;
            parameters[6].Value = model.IP;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.PhoneMsg GetModelByPhoneMsg(int ID)
        {
            string sql = string.Format("SELECT * FROM PhoneMsg WITH(NOLOCK) WHERE ID={0}", ID);
            Model.PhoneMsg model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.PhoneMsg();
                    }
                    model = ConvetToPhoneMsg(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.PhoneMsg> GetListPhoneMsg(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.PhoneMsg> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "PhoneMsg", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.PhoneMsg>();
                    }
                    list.Add(ConvetToPhoneMsg(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.PhoneMsg> GetPagePhoneMsg(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.PhoneMsg> list = new List<Yax.Model.PhoneMsg>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "PhoneMsg", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToPhoneMsg(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
