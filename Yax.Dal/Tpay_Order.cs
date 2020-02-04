using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// Tpay_Order
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表Tpay_Order)
        /// </summary>
        public static Model.Tpay_Order ConvertToTpay_Order(DataRow dr)
        {
            Model.Tpay_Order model = new Model.Tpay_Order();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.OrderNum = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["OrderNum"]) ? string.Empty : dr["OrderNum"].ToString();//商户订单号
            model.out_trade_no = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["out_trade_no"]) ? string.Empty : dr["out_trade_no"].ToString();//平台订单号
            model.Trade_no = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Trade_no"]) ? string.Empty : dr["Trade_no"].ToString();//第三方订单号 支付宝或者微信
            model.Account = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Account"]) ? string.Empty : dr["Account"].ToString();//商户号
            model.UID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UID"]) ? 0 : int.Parse(dr["UID"].ToString());//商户ID
            model.PayState = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PayState"]) ? string.Empty : dr["PayState"].ToString();//1待支付 2已支付
            model.Price = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Price"]) ? 0 : decimal.Parse(dr["Price"].ToString());
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.PayTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PayTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["PayTime"].ToString());
            model.PayWay = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PayWay"]) ? string.Empty : dr["PayWay"].ToString();
            model.ZhongDuan = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ZhongDuan"]) ? string.Empty : dr["ZhongDuan"].ToString();
            model.RequestUrl = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["RequestUrl"]) ? string.Empty : dr["RequestUrl"].ToString();
            model.RefferUrl = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["RefferUrl"]) ? string.Empty : dr["RefferUrl"].ToString();
            model.ISDeal = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ISDeal"]) ? 0 : int.Parse(dr["ISDeal"].ToString());//客户端是否已经处理完这条数据 0   1
            model.redicUrl = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["redicUrl"]) ? string.Empty : dr["redicUrl"].ToString();
            model.noticeUrl = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["noticeUrl"]) ? string.Empty : dr["noticeUrl"].ToString();
            model.UserMark = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UserMark"]) ? string.Empty : dr["UserMark"].ToString();
            model.Title = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Title"]) ? string.Empty : dr["Title"].ToString();//商品标题
            model.AgentMoney = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AgentMoney"]) ? 0 : decimal.Parse(dr["AgentMoney"].ToString()); //代理分配的金额
            model.SHMoney = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["SHMoney"]) ? 0 : decimal.Parse(dr["SHMoney"].ToString()); //商户分配的金额
            model.PTMoney = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PTMoney"]) ? 0 : decimal.Parse(dr["PTMoney"].ToString()); //平台分配的金额
            model.KFMoney = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["KFMoney"]) ? 0 : decimal.Parse(dr["KFMoney"].ToString()); //系统商金额

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表Tpay_Order)
        /// </summary>
        public static Model.Tpay_Order ConvetToTpay_Order(SqlDataReader reader, string extParam)
        {
            Model.Tpay_Order model = new Model.Tpay_Order();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.OrderNum = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);//商户订单号
            model.out_trade_no = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);//平台订单号
            model.Trade_no = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);//第三方订单号 支付宝或者微信
            model.Account = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);//商户号
            model.UID = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);//商户ID
            model.PayState = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);//1待支付 2已支付
            model.Price = reader.IsDBNull(7) ? 0 : reader.GetDecimal(7);
            model.AddTime = reader.IsDBNull(8) ? System.DateTime.MinValue : reader.GetDateTime(8);
            model.PayTime = reader.IsDBNull(9) ? System.DateTime.MinValue : reader.GetDateTime(9);
            model.PayWay = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
            model.ZhongDuan = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
            model.RequestUrl = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
            model.RefferUrl = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
            model.ISDeal = reader.IsDBNull(14) ? 0 : reader.GetInt32(14);//客户端是否已经处理完这条数据 0   1
            model.redicUrl = reader.IsDBNull(15) ? string.Empty : reader.GetString(15);
            model.noticeUrl = reader.IsDBNull(16) ? string.Empty : reader.GetString(16);
            model.UserMark = reader.IsDBNull(17) ? string.Empty : reader.GetString(17);
            model.Title = reader.IsDBNull(18) ? string.Empty : reader.GetString(18);//商品标题
            model.AgentMoney = reader.IsDBNull(19) ? 0 : reader.GetDecimal(19);//代理分配的金额
            model.SHMoney = reader.IsDBNull(20) ? 0 : reader.GetDecimal(20);//商户分配的金额
            model.PTMoney = reader.IsDBNull(21) ? 0 : reader.GetDecimal(21);//平台分配的金额
            model.KFMoney = reader.IsDBNull(22) ? 0 : reader.GetDecimal(22);//系统商金额

            return model;
        }
        /// <summary>
        /// 增加一条数据(表Tpay_Order)
        /// </summary>
        public int Tpay_OrderAdd(Model.Tpay_Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Tpay_Order(");
            strSql.Append("OrderNum,out_trade_no,Trade_no,Account,UID,PayState,Price,AddTime,PayTime,PayWay,ZhongDuan,RequestUrl,RefferUrl,ISDeal,redicUrl,noticeUrl,UserMark,Title,AgentMoney,SHMoney,PTMoney,KFMoney)");
            strSql.Append(" VALUES (");
            strSql.Append("@OrderNum,@out_trade_no,@Trade_no,@Account,@UID,@PayState,@Price,@AddTime,@PayTime,@PayWay,@ZhongDuan,@RequestUrl,@RefferUrl,@ISDeal,@redicUrl,@noticeUrl,@UserMark,@Title,@AgentMoney,@SHMoney,@PTMoney,@KFMoney)");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderNum", SqlDbType.NVarChar,100),
                    new SqlParameter("@out_trade_no", SqlDbType.NVarChar,100),
                    new SqlParameter("@Trade_no", SqlDbType.NVarChar,100),
                    new SqlParameter("@Account", SqlDbType.NVarChar,100),
                    new SqlParameter("@UID", SqlDbType.Int,4),
                    new SqlParameter("@PayState", SqlDbType.NVarChar,100),
                    new SqlParameter("@Price", SqlDbType.Decimal,9),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@PayTime", SqlDbType.DateTime,8),
                    new SqlParameter("@PayWay", SqlDbType.NVarChar,20),
                    new SqlParameter("@ZhongDuan", SqlDbType.NVarChar,20),
                    new SqlParameter("@RequestUrl", SqlDbType.NVarChar,1000),
                    new SqlParameter("@RefferUrl", SqlDbType.NVarChar,1000),
                    new SqlParameter("@ISDeal", SqlDbType.Int,4),
                    new SqlParameter("@redicUrl", SqlDbType.NVarChar,500),
                    new SqlParameter("@noticeUrl", SqlDbType.NVarChar,500),
                    new SqlParameter("@UserMark", SqlDbType.NVarChar,100),
                    new SqlParameter("@Title", SqlDbType.NVarChar,100),
                    new SqlParameter("@AgentMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@SHMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@PTMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@KFMoney", SqlDbType.Decimal,9)};
            parameters[0].Value = model.OrderNum;
            parameters[1].Value = model.out_trade_no;
            parameters[2].Value = model.Trade_no;
            parameters[3].Value = model.Account;
            parameters[4].Value = model.UID;
            parameters[5].Value = model.PayState;
            parameters[6].Value = model.Price;
            parameters[7].Value = model.AddTime;
            parameters[8].Value = model.PayTime;
            parameters[9].Value = model.PayWay;
            parameters[10].Value = model.ZhongDuan;
            parameters[11].Value = model.RequestUrl;
            parameters[12].Value = model.RefferUrl;
            parameters[13].Value = model.ISDeal;
            parameters[14].Value = model.redicUrl;
            parameters[15].Value = model.noticeUrl;
            parameters[16].Value = model.UserMark;
            parameters[17].Value = model.Title;
            parameters[18].Value = model.AgentMoney;
            parameters[19].Value = model.SHMoney;
            parameters[20].Value = model.PTMoney;
            parameters[21].Value = model.KFMoney;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表Tpay_Order)
        /// </summary>
        public int Tpay_OrderUpdate(Model.Tpay_Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Tpay_Order SET ");
            strSql.Append("OrderNum=@OrderNum,");
            strSql.Append("out_trade_no=@out_trade_no,");
            strSql.Append("Trade_no=@Trade_no,");
            strSql.Append("Account=@Account,");
            strSql.Append("UID=@UID,");
            strSql.Append("PayState=@PayState,");
            strSql.Append("Price=@Price,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("PayTime=@PayTime,");
            strSql.Append("PayWay=@PayWay,");
            strSql.Append("ZhongDuan=@ZhongDuan,");
            strSql.Append("RequestUrl=@RequestUrl,");
            strSql.Append("RefferUrl=@RefferUrl,");
            strSql.Append("ISDeal=@ISDeal,");
            strSql.Append("redicUrl=@redicUrl,");
            strSql.Append("noticeUrl=@noticeUrl,");
            strSql.Append("UserMark=@UserMark,");
            strSql.Append("Title=@Title,");
            strSql.Append("AgentMoney=@AgentMoney,");
            strSql.Append("SHMoney=@SHMoney,");
            strSql.Append("PTMoney=@PTMoney,");
            strSql.Append("KFMoney=@KFMoney");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@OrderNum", SqlDbType.NVarChar,100),
               new SqlParameter("@out_trade_no", SqlDbType.NVarChar,100),
               new SqlParameter("@Trade_no", SqlDbType.NVarChar,100),
               new SqlParameter("@Account", SqlDbType.NVarChar,100),
               new SqlParameter("@UID", SqlDbType.Int,4),
               new SqlParameter("@PayState", SqlDbType.NVarChar,100),
               new SqlParameter("@Price", SqlDbType.Decimal,9),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@PayTime", SqlDbType.DateTime,8),
               new SqlParameter("@PayWay", SqlDbType.NVarChar,20),
               new SqlParameter("@ZhongDuan", SqlDbType.NVarChar,20),
               new SqlParameter("@RequestUrl", SqlDbType.NVarChar,1000),
               new SqlParameter("@RefferUrl", SqlDbType.NVarChar,1000),
               new SqlParameter("@ISDeal", SqlDbType.Int,4),
               new SqlParameter("@redicUrl", SqlDbType.NVarChar,500),
               new SqlParameter("@noticeUrl", SqlDbType.NVarChar,500),
               new SqlParameter("@UserMark", SqlDbType.NVarChar,100),
               new SqlParameter("@Title", SqlDbType.NVarChar,100),
               new SqlParameter("@AgentMoney", SqlDbType.Decimal,9),
               new SqlParameter("@SHMoney", SqlDbType.Decimal,9),
               new SqlParameter("@PTMoney", SqlDbType.Decimal,9),
               new SqlParameter("@KFMoney", SqlDbType.Decimal,9)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.OrderNum;
            parameters[2].Value = model.out_trade_no;
            parameters[3].Value = model.Trade_no;
            parameters[4].Value = model.Account;
            parameters[5].Value = model.UID;
            parameters[6].Value = model.PayState;
            parameters[7].Value = model.Price;
            parameters[8].Value = model.AddTime;
            parameters[9].Value = model.PayTime;
            parameters[10].Value = model.PayWay;
            parameters[11].Value = model.ZhongDuan;
            parameters[12].Value = model.RequestUrl;
            parameters[13].Value = model.RefferUrl;
            parameters[14].Value = model.ISDeal;
            parameters[15].Value = model.redicUrl;
            parameters[16].Value = model.noticeUrl;
            parameters[17].Value = model.UserMark;
            parameters[18].Value = model.Title;
            parameters[19].Value = model.AgentMoney;
            parameters[20].Value = model.SHMoney;
            parameters[21].Value = model.PTMoney;
            parameters[22].Value = model.KFMoney;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.Tpay_Order GetModelByTpay_Order(int ID)
        {
            string sql = string.Format("SELECT * FROM Tpay_Order WITH(NOLOCK) WHERE ID={0}", ID);
            Model.Tpay_Order model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.Tpay_Order();
                    }
                    model = ConvetToTpay_Order(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Tpay_Order> GetListTpay_Order(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.Tpay_Order> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "Tpay_Order", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.Tpay_Order>();
                    }
                    list.Add(ConvetToTpay_Order(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.Tpay_Order> GetPageTpay_Order(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.Tpay_Order> list = new List<Yax.Model.Tpay_Order>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "Tpay_Order", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToTpay_Order(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
