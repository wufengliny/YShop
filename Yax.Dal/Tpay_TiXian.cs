using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// Tpay_TiXian
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表Tpay_TiXian)
        /// </summary>
        public static Model.Tpay_TiXian ConvertToTpay_TiXian(DataRow dr)
        {
            Model.Tpay_TiXian model = new Model.Tpay_TiXian();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.UID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UID"]) ? 0 : int.Parse(dr["UID"].ToString());//提现人ID  商户或者代理
            model.UAccount = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UAccount"]) ? string.Empty : dr["UAccount"].ToString();//提现人(商户号或者代理名称) 
            model.UType = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UType"]) ? 0 : int.Parse(dr["UType"].ToString());//1商户提现2 代理提现
            model.Money = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Money"]) ? 0 : decimal.Parse(dr["Money"].ToString());
            model.PreMoney = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PreMoney"]) ? 0 : decimal.Parse(dr["PreMoney"].ToString());
            model.AfterMoney = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AfterMoney"]) ? 0 : decimal.Parse(dr["AfterMoney"].ToString());
            model.AccountInfo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AccountInfo"]) ? string.Empty : dr["AccountInfo"].ToString();//提现账户信息
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.State = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["State"]) ? 0 : int.Parse(dr["State"].ToString());//1 未审核   2 审核不通过 3审核通过（已出款）
            model.ApproID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ApproID"]) ? 0 : int.Parse(dr["ApproID"].ToString());
            model.ApproName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ApproName"]) ? string.Empty : dr["ApproName"].ToString();
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();//审核通过，或者不通过管理员备注信息，客户可以看到
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表Tpay_TiXian)
        /// </summary>
        public static Model.Tpay_TiXian ConvetToTpay_TiXian(SqlDataReader reader, string extParam)
        {
            Model.Tpay_TiXian model = new Model.Tpay_TiXian();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.UID = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);//提现人ID  商户或者代理
            model.UAccount = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);//提现人(商户号或者代理名称) 
            model.UType = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);//1商户提现2 代理提现
            model.Money = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4);
            model.PreMoney = reader.IsDBNull(5) ? 0 : reader.GetDecimal(5);
            model.AfterMoney = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6);
            model.AccountInfo = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);//提现账户信息
            model.Enable = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
            model.State = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);//1 未审核   2 审核不通过 3审核通过（已出款）
            model.ApproID = reader.IsDBNull(10) ? 0 : reader.GetInt32(10);
            model.ApproName = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
            model.Memo = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);//审核通过，或者不通过管理员备注信息，客户可以看到
            model.AddTime = reader.IsDBNull(13) ? System.DateTime.MinValue : reader.GetDateTime(13);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表Tpay_TiXian)
        /// </summary>
        public int Tpay_TiXianAdd(Model.Tpay_TiXian model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Tpay_TiXian(");
            strSql.Append("UID,UAccount,UType,Money,PreMoney,AfterMoney,AccountInfo,Enable,State,ApproID,ApproName,Memo,AddTime)");
            strSql.Append(" VALUES (");
            strSql.Append("@UID,@UAccount,@UType,@Money,@PreMoney,@AfterMoney,@AccountInfo,@Enable,@State,@ApproID,@ApproName,@Memo,@AddTime)");
            SqlParameter[] parameters = {
                    new SqlParameter("@UID", SqlDbType.Int,4),
                    new SqlParameter("@UAccount", SqlDbType.NVarChar,100),
                    new SqlParameter("@UType", SqlDbType.Int,4),
                    new SqlParameter("@Money", SqlDbType.Decimal,9),
                    new SqlParameter("@PreMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@AfterMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@AccountInfo", SqlDbType.NVarChar,500),
                    new SqlParameter("@Enable", SqlDbType.Int,4),
                    new SqlParameter("@State", SqlDbType.Int,4),
                    new SqlParameter("@ApproID", SqlDbType.Int,4),
                    new SqlParameter("@ApproName", SqlDbType.NVarChar,100),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,500),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.UAccount;
            parameters[2].Value = model.UType;
            parameters[3].Value = model.Money;
            parameters[4].Value = model.PreMoney;
            parameters[5].Value = model.AfterMoney;
            parameters[6].Value = model.AccountInfo;
            parameters[7].Value = model.Enable;
            parameters[8].Value = model.State;
            parameters[9].Value = model.ApproID;
            parameters[10].Value = model.ApproName;
            parameters[11].Value = model.Memo;
            parameters[12].Value = model.AddTime;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表Tpay_TiXian)
        /// </summary>
        public int Tpay_TiXianUpdate(Model.Tpay_TiXian model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Tpay_TiXian SET ");
            strSql.Append("UID=@UID,");
            strSql.Append("UAccount=@UAccount,");
            strSql.Append("UType=@UType,");
            strSql.Append("Money=@Money,");
            strSql.Append("PreMoney=@PreMoney,");
            strSql.Append("AfterMoney=@AfterMoney,");
            strSql.Append("AccountInfo=@AccountInfo,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("State=@State,");
            strSql.Append("ApproID=@ApproID,");
            strSql.Append("ApproName=@ApproName,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("AddTime=@AddTime");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@UID", SqlDbType.Int,4),
               new SqlParameter("@UAccount", SqlDbType.NVarChar,100),
               new SqlParameter("@UType", SqlDbType.Int,4),
               new SqlParameter("@Money", SqlDbType.Decimal,9),
               new SqlParameter("@PreMoney", SqlDbType.Decimal,9),
               new SqlParameter("@AfterMoney", SqlDbType.Decimal,9),
               new SqlParameter("@AccountInfo", SqlDbType.NVarChar,500),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@State", SqlDbType.Int,4),
               new SqlParameter("@ApproID", SqlDbType.Int,4),
               new SqlParameter("@ApproName", SqlDbType.NVarChar,100),
               new SqlParameter("@Memo", SqlDbType.NVarChar,500),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UID;
            parameters[2].Value = model.UAccount;
            parameters[3].Value = model.UType;
            parameters[4].Value = model.Money;
            parameters[5].Value = model.PreMoney;
            parameters[6].Value = model.AfterMoney;
            parameters[7].Value = model.AccountInfo;
            parameters[8].Value = model.Enable;
            parameters[9].Value = model.State;
            parameters[10].Value = model.ApproID;
            parameters[11].Value = model.ApproName;
            parameters[12].Value = model.Memo;
            parameters[13].Value = model.AddTime;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.Tpay_TiXian GetModelByTpay_TiXian(int ID)
        {
            string sql = string.Format("SELECT * FROM Tpay_TiXian WITH(NOLOCK) WHERE ID={0}", ID);
            Model.Tpay_TiXian model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.Tpay_TiXian();
                    }
                    model = ConvetToTpay_TiXian(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Tpay_TiXian> GetListTpay_TiXian(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.Tpay_TiXian> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "Tpay_TiXian", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.Tpay_TiXian>();
                    }
                    list.Add(ConvetToTpay_TiXian(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.Tpay_TiXian> GetPageTpay_TiXian(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.Tpay_TiXian> list = new List<Yax.Model.Tpay_TiXian>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "Tpay_TiXian", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToTpay_TiXian(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
