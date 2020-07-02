using CommSQLHelper;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DS_Log
    {

        #region 2019 Kay
        public int ErrorLogAdd(MS_LogError model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO S_LogError(");
            strSql.Append("Message,StackTrace,AddTime,IP,URL,UserID,UserName)");
            strSql.Append(" VALUES (");
            strSql.Append("@Message,@StackTrace,@AddTime,@IP,@URL,@UserID,@UserName)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Message", SqlDbType.NVarChar,-1),
                    new SqlParameter("@StackTrace", SqlDbType.NVarChar,-1),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@IP", SqlDbType.NVarChar,32),
                    new SqlParameter("@URL", SqlDbType.NVarChar,1000),
                    new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.Message;
            parameters[1].Value = model.StackTrace;
            parameters[2].Value = model.AddTime;
            parameters[3].Value = model.IP;
            parameters[4].Value = model.URL;
            parameters[5].Value = model.UserID;
            parameters[6].Value = model.UserName;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        public int LoginLogAdd(MS_LogLogin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO S_LogLogin(");
            strSql.Append("OperatorType,UserName,UserID,LoginUrl,IP,AddTime,Statu,Memo)");
            strSql.Append(" VALUES (");
            strSql.Append("@OperatorType,@UserName,@UserID,@LoginUrl,@IP,@AddTime,@Statu,@Memo)");
            SqlParameter[] parameters = {
                    new SqlParameter("@OperatorType", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,64),
                    new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@LoginUrl", SqlDbType.NVarChar,500),
                    new SqlParameter("@IP", SqlDbType.NVarChar,32),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Statu", SqlDbType.Int,4),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.OperatorType;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.LoginUrl;
            parameters[4].Value = model.IP;
            parameters[5].Value = model.AddTime;
            parameters[6].Value = model.Statu;
            parameters[7].Value = model.Memo;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        public int OperateLogAdd(MS_LogOperate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO S_LogOperate(");
            strSql.Append("UserID,UserName,URL,URLReferrer,IP,AddTime,Memo,OperatorType,IsSensitive)");
            strSql.Append(" VALUES (");
            strSql.Append("@UserID,@UserName,@URL,@URLReferrer,@IP,@AddTime,@Memo,@OperatorType,@IsSensitive)");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,64),
                    new SqlParameter("@URL", SqlDbType.NVarChar,1000),
                    new SqlParameter("@URLReferrer", SqlDbType.NVarChar,1000),
                    new SqlParameter("@IP", SqlDbType.NVarChar,32),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
                    new SqlParameter("@OperatorType", SqlDbType.Int,4),
                    new SqlParameter("@IsSensitive", SqlDbType.Bit,1)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.URL;
            parameters[3].Value = model.URLReferrer;
            parameters[4].Value = model.IP;
            parameters[5].Value = model.AddTime;
            parameters[6].Value = model.Memo;
            parameters[7].Value = model.OperatorType;
            parameters[8].Value = model.IsSensitive;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public int SysLogAdd(MS_LogSys model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO S_LogSys(");
            strSql.Append("LogType,IP,AddTime,Memo)");
            strSql.Append(" VALUES (");
            strSql.Append("@LogType,@IP,@AddTime,@Memo)");
            SqlParameter[] parameters = {
                    new SqlParameter("@LogType", SqlDbType.Int,4),
                    new SqlParameter("@IP", SqlDbType.NVarChar,32),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Memo", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.LogType;
            parameters[1].Value = model.IP;
            parameters[2].Value = model.AddTime;
            parameters[3].Value = model.Memo;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }



        /// <summary>
        ///登录日志分页
        /// </summary>
        public List<object> LoginLogPager(int OperatorType,string UserName, string BeginTime, string EndTime,string memo, int statu, int pageIndex, int pageSize)
        {
            string strWhere = " OperatorType="+ OperatorType;
            if(statu>0)
            {
                strWhere += " and Statu="+statu;
            }
            if(!string.IsNullOrEmpty(UserName))
            {
                strWhere += " and UserName='"+UserName+"'";
            }
            if (!string.IsNullOrEmpty(memo))
            {
                strWhere += " and memo like '%" + memo + "%'";
            }
            if (!string.IsNullOrEmpty(BeginTime))
            {
                strWhere += " and addtime>='"+ BeginTime + "'";
            }
            if (!string.IsNullOrEmpty(EndTime))
            {
                strWhere += " and addtime<='" + EndTime + "'";
            }
            MAspNetPager modelp = new MAspNetPager()
            {
                OrderString = "ID desc",
                PageIndex = pageIndex,
                PageSize = pageSize,
                ReFieldsStr = "*",
                TableName = "S_LogLogin",
                WhereString = strWhere
            };
            return AspNetPagerList.PagerLsit<MS_LogLogin>(modelp);
        }

        /// <summary>
        /// 操作日志分页
        /// </summary>
        /// <param name="OperatorType"></param>
        /// <param name="UserName"></param>
        /// <param name="BeginTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="memo"></param>
        /// <param name="statu"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<object> OperateLogPager(int OperatorType, string UserName, string BeginTime, string EndTime, string memo, int IsSensitive, int pageIndex, int pageSize)
        {
            string strWhere = " OperatorType=" + OperatorType;
            if (IsSensitive > -1)
            {
                strWhere += " and IsSensitive=" + IsSensitive;
            }
            if (!string.IsNullOrEmpty(UserName))
            {
                strWhere += " and UserName='" + UserName + "'";
            }
            if (!string.IsNullOrEmpty(memo))
            {
                strWhere += " and memo like '%" + memo + "%'";
            }
            if (!string.IsNullOrEmpty(BeginTime))
            {
                strWhere += " and addtime>='" + BeginTime + "'";
            }
            if (!string.IsNullOrEmpty(EndTime))
            {
                strWhere += " and addtime<='" + EndTime + "'";
            }
            MAspNetPager modelp = new MAspNetPager()
            {
                OrderString = "ID desc",
                PageIndex = pageIndex,
                PageSize = pageSize,
                ReFieldsStr = "*",
                TableName = "S_LogOperate",
                WhereString = strWhere
            };
            return AspNetPagerList.PagerLsit<MS_LogOperate>(modelp);
        }

        public List<object> ErrorLogPager(string BeginTime, string EndTime, string Message, int pageIndex, int pageSize)
        {
            string strWhere = " 1=1" ;
            if (!string.IsNullOrEmpty(Message))
            {
                strWhere += " and Message like '%" + Message + "%'";
            }
            if (!string.IsNullOrEmpty(BeginTime))
            {
                strWhere += " and addtime>='" + BeginTime + "'";
            }
            if (!string.IsNullOrEmpty(EndTime))
            {
                strWhere += " and addtime<='" + EndTime + "'";
            }
            MAspNetPager modelp = new MAspNetPager()
            {
                OrderString = "ID desc",
                PageIndex = pageIndex,
                PageSize = pageSize,
                ReFieldsStr = "*",
                TableName = "S_LogError",
                WhereString = strWhere
            };
            return AspNetPagerList.PagerLsit<MS_LogError>(modelp);
        }

        public List<object> SysLogPager(string BeginTime, string EndTime,int LogType, string Memo, int pageIndex, int pageSize)
        {
            string strWhere = " 1=1";
            if (LogType>0)
            {
                strWhere += " and LogType="+ LogType;
            }
            if (!string.IsNullOrEmpty(Memo))
            {
                strWhere += " and Memo like '%" + Memo + "%'";
            }
            if (!string.IsNullOrEmpty(BeginTime))
            {
                strWhere += " and addtime>='" + BeginTime + "'";
            }
            if (!string.IsNullOrEmpty(EndTime))
            {
                strWhere += " and addtime<='" + EndTime + "'";
            }
            MAspNetPager modelp = new MAspNetPager()
            {
                OrderString = "ID desc",
                PageIndex = pageIndex,
                PageSize = pageSize,
                ReFieldsStr = "*",
                TableName = "S_LogSys",
                WhereString = strWhere
            };
            return AspNetPagerList.PagerLsit<MS_LogSys>(modelp);
        }
        public MS_LogLogin GetLoginModelByID(int ID)
        {
            string str = "select * from S_LogLogin where ID=@ID";
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = ID;
            return SQLHelper.ExecuteReaderObject<MS_LogLogin>(CommandType.Text, str, param);
        }
        public MS_LogOperate GetOperateModelByID(int ID)
        {
            string str = "select * from S_LogOperate where ID=@ID";
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = ID;
            return SQLHelper.ExecuteReaderObject<MS_LogOperate>(CommandType.Text, str, param);
        }
        public MS_LogError GetErrorModelByID(int ID)
        {
            string str = "select * from S_LogError where ID=@ID";
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = ID;
            return SQLHelper.ExecuteReaderObject<MS_LogError>(CommandType.Text, str, param);
        }
        public MS_LogSys GetSysModelByID(int ID)
        {
            string str = "select * from S_LogSys where ID=@ID";
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = ID;
            return SQLHelper.ExecuteReaderObject<MS_LogSys>(CommandType.Text, str, param);
        }
        #endregion
 
    }
}
