using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// DianQuanDetail
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表DianQuanDetail)
        /// </summary>
        public static Model.DianQuanDetail ConvertToDianQuanDetail(DataRow dr)
        {
            Model.DianQuanDetail model = new Model.DianQuanDetail();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.PreJiFen = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PreJiFen"]) ? 0 : int.Parse(dr["PreJiFen"].ToString());
            model.Jifen = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Jifen"]) ? 0 : int.Parse(dr["Jifen"].ToString());
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.UID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UID"]) ? 0 : int.Parse(dr["UID"].ToString());
            model.AfterJIfen = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AfterJIfen"]) ? 0 : int.Parse(dr["AfterJIfen"].ToString());
            model.Account = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Account"]) ? string.Empty : dr["Account"].ToString();

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表DianQuanDetail)
        /// </summary>
        public static Model.DianQuanDetail ConvetToDianQuanDetail(SqlDataReader reader, string extParam)
        {
            Model.DianQuanDetail model = new Model.DianQuanDetail();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.PreJiFen = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
            model.Jifen = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
            model.Memo = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
            model.AddTime = reader.IsDBNull(4) ? System.DateTime.MinValue : reader.GetDateTime(4);
            model.UID = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
            model.AfterJIfen = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
            model.Account = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表DianQuanDetail)
        /// </summary>
        public int DianQuanDetailAdd(Model.DianQuanDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO DianQuanDetail(");
            strSql.Append("PreJiFen,Jifen,Memo,AddTime,UID,AfterJIfen,Account)");
            strSql.Append(" VALUES (");
            strSql.Append("@PreJiFen,@Jifen,@Memo,@AddTime,@UID,@AfterJIfen,@Account)");
            SqlParameter[] parameters = {
                    new SqlParameter("@PreJiFen", SqlDbType.Int,4),
                    new SqlParameter("@Jifen", SqlDbType.Int,4),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,500),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@UID", SqlDbType.Int,4),
                    new SqlParameter("@AfterJIfen", SqlDbType.Int,4),
                    new SqlParameter("@Account", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.PreJiFen;
            parameters[1].Value = model.Jifen;
            parameters[2].Value = model.Memo;
            parameters[3].Value = model.AddTime;
            parameters[4].Value = model.UID;
            parameters[5].Value = model.AfterJIfen;
            parameters[6].Value = model.Account;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表DianQuanDetail)
        /// </summary>
        public int DianQuanDetailUpdate(Model.DianQuanDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE DianQuanDetail SET ");
            strSql.Append("PreJiFen=@PreJiFen,");
            strSql.Append("Jifen=@Jifen,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("UID=@UID,");
            strSql.Append("AfterJIfen=@AfterJIfen,");
            strSql.Append("Account=@Account");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@PreJiFen", SqlDbType.Int,4),
               new SqlParameter("@Jifen", SqlDbType.Int,4),
               new SqlParameter("@Memo", SqlDbType.NVarChar,500),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@UID", SqlDbType.Int,4),
               new SqlParameter("@AfterJIfen", SqlDbType.Int,4),
               new SqlParameter("@Account", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.PreJiFen;
            parameters[2].Value = model.Jifen;
            parameters[3].Value = model.Memo;
            parameters[4].Value = model.AddTime;
            parameters[5].Value = model.UID;
            parameters[6].Value = model.AfterJIfen;
            parameters[7].Value = model.Account;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.DianQuanDetail GetModelByDianQuanDetail(int ID)
        {
            string sql = string.Format("SELECT * FROM DianQuanDetail WITH(NOLOCK) WHERE ID={0}", ID);
            Model.DianQuanDetail model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.DianQuanDetail();
                    }
                    model = ConvetToDianQuanDetail(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.DianQuanDetail> GetListDianQuanDetail(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.DianQuanDetail> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "DianQuanDetail", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.DianQuanDetail>();
                    }
                    list.Add(ConvetToDianQuanDetail(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.DianQuanDetail> GetPageDianQuanDetail(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.DianQuanDetail> list = new List<Yax.Model.DianQuanDetail>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "DianQuanDetail", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToDianQuanDetail(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
