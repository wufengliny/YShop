using Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yax.Common;
namespace YShop.Areas.Admin.Controllers
{
    [YUAction]
    public class ConfigController : Controller
    {
        //
        // GET: /Config/

        [PowerFiler("Log7")]
        public ActionResult Log()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1";
            string ftime = Utils.GetSafeQueryString("ftime"); 
            string ttime = Utils.GetSafeQueryString("ttime"); 
            string Message = Utils.GetSafeQueryString("memo"); 
            string name = Utils.GetSafeQueryString("UserName"); 
            string typew = Utils.GetSafeQueryString("Type"); 
            if (!string.IsNullOrEmpty(ftime))
            {
                strWhere += "  and  Addtime>'" + ftime + "'";
            }
            if (!string.IsNullOrEmpty(ttime))
            {
                strWhere += "  and  Addtime<'" + ttime + "'";
            }
            if (!string.IsNullOrEmpty(Message))
            {
                strWhere += "  and  Message like '%" + Message + "%'";
            }
            if (!string.IsNullOrEmpty(name))
            {
                strWhere += "  and  UserName='" + name + "'";
            }
            if (!string.IsNullOrEmpty(typew))
            {
                strWhere += " and type=" + typew;
            }
            Yax.BLL.ZY_Log bll = new Yax.BLL.ZY_Log();
            List<Yax.Model.ZY_Log> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }

        [PowerFiler("Log7")]
        public ActionResult LogDetail()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            Yax.Model.ZY_Log model = new Yax.BLL.ZY_Log().GetModel(id);
            if (model != null)
            {
                ViewBag.id = id;
                ViewBag.type = model.Type;
                ViewBag.userName = model.UserName;
                ViewBag.addtime = model.Addtime;
                ViewBag.url = model.Url;
                ViewBag.ip = model.IP;
                ViewBag.browser = model.Browser;
                ViewBag.memo = model.Message;
            }
            return View();
        }


        [PowerFiler("FriendLink21")]
        public ActionResult FriendLink()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1 and Enable=1";
            string SiteName = Utils.GetSafeQueryString("SiteName");
            string Url = Utils.GetSafeQueryString("Url"); 
            if (!string.IsNullOrEmpty(SiteName))
            {
                strWhere += "  and  SiteName like '%" + SiteName + "%'";
            }
            if (!string.IsNullOrEmpty(Url))
            {
                strWhere += "  and  Url like '%" + Url + "%'";
            }

            Yax.BLL.FriendLink bll = new Yax.BLL.FriendLink();
            List<Yax.Model.FriendLink> list = bll.GetPage(pageIndex, pageSize, strWhere, "Sort desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }
        [PowerFiler("FriendLink21")]
        public ActionResult AddFriendLink()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            if (id > 0)
            {
                Yax.Model.FriendLink model = new Yax.BLL.FriendLink().GetModel(id);
                if (model != null)
                {
                    ViewBag.SiteName = model.SiteName;
                    ViewBag.Url = model.Url;
                    ViewBag.Sort = model.Sort;
                    ViewBag.Memo = model.Memo;
                    ViewBag.ImgUrl = model.ImgUrl;
                }
            }

            return View();
        }
        [PowerFiler("FriendLink21")]
        public ActionResult AddFriendLinkPost()
        {
            Yax.Model.FriendLink model = new Yax.Model.FriendLink();
            int id = Yax.Common.Utils.GetFormInt("id");
            model.SiteName = Request.Form["SiteName"];
            model.Url = Request.Form["Url"];
            model.Sort = Yax.Common.Utils.GetFormInt("Sort");
            model.Memo = Request.Form["Memo"];
            model.ImgUrl = Yax.Common.Utils.GetFormString("Cover");
            if (id > 0)
            {
                model.ID = id;
                int resu = new Yax.BLL.FriendLink().UpdateInfo(model);
                if (resu > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "修改友情链接(" + model.SiteName + ")成功");
                    Yax.BLL.WebTool.DelChcheWeb();
                    return Content("修改成功");
                }
            }
            else
            {
                model.AddTime = DateTime.Now;
                model.Enable = 1;
                int resa = new Yax.BLL.FriendLink().Add(model);
                if (resa > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "添加友情链接(" + model.SiteName + ")成功");
                    Yax.BLL.WebTool.DelChcheWeb();
                    return Content("添加成功");
                }
            }
            return Content("");
        }
        [PowerFiler("FriendLink21")]
        public ActionResult delFriendLink()
        {
            int id = Yax.Common.Utils.GetQueryInt("id", 0);
            string name = Request.QueryString["name"];
            int res = new Yax.BLL.FriendLink().UpdateEnable(id, 0);
            try
            {
                if (res > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "删除友情链接(" + name + ")成功");
                    return Content("删除成功");
                }
                else
                {
                    return Content("删除失败");
                }
            }
            catch
            {
                return Content("操作异常");
            }
        }


        [PowerFiler("changguishezhi4")]
        public ActionResult SysConfig()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string GName = Utils.GetSafeQueryString("GName");  
            if(string.IsNullOrEmpty(GName))
            {
                GName = "SysConfig";
            }
            string strWhere = "1=1 and Enable=1 and GroupName='" + GName + "' ";
            string Name = Utils.GetSafeQueryString("kName");  
            if (!string.IsNullOrEmpty(Name))
            {
                strWhere += "  and  Name like '%" + Name + "%'";
            }

            Yax.BLL.Config bll = new Yax.BLL.Config();
            List<Yax.Model.Config> list = bll.GetPage(pageIndex, pageSize, strWhere, "sort asc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }
        [PowerFiler("changguishezhi4")]
        public ActionResult AddSysConfig()
        {
            int id = Yax.Common.Utils.GetQueryInt("id", 0);
            if (id > 0)
            {
                Yax.Model.Config model = new Yax.BLL.Config().GetModel(id);
                if (model != null)
                {
                    ViewBag.Name = model.Name;
                    ViewBag.KeyName = model.KeyName;
                    ViewBag.Memo = model.Memo;
                    ViewBag.Value = model.Value;
                    ViewBag.Sort = model.Sort;
                }
            }
            else
            {
                ViewBag.Sort = 1;
            }
            return View();
        }

        [ValidateInput(false)]
        [PowerFiler("changguishezhi4")]
        public ActionResult AddSysConfigPost()
        {
            Yax.Model.Config model = new Yax.Model.Config();
            int id = Yax.Common.Utils.GetFormInt("id", 0);
            string GName = Request.Form["GName"];
            if (string.IsNullOrEmpty(GName))
            {
                GName = "SysConfig";
            }
            model.Memo = Request.Form["Memo"].Trim();
            model.Value = Request.Form["KValue"].Trim();
            model.UpdateTime = DateTime.Now;
            model.LastModifyUser = new Yax.BLL.CurrentUser().Id;
            model.Name = Request.Form["Name"].Trim();
            int sort = Yax.Common.Utils.GetFormInt("sort");
            if(sort<0)
            {
                sort = 0;
            }
            model.Sort = sort;
            if (id > 0)
            {
                model.ID = id;
                int resu = new Yax.BLL.Config().UpdateInfo(model);
                if (resu > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "修改参数(" + model.ID + ")成功");
                    //清除前台缓存
                    Yax.BLL.WebTool.DelChcheWeb();
                    return Content("修改成功");
                }
            }
            else
            {
                model.KeyName = Request.Form["KeyName"].Trim();
                model.GroupName = GName;
                model.Enable = 1;
                model.AddUser = new Yax.BLL.CurrentUser().Id;
                model.AddTime = DateTime.Now;
                int resu = new Yax.BLL.Config().Add(model);
                if (resu > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "添加参数(" + model.Name + ")成功");
                    return Content("添加成功");
                }

            }
            return View();
        }
        [PowerFiler("changguishezhi4")]
        public ActionResult DelConfig(int id)
        {
            Yax.Model.Config model = new Yax.Model.Config();
            model.ID = id;
            model.Enable = 0;
            int res = new Yax.BLL.Config().UpdateEnable(model);
            if (res > 0)
            {
                new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "删除参数列表参数ID（" + model.ID + "）成功");
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }



        [PowerFiler("disanfangzhifu22")]
        public ActionResult PayCard()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1 ";


            Yax.BLL.PayCard bll = new Yax.BLL.PayCard();
            List<Yax.Model.PayCard> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID asc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }
        [PowerFiler("disanfangzhifu22")]
        public ActionResult PadCardAdd()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            Yax.Model.PayCard model = new Yax.Model.PayCard();
            if (id > 0)
            {
                model = new Yax.BLL.PayCard().GetModel(id);
                if (model != null)
                {
                    ViewBag.APIKey = model.APIKey;
                    ViewBag.APIUrl = model.APIUrl;
                    ViewBag.CardNo = model.CardNo;
                    ViewBag.Memo = model.Memo;
                    ViewBag.Name = model.Name;
                    ViewBag.PayUrl = model.PayUrl;
                    ViewBag.PublicKey = model.PublicKey;
                    ViewBag.CardType = model.CardType;
                }

            }
            return View();
        }
        [PowerFiler("disanfangzhifu22")]
        public ActionResult PadCardAddPost()
        {
            Yax.Model.PayCard model = new Yax.Model.PayCard();
            int id = Yax.Common.Utils.GetFormInt("id");
            model.APIKey = Request.Form["APIKey"];
            model.APIUrl = Request.Form["APIUrl"];
            model.CardNo = Request.Form["CardNo"];
            model.Memo = Request.Form["Memo"];
            model.Name = Request.Form["Name"];
            model.PayUrl = Request.Form["PayUrl"];
            model.PublicKey = Request.Form["PublicKey"];
            model.CardType = Request.Form["CardType"];
            model.UpdateTime = DateTime.Now;
            if (id > 0)
            {
                model.ID = id;
                int res = new Yax.BLL.PayCard().UpdateInfo(model);
                if (res > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, "修改第三方支付信息：" + model.Name + "-ID:" + model.ID);
                    return Content("修改成功");
                }
            }
            else
            {
                model.AddTime = DateTime.Now;
                model.Enable = 1;
                int res = new Yax.BLL.PayCard().Add(model);
                if (res > 0)
                {
                    return Content("添加成功");
                }
            }

            return Content("");
        }
        [PowerFiler("disanfangzhifu22")]
        public ActionResult upEnablepaycard()
        {
            Yax.Model.PayCard model = new Yax.Model.PayCard();
            model.ID = Yax.Common.Utils.GetQueryInt("id");
            model.Enable = Yax.Common.Utils.GetQueryInt("enable", 0);
            int res = new Yax.BLL.PayCard().UpdateEnable(model);
            if (res > 0)
            {
                new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "禁用第三方（" + model.ID + "）成功");
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }


        [PowerFiler("imagetype23")]
        public ActionResult Img()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1 and Enabale=1 and category='o' and ImgType=" + Utils.GetSafeQueryString("ImgType");
            Yax.BLL.Web_Img bll = new Yax.BLL.Web_Img();
            List<Yax.Model.Web_Img> list = bll.GetPage(pageIndex, pageSize, strWhere, "id desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }
        [PowerFiler("imagetype23")]
        public ActionResult ImgAdd()
        {
            Yax.Model.Web_Img model = new Yax.Model.Web_Img();
            int id = Yax.Common.Utils.GetQueryInt("id");
            model = new Yax.BLL.Web_Img().GetModel(id);
            ViewBag.OpenType = "_self";
            if (model != null)
            {
                ViewBag.Name = model.Name;
                ViewBag.Href = model.Href;
                ViewBag.ImgUlrSmall = model.ImgUlrSmall;
                ViewBag.Imgurl = model.Imgurl;
                ViewBag.Memo = model.Memo;
                ViewBag.OpenType = model.OpenType;

            }
            return View();
        }
        [PowerFiler("imagetype23")]
        public ActionResult ImgAddPost()
        {
            Yax.Model.Web_Img model = new Yax.Model.Web_Img();
            int id = Yax.Common.Utils.GetFormInt("id");
            model.Href = Request.Form["Href"];
            model.Imgurl = Request.Form["Imgurl"];
            model.ImgUlrSmall = Yax.Common.UploadPic.UpLoadSmallPic(Server.MapPath(model.Imgurl), "200*200");
            model.Memo = Request.Form["Memo"];
            model.Name = Request.Form["txtname"];
            model.OpenType = Request.Form["OpenType"];
            if (id > 0)
            {
                model.ID = id;
                int res = new Yax.BLL.Web_Img().Update_info(model);
            }
            else
            {
                model.Category = "o";
                model.ImgType = Yax.Common.Utils.GetFormInt("ImgType");
                model.AddTime = DateTime.Now;
                model.Enabale = 1;
                model.Sort = 1;
                int res = new Yax.BLL.Web_Img().Add(model);
            }


            //清除前台缓存
            Yax.BLL.WebTool.DelChcheWeb();
            return Content("操作成功");
        }
        [PowerFiler("imagetype23")]
        public ActionResult ImgType()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1 and enable=1";
            Yax.BLL.Img_Type bll = new Yax.BLL.Img_Type();
            List<Yax.Model.Img_Type> list = bll.GetPage(pageIndex, pageSize, strWhere, "id desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }
        [PowerFiler("imagetype23")]
        public ActionResult ImgTypeAdd()
        {
            Yax.Model.Img_Type model = new Yax.Model.Img_Type();
            int id = Yax.Common.Utils.GetQueryInt("id");
            model = new Yax.BLL.Img_Type().GetModel(id);
            if (model != null && model.Enable == 1)
            {
                ViewBag.Name = model.Name;
            }
            return View();
        }
        [PowerFiler("imagetype23")]
        public ActionResult ImgTypeAddPost()
        {
            Yax.Model.Img_Type model = new Yax.Model.Img_Type();
            int id = Yax.Common.Utils.GetFormInt("id");
            string name = Request.Form["txtname"];
            model.Name = name;
            if (id > 0)
            {
                model.ID = id;
                int res = new Yax.BLL.Img_Type().Update_Name(model);
                if (res > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "修改图片类别（" + model.Name + "）ID:" + model.ID + "成功");
                    return Content("修改成功");
                }
                else
                {
                    return Content("操作失败");
                }
            }
            else
            {
                model.Enable = 1;
                model.AddTime = DateTime.Now;
                int res = new Yax.BLL.Img_Type().Add(model);
                if (res > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "添加图片类别（" + model.Name + "）成功");
                    return Content("添加成功");
                }
                else
                {
                    return Content("操作失败");
                }
            }
        }

        [PowerFiler("imagetype23")]
        public ActionResult delImgType()
        {
            Yax.Model.Img_Type model = new Yax.Model.Img_Type();
            model.ID = Yax.Common.Utils.GetQueryInt("id");
            model.Enable = Yax.Common.Utils.GetQueryInt("enable", 0);
            int res = new Yax.BLL.Img_Type().Update_Enable(model);
            if (res > 0)
            {
                new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "删除图片类别：" + Request.QueryString["name"] + "（" + model.ID + "）成功");
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }
        [PowerFiler("imagetype23")]
        public ActionResult delImg()
        {
            Yax.Model.Web_Img model = new Yax.Model.Web_Img();
            model.ID = Yax.Common.Utils.GetQueryInt("id");
            model.Enabale = Yax.Common.Utils.GetQueryInt("enable", 0);
            int res = new Yax.BLL.Web_Img().Update_enable(model);
            if (res > 0)
            {
                new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "删除图片：" + Request.QueryString["name"] + "（" + model.ID + "）成功");
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }


        [PowerFiler("pic6")]
        public ActionResult ConfigImg()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string GName ="images";
            string strWhere = "1=1 and Enable=1 and GroupName='" + GName + "' ";
            string Name = Utils.GetSafeQueryString("kName");
            if (!string.IsNullOrEmpty(Name))
            {
                strWhere += "  and  Name like '%" + Name + "%'";
            }

            Yax.BLL.Config bll = new Yax.BLL.Config();
            List<Yax.Model.Config> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID asc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }

        [PowerFiler("pic6")]
        public ActionResult ConfigImgAdd()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            if(id>0)
            {
                Yax.Model.Config model = new Yax.Model.Config();
                model = new Yax.BLL.Config().GetModel(id);
                if(model!=null)
                {
                    ViewBag.Name = model.Name;
                    ViewBag.Memo = model.Memo;
                    ViewBag.Imgurl = model.Value;
                    ViewBag.KeyName = model.KeyName;
                }
            }
            return View();
        }
        [PowerFiler("pic6")]
        public ActionResult ConfigImgAddPost()
        {
            Yax.Model.Config model = new Yax.Model.Config();
            int id = Yax.Common.Utils.GetFormInt("id");
            model.Memo = Request.Form["Memo"];
            model.Name = Request.Form["txtname"];
            model.Value = Request.Form["Imgurl"];
            model.LastModifyUser = new Yax.BLL.CurrentUser().Id;
            model.UpdateTime = DateTime.Now;
            int res = 0;
            if (id>0)
            {
                model.ID = id;
                res = new Yax.BLL.Config().UpdateInfo(model);
            }
            else
            {
                model.AddTime = DateTime.Now;
                model.AddUser = new Yax.BLL.CurrentUser().Id;
                model.Enable = 1;
                model.Sort = 1;
                model.GroupName = "images";
                model.KeyName = Request.Form["KeyName"];
                res = new Yax.BLL.Config().Add(model);
            }
            if(res>0)
            {
                Yax.BLL.WebTool.DelChcheWeb();
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
            return View();
        }


        [PowerFiler("duanxinjilu3")]
        public ActionResult PhoneMsg()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1";
            string phone = Utils.GetSafeQueryString("phone"); 
            if (!string.IsNullOrEmpty(phone))
            {
                strWhere += " and phone='" + phone + "'";
            }
            Yax.BLL.PhoneMsg bll = new Yax.BLL.PhoneMsg();
            List<Yax.Model.PhoneMsg> list = bll.GetPage(pageIndex, pageSize, strWhere, "id desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }

        [PowerFiler("duanxinjiekou2")]
        public ActionResult PhoneMsgJK()
        {
            Yax.Model.MsgConfig model = new Yax.BLL.MsgConfig().GetModel(1);
            if(model!=null)
            {
                ViewBag.QIYeID = model.QIYeID;
                ViewBag.Pwd = model.Pwd;
                ViewBag.ContentPre = model.ContentPre;
                ViewBag.URL = model.URL;
            }
            return View();
        }
        [PowerFiler("duanxinjiekou2")]
        public ActionResult PhoneMsgJKPost(string QIYeID, string Pwd, string ContentPre, string URL)
        {
            Yax.Model.MsgConfig model = new Yax.Model.MsgConfig();
            model.ID = 1;
            model.QIYeID = QIYeID.Trim();
            model.Pwd = Pwd.Trim();
            model.ContentPre = ContentPre.Trim();
            model.URL = URL.Trim();
            model.DayMax = 0;
            model.UserDayMax = 0;
            int res=  new Yax.BLL.MsgConfig().Update_info(model);
            if (res > 0)
            {
                Yax.BLL.WebTool.DelChcheWeb();
                new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "修改短信接口参数成功");
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }


    }
}
