using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;


namespace VedioAdmin.Filters
{
    /// <summary>
    /// 直接从cookie 判断是否登录，是否有权限 不读取数据库数据
    /// </summary>
    public class IsAuditorFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                string enstr = filterContext.HttpContext.User.Identity.Name;
                string mess = UCommon.SecurityHelper.De_Login(enstr);
                string[] str = mess.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                if (string.IsNullOrEmpty(enstr)|| string.IsNullOrEmpty(mess) || str.Length != 7)
                {
                    FormsAuthentication.SignOut();
                    filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary(new { Controller = "Login", Action = "index" }));
                }
            }
            catch
            {
                FormsAuthentication.SignOut();
                filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary(new { Controller = "Login", Action = "index" }));
            }
        }
    }
}