using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// TiXian
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表TiXian)
        /// </summary>
        public static Model.TiXian ConvertToTiXian(DataRow dr)
        {
            Model.TiXian model = new Model.TiXian();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.OrderNO = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["OrderNO"]) ? string.Empty : dr["OrderNO"].ToString();//提现订单号
            model.RealName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["RealName"]) ? string.Empty : dr["RealName"].ToString();//提现人 真实姓名
            model.Phone = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Phone"]) ? string.Empty : dr["Phone"].ToString();
            model.BankName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BankName"]) ? string.Empty : dr["BankName"].ToString();
            model.BankNO = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BankNO"]) ? string.Empty : dr["BankNO"].ToString();
            model.Money = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Money"]) ? 0 : decimal.Parse(dr["Money"].ToString());
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.PreMoney = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PreMoney"]) ? 0 : decimal.Parse(dr["PreMoney"].ToString()); //提现前金额
            model.AfterMoney = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AfterMoney"]) ? 0 : decimal.Parse(dr["AfterMoney"].ToString()); //提现后剩余金额
            model.UserID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UserID"]) ? 0 : int.Parse(dr["UserID"].ToString());
            model.BankCardID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BankCardID"]) ? 0 : int.Parse(dr["BankCardID"].ToString());//会员银行卡表的ID
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.State = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["State"]) ? 0 : int.Parse(dr["State"].ToString());//1 未审核   2 审核不通过 3审核通过（已出款）
            model.ApproveID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ApproveID"]) ? 0 : int.Parse(dr["ApproveID"].ToString());//审核者的管理员ID
            model.ApproveTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ApproveTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["ApproveTime"].ToString());
            model.ApproveName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ApproveName"]) ? string.Empty : dr["ApproveName"].ToString();//管理员账户名
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();//备注

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表TiXian)
        /// </summary>
        public static Model.TiXian ConvetToTiXian(SqlDataReader reader, string extParam)
        {
            Model.TiXian model = new Model.TiXian();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.OrderNO = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);//提现订单号
            model.RealName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);//提现人 真实姓名
            model.Phone = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
            model.BankName = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
            model.BankNO = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
            model.Money = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6);
            model.AddTime = reader.IsDBNull(7) ? System.DateTime.MinValue : reader.GetDateTime(7);
            model.PreMoney = reader.IsDBNull(8) ? 0 : reader.GetDecimal(8);//提现前金额
            model.AfterMoney = reader.IsDBNull(9) ? 0 : reader.GetDecimal(9);//提现后剩余金额
            model.UserID = reader.IsDBNull(10) ? 0 : reader.GetInt32(10);
            model.BankCardID = reader.IsDBNull(11) ? 0 : reader.GetInt32(11);//会员银行卡表的ID
            model.Enable = reader.IsDBNull(12) ? 0 : reader.GetInt32(12);
            model.State = reader.IsDBNull(13) ? 0 : reader.GetInt32(13);//1 未审核   2 审核不通过 3审核通过（已出款）
            model.ApproveID = reader.IsDBNull(14) ? 0 : reader.GetInt32(14);//审核者的管理员ID
            model.ApproveTime = reader.IsDBNull(15) ? System.DateTime.MinValue : reader.GetDateTime(15);
            model.ApproveName = reader.IsDBNull(16) ? string.Empty : reader.GetString(16);//管理员账户名
            model.Memo = reader.IsDBNull(17) ? string.Empty : reader.GetString(17);//备注

            return model;
        }
        /// <summary>
        /// 增加一条数据(表TiXian)
        /// </summary>
        public int TiXianAdd(Model.TiXian model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO TiXian(");
            strSql.Append("OrderNO,RealName,Phone,BankName,BankNO,Money,AddTime,PreMoney,AfterMoney,UserID,BankCardID,Enable,State,ApproveID,ApproveTime,ApproveName,Memo)");
            strSql.Append(" VALUES (");
            strSql.Append("@OrderNO,@RealName,@Phone,@BankName,@BankNO,@Money,@AddTime,@PreMoney,@AfterMoney,@UserID,@BankCardID,@Enable,@State,@ApproveID,@ApproveTime,@ApproveName,@Memo)");
            SqlParameter[] parameters = {
		            new SqlParameter("@OrderNO", SqlDbType.NVarChar,100),
		            new SqlParameter("@RealName", SqlDbType.NVarChar,100),
		            new SqlParameter("@Phone", SqlDbType.NVarChar,100),
		            new SqlParameter("@BankName", SqlDbType.NVarChar,100),
		            new SqlParameter("@BankNO", SqlDbType.NVarChar,100),
		            new SqlParameter("@Money", SqlDbType.Decimal,9),
		            new SqlParameter("@AddTime", SqlDbType.DateTime,8),
		            new SqlParameter("@PreMoney", SqlDbType.Decimal,9),
		            new SqlParameter("@AfterMoney", SqlDbType.Decimal,9),
		            new SqlParameter("@UserID", SqlDbType.Int,4),
		            new SqlParameter("@BankCardID", SqlDbType.Int,4),
		            new SqlParameter("@Enable", SqlDbType.Int,4),
		            new SqlParameter("@State", SqlDbType.Int,4),
		            new SqlParameter("@ApproveID", SqlDbType.Int,4),
		            new SqlParameter("@ApproveTime", SqlDbType.DateTime,8),
		            new SqlParameter("@ApproveName", SqlDbType.NVarChar,100),
		            new SqlParameter("@Memo", SqlDbType.NVarChar,1000)};
            parameters[0].Value = model.OrderNO;
            parameters[1].Value = model.RealName;
            parameters[2].Value = model.Phone;
            parameters[3].Value = model.BankName;
            parameters[4].Value = model.BankNO;
            parameters[5].Value = model.Money;
            parameters[6].Value = model.AddTime;
            parameters[7].Value = model.PreMoney;
            parameters[8].Value = model.AfterMoney;
            parameters[9].Value = model.UserID;
            parameters[10].Value = model.BankCardID;
            parameters[11].Value = model.Enable;
            parameters[12].Value = model.State;
            parameters[13].Value = model.ApproveID;
            parameters[14].Value = model.ApproveTime;
            parameters[15].Value = model.ApproveName;
            parameters[16].Value = model.Memo;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表TiXian)
        /// </summary>
        public int TiXianUpdate(Model.TiXian model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TiXian SET ");
            strSql.Append("OrderNO=@OrderNO,");
            strSql.Append("RealName=@RealName,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("BankNO=@BankNO,");
            strSql.Append("Money=@Money,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("PreMoney=@PreMoney,");
            strSql.Append("AfterMoney=@AfterMoney,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("BankCardID=@BankCardID,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("State=@State,");
            strSql.Append("ApproveID=@ApproveID,");
            strSql.Append("ApproveTime=@ApproveTime,");
            strSql.Append("ApproveName=@ApproveName,");
            strSql.Append("Memo=@Memo");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@OrderNO", SqlDbType.NVarChar,100),
               new SqlParameter("@RealName", SqlDbType.NVarChar,100),
               new SqlParameter("@Phone", SqlDbType.NVarChar,100),
               new SqlParameter("@BankName", SqlDbType.NVarChar,100),
               new SqlParameter("@BankNO", SqlDbType.NVarChar,100),
               new SqlParameter("@Money", SqlDbType.Decimal,9),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@PreMoney", SqlDbType.Decimal,9),
               new SqlParameter("@AfterMoney", SqlDbType.Decimal,9),
               new SqlParameter("@UserID", SqlDbType.Int,4),
               new SqlParameter("@BankCardID", SqlDbType.Int,4),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@State", SqlDbType.Int,4),
               new SqlParameter("@ApproveID", SqlDbType.Int,4),
               new SqlParameter("@ApproveTime", SqlDbType.DateTime,8),
               new SqlParameter("@ApproveName", SqlDbType.NVarChar,100),
               new SqlParameter("@Memo", SqlDbType.NVarChar,1000)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.OrderNO;
            parameters[2].Value = model.RealName;
            parameters[3].Value = model.Phone;
            parameters[4].Value = model.BankName;
            parameters[5].Value = model.BankNO;
            parameters[6].Value = model.Money;
            parameters[7].Value = model.AddTime;
            parameters[8].Value = model.PreMoney;
            parameters[9].Value = model.AfterMoney;
            parameters[10].Value = model.UserID;
            parameters[11].Value = model.BankCardID;
            parameters[12].Value = model.Enable;
            parameters[13].Value = model.State;
            parameters[14].Value = model.ApproveID;
            parameters[15].Value = model.ApproveTime;
            parameters[16].Value = model.ApproveName;
            parameters[17].Value = model.Memo;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int TiXianUpdate_Enable(Model.TiXian model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TiXian SET ");
            strSql.Append("Enable=@Enable ");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Enable", SqlDbType.Int,4)
              };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Enable;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.TiXian GetModelByTiXian(int ID)
        {
            string sql = string.Format("SELECT * FROM TiXian WITH(NOLOCK) WHERE ID={0}", ID);
            Model.TiXian model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.TiXian();
                    }
                    model = ConvetToTiXian(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.TiXian> GetListTiXian(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.TiXian> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "TiXian", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.TiXian>();
                    }
                    list.Add(ConvetToTiXian(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.TiXian> GetPageTiXian(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.TiXian> list = new List<Yax.Model.TiXian>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "TiXian", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToTiXian(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
