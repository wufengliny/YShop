using Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Collections;
using System.IO;
using System.Globalization;

namespace YShop.Areas.Admin.Controllers
{
     [YUAction]
    public class ShopController : Controller
    {
        //
        // GET: /Shop/
        [PowerFiler("shoplist28")]
        public ActionResult Index()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1 and enable=1";
            string id = Yax.Common.Utils.GetQueryInt("ID",0).ToString();
            if (id == "0")
            {
                id = "";
            }
            string strname = Yax.Common.Utils.GetSafeQueryString("name"); 
            string strftime = Yax.Common.Utils.GetSafeQueryString("ftime"); 
            string strttime = Yax.Common.Utils.GetSafeQueryString("ttime"); 
            string Typew = Yax.Common.Utils.GetSafeQueryString("Typew"); 
            string cid = Yax.Common.Utils.GetSafeQueryString("cid");
            if (!string.IsNullOrEmpty(id))
            {
                strWhere += "  and  id=" + id;
            }
            if (!string.IsNullOrEmpty(strname))
            {
                strWhere += "  and  name like '%" + strname+"%'";
            }
            if (!string.IsNullOrEmpty(strftime))
            {
                strWhere += "  and  AddTime>'" + strftime+"'";
            }
            if (!string.IsNullOrEmpty(strttime))
            {
                strWhere += "  and  AddTime<'" + strttime + "'";
            }
            if (!string.IsNullOrEmpty(Typew))
            {
                if (Typew == "1")
                {
                    strWhere += "  and  IsTop=1 ";
                }
                if (Typew == "2")
                {
                    strWhere += "  and  IsHot=1 ";
                }
                if (Typew == "3")
                {
                    strWhere += "  and  IsRecomand=1 ";
                }
                if (Typew == "4")
                {
                    strWhere += "  and  IsDown=1 ";
                }
                if (Typew == "5")
                {
                    strWhere += "  and  IsNew=1 ";
                }
            }
            if (!string.IsNullOrEmpty(cid))
            {
                strWhere += "  and  cid=" + cid + "";
            }
            initCategorySelect();
            Yax.BLL.ShopGood bll = new Yax.BLL.ShopGood();
            List<Yax.Model.ShopGood> list = bll.GetPage_view(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }

        [PowerFiler("shoplist28")]
        public ActionResult AddGoods()
        {
            Yax.Model.ShopGood model = new Yax.Model.ShopGood();
            initCategorySelect();
            int id = Yax.Common.Utils.GetQueryInt("id", 0);
            if (id > 0)
            {
                model = new Yax.BLL.ShopGood().GetModel(id);
                if (model != null)
                {
                    ViewBag.Name = model.Name;
                    ViewBag.SearchName = model.SearchName;
                    ViewBag.memo = model.Memo;
                    ViewBag.GoodNO = model.GoodNO;
                    ViewBag.Color = model.Color;
                    ViewBag.Size = model.Size;
                    ViewBag.Source = model.Source;
                    ViewBag.Price = model.Price;
                    ViewBag.SalePrice = model.SalePrice;
                    ViewBag.StockNum = model.StockNum;
                    //
                    Yax.Model.Catagory mc = new Yax.BLL.Catagory().GetModel(model.CID);
                    if (mc != null)
                    {
                        if (mc.PID == 0)
                        {
                            ViewBag.pcateid = mc.ID;
                        }
                        else
                        {
                            ViewBag.hasson = 1;
                            ViewBag.son= GetSon2(mc.PID);
                            ViewBag.pcateid = mc.PID;
                            ViewBag.sonid = mc.ID;
                        }
                    }
                    //ViewBag.cid = model.CID;//
                    ViewBag.JiFen = model.JiFen;
                    ViewBag.IsTop = model.IsTop;
                    ViewBag.IsRecomand = model.IsRecomand;
                    ViewBag.IsHot = model.IsHot;
                    ViewBag.IsNew = model.IsNew;
                    ViewBag.PostFee = model.PostFee;
                    ViewBag.IsDown = model.IsDown;
                    ViewBag.content = model.Detail;
                    ViewBag.cover = model.Cover;
                }
            }
            return View();
        }

       [ValidateInput(false)]
        [HttpPost]
        [PowerFiler("shoplist28")]
        public ActionResult AddGoodsPost()
        {
            Yax.Model.ShopGood model = new Yax.Model.ShopGood();
            int id = Yax.Common.Utils.GetFormInt("id",0);
            int pcid = Yax.Common.Utils.GetFormInt("pcateid",0);
            int scid = Yax.Common.Utils.GetFormInt("sonid", 0);
            if (scid > 0)
            {
                model.CID = scid;
            }
            else {
                model.CID = pcid;
            }


            model.Color = Request.Form["Color"];
            model.Cover = Request.Form["Cover"];
            model.CoverSmall = Yax.Common.UploadPic.UpLoadSmallPic(Server.MapPath(model.Cover), "86*86");
            model.Detail = Request.Form["Content"];
            model.GoodNO = Request.Form["GoodNO"];
            model.IsDown = Yax.Common.Utils.GetFormInt("IsDown",0);
            model.IsHot = Yax.Common.Utils.GetFormInt("IsHot", 0);
            model.IsRecomand = Yax.Common.Utils.GetFormInt("IsRecomand", 0);
            model.IsTop = Yax.Common.Utils.GetFormInt("IsTop", 0);
            model.IsNew = Yax.Common.Utils.GetFormInt("IsNew", 0);
            model.JiFen = Yax.Common.Utils.GetFormInt("JiFen",0);
            model.Memo = Request.Form["Memo"];
            model.Name = Request.Form["Name"];
            model.PostFee = Yax.Common.Utils.GetFormDecimal("PostFee");
            model.Price = Yax.Common.Utils.GetFormDecimal("Price");
            model.SalePrice = Yax.Common.Utils.GetFormDecimal("SalePrice");
            model.SearchName = Request.Form["SearchName"];
            model.Size = Request.Form["Size"];
            model.Source = Request.Form["Source"];
            model.UpdateTime = DateTime.Now;
            model.CategaryName = "";
            model.StockNum = Yax.Common.Utils.GetFormInt("StockNum", 0);
            if (id > 0)
            {
                model.ID = id;
                int resu = new Yax.BLL.ShopGood().UpdateInfo(model);
                if (resu > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "修改商品（" + model.Name + "）成功");
                    return Content("修改成功！");
                }
                else
                {
                    return Content("修改失败");
                }
            }
            else
            {
                model.Enable = 1;
                model.AddTime = DateTime.Now;
                model.Hits = 0;
                model.IP = Yax.Common.Utils.GetClientIP();
                int resa=  new Yax.BLL.ShopGood().Add(model);
                if (resa > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "添加商品（" + model.Name + "）成功");
                    return Content("添加成功！");
                }
                else
                {
                    return Content("添加失败");
                }
            }
            return Content("");
        }
        private void initCategorySelect()
        {
            StringBuilder sbp = new StringBuilder();
            StringBuilder son = new StringBuilder();
            List<Yax.Model.Catagory> list = new Yax.BLL.Catagory().GetList(1000,"*","1=1","Sort desc");
            if (list !=null &&list.Count>0)
            {
                List<Yax.Model.Catagory> listp = list.Where(p => p.PID == 0).ToList();
                int initfip = -1;
                if (listp != null && listp.Count > 0)
                {
                    initfip = listp[0].ID;
                    for (int i = 0; i < listp.Count; i++)
                    {
                        sbp.AppendLine(" <option value=\"" + listp[i].ID + "\">" + listp[i].Name + "</option>");
                    }
                }
                int hasson = -1;
                List<Yax.Model.Catagory> listson = list.Where(p => p.PID == initfip).ToList();
                if (listson != null && listson.Count > 0)
                {
                    hasson = 1;
                    for (int i = 0; i < listson.Count; i++)
                    {
                        son.AppendLine(" <option value=\"" + listson[i].ID + "\">" + listson[i].Name + "</option>");
                    }
                }
                ViewBag.hasson = hasson;
                ViewBag.pstr = sbp.ToString();
                ViewBag.son = son.ToString();
            }
        }
        [PowerFiler("shoplist28")]
        public  ActionResult GetSon()
        {
            int parid = Yax.Common.Utils.GetQueryInt("parid",-1);
            StringBuilder son = new StringBuilder();
            List<Yax.Model.Catagory> list = new Yax.BLL.Catagory().GetList(1000, "*", "1=1 and pid=" + parid, "Sort desc");
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    son.AppendLine(" <option value=\"" + list[i].ID + "\">" + list[i].Name + "</option>");
                }
                return Content(son.ToString());
            }
            else
            {
                return Content("");
            }
        }

        [PowerFiler("shoplist28")]
        public ActionResult upEnable()
        {
            Yax.Model.ShopGood model = new Yax.Model.ShopGood();
            model.ID = Yax.Common.Utils.GetQueryInt("id");
            model.Enable = Yax.Common.Utils.GetQueryInt("enable", 0);
            int res = new Yax.BLL.ShopGood().Update_enable(model);
            if (res > 0)
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }


        [PowerFiler("shopgoodstype29")]
        public ActionResult CateGory()
        {

            string cap = Yax.Common.Utils.GetSafeQueryString("cap");
            if (string.IsNullOrEmpty(cap))
            {
                cap = "0";
            }
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1 and PID=" + cap + " ";
            string name = Yax.Common.Utils.GetSafeQueryString("Name");
            if (!string.IsNullOrEmpty(name))
            {
                strWhere += "  and  Name like '%" + name + "%'";
            }


            Yax.BLL.Catagory bll = new Yax.BLL.Catagory();
            List<Yax.Model.Catagory> list = bll.GetPage(pageIndex, pageSize, strWhere, "Sort desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }

        [PowerFiler("shopgoodstype29")]
        public ActionResult upEnableCateGory()
        {
            Yax.Model.Catagory model = new Yax.Model.Catagory();
            model.ID = Yax.Common.Utils.GetQueryInt("id");
            model.Enable = Yax.Common.Utils.GetQueryInt("enable", 0);
            int res = new Yax.BLL.Catagory().Update_enable(model);
            if (res > 0)
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }

        private string GetSon2(int parid)
        {
            StringBuilder son = new StringBuilder();
            List<Yax.Model.Catagory> list = new Yax.BLL.Catagory().GetList(1000, "*", "1=1 and pid=" + parid, "Sort desc");
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    son.AppendLine(" <option value=\"" + list[i].ID + "\">" + list[i].Name + "</option>");
                }
                return son.ToString();
            }
            else
            {
                return "";
            }
        }


        [PowerFiler("shopgoodstype29")]
        public ActionResult CreateCateGory()
        {
            List<Yax.Model.Catagory> list = new Yax.BLL.Catagory().GetList(200,"*","pid=0 and enable=1 ","Sort desc");
            StringBuilder sb = new StringBuilder();
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    sb.AppendLine("<option value=\""+list[i].ID+"\">"+list[i].Name+"</option>");
                }
            }
            int id = Yax.Common.Utils.GetQueryInt("id",0);
            Yax.Model.Catagory model = new Yax.BLL.Catagory().GetModel(id);
            ViewBag.parentid = Yax.Common.Utils.GetQueryInt("parid",0);
            if (model != null)
            {
                ViewBag.Name = model.Name;
                ViewBag.parentid = model.PID;
                ViewBag.sort = model.Sort;
                ViewBag.memo = model.Memo;
            }
            ViewBag.pstr = sb.ToString();
            return View();
        }
        [PowerFiler("shopgoodstype29")]
        public ActionResult CreateCateGoryPost()
        {
            int id = Yax.Common.Utils.GetFormInt("id", 0);
            Yax.Model.Catagory model = new Yax.Model.Catagory();
            model.Memo = Request.Form["Memo"];
            model.Name = Request.Form["txtname"];
            model.PID = Yax.Common.Utils.GetFormInt("ParentID");
            model.Sort = Yax.Common.Utils.GetFormInt("Sort");
            if (id > 0)
            {
                model.ID = id;
                int res = new Yax.BLL.Catagory().UpdateName(model);
                if (res > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "修改商品类别（" + model.Name + "）成功");
                    return Content("修改成功！");
                }
                else
                {
                    return Content("修改失败！");
                }
            }
            else
            {
                model.AddTime = DateTime.Now;
                model.Enable = 1;
                int res = new Yax.BLL.Catagory().Add(model);
                if (res > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "添加商品类别（" + model.Name + "）成功");
                    return Content("添加成功！");
                }
                else
                {
                    return Content("添加失败！");
                }

            }
            
        }

        [PowerFiler("shoplist28")]
        public ActionResult ShopImg()
        {
            int gid = Yax.Common.Utils.GetQueryInt("gid");
            List<Yax.Model.GoodsUrl> list = new Yax.BLL.GoodsUrl().GetList(20,"*"," enable=1 and gid="+gid,"ID desc");
            return View(list);
        }
        [PowerFiler("shoplist28")]
        public ActionResult AddImg()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            if (id > 0)
            {
                Yax.Model.GoodsUrl model=new Yax.BLL.GoodsUrl().GetModel(id);
                if(model!=null)
                {
                    ViewBag.Cover = model.Url;
                }
               
            }
            return View();
        }
        [PowerFiler("shoplist28")]
        public ActionResult AddimgPost()
        {
            string cover=Request.Form["cover"];
            string smallcover = Yax.Common.UploadPic.UpLoadSmallPic(Server.MapPath(cover),"86*86");
            int gid = Yax.Common.Utils.GetFormInt("gid");
            int id = Yax.Common.Utils.GetFormInt("id");
            //
            Yax.Model.GoodsUrl model = new Yax.Model.GoodsUrl();
            model.Url = cover;
            model.UrlSmalll = smallcover;
          
            if (id > 0)
            {
                model.ID = id;
                int res = new Yax.BLL.GoodsUrl().UpdateInfo(model);
                if (res > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "修改商品图片（" + model.GID + "）成功");
                    return Content("修改成功！");
                }
                else
                {
                    return Content("修改失败！");
                }
            }
            else
            {
                model.GID = gid;
                model.Enable = 1;
                int res = new Yax.BLL.GoodsUrl().Add(model);
                if (res > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "添加商品图片（" + model.GID + "）成功");
                    return Content("添加成功！");
                }
                else
                {
                    return Content("添加失败！");
                }
            }
            return Content("");
        }
        [PowerFiler("shoplist28")]
        public ActionResult upEnableImg()
        {
            Yax.Model.GoodsUrl model = new Yax.Model.GoodsUrl();
            model.ID = Yax.Common.Utils.GetQueryInt("id");
            model.Enable = Yax.Common.Utils.GetQueryInt("enable", 0);
            int res = new Yax.BLL.GoodsUrl().Update_enable(model);
            if (res > 0)
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }

        [PowerFiler("shoplist28")]
        public ActionResult DelImg(string path)
        {
            string serverPath = Server.MapPath(path);
            if(!string.IsNullOrEmpty(path))
            {
                if (System.IO.File.Exists(serverPath))
                {
                    System.IO.File.Delete(serverPath);
                }
            }
            return Content("");
        }





    }
}
