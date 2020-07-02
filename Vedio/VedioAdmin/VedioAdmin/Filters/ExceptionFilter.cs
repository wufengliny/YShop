using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using BLL;

namespace VedioAdmin.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string controller = filterContext.RouteData.Values["controller"] as string;
            string action = filterContext.RouteData.Values["action"] as string;
            new BS_Log().ErrorLogAdd(filterContext.Exception.Message, filterContext.Exception.StackTrace);
            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("/Base/Error");
        }
    }
}