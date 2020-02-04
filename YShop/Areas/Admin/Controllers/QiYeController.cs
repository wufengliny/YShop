using Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace YShop.Areas.Admin.Controllers
{
    [YUAction]
    public class QiYeController : Controller
    {
        //
        // GET: /Admin/QiYe/

        [PowerFiler("liuyan25")]
        public ActionResult Index()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1 and Enable=1";
            Yax.BLL.QiYe_LiuYan bll = new Yax.BLL.QiYe_LiuYan();
            List<Yax.Model.QiYe_LiuYan> list = bll.GetPage(pageIndex, pageSize, strWhere, "id desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }

        [PowerFiler("liuyan25")]
        public ActionResult LiuYanDetail(int id)
        {
            Yax.Model.QiYe_LiuYan model = new Yax.BLL.QiYe_LiuYan().GetModel(id);
            if(model.ID>0)
            {
                ViewBag.Title = model.Title;
                ViewBag.Name = model.Name;
                ViewBag.Email = model.Email;
                ViewBag.AddTime = model.AddTime;
                ViewBag.Detail = model.Detail;
            }
            return View();
        }

        [PowerFiler("ProductType26")]
        public ActionResult ProductType()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1 ";
            Yax.BLL.QiYe_ProductType bll = new Yax.BLL.QiYe_ProductType();
            List<Yax.Model.QiYe_ProductType> list = bll.GetPage(pageIndex, pageSize, strWhere, "id desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }
        [PowerFiler("ProductType26")]
        public ActionResult ProductTypeAdd()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            if(id>0)
            {
                Yax.Model.QiYe_ProductType model = new Yax.BLL.QiYe_ProductType().GetModel(id);
                if (model != null)
                {
                    ViewBag.Name = model.Name;
                    ViewBag.SeoKeyword = model.SeoKeyword;
                    ViewBag.SeoDescription = model.SeoDescription;
                }
            }
            return View();
        }
        [PowerFiler("ProductType26")]
        public ActionResult ProductTypeAddPost(Yax.Model.QiYe_ProductType model)
        {
            int res = 0;
            string doName = "";
            if(string.IsNullOrEmpty(model.SeoDescription))
            {
                model.SeoDescription = "";
            }
            if (string.IsNullOrEmpty(model.SeoKeyword))
            {
                model.SeoKeyword = "";
            }
            if (model.ID > 0)
            {
                doName = "修改";
                res = new Yax.BLL.QiYe_ProductType().Update(model);
            }
            else
            {
                doName = "添加";
                res = new Yax.BLL.QiYe_ProductType().Add(model);
            }
            if (res > 0)
            {
                new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + doName +"产品分类(" + model.Name + ")成功");
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
            return Content("");
        }
        [PowerFiler("ProductType26")]
        public ActionResult DelProductType(int id)
        {
           int res= new Yax.BLL.QiYe_ProductType().Delete(id);
            if (res > 0)
            {
                new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name +   "删除产品分类(" + id + ")成功");
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }

        [PowerFiler("Product27")]
        public ActionResult Product()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1 ";
            string Name = Yax.Common.Utils.GetSafeFormString("Name"); 
            int IsIndex = Yax.Common.Utils.GetFormInt("IsIndex");
            int ProductTypeID = Yax.Common.Utils.GetFormInt("ProductTypeID");
            if (!string.IsNullOrEmpty(Name))
            {
                strWhere += " and Name like '%"+ Name.Trim() + "%'";
            }
            if(ProductTypeID>0)
            {
                strWhere += " and ProductTypeID="+ ProductTypeID;
            }
            if (IsIndex > 0)
            {
                strWhere += " and IsIndex=1 ";
            }
            Yax.BLL.QiYe_Product bll = new Yax.BLL.QiYe_Product();
            List<Yax.Model.QiYe_Product> list = bll.GetPage(pageIndex, pageSize, strWhere, "id desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);

            int t1;
            int t2;
            List<Yax.Model.QiYe_ProductType> listType =new Yax.BLL.QiYe_ProductType().GetPage(1, 100, "1=1", "id desc", "*", out t1, out t2);
            ViewBag.listType = listType;
            return View(list);
        }
        [PowerFiler("Product27")]
        public ActionResult ProductAdd()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            int protypeid = 0;
            DateTime addTime = DateTime.Now.AddYears(-100);
            if(id>0)
            {
                Yax.Model.QiYe_Product model = new Yax.BLL.QiYe_Product().GetModel(id);
                if(model!=null)
                {
                    ViewBag.Name = model.Name;
                    ViewBag.Cover = model.Cover;
                    ViewBag.ProductNO = model.ProductNO;
                    ViewBag.ProductTypeID = model.ProductTypeID;
                    ViewBag.SeoDescription = model.SeoDescription;
                    ViewBag.Seokeyword = model.Seokeyword;
                    ViewBag.IsIndex = model.IsIndex;
                    ViewBag.AddTime = model.AddTime;
                    ViewBag.Introduce = model.Introduce;
                    ViewBag.Detail = model.Detail;
                    ViewBag.Hits = model.Hits;
                    protypeid = model.ProductTypeID;
                    addTime = model.AddTime;
                }
            }
            else
            {
                ViewBag.Hits = 1;
            }
            if (addTime<DateTime.Now.AddYears(-10))
            {
                ViewBag.AddTime = DateTime.Now;
            }
            int TotalCount;
            int TotalPage;
            StringBuilder sb = new StringBuilder(1000);
            List<Yax.Model.QiYe_ProductType> listType = new Yax.BLL.QiYe_ProductType().GetPage(1, 100, "1=1", "id desc", "*", out TotalCount, out TotalPage);
            if (listType != null && listType.Count > 0)
            {
                for(int i=0;i<listType.Count;i++)
                {
                    string strselect = protypeid == listType[i].ID ? "selected=\"selected\"" : "";
                    sb.AppendLine(" <option "+ strselect + "  value=\""+ listType[i].ID + "\">" + listType[i].Name+"</option>");
                }
            }
            ViewBag.sbtype = sb.ToString();
            return View();
        }
        [ValidateInput(false)]
        [PowerFiler("Product27")]
        public ActionResult ProtectAddPost()
        {
            try
            {
                Yax.Model.QiYe_Product model = new Yax.Model.QiYe_Product();
                int id = Yax.Common.Utils.GetFormInt("id");
                int res = 0;
                model.Seokeyword = Request.Form["Seokeyword"];
                model.SeoDescription = Request.Form["SeoDescription"];
                model.ProductTypeID = Yax.Common.Utils.GetFormInt("ProductTypeID");
                model.ProductNO = Request.Form["ProductNO"];
                model.Name = Request.Form["Name"].Trim();
                model.IsIndex = Yax.Common.Utils.GetFormInt("IsIndex");
                model.Introduce = Request.Form["Introduce"];
                model.Cover = Request.Form["Cover"];
                model.Detail = Request.Form["Content"];
                model.Color = "";
                model.Size = "";
                model.Price = 0;
                model.Hits = Yax.Common.Utils.GetFormInt("Hits");
                if (id > 0)
                {
                    model.ID = id;
                    res = new Yax.BLL.QiYe_Product().Update_info(model);
                }
                else
                {
                    model.AddTime = DateTime.Now;
                    model.Enable = 1;
                   
                    res = new Yax.BLL.QiYe_Product().Add(model);
                }
                if (res > 0)
                {
                    return Content("操作成功");
                }
                else
                {
                    return Content("操作失败");
                }
            }
            catch(Exception e)
            {
                return Content("网络繁忙993"+e.Message+e.StackTrace);
            }
            
            return Content("");
        }

        [PowerFiler("Product27")]
        public ActionResult DelProduct(int id)
        {
            int res= new Yax.BLL.QiYe_Product().Delete(id);
            if(id>0)
            {
                return Content("删除成功");
            }
            else
            {
                return Content("删除失败");
            }
        }

        [PowerFiler("Product27")]
        public ActionResult ProductImg()
        {

            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            int productID = Yax.Common.Utils.GetQueryInt("id");
            Yax.Model.QiYe_Product model = new Yax.BLL.QiYe_Product().GetModel(productID);
            if(model!=null)
            {
                ViewBag.name = model.Name;
            }
            string strWhere = " 1=1 and category='qiyeproductimg' and ImgType="+productID+" ";
            Yax.BLL.Web_Img bll = new Yax.BLL.Web_Img();
            List<Yax.Model.Web_Img> list = bll.GetPage(pageIndex, pageSize, strWhere, "sort asc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);

            return View(list);
        }
        [PowerFiler("Product27")]
        public ActionResult ProductImgAdd()
        {
            ViewBag.Sort = 1;
            int imgid = Yax.Common.Utils.GetQueryInt("imgid");
            if(imgid>0)
            {
                Yax.Model.Web_Img model = new Yax.BLL.Web_Img().GetModel(imgid);
                ViewBag.Imgurl = model.Imgurl;
                ViewBag.Sort = model.Sort;
            }
            return View();
        }
        [PowerFiler("Product27")]
        public ActionResult ProductImgAddPost()
        {
            string imgurl = Request.Form["Imgurl"];
            int imgid = Yax.Common.Utils.GetFormInt("imgid");
            int res = 0;
            if (!string.IsNullOrEmpty(imgurl))
            {
                Yax.Model.Web_Img model = new Yax.Model.Web_Img();
                model.Imgurl = imgurl;
                model.Sort = Yax.Common.Utils.GetFormInt("Sort");
                if (imgid>0)
                {
                    model.ID = imgid;
                    res = new Yax.BLL.Web_Img().Update_sortimg(model);
                }
                else
                {
                    model.AddTime = DateTime.Now;
                    model.Category = "qiyeproductimg";
                    model.Enabale = 1;
                    model.Href = "";
                    model.ImgType = Yax.Common.Utils.GetFormInt("ProductID");
                    model.ImgUlrSmall = "";
                    model.Memo = "";
                    model.Name = "";
                    model.OpenType = "";
                    res = new Yax.BLL.Web_Img().Add(model);
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
            else
            {
                return Content("请选择上传的图片");
            }
           
        }
        [PowerFiler("Product27")]
        public ActionResult ProductImgDel()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            if(id>0)
            {
                new Yax.BLL.Web_Img().Delete(id);
                return Content("删除成功");
            }
            else
            {
                return Content("删除失败");
            }
        }


        //[PowerFiler("Product27")]
        public ActionResult ProductCoverImgDel()
        {
            string mapPath;
            try
            {
                string url = Request.Form["img"];
                mapPath = Server.MapPath(url);
                if (System.IO.File.Exists(mapPath))
                {
                    System.IO.File.Delete(mapPath);
                    return Content("删除成功");
                }
                else
                {
                    return Content("未找到可删除的图片");
                }
            }
            catch
            {
                return Content("");
            }
           
            return Content("删除成功");//
        }
    }
}
