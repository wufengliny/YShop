using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// TPay_WXConfig
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表TPay_WXConfig)
        /// </summary>
        public static Model.TPay_WXConfig ConvertToTPay_WXConfig(DataRow dr)
        {
            Model.TPay_WXConfig model = new Model.TPay_WXConfig();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();
            model.Token = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Token"]) ? string.Empty : dr["Token"].ToString();
            model.apiid = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["apiid"]) ? string.Empty : dr["apiid"].ToString();
            model.Secret = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Secret"]) ? string.Empty : dr["Secret"].ToString();
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.PayMCHID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PayMCHID"]) ? string.Empty : dr["PayMCHID"].ToString();
            model.PayKey = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PayKey"]) ? string.Empty : dr["PayKey"].ToString();
            model.SSLCERT_PATH = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["SSLCERT_PATH"]) ? string.Empty : dr["SSLCERT_PATH"].ToString();
            model.SSLCERT_PASSWORD = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["SSLCERT_PASSWORD"]) ? string.Empty : dr["SSLCERT_PASSWORD"].ToString();
            model.NOTIFY_URL = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["NOTIFY_URL"]) ? string.Empty : dr["NOTIFY_URL"].ToString();
            model.SiteUrl = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["SiteUrl"]) ? string.Empty : dr["SiteUrl"].ToString();
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());//1正常2维护3禁用4异常
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();
            model.MinMoney = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["MinMoney"]) ? 0 : decimal.Parse(dr["MinMoney"].ToString());

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表TPay_WXConfig)
        /// </summary>
        public static Model.TPay_WXConfig ConvetToTPay_WXConfig(SqlDataReader reader, string extParam)
        {
            Model.TPay_WXConfig model = new Model.TPay_WXConfig();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.Token = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            model.apiid = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
            model.Secret = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
            model.AddTime = reader.IsDBNull(5) ? System.DateTime.MinValue : reader.GetDateTime(5);
            model.PayMCHID = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
            model.PayKey = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
            model.SSLCERT_PATH = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
            model.SSLCERT_PASSWORD = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
            model.NOTIFY_URL = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
            model.SiteUrl = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
            model.Enable = reader.IsDBNull(12) ? 0 : reader.GetInt32(12);//1正常2维护3禁用4异常
            model.Memo = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
            model.MinMoney = reader.IsDBNull(14) ? 0 : reader.GetDecimal(14);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表TPay_WXConfig)
        /// </summary>
        public int TPay_WXConfigAdd(Model.TPay_WXConfig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO TPay_WXConfig(");
            strSql.Append("Name,Token,apiid,Secret,AddTime,PayMCHID,PayKey,SSLCERT_PATH,SSLCERT_PASSWORD,NOTIFY_URL,SiteUrl,Enable,Memo,MinMoney)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@Token,@apiid,@Secret,@AddTime,@PayMCHID,@PayKey,@SSLCERT_PATH,@SSLCERT_PASSWORD,@NOTIFY_URL,@SiteUrl,@Enable,@Memo,@MinMoney)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,100),
                    new SqlParameter("@Token", SqlDbType.NVarChar,100),
                    new SqlParameter("@apiid", SqlDbType.NVarChar,100),
                    new SqlParameter("@Secret", SqlDbType.NVarChar,100),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@PayMCHID", SqlDbType.NVarChar,500),
                    new SqlParameter("@PayKey", SqlDbType.NVarChar,500),
                    new SqlParameter("@SSLCERT_PATH", SqlDbType.NVarChar,500),
                    new SqlParameter("@SSLCERT_PASSWORD", SqlDbType.NVarChar,500),
                    new SqlParameter("@NOTIFY_URL", SqlDbType.NVarChar,500),
                    new SqlParameter("@SiteUrl", SqlDbType.NVarChar,500),
                    new SqlParameter("@Enable", SqlDbType.Int,4),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,100),
                    new SqlParameter("@MinMoney", SqlDbType.Decimal,9)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Token;
            parameters[2].Value = model.apiid;
            parameters[3].Value = model.Secret;
            parameters[4].Value = model.AddTime;
            parameters[5].Value = model.PayMCHID;
            parameters[6].Value = model.PayKey;
            parameters[7].Value = model.SSLCERT_PATH;
            parameters[8].Value = model.SSLCERT_PASSWORD;
            parameters[9].Value = model.NOTIFY_URL;
            parameters[10].Value = model.SiteUrl;
            parameters[11].Value = model.Enable;
            parameters[12].Value = model.Memo;
            parameters[13].Value = model.MinMoney;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表TPay_WXConfig)
        /// </summary>
        public int TPay_WXConfigUpdate(Model.TPay_WXConfig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TPay_WXConfig SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("Token=@Token,");
            strSql.Append("apiid=@apiid,");
            strSql.Append("Secret=@Secret,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("PayMCHID=@PayMCHID,");
            strSql.Append("PayKey=@PayKey,");
            strSql.Append("SSLCERT_PATH=@SSLCERT_PATH,");
            strSql.Append("SSLCERT_PASSWORD=@SSLCERT_PASSWORD,");
            strSql.Append("NOTIFY_URL=@NOTIFY_URL,");
            strSql.Append("SiteUrl=@SiteUrl,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("MinMoney=@MinMoney");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,100),
               new SqlParameter("@Token", SqlDbType.NVarChar,100),
               new SqlParameter("@apiid", SqlDbType.NVarChar,100),
               new SqlParameter("@Secret", SqlDbType.NVarChar,100),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@PayMCHID", SqlDbType.NVarChar,500),
               new SqlParameter("@PayKey", SqlDbType.NVarChar,500),
               new SqlParameter("@SSLCERT_PATH", SqlDbType.NVarChar,500),
               new SqlParameter("@SSLCERT_PASSWORD", SqlDbType.NVarChar,500),
               new SqlParameter("@NOTIFY_URL", SqlDbType.NVarChar,500),
               new SqlParameter("@SiteUrl", SqlDbType.NVarChar,500),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@Memo", SqlDbType.NVarChar,100),
               new SqlParameter("@MinMoney", SqlDbType.Decimal,9)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Token;
            parameters[3].Value = model.apiid;
            parameters[4].Value = model.Secret;
            parameters[5].Value = model.AddTime;
            parameters[6].Value = model.PayMCHID;
            parameters[7].Value = model.PayKey;
            parameters[8].Value = model.SSLCERT_PATH;
            parameters[9].Value = model.SSLCERT_PASSWORD;
            parameters[10].Value = model.NOTIFY_URL;
            parameters[11].Value = model.SiteUrl;
            parameters[12].Value = model.Enable;
            parameters[13].Value = model.Memo;
            parameters[14].Value = model.MinMoney;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.TPay_WXConfig GetModelByTPay_WXConfig(int ID)
        {
            string sql = string.Format("SELECT * FROM TPay_WXConfig WITH(NOLOCK) WHERE ID={0}", ID);
            Model.TPay_WXConfig model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.TPay_WXConfig();
                    }
                    model = ConvetToTPay_WXConfig(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.TPay_WXConfig> GetListTPay_WXConfig(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.TPay_WXConfig> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "TPay_WXConfig", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.TPay_WXConfig>();
                    }
                    list.Add(ConvetToTPay_WXConfig(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.TPay_WXConfig> GetPageTPay_WXConfig(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.TPay_WXConfig> list = new List<Yax.Model.TPay_WXConfig>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "TPay_WXConfig", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToTPay_WXConfig(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
