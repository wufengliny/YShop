using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using YShop.Filters;
using System.Data;
using System.Text.RegularExpressions;

namespace YShop.Controllers
{
    
    public class HomeController : Controller
    {
        //
        // GET: /Home/ 
        public ActionResult Index()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "  ProductTypeID=5 ";
            Yax.BLL.QiYe_Product bll = new Yax.BLL.QiYe_Product();
            List<Yax.Model.QiYe_Product> list = bll.GetPage(pageIndex, pageSize, strWhere, "id desc", "*", out TotalCount, out TotalPage);
            ViewBag.list = list;
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View();
        }
        
    }
}
