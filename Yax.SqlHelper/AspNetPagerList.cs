using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Yax.SqlHelper
{
    /// <summary>
    /// 分页操作
    /// </summary>
    public class AspNetPagerList
    {

        public static DataTable Pager(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, string Tables, out int TotalRecord)
        {
            MAspNetPager modelp = new MAspNetPager()
            {
                OrderString = orderString,
                PageIndex = pageIndex,
                PageSize = pageSize,
                ReFieldsStr = Field,
                TableName = Tables,
                WhereString = StrWhere
            };
            DataTable dt = null;
            dt = AspNetPagerList.PagerLsit(modelp, out TotalRecord);
            return dt;
        }
        /// <summary>
        /// 分页查询 list[0]为数据总数 list[1]为当前页数据集(类型为table)
        /// 存储过程名称必须是 AspNetPager
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static DataTable PagerLsit(MAspNetPager model,out int TotalRecord, string procuedureName = "AspNetPager")
        {
            DataTable dt = null;
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(DBHelper.GetConn_string());
            conn.Open();
            PrepareCommand(command, conn, null, CommandType.StoredProcedure, procuedureName, CreatePagerParameter(model));
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            TotalRecord = string.IsNullOrEmpty(command.Parameters["@TotalRecord"].Value.ToString()) ? 0 : int.Parse(command.Parameters["@TotalRecord"].Value.ToString());
            dt = ds.Tables[0];
            command.Dispose();
            command.Clone();
            da.Dispose();
            conn.Close();
            return dt;
        }

        /// <summary>
        /// 创建储存过程分页查询时要用到的参数
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fields">字段名(全部字段为*)</param>
        /// <param name="orderFields">排序字段(必须!支持多字段不用加order by) 要加ASC 或DESC </param>
        /// <param name="where">查询条件(不用加where)</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">当前页</param>
        /// <returns></returns>
        public static SqlParameter[] CreatePagerParameter(MAspNetPager model)
        {
            SqlParameter[] par = { MakeInParam("@TableName",SqlDbType.VarChar,8000,model.TableName),
                            MakeInParam("@ReFieldsStr",SqlDbType.VarChar,8000,model.ReFieldsStr),
                             MakeInParam("@OrderString",SqlDbType.VarChar,8000,model.OrderString),
                             MakeInParam("@WhereString",SqlDbType.VarChar,8000,model.WhereString),
                            MakeInParam("@PageSize",SqlDbType.Int,50,model.PageSize),
                             MakeInParam("@PageIndex",SqlDbType.Int,50,model.PageIndex),
                             MakeOutParam("@TotalRecord",SqlDbType.Int,50,"")};
            return par;
        }

        /// <summary>
        /// Make input param.
        /// </summary>
        /// <param name="ParamName">Name of param.</param>
        /// <param name="DbType">Param type.</param>
        /// <param name="Size">Param size.</param>
        /// <param name="Value">Param value.</param>
        /// <returns>New parameter.</returns>
        public static SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        public static SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, Value);
        }

        /// <summary>
        /// Make stored procedure param.
        /// </summary>
        /// <param name="ParamName">Name of param.</param>
        /// <param name="DbType">Param type.</param>
        /// <param name="Size">Param size.</param>
        /// <param name="Direction">Parm direction.</param>
        /// <param name="Value">Param value.</param>
        /// <returns>New parameter.</returns>
        public static SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;

            if (Size > 0)
                param = new SqlParameter(ParamName, DbType, Size);
            else
                param = new SqlParameter(ParamName, DbType);

            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;

            return param;
        }


        /// <summary>
        /// 该函数打开Connection，初始化提供的Command
        /// </summary>
        /// <param name="command">需要准备的Commond</param>
        /// <param name="connection">将要使用的SqlConnection</param>
        /// <param name="transaction">将要使用的SqlTransaction, null表示不需要事物支持</param>
        /// <param name="commandType">命令类型 (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">执行SQL需要的SqlParameter， null表示不需要参数</param>
        private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandTimeout = 1200;
            if (transaction != null)
            {
                command.Transaction = transaction;
            }
            command.CommandType = commandType;
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }
        private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            foreach (SqlParameter p in commandParameters)
            {
                //check for derived output value with no value assigned
                if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                {
                    p.Value = DBNull.Value;
                }
                command.Parameters.Add(p);
            }
        }

    }

}
