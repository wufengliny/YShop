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
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        [PowerFiler("xitongzhuye1")]
        public ActionResult Index()
        {
            Yax.BLL.Article bll = new Yax.BLL.Article();
            int TotalCount;
            int TotalPage;
            DataTable list_article = bll.GetPage_view(1, 10, " 1=1 and Enable=1", "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.list_article = list_article;

            Yax.BLL.ZY_Log bll_log = new Yax.BLL.ZY_Log();
            List<Yax.Model.ZY_Log> list_log = bll_log.GetPage(1, 10, " 1=1 ", "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.list_log = list_log;
            return View();
        }
        public ActionResult AjaxPic()
        {
            string RootDir = "";
            int roo = Yax.Common.Utils.GetQueryInt("roo");
            if(roo == 1)
            {
                RootDir = "/VedioCover/AMH/";
            }
          
            HttpFileCollectionBase files = Request.Files;
            if (files.Count > 0)
            {
                if (files[0].ContentType.ToLower().Contains("image"))
                {
                    if (files[0].ContentLength < 1024 * 1024)
                    {
                        string str = Yax.Common.UploadPic.UpLoadPicBig(files, RootDir);
                        Yax.Common.AjaxMsgHelper.AjaxMsg("1", str);
                    }
                    else
                    {
                        Yax.Common.AjaxMsgHelper.AjaxMsg("0", "图片大小不能超过1M");
                    }
                }
                else
                {
                    Yax.Common.AjaxMsgHelper.AjaxMsg("0", "仅支持图片上传");
                }
            }
            else
            {
                Yax.Common.AjaxMsgHelper.AjaxMsg("0", "无文件");
            }
            Response.End();
            return Content("");
        }

        public ActionResult AjaxFile()
        {
            HttpFileCollectionBase files = Request.Files;
            if (files.Count > 0)
            {
                if (files[0].ContentType.ToLower().Contains("application")|| files[0].ContentType.ToLower().Contains("image"))
                {
                    string FileName = files[0].FileName;
                    string FileNameExt = FileName.Substring(FileName.LastIndexOf('.'));
                    if(FileNameExt.ToLower()== ".zip"|| FileNameExt.ToLower() == ".rar"|| FileNameExt.ToLower() == ".png" || FileNameExt.ToLower() == ".jpg" || FileNameExt.ToLower() == ".jpeg")
                    {
                        if (files[0].ContentLength < 1000 * 1000 * 100)
                        {
                            string str = Yax.Common.UploadPic.UpLoadPicBig(files);
                            Yax.Common.AjaxMsgHelper.AjaxMsg("1", str);
                        }
                        else
                        {
                            Yax.Common.AjaxMsgHelper.AjaxMsg("0", "文件大小不能超过100M");
                        }
                    }
                    else
                    {
                        Yax.Common.AjaxMsgHelper.AjaxMsg("0", "仅支持上传.zip,.rar,png,jpg,jpeg文件");
                    }
                }
                else
                {
                    Yax.Common.AjaxMsgHelper.AjaxMsg("0", "仅支持上传.zip,.rar文件");
                }
            }
            else
            {
                Yax.Common.AjaxMsgHelper.AjaxMsg("0", "无文件");
            }
            Response.End();
            return Content("");
        }


        public ActionResult AjaxVedio()
        {
            string RootDir = "";
            int roo = Yax.Common.Utils.GetQueryInt("roo");
            if (roo == 1)
            {
                RootDir = "/VedioFile/AMH/";
            }
            HttpFileCollectionBase files = Request.Files;
            if (files.Count > 0)
            {
                if (files[0].ContentType.ToLower().Contains("mp4"))
                {
                    if (files[0].ContentLength <1000* 1024 * 1024)
                    {
                        string str = Yax.Common.UploadPic.UpLoadPicBig(files, RootDir);
                        Yax.Common.AjaxMsgHelper.AjaxMsg("1", str);
                    }
                    else
                    {
                        Yax.Common.AjaxMsgHelper.AjaxMsg("0", "视频文件大小不能超过1000M");
                    }
                }
                else
                {
                    Yax.Common.AjaxMsgHelper.AjaxMsg("0", "仅支持mp4文件");
                }
            }
            else
            {
                Yax.Common.AjaxMsgHelper.AjaxMsg("0", "无文件");
            }
            Response.End();
            return Content("");
        }
        public ActionResult AjaxNetImg()
        {
            try
            {
                string url = Yax.Common.Utils.GetQurryString("url");
                string str = Yax.Common.HTTPHelper.SaveRemotPicWeb(url, "/VedioCover/AMH/");
                return Content(str);
            }
            catch(Exception e)
            {
                return Content("下载失败："+e.Message);
            }

        }

    }
}
