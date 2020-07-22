using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCommon;
namespace VedioWeb.Filters
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
                new BS_Log().ErrorLogAdd(filterContext.Exception.Message, filterContext.Exception.StackTrace);
            }
            catch (Exception ex)
            {
                HanderFalse = "T";
                filterContext.ExceptionHandled = true;  //设置为True  否则 异常仍然会抛出 不会跳到/Login/Info
                UUtils.WriteFileLog_Web("连接不上数据库： errmsg:" + ex.Message + "----Url：" + url + "时间：" + DateTime.Now);
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