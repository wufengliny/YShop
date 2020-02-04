using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Yax.SqlHelper
{
    public class DBHelper
    {
        private static string Conn_String;
        public static string GetConn_string()
        {
            if(string.IsNullOrEmpty(Conn_String))
            {
                object obj = Yax.Common.DataCache.GetCache("Conn_String");
                if (obj == null)
                {
                    Conn_String = Yax.Common.SecurityHelper.Decrypt(ConfigurationManager.ConnectionStrings["DBconn"].ConnectionString);
                    Yax.Common.DataCache.SetCache("Conn_String", Conn_String);
                }
                else
                {
                    Conn_String = obj.ToString();
                }
            }
            return Conn_String;
        }

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(GetConn_string());
        }

        public static bool GetIsDBNULL(object dc)
        {
            if (dc is DBNull)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static SqlDataReader GetList(int top, string fldName, string tblName, string strWhere, string fldSort)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@top",SqlDbType.Int,4),
                new SqlParameter("@fldName",SqlDbType.NVarChar ,4000),
                new SqlParameter ("@tblName",SqlDbType .NVarChar ,1000),
                new SqlParameter ("@strWhere",SqlDbType .NVarChar ,4000),
                new SqlParameter ("@fldSort",SqlDbType .NVarChar ,4000)};
            parameters[0].Value = top;
            parameters[1].Value = fldName;
            parameters[2].Value = tblName;
            parameters[3].Value = strWhere;
            parameters[4].Value = fldSort;

            return SQLExecute.ExecuteReader("GetList", parameters);
        }
        /// <summary>
        /// 读取数据
        /// </summary>
        public static DataTable GetDataTableList(int top, string fldName, string tblName, string strWhere, string fldSort)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@top",SqlDbType.Int,4),
                new SqlParameter("@fldName",SqlDbType.NVarChar ,4000),
                new SqlParameter ("@tblName",SqlDbType .NVarChar ,1000),
                new SqlParameter ("@strWhere",SqlDbType .NVarChar ,4000),
                new SqlParameter ("@fldSort",SqlDbType .NVarChar ,4000)};
            parameters[0].Value = top;
            parameters[1].Value = fldName;
            parameters[2].Value = tblName;
            parameters[3].Value = strWhere;
            parameters[4].Value = fldSort;

            return SQLExecute.ExecuteTable("GetList", parameters);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public static int Delete(string tblName, string strWhere)
        {
            string sql = string.Format("delete {0} where {1}", tblName, strWhere);
            return SQLExecute.ExecuteNonQuery(CommandType.Text, sql);
        }
        public static int ExecuteSqlTran(List<String> SQLStringList)
        {
            using (SqlConnection conn = GetSqlConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    int count = 0;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            count += cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return count;
                }
                catch
                {
                    tx.Rollback();
                    return 0;
                }
            }
        }

    }
}
