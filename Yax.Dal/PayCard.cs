using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// PayCard
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表PayCard)
        /// </summary>
        public static Model.PayCard ConvertToPayCard(DataRow dr)
        {
            Model.PayCard model = new Model.PayCard();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();
            model.CardNo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["CardNo"]) ? string.Empty : dr["CardNo"].ToString();
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.APIUrl = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["APIUrl"]) ? string.Empty : dr["APIUrl"].ToString();
            model.APIKey = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["APIKey"]) ? string.Empty : dr["APIKey"].ToString();
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();
            model.PublicKey = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PublicKey"]) ? string.Empty : dr["PublicKey"].ToString();
            model.PayUrl = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PayUrl"]) ? string.Empty : dr["PayUrl"].ToString();
            model.UpdateTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UpdateTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["UpdateTime"].ToString());
            model.CardType = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["CardType"]) ? string.Empty : dr["CardType"].ToString();//第三方类型  支付宝 微信  。。。。
            model.ImgUrl = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ImgUrl"]) ? string.Empty : dr["ImgUrl"].ToString();

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表PayCard)
        /// </summary>
        public static Model.PayCard ConvetToPayCard(SqlDataReader reader, string extParam)
        {
            Model.PayCard model = new Model.PayCard();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.CardNo = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            model.Enable = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
            model.AddTime = reader.IsDBNull(4) ? System.DateTime.MinValue : reader.GetDateTime(4);
            model.APIUrl = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
            model.APIKey = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
            model.Memo = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
            model.PublicKey = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
            model.PayUrl = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
            model.UpdateTime = reader.IsDBNull(10) ? System.DateTime.MinValue : reader.GetDateTime(10);
            model.CardType = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);//第三方类型  支付宝 微信  。。。。
            model.ImgUrl = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
            return model;
        }
        /// <summary>
        /// 增加一条数据(表PayCard)
        /// </summary>
        public int PayCardAdd(Model.PayCard model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO PayCard(");
            strSql.Append("Name,CardNo,Enable,AddTime,APIUrl,APIKey,Memo,PublicKey,PayUrl,UpdateTime,CardType)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@CardNo,@Enable,@AddTime,@APIUrl,@APIKey,@Memo,@PublicKey,@PayUrl,@UpdateTime,@CardType)");
            SqlParameter[] parameters = {
		            new SqlParameter("@Name", SqlDbType.NVarChar,100),
		            new SqlParameter("@CardNo", SqlDbType.VarChar,250),
		            new SqlParameter("@Enable", SqlDbType.Int,4),
		            new SqlParameter("@AddTime", SqlDbType.DateTime,8),
		            new SqlParameter("@APIUrl", SqlDbType.NVarChar,500),
		            new SqlParameter("@APIKey", SqlDbType.VarChar,500),
		            new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
		            new SqlParameter("@PublicKey", SqlDbType.NVarChar,1000),
		            new SqlParameter("@PayUrl", SqlDbType.NVarChar,500),
		            new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
		            new SqlParameter("@CardType", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.CardNo;
            parameters[2].Value = model.Enable;
            parameters[3].Value = model.AddTime;
            parameters[4].Value = model.APIUrl;
            parameters[5].Value = model.APIKey;
            parameters[6].Value = model.Memo;
            parameters[7].Value = model.PublicKey;
            parameters[8].Value = model.PayUrl;
            parameters[9].Value = model.UpdateTime;
            parameters[10].Value = model.CardType;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表PayCard)
        /// </summary>
        public int PayCardUpdate(Model.PayCard model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE PayCard SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("CardNo=@CardNo,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("APIUrl=@APIUrl,");
            strSql.Append("APIKey=@APIKey,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("PublicKey=@PublicKey,");
            strSql.Append("PayUrl=@PayUrl,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("CardType=@CardType");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,100),
               new SqlParameter("@CardNo", SqlDbType.VarChar,250),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@APIUrl", SqlDbType.NVarChar,500),
               new SqlParameter("@APIKey", SqlDbType.VarChar,500),
               new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
               new SqlParameter("@PublicKey", SqlDbType.NVarChar,1000),
               new SqlParameter("@PayUrl", SqlDbType.NVarChar,500),
               new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
               new SqlParameter("@CardType", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.CardNo;
            parameters[3].Value = model.Enable;
            parameters[4].Value = model.AddTime;
            parameters[5].Value = model.APIUrl;
            parameters[6].Value = model.APIKey;
            parameters[7].Value = model.Memo;
            parameters[8].Value = model.PublicKey;
            parameters[9].Value = model.PayUrl;
            parameters[10].Value = model.UpdateTime;
            parameters[11].Value = model.CardType;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int PayCardUpdateenable(Model.PayCard model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PayCard set ");
            strSql.Append("Enable=@Enable");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
		            new SqlParameter("@ID", SqlDbType.Int,4),
		            new SqlParameter("@Enable", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Enable;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int PayCardUpdateInfo(Model.PayCard model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE PayCard SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("CardNo=@CardNo,");
            strSql.Append("APIUrl=@APIUrl,");
            strSql.Append("APIKey=@APIKey,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("PublicKey=@PublicKey,");
            strSql.Append("PayUrl=@PayUrl,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("CardType=@CardType");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,100),
               new SqlParameter("@CardNo", SqlDbType.VarChar,250),
               new SqlParameter("@APIUrl", SqlDbType.NVarChar,500),
               new SqlParameter("@APIKey", SqlDbType.VarChar,500),
               new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
               new SqlParameter("@PublicKey", SqlDbType.NVarChar,1000),
               new SqlParameter("@PayUrl", SqlDbType.NVarChar,500),
               new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
               new SqlParameter("@CardType", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.CardNo;
            parameters[3].Value = model.APIUrl;
            parameters[4].Value = model.APIKey;
            parameters[5].Value = model.Memo;
            parameters[6].Value = model.PublicKey;
            parameters[7].Value = model.PayUrl;
            parameters[8].Value = model.UpdateTime;
            parameters[9].Value = model.CardType;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.PayCard GetModelByPayCard(int ID)
        {
            string sql = string.Format("SELECT * FROM PayCard WITH(NOLOCK) WHERE ID={0}", ID);
            Model.PayCard model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.PayCard();
                    }
                    model = ConvetToPayCard(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.PayCard> GetListPayCard(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.PayCard> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "PayCard", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.PayCard>();
                    }
                    list.Add(ConvetToPayCard(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.PayCard> GetPagePayCard(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.PayCard> list = new List<Yax.Model.PayCard>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "PayCard", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToPayCard(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
