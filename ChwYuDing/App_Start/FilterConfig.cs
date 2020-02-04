using ChwYuDing.Filters;
using System;
using System.Web;
using System.Web.Mvc;

namespace ChwYuDing
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ErrorFilter());
        }
    }
}