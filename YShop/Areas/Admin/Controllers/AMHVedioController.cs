using Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Data;

namespace YShop.Areas.Admin.Controllers
{
    [YUAction]
    public class AMHVedioController : Controller
    {
        //
        // GET: /Admin/AMHVedio/

        #region 37视频
        [PowerFiler("AmhVedio39")]
        public ActionResult Index()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = " FromSite='https://adcxx08.com'";
            Yax.BLL.AMH_Vedio bll = new Yax.BLL.AMH_Vedio();
            string Category = Yax.Common.Utils.GetSafeQueryString("Category");
            int ID = Yax.Common.Utils.GetQueryInt("ID");
            int IsFree = Yax.Common.Utils.GetQueryInt("IsFree");
            string Name = Yax.Common.Utils.GetSafeQueryString("Name");
            if (string.IsNullOrEmpty(Category))
            {
                Category = "自拍";
            }
        
            ViewBag.Category = Category;
            if (!string.IsNullOrEmpty(Category))
            {
                strWhere += " and Category='" + Category + "'";
            }
            if (!string.IsNullOrEmpty(Name))
            {
                strWhere += " and Name like '%" + Name + "%'";
            }
            if (ID > 0)
            {
                strWhere += " and ID=" + ID;
            }
            if (IsFree > 0)
            {
                strWhere += " and IsFree=" + IsFree;
            }
            List<Yax.Model.AMH_Vedio> list = bll.GetPage(pageIndex, pageSize, strWhere, "id desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            ViewBag.list = list;
            ViewBag.fileurl = new Yax.BLL.Config().GetModelBy_key("fileurl").Value;
            return View();
        }

        [PowerFiler("AmhVedio39")]
        public ActionResult PlayVedio()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            if (id > 0)
            {
                Yax.Model.AMH_Vedio model = new Yax.BLL.AMH_Vedio().GetModel(id);
                ViewBag.Url = model.Url;
                ViewBag.Name = model.Name;
                if (model.FromSite == "sys")
                {
                    string fileurl = new Yax.BLL.Config().GetModelBy_key("chwadminurl").Value;
                    if (fileurl.Contains("http:") || fileurl.Contains("https:"))
                    {

                    }
                    else
                    {
                        ViewBag.Url = fileurl + model.Url;
                    }
                   
                }
                else
                {
                    string fileurl = new Yax.BLL.Config().GetModelBy_key("fileurl").Value;
                    ViewBag.Cover = fileurl + model.Cover;
                }
                ViewBag.Name = model.Name;
            }
            return View();
        } 
        #endregion




        #region 系统视频
        [PowerFiler("AmhVedio38")]
        public ActionResult sysvedio()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = " FromSite='sys'";
            Yax.BLL.AMH_Vedio bll = new Yax.BLL.AMH_Vedio();
            string Category = Yax.Common.Utils.GetSafeQueryString("Category");
            int ID = Yax.Common.Utils.GetQueryInt("ID");
            int IsFree = Yax.Common.Utils.GetQueryInt("IsFree");
            string Name = Yax.Common.Utils.GetSafeQueryString("Name");
            if (string.IsNullOrEmpty(Category))
            {
                Category = "自拍";
            }
            ViewBag.Category = Category;
            if (!string.IsNullOrEmpty(Category))
            {
                strWhere += " and Category='" + Category + "'";
            }
            if (!string.IsNullOrEmpty(Name))
            {
                strWhere += " and Name like '%" + Name + "%'";
            }
            if (ID > 0)
            {
                strWhere += " and ID=" + ID;
            }
            if (IsFree > 0)
            {
                strWhere += " and IsFree=" + IsFree;
            }
            List<Yax.Model.AMH_Vedio> list = bll.GetPage(pageIndex, pageSize, strWhere, "id desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            ViewBag.list = list;
            ViewBag.fileurl = new Yax.BLL.Config().GetModelBy_key("fileurl").Value;
            return View();
        }


        [PowerFiler("AmhVedio38")]
        public ActionResult AddVedio()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            ViewBag.fileurl = new Yax.BLL.Config().GetModelBy_key("fileurl").Value;
            ViewBag.Category = "自拍";
            if (id > 0)
            {
                Yax.Model.AMH_Vedio model = new Yax.BLL.AMH_Vedio().GetModel(id);
                ViewBag.Url = model.Url;
                ViewBag.Name = model.Name;
                ViewBag.Sort = model.Sort;
                ViewBag.Cover = model.Cover;
                ViewBag.FromSite = model.FromSite;
                ViewBag.Category = model.Category;
                ViewBag.VedioLong = model.VedioLong;
            }
            else
            {
                string str = "select max(sort) from AMH_Vedio ";
                object obj = new Yax.BLL.BCommon().ExecuteScalar(str);
                if (obj == null || string.IsNullOrEmpty(obj.ToString()))
                {
                    ViewBag.Sort = 1;
                }
                else
                {
                    ViewBag.Sort = int.Parse(obj.ToString());
                }
            }

            return View();
        }
        [PowerFiler("AmhVedio38")]
        public ActionResult AddVedioPost()
        {
            string Name = Yax.Common.Utils.GetSafeFormString("Name");
            string Url = Yax.Common.Utils.GetSafeFormString("Url");
            int Sort = Yax.Common.Utils.GetFormInt("Sort");
            string Cover = Yax.Common.Utils.GetSafeFormString("Cover");
            string Category= Yax.Common.Utils.GetSafeFormString("CategoryA");
            string VedioLong = Yax.Common.Utils.GetSafeFormString("VedioLong");
            int id = Yax.Common.Utils.GetFormInt("id");
            int adminID = new Yax.BLL.CurrentUser().Id;
            if (id > 0)
            {
                string str = " update AMH_Vedio set Name='" + Name + "',Url='" + Url + "',Sort=" + Sort + ",Cover='" + Cover + "',Category='"+ Category + "',VedioLong='"+ VedioLong + "' where id=" + id;
                new Yax.BLL.BCommon().ExecuteScalar(str);
            }
            else
            {
                string str = "insert into AMH_Vedio([Name],Url,[Sort],Cover,[AddUser],[AddTime],[Enable],[Category],[FromSite],[VedioLong],[IsFree])";
                str += " VALUES('" + Name + "','" + Url + "'," + Sort + ",'" + Cover + "'," + adminID + ",getdate(),1,'"+ Category + "','sys','"+ VedioLong + "',2)";
                new Yax.BLL.BCommon().ExecuteScalar(str);
            }
            return Content("操作成功");
        }

        [PowerFiler("AmhVedio38")]
        public ActionResult SetIsFree()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            int val = Yax.Common.Utils.GetQueryInt("val");
            if(id>0&&val>0)
            {
                string str = " update AMH_Vedio set IsFree= " + val + " where id=" + id;
                new Yax.BLL.BCommon().ExecuteScalar(str);
            }
            return Content("ok");
        }

        [PowerFiler("AmhVedio38")]
        public ActionResult DelVedio()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            Yax.Model.AMH_Vedio model = new Yax.BLL.AMH_Vedio().GetModel(id);
            if (model !=null&&model.ID>0 )
            {
                string Fpath = Server.MapPath(model.Url);
                if(System.IO.File.Exists(Fpath))
                {
                    System.IO.File.Delete(Fpath);
                }
                string str = " delete from  AMH_Vedio   where id=" + id;
                new Yax.BLL.ZY_Log().AddLog(1,"删除视频："+model.Name);
                new Yax.BLL.BCommon().ExecuteScalar(str);
            }
            return Content("ok");
        }

        #endregion

    }
}
