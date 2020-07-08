using Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VedioAdmin.Filters;

namespace VedioAdmin.Controllers
{
    [IsAuditorFilter]
    public class FileUPController : BaseController
    {
        // GET: FileUP
        public ActionResult AjaxPic()
        {
            APIResut response = new APIResut();
            string RootDir = "";
            int roo = UCommon.UUtils.GetQueryInt("roo");
            if (roo == 1)
            {
                RootDir = "/UpLoadFiles/Images/";
            }
            HttpFileCollectionBase files = Request.Files;
            if (files.Count > 0)
            {
                if (files[0].ContentType.ToLower().Contains("image"))
                {
                    if (files[0].ContentLength < 1024 * 1024)
                    {
                        string str = UCommon.UploadPic.UpLoadPicBig(files, RootDir);
                        response.statu = 1;
                        response.Message = str;
                        return Content(JsonConvert.SerializeObject(response));
                    }
                    else
                    {
                        response.statu = 1;
                        response.Message = "图片大小不能超过1M";
                        return Content(JsonConvert.SerializeObject(response));
                    }
                }
                else
                {
                    response.statu = 1;
                    response.Message = "仅支持图片上传";
                    return Content(JsonConvert.SerializeObject(response));
                   
                }
            }
            else
            {
                response.statu = 1;
                response.Message = "无文件";
                return Content(JsonConvert.SerializeObject(response));
            }
        }

        public ActionResult AjaxVedio()
        {
            APIResut response = new APIResut();
            string RootDir = "";
            int roo = UCommon.UUtils.GetQueryInt("roo");
            if (roo == 1)
            {
                RootDir = "/UpLoadFiles/Vedio/";
            }
            HttpFileCollectionBase files = Request.Files;
            if (files.Count > 0)
            {
                if (files[0].ContentType.ToLower().Contains("mp4"))
                {
                    if (files[0].ContentLength < 1000 * 1024 * 1024)
                    {
                        string str = UCommon.UploadPic.UpLoadPicBig(files, RootDir);
                        response.statu = 1;
                        response.Message = str;
                        return Content(JsonConvert.SerializeObject(response));
                    }
                    else
                    {
                        response.statu = 1;
                        response.Message = "视频文件大小不能超过1000M";
                        return Content(JsonConvert.SerializeObject(response));
                    }
                }
                else
                {
                    response.statu = 1;
                    response.Message = "仅支持mp4文件";
                    return Content(JsonConvert.SerializeObject(response));
                   
                }
            }
            else
            {
                response.statu = 1;
                response.Message = "无文件";
                return Content(JsonConvert.SerializeObject(response));
            }
        }



        public ActionResult AjaxNetImg()
        {
            try
            {
                string url = UCommon.UUtils.GetQurryString("url");
                string str = UCommon.UHTTPHelper.SaveRemotPicWeb(url, "/UpLoadFiles/VedioCover/");
                return Content(str);
            }
            catch (Exception e)
            {
                return Content("下载失败：" + e.Message);
            }

        }
    }
}