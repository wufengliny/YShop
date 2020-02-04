using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Yax.Common;

namespace TPay.Filters
{
    public class AgentActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            int uid = new Yax.BLL.QuickData.CurrentUserPayAgent().ID;
            string Account = new Yax.BLL.QuickData.CurrentUserPayAgent().Account;
            string lastlogintime = new Yax.BLL.QuickData.CurrentUserPayAgent().lastlogintime;
            if (uid > 0 && !string.IsNullOrEmpty(Account))
            {
                //Yax.Model.TPay_User model = new Yax.BLL.TPay_User().GetModel(uid);
                //if (model.LastLoginTime.ToString() != lastlogintime)
                //{
                //    Yax.Common.Cookies.DeleteCookies(Yax.Common.PubStr.MemberCookieName);
                //    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { area = "Default", Controller = "Login", Action = "LoninOther" }));
                //}
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { area = "Default", Controller = "Login", Action = "DLLogin" }));
            }
            // filterContext.Result = new RedirectResult("http://www.baidu.com");//也可以跳到别的站点
        }
    }
}