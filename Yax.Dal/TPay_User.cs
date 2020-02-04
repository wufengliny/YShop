using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// TPay_User
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表TPay_User)
        /// </summary>
        public static Model.TPay_User ConvertToTPay_User(DataRow dr)
        {
            Model.TPay_User model = new Model.TPay_User();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();//商户名称（企业名称）
            model.Account = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Account"]) ? string.Empty : dr["Account"].ToString();//商户号
            model.Pwd = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Pwd"]) ? string.Empty : dr["Pwd"].ToString();
            model.ContactMan = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ContactMan"]) ? string.Empty : dr["ContactMan"].ToString();//联系人姓名
            model.State = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["State"]) ? 0 : int.Parse(dr["State"].ToString());//商户号状态1：正常(已激活) 2测试 3禁用 4删除
            model.PayKey = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PayKey"]) ? string.Empty : dr["PayKey"].ToString();//密钥
            model.CalWay = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["CalWay"]) ? string.Empty : dr["CalWay"].ToString();//结算方式:1支付宝2微信3：银行卡
            model.CalBankNo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["CalBankNo"]) ? string.Empty : dr["CalBankNo"].ToString();//结算账号
            model.CalBankName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["CalBankName"]) ? string.Empty : dr["CalBankName"].ToString();//结算银行名称 
            model.CalMan = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["CalMan"]) ? string.Empty : dr["CalMan"].ToString();//结算持卡人姓名
            model.WebUrl = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["WebUrl"]) ? string.Empty : dr["WebUrl"].ToString();//商户网站域名
            model.Emali = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Emali"]) ? string.Empty : dr["Emali"].ToString();//联系邮箱
            model.QQ = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["QQ"]) ? string.Empty : dr["QQ"].ToString();//联系QQ
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();//商户备注 其他信息
            model.Money = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Money"]) ? 0 : decimal.Parse(dr["Money"].ToString()); //商户余额
            model.OutMoney = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["OutMoney"]) ? 0 : decimal.Parse(dr["OutMoney"].ToString()); //历史提现总金额
            model.FreezeMoney = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["FreezeMoney"]) ? 0 : decimal.Parse(dr["FreezeMoney"].ToString()); //冻结金额
            model.WXFee = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["WXFee"]) ? 0 : decimal.Parse(dr["WXFee"].ToString()); //微信费率 eg(金额100元) 费率是4.0 结算之后商户可以提现96元
            model.ZFBFee = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ZFBFee"]) ? 0 : decimal.Parse(dr["ZFBFee"].ToString()); //支付宝费率 eg(金额100元) 费率是4.0 结算之后商户可以提现96元
            model.Phone = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Phone"]) ? string.Empty : dr["Phone"].ToString();//联系电话
            model.RecommondID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["RecommondID"]) ? 0 : int.Parse(dr["RecommondID"].ToString());//代理推荐人ID
            model.IPWhite = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IPWhite"]) ? string.Empty : dr["IPWhite"].ToString();//IP白名单  多个,逗号隔开 
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
        /// 数据转换成实体(表TPay_User)
        /// </summary>
        public static Model.TPay_User ConvetToTPay_User(SqlDataReader reader, string extParam)
        {
            Model.TPay_User model = new Model.TPay_User();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);//商户名称（企业名称）
            model.Account = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);//商户号
            model.Pwd = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
            model.ContactMan = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);//联系人姓名
            model.State = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);//商户号状态1：正常(已激活) 2测试 3禁用 4删除
            model.PayKey = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);//密钥
            model.CalWay = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);//结算方式:1支付宝2微信3：银行卡
            model.CalBankNo = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);//结算账号
            model.CalBankName = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);//结算银行名称 
            model.CalMan = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);//结算持卡人姓名
            model.WebUrl = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);//商户网站域名
            model.Emali = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);//联系邮箱
            model.QQ = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);//联系QQ
            model.Memo = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);//商户备注 其他信息
            model.Money = reader.IsDBNull(15) ? 0 : reader.GetDecimal(15);//商户余额
            model.OutMoney = reader.IsDBNull(16) ? 0 : reader.GetDecimal(16);//历史提现总金额
            model.FreezeMoney = reader.IsDBNull(17) ? 0 : reader.GetDecimal(17);//冻结金额
            model.WXFee = reader.IsDBNull(18) ? 0 : reader.GetDecimal(18);//微信费率 eg(金额100元) 费率是4.0 结算之后商户可以提现96元
            model.ZFBFee = reader.IsDBNull(19) ? 0 : reader.GetDecimal(19);//支付宝费率 eg(金额100元) 费率是4.0 结算之后商户可以提现96元
            model.Phone = reader.IsDBNull(20) ? string.Empty : reader.GetString(20);//联系电话
            model.RecommondID = reader.IsDBNull(21) ? 0 : reader.GetInt32(21);//代理推荐人ID
            model.IPWhite = reader.IsDBNull(22) ? string.Empty : reader.GetString(22);//IP白名单  多个,逗号隔开 
            model.AddTime = reader.IsDBNull(23) ? System.DateTime.MinValue : reader.GetDateTime(23);
            model.ErrorCount = reader.IsDBNull(24) ? 0 : reader.GetInt32(24);
            model.LastErrTime = reader.IsDBNull(25) ? System.DateTime.MinValue : reader.GetDateTime(25);
            model.LoginCount = reader.IsDBNull(26) ? 0 : reader.GetInt32(26);
            model.LastLoginIP = reader.IsDBNull(27) ? string.Empty : reader.GetString(27);
            model.LastLoginTime = reader.IsDBNull(28) ? System.DateTime.MinValue : reader.GetDateTime(28);
            model.WXAccount = reader.IsDBNull(29) ? string.Empty : reader.GetString(29);
            model.ZFBAccount = reader.IsDBNull(30) ? string.Empty : reader.GetString(30);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表TPay_User)
        /// </summary>
        public int TPay_UserAdd(Model.TPay_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO TPay_User(");
            strSql.Append("Name,Account,Pwd,ContactMan,State,PayKey,CalWay,CalBankNo,CalBankName,CalMan,WebUrl,Emali,QQ,Memo,Money,OutMoney,FreezeMoney,WXFee,ZFBFee,Phone,RecommondID,IPWhite,AddTime)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@Account,@Pwd,@ContactMan,@State,@PayKey,@CalWay,@CalBankNo,@CalBankName,@CalMan,@WebUrl,@Emali,@QQ,@Memo,@Money,@OutMoney,@FreezeMoney,@WXFee,@ZFBFee,@Phone,@RecommondID,@IPWhite,@AddTime)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,100),
                    new SqlParameter("@Account", SqlDbType.NVarChar,100),
                    new SqlParameter("@Pwd", SqlDbType.NVarChar,500),
                    new SqlParameter("@ContactMan", SqlDbType.NVarChar,20),
                    new SqlParameter("@State", SqlDbType.Int,4),
                    new SqlParameter("@PayKey", SqlDbType.NVarChar,500),
                    new SqlParameter("@CalWay", SqlDbType.NVarChar,20),
                    new SqlParameter("@CalBankNo", SqlDbType.NVarChar,100),
                    new SqlParameter("@CalBankName", SqlDbType.NVarChar,100),
                    new SqlParameter("@CalMan", SqlDbType.NVarChar,100),
                    new SqlParameter("@WebUrl", SqlDbType.NVarChar,100),
                    new SqlParameter("@Emali", SqlDbType.NVarChar,100),
                    new SqlParameter("@QQ", SqlDbType.NVarChar,100),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
                    new SqlParameter("@Money", SqlDbType.Decimal,9),
                    new SqlParameter("@OutMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@FreezeMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@WXFee", SqlDbType.Decimal,9),
                    new SqlParameter("@ZFBFee", SqlDbType.Decimal,9),
                    new SqlParameter("@Phone", SqlDbType.NVarChar,100),
                    new SqlParameter("@RecommondID", SqlDbType.Int,4),
                    new SqlParameter("@IPWhite", SqlDbType.NVarChar,1000),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Account;
            parameters[2].Value = model.Pwd;
            parameters[3].Value = model.ContactMan;
            parameters[4].Value = model.State;
            parameters[5].Value = model.PayKey;
            parameters[6].Value = model.CalWay;
            parameters[7].Value = model.CalBankNo;
            parameters[8].Value = model.CalBankName;
            parameters[9].Value = model.CalMan;
            parameters[10].Value = model.WebUrl;
            parameters[11].Value = model.Emali;
            parameters[12].Value = model.QQ;
            parameters[13].Value = model.Memo;
            parameters[14].Value = model.Money;
            parameters[15].Value = model.OutMoney;
            parameters[16].Value = model.FreezeMoney;
            parameters[17].Value = model.WXFee;
            parameters[18].Value = model.ZFBFee;
            parameters[19].Value = model.Phone;
            parameters[20].Value = model.RecommondID;
            parameters[21].Value = model.IPWhite;
            parameters[22].Value = model.AddTime;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表TPay_User)
        /// </summary>
        public int TPay_UserUpdate(Model.TPay_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TPay_User SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("Account=@Account,");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("ContactMan=@ContactMan,");
            strSql.Append("State=@State,");
            strSql.Append("PayKey=@PayKey,");
            strSql.Append("CalWay=@CalWay,");
            strSql.Append("CalBankNo=@CalBankNo,");
            strSql.Append("CalBankName=@CalBankName,");
            strSql.Append("CalMan=@CalMan,");
            strSql.Append("WebUrl=@WebUrl,");
            strSql.Append("Emali=@Emali,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("Money=@Money,");
            strSql.Append("OutMoney=@OutMoney,");
            strSql.Append("FreezeMoney=@FreezeMoney,");
            strSql.Append("WXFee=@WXFee,");
            strSql.Append("ZFBFee=@ZFBFee,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("RecommondID=@RecommondID,");
            strSql.Append("IPWhite=@IPWhite,");
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
               new SqlParameter("@Name", SqlDbType.NVarChar,100),
               new SqlParameter("@Account", SqlDbType.NVarChar,100),
               new SqlParameter("@Pwd", SqlDbType.NVarChar,500),
               new SqlParameter("@ContactMan", SqlDbType.NVarChar,20),
               new SqlParameter("@State", SqlDbType.Int,4),
               new SqlParameter("@PayKey", SqlDbType.NVarChar,500),
               new SqlParameter("@CalWay", SqlDbType.NVarChar,20),
               new SqlParameter("@CalBankNo", SqlDbType.NVarChar,100),
               new SqlParameter("@CalBankName", SqlDbType.NVarChar,100),
               new SqlParameter("@CalMan", SqlDbType.NVarChar,100),
               new SqlParameter("@WebUrl", SqlDbType.NVarChar,100),
               new SqlParameter("@Emali", SqlDbType.NVarChar,100),
               new SqlParameter("@QQ", SqlDbType.NVarChar,100),
               new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
               new SqlParameter("@Money", SqlDbType.Decimal,9),
               new SqlParameter("@OutMoney", SqlDbType.Decimal,9),
               new SqlParameter("@FreezeMoney", SqlDbType.Decimal,9),
               new SqlParameter("@WXFee", SqlDbType.Decimal,9),
               new SqlParameter("@ZFBFee", SqlDbType.Decimal,9),
               new SqlParameter("@Phone", SqlDbType.NVarChar,100),
               new SqlParameter("@RecommondID", SqlDbType.Int,4),
               new SqlParameter("@IPWhite", SqlDbType.NVarChar,1000),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@ErrorCount", SqlDbType.Int,4),
               new SqlParameter("@LastErrTime", SqlDbType.DateTime,8),
               new SqlParameter("@LoginCount", SqlDbType.Int,4),
               new SqlParameter("@LastLoginIP", SqlDbType.NVarChar,100),
               new SqlParameter("@LastLoginTime", SqlDbType.DateTime,8),
               new SqlParameter("@WXAccount", SqlDbType.NVarChar,100),
               new SqlParameter("@ZFBAccount", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Account;
            parameters[3].Value = model.Pwd;
            parameters[4].Value = model.ContactMan;
            parameters[5].Value = model.State;
            parameters[6].Value = model.PayKey;
            parameters[7].Value = model.CalWay;
            parameters[8].Value = model.CalBankNo;
            parameters[9].Value = model.CalBankName;
            parameters[10].Value = model.CalMan;
            parameters[11].Value = model.WebUrl;
            parameters[12].Value = model.Emali;
            parameters[13].Value = model.QQ;
            parameters[14].Value = model.Memo;
            parameters[15].Value = model.Money;
            parameters[16].Value = model.OutMoney;
            parameters[17].Value = model.FreezeMoney;
            parameters[18].Value = model.WXFee;
            parameters[19].Value = model.ZFBFee;
            parameters[20].Value = model.Phone;
            parameters[21].Value = model.RecommondID;
            parameters[22].Value = model.IPWhite;
            parameters[23].Value = model.AddTime;
            parameters[24].Value = model.ErrorCount;
            parameters[25].Value = model.LastErrTime;
            parameters[26].Value = model.LoginCount;
            parameters[27].Value = model.LastLoginIP;
            parameters[28].Value = model.LastLoginTime;
            parameters[29].Value = model.WXAccount;
            parameters[30].Value = model.ZFBAccount;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.TPay_User GetModelByTPay_User(int ID)
        {
            string sql = string.Format("SELECT * FROM TPay_User WITH(NOLOCK) WHERE ID={0}", ID);
            Model.TPay_User model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.TPay_User();
                    }
                    model = ConvetToTPay_User(reader, "All");
                }
            }
            return model;
        }

        public Model.TPay_User GetModelByTPay_User_Account(string Account)
        {
            string sql = string.Format("SELECT * FROM TPay_User WITH(NOLOCK) WHERE Account='{0}'", Account);
            Model.TPay_User model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.TPay_User();
                    }
                    model = ConvetToTPay_User(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.TPay_User> GetListTPay_User(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.TPay_User> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "TPay_User", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.TPay_User>();
                    }
                    list.Add(ConvetToTPay_User(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.TPay_User> GetPageTPay_User(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.TPay_User> list = new List<Yax.Model.TPay_User>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "TPay_User", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToTPay_User(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
