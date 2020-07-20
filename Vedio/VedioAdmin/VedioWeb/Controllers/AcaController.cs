using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VedioWeb.Controllers
{
    public class AcaController : Controller
    {
        // GET: Aca
        public ActionResult Index(int pi = 1)
        {
            string strWhere = " where cv.Enable=1  ";
            string SortStr = "[IsTop] Desc,[Sort] desc";
            string Category = UCommon.UUtils.GetSafeQueryString("Category");
            if (!string.IsNullOrEmpty(Category))
            {
                strWhere += " and cv.Category='"+ Category + "'";
            }
            ViewBag.picurl = new BS_Config().GetModelByKeyFromCache("picurl").Value;
            ViewBag.weburl = new BS_Config().GetModelByKeyFromCache("weburl").Value;
            var list = new BC_Vedios().Pager(pi, 20, strWhere, SortStr);
            return View(list);
        }

        public ActionResult Test()
        {
            return Content("");
        }
    }
}