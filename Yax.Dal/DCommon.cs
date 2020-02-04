using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Yax.SQLServerDAL
{
    /// <summary>
    /// 
    /// </summary>
    public class DCommon
    {
        /// <summary>
        /// 更新一张表一个字段的值
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="fieldValue">值</param>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public int UpdateOneField(string tableName, string fieldName, string fieldValue, string where, SqlTransaction trans = null)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@TableName", SqlDbType.VarChar,50),
                new SqlParameter("@FieldName", SqlDbType.VarChar,50),
                new SqlParameter("@FieldValue", SqlDbType.VarChar,8000),
                new SqlParameter("@Where", SqlDbType.VarChar,8000)};
            parameters[0].Value = tableName;
            parameters[1].Value = fieldName;
            parameters[2].Value = fieldValue;
            parameters[3].Value = where;
            if (trans == null)
            {
                return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateOneField", parameters);
            }
            else
            {
                return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UpdateOneField", parameters);
            }
        }
        /// <summary>
        /// 更新一张表一个字段的值(在原来的这个值上加现在这个值)
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="fieldValue">值</param>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public int UpdateOneFieldAdd(string tableName, string fieldName, string fieldValue, string where, SqlTransaction trans = null)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@TableName", SqlDbType.VarChar,50),
                new SqlParameter("@FieldName", SqlDbType.VarChar,50),
                new SqlParameter("@FieldValue", SqlDbType.VarChar,8000),
                new SqlParameter("@Where", SqlDbType.VarChar,8000)};
            parameters[0].Value = tableName;
            parameters[1].Value = fieldName;
            parameters[2].Value = fieldValue;
            parameters[3].Value = where;
            if (trans == null)
            {
                return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateOneFieldAdd", parameters);
            }
            else
            {
                return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UpdateOneFieldAdd", parameters);
            }
        }
        public int ExecuteSqlTran(List<String> SQLStringList)
        {
            return Yax.SqlHelper.DBHelper.ExecuteSqlTran(SQLStringList);
        }
        public DataTable GetPagerViewData(int pageIndex, int pageSize, string StrWhere, string orderString, string viewName, out int TotalRecord)
        {
            DataTable dt = Yax.SqlHelper.AspNetPagerList.Pager(pageIndex, pageSize, StrWhere, orderString, "*", viewName, out TotalRecord);
            return dt;
        }

        public object ExecuteScalar(string sql)
        {
            object obj = Yax.SqlHelper.SQLExecute.ExecuteScalar(CommandType.Text, sql);
            return obj;
        }

        public DataTable GetDataBySQL(string sql)
        {
            DataTable dt = Yax.SqlHelper.SQLExecute.ExecuteDataSet(sql).Tables[0];
            return dt;
        }

    }
}
