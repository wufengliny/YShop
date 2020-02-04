using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YWeb.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            List<Yax.Model.Article> list= new Yax.BLL.Article().GetList(10,"*","1=1","ID desc");
            int t1;
            int t2;
            List<Yax.Model.QiYe_ProductType> list2 = new Yax.BLL.QiYe_ProductType().GetPage(1,10, "1=1", "ID desc", "*",out t1,out t2);
            Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModel(1);
            return Content(list[0].Detail+model.RealName);
        }
        public ActionResult test()
        {
            int tid = Yax.Common.Utils.GetQueryInt("tid",0);
            int pageIndex = 1; ;
            int pageSize = 10;
            int TotalCount;
            int TotalPage;
            int pid = Yax.Common.Utils.GetQueryInt("pid");
            if (tid==1)
            {
                ViewBag.seokey = new Yax.BLL.Config().GetModelBy_key("qiyeproductseokey").Value;
                ViewBag.seodesc = new Yax.BLL.Config().GetModelBy_key("qiyeproductseodesc").Value;
                ViewBag.title = new Yax.BLL.Config().GetModelBy_key("qiyeanliseotitle").Value;
            }
            if(tid==2)
            {
                string strWhere = "1=1 and Enable=1 ";
                if (pid > 0)
                {
                    strWhere += " and ProductTypeID=" + pid;
                }
               
                List<Yax.Model.QiYe_Product> list =new Yax.BLL.QiYe_Product().GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
                ViewBag.TotalPage = TotalPage;
                ViewBag.TotalCount = TotalCount;
                ViewBag.pageIndex = pageIndex;
                ViewBag.list = list;
            }
            if(tid == 3)
            {
                int t1;
                int t2;
                List<Yax.Model.QiYe_ProductType> listtype = new Yax.BLL.QiYe_ProductType().GetPage(1, 100, "1=1", "ID desc", "*", out t1, out t2);
                ViewBag.listtype = listtype;
            }
            if(tid == 4)
            {
                string strWhere = "1=1 and Enable=1 ";
                if (pid > 0)
                {
                    strWhere += " and ProductTypeID=" + pid;
                }
                Yax.BLL.QiYe_Product bll = new Yax.BLL.QiYe_Product();
                List<Yax.Model.QiYe_Product> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
                ViewBag.TotalPage = TotalPage;
                ViewBag.TotalCount = TotalCount;
                ViewBag.pageIndex = pageIndex;

                int t1;
                int t2;
                List<Yax.Model.QiYe_ProductType> listtype = new Yax.BLL.QiYe_ProductType().GetPage(1, 100, "1=1", "ID desc", "*", out t1, out t2);
                ViewBag.listtype = listtype;
            }
            if(tid == 5)
            {
                ViewBag.seokey = new Yax.BLL.Config().GetModelBy_key("qiyeproductseokey").Value;
                ViewBag.seodesc = new Yax.BLL.Config().GetModelBy_key("qiyeproductseodesc").Value;
                ViewBag.title = new Yax.BLL.Config().GetModelBy_key("qiyeanliseotitle").Value;

                string strWhere = "1=1 and Enable=1 ";
                if (pid > 0)
                {
                    strWhere += " and ProductTypeID=" + pid;
                }
                Yax.BLL.QiYe_Product bll = new Yax.BLL.QiYe_Product();
                List<Yax.Model.QiYe_Product> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
                ViewBag.TotalPage = TotalPage;
                ViewBag.TotalCount = TotalCount;
                ViewBag.pageIndex = pageIndex;

                int t1;
                int t2;
                List<Yax.Model.QiYe_ProductType> listtype = new Yax.BLL.QiYe_ProductType().GetPage(1, 100, "1=1", "ID desc", "*", out t1, out t2);
                ViewBag.listtype = listtype;
            }
            return Content(ViewBag.title);
        }
    }
}
