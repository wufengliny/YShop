using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// OrderItem
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表OrderItem)
        /// </summary>
        public static Model.OrderItem ConvertToOrderItem(DataRow dr)
        {
            Model.OrderItem model = new Model.OrderItem();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.OrderNO = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["OrderNO"]) ? string.Empty : dr["OrderNO"].ToString();
            model.GoodID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["GoodID"]) ? 0 : int.Parse(dr["GoodID"].ToString());
            model.Num = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Num"]) ? 0 : int.Parse(dr["Num"].ToString());
            model.UnitPrice = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UnitPrice"]) ? 0 : decimal.Parse(dr["UnitPrice"].ToString());
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.BuyerMessage = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BuyerMessage"]) ? string.Empty : dr["BuyerMessage"].ToString();
            model.GoodName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["GoodName"]) ? string.Empty : dr["GoodName"].ToString();
            model.GoodType = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["GoodType"]) ? string.Empty : dr["GoodType"].ToString();
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.GoodImg = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["GoodImg"]) ? string.Empty : dr["GoodImg"].ToString();
            model.GoodMemo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["GoodMemo"]) ? string.Empty : dr["GoodMemo"].ToString();
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();
            model.UserID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UserID"]) ? 0 : int.Parse(dr["UserID"].ToString());
            model.IsCommented = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["IsCommented"]) ? 0 : int.Parse(dr["IsCommented"].ToString());

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表OrderItem)
        /// </summary>
        public static Model.OrderItem ConvetToOrderItem(SqlDataReader reader, string extParam)
        {
            Model.OrderItem model = new Model.OrderItem();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.OrderNO = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.GoodID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
            model.Num = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
            model.UnitPrice = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4);
            model.AddTime = reader.IsDBNull(5) ? System.DateTime.MinValue : reader.GetDateTime(5);
            model.BuyerMessage = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
            model.GoodName = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
            model.GoodType = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
            model.Enable = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);
            model.GoodImg = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
            model.GoodMemo = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
            model.Memo = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
            model.UserID = reader.IsDBNull(13) ? 0 : reader.GetInt32(13);
            model.IsCommented = reader.IsDBNull(14) ? 0 : reader.GetInt32(14);
            return model;
        }
        /// <summary>
        /// 增加一条数据(表OrderItem)
        /// </summary>
        public int OrderItemAdd(Model.OrderItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO OrderItem(");
            strSql.Append("OrderNO,GoodID,Num,UnitPrice,AddTime,BuyerMessage,GoodName,GoodType,Enable,GoodImg,GoodMemo,Memo,UserID)");
            strSql.Append(" VALUES (");
            strSql.Append("@OrderNO,@GoodID,@Num,@UnitPrice,@AddTime,@BuyerMessage,@GoodName,@GoodType,@Enable,@GoodImg,@GoodMemo,@Memo,@UserID)");
            SqlParameter[] parameters = {
		            new SqlParameter("@OrderNO", SqlDbType.NVarChar,500),
		            new SqlParameter("@GoodID", SqlDbType.Int,4),
		            new SqlParameter("@Num", SqlDbType.Int,4),
		            new SqlParameter("@UnitPrice", SqlDbType.Decimal,9),
		            new SqlParameter("@AddTime", SqlDbType.DateTime,8),
		            new SqlParameter("@BuyerMessage", SqlDbType.NVarChar,500),
		            new SqlParameter("@GoodName", SqlDbType.NVarChar,500),
		            new SqlParameter("@GoodType", SqlDbType.NVarChar,500),
		            new SqlParameter("@Enable", SqlDbType.Int,4),
		            new SqlParameter("@GoodImg", SqlDbType.NVarChar,500),
		            new SqlParameter("@GoodMemo", SqlDbType.NVarChar,500),
		            new SqlParameter("@Memo", SqlDbType.NVarChar,500),
		            new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = model.OrderNO;
            parameters[1].Value = model.GoodID;
            parameters[2].Value = model.Num;
            parameters[3].Value = model.UnitPrice;
            parameters[4].Value = model.AddTime;
            parameters[5].Value = model.BuyerMessage;
            parameters[6].Value = model.GoodName;
            parameters[7].Value = model.GoodType;
            parameters[8].Value = model.Enable;
            parameters[9].Value = model.GoodImg;
            parameters[10].Value = model.GoodMemo;
            parameters[11].Value = model.Memo;
            parameters[12].Value = model.UserID;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        /// <summary>
        /// 修改数据(表OrderItem)
        /// </summary>
        public int OrderItemUpdate(Model.OrderItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE OrderItem SET ");
            strSql.Append("OrderNO=@OrderNO,");
            strSql.Append("GoodID=@GoodID,");
            strSql.Append("Num=@Num,");
            strSql.Append("UnitPrice=@UnitPrice,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("BuyerMessage=@BuyerMessage,");
            strSql.Append("GoodName=@GoodName,");
            strSql.Append("GoodType=@GoodType,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("GoodImg=@GoodImg,");
            strSql.Append("GoodMemo=@GoodMemo,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("UserID=@UserID");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@OrderNO", SqlDbType.NVarChar,500),
               new SqlParameter("@GoodID", SqlDbType.Int,4),
               new SqlParameter("@Num", SqlDbType.Int,4),
               new SqlParameter("@UnitPrice", SqlDbType.Decimal,9),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@BuyerMessage", SqlDbType.NVarChar,500),
               new SqlParameter("@GoodName", SqlDbType.NVarChar,500),
               new SqlParameter("@GoodType", SqlDbType.NVarChar,500),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@GoodImg", SqlDbType.NVarChar,500),
               new SqlParameter("@GoodMemo", SqlDbType.NVarChar,500),
               new SqlParameter("@Memo", SqlDbType.NVarChar,500),
               new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.OrderNO;
            parameters[2].Value = model.GoodID;
            parameters[3].Value = model.Num;
            parameters[4].Value = model.UnitPrice;
            parameters[5].Value = model.AddTime;
            parameters[6].Value = model.BuyerMessage;
            parameters[7].Value = model.GoodName;
            parameters[8].Value = model.GoodType;
            parameters[9].Value = model.Enable;
            parameters[10].Value = model.GoodImg;
            parameters[11].Value = model.GoodMemo;
            parameters[12].Value = model.Memo;
            parameters[13].Value = model.UserID;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int OrderItemUpdate_IsComment(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrderItem set ");
            strSql.Append("IsCommented=1 ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
		            new SqlParameter("@ID", SqlDbType.Int,4)
		            };
            parameters[0].Value = id;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int OrderItemUpdate_Num(Model.OrderItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrderItem set ");
            strSql.Append("Num=@Num");
            strSql.Append(" where ID=@ID and UserID=@UserID");
            SqlParameter[] parameters = {
		            new SqlParameter("@ID", SqlDbType.Int,4),
		            new SqlParameter("@Num", SqlDbType.Int,4),
		            new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Num;
            parameters[2].Value = model.UserID;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int OrderItemUpdate_enableMember(Model.OrderItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrderItem set ");
            strSql.Append("Enable=@Enable");
            strSql.Append(" where ID=@ID and UserID=@UserID");
            SqlParameter[] parameters = {
		            new SqlParameter("@ID", SqlDbType.Int,4),
		            new SqlParameter("@Enable", SqlDbType.Int,4),
		            new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Enable;
            parameters[2].Value = model.UserID;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int OrderItemUpdate_orderno(int uid,string orderno)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrderItem set ");
            strSql.Append("OrderNO=@OrderNO");
            strSql.Append(" where UserID=@UserID and OrderNO='' and Enable=1 ");
            SqlParameter[] parameters = {
		            new SqlParameter("@OrderNO", SqlDbType.NVarChar,500),
		            new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = orderno;
            parameters[1].Value = uid;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.OrderItem GetModelByOrderItem(int ID)
        {
            string sql = string.Format("SELECT * FROM OrderItem WITH(NOLOCK) WHERE ID={0}", ID);
            Model.OrderItem model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.OrderItem();
                    }
                    model = ConvetToOrderItem(reader, "All");
                }
            }
            return model;
        }

        public Model.OrderItem GetModelByOrderItemGIDANDuid(int gid,int userid)
        {
            string sql = string.Format("SELECT * FROM OrderItem WITH(NOLOCK) WHERE GoodID={0} and UserID={1} and enable=1 and OrderNO='' ", gid, userid);
            Model.OrderItem model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.OrderItem();
                    }
                    model = ConvetToOrderItem(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.OrderItem> GetListOrderItem(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.OrderItem> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "OrderItem", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.OrderItem>();
                    }
                    list.Add(ConvetToOrderItem(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }


       
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.OrderItem> GetPageOrderItem(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.OrderItem> list = new List<Yax.Model.OrderItem>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "OrderItem", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToOrderItem(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
