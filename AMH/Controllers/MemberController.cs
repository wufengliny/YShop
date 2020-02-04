using AMH.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMH.Controllers
{
    [MemAction]
    public class MemberController : Controller
    {
        //
        // GET: /Member/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyLike()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 10;
            int TotalCount = 0;
            int TotalPage = 0;
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            string strWhere = " UID=" + uid+ " and Category='AMHVedio' ";
            List<Yax.Model.UserLike> list = new Yax.BLL.UserLike().GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
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
