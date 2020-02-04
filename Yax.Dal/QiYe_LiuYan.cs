using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// QiYe_LiuYan
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表QiYe_LiuYan)
        /// </summary>
        public static Model.QiYe_LiuYan ConvertToQiYe_LiuYan(DataRow dr)
        {
            Model.QiYe_LiuYan model = new Model.QiYe_LiuYan();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Title = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Title"]) ? string.Empty : dr["Title"].ToString();
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();
            model.Email = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Email"]) ? string.Empty : dr["Email"].ToString();
            model.Detail = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Detail"]) ? string.Empty : dr["Detail"].ToString();
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.Phone = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Phone"]) ? string.Empty : dr["Phone"].ToString();

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表QiYe_LiuYan)
        /// </summary>
        public static Model.QiYe_LiuYan ConvetToQiYe_LiuYan(SqlDataReader reader, string extParam)
        {
            Model.QiYe_LiuYan model = new Model.QiYe_LiuYan();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Title = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.Name = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            model.Email = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
            model.Detail = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
            model.AddTime = reader.IsDBNull(5) ? System.DateTime.MinValue : reader.GetDateTime(5);
            model.Enable = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
            model.Phone = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表QiYe_LiuYan)
        /// </summary>
        public int QiYe_LiuYanAdd(Model.QiYe_LiuYan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO QiYe_LiuYan(");
            strSql.Append("Title,Name,Email,Detail,AddTime,Enable,Phone)");
            strSql.Append(" VALUES (");
            strSql.Append("@Title,@Name,@Email,@Detail,@AddTime,@Enable,@Phone)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Title", SqlDbType.NVarChar,100),
                    new SqlParameter("@Name", SqlDbType.NVarChar,100),
                    new SqlParameter("@Email", SqlDbType.NVarChar,100),
                    new SqlParameter("@Detail", SqlDbType.NVarChar,1000),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Enable", SqlDbType.Int,4),
                    new SqlParameter("@Phone", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Email;
            parameters[3].Value = model.Detail;
            parameters[4].Value = model.AddTime;
            parameters[5].Value = model.Enable;
            parameters[6].Value = model.Phone;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表QiYe_LiuYan)
        /// </summary>
        public int QiYe_LiuYanUpdate(Model.QiYe_LiuYan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE QiYe_LiuYan SET ");
            strSql.Append("Title=@Title,");
            strSql.Append("Name=@Name,");
            strSql.Append("Email=@Email,");
            strSql.Append("Detail=@Detail,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("Phone=@Phone");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Title", SqlDbType.NVarChar,100),
               new SqlParameter("@Name", SqlDbType.NVarChar,100),
               new SqlParameter("@Email", SqlDbType.NVarChar,100),
               new SqlParameter("@Detail", SqlDbType.NVarChar,1000),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@Phone", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.Detail;
            parameters[5].Value = model.AddTime;
            parameters[6].Value = model.Enable;
            parameters[7].Value = model.Phone;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.QiYe_LiuYan GetModelByQiYe_LiuYan(int ID)
        {
            string sql = string.Format("SELECT * FROM QiYe_LiuYan WITH(NOLOCK) WHERE ID={0}", ID);
            Model.QiYe_LiuYan model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.QiYe_LiuYan();
                    }
                    model = ConvetToQiYe_LiuYan(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.QiYe_LiuYan> GetListQiYe_LiuYan(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.QiYe_LiuYan> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "QiYe_LiuYan", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.QiYe_LiuYan>();
                    }
                    list.Add(ConvetToQiYe_LiuYan(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.QiYe_LiuYan> GetPageQiYe_LiuYan(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.QiYe_LiuYan> list = new List<Yax.Model.QiYe_LiuYan>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "QiYe_LiuYan", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToQiYe_LiuYan(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
