using Admin.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace YShop.Areas.Admin.Controllers
{
    [YUAction]
    public class ArticleController : Controller
    {
        //
        // GET: /Article/
        [PowerFiler("wenzhang15")]
        public ActionResult Index()
        {
            initNewsType();
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1 and enable=1  and ArticleTypeID>0  and Category='news'";
            string id = Yax.Common.Utils.GetQueryInt("ID", 0).ToString();
            if (id == "0")
            {
                id = "";
            }
            string strname = Yax.Common.Utils.GetSafeQueryString("name");
            string adduser = Yax.Common.Utils.GetSafeQueryString("adduser");
            string Typew = Yax.Common.Utils.GetSafeQueryString("Typew");
            string cid = Yax.Common.Utils.GetSafeQueryString("cid");
            string othert = Yax.Common.Utils.GetSafeQueryString("othert");
            if (!string.IsNullOrEmpty(id))
            {
                strWhere += "  and  id=" + id;
            }
            if (!string.IsNullOrEmpty(strname))
            {
                strWhere += "  and  name like '%" + strname + "%'";
            }
            if (!string.IsNullOrEmpty(Typew))
            {
                strWhere += "  and  ArticleTypeID=" + Typew;
            }
            if (!string.IsNullOrEmpty(adduser))
            {
                strWhere += "  and  adminName like '%" + adduser + "%'";
            }
            if (!string.IsNullOrEmpty(othert))
            {
                if (othert == "1")
                {
                    strWhere += "  and  IsIndex=1";
                }
                else if (othert == "2")
                {
                    strWhere += "  and  IsRecoommend=1";
                }
                else if (othert == "3")
                {
                    strWhere += "  and  IsHot=1";
                }
            }
            Yax.BLL.Article bll = new Yax.BLL.Article();
            DataTable list = bll.GetPage_view(pageIndex, pageSize, strWhere, "Sort Desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }

        [PowerFiler("wenzhang15")]
        public ActionResult NewsSetSort()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            string sortType = Yax.Common.Utils.GetSafeQueryString("sorttype");
            int sort = Yax.Common.Utils.GetQueryInt("sort");
            int t1;
            string strWhere = "1=1 and Enable=1";
            Yax.BLL.Article bll = new Yax.BLL.Article();
            string orderstring = "sort desc";
            // 1 2 3 5 6     6 5 4  3  2
            if (sortType == "up")
            {
                strWhere += " and sort>" + sort;
                orderstring = "sort asc";
            }
            else
            {
                strWhere += " and sort<" + sort;
            }
            List<Yax.Model.Article> list = bll.GetPage(1, 1, strWhere, orderstring, "*", out t1, out t1);
            if (list != null && list.Count == 1)
            {
                int sort2 = list[0].Sort;
                if (sortType == "up")
                {
                    sort2 = sort2 + 1;
                }
                else
                {
                    sort2 = sort2 - 1;
                }
                new Yax.BLL.BCommon().UpdateOneField("Article", "sort", sort2.ToString(), "id=" + id, null);
            }
            else
            {
                if (sortType == "up")
                {
                    sort = sort + 1;
                }
                else
                {
                    sort = sort - 1;
                }
                new Yax.BLL.BCommon().UpdateOneField("Article", "sort", sort.ToString(), "id=" + id, null);
            }
            return Content("");
        }
        

        [PowerFiler("wenzhang15")]
        public ActionResult AddArticle()
        {
            initNewsType();
            int id = Yax.Common.Utils.GetQueryInt("id");
            if (id > 0)
            {
                 Yax.Model.Article model = new Yax.BLL.Article().GetModel(id);
                 if (model != null)
                 {
                     ViewBag.Name = model.Name;
                     ViewBag.Mark = model.Mark;
                     ViewBag.Autho = model.Autho;
                     ViewBag.ArticleTypeID = model.ArticleTypeID;
                     ViewBag.IsIndex = model.IsIndex;
                     ViewBag.IsRecoommend = model.IsRecoommend;
                     ViewBag.IsHot = model.IsHot;
                     ViewBag.Detail = model.Detail;
                     ViewBag.Cover = model.Cover;
                    ViewBag.Seokeywords = model.SeoKeywords;
                    ViewBag.Seodescription = model.SeoDescription;
                     ViewBag.AddTime = model.AddTime;
                    ViewBag.Hits = model.Hits;
                    ViewBag.Mark = model.Mark;
                    ViewBag.Sort = model.Sort;
                }
            }
            else
            {
                string str = " select max(id) from Article";
                object objs = new Yax.BLL.BCommon().ExecuteScalar(str);
                ViewBag.Sort =(int.Parse(objs.ToString())+1);
                ViewBag.AddTime = DateTime.Now;
            }
            return View();
        }

        [ValidateInput(false)]
        [PowerFiler("wenzhang15")]
        public ActionResult AddArticlePost()
        {
            Yax.Model.Article model = new Yax.Model.Article();
            int id = Yax.Common.Utils.GetFormInt("id",0);
            model.ArticleTypeID = Yax.Common.Utils.GetFormInt("pcateid");
            model.Autho = Request.Form["Autho"];
            model.Cover = Request.Form["Cover"];
            model.CoverSmall = "";
            model.IP = Yax.Common.Utils.GetClientIP();
            model.Detail = Request.Form["Content"];
            model.IsIndex = Yax.Common.Utils.GetFormInt("IsIndex",0);
            model.IsRecoommend = Yax.Common.Utils.GetFormInt("IsRecoommend", 0);
            model.IsHot = Yax.Common.Utils.GetFormInt("IsHot", 0);
            model.Mark = Request.Form["Mark"];
            model.Name = Request.Form["name"];
            model.UpdateTime = DateTime.Now;
            model.SeoKeywords = Request.Form["Seokeywords"];
            model.SeoDescription = Request.Form["Seodescription"];

            model.Hits = Yax.Common.Utils.GetFormInt("Hits");
            model.Sort= Yax.Common.Utils.GetFormInt("Sort");
            DateTime dtAdd = DateTime.Now;
            DateTime.TryParse(Request.Form["AddTime"], out dtAdd);
            model.AddTime = dtAdd;
            if (id > 0)
            {
                if (!string.IsNullOrEmpty(Request.Form["isDelPic"]))
                {
                    // 删除文章原图片
                    Yax.Model.Article modelOld = new Yax.BLL.Article().GetModel(id);
                    if (modelOld != null)
                    {
                        try
                        {
                            string strDetail = modelOld.Detail;
                            string serverPath = Server.MapPath("/Content/images/UploadImages/");
                            Regex reImg = new Regex("(?<=<img src=\")[\\s\\S]*?(?=\")");
                            MatchCollection maiMg = reImg.Matches(strDetail);
                            if (maiMg.Count > 0)
                            {
                                for (int i = 0; i < maiMg.Count; i++)
                                {
                                    string imgurl = maiMg[i].Value;
                                    string FileName = imgurl.Substring(imgurl.LastIndexOf('/') + 1);
                                    if (System.IO.File.Exists(serverPath + "/" + FileName))
                                    {
                                        System.IO.File.Delete(serverPath + FileName);
                                    }
                                }
                            }
                        }
                        catch {
                            new Yax.BLL.ZY_Log().AddLog_JustMessage(1,"删除图片出现异常！");
                        }
                    }
                }
                //

                model.ID = id;
                int resa = new Yax.BLL.Article().UpdateInfo(model);
                if (resa > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "修改文章（" + model.Name + "）成功");
                    return Content("修改成功！");
                }
                else
                {
                    return Content("修改失败");
                }
            }
            else
            {
                model.Category = Request.Form["Category"];
                model.AddUser = new Yax.BLL.CurrentUser().Id;
                model.Enable = 1;
                int resa=  new Yax.BLL.Article().Add(model);
                if (resa > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "添加文章（" + model.Name + "）成功");
                    return Content("添加成功！");
                }
                else
                {
                    return Content("添加失败");
                }
            }
            return View();
        }

        [PowerFiler("wenzhang15")]
        public ActionResult upEnableArticle()
        {
            Yax.Model.Article model = new Yax.Model.Article();
            model.ID = Yax.Common.Utils.GetQueryInt("id");
            model.Enable = Yax.Common.Utils.GetQueryInt("enable", 0);
            int res = new Yax.BLL.Article().Update_enable(model);
            if (res > 0)
            {
                new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "删除文章（" + model.ID + "）成功");
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }

        [PowerFiler("wenzhang15")]
        public ActionResult UPIndexArticle()
        {
            Yax.Model.Article model = new Yax.Model.Article();
            model.ID = Yax.Common.Utils.GetQueryInt("id");
            model.IsIndex = Yax.Common.Utils.GetQueryInt("enable", 0);
            int res = new Yax.BLL.Article().Update_Index(model);
            if (res > 0)
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }
        [PowerFiler("wenzhang15")]
        public ActionResult UPHotArticle()
        {
            Yax.Model.Article model = new Yax.Model.Article();
            model.ID = Yax.Common.Utils.GetQueryInt("id");
            model.IsHot = Yax.Common.Utils.GetQueryInt("enable", 0);
            int res = new Yax.BLL.Article().Update_hot(model);
            if (res > 0)
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }

        [PowerFiler("wenzhang15")]
        public ActionResult UPIsRecoommendArticle()
        {
            Yax.Model.Article model = new Yax.Model.Article();
            model.ID = Yax.Common.Utils.GetQueryInt("id");
            model.IsRecoommend = Yax.Common.Utils.GetQueryInt("enable", 0);
            int res = new Yax.BLL.Article().Update_Recommend(model);
            if (res > 0)
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }


        [PowerFiler("wenzhang15")]
        public ActionResult ArticleOther()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            if (id > 0)
            {
                Yax.Model.Article model = new Yax.BLL.Article().GetModel(id);
                if (model != null)
                {
                    ViewBag.Name = model.Name;
                    ViewBag.Mark = model.Mark;
                    ViewBag.Autho = model.Autho;
                    ViewBag.ArticleTypeID = model.ArticleTypeID;
                    ViewBag.IsIndex = model.IsIndex;
                    ViewBag.Detail = model.Detail;
                    ViewBag.Cover = model.Cover;
                    ViewBag.Seokeywords = model.SeoKeywords;
                    ViewBag.Seodescription = model.SeoDescription;
                    if (model.AddTime > DateTime.Now.AddYears(-10))
                    {
                        ViewBag.AddTime = model.AddTime;
                    }
                    else
                    {
                        ViewBag.AddTime = DateTime.Now;
                    }
                }
            }
            return View();
        }
        private string initNewsType()
        {
            StringBuilder atype = new StringBuilder();
            List<Yax.Model.ArticleType> list = new Yax.BLL.ArticleType().GetList(1000, "*", "1=1 and enable=1", "ID asc");
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == 0)
                    {
                        ViewBag.ArticleTypeID = list[i].ID;
                    }
                    atype.AppendLine(" <option value=\"" + list[i].ID + "\">" + list[i].Name + "</option>");
                }
                ViewBag.atype = atype.ToString();
                return atype.ToString();
            }
            else
            {
                return atype.ToString();
            }
        }

        //

        [PowerFiler("wenzhangfenlei16")]
        public ActionResult Category()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1 and Enable=1";
            string name = Yax.Common.Utils.GetSafeQueryString("Name");  
            if (!string.IsNullOrEmpty(name))
            {
                strWhere += "  and  Name like '%" + name + "%'";
            }
            Yax.BLL.ArticleType bll = new Yax.BLL.ArticleType();
            List<Yax.Model.ArticleType> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }
        [PowerFiler("wenzhangfenlei16")]
        public ActionResult AddCategory()
        {
            int id = Yax.Common.Utils.GetQueryInt("id",0);
            if (id > 0)
            {
                Yax.Model.ArticleType model = new Yax.BLL.ArticleType().GetModel(id);
                if (model != null)
                {
                    ViewBag.Name = model.Name;
                }
            }
            return View();
        }
        [PowerFiler("wenzhangfenlei16")]
        public ActionResult AddCategoryPost()
        {
            int id = Yax.Common.Utils.GetFormInt("id", 0);
            Yax.Model.ArticleType model = new Yax.Model.ArticleType();
            model.Name = Request.Form["txtname"];
            if (id > 0)
            {
                model.ID = id;
                int res = new Yax.BLL.ArticleType().UpdateName(model);
                if (res > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "修改文章类别（" + model.Name + "）成功");
                    return Content("修改成功！");
                }
                else
                {
                    return Content("修改失败！");
                }
            }
            else
            {
                model.Addtime = DateTime.Now;
                model.Enable = 1;
                int res = new Yax.BLL.ArticleType().Add(model);
                if (res > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "添加文章类别（" + model.Name + "）成功");
                    return Content("添加成功！");
                }
                else
                {
                    return Content("添加失败！");
                }

            }
        }

        [PowerFiler("wenzhangfenlei16")]
        public ActionResult upEnable()
        {
            Yax.Model.ArticleType model = new Yax.Model.ArticleType();
            model.ID = Yax.Common.Utils.GetQueryInt("id");
            model.Enable = Yax.Common.Utils.GetQueryInt("enable", 0);
            int res = new Yax.BLL.ArticleType().Update_enable(model);
            if (res > 0)
            {
                new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "删除文章分类（" + model.ID + "）成功");
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }


        [PowerFiler("wenzhang30")]
        public ActionResult listCategoryOther()
        {
            initNewsType();
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string Category = Request.QueryString["Category"];
            string strWhere = "1=1 and enable=1  and ArticleTypeID=0  and Category='"+ Category + "'";
            string id = Yax.Common.Utils.GetQueryInt("ID", 0).ToString();
            if (id == "0")
            {
                id = "";
            }
            string strname = Yax.Common.Utils.GetSafeQueryString("name");
            string adduser = Yax.Common.Utils.GetSafeQueryString("adduser");
            string Typew = Yax.Common.Utils.GetSafeQueryString("Typew");
            string cid = Yax.Common.Utils.GetSafeQueryString("cid");
            string othert = Yax.Common.Utils.GetSafeQueryString("othert");
            if (!string.IsNullOrEmpty(id))
            {
                strWhere += "  and  id=" + id;
            }
            if (!string.IsNullOrEmpty(strname))
            {
                strWhere += "  and  name like '%" + strname + "%'";
            }
            if (!string.IsNullOrEmpty(Typew))
            {
                strWhere += "  and  ArticleTypeID=" + Typew;
            }
            if (!string.IsNullOrEmpty(adduser))
            {
                strWhere += "  and  adminName like '%" + adduser + "%'";
            }
            if (!string.IsNullOrEmpty(othert))
            {
                if (othert == "1")
                {
                    strWhere += "  and  IsIndex=1";
                }
                else if (othert == "2")
                {
                    strWhere += "  and  IsRecoommend=1";
                }
                else if (othert == "3")
                {
                    strWhere += "  and  IsHot=1";
                }
            }
            Yax.BLL.Article bll = new Yax.BLL.Article();
            DataTable list = bll.GetPage_view(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }

        [PowerFiler("wenzhang30")]
        public ActionResult AddArticleCategoryOther()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            if (id > 0)
            {
                Yax.Model.Article model = new Yax.BLL.Article().GetModel(id);
                if (model != null)
                {
                    ViewBag.Name = model.Name;
                    ViewBag.Mark = model.Mark;
                    ViewBag.Autho = model.Autho;
                    ViewBag.ArticleTypeID = model.ArticleTypeID;
                    ViewBag.IsIndex = model.IsIndex;
                    ViewBag.IsRecoommend = model.IsRecoommend;
                    ViewBag.IsHot = model.IsHot;
                    ViewBag.Detail = model.Detail;
                    ViewBag.Cover = model.Cover;
                    ViewBag.Seokeywords = model.SeoKeywords;
                    ViewBag.Seodescription = model.SeoDescription;
                    ViewBag.AddTime = model.AddTime;
                    ViewBag.Hits = model.Hits;
                    ViewBag.Mark = model.Mark;
                }
            }
            else
            {
                ViewBag.AddTime = DateTime.Now;
            }
            return View();
        }



    }
}
