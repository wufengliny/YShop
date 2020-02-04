using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Yax.Common;

namespace MVWeb.Filters
{
    public class MemActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            string Account = new Yax.BLL.QuickData.CurrentUserMV().Account;
            string lastlogintime = new Yax.BLL.QuickData.CurrentUserMV().lastlogintime;
            if (uid > 0&&!string.IsNullOrEmpty(Account))
            {
                Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModel(uid);
                if(model.LastLoginTime.ToString()!= lastlogintime)
                {
                    Yax.Common.Cookies.DeleteCookies(Yax.Common.PubStr.MemberCookieName);
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { area = "Default", Controller = "Login", Action = "LoninOther" }));
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