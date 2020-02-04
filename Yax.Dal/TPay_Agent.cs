using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// TPay_Agent
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表TPay_Agent)
        /// </summary>
        public static Model.TPay_Agent ConvertToTPay_Agent(DataRow dr)
        {
            Model.TPay_Agent model = new Model.TPay_Agent();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Account = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Account"]) ? string.Empty : dr["Account"].ToString();//代理账户
            model.RealName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["RealName"]) ? string.Empty : dr["RealName"].ToString();//代理人姓名
            model.Pwd = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Pwd"]) ? string.Empty : dr["Pwd"].ToString();
            model.State = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["State"]) ? string.Empty : dr["State"].ToString();//状态 1：正常3：禁用 4删除
            model.CalWay = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["CalWay"]) ? string.Empty : dr["CalWay"].ToString();//结算方式:1支付宝2微信3：银行卡
            model.CalBankNo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["CalBankNo"]) ? string.Empty : dr["CalBankNo"].ToString();//结算账号
            model.CalBankName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["CalBankName"]) ? string.Empty : dr["CalBankName"].ToString();//结算银行名称 
            model.CalMan = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["CalMan"]) ? string.Empty : dr["CalMan"].ToString();//结算持卡人姓名
            model.Phone = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Phone"]) ? string.Empty : dr["Phone"].ToString();//联系电话
            model.Money = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Money"]) ? 0 : decimal.Parse(dr["Money"].ToString());
            model.OutMoney = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["OutMoney"]) ? 0 : decimal.Parse(dr["OutMoney"].ToString());
            model.FreezeMoney = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["FreezeMoney"]) ? 0 : decimal.Parse(dr["FreezeMoney"].ToString());
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();
            model.WXFee = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["WXFee"]) ? 0 : decimal.Parse(dr["WXFee"].ToString()); //代理费率 EG：0.5 代理1000块钱流水5块钱提成
            model.ZFBFee = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ZFBFee"]) ? 0 : decimal.Parse(dr["ZFBFee"].ToString()); //代理费率 EG：0.5 代理1000块钱流水5块钱提成
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.ErrorCount = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ErrorCount"]) ? 0 : int.Parse(dr["ErrorCount"].ToString());
            model.LastErrTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["LastErrTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["LastErrTime"].ToString());
            model.LoginCount = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["LoginCount"]) ? 0 : int.Parse(dr["LoginCount"].ToString());
            model.LastLoginIP = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["LastLoginIP"]) ? string.Empty : dr["LastLoginIP"].ToString();
            model.LastLoginTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["LastLoginTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["LastLoginTime"].ToString());
            model.WXAccount = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["WXAccount"]) ? string.Empty : dr["WXAccount"].ToString();
            model.ZFBAccount = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ZFBAccount"]) ? string.Empty : dr["ZFBAccount"].ToString();

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表TPay_Agent)
        /// </summary>
        public static Model.TPay_Agent ConvetToTPay_Agent(SqlDataReader reader, string extParam)
        {
            Model.TPay_Agent model = new Model.TPay_Agent();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Account = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);//代理账户
            model.RealName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);//代理人姓名
            model.Pwd = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
            model.State = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);//状态 1：正常3：禁用 4删除
            model.CalWay = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);//结算方式:1支付宝2微信3：银行卡
            model.CalBankNo = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);//结算账号
            model.CalBankName = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);//结算银行名称 
            model.CalMan = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);//结算持卡人姓名
            model.Phone = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);//联系电话
            model.Money = reader.IsDBNull(10) ? 0 : reader.GetDecimal(10);
            model.OutMoney = reader.IsDBNull(11) ? 0 : reader.GetDecimal(11);
            model.FreezeMoney = reader.IsDBNull(12) ? 0 : reader.GetDecimal(12);
            model.Memo = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
            model.WXFee = reader.IsDBNull(14) ? 0 : reader.GetDecimal(14);//代理费率 EG：0.5 代理1000块钱流水5块钱提成
            model.ZFBFee = reader.IsDBNull(15) ? 0 : reader.GetDecimal(15);//代理费率 EG：0.5 代理1000块钱流水5块钱提成
            model.AddTime = reader.IsDBNull(16) ? System.DateTime.MinValue : reader.GetDateTime(16);
            model.ErrorCount = reader.IsDBNull(17) ? 0 : reader.GetInt32(17);
            model.LastErrTime = reader.IsDBNull(18) ? System.DateTime.MinValue : reader.GetDateTime(18);
            model.LoginCount = reader.IsDBNull(19) ? 0 : reader.GetInt32(19);
            model.LastLoginIP = reader.IsDBNull(20) ? string.Empty : reader.GetString(20);
            model.LastLoginTime = reader.IsDBNull(21) ? System.DateTime.MinValue : reader.GetDateTime(21);
            model.WXAccount = reader.IsDBNull(22) ? string.Empty : reader.GetString(22);
            model.ZFBAccount = reader.IsDBNull(23) ? string.Empty : reader.GetString(23);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表TPay_Agent)
        /// </summary>
        public int TPay_AgentAdd(Model.TPay_Agent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO TPay_Agent(");
            strSql.Append("Account,RealName,Pwd,State,CalWay,CalBankNo,CalBankName,CalMan,Phone,Money,OutMoney,FreezeMoney,Memo,WXFee,ZFBFee,AddTime,ErrorCount,LastErrTime,LoginCount,LastLoginIP,LastLoginTime,WXAccount,ZFBAccount)");
            strSql.Append(" VALUES (");
            strSql.Append("@Account,@RealName,@Pwd,@State,@CalWay,@CalBankNo,@CalBankName,@CalMan,@Phone,@Money,@OutMoney,@FreezeMoney,@Memo,@WXFee,@ZFBFee,@AddTime,@ErrorCount,@LastErrTime,@LoginCount,@LastLoginIP,@LastLoginTime,@WXAccount,@ZFBAccount)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Account", SqlDbType.NVarChar,100),
                    new SqlParameter("@RealName", SqlDbType.NVarChar,100),
                    new SqlParameter("@Pwd", SqlDbType.NVarChar,500),
                    new SqlParameter("@State", SqlDbType.NVarChar,100),
                    new SqlParameter("@CalWay", SqlDbType.NVarChar,100),
                    new SqlParameter("@CalBankNo", SqlDbType.NVarChar,100),
                    new SqlParameter("@CalBankName", SqlDbType.NVarChar,100),
                    new SqlParameter("@CalMan", SqlDbType.NVarChar,100),
                    new SqlParameter("@Phone", SqlDbType.NVarChar,100),
                    new SqlParameter("@Money", SqlDbType.Decimal,9),
                    new SqlParameter("@OutMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@FreezeMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
                    new SqlParameter("@WXFee", SqlDbType.Decimal,9),
                    new SqlParameter("@ZFBFee", SqlDbType.Decimal,9),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@ErrorCount", SqlDbType.Int,4),
                    new SqlParameter("@LastErrTime", SqlDbType.DateTime,8),
                    new SqlParameter("@LoginCount", SqlDbType.Int,4),
                    new SqlParameter("@LastLoginIP", SqlDbType.NVarChar,100),
                    new SqlParameter("@LastLoginTime", SqlDbType.DateTime,8),
                    new SqlParameter("@WXAccount", SqlDbType.NVarChar,100),
                    new SqlParameter("@ZFBAccount", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.Account;
            parameters[1].Value = model.RealName;
            parameters[2].Value = model.Pwd;
            parameters[3].Value = model.State;
            parameters[4].Value = model.CalWay;
            parameters[5].Value = model.CalBankNo;
            parameters[6].Value = model.CalBankName;
            parameters[7].Value = model.CalMan;
            parameters[8].Value = model.Phone;
            parameters[9].Value = model.Money;
            parameters[10].Value = model.OutMoney;
            parameters[11].Value = model.FreezeMoney;
            parameters[12].Value = model.Memo;
            parameters[13].Value = model.WXFee;
            parameters[14].Value = model.ZFBFee;
            parameters[15].Value = model.AddTime;
            parameters[16].Value = model.ErrorCount;
            parameters[17].Value = model.LastErrTime;
            parameters[18].Value = model.LoginCount;
            parameters[19].Value = model.LastLoginIP;
            parameters[20].Value = model.LastLoginTime;
            parameters[21].Value = model.WXAccount;
            parameters[22].Value = model.ZFBAccount;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表TPay_Agent)
        /// </summary>
        public int TPay_AgentUpdate(Model.TPay_Agent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TPay_Agent SET ");
            strSql.Append("Account=@Account,");
            strSql.Append("RealName=@RealName,");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("State=@State,");
            strSql.Append("CalWay=@CalWay,");
            strSql.Append("CalBankNo=@CalBankNo,");
            strSql.Append("CalBankName=@CalBankName,");
            strSql.Append("CalMan=@CalMan,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Money=@Money,");
            strSql.Append("OutMoney=@OutMoney,");
            strSql.Append("FreezeMoney=@FreezeMoney,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("WXFee=@WXFee,");
            strSql.Append("ZFBFee=@ZFBFee,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("ErrorCount=@ErrorCount,");
            strSql.Append("LastErrTime=@LastErrTime,");
            strSql.Append("LoginCount=@LoginCount,");
            strSql.Append("LastLoginIP=@LastLoginIP,");
            strSql.Append("LastLoginTime=@LastLoginTime,");
            strSql.Append("WXAccount=@WXAccount,");
            strSql.Append("ZFBAccount=@ZFBAccount");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Account", SqlDbType.NVarChar,100),
               new SqlParameter("@RealName", SqlDbType.NVarChar,100),
               new SqlParameter("@Pwd", SqlDbType.NVarChar,500),
               new SqlParameter("@State", SqlDbType.NVarChar,100),
               new SqlParameter("@CalWay", SqlDbType.NVarChar,100),
               new SqlParameter("@CalBankNo", SqlDbType.NVarChar,100),
               new SqlParameter("@CalBankName", SqlDbType.NVarChar,100),
               new SqlParameter("@CalMan", SqlDbType.NVarChar,100),
               new SqlParameter("@Phone", SqlDbType.NVarChar,100),
               new SqlParameter("@Money", SqlDbType.Decimal,9),
               new SqlParameter("@OutMoney", SqlDbType.Decimal,9),
               new SqlParameter("@FreezeMoney", SqlDbType.Decimal,9),
               new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
               new SqlParameter("@WXFee", SqlDbType.Decimal,9),
               new SqlParameter("@ZFBFee", SqlDbType.Decimal,9),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@ErrorCount", SqlDbType.Int,4),
               new SqlParameter("@LastErrTime", SqlDbType.DateTime,8),
               new SqlParameter("@LoginCount", SqlDbType.Int,4),
               new SqlParameter("@LastLoginIP", SqlDbType.NVarChar,100),
               new SqlParameter("@LastLoginTime", SqlDbType.DateTime,8),
               new SqlParameter("@WXAccount", SqlDbType.NVarChar,100),
               new SqlParameter("@ZFBAccount", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Account;
            parameters[2].Value = model.RealName;
            parameters[3].Value = model.Pwd;
            parameters[4].Value = model.State;
            parameters[5].Value = model.CalWay;
            parameters[6].Value = model.CalBankNo;
            parameters[7].Value = model.CalBankName;
            parameters[8].Value = model.CalMan;
            parameters[9].Value = model.Phone;
            parameters[10].Value = model.Money;
            parameters[11].Value = model.OutMoney;
            parameters[12].Value = model.FreezeMoney;
            parameters[13].Value = model.Memo;
            parameters[14].Value = model.WXFee;
            parameters[15].Value = model.ZFBFee;
            parameters[16].Value = model.AddTime;
            parameters[17].Value = model.ErrorCount;
            parameters[18].Value = model.LastErrTime;
            parameters[19].Value = model.LoginCount;
            parameters[20].Value = model.LastLoginIP;
            parameters[21].Value = model.LastLoginTime;
            parameters[22].Value = model.WXAccount;
            parameters[23].Value = model.ZFBAccount;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.TPay_Agent GetModelByTPay_Agent(int ID)
        {
            string sql = string.Format("SELECT * FROM TPay_Agent WITH(NOLOCK) WHERE ID={0}", ID);
            Model.TPay_Agent model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.TPay_Agent();
                    }
                    model = ConvetToTPay_Agent(reader, "All");
                }
            }
            return model;
        }


        public Model.TPay_Agent GetModelByTPay_Agent_Account(string Account)
        {
            string sql = string.Format("SELECT * FROM TPay_Agent WITH(NOLOCK) WHERE Account='{0}'", Account);
            Model.TPay_Agent model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.TPay_Agent();
                    }
                    model = ConvetToTPay_Agent(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.TPay_Agent> GetListTPay_Agent(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.TPay_Agent> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "TPay_Agent", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.TPay_Agent>();
                    }
                    list.Add(ConvetToTPay_Agent(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.TPay_Agent> GetPageTPay_Agent(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.TPay_Agent> list = new List<Yax.Model.TPay_Agent>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "TPay_Agent", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToTPay_Agent(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
