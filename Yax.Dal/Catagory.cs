using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// Catagory
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表Catagory)
        /// </summary>
        public static Model.Catagory ConvertToCatagory(DataRow dr)
        {
            Model.Catagory model = new Model.Catagory();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();
            model.PID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["PID"]) ? 0 : int.Parse(dr["PID"].ToString());
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.Memo = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Memo"]) ? string.Empty : dr["Memo"].ToString();
            model.Sort = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Sort"]) ? 0 : int.Parse(dr["Sort"].ToString());

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表Catagory)
        /// </summary>
        public static Model.Catagory ConvetToCatagory(SqlDataReader reader, string extParam)
        {
            Model.Catagory model = new Model.Catagory();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.PID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
            model.AddTime = reader.IsDBNull(3) ? System.DateTime.MinValue : reader.GetDateTime(3);
            model.Enable = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
            model.Memo = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
            model.Sort = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表Catagory)
        /// </summary>
        public int CatagoryAdd(Model.Catagory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Catagory(");
            strSql.Append("Name,PID,AddTime,Enable,Memo,Sort)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@PID,@AddTime,@Enable,@Memo,@Sort)");
            SqlParameter[] parameters = {
		            new SqlParameter("@Name", SqlDbType.NVarChar,100),
		            new SqlParameter("@PID", SqlDbType.Int,4),
		            new SqlParameter("@AddTime", SqlDbType.DateTime,8),
		            new SqlParameter("@Enable", SqlDbType.Int,4),
		            new SqlParameter("@Memo", SqlDbType.NVarChar,500),
		            new SqlParameter("@Sort", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.PID;
            parameters[2].Value = model.AddTime;
            parameters[3].Value = model.Enable;
            parameters[4].Value = model.Memo;
            parameters[5].Value = model.Sort;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表Catagory)
        /// </summary>
        public int CatagoryUpdate(Model.Catagory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Catagory SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("PID=@PID,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("Sort=@Sort");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,100),
               new SqlParameter("@PID", SqlDbType.Int,4),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@Memo", SqlDbType.NVarChar,500),
               new SqlParameter("@Sort", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.PID;
            parameters[3].Value = model.AddTime;
            parameters[4].Value = model.Enable;
            parameters[5].Value = model.Memo;
            parameters[6].Value = model.Sort;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        public int CatagoryUpdate_enable(Model.Catagory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Catagory SET ");
            strSql.Append("Enable=@Enable");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Enable", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Enable;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int CatagoryUpdateName(Model.Catagory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Catagory SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("PID=@PID,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("Sort=@Sort");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,100),
               new SqlParameter("@PID", SqlDbType.Int,4),
               new SqlParameter("@Memo", SqlDbType.NVarChar,500),
               new SqlParameter("@Sort", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.PID;
            parameters[3].Value = model.Memo;
            parameters[4].Value = model.Sort;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.Catagory GetModelByCatagory(int ID)
        {
            string sql = string.Format("SELECT * FROM Catagory WITH(NOLOCK) WHERE ID={0}", ID);
            Model.Catagory model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.Catagory();
                    }
                    model = ConvetToCatagory(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Catagory> GetListCatagory(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.Catagory> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "Catagory", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.Catagory>();
                    }
                    list.Add(ConvetToCatagory(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.Catagory> GetPageCatagory(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.Catagory> list = new List<Yax.Model.Catagory>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "Catagory", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToCatagory(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
