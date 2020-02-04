using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// MoneyDetail
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表MoneyDetail)
        /// </summary>
        public static Model.MoneyDetail ConvertToMoneyDetail(DataRow dr)
        {
            Model.MoneyDetail model = new Model.MoneyDetail();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.UserID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UserID"]) ? 0 : int.Parse(dr["UserID"].ToString());
            model.Phone = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Phone"]) ? string.Empty : dr["Phone"].ToString();
            model.RealName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["RealName"]) ? string.Empty : dr["RealName"].ToString();
            model.Money = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Money"]) ? 0 : decimal.Parse(dr["Money"].ToString());
            model.PreMoney = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PreMoney"]) ? 0 : decimal.Parse(dr["PreMoney"].ToString());
            model.AfterMoney = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AfterMoney"]) ? 0 : decimal.Parse(dr["AfterMoney"].ToString());
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.OrderNO = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["OrderNO"]) ? string.Empty : dr["OrderNO"].ToString();
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();
            model.msgRecord = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["msgRecord"]) ? string.Empty : dr["msgRecord"].ToString();//后台充值时记录短信内容
            model.AdminID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AdminID"]) ? 0 : int.Parse(dr["AdminID"].ToString());
            model.CZtype = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["CZtype"]) ? 0 : int.Parse(dr["CZtype"].ToString());//1 后台充值 2
            model.MoneyType = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["MoneyType"]) ? string.Empty : dr["MoneyType"].ToString();//1 in  2  out

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表MoneyDetail)
        /// </summary>
        public static Model.MoneyDetail ConvetToMoneyDetail(SqlDataReader reader, string extParam)
        {
            Model.MoneyDetail model = new Model.MoneyDetail();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.UserID = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
            model.Phone = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            model.RealName = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
            model.Money = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4);
            model.PreMoney = reader.IsDBNull(5) ? 0 : reader.GetDecimal(5);
            model.AfterMoney = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6);
            model.AddTime = reader.IsDBNull(7) ? System.DateTime.MinValue : reader.GetDateTime(7);
            model.Enable = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
            model.OrderNO = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
            model.Memo = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
            model.msgRecord = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);//后台充值时记录短信内容
            model.AdminID = reader.IsDBNull(12) ? 0 : reader.GetInt32(12);
            model.CZtype = reader.IsDBNull(13) ? 0 : reader.GetInt32(13);//1 后台充值 2
            model.MoneyType = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);//1 in  2  out

            return model;
        }
        /// <summary>
        /// 增加一条数据(表MoneyDetail)
        /// </summary>
        public int MoneyDetailAdd(Model.MoneyDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO MoneyDetail(");
            strSql.Append("UserID,Phone,RealName,Money,PreMoney,AfterMoney,AddTime,Enable,OrderNO,Memo,msgRecord,AdminID,CZtype,MoneyType)");
            strSql.Append(" VALUES (");
            strSql.Append("@UserID,@Phone,@RealName,@Money,@PreMoney,@AfterMoney,@AddTime,@Enable,@OrderNO,@Memo,@msgRecord,@AdminID,@CZtype,@MoneyType)");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@Phone", SqlDbType.NVarChar,100),
                    new SqlParameter("@RealName", SqlDbType.NVarChar,100),
                    new SqlParameter("@Money", SqlDbType.Decimal,9),
                    new SqlParameter("@PreMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@AfterMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Enable", SqlDbType.Int,4),
                    new SqlParameter("@OrderNO", SqlDbType.NVarChar,100),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,100),
                    new SqlParameter("@msgRecord", SqlDbType.NVarChar,500),
                    new SqlParameter("@AdminID", SqlDbType.Int,4),
                    new SqlParameter("@CZtype", SqlDbType.Int,4),
                    new SqlParameter("@MoneyType", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.Phone;
            parameters[2].Value = model.RealName;
            parameters[3].Value = model.Money;
            parameters[4].Value = model.PreMoney;
            parameters[5].Value = model.AfterMoney;
            parameters[6].Value = model.AddTime;
            parameters[7].Value = model.Enable;
            parameters[8].Value = model.OrderNO;
            parameters[9].Value = model.Memo;
            parameters[10].Value = model.msgRecord;
            parameters[11].Value = model.AdminID;
            parameters[12].Value = model.CZtype;
            parameters[13].Value = model.MoneyType;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表MoneyDetail)
        /// </summary>
        public int MoneyDetailUpdate(Model.MoneyDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE MoneyDetail SET ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("RealName=@RealName,");
            strSql.Append("Money=@Money,");
            strSql.Append("PreMoney=@PreMoney,");
            strSql.Append("AfterMoney=@AfterMoney,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("OrderNO=@OrderNO,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("msgRecord=@msgRecord,");
            strSql.Append("AdminID=@AdminID,");
            strSql.Append("CZtype=@CZtype,");
            strSql.Append("MoneyType=@MoneyType");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@UserID", SqlDbType.Int,4),
               new SqlParameter("@Phone", SqlDbType.NVarChar,100),
               new SqlParameter("@RealName", SqlDbType.NVarChar,100),
               new SqlParameter("@Money", SqlDbType.Decimal,9),
               new SqlParameter("@PreMoney", SqlDbType.Decimal,9),
               new SqlParameter("@AfterMoney", SqlDbType.Decimal,9),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@OrderNO", SqlDbType.NVarChar,100),
               new SqlParameter("@Memo", SqlDbType.NVarChar,100),
               new SqlParameter("@msgRecord", SqlDbType.NVarChar,500),
               new SqlParameter("@AdminID", SqlDbType.Int,4),
               new SqlParameter("@CZtype", SqlDbType.Int,4),
               new SqlParameter("@MoneyType", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.Phone;
            parameters[3].Value = model.RealName;
            parameters[4].Value = model.Money;
            parameters[5].Value = model.PreMoney;
            parameters[6].Value = model.AfterMoney;
            parameters[7].Value = model.AddTime;
            parameters[8].Value = model.Enable;
            parameters[9].Value = model.OrderNO;
            parameters[10].Value = model.Memo;
            parameters[11].Value = model.msgRecord;
            parameters[12].Value = model.AdminID;
            parameters[13].Value = model.CZtype;
            parameters[14].Value = model.MoneyType;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.MoneyDetail GetModelByMoneyDetail(int ID)
        {
            string sql = string.Format("SELECT * FROM MoneyDetail WITH(NOLOCK) WHERE ID={0}", ID);
            Model.MoneyDetail model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.MoneyDetail();
                    }
                    model = ConvetToMoneyDetail(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.MoneyDetail> GetListMoneyDetail(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.MoneyDetail> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "MoneyDetail", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.MoneyDetail>();
                    }
                    list.Add(ConvetToMoneyDetail(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.MoneyDetail> GetPageMoneyDetail(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.MoneyDetail> list = new List<Yax.Model.MoneyDetail>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "MoneyDetail", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToMoneyDetail(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
