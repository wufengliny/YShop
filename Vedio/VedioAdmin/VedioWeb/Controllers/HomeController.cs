using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;
namespace VedioWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int pi = 1)
        {
            string strWhere = " where cv.Enable=1 and cv.Price=0 ";
            string SortStr = "[IsTop] Desc,[Sort] desc";
            string Category = UCommon.UUtils.GetSafeQueryString("Category");
            var listFree = new BC_Vedios().Pager(pi, 4, strWhere, SortStr);
            ViewBag.listFree = listFree;
            ViewBag.picurl = new BS_Config().GetModelByKeyFromCache("picurl").Value;
            strWhere = " where cv.Price>0 ";
            var list = new BC_Vedios().Pager(pi, 20, strWhere, SortStr);
            ViewBag.list = list;
            return View();
        }


        public ActionResult FreeVedio(int pi = 1)
        {
            string strWhere = " where cv.Enable=1 and cv.Price=0 ";
            string SortStr = "[IsTop] Desc,[Sort] desc";
            var listFree = new BC_Vedios().Pager(pi, 20, strWhere, SortStr);
            string Category = UCommon.UUtils.GetSafeQueryString("Category");
            string pageWhere = Request.Url.Query;
            ViewBag.picurl = new BS_Config().GetModelByKeyFromCache("picurl").Value;
            return View(listFree);
        }

        public ActionResult VIPVedio(int pi = 1)
        {
            string strWhere = " where cv.Enable=1 and cv.Price>0 ";
            string SortStr = "[IsTop] Desc,[Sort] desc";
            var listFree = new BC_Vedios().Pager(pi, 20, strWhere, SortStr);
            string Category = UCommon.UUtils.GetSafeQueryString("Category");
            string pageWhere = Request.Url.Query;
            ViewBag.picurl = new BS_Config().GetModelByKeyFromCache("picurl").Value;
            return View(listFree);
        }


        public ActionResult MHView(int ID)
        {
            int uid = new BLL.CurrentUser().ID;
            if (ID > 0)
            {
                MC_Vedios model = new BC_Vedios().GetModelByID(ID);
                if (model != null)
                {
                    ViewBag.Name = model.Name;
                    ViewBag.Price = model.Price;
                    if (uid > 0)
                    {
                        //string str = " select * from UserLike where uid=" + uid + " and gid=" + id + " and Category='AMHVedio'";
                        //DataTable dt = new Yax.BLL.BCommon().GetDataBySQL(str);
                        //if (dt.Rows.Count > 0)
                        //{
                        //    ViewBag.likemsg = "已收藏";
                        //}
                        //else
                        //{
                        //    ViewBag.likemsg = "收藏";
                        //}
                    }
                    else
                    {
                        ViewBag.likemsg = "收藏";
                    }
                    if (model.Price == 0)
                    {
                        if (model.Url.ToLower().Contains("https:") || model.Url.ToLower().Contains("http:"))
                        {
                            ViewBag.Url = model.Url;
                        }
                        else
                        {
                            string htUrl ="";
                            ViewBag.Url = htUrl + model.Url;
                        }
                    }
                    else if (model.Price > 0)
                    {
                        ViewBag.VIPVedio = "yes";
                        ViewBag.uid = uid;
                        if (uid > 0)
                        {
                            MS_User muser = new BS_User().GetModelByID(uid);
                            if (muser != null && muser.VIP  && muser.VIPEndTime > DateTime.Now)
                            {
                                ViewBag.VIP = 1;
                                if (model.Url.ToLower().Contains("https:") || model.Url.ToLower().Contains("http:"))
                                {
                                    ViewBag.Url = model.Url;
                                }
                                else
                                {
                                    string htUrl = "";
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
            //int id = Yax.Common.Utils.GetQueryInt("id");
            //int uid = new Yax.BLL.QuickData.CurrentUserMV().ID;
            //if (uid > 0)
            //{
            //    Yax.Model.AMH_Vedio mVedio = new Yax.BLL.AMH_Vedio().GetModel(id);
            //    if (mVedio != null)
            //    {
            //        string str = " select * from UserLike where uid=" + uid + " and gid=" + id + " and Category='AMHVedio'";
            //        DataTable dt = new Yax.BLL.BCommon().GetDataBySQL(str);
            //        if (dt.Rows.Count > 0)
            //        {
            //            string strde = " delete from UserLike where uid=" + uid + " and gid=" + id + " and Category='AMHVedio'";
            //            new Yax.BLL.BCommon().ExecuteScalar(strde);
            //            return Content("can");
            //        }
            //        else
            //        {
            //            Yax.Model.UserLike model = new Yax.Model.UserLike();
            //            model.AddTime = DateTime.Now;
            //            model.Category = "AMHVedio";
            //            model.Enable = 1;
            //            model.GID = id;
            //            model.UID = uid;
            //            model.Name = mVedio.Name;
            //            new Yax.BLL.UserLike().Add(model);
            //            return Content("ok");
            //        }

            //    }
            //    else
            //    {
            //        return Content("资源不存在");
            //    }

            //}
            //else
            //{
            //    return Content("请先登录才能收藏");
            //}
            return Content("");
        }



    }
}