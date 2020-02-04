using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// JiFenDetail
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表JiFenDetail)
        /// </summary>
        public static Model.JiFenDetail ConvertToJiFenDetail(DataRow dr)
        {
            Model.JiFenDetail model = new Model.JiFenDetail();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.PreJiFen = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PreJiFen"]) ? 0 : int.Parse(dr["PreJiFen"].ToString());//变化前积分
            model.Jifen = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Jifen"]) ? 0 : int.Parse(dr["Jifen"].ToString());//变化积分
            model.AfterJIfen = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AfterJIfen"]) ? 0 : int.Parse(dr["AfterJIfen"].ToString());//变化后积分
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.UID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["UID"]) ? 0 : int.Parse(dr["UID"].ToString());
            model.Account = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Account"]) ? string.Empty : dr["Account"].ToString();

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表JiFenDetail)
        /// </summary>
        public static Model.JiFenDetail ConvetToJiFenDetail(SqlDataReader reader, string extParam)
        {
            Model.JiFenDetail model = new Model.JiFenDetail();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.PreJiFen = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);//变化前积分
            model.Jifen = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);//变化积分
            model.AfterJIfen = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);//变化后积分
            model.Memo = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
            model.AddTime = reader.IsDBNull(5) ? System.DateTime.MinValue : reader.GetDateTime(5);
            model.UID = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
            model.Account = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表JiFenDetail)
        /// </summary>
        public int JiFenDetailAdd(Model.JiFenDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO JiFenDetail(");
            strSql.Append("PreJiFen,Jifen,AfterJIfen,Memo,AddTime,UID,Account)");
            strSql.Append(" VALUES (");
            strSql.Append("@PreJiFen,@Jifen,@AfterJIfen,@Memo,@AddTime,@UID,@Account)");
            SqlParameter[] parameters = {
                    new SqlParameter("@PreJiFen", SqlDbType.Int,4),
                    new SqlParameter("@Jifen", SqlDbType.Int,4),
                    new SqlParameter("@AfterJIfen", SqlDbType.Int,4),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,500),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@UID", SqlDbType.Int,4),
                    new SqlParameter("@Account", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.PreJiFen;
            parameters[1].Value = model.Jifen;
            parameters[2].Value = model.AfterJIfen;
            parameters[3].Value = model.Memo;
            parameters[4].Value = model.AddTime;
            parameters[5].Value = model.UID;
            parameters[6].Value = model.Account;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表JiFenDetail)
        /// </summary>
        public int JiFenDetailUpdate(Model.JiFenDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE JiFenDetail SET ");
            strSql.Append("PreJiFen=@PreJiFen,");
            strSql.Append("Jifen=@Jifen,");
            strSql.Append("AfterJIfen=@AfterJIfen,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("UID=@UID,");
            strSql.Append("Account=@Account");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@PreJiFen", SqlDbType.Int,4),
               new SqlParameter("@Jifen", SqlDbType.Int,4),
               new SqlParameter("@AfterJIfen", SqlDbType.Int,4),
               new SqlParameter("@Memo", SqlDbType.NVarChar,500),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@UID", SqlDbType.Int,4),
               new SqlParameter("@Account", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.PreJiFen;
            parameters[2].Value = model.Jifen;
            parameters[3].Value = model.AfterJIfen;
            parameters[4].Value = model.Memo;
            parameters[5].Value = model.AddTime;
            parameters[6].Value = model.UID;
            parameters[7].Value = model.Account;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.JiFenDetail GetModelByJiFenDetail(int ID)
        {
            string sql = string.Format("SELECT * FROM JiFenDetail WITH(NOLOCK) WHERE ID={0}", ID);
            Model.JiFenDetail model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.JiFenDetail();
                    }
                    model = ConvetToJiFenDetail(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.JiFenDetail> GetListJiFenDetail(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.JiFenDetail> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "JiFenDetail", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.JiFenDetail>();
                    }
                    list.Add(ConvetToJiFenDetail(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.JiFenDetail> GetPageJiFenDetail(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.JiFenDetail> list = new List<Yax.Model.JiFenDetail>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "JiFenDetail", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToJiFenDetail(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
