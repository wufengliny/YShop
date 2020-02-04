using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// Y_User
    /// </summary>
    public partial class DataProvider
    {
        public static Model.Y_User ConvertToY_User(DataRow dr)
        {
            Model.Y_User model = new Model.Y_User();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Account = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Account"]) ? string.Empty : dr["Account"].ToString();//唯一   邮箱或者手机
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();//用户名 显示
            model.RealName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["RealName"]) ? string.Empty : dr["RealName"].ToString();
            model.Phone = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Phone"]) ? string.Empty : dr["Phone"].ToString();
            model.Pwd = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Pwd"]) ? string.Empty : dr["Pwd"].ToString();
            model.Email = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Email"]) ? string.Empty : dr["Email"].ToString();
            model.Sex = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Sex"]) ? 0 : int.Parse(dr["Sex"].ToString());//0：男 1：女
            model.LastLoginTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["LastLoginTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["LastLoginTime"].ToString());
            model.LastLoginIP = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["LastLoginIP"]) ? string.Empty : dr["LastLoginIP"].ToString();
            model.LoginCount = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["LoginCount"]) ? 0 : int.Parse(dr["LoginCount"].ToString());
            model.RegIP = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["RegIP"]) ? string.Empty : dr["RegIP"].ToString();
            model.RegURL = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["RegURL"]) ? string.Empty : dr["RegURL"].ToString();
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.RegType = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["RegType"]) ? 0 : int.Parse(dr["RegType"].ToString());//0 邮箱注册  1：手机注册 2:一般注册（无邮箱，手机） 3后台添加 4 代理添加
            model.UpdateTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UpdateTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["UpdateTime"].ToString());
            model.Effect = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Effect"]) ? 0 : int.Parse(dr["Effect"].ToString());
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();
            model.ErrorCount = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ErrorCount"]) ? 0 : int.Parse(dr["ErrorCount"].ToString());
            model.LastErrTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["LastErrTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["LastErrTime"].ToString());
            model.Money = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Money"]) ? 0 : decimal.Parse(dr["Money"].ToString());
            model.QQ = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["QQ"]) ? string.Empty : dr["QQ"].ToString();
            model.JIFen = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["JIFen"]) ? 0 : int.Parse(dr["JIFen"].ToString());//会员的积分数
            model.DianQuan = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["DianQuan"]) ? 0 : int.Parse(dr["DianQuan"].ToString());//点券 不可提现
            model.AddressID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddressID"]) ? 0 : int.Parse(dr["AddressID"].ToString());
            model.IDCard = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IDCard"]) ? string.Empty : dr["IDCard"].ToString();//身份证号码
            model.IDCardImgZheng = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IDCardImgZheng"]) ? string.Empty : dr["IDCardImgZheng"].ToString();
            model.IDCardImgBei = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IDCardImgBei"]) ? string.Empty : dr["IDCardImgBei"].ToString();
            model.IDCardImgShouChi = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IDCardImgShouChi"]) ? string.Empty : dr["IDCardImgShouChi"].ToString();//手持身份证
            model.LivePlace = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["LivePlace"]) ? string.Empty : dr["LivePlace"].ToString();//现居住地
            model.WorkPlace = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["WorkPlace"]) ? string.Empty : dr["WorkPlace"].ToString();//单位地址
            model.JobName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["JobName"]) ? string.Empty : dr["JobName"].ToString();
            model.JobAge = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["JobAge"]) ? string.Empty : dr["JobAge"].ToString();
            model.JobCompanyPhone = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["JobCompanyPhone"]) ? string.Empty : dr["JobCompanyPhone"].ToString();//单位电话
            model.JobMoney = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["JobMoney"]) ? 0 : decimal.Parse(dr["JobMoney"].ToString());
            model.ContactMan = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ContactMan"]) ? string.Empty : dr["ContactMan"].ToString();
            model.ContactMan2 = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ContactMan2"]) ? string.Empty : dr["ContactMan2"].ToString();
            model.BankName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BankName"]) ? string.Empty : dr["BankName"].ToString();
            model.BankCardNO = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BankCardNO"]) ? string.Empty : dr["BankCardNO"].ToString();
            model.JobCompanyName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["JobCompanyName"]) ? string.Empty : dr["JobCompanyName"].ToString();
            model.RZState = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["RZState"]) ? 0 : int.Parse(dr["RZState"].ToString());
            model.RzMemo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["RzMemo"]) ? string.Empty : dr["RzMemo"].ToString();
            model.BuC = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BuC"]) ? string.Empty : dr["BuC"].ToString();
            model.BuC2 = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BuC2"]) ? string.Empty : dr["BuC2"].ToString();
            model.BuC3 = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BuC3"]) ? string.Empty : dr["BuC3"].ToString();
            model.BuC4 = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BuC4"]) ? string.Empty : dr["BuC4"].ToString();
            model.BuC5 = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BuC5"]) ? string.Empty : dr["BuC5"].ToString();
            model.BuC6 = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BuC6"]) ? string.Empty : dr["BuC6"].ToString();
            model.IDCardSelf = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IDCardSelf"]) ? string.Empty : dr["IDCardSelf"].ToString();
            model.UserType = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UserType"]) ? string.Empty : dr["UserType"].ToString();//会员，代理
            model.AgentID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AgentID"]) ? 0 : int.Parse(dr["AgentID"].ToString());//上级代理ID 
            model.VIP = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["VIP"]) ? 0 : int.Parse(dr["VIP"].ToString());//0：非VIP 1：VIP
            model.VIPLevel = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["VIPLevel"]) ? 0 : int.Parse(dr["VIPLevel"].ToString());//1:普通VIP2 超级VIP 
            model.VIPEndTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["VIPEndTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["VIPEndTime"].ToString()); //VIP 结束时间
            model.VIPMemo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["VIPMemo"]) ? string.Empty : dr["VIPMemo"].ToString();//VIP备注

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表Y_User)
        /// </summary>
        public static Model.Y_User ConvetToY_User(SqlDataReader reader, string extParam)
        {
            Model.Y_User model = new Model.Y_User();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Account = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);//唯一   邮箱或者手机
            model.Name = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);//用户名 显示
            model.RealName = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
            model.Phone = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
            model.Pwd = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
            model.Email = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
            model.Sex = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);//0：男 1：女
            model.LastLoginTime = reader.IsDBNull(8) ? System.DateTime.MinValue : reader.GetDateTime(8);
            model.LastLoginIP = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
            model.LoginCount = reader.IsDBNull(10) ? 0 : reader.GetInt32(10);
            model.RegIP = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
            model.RegURL = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
            model.AddTime = reader.IsDBNull(13) ? System.DateTime.MinValue : reader.GetDateTime(13);
            model.RegType = reader.IsDBNull(14) ? 0 : reader.GetInt32(14);//0 邮箱注册  1：手机注册 2:一般注册（无邮箱，手机） 3后台添加 4 代理添加
            model.UpdateTime = reader.IsDBNull(15) ? System.DateTime.MinValue : reader.GetDateTime(15);
            model.Effect = reader.IsDBNull(16) ? 0 : reader.GetInt32(16);
            model.Memo = reader.IsDBNull(17) ? string.Empty : reader.GetString(17);
            model.ErrorCount = reader.IsDBNull(18) ? 0 : reader.GetInt32(18);
            model.LastErrTime = reader.IsDBNull(19) ? System.DateTime.MinValue : reader.GetDateTime(19);
            model.Money = reader.IsDBNull(20) ? 0 : reader.GetDecimal(20);
            model.QQ = reader.IsDBNull(21) ? string.Empty : reader.GetString(21);
            model.JIFen = reader.IsDBNull(22) ? 0 : reader.GetInt32(22);//会员的积分数
            model.DianQuan = reader.IsDBNull(23) ? 0 : reader.GetInt32(23);//点券 不可提现
            model.AddressID = reader.IsDBNull(24) ? 0 : reader.GetInt32(24);
            model.IDCard = reader.IsDBNull(25) ? string.Empty : reader.GetString(25);//身份证号码
            model.IDCardImgZheng = reader.IsDBNull(26) ? string.Empty : reader.GetString(26);
            model.IDCardImgBei = reader.IsDBNull(27) ? string.Empty : reader.GetString(27);
            model.IDCardImgShouChi = reader.IsDBNull(28) ? string.Empty : reader.GetString(28);//手持身份证
            model.LivePlace = reader.IsDBNull(29) ? string.Empty : reader.GetString(29);//现居住地
            model.WorkPlace = reader.IsDBNull(30) ? string.Empty : reader.GetString(30);//单位地址
            model.JobName = reader.IsDBNull(31) ? string.Empty : reader.GetString(31);
            model.JobAge = reader.IsDBNull(32) ? string.Empty : reader.GetString(32);
            model.JobCompanyPhone = reader.IsDBNull(33) ? string.Empty : reader.GetString(33);//单位电话
            model.JobMoney = reader.IsDBNull(34) ? 0 : reader.GetDecimal(34);
            model.ContactMan = reader.IsDBNull(35) ? string.Empty : reader.GetString(35);
            model.ContactMan2 = reader.IsDBNull(36) ? string.Empty : reader.GetString(36);
            model.BankName = reader.IsDBNull(37) ? string.Empty : reader.GetString(37);
            model.BankCardNO = reader.IsDBNull(38) ? string.Empty : reader.GetString(38);
            model.JobCompanyName = reader.IsDBNull(39) ? string.Empty : reader.GetString(39);
            model.RZState = reader.IsDBNull(40) ? 0 : reader.GetInt32(40);
            model.RzMemo = reader.IsDBNull(41) ? string.Empty : reader.GetString(41);
            model.BuC = reader.IsDBNull(42) ? string.Empty : reader.GetString(42);
            model.BuC2 = reader.IsDBNull(43) ? string.Empty : reader.GetString(43);
            model.BuC3 = reader.IsDBNull(44) ? string.Empty : reader.GetString(44);
            model.BuC4 = reader.IsDBNull(45) ? string.Empty : reader.GetString(45);
            model.BuC5 = reader.IsDBNull(46) ? string.Empty : reader.GetString(46);
            model.BuC6 = reader.IsDBNull(47) ? string.Empty : reader.GetString(47);
            model.IDCardSelf = reader.IsDBNull(48) ? string.Empty : reader.GetString(48);
            model.UserType = reader.IsDBNull(49) ? string.Empty : reader.GetString(49);//会员，代理
            model.AgentID = reader.IsDBNull(50) ? 0 : reader.GetInt32(50);//上级代理ID 
            model.VIP = reader.IsDBNull(51) ? 0 : reader.GetInt32(51);//0：非VIP 1：VIP
            model.VIPLevel = reader.IsDBNull(52) ? 0 : reader.GetInt32(52);//1:普通VIP2 超级VIP 
            model.VIPEndTime = reader.IsDBNull(53) ? System.DateTime.MinValue : reader.GetDateTime(53);//VIP 结束时间
            model.VIPMemo = reader.IsDBNull(54) ? string.Empty : reader.GetString(54);//VIP备注

            return model;
        }
        /// <summary>
        /// 增加一条数据(表Y_User)
        /// </summary>
        public int Y_UserAdd(Model.Y_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Y_User(");
            strSql.Append("Account,Name,RealName,Phone,Pwd,Email,Sex,LastLoginTime,LastLoginIP,LoginCount,RegIP,RegURL,AddTime,RegType,UpdateTime,Effect,Memo,ErrorCount,LastErrTime,Money,QQ,JIFen,AddressIDCardCardImgZhengCardImgBeiCardImgShouChi,LivePlace,WorkPlace,JobName,JobAge,JobCompanyPhone,JobMoney,ContactMan,ContactMan2,BankName,BankCardNO,JobCompanyName,RZState,RzMemoCardSelf,BuC,BuC2,BuC3,BuC4,BuC5,BuC6)");
            strSql.Append(" VALUES (");
            strSql.Append("@Account,@Name,@RealName,@Phone,@Pwd,@Email,@Sex,@LastLoginTime,@LastLoginIP,@LoginCount,@RegIP,@RegURL,@AddTime,@RegType,@UpdateTime,@Effect,@Memo,@ErrorCount,@LastErrTime,@Money,@QQ,@JIFen,@AddressIDCardCardImgZhengCardImgBeiCardImgShouChi,@LivePlace,@WorkPlace,@JobName,@JobAge,@JobCompanyPhone,@JobMoney,@ContactMan,@ContactMan2,@BankName,@BankCardNO,@JobCompanyName,@RZState,@RzMemoCardSelf,@BuC,@BuC2,@BuC3,@BuC4,@BuC5,@BuC6)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Account", SqlDbType.NVarChar,100),
                    new SqlParameter("@Name", SqlDbType.NVarChar,100),
                    new SqlParameter("@RealName", SqlDbType.NVarChar,100),
                    new SqlParameter("@Phone", SqlDbType.NVarChar,100),
                    new SqlParameter("@Pwd", SqlDbType.NVarChar,500),
                    new SqlParameter("@Email", SqlDbType.NVarChar,100),
                    new SqlParameter("@Sex", SqlDbType.Int,4),
                    new SqlParameter("@LastLoginTime", SqlDbType.DateTime,8),
                    new SqlParameter("@LastLoginIP", SqlDbType.NVarChar,100),
                    new SqlParameter("@LoginCount", SqlDbType.Int,4),
                    new SqlParameter("@RegIP", SqlDbType.NVarChar,100),
                    new SqlParameter("@RegURL", SqlDbType.NVarChar,100),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@RegType", SqlDbType.Int,4),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Effect", SqlDbType.Int,4),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
                    new SqlParameter("@ErrorCount", SqlDbType.Int,4),
                    new SqlParameter("@LastErrTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Money", SqlDbType.Decimal,9),
                    new SqlParameter("@QQ", SqlDbType.NVarChar,100),
                    new SqlParameter("@JIFen", SqlDbType.Int,4),
                    new SqlParameter("@AddressID", SqlDbType.Int,4),
                    new SqlParameter("@IDCard", SqlDbType.NVarChar,100),
                    new SqlParameter("@IDCardImgZheng", SqlDbType.NVarChar,500),
                    new SqlParameter("@IDCardImgBei", SqlDbType.NVarChar,500),
                    new SqlParameter("@IDCardImgShouChi", SqlDbType.NVarChar,500),
                    new SqlParameter("@LivePlace", SqlDbType.NVarChar,500),
                    new SqlParameter("@WorkPlace", SqlDbType.NVarChar,500),
                    new SqlParameter("@JobName", SqlDbType.NVarChar,100),
                    new SqlParameter("@JobAge", SqlDbType.NVarChar,100),
                    new SqlParameter("@JobCompanyPhone", SqlDbType.NVarChar,100),
                    new SqlParameter("@JobMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@ContactMan", SqlDbType.NVarChar,500),
                    new SqlParameter("@ContactMan2", SqlDbType.NVarChar,500),
                    new SqlParameter("@BankName", SqlDbType.NVarChar,100),
                    new SqlParameter("@BankCardNO", SqlDbType.NVarChar,100),
                    new SqlParameter("@JobCompanyName", SqlDbType.NVarChar,100),
                    new SqlParameter("@RZState", SqlDbType.Int,4),
                    new SqlParameter("@RzMemo", SqlDbType.NVarChar,500),
                    new SqlParameter("@IDCardSelf", SqlDbType.NVarChar,500),
                    new SqlParameter("@BuC", SqlDbType.NVarChar,500),
                    new SqlParameter("@BuC2", SqlDbType.NVarChar,500),
                    new SqlParameter("@BuC3", SqlDbType.NVarChar,500),
                    new SqlParameter("@BuC4", SqlDbType.NVarChar,500),
                    new SqlParameter("@BuC5", SqlDbType.NVarChar,500),
                    new SqlParameter("@BuC6", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.Account;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.RealName;
            parameters[3].Value = model.Phone;
            parameters[4].Value = model.Pwd;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.Sex;
            parameters[7].Value = model.LastLoginTime;
            parameters[8].Value = model.LastLoginIP;
            parameters[9].Value = model.LoginCount;
            parameters[10].Value = model.RegIP;
            parameters[11].Value = model.RegURL;
            parameters[12].Value = model.AddTime;
            parameters[13].Value = model.RegType;
            parameters[14].Value = model.UpdateTime;
            parameters[15].Value = model.Effect;
            parameters[16].Value = model.Memo;
            parameters[17].Value = model.ErrorCount;
            parameters[18].Value = model.LastErrTime;
            parameters[19].Value = model.Money;
            parameters[20].Value = model.QQ;
            parameters[21].Value = model.JIFen;
            parameters[22].Value = model.AddressID;
            parameters[23].Value = model.IDCard;
            parameters[24].Value = model.IDCardImgZheng;
            parameters[25].Value = model.IDCardImgBei;
            parameters[26].Value = model.IDCardImgShouChi;
            parameters[27].Value = model.LivePlace;
            parameters[28].Value = model.WorkPlace;
            parameters[29].Value = model.JobName;
            parameters[30].Value = model.JobAge;
            parameters[31].Value = model.JobCompanyPhone;
            parameters[32].Value = model.JobMoney;
            parameters[33].Value = model.ContactMan;
            parameters[34].Value = model.ContactMan2;
            parameters[35].Value = model.BankName;
            parameters[36].Value = model.BankCardNO;
            parameters[37].Value = model.JobCompanyName;
            parameters[38].Value = model.RZState;
            parameters[39].Value = model.RzMemo;
            parameters[40].Value = model.IDCardSelf;
            parameters[41].Value = model.BuC;
            parameters[42].Value = model.BuC2;
            parameters[43].Value = model.BuC3;
            parameters[44].Value = model.BuC4;
            parameters[45].Value = model.BuC5;
            parameters[46].Value = model.BuC6;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        public int Y_UserRegphone(Model.Y_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Y_User(");
            strSql.Append("Account,Phone,Name,Pwd,LastLoginTime,LastLoginIP,LoginCount,RegIP,RegURL,AddTime,UpdateTime,Effect,Money)");
            strSql.Append(" VALUES (");
            strSql.Append("@Account,@Phone,@Name,@Pwd,@LastLoginTime,@LastLoginIP,@LoginCount,@RegIP,@RegURL,@AddTime,@UpdateTime,@Effect,@Money)");
            SqlParameter[] parameters = {
		            new SqlParameter("@Account", SqlDbType.NVarChar,100),
		            new SqlParameter("@Phone", SqlDbType.NVarChar,100),
                    new SqlParameter("@Name", SqlDbType.NVarChar,100),
                    new SqlParameter("@Pwd", SqlDbType.NVarChar,500),
		            new SqlParameter("@LastLoginTime", SqlDbType.DateTime,8),
		            new SqlParameter("@LastLoginIP", SqlDbType.NVarChar,100),
		            new SqlParameter("@LoginCount", SqlDbType.Int,4),
		            new SqlParameter("@RegIP", SqlDbType.NVarChar,100),
		            new SqlParameter("@RegURL", SqlDbType.NVarChar,100),
		            new SqlParameter("@AddTime", SqlDbType.DateTime,8),
		            new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
		            new SqlParameter("@Effect", SqlDbType.Int,4),
            new SqlParameter("@Money", SqlDbType.Decimal,9)};
            parameters[0].Value = model.Account;
            parameters[1].Value = model.Phone;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Pwd;
            parameters[4].Value = model.LastLoginTime;
            parameters[5].Value = model.LastLoginIP;
            parameters[6].Value = model.LoginCount;
            parameters[7].Value = model.RegIP;
            parameters[8].Value = model.RegURL;
            parameters[9].Value = model.AddTime;
            parameters[10].Value = model.UpdateTime;
            parameters[11].Value = model.Effect;
            parameters[12].Value = model.Money;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表Y_User)
        /// </summary>
        public int Y_UserUpdate(Model.Y_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Y_User SET ");
            strSql.Append("Account=@Account,");
            strSql.Append("Name=@Name,");
            strSql.Append("RealName=@RealName,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("Email=@Email,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("LastLoginTime=@LastLoginTime,");
            strSql.Append("LastLoginIP=@LastLoginIP,");
            strSql.Append("LoginCount=@LoginCount,");
            strSql.Append("RegIP=@RegIP,");
            strSql.Append("RegURL=@RegURL,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("RegType=@RegType,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("Effect=@Effect,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("ErrorCount=@ErrorCount,");
            strSql.Append("LastErrTime=@LastErrTime,");
            strSql.Append("Money=@Money,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("JIFen=@JIFen,");
            strSql.Append("AddressID=@AddressID,");
            strSql.Append("IDCard=@IDCard,");
            strSql.Append("IDCardImgZheng=@IDCardImgZheng,");
            strSql.Append("IDCardImgBei=@IDCardImgBei,");
            strSql.Append("IDCardImgShouChi=@IDCardImgShouChi,");
            strSql.Append("LivePlace=@LivePlace,");
            strSql.Append("WorkPlace=@WorkPlace,");
            strSql.Append("JobName=@JobName,");
            strSql.Append("JobAge=@JobAge,");
            strSql.Append("JobCompanyPhone=@JobCompanyPhone,");
            strSql.Append("JobMoney=@JobMoney,");
            strSql.Append("ContactMan=@ContactMan,");
            strSql.Append("ContactMan2=@ContactMan2,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("BankCardNO=@BankCardNO,");
            strSql.Append("JobCompanyName=@JobCompanyName,");
            strSql.Append("RZState=@RZState,");
            strSql.Append("RzMemo=@RzMemo,");
            strSql.Append("IDCardSelf=@IDCardSelf,");
            strSql.Append("BuC=@BuC,");
            strSql.Append("BuC2=@BuC2,");
            strSql.Append("BuC3=@BuC3,");
            strSql.Append("BuC4=@BuC4,");
            strSql.Append("BuC5=@BuC5,");
            strSql.Append("BuC6=@BuC6");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Account", SqlDbType.NVarChar,100),
               new SqlParameter("@Name", SqlDbType.NVarChar,100),
               new SqlParameter("@RealName", SqlDbType.NVarChar,100),
               new SqlParameter("@Phone", SqlDbType.NVarChar,100),
               new SqlParameter("@Pwd", SqlDbType.NVarChar,500),
               new SqlParameter("@Email", SqlDbType.NVarChar,100),
               new SqlParameter("@Sex", SqlDbType.Int,4),
               new SqlParameter("@LastLoginTime", SqlDbType.DateTime,8),
               new SqlParameter("@LastLoginIP", SqlDbType.NVarChar,100),
               new SqlParameter("@LoginCount", SqlDbType.Int,4),
               new SqlParameter("@RegIP", SqlDbType.NVarChar,100),
               new SqlParameter("@RegURL", SqlDbType.NVarChar,100),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@RegType", SqlDbType.Int,4),
               new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
               new SqlParameter("@Effect", SqlDbType.Int,4),
               new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
               new SqlParameter("@ErrorCount", SqlDbType.Int,4),
               new SqlParameter("@LastErrTime", SqlDbType.DateTime,8),
               new SqlParameter("@Money", SqlDbType.Decimal,9),
               new SqlParameter("@QQ", SqlDbType.NVarChar,100),
               new SqlParameter("@JIFen", SqlDbType.Int,4),
               new SqlParameter("@AddressID", SqlDbType.Int,4),
               new SqlParameter("@IDCard", SqlDbType.NVarChar,100),
               new SqlParameter("@IDCardImgZheng", SqlDbType.NVarChar,500),
               new SqlParameter("@IDCardImgBei", SqlDbType.NVarChar,500),
               new SqlParameter("@IDCardImgShouChi", SqlDbType.NVarChar,500),
               new SqlParameter("@LivePlace", SqlDbType.NVarChar,500),
               new SqlParameter("@WorkPlace", SqlDbType.NVarChar,500),
               new SqlParameter("@JobName", SqlDbType.NVarChar,100),
               new SqlParameter("@JobAge", SqlDbType.NVarChar,100),
               new SqlParameter("@JobCompanyPhone", SqlDbType.NVarChar,100),
               new SqlParameter("@JobMoney", SqlDbType.Decimal,9),
               new SqlParameter("@ContactMan", SqlDbType.NVarChar,500),
               new SqlParameter("@ContactMan2", SqlDbType.NVarChar,500),
               new SqlParameter("@BankName", SqlDbType.NVarChar,100),
               new SqlParameter("@BankCardNO", SqlDbType.NVarChar,100),
               new SqlParameter("@JobCompanyName", SqlDbType.NVarChar,100),
               new SqlParameter("@RZState", SqlDbType.Int,4),
               new SqlParameter("@RzMemo", SqlDbType.NVarChar,500),
               new SqlParameter("@IDCardSelf", SqlDbType.NVarChar,500),
               new SqlParameter("@BuC", SqlDbType.NVarChar,500),
               new SqlParameter("@BuC2", SqlDbType.NVarChar,500),
               new SqlParameter("@BuC3", SqlDbType.NVarChar,500),
               new SqlParameter("@BuC4", SqlDbType.NVarChar,500),
               new SqlParameter("@BuC5", SqlDbType.NVarChar,500),
               new SqlParameter("@BuC6", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Account;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.RealName;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.Pwd;
            parameters[6].Value = model.Email;
            parameters[7].Value = model.Sex;
            parameters[8].Value = model.LastLoginTime;
            parameters[9].Value = model.LastLoginIP;
            parameters[10].Value = model.LoginCount;
            parameters[11].Value = model.RegIP;
            parameters[12].Value = model.RegURL;
            parameters[13].Value = model.AddTime;
            parameters[14].Value = model.RegType;
            parameters[15].Value = model.UpdateTime;
            parameters[16].Value = model.Effect;
            parameters[17].Value = model.Memo;
            parameters[18].Value = model.ErrorCount;
            parameters[19].Value = model.LastErrTime;
            parameters[20].Value = model.Money;
            parameters[21].Value = model.QQ;
            parameters[22].Value = model.JIFen;
            parameters[23].Value = model.AddressID;
            parameters[24].Value = model.IDCard;
            parameters[25].Value = model.IDCardImgZheng;
            parameters[26].Value = model.IDCardImgBei;
            parameters[27].Value = model.IDCardImgShouChi;
            parameters[28].Value = model.LivePlace;
            parameters[29].Value = model.WorkPlace;
            parameters[30].Value = model.JobName;
            parameters[31].Value = model.JobAge;
            parameters[32].Value = model.JobCompanyPhone;
            parameters[33].Value = model.JobMoney;
            parameters[34].Value = model.ContactMan;
            parameters[35].Value = model.ContactMan2;
            parameters[36].Value = model.BankName;
            parameters[37].Value = model.BankCardNO;
            parameters[38].Value = model.JobCompanyName;
            parameters[39].Value = model.RZState;
            parameters[40].Value = model.RzMemo;
            parameters[41].Value = model.IDCardSelf;
            parameters[42].Value = model.BuC;
            parameters[43].Value = model.BuC2;
            parameters[44].Value = model.BuC3;
            parameters[45].Value = model.BuC4;
            parameters[46].Value = model.BuC5;
            parameters[47].Value = model.BuC6;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int Y_UserUpdateAddress(Model.Y_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Y_User set ");
            strSql.Append("AddressID=@AddressID");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
		            new SqlParameter("@ID", SqlDbType.Int,4),
		            new SqlParameter("@AddressID", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.AddressID;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int Y_UserUpdate_info(Model.Y_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Y_User SET ");
            strSql.Append("RealName=@RealName,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Email=@Email,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("QQ=@QQ");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@RealName", SqlDbType.NVarChar,100),
               new SqlParameter("@Phone", SqlDbType.NVarChar,100),
               new SqlParameter("@Email", SqlDbType.NVarChar,100),
               new SqlParameter("@Sex", SqlDbType.Int,4),
               new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
               new SqlParameter("@QQ", SqlDbType.NVarChar,100)
              };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.RealName;
            parameters[2].Value = model.Phone;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.UpdateTime;
            parameters[6].Value = model.QQ;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int Y_UserUpdate_BuC(Model.Y_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Y_User SET ");
            strSql.Append("BuC=@BuC,");
            strSql.Append("BuC2=@BuC2,");
            strSql.Append("BuC3=@BuC3,");
            strSql.Append("BuC4=@BuC4,");
            strSql.Append("BuC5=@BuC5,");
            strSql.Append("BuC6=@BuC6");
            strSql.Append(" WHERE phone=@phone");
            SqlParameter[] parameters = {
                new SqlParameter("@phone", SqlDbType.NVarChar,100),
               new SqlParameter("@BuC", SqlDbType.NVarChar,100),
               new SqlParameter("@BuC2", SqlDbType.NVarChar,100),
               new SqlParameter("@BuC3", SqlDbType.NVarChar,100),
               new SqlParameter("@BuC4", SqlDbType.NVarChar,100),
               new SqlParameter("@BuC5", SqlDbType.NVarChar,100),
               new SqlParameter("@BuC6", SqlDbType.NVarChar,100)
              };
            parameters[0].Value = model.Phone;
            parameters[1].Value = model.BuC;
            parameters[2].Value = model.BuC2;
            parameters[3].Value = model.BuC3;
            parameters[4].Value = model.BuC4;
            parameters[5].Value = model.BuC5;
            parameters[6].Value = model.BuC6;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int Y_UserUpdate_Bank(string BName,string Bno,string phone,int rzstate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Y_User SET ");
            strSql.Append("BankName=@BankName,");
            strSql.Append("BankCardNO=@BankCardNO,");
            strSql.Append("RZState=@RZState");
            strSql.Append(" WHERE phone=@phone and Effect=1");
            SqlParameter[] parameters = {
               new SqlParameter("@BankName", SqlDbType.NVarChar,100),
               new SqlParameter("@BankCardNO", SqlDbType.NVarChar,100),
                     new SqlParameter("@RZState", SqlDbType.Int,4),
               new SqlParameter("@phone", SqlDbType.NVarChar,100)
      
              };
            parameters[0].Value = BName;
            parameters[1].Value = Bno;
            parameters[2].Value = rzstate;
            parameters[3].Value = phone;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int Y_UserUpdate_info_Member(Model.Y_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Y_User SET ");
            strSql.Append("JobCompanyName=@JobCompanyName,");
            strSql.Append("JobName=@JobName,");
            strSql.Append("JobCompanyPhone=@JobCompanyPhone,");
            strSql.Append("JobAge=@JobAge,");
            strSql.Append("JobMoney=@JobMoney,");
            strSql.Append("WorkPlace=@WorkPlace,");
            strSql.Append("LivePlace=@LivePlace,");
            strSql.Append("ContactMan=@ContactMan,");
            strSql.Append("ContactMan2=@ContactMan2");
            strSql.Append(" WHERE Phone=@Phone and Effect=1");
            SqlParameter[] parameters = {
                new SqlParameter("@Phone", SqlDbType.NVarChar,100),
               new SqlParameter("@JobCompanyName", SqlDbType.NVarChar,100),
               new SqlParameter("@JobName", SqlDbType.NVarChar,100),
               new SqlParameter("@JobCompanyPhone", SqlDbType.NVarChar,100),
               new SqlParameter("@JobAge", SqlDbType.NVarChar,100),
               new SqlParameter("@JobMoney", SqlDbType.Decimal,9),
               new SqlParameter("@WorkPlace", SqlDbType.NVarChar,100),
               new SqlParameter("@LivePlace", SqlDbType.NVarChar,100),
               new SqlParameter("@ContactMan", SqlDbType.NVarChar,100),
                new SqlParameter("@ContactMan2", SqlDbType.NVarChar,100)
              };
            parameters[0].Value = model.Phone;
            parameters[1].Value = model.JobCompanyName;
            parameters[2].Value = model.JobName;
            parameters[3].Value = model.JobCompanyPhone;
            parameters[4].Value = model.JobAge;
            parameters[5].Value = model.JobMoney;
            parameters[6].Value = model.WorkPlace;
            parameters[7].Value = model.LivePlace;
            parameters[8].Value = model.ContactMan;
            parameters[9].Value = model.ContactMan2;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int Y_UserUpdate_logininfo(Model.Y_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Y_User SET ");
            strSql.Append("LoginCount=@LoginCount,");
            strSql.Append("LastLoginIP=@LastLoginIP,");
            strSql.Append("LastLoginTime=@LastLoginTime");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@LoginCount", SqlDbType.Int,4),
               new SqlParameter("@LastLoginIP", SqlDbType.NVarChar,100),
               new SqlParameter("@LastLoginTime", SqlDbType.DateTime,8)

              };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.LoginCount;
            parameters[2].Value = model.LastLoginIP;
            parameters[3].Value = model.LastLoginTime;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int Y_UserUpdate_infoHT(Model.Y_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Y_User set ");
            strSql.Append("RealName=@RealName,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("Memo=@Memo");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
		            new SqlParameter("@ID", SqlDbType.Int,4),
		            new SqlParameter("@RealName", SqlDbType.NVarChar,100),
		            new SqlParameter("@Phone", SqlDbType.NVarChar,100),
		            new SqlParameter("@Pwd", SqlDbType.NVarChar,500),
		            new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
		            new SqlParameter("@Memo", SqlDbType.NVarChar,1000)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.RealName;
            parameters[2].Value = model.Phone;
            parameters[3].Value = model.Pwd;
            parameters[4].Value = model.UpdateTime;
            parameters[5].Value = model.Memo;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int Y_UserUpdateErr(Model.Y_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Y_User set ");
            strSql.Append("ErrorCount=@ErrorCount,");
            strSql.Append("LastErrTime=@LastErrTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
		            new SqlParameter("@ID", SqlDbType.Int,4),
		            new SqlParameter("@ErrorCount", SqlDbType.Int,4),
		            new SqlParameter("@LastErrTime", SqlDbType.DateTime,8)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ErrorCount;
            parameters[2].Value = model.LastErrTime;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int Y_UserUpdateEnable(Model.Y_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Y_User set ");
            strSql.Append("Effect=@Effect");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
		            new SqlParameter("@ID", SqlDbType.Int,4),
		            new SqlParameter("@Effect", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Effect;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int Y_UserUpdateMoney(decimal money,int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Y_User set ");
            strSql.Append("Money=@Money");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@Money", SqlDbType.Decimal,9)};
            parameters[0].Value = uid;
            parameters[1].Value = money;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int Y_UserUpdateRZstate(Model.Y_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Y_User set ");
            strSql.Append("RZState=@RZState");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@RZState", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.RZState;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int Y_UserUpdateRZ(Model.Y_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Y_User set ");
            strSql.Append("RealName=@RealName,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("IDCard=@IDCard,");
            strSql.Append("IDCardImgZheng=@IDCardImgZheng,");
            strSql.Append("IDCardImgBei=@IDCardImgBei,");
            strSql.Append("IDCardImgShouChi=@IDCardImgShouChi,");
            strSql.Append("IDCardSelf=@IDCardSelf");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                     new SqlParameter("@RealName", SqlDbType.NVarChar,100),
                    new SqlParameter("@Sex", SqlDbType.Int,4),
                      new SqlParameter("@IDCard", SqlDbType.NVarChar,100),
                      new SqlParameter("@IDCardImgZheng", SqlDbType.NVarChar,100),
                       new SqlParameter("@IDCardImgBei", SqlDbType.NVarChar,100),
                      new SqlParameter("@IDCardImgShouChi", SqlDbType.NVarChar,100),
                       new SqlParameter("@IDCardSelf", SqlDbType.NVarChar,100)
                  
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.RealName;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.IDCard;
            parameters[4].Value = model.IDCardImgZheng;
            parameters[5].Value = model.IDCardImgBei;
            parameters[6].Value = model.IDCardImgShouChi;
            parameters[7].Value = model.IDCardSelf;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int Y_UserUpdateRZIDCard(Model.Y_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Y_User set ");
            strSql.Append("RealName=@RealName,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("IDCard=@IDCard");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                     new SqlParameter("@RealName", SqlDbType.NVarChar,100),
                    new SqlParameter("@Sex", SqlDbType.Int,4),
                      new SqlParameter("@IDCard", SqlDbType.NVarChar,100)
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.RealName;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.IDCard;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int Y_UserUpdate_pwd(Model.Y_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Y_User set ");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("UpdateTime=@UpdateTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
		            new SqlParameter("@ID", SqlDbType.Int,4),
		            new SqlParameter("@Pwd", SqlDbType.NVarChar,250),
		            new SqlParameter("@UpdateTime", SqlDbType.DateTime,8)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Pwd;
            parameters[2].Value = model.UpdateTime;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.Y_User GetModelByY_User(int ID)
        {
            string sql = string.Format("SELECT * FROM Y_User WITH(NOLOCK) WHERE ID={0}", ID);
            Model.Y_User model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.Y_User();
                    }
                    model = ConvetToY_User(reader, "All");
                }
            }
            return model;
        }

        public Model.Y_User GetModelByY_UserAccount(string Account)
        {
            string sql = string.Format("SELECT * FROM Y_User WITH(NOLOCK) WHERE Account='{0}'", Account);
            Model.Y_User model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.Y_User();
                    }
                    model = ConvetToY_User(reader, "All");
                }
            }
            return model;
        }


        public Model.Y_User GetModelByY_UserPhone(string Phone)
        {
            string sql = string.Format("SELECT * FROM Y_User WITH(NOLOCK) WHERE Phone='{0}'", Phone);
            Model.Y_User model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.Y_User();
                    }
                    model = ConvetToY_User(reader, "All");
                }
            }
            return model;
        }

        public Model.Y_User GetModelByY_UserPhoneAndEffect(string Phone)
        {
            string sql = string.Format("SELECT * FROM Y_User WITH(NOLOCK) WHERE Phone='{0}' and effect=1", Phone);
            Model.Y_User model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.Y_User();
                    }
                    model = ConvetToY_User(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Y_User> GetListY_User(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.Y_User> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "Y_User", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.Y_User>();
                    }
                    list.Add(ConvetToY_User(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.Y_User> GetPageY_User(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.Y_User> list = new List<Yax.Model.Y_User>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "Y_User", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToY_User(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
