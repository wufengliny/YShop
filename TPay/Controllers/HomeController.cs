using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPay.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            string str = "select PayPrice from ShopOrder where id=1";
            System.Data.DataTable dt = new Yax.BLL.BCommon().GetDataBySQL(str);
            return Content(dt.Rows[0][0].ToString());
        }
    }
}