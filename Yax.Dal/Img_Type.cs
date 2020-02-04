using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// Img_Type
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表Img_Type)
        /// </summary>
        public static Model.Img_Type ConvertToImg_Type(DataRow dr)
        {

            Model.Img_Type model = new Model.Img_Type();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表Img_Type)
        /// </summary>
        public static Model.Img_Type ConvetToImg_Type(SqlDataReader reader, string extParam)
        {
            Model.Img_Type model = new Model.Img_Type();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.AddTime = reader.IsDBNull(2) ? System.DateTime.MinValue : reader.GetDateTime(2);
            model.Enable = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表Img_Type)
        /// </summary>
        public int Img_TypeAdd(Model.Img_Type model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Img_Type(");
            strSql.Append("Name,AddTime,Enable)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@AddTime,@Enable)");
            SqlParameter[] parameters = {
		            new SqlParameter("@Name", SqlDbType.NVarChar,100),
		            new SqlParameter("@AddTime", SqlDbType.DateTime,8),
		            new SqlParameter("@Enable", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.AddTime;
            parameters[2].Value = model.Enable;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表Img_Type)
        /// </summary>
        public int Img_TypeUpdate(Model.Img_Type model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Img_Type SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Enable=@Enable");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,100),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@Enable", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.AddTime;
            parameters[3].Value = model.Enable;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int Img_TypeUpdate_Name(Model.Img_Type model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Img_Type set ");
            strSql.Append("Name=@Name");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
		            new SqlParameter("@ID", SqlDbType.Int,4),
		            new SqlParameter("@Name", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public int Img_TypeUpdate_Enable(Model.Img_Type model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Img_Type set ");
            strSql.Append("Enable=@Enable");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
		            new SqlParameter("@ID", SqlDbType.Int,4),
		            new SqlParameter("@Enable", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Enable;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.Img_Type GetModelByImg_Type(int ID)
        {
            string sql = string.Format("SELECT * FROM Img_Type WITH(NOLOCK) WHERE ID={0}", ID);
            Model.Img_Type model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.Img_Type();
                    }
                    model = ConvetToImg_Type(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Img_Type> GetListImg_Type(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.Img_Type> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "Img_Type", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.Img_Type>();
                    }
                    list.Add(ConvetToImg_Type(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.Img_Type> GetPageImg_Type(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.Img_Type> list = new List<Yax.Model.Img_Type>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "Img_Type", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToImg_Type(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
