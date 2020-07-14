using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMaker.Helper
{
    public class SQLHelper
    {
        public static string CONN_STRING { get; set; }
        public SQLHelper(string cONN_STRING)
        {
            CONN_STRING = cONN_STRING;
        }
        #region ExecuteNonQuery

        public static int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            return ExecuteNonQuery(CONN_STRING, commandType, commandText, (SqlParameter[])null);
        }

       

       

        #endregion ExecuteNonQuery
    }
}
