using System.Web;
using System.Web.Mvc;
using YShop.Filters;

namespace YShop
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