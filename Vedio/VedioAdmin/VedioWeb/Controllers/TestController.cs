using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VedioWeb.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            DateTime dt = DateTime.Now;
            return Content(dt.ToLocalTime()+"--"+dt.ToString());
        }
        /// <summary>
        /// 应用页面/aca/play
        /// </summary>
        /// <returns></returns>
   
        public ActionResult Article()
        {
            return View();
        }
    }
}