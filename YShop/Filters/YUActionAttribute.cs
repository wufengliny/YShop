using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Yax.Common;
namespace Admin.Filters
{
    public class YUActionAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string userid = Cookies.GetCookies(PubStr.ManageCookieName, "userid");
            if (!string.IsNullOrEmpty(userid))
            {
                //参数过滤
                HandleSQL(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new {area="admin",  Controller="Login",Action="Login"}));
            }
            // filterContext.Result = new RedirectResult("http://www.baidu.com");//也可以跳到别的站点
        }
        private void HandleSQL(ActionExecutingContext filterContext)
        {
            try
            {
                var actionParameters = filterContext.ActionDescriptor.GetParameters();
                string strurl = filterContext.RequestContext.HttpContext.Request.RawUrl;

                if (strurl.ToLower().Contains("update"))
                {
                    filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary(new { Controller = "Login", Action = "Login", message = "自动调整" }));
                }
                if (strurl.ToLower().Contains("delete"))
                {
                    filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary(new { Controller = "Login", Action = "Login", message = "自动调整" }));
                }
                if (strurl.ToLower().Contains("truncate"))
                {
                    filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary(new { Controller = "Login", Action = "Login", message = "自动调整" }));
                }
                if (strurl.ToLower().Contains("drop"))
                {
                    filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary(new { Controller = "Login", Action = "Login", message = "自动调整" }));
                }
                if (strurl.ToLower().Contains("exec"))
                {
                    filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary(new { Controller = "Login", Action = "Login", message = "自动调整" }));
                }
                if (strurl.ToLower().Contains("select"))
                {
                    filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary(new { Controller = "Login", Action = "Login", message = "自动调整" }));
                }
                if (strurl.ToLower().Contains("declare"))
                {
                    filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary(new { Controller = "Login", Action = "Login", message = "自动调整" }));
                }


                foreach (var p in actionParameters)
                {
                    if (p.ParameterType == typeof(string))
                    {
                        if (filterContext.ActionParameters[p.ParameterName] != null)
                        {
                            filterContext.ActionParameters[p.ParameterName] = FilterSQL(filterContext.ActionParameters[p.ParameterName].ToString());
                        }
                    }
                }
            }
            catch
            {
                GC.Collect();
            }
        }


        public static string FilterSQL(object sInput)
        {
            if (sInput == null)
            {
                return null;
            }
            if (sInput.ToString() == "")
            {
                return "";
            }

            string str = sInput.ToString();
            while (true)
            {
                if (str.Length == (str = Regex.Replace(str, "(insert|select|exec|delete|update|drop|create|truncate|declare|xp_cmdshell|union|)", "", RegexOptions.IgnoreCase)).Length) break;
            }
            return str;
        }



    }
}