using ComEnum;

using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;


namespace BLL
{
    public class BS_Log
    {
        private DS_Log dal = new DS_Log();



        #region 2019 Kay
        /// <summary>
        /// 添加操作日志
        /// </summary>
        /// <param name="msg">操作信息</param>
        /// <param name="UserID">操作人ID</param>
        /// <param name="UserName">操作人名称</param>
        /// <param name="OperatorType">操作人类型</param>
        /// <param name="IsSensitive">是否敏感信息的操作</param>
        /// <returns></returns>
        public int OperateLogAdd(string msg,int UserID,string UserName,AccountEnum OperatorType, bool IsSensitive)
        {
            MS_LogOperate model = new MS_LogOperate();
            model.AddTime = DateTime.Now;
            model.IP = UCommon.UUtils.GetClientIP();
            model.Memo = msg;
            model.OperatorType =(int)OperatorType;
            model.URL = System.Web.HttpContext.Current.Request.Url.ToString();
            model.URLReferrer = System.Web.HttpContext.Current.Request.UrlReferrer == null ? "" : System.Web.HttpContext.Current.Request.UrlReferrer.ToString();
            model.UserID = UserID;
            model.UserName = UserName;
            model.IsSensitive = IsSensitive;
            return dal.OperateLogAdd(model);
        }

        /// <summary>
        /// 操作 记录根据Source 判断是管理员还是会员的操作日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="source"></param>
        /// <param name="IsSensitive"></param>
        /// <returns></returns>
        public int OperateLogAddExtend(string msg,int source, bool IsSensitive = false)
        {
            if(source==1||source==2)
            {
                return OperateLogAdd(msg, new BLL.CurrentUser().ID, new BLL.CurrentUser().Account, AccountEnum.Member, IsSensitive);
            }
            if (source == 3)
            {
                return OperateLogAdd(msg, new BLL.CurrentAdmin().ID, new BLL.CurrentAdmin().Account, AccountEnum.Admin, IsSensitive);
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 添加登录日志
        /// </summary>
        /// <param name="memo"></param>
        /// <param name="OperatorType"></param>
        /// <param name="statu">1:登录成功2：登录失败</param>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int LoginLogAdd(string memo, AccountEnum OperatorType, int statu,int userID,string userName)
        {
            MS_LogLogin model = new MS_LogLogin();
            model.AddTime = DateTime.Now;
            model.IP = UCommon.UUtils.GetClientIP();
            model.Memo = memo;
            model.OperatorType = (int)OperatorType;
            model.Statu = statu;
            model.UserID = userID;
            model.UserName = userName;
            model.LoginUrl = System.Web.HttpContext.Current.Request.Url.ToString();
            return dal.LoginLogAdd(model);
        }
        public int ErrorLogAdd(string Message,string StackTrace,int UserID=0,string UserName="")
        {
            MS_LogError model = new MS_LogError();
            model.AddTime = DateTime.Now;
            model.IP= UCommon.UUtils.GetIP();
            model.Message = Message;
            model.StackTrace = StackTrace;
            model.URL = System.Web.HttpContext.Current == null ? "" : System.Web.HttpContext.Current.Request.Url.ToString(); 
            model.UserID = UserID;
            model.UserName = UserName;
            return dal.ErrorLogAdd(model);
        }

        public int SysLogAdd(int LogType,string Memo)
        {
            MS_LogSys model = new MS_LogSys();
            model.AddTime = DateTime.Now;
            model.IP= UCommon.UUtils.GetIP();
            model.LogType = LogType;
            model.Memo = Memo;
            return dal.SysLogAdd(model);
        }



        /// <summary>
        /// 登录日志分页
        /// </summary>
        public List<MS_LogLogin> LoginLogPager(int OperatorType, string UserName, string BeginTime, string EndTime,string memo, int statu, int pageIndex, int pageSize)
        {
            List<object> list = dal.LoginLogPager(OperatorType,UserName, BeginTime,EndTime, memo,statu, pageIndex, pageSize);
            PagedList<MS_LogLogin> pl = new PagedList<MS_LogLogin>((List<MS_LogLogin>)list[1], pageIndex, pageSize, int.Parse(list[0].ToString()));
            return pl;
        }
        public List<MS_LogOperate> OperateLogPager(int OperatorType, string UserName, string BeginTime, string EndTime, string memo, int IsSensitive, int pageIndex, int pageSize)
        {
            List<object> list = dal.OperateLogPager(OperatorType, UserName, BeginTime, EndTime, memo, IsSensitive, pageIndex, pageSize);
            PagedList<MS_LogOperate> pl = new PagedList<MS_LogOperate>((List<MS_LogOperate>)list[1], pageIndex, pageSize, int.Parse(list[0].ToString()));
            return pl;
        }
        public List<MS_LogError> ErrorLogPager(string BeginTime, string EndTime, string Message,  int pageIndex, int pageSize)
        {
            List<object> list = dal.ErrorLogPager( BeginTime, EndTime, Message, pageIndex, pageSize);
            PagedList<MS_LogError> pl = new PagedList<MS_LogError>((List<MS_LogError>)list[1], pageIndex, pageSize, int.Parse(list[0].ToString()));
            return pl;
        }

        public List<MS_LogSys> SysLogPager(string BeginTime, string EndTime, int LogType, string Memo, int pageIndex, int pageSize)
        {
            List<object> list = dal.SysLogPager(BeginTime, EndTime, LogType, Memo, pageIndex, pageSize);
            PagedList<MS_LogSys> pl = new PagedList<MS_LogSys>((List<MS_LogSys>)list[1], pageIndex, pageSize, int.Parse(list[0].ToString()));
            return pl;
        }
        public MS_LogLogin GetLoginModelByID(int ID)
        {
            return dal.GetLoginModelByID(ID);
        }
        public MS_LogOperate GetOperateModelByID(int ID)
        {
            return dal.GetOperateModelByID(ID);
        }
        public MS_LogError GetErrorModelByID(int ID)
        {
            return dal.GetErrorModelByID(ID);
        }
        public MS_LogSys GetSysModelByID(int ID)
        {
            return dal.GetSysModelByID(ID);
        }
        #endregion
      
        
     
        public IList<MS_Log> Testlog(string strWhere)
        {
            return dal.Testlog(strWhere);
        }
    }
}
