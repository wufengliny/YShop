using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entity;
using UCommon;
namespace VedioWeb.Filters
{
    public class MemActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            int uid = new CurrentUser().ID;
            string Account = new CurrentUser().Account;
            DateTime lastlogintime = new CurrentUser().Lastlogintime; 
            if (uid > 0 && !string.IsNullOrEmpty(Account))
            {
                MS_User model = new BS_User().GetModelByID(uid);
                if (model.LastLoginTime.ToString() != lastlogintime.ToString())
                {
                    Cookies.DeleteCookies(PubStr.MemberCookieName);
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { area = "Default", Controller = "Login", Action = "Login" }));
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { area = "Default", Controller = "Login", Action = "Login" }));
            }
            // filterContext.Result = new RedirectResult("http://www.baidu.com");//也可以跳到别的站点
        }
    }
}