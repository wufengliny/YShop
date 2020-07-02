using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using BLL;
using VedioAdmin.Filters;
using ComEnum;

namespace VedioAdmin.Controllers
{
    [IsAuditorFilter]
    public class LogController : BaseController
    {
        BS_Log bll = new BS_Log();

        [Power("loginlog",OpenTypeEnum.Page,true)]
        public ActionResult LoginLog(int id, string UserName, string BeginTime, string EndTime, string memo, int Statu = 0, int pi = 1)
        {
            string dangerWords = string.Empty;
            UserName = UCommon.DangerSQLHelper.GetSafeStringForQuery(UserName, ref dangerWords);
            BeginTime = UCommon.DangerSQLHelper.GetSafeStringForQuery(BeginTime, ref dangerWords);
            EndTime = UCommon.DangerSQLHelper.GetSafeStringForQuery(EndTime, ref dangerWords);
            memo = UCommon.DangerSQLHelper.GetSafeStringForQuery(memo, ref dangerWords);
            if (!string.IsNullOrEmpty(dangerWords))
            {
                OperateLogAdd("查询操作(" + Request.QueryString + ")含有危险字符串，已自动过滤（" + dangerWords + "）", true);
            }
            int OperatorType = id;
            ViewBag.OperatorType = OperatorType;
            return View(bll.LoginLogPager(OperatorType, UserName, BeginTime, EndTime, memo, Statu, pi, PageSize));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">权限标识ID</param>
        /// <param name="logid">日志表的ID</param>
        /// <returns></returns>
        [Power("loginlogdetail", OpenTypeEnum.Dialog)]
        public ActionResult LoginLogDetail(int id, int logid)
        {
            MS_LogLogin model = bll.GetLoginModelByID(logid);
            if (model.OperatorType != id)
            {
                return Content("无权访问");
            }
            return View(model);
        }



        [Power("operatelog", OpenTypeEnum.Page,true)]
        public ActionResult OperateLog(int id, string UserName, string BeginTime, string EndTime, string memo, int IsSensitive = -1, int pi = 1)
        {
            string dangerWords = string.Empty;
            UserName = UCommon.DangerSQLHelper.GetSafeStringForQuery(UserName, ref dangerWords);
            BeginTime = UCommon.DangerSQLHelper.GetSafeStringForQuery(BeginTime, ref dangerWords);
            EndTime = UCommon.DangerSQLHelper.GetSafeStringForQuery(EndTime, ref dangerWords);
            memo = UCommon.DangerSQLHelper.GetSafeStringForQuery(memo, ref dangerWords);
            if (!string.IsNullOrEmpty(dangerWords))
            {
                OperateLogAdd("查询操作(" + Request.QueryString + ")含有危险字符串，已自动过滤（" + dangerWords + "）", true);
            }
            int OperatorType = id;
            ViewBag.OperatorType = OperatorType;
            return View(bll.OperateLogPager(OperatorType, UserName, BeginTime, EndTime, memo, IsSensitive, pi, PageSize));
        }

        [Power("operatelogdetail", OpenTypeEnum.Dialog)]
        public ActionResult OperateLogDetail(int id, int logid)
        {
            MS_LogOperate model = bll.GetOperateModelByID(logid);
            if (model.OperatorType!= id)
            {
                return Content("无权访问");
            }
            return View(model);
        }

        [Power("errorlog", OpenTypeEnum.Page,true)]
        public ActionResult ErrorLog(string BeginTime, string EndTime, string Message, int pi = 1)
        {
            string dangerWords = string.Empty;
            BeginTime = UCommon.DangerSQLHelper.GetSafeStringForQuery(BeginTime, ref dangerWords);
            EndTime = UCommon.DangerSQLHelper.GetSafeStringForQuery(EndTime, ref dangerWords);
            Message = UCommon.DangerSQLHelper.GetSafeStringForQuery(Message, ref dangerWords);
            if (!string.IsNullOrEmpty(dangerWords))
            {
                OperateLogAdd("查询操作(" + Request.QueryString + ")含有危险字符串，已自动过滤（" + dangerWords + "）", true);
            }
            return View(bll.ErrorLogPager(BeginTime, EndTime, Message, pi, PageSize));
        }
        [Power("errorlogdetail", OpenTypeEnum.Dialog)]
        public ActionResult ErrorLogDetail(int logid)
        {
            MS_LogError model = bll.GetErrorModelByID(logid);
            return View(model);
        }

        [Power("syslog", OpenTypeEnum.Page,true)]
        public ActionResult SysLog(string BeginTime, string EndTime,string Memo, int LogType=0, int pi = 1)
        {
            string dangerWords = string.Empty;
            BeginTime = UCommon.DangerSQLHelper.GetSafeStringForQuery(BeginTime, ref dangerWords);
            EndTime = UCommon.DangerSQLHelper.GetSafeStringForQuery(EndTime, ref dangerWords);
            Memo = UCommon.DangerSQLHelper.GetSafeStringForQuery(Memo, ref dangerWords);
            if (!string.IsNullOrEmpty(dangerWords))
            {
                OperateLogAdd("查询操作(" + Request.QueryString + ")含有危险字符串，已自动过滤（" + dangerWords + "）", true);
            }
            return View(bll.SysLogPager(BeginTime, EndTime, LogType, Memo, pi, PageSize));
        }
        [Power("syslogdetail", OpenTypeEnum.Dialog)]
        public ActionResult SysLogDetail(int logid)
        {
            MS_LogSys model = bll.GetSysModelByID(logid);
            return View(model);
        }
    }
}
