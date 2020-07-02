
using VedioAdmin.Filters;
using System.Web;
using System.Web.Mvc;


namespace VedioAdmin
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionFilter());
        }
    }
}
