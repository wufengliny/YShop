using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// L_Data
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表L_Data)
        /// </summary>
        public static Model.L_Data ConvertToL_Data(DataRow dr)
        {
            Model.L_Data model = new Model.L_Data();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.KeyName = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["KeyName"]) ? string.Empty : dr["KeyName"].ToString();
            model.Data = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Data"]) ? string.Empty : dr["Data"].ToString();
            model.SearchWord = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["SearchWord"]) ? string.Empty : dr["SearchWord"].ToString();
            model.AddTime = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["AddTime"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr["AddTime"].ToString());
            model.Enable = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Enable"]) ? 0 : int.Parse(dr["Enable"].ToString());
            model.DataTypeID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["DataTypeID"]) ? 0 : int.Parse(dr["DataTypeID"].ToString());

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表L_Data)
        /// </summary>
        public static Model.L_Data ConvetToL_Data(SqlDataReader reader, string extParam)
        {
            Model.L_Data model = new Model.L_Data();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.KeyName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.Data = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            model.SearchWord = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
            model.AddTime = reader.IsDBNull(4) ? System.DateTime.MinValue : reader.GetDateTime(4);
            model.Enable = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
            model.DataTypeID = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表L_Data)
        /// </summary>
        public int L_DataAdd(Model.L_Data model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO L_Data(");
            strSql.Append("KeyName,Data,SearchWord,AddTime,Enable,DataTypeID)");
            strSql.Append(" VALUES (");
            strSql.Append("@KeyName,@Data,@SearchWord,@AddTime,@Enable,@DataTypeID)");
            SqlParameter[] parameters = {
                    new SqlParameter("@KeyName", SqlDbType.NVarChar,100),
                    new SqlParameter("@Data", SqlDbType.NVarChar,1000),
                    new SqlParameter("@SearchWord", SqlDbType.NVarChar,100),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Enable", SqlDbType.Int,4),
                    new SqlParameter("@DataTypeID", SqlDbType.Int,4)};
            parameters[0].Value = model.KeyName;
            parameters[1].Value = model.Data;
            parameters[2].Value = model.SearchWord;
            parameters[3].Value = model.AddTime;
            parameters[4].Value = model.Enable;
            parameters[5].Value = model.DataTypeID;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表L_Data)
        /// </summary>
        public int L_DataUpdate(Model.L_Data model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE L_Data SET ");
            strSql.Append("KeyName=@KeyName,");
            strSql.Append("Data=@Data,");
            strSql.Append("SearchWord=@SearchWord,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("DataTypeID=@DataTypeID");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@KeyName", SqlDbType.NVarChar,100),
               new SqlParameter("@Data", SqlDbType.NVarChar,1000),
               new SqlParameter("@SearchWord", SqlDbType.NVarChar,100),
               new SqlParameter("@AddTime", SqlDbType.DateTime,8),
               new SqlParameter("@Enable", SqlDbType.Int,4),
               new SqlParameter("@DataTypeID", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.KeyName;
            parameters[2].Value = model.Data;
            parameters[3].Value = model.SearchWord;
            parameters[4].Value = model.AddTime;
            parameters[5].Value = model.Enable;
            parameters[6].Value = model.DataTypeID;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int L_DataUpdate_info(Model.L_Data model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE L_Data SET ");
            strSql.Append("KeyName=@KeyName,");
            strSql.Append("Data=@Data,");
            strSql.Append("DataTypeID=@DataTypeID");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@KeyName", SqlDbType.NVarChar,100),
               new SqlParameter("@Data", SqlDbType.NVarChar,1000),
               new SqlParameter("@DataTypeID", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.KeyName;
            parameters[2].Value = model.Data;
            parameters[3].Value = model.DataTypeID;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.L_Data GetModelByL_Data(int ID)
        {
            string sql = string.Format("SELECT * FROM L_Data WITH(NOLOCK) WHERE ID={0}", ID);
            Model.L_Data model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.L_Data();
                    }
                    model = ConvetToL_Data(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.L_Data> GetListL_Data(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.L_Data> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "L_Data", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.L_Data>();
                    }
                    list.Add(ConvetToL_Data(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.L_Data> GetPageL_Data(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.L_Data> list = new List<Yax.Model.L_Data>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "L_Data", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToL_Data(dt.Rows[i]));
                }
            }
            return list;
        }
        public DataTable GetPage_L_Data_view(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "View_L_Data", out TotalRecord);
            return dt;
        }


    }
}
