using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// BankCard
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表BankCard)
        /// </summary>
        public static Model.BankCard ConvertToBankCard(DataRow dr)
        {
            Model.BankCard model = new Model.BankCard();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.BankNo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BankNo"]) ? string.Empty : dr["BankNo"].ToString();
            model.BankName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BankName"]) ? string.Empty : dr["BankName"].ToString();
            model.cardType = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["cardType"]) ? string.Empty : dr["cardType"].ToString();
            model.Area = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Area"]) ? string.Empty : dr["Area"].ToString();
            model.Brand = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Brand"]) ? string.Empty : dr["Brand"].ToString();
            model.BanksimpleCode = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BanksimpleCode"]) ? string.Empty : dr["BanksimpleCode"].ToString();
            model.BankTel = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BankTel"]) ? string.Empty : dr["BankTel"].ToString();
            model.BankUrl = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["BankUrl"]) ? string.Empty : dr["BankUrl"].ToString();
            model.UID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UID"]) ? 0 : int.Parse(dr["UID"].ToString());
            model.RealName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["RealName"]) ? string.Empty : dr["RealName"].ToString();
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表BankCard)
        /// </summary>
        public static Model.BankCard ConvetToBankCard(SqlDataReader reader, string extParam)
        {
            Model.BankCard model = new Model.BankCard();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.BankNo = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.BankName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            model.cardType = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
            model.Area = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
            model.Brand = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
            model.BanksimpleCode = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
            model.BankTel = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
            model.BankUrl = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
            model.UID = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);
            model.RealName = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
            model.Enable = reader.IsDBNull(11) ? 0 : reader.GetInt32(11);
            model.AddTime = reader.IsDBNull(12) ? System.DateTime.MinValue : reader.GetDateTime(12);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表BankCard)
        /// </summary>
        public int BankCardAdd(Model.BankCard model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO BankCard(");
            strSql.Append("BankNo,BankName,cardType,Area,Brand,BanksimpleCode,BankTel,BankUrl,UID,RealName,Enable,AddTime)");
            strSql.Append(" VALUES (");
            strSql.Append("@BankNo,@BankName,@cardType,@Area,@Brand,@BanksimpleCode,@BankTel,@BankUrl,@UID,@RealName,@Enable,@AddTime)");
            SqlParameter[] parameters = {
                    new SqlParameter("@BankNo", SqlDbType.NVarChar,100),
                    new SqlParameter("@BankName", SqlDbType.NVarChar,100),
                    new SqlParameter("@cardType", SqlDbType.NVarChar,100),
                    new SqlParameter("@Area", SqlDbType.NVarChar,100),
                    new SqlParameter("@Brand", SqlDbType.NVarChar,100),
                    new SqlParameter("@BanksimpleCode", SqlDbType.NVarChar,100),
                    new SqlParameter("@BankTel", SqlDbType.NVarChar,100),
                    new SqlParameter("@BankUrl", SqlDbType.NVarChar,100),
                    new SqlParameter("@UID", SqlDbType.Int,4),
                    new SqlParameter("@RealName", SqlDbType.NVarChar,100),
                    new SqlParameter("@Enable", SqlDbType.Int,4),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8)};
            parameters[0].Value = model.BankNo;
            parameters[1].Value = model.BankName;
            parameters[2].Value = model.cardType;
            parameters[3].Value = model.Area;
            parameters[4].Value = model.Brand;
            parameters[5].Value = model.BanksimpleCode;
            parameters[6].Value = model.BankTel;
            parameters[7].Value = model.BankUrl;
            parameters[8].Value = model.UID;
            parameters[9].Value = model.RealName;
            parameters[10].Value = model.Enable;
            parameters[11].Value = model.AddTime;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表BankCard)
        /// </summary>
        public int BankCardUpdate(Model.BankCard model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE BankCard SET ");
            strSql.Append("BankNo=@BankNo,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("cardType=@cardType,");
            strSql.Append("Area=@Area,");
            strSql.Append("Brand=@Brand,");
            strSql.Append("BanksimpleCode=@BanksimpleCode,");
            strSql.Append("BankTel=@BankTel,");
            strSql.Append("BankUrl=@BankUrl,");
            strSql.Append("UID=@UID,");
            strSql.Append("RealName=@RealName,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("AddTime=@AddTime");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@BankNo", SqlDbType.NVarChar,100),
               new SqlParameter("@BankName", SqlDbType.NVarChar,100),
               new SqlParameter("@cardType", SqlDbType.NVarChar,100),
               new SqlParameter("@Area", SqlDbType.NVarChar,100),
               new SqlParameter("@Brand", SqlDbType.NVarChar,100),
               new SqlParameter("@BanksimpleCode", SqlDbType.NVarChar,100),
               new SqlParameter("@BankTel", SqlDbType.NVarChar,100),
               new SqlParameter("@BankUrl", SqlDbType.NVarChar,100),
               new SqlParameter("@UID", SqlDbType.Int,4),
               new SqlParameter("@RealName", SqlDbType.NVarChar,100),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BankNo;
            parameters[2].Value = model.BankName;
            parameters[3].Value = model.cardType;
            parameters[4].Value = model.Area;
            parameters[5].Value = model.Brand;
            parameters[6].Value = model.BanksimpleCode;
            parameters[7].Value = model.BankTel;
            parameters[8].Value = model.BankUrl;
            parameters[9].Value = model.UID;
            parameters[10].Value = model.RealName;
            parameters[11].Value = model.Enable;
            parameters[12].Value = model.AddTime;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.BankCard GetModelByBankCard(int ID)
        {
            string sql = string.Format("SELECT * FROM BankCard WITH(NOLOCK) WHERE ID={0}", ID);
            Model.BankCard model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.BankCard();
                    }
                    model = ConvetToBankCard(reader, "All");
                }
            }
            return model;
        }

        public Model.BankCard GetModelByBankCardBy_BankNo(string BankNo)
        {
            string sql = string.Format("SELECT * FROM BankCard WITH(NOLOCK) WHERE BankNo='{0}'", BankNo);
            Model.BankCard model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.BankCard();
                    }
                    model = ConvetToBankCard(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.BankCard> GetListBankCard(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.BankCard> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "BankCard", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.BankCard>();
                    }
                    list.Add(ConvetToBankCard(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.BankCard> GetPageBankCard(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.BankCard> list = new List<Yax.Model.BankCard>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "BankCard", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToBankCard(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
