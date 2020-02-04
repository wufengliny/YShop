using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// CompanyBankCard
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表CompanyBankCard)
        /// </summary>
        public static Model.CompanyBankCard ConvertToCompanyBankCard(DataRow dr)
        {
            Model.CompanyBankCard model = new Model.CompanyBankCard();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.BankName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BankName"]) ? string.Empty : dr["BankName"].ToString();
            model.CardOwner = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["CardOwner"]) ? string.Empty : dr["CardOwner"].ToString();
            model.CardNO = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["CardNO"]) ? string.Empty : dr["CardNO"].ToString();
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表CompanyBankCard)
        /// </summary>
        public static Model.CompanyBankCard ConvetToCompanyBankCard(SqlDataReader reader, string extParam)
        {
            Model.CompanyBankCard model = new Model.CompanyBankCard();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.BankName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.CardOwner = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            model.CardNO = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
            model.Enable = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
            model.AddTime = reader.IsDBNull(5) ? System.DateTime.MinValue : reader.GetDateTime(5);
            model.Memo = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表CompanyBankCard)
        /// </summary>
        public int CompanyBankCardAdd(Model.CompanyBankCard model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO CompanyBankCard(");
            strSql.Append("BankName,CardOwner,CardNO,Enable,AddTime,Memo)");
            strSql.Append(" VALUES (");
            strSql.Append("@BankName,@CardOwner,@CardNO,@Enable,@AddTime,@Memo)");
            SqlParameter[] parameters = {
		            new SqlParameter("@BankName", SqlDbType.NVarChar,100),
		            new SqlParameter("@CardOwner", SqlDbType.NVarChar,100),
		            new SqlParameter("@CardNO", SqlDbType.NVarChar,100),
		            new SqlParameter("@Enable", SqlDbType.Int,4),
		            new SqlParameter("@AddTime", SqlDbType.DateTime,8),
		            new SqlParameter("@Memo", SqlDbType.NVarChar,1000)};
            parameters[0].Value = model.BankName;
            parameters[1].Value = model.CardOwner;
            parameters[2].Value = model.CardNO;
            parameters[3].Value = model.Enable;
            parameters[4].Value = model.AddTime;
            parameters[5].Value = model.Memo;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表CompanyBankCard)
        /// </summary>
        public int CompanyBankCardUpdate(Model.CompanyBankCard model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE CompanyBankCard SET ");
            strSql.Append("BankName=@BankName,");
            strSql.Append("CardOwner=@CardOwner,");
            strSql.Append("CardNO=@CardNO,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Memo=@Memo");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@BankName", SqlDbType.NVarChar,100),
               new SqlParameter("@CardOwner", SqlDbType.NVarChar,100),
               new SqlParameter("@CardNO", SqlDbType.NVarChar,100),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@Memo", SqlDbType.NVarChar,1000)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BankName;
            parameters[2].Value = model.CardOwner;
            parameters[3].Value = model.CardNO;
            parameters[4].Value = model.Enable;
            parameters[5].Value = model.AddTime;
            parameters[6].Value = model.Memo;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.CompanyBankCard GetModelByCompanyBankCard(int ID)
        {
            string sql = string.Format("SELECT * FROM CompanyBankCard WITH(NOLOCK) WHERE ID={0}", ID);
            Model.CompanyBankCard model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.CompanyBankCard();
                    }
                    model = ConvetToCompanyBankCard(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.CompanyBankCard> GetListCompanyBankCard(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.CompanyBankCard> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "CompanyBankCard", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.CompanyBankCard>();
                    }
                    list.Add(ConvetToCompanyBankCard(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.CompanyBankCard> GetPageCompanyBankCard(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.CompanyBankCard> list = new List<Yax.Model.CompanyBankCard>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "CompanyBankCard", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToCompanyBankCard(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
