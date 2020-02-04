using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Yax.SqlHelper
{
    public class SQLExecute
    {
        public static int CommandTimeout = 30;
        /// <summary>
        /// 根据传入的存储过程名称和参数执行存储过程并返回SqlDataReader对象
        /// </summary>
        /// <param name="cmdText">存储过程名</param>
        /// <param name="commandParameters">传入的参数</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = SqlHelper.DBHelper.GetSqlConnection();
            try
            {
                PrepareCommand(command, connection, null, CommandType.StoredProcedure, cmdText, commandParameters);
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                command.Parameters.Clear();

                return reader;
            }
            catch
            {
                connection.Close();
                throw;
            }
        }
        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection =DBHelper.GetSqlConnection();
            try
            {
                PrepareCommand(command, connection, null, cmdType, cmdText, commandParameters);
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                command.Parameters.Clear();

                return reader;
            }
            catch
            {
                connection.Close();
                throw;
            }
        }
        /// <summary>
        /// 新增后台获取DataTable方法
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteTable(string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter;
            SqlConnection connection = SqlHelper.DBHelper.GetSqlConnection();
            DataTable table = new DataTable();

            try
            {
                PrepareCommand(command, connection, null, CommandType.StoredProcedure, cmdText, commandParameters);
                adapter = new SqlDataAdapter(command);
                adapter.Fill(table);

            }
            catch (Exception ex)
            {
                connection.Close();
                throw;

            }
            finally
            {
                connection.Close();
                command.Parameters.Clear();
            }
            return table;
        }

        public static DataTable ExecuteTable(string cmdText, CommandType commandType, params SqlParameter[] commandParameters)
        {
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter;
            SqlConnection connection = DBHelper.GetSqlConnection();
            DataTable table = new DataTable();

            try
            {
                PrepareCommand(command, connection, null, commandType, cmdText, commandParameters);
                adapter = new SqlDataAdapter(command);
                adapter.Fill(table);

            }
            catch (Exception ex)
            {
                connection.Close();
                throw;

            }
            finally
            {
                connection.Close();
                command.Parameters.Clear();
            }
            return table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdType">CommandType.StoredProcedure  CommandType.Text</param>
        /// <param name="cmdText">存储过程名  SQL语句</param>
        /// <param name="commandParameters">参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand command = new SqlCommand();

            using (SqlConnection connection =DBHelper.GetSqlConnection())
            {
                PrepareCommand(command, connection, null, cmdType, cmdText, commandParameters);
                int val = command.ExecuteNonQuery();
                command.Parameters.Clear();
                connection.Close();
                return val;
            }
        }


        public static DataSet ExecuteDataSet(string SQLStr)
        {
            using (SqlConnection connection = DBHelper.GetSqlConnection())
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLStr, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
        /// <summary>
        /// 后期待优化  这里未给出dispose close
        /// </summary>
        /// <param name="p_trans"></param>
        /// <param name="p_cmdType"></param>
        /// <param name="p_cmdText"></param>
        /// <param name="p_cmdParms"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(SqlTransaction p_trans, CommandType p_cmdType, string p_cmdText, params SqlParameter[] p_cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, p_trans.Connection, p_trans, p_cmdType, p_cmdText, p_cmdParms);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }


        public static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = DBHelper.GetSqlConnection())
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                connection.Close();
                return val;
            }
        }
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;
            cmd.CommandTimeout = CommandTimeout;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

    }
}
