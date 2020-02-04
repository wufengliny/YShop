using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Yax.SQLServerDAL
{
    /// <summary>
    /// QiYe_ProductType
    /// </summary>
    public partial class DataProvider
    {
        /// <summary>
        /// 数据转换成实体(表QiYe_ProductType)
        /// </summary>
        public static Model.QiYe_ProductType ConvertToQiYe_ProductType(DataRow dr)
        {
            Model.QiYe_ProductType model = new Model.QiYe_ProductType();

            model.ID = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["ID"]) ? 0 : int.Parse(dr["ID"].ToString());
            model.Name = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["Name"]) ? string.Empty : dr["Name"].ToString();
            model.SeoKeyword = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["SeoKeyword"]) ? string.Empty : dr["SeoKeyword"].ToString();
            model.SeoDescription = Yax.SqlHelper.DBHelper.GetIsDBNULL(dr["SeoDescription"]) ? string.Empty : dr["SeoDescription"].ToString();

            return model;
        }
        /// <summary>
        /// 数据转换成实体(表QiYe_ProductType)
        /// </summary>
        public static Model.QiYe_ProductType ConvetToQiYe_ProductType(SqlDataReader reader, string extParam)
        {
            Model.QiYe_ProductType model = new Model.QiYe_ProductType();

            model.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            model.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            model.SeoKeyword = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            model.SeoDescription = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);

            return model;
        }
        /// <summary>
        /// 增加一条数据(表QiYe_ProductType)
        /// </summary>
        public int QiYe_ProductTypeAdd(Model.QiYe_ProductType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO QiYe_ProductType(");
            strSql.Append("Name,SeoKeyword,SeoDescription)");
            strSql.Append(" VALUES (");
            strSql.Append("@Name,@SeoKeyword,@SeoDescription)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,100),
                    new SqlParameter("@SeoKeyword", SqlDbType.NVarChar,500),
                    new SqlParameter("@SeoDescription", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.SeoKeyword;
            parameters[2].Value = model.SeoDescription;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据(表QiYe_ProductType)
        /// </summary>
        public int QiYe_ProductTypeUpdate(Model.QiYe_ProductType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE QiYe_ProductType SET ");
            strSql.Append("Name=@Name,");
            strSql.Append("SeoKeyword=@SeoKeyword,");
            strSql.Append("SeoDescription=@SeoDescription");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@Name", SqlDbType.NVarChar,100),
               new SqlParameter("@SeoKeyword", SqlDbType.NVarChar,500),
               new SqlParameter("@SeoDescription", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.SeoKeyword;
            parameters[3].Value = model.SeoDescription;

            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 读取实体
        /// </summary>
        public Model.QiYe_ProductType GetModelByQiYe_ProductType(int ID)
        {
            string sql = string.Format("SELECT * FROM QiYe_ProductType WITH(NOLOCK) WHERE ID={0}", ID);
            Model.QiYe_ProductType model = null;
            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (model == null)
                    {
                        model = new Model.QiYe_ProductType();
                    }
                    model = ConvetToQiYe_ProductType(reader, "All");
                }
            }
            return model;
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.QiYe_ProductType> GetListQiYe_ProductType(int top, string fldName, string strWhere, string fldSort)
        {
            List<Model.QiYe_ProductType> list = null;
            using (SqlDataReader reader = Yax.SqlHelper.DBHelper.GetList(top, fldName, "QiYe_ProductType", strWhere, fldSort))
            {
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new List<Model.QiYe_ProductType>();
                    }
                    list.Add(ConvetToQiYe_ProductType(reader, "All"));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 分页读取数据,参数输出总记录数
        /// </summary>
        public List<Yax.Model.QiYe_ProductType> GetPageQiYe_ProductType(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)
        {
            List<Yax.Model.QiYe_ProductType> list = new List<Yax.Model.QiYe_ProductType>();
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, Field, "QiYe_ProductType", out TotalRecord);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToQiYe_ProductType(dt.Rows[i]));
                }
            }
            return list;
        }
    }
}
