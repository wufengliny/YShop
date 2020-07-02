using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VedioAdmin.Controllers
{
    /// <summary>
    /// 错误 无权限 跳转到此处 
    /// </summary>
    
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Dialog(string msg)
        {
            ViewBag.msg = msg;
            return View();
        }
        public ActionResult NoAuth()
        {
            return View();
        }
        public ActionResult Msg()
        {
            return Content("您的权限不足");
        }
        public ActionResult DangerSearch(string msg)
        {
            ViewBag.msg = msg;
            return View();
        }

    }
}