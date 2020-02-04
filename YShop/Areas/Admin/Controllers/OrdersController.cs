using Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YShop.Areas.Admin.Controllers
{
     [YUAction]
    public class OrdersController : Controller
    {
        //
        // GET: /Orders/

        [PowerFiler("orders24")]
        public ActionResult Index()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 10;
            int TotalCount;
            int TotalPage;
            string strWhere = "enable=1";
            string OrderNO = Yax.Common.Utils.GetSafeQueryString("OrderNO"); 
            string Statu = Yax.Common.Utils.GetSafeQueryString("Statu"); 
            string Uname = Yax.Common.Utils.GetSafeQueryString("Uname"); 
            string strftime = Yax.Common.Utils.GetSafeQueryString("ftime"); 
            string strttime = Yax.Common.Utils.GetSafeQueryString("ttime"); 
            if (!string.IsNullOrEmpty(OrderNO))
            {
                strWhere += "  and  OrderNO like '%" + OrderNO + "%'";
            }
            if (!string.IsNullOrEmpty(Statu))
            {
                strWhere += "  and  Statu=" + Statu;
            }
            if (!string.IsNullOrEmpty(Uname))
            {
                strWhere += "  and  Uname like '%" + Uname+"%'";
            }
            if (!string.IsNullOrEmpty(strftime))
            {
                strWhere += "  and  AddTime>'" + strftime + "'";
            }
            if (!string.IsNullOrEmpty(strttime))
            {
                strWhere += "  and  AddTime<'" + strttime + "'";
            }

            Yax.BLL.ShopOrder bll = new Yax.BLL.ShopOrder();
            List<Yax.Model.ShopOrder> list = bll.GetPage_view(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }
        [PowerFiler("orders24")]
        public ActionResult delorder()
        {
            Yax.Model.ShopOrder model = new Yax.Model.ShopOrder();
            model.ID = Yax.Common.Utils.GetQueryInt("id");
            model.Enable = Yax.Common.Utils.GetQueryInt("enable", 0);
            int res = new Yax.BLL.ShopOrder().Update_enable(model);
            if (res > 0)
            {
                new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "删除订单,订单号（" + Request.QueryString["OrderNO"] + "），ID："+model.ID+"成功");
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }
        [PowerFiler("orders24")]
        public ActionResult DoSendGood()
        {
            Yax.Model.ShopOrder model = new Yax.Model.ShopOrder();
            int id = Yax.Common.Utils.GetQueryInt("id");
            model = new Yax.BLL.ShopOrder().GetModel(id);
            if (model != null)
            {
                ViewBag.WuliuName = model.WuliuName;
                ViewBag.WuliuNo = model.WuliuNo;
            }
            return View();
        }
        [PowerFiler("orders24")]
        public ActionResult DoSendGoodPost()
        {
            Yax.Model.ShopOrder model = new Yax.Model.ShopOrder();
            int id = Yax.Common.Utils.GetFormInt("id");
            string WuliuName = Request.Form["WuliuName"];
            string WuliuNo = Request.Form["WuliuNo"];
            model.WuliuName = WuliuName;
            model.WuliuNo = WuliuNo;
            model.ID = id;
            string OrderNO = Request.Form["OrderNO"];
            int res = new Yax.BLL.ShopOrder().Update_wuliu(model);
            if (res > 0)
            {
                model.Statu = 2;
                new Yax.BLL.ShopOrder().Update_statu(model);
                new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "发货（订单号：" + OrderNO + "订单ID:" + model.ID + "）成功");
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }



    }
}
