using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace acode
{
    public class SysCommn
    {
        public SysCommn()
        { }
        public static string GetConn()
        {
            DataSet ds = DbHelperOleDb.Query("Select * from SysConfig where ParameterName='conn'");
            return  ds.Tables[0].Rows[0]["ParameterValue"].ToString();
        }
        public static string GetUsualCode()
        {
            DataSet ds = DbHelperOleDb.Query("Select * from SysConfig where ParameterName='usualcode'");
            return ds.Tables[0].Rows[0]["ParameterValue"].ToString();
        }
        /// <summary>
        /// 读参数值
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static string GetParameterValue(string parameterName)
        {
            DataSet ds = DbHelperOleDb.Query("Select * from SysConfig where ParameterName='" + parameterName + "'");
            return ds.Tables[0].Rows[0]["ParameterValue"].ToString();
        }
    }
   
}
