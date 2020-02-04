using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMH.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = " IsFree=1 ";
            Yax.BLL.AMH_Vedio bll = new Yax.BLL.AMH_Vedio();
            string Category = Yax.Common.Utils.GetSafeQueryString("Category");
            List<Yax.Model.AMH_Vedio> listFree = bll.GetPage(pageIndex, 4, strWhere, "id desc", "*", out TotalCount, out TotalPage);
            ViewBag.listFree = listFree;
            ViewBag.PreImgUrl = new Yax.BLL.Config().GetModelBy_key("chwadminurl").Value;
            strWhere = "IsFree=2 ";
            List<Yax.Model.AMH_Vedio> list = bll.GetPage(pageIndex, pageSize, strWhere, "Sort desc", "*", out TotalCount, out TotalPage);
            ViewBag.fileurl = new Yax.BLL.Config().GetModelBy_key("fileurl").Value;

            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            ViewBag.list = list;
            ViewBag.fileurl = new Yax.BLL.Config().GetModelBy_key("fileurl").Value;
            return View();
        }


        public ActionResult FreeVedio()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = " IsFree=1 ";
            Yax.BLL.AMH_Vedio bll = new Yax.BLL.AMH_Vedio();
            string Category = Yax.Common.Utils.GetSafeQueryString("Category");
            List<Yax.Model.AMH_Vedio> listFree = bll.GetPage(pageIndex, 4, strWhere, "id desc", "*", out TotalCount, out TotalPage);
            ViewBag.listFree = listFree;
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            ViewBag.PreImgUrl = new Yax.BLL.Config().GetModelBy_key("chwadminurl").Value;
            // 
            return View();
        }
        
        public ActionResult VIPVedio()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = " IsFree=2 ";
            Yax.BLL.AMH_Vedio bll = new Yax.BLL.AMH_Vedio();
            List<Yax.Model.AMH_Vedio> listFree = bll.GetPage(pageIndex, 16, strWhere, "sort desc", "*", out TotalCount, out TotalPage);
            ViewBag.listFree = listFree;
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            ViewBag.PreImgUrl =  new Yax.BLL.Config().GetModelBy_key("fileurl").Value;
            // 
            return View();
        }


        public ActionResult MHView()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            if (id>0)
            {
                Yax.Model.AMH_Vedio model = new Yax.BLL.AMH_Vedio().GetModel(id);
                if(model!=null)
                {
                    ViewBag.Name = model.Name;
                    ViewBag.IsFree = model.IsFree;
                    if(uid>0)
                    {
                        string str = " select * from UserLike where uid=" + uid + " and gid=" + id + " and Category='AMHVedio'";
                        DataTable dt = new Yax.BLL.BCommon().GetDataBySQL(str);
                        if(dt.Rows.Count>0)
                        {
                            ViewBag.likemsg = "已收藏";
                        }
                        else
                        {
                            ViewBag.likemsg = "收藏";
                        }
                       
                    }
                    else
                    {
                        ViewBag.likemsg = "收藏";
                    }
                    string preUrl = "";
                    if(model.FromSite=="sys")
                    {
                        preUrl = new Yax.BLL.Config().GetModelBy_key("chwadminurl").Value;
                    }
                    else
                    {
                        preUrl= new Yax.BLL.Config().GetModelBy_key("fileurl").Value;
                    }
                    ViewBag.Cover = preUrl + model.Cover;
                    if (model.IsFree == 1)
                    {
                        if(model.Url.ToLower().Contains("https:")||model.Url.ToLower().Contains("http:"))
                        {
                            ViewBag.Url = model.Url;
                        }
                        else
                        {
                            string htUrl = new Yax.BLL.Config().GetModelBy_key("chwadminurl").Value;
                            ViewBag.Url = htUrl + model.Url;
                        }
                    }
                    else if (model.IsFree == 2)
                    {
                        ViewBag.VIPVedio = "yes";
                        
                        ViewBag.uid = uid;
                        if(uid>0)
                        {
                            Yax.Model.Y_User muser = new Yax.BLL.Y_User().GetModel(uid);
                            if(muser!=null&&muser.VIP==1&&muser.VIPEndTime>DateTime.Now)
                            {
                                ViewBag.VIP = 1;
                                if (model.Url.ToLower().Contains("https:") || model.Url.ToLower().Contains("http:"))
                                {
                                    ViewBag.Url = model.Url;
                                }
                                else
                                {
                                    string htUrl = new Yax.BLL.Config().GetModelBy_key("chwadminurl").Value;
                                    ViewBag.Url = htUrl + model.Url;
                                }
                            }
                            else
                            {
                                ViewBag.VIP = 0;
                            }
                        }
                       
                    }
                }
                else
                {
                    ViewBag.err = "视频不存在";
                }
               
            }
            return View();
        }


        public ActionResult DoLike()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            if(uid > 0)
            {
                Yax.Model.AMH_Vedio mVedio = new Yax.BLL.AMH_Vedio().GetModel(id);
                if(mVedio!=null)
                {
                    string str = " select * from UserLike where uid="+uid+" and gid="+id+ " and Category='AMHVedio'";
                    DataTable dt=  new Yax.BLL.BCommon().GetDataBySQL(str);
                    if(dt.Rows.Count>0)
                    {
                        string strde = " delete from UserLike where uid=" + uid + " and gid=" + id + " and Category='AMHVedio'";
                        new Yax.BLL.BCommon().ExecuteScalar(strde);
                        return Content("can");
                    }
                    else
                    {
                        Yax.Model.UserLike model = new Yax.Model.UserLike();
                        model.AddTime = DateTime.Now;
                        model.Category = "AMHVedio";
                        model.Enable = 1;
                        model.GID = id;
                        model.UID = uid;
                        model.Name = mVedio.Name;
                        new Yax.BLL.UserLike().Add(model);
                        return Content("ok");
                    }
                  
                }
                else
                {
                    return Content("资源不存在");
                }
               
            }
            else
            {
                return Content("请先登录才能收藏");
            }
            return Content("");
        }



    }
}