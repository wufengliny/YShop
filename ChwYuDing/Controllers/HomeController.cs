using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChwYuDing.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            int TotalRecord = 0;
            int TotalPage = 0;
            string adminUrl = new Yax.BLL.Config().GetModelBy_key("chwadminurl").Value;
            ViewBag.adminUrl = adminUrl;
            List<Yax.Model.Chw_Boat> list = new Yax.BLL.Chw_Boat().GetPage(1, 30, " state='上架中'", "Sort desc", "*", out TotalRecord, out TotalPage);
            ViewBag.list = list;
            return View();
        }
        public ActionResult MHView()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            Yax.Model.Chw_Boat model = new Yax.BLL.Chw_Boat().GetModel(id);
            string adminUrl = new Yax.BLL.Config().GetModelBy_key("chwadminurl").Value;
            ViewBag.Name = model.Name;
            ViewBag.Hit = model.Hit;
            ViewBag.AddTime = model.AddTime;
            ViewBag.Sort = model.Sort;
            ViewBag.MaxNum = model.MaxNum;
            ViewBag.ContactMan = model.ContactMan;
            ViewBag.ContantPhone = model.ContantPhone;
            ViewBag.PriceMemo = model.PriceMemo;
            ViewBag.Introduce = model.Introduce;
            ViewBag.Cover = adminUrl+ model.Cover;
            ViewBag.Memo = model.Memo;
            return View();
        }
    }
}