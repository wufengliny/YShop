using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// ShopOrder
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表ShopOrder)
        /// </summary>
        public static Model.ShopOrder ConvertToShopOrder(DataRow dr, string view = "table")
        {
            Model.ShopOrder model = new Model.ShopOrder();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.OrderNO = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["OrderNO"]) ? string.Empty : dr["OrderNO"].ToString();
            model.Statu = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Statu"]) ? 0 : int.Parse(dr["Statu"].ToString());//订单状态  0：待付款 1：待发货 2：待收货 3：交易完成 4：交易关闭
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.ThreeOrder = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ThreeOrder"]) ? string.Empty : dr["ThreeOrder"].ToString();//第三方订单号
            model.Introduce = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Introduce"]) ? string.Empty : dr["Introduce"].ToString();
            model.OrderMemo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["OrderMemo"]) ? string.Empty : dr["OrderMemo"].ToString();
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.PayTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PayTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["PayTime"].ToString());
            model.UserID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UserID"]) ? 0 : int.Parse(dr["UserID"].ToString());
            model.PayPrice = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PayPrice"]) ? 0 : decimal.Parse(dr["PayPrice"].ToString());
            model.TakeOverTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["TakeOverTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["TakeOverTime"].ToString()); //确认收货时间
            model.SendTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["SendTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["SendTime"].ToString());
            model.UpdateTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UpdateTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["UpdateTime"].ToString());
            model.WuliuNo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["WuliuNo"]) ? string.Empty : dr["WuliuNo"].ToString();
            model.WuliuName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["WuliuName"]) ? string.Empty : dr["WuliuName"].ToString();
            model.CutPrice = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["CutPrice"]) ? 0 : decimal.Parse(dr["CutPrice"].ToString()); //优惠费用
            model.WuLiuPrice = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["WuLiuPrice"]) ? 0 : decimal.Parse(dr["WuLiuPrice"].ToString());
            model.PayMethod = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PayMethod"]) ? 0 : int.Parse(dr["PayMethod"].ToString());

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表ShopOrder)
        /// </summary>
        public static Model.ShopOrder ConvetToShopOrder(SqlDataReader reader, string extParam)
        {
            Model.ShopOrder model = new Model.ShopOrder();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.OrderNO = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.Statu = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);//订单状态  0：待付款 1：待发货 2：待收货 3：交易完成 4：交易关闭
            model.AddTime = reader.IsDBNull(3) ? System.DateTime.MinValue : reader.GetDateTime(3);
            model.ThreeOrder = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);//第三方订单号
            model.Introduce = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
            model.OrderMemo = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
            model.Memo = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
            model.Enable = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
            model.PayTime = reader.IsDBNull(9) ? System.DateTime.MinValue : reader.GetDateTime(9);
            model.UserID = reader.IsDBNull(10) ? 0 : reader.GetInt32(10);
            model.PayPrice = reader.IsDBNull(11) ? 0 : reader.GetDecimal(11);
            model.TakeOverTime = reader.IsDBNull(12) ? System.DateTime.MinValue : reader.GetDateTime(12);//确认收货时间
            model.SendTime = reader.IsDBNull(13) ? System.DateTime.MinValue : reader.GetDateTime(13);
            model.UpdateTime = reader.IsDBNull(14) ? System.DateTime.MinValue : reader.GetDateTime(14);
            model.WuliuNo = reader.IsDBNull(15) ? string.Empty : reader.GetString(15);
            model.WuliuName = reader.IsDBNull(16) ? string.Empty : reader.GetString(16);
            model.CutPrice = reader.IsDBNull(17) ? 0 : reader.GetDecimal(17);//优惠费用
            model.WuLiuPrice = reader.IsDBNull(18) ? 0 : reader.GetDecimal(18);
            model.PayMethod = reader.IsDBNull(19) ? 0 : reader.GetInt32(19);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表ShopOrder)
        /// </summary>
        public int ShopOrderAdd(Model.ShopOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO ShopOrder(");
            strSql.Append("OrderNO,Statu,AddTime,ThreeOrder,Introduce,OrderMemo,Memo,Enable,PayTime,UserID,PayPrice,TakeOverTime,SendTime,UpdateTime,WuliuNo,WuliuName,CutPrice,WuLiuPrice,PayMethod)");
            strSql.Append(" VALUES (");
            strSql.Append("@OrderNO,@Statu,@AddTime,@ThreeOrder,@Introduce,@OrderMemo,@Memo,@Enable,@PayTime,@UserID,@PayPrice,@TakeOverTime,@SendTime,@UpdateTime,@WuliuNo,@WuliuName,@CutPrice,@WuLiuPrice,@PayMethod)");
            SqlParameter[] parameters = {
		            new SqlParameter("@OrderNO", SqlDbType.VarChar,250),
		            new SqlParameter("@Statu", SqlDbType.Int,4),
		            new SqlParameter("@AddTime", SqlDbType.DateTime,8),
		            new SqlParameter("@ThreeOrder", SqlDbType.VarChar,250),
		            new SqlParameter("@Introduce", SqlDbType.NVarChar,1000),
		            new SqlParameter("@OrderMemo", SqlDbType.NVarChar,100),
		            new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
		            new SqlParameter("@Enable", SqlDbType.Int,4),
		            new SqlParameter("@PayTime", SqlDbType.DateTime,8),
		            new SqlParameter("@UserID", SqlDbType.Int,4),
		            new SqlParameter("@PayPrice", SqlDbType.Decimal,9),
		            new SqlParameter("@TakeOverTime", SqlDbType.DateTime,8),
		            new SqlParameter("@SendTime", SqlDbType.DateTime,8),
		            new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
		            new SqlParameter("@WuliuNo", SqlDbType.VarChar,250),
		            new SqlParameter("@WuliuName", SqlDbType.NVarChar,100),
		            new SqlParameter("@CutPrice", SqlDbType.Decimal,9),
		            new SqlParameter("@WuLiuPrice", SqlDbType.Decimal,9),
		            new SqlParameter("@PayMethod", SqlDbType.Int,4)};
            parameters[0].Value = model.OrderNO;
            parameters[1].Value = model.Statu;
            parameters[2].Value = model.AddTime;
            parameters[3].Value = model.ThreeOrder;
            parameters[4].Value = model.Introduce;
            parameters[5].Value = model.OrderMemo;
            parameters[6].Value = model.Memo;
            parameters[7].Value = model.Enable;
            parameters[8].Value = model.PayTime;
            parameters[9].Value = model.UserID;
            parameters[10].Value = model.PayPrice;
            parameters[11].Value = model.TakeOverTime;
            parameters[12].Value = model.SendTime;
            parameters[13].Value = model.UpdateTime;
            parameters[14].Value = model.WuliuNo;
            parameters[15].Value = model.WuliuName;
            parameters[16].Value = model.CutPrice;
            parameters[17].Value = model.WuLiuPrice;
            parameters[18].Value = model.PayMethod;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表ShopOrder)
        /// </summary>
        public int ShopOrderUpdate(Model.ShopOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE ShopOrder SET ");
            strSql.Append("OrderNO=@OrderNO,");
            strSql.Append("Statu=@Statu,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("ThreeOrder=@ThreeOrder,");
            strSql.Append("Introduce=@Introduce,");
            strSql.Append("OrderMemo=@OrderMemo,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("PayTime=@PayTime,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("PayPrice=@PayPrice,");
            strSql.Append("TakeOverTime=@TakeOverTime,");
            strSql.Append("SendTime=@SendTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("WuliuNo=@WuliuNo,");
            strSql.Append("WuliuName=@WuliuName,");
            strSql.Append("CutPrice=@CutPrice,");
            strSql.Append("WuLiuPrice=@WuLiuPrice,");
            strSql.Append("PayMethod=@PayMethod");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@OrderNO", SqlDbType.VarChar,250),
               new SqlParameter("@Statu", SqlDbType.Int,4),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@ThreeOrder", SqlDbType.VarChar,250),
               new SqlParameter("@Introduce", SqlDbType.NVarChar,1000),
               new SqlParameter("@OrderMemo", SqlDbType.NVarChar,100),
               new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@PayTime", SqlDbType.DateTime,8),
               new SqlParameter("@UserID", SqlDbType.Int,4),
               new SqlParameter("@PayPrice", SqlDbType.Decimal,9),
               new SqlParameter("@TakeOverTime", SqlDbType.DateTime,8),
               new SqlParameter("@SendTime", SqlDbType.DateTime,8),
               new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
               new SqlParameter("@WuliuNo", SqlDbType.VarChar,250),
               new SqlParameter("@WuliuName", SqlDbType.NVarChar,100),
               new SqlParameter("@CutPrice", SqlDbType.Decimal,9),
               new SqlParameter("@WuLiuPrice", SqlDbType.Decimal,9),
               new SqlParameter("@PayMethod", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.OrderNO;
            parameters[2].Value = model.Statu;
            parameters[3].Value = model.AddTime;
            parameters[4].Value = model.ThreeOrder;
            parameters[5].Value = model.Introduce;
            parameters[6].Value = model.OrderMemo;
            parameters[7].Value = model.Memo;
            parameters[8].Value = model.Enable;
            parameters[9].Value = model.PayTime;
            parameters[10].Value = model.UserID;
            parameters[11].Value = model.PayPrice;
            parameters[12].Value = model.TakeOverTime;
            parameters[13].Value = model.SendTime;
            parameters[14].Value = model.UpdateTime;
            parameters[15].Value = model.WuliuNo;
            parameters[16].Value = model.WuliuName;
            parameters[17].Value = model.CutPrice;
            parameters[18].Value = model.WuLiuPrice;
            parameters[19].Value = model.PayMethod;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        public int ShopOrderUpdate_enable(Model.ShopOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ShopOrder set ");
            strSql.Append("Enable=@Enable");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
		            new SqlParameter("@ID", SqlDbType.Int,4),
		            new SqlParameter("@Enable", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Enable;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }



        public int ShopOrderUpdate_wuliu(Model.ShopOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ShopOrder set ");
            strSql.Append("WuliuNo=@WuliuNo,");
            strSql.Append("WuliuName=@WuliuName");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
		            new SqlParameter("@ID", SqlDbType.Int,4),
		            new SqlParameter("@WuliuNo", SqlDbType.VarChar,250),
		            new SqlParameter("@WuliuName", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.WuliuNo;
            parameters[2].Value = model.WuliuName;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int ShopOrderUpdate_statu(Model.ShopOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ShopOrder set ");
            strSql.Append("Statu=@Statu");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
		            new SqlParameter("@ID", SqlDbType.Int,4),
		            new SqlParameter("@Statu", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Statu;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.ShopOrder GetModelByShopOrder(int ID)
        {
            string sql = string.Format("SELECT * FROM ShopOrder WITH(NOLOCK) WHERE ID={0}", ID);
            Model.ShopOrder model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.ShopOrder();
                    }
                    model = ConvetToShopOrder(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.ShopOrder> GetListShopOrder(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.ShopOrder> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "ShopOrder", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.ShopOrder>();
                    }
                    list.Add(ConvetToShopOrder(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.ShopOrder> GetPageShopOrder(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.ShopOrder> list = new List<Yax.Model.ShopOrder>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "ShopOrder", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToShopOrder(dt.Rows[i]));
                }
            }
            return list;
        }

        public List<Yax.Model.ShopOrder> GetPageOrder_view(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.ShopOrder> list = new List<Yax.Model.ShopOrder>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "View_Order", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToShopOrder(dt.Rows[i], "view"));
                }
            }
            return list;
        }



    }
}
