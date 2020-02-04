using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yax.SQLServerDAL;

namespace Yax.BLL
{
    public class BCommon
    {
        DCommon dal = new DCommon();
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
            return dal.UpdateOneFieldAdd(tableName, fieldName, fieldValue, where, trans);
        }
        /// <summary>
        /// 更新一张表一个字段的值
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="fieldValue">值</param>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public int UpdateOneField(string tableName, string fieldName, string fieldValue, string where, SqlTransaction trans)
        {
            return dal.UpdateOneField(tableName, fieldName, fieldValue, where, trans);
        }
        public int ExecuteSqlTran(List<String> SQLStringList)
        {
            return dal.ExecuteSqlTran(SQLStringList);
        }
        public DataTable GetPagerViewData(int pageIndex, int pageSize, string StrWhere, string orderString, string viewName, out int TotalRecord, out int TotalPage)
        {
            DataTable dt = dal.GetPagerViewData(pageIndex, pageSize, StrWhere, orderString, viewName, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return dt;
        }
        public object ExecuteScalar(string sql)
        {
            return dal.ExecuteScalar(sql);
        }
        public DataTable GetDataBySQL(string sql)
        {
            return dal.GetDataBySQL(sql);
        }



    }
}
