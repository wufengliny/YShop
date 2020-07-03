using VedioAdmin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VedioAdmin.Controllers
{
    [IsAuditorFilter]
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            
            return Content("系统繁忙");
        }
        public ActionResult Main()
        {
            //0608C983C7429AB0D9C2675CA5740704D1B835C1BE091E99C12D542C063495BD1E980F9E3ED87B18B6C812315E7C568AEBF4D629F9C8904AD4D853B33E4EED66D3F91C5087DA3F47A3898B32A5B5EA8827E24111EADC8483EFF89F2B6E50327AD97BC333514CFFF84471C901A7D140C3
            string str = System.Web.HttpContext.Current.User.Identity.Name;
            ViewBag.str = str;
            return View();
        }



    }
}