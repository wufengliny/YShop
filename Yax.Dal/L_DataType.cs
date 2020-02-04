using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// L_DataType
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表L_DataType)
        /// </summary>
        public static Model.L_DataType ConvertToL_DataType(DataRow dr)
        {
            Model.L_DataType model = new Model.L_DataType();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表L_DataType)
        /// </summary>
        public static Model.L_DataType ConvetToL_DataType(SqlDataReader reader, string extParam)
        {
            Model.L_DataType model = new Model.L_DataType();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.AddTime = reader.IsDBNull(2) ? System.DateTime.MinValue : reader.GetDateTime(2);
            model.Enable = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表L_DataType)
        /// </summary>
        public int L_DataTypeAdd(Model.L_DataType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO L_DataType(");
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
        /// 修改数据(表L_DataType)
        /// </summary>
        public int L_DataTypeUpdate(Model.L_DataType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE L_DataType SET ");
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

        public int L_DataTypeUpdateName(Model.L_DataType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE L_DataType SET ");
            strSql.Append("Name=@Name");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,100) };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.L_DataType GetModelByL_DataType(int ID)
        {
            string sql = string.Format("SELECT * FROM L_DataType WITH(NOLOCK) WHERE ID={0}", ID);
            Model.L_DataType model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.L_DataType();
                    }
                    model = ConvetToL_DataType(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.L_DataType> GetListL_DataType(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.L_DataType> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "L_DataType", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.L_DataType>();
                    }
                    list.Add(ConvetToL_DataType(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.L_DataType> GetPageL_DataType(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.L_DataType> list = new List<Yax.Model.L_DataType>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "L_DataType", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToL_DataType(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
