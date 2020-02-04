using Admin.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YShop.Areas.Admin.Controllers
{
    [YUAction]
    public class ChwBoatController : Controller
    {
        //
        // GET: /Admin/ChwBoat/
        [PowerFiler("MyBoat61")]
        public ActionResult MyBoat()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1";
            Yax.BLL.Chw_Boat bll = new Yax.BLL.Chw_Boat();
            List<Yax.Model.Chw_Boat> list = bll.GetPage(pageIndex, pageSize, strWhere, "Sort desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            ViewBag.list = list;
            return View();
        }
        [PowerFiler("MyBoat61")]
        public ActionResult MyBoatAdd()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            if(id>0)
            {
                Yax.Model.Chw_Boat model = new Yax.BLL.Chw_Boat().GetModel(id);
                ViewBag.Name = model.Name;
                ViewBag.Hit = model.Hit;
                ViewBag.AddTime = model.AddTime;
                ViewBag.Sort = model.Sort;
                ViewBag.MaxNum = model.MaxNum;
                ViewBag.ContactMan = model.ContactMan;
                ViewBag.ContantPhone = model.ContantPhone;
                ViewBag.PriceMemo = model.PriceMemo;
                ViewBag.Introduce = model.Introduce;
                ViewBag.Cover = model.Cover;
                ViewBag.Memo = model.Memo;
            }
            return View();
        }
        [PowerFiler("MyBoat61")]
        [ValidateInput(false)]
        public ActionResult MyBoatAddPost()
        {
            Yax.Model.Chw_Boat model = new Yax.Model.Chw_Boat();
            int id = Yax.Common.Utils.GetFormInt("id");
            string Name = Yax.Common.Utils.GetSafeFormString("Name");
            int Hit = Yax.Common.Utils.GetFormInt("Hit");
            DateTime AddTime = Yax.Common.Utils.GetFormDate("AddTime");
            int Sort = Yax.Common.Utils.GetFormInt("Sort");
            int MaxNum= Yax.Common.Utils.GetFormInt("MaxNum");
            string ContactMan= Yax.Common.Utils.GetSafeFormString("ContactMan");
            string ContantPhone = Yax.Common.Utils.GetSafeFormString("ContantPhone");
            string PriceMemo = Yax.Common.Utils.GetFormString("PriceMemo");
            string Introduce = Yax.Common.Utils.GetFormString("Introduce");
            string Cover= Yax.Common.Utils.GetFormString("Cover");
            string Memo = Yax.Common.Utils.GetFormString("Memo");
            model.Name = Name;
            model.Hit = Hit;
            model.AddTime = AddTime;
            model.Sort = Sort;
            model.MaxNum = MaxNum;
            model.ContactMan = ContactMan;
            model.ContantPhone = ContantPhone;
            model.PriceMemo = PriceMemo;
            model.Introduce = Introduce;
            model.Cover = Cover;
            model.Attention = "";
            model.Memo = Memo;
            int res = 0;
            if (id>0)
            {
                Yax.Model.Chw_Boat m_get = new Yax.BLL.Chw_Boat().GetModel(id);
                model.ID = id;
                model.State = m_get.State;
                res= new Yax.BLL.Chw_Boat().Update(model);
            }
            else
            {
                model.State = "上架中";
                res = new Yax.BLL.Chw_Boat().Add(model);
            }
            if(res>0)
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");

            }
        }
        [PowerFiler("MyBoat61")]
        public ActionResult BoatState()
        {
            int id = Yax.Common.Utils.GetFormInt("id");
            int state = Yax.Common.Utils.GetFormInt("state",2);
            string stateStr = "上架中";
            if(state==3)
            {
                stateStr = "已下架";
            }
            string str= " update Chw_Boat set state='"+stateStr+"' where id="+id;
            new Yax.BLL.BCommon().ExecuteScalar(str);
            return Content("");
        }

        [PowerFiler("BoatOrder61")]
        public ActionResult BoatOrder()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = " 1=1 ";
            string Phone = Yax.Common.Utils.GetSafeQueryString("Phone");
            string State = Yax.Common.Utils.GetSafeQueryString("State");
            string Account = Yax.Common.Utils.GetSafeQueryString("Account");
            if(!string.IsNullOrEmpty(Phone))
            {
                strWhere += " and phone='"+Phone+"'";
            }
            if (!string.IsNullOrEmpty(State))
            {
                strWhere += " and State='" + State + "'";
            }
            if (!string.IsNullOrEmpty(Account))
            {
                strWhere += " and Account='" + Account + "'";
            }
            DataTable dt = new Yax.BLL.BCommon().GetPagerViewData(pageIndex, pageSize, strWhere, "ID desc", "View_ChwBoatOrder", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            ViewBag.dt = dt;
            return View();
        }

        [PowerFiler("BoatOrder61")]
        public ActionResult ModOrderState()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            int TotalCount;
            int TotalPage;
            string strWhere = " id="+id;
            DataTable dt = new Yax.BLL.BCommon().GetPagerViewData(1, 1, strWhere, "ID desc", "View_ChwBoatOrder", out TotalCount, out TotalPage);
            DataRow dr = dt.Rows[0];
            ViewBag.dr = dr;
            return View();
        }

        public ActionResult ModOrderStatePost()
        {
            int id = Yax.Common.Utils.GetFormInt("id");
            string state = Yax.Common.Utils.GetSafeFormString("state");
            string str = "  update Chw_Order set state='"+state+"' where id="+id;
            new Yax.BLL.BCommon().ExecuteScalar(str);
            return Content("操作成功");
        }

    }
}
