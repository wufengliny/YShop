using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace TPay.Filters
{
    public class ErrorFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string HanderFalse = "F";
            string url = "";
            try
            {
                url = filterContext.RequestContext.HttpContext.Request.Url.ToString();
                string errmsg = "信息：" + filterContext.Exception.Message + "----<br/>堆栈：" + filterContext.Exception.StackTrace;
                new Yax.BLL.ZY_Log().AddLog(2, errmsg);
                Yax.Common.Utils.WriteFileLog_Web("系统错误：errmsg:" + errmsg + "----Url：" + url + "时间：" + DateTime.Now);
            }
            catch (Exception ex)
            {
                HanderFalse = "T";
                filterContext.ExceptionHandled = true;  //设置为True  否则 异常仍然会抛出 不会跳到/Login/Info
                Yax.Common.Utils.WriteFileLog_Web("连接不上数据库： errmsg:" + ex.Message + "----Url：" + url + "时间：" + DateTime.Now);
                filterContext.Result = new RedirectResult("/Login/Error?msg=系统繁忙002");
            }
            if (HanderFalse == "F")
            {
                filterContext.ExceptionHandled = true;
                filterContext.Result = new RedirectResult("/Login/Error?msg=系统繁忙001");
            }

        }
    }
}