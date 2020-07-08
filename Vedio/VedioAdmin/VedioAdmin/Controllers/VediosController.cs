using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VedioAdmin.Filters;
using BLL;
using Entity;
using Webdiyer.WebControls.Mvc;

namespace VedioAdmin.Controllers
{
    [IsAuditorFilter]
    public class VediosController : BaseController
    {
        // GET: Vedios
        [Power("Vedios", ComEnum.OpenTypeEnum.Page, true)]
        public ActionResult Index(string Name="",string Category="",string Tag="",int SeriousID=0,string fromTime="",string endTime="",int pi=1)
        {
            string strWhere = " where  cv.Enable=1 ";
            if (!string.IsNullOrEmpty(Name))
            {
                strWhere += " and cv.Name like'%" + Name + "%'";
            }
            if (!string.IsNullOrEmpty(Category))
            {
                strWhere += " and cv.Category='" + Category + "'";
            }
            if (!string.IsNullOrEmpty(Tag))
            {
                strWhere += " and cv.Tag like'%" + Tag + "%'";
            }
            if (SeriousID > 0)
            {
                strWhere += " and cv.SeriousID=" + SeriousID;
            }
            if(!string.IsNullOrEmpty(fromTime))
            {
                strWhere += " and cv.AddTime>'"+fromTime+"'";
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strWhere += " and cv.AddTime<'" + endTime + "'";
            }
            var list = new BC_Vedios().Pager(pi,20,strWhere, " [Sort] asc,AddTime desc ");
            ViewBag.tags = new BC_Tags().List();
            ViewBag.serious = new BC_Serious().List();
            return View(list);
        }

        [HttpGet]
        [Power("VediosAdd", ComEnum.OpenTypeEnum.Dialog)]
        public ActionResult Add(int ID=0)
        {

            ViewBag.tags = new BC_Tags().List();
            ViewBag.serious = new BC_Serious().List();
            MC_Vedios model = new MC_Vedios();
            if(ID>0)
            {
                model = new BC_Vedios().GetModelByID(ID);
            }
            else
            {
                model.Category = "国产";
                model.Price = 0;
                model.Tag = "";
            }
            return View(model);
        }
        [HttpPost]
        [Power("VediosAdd", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult Add(string txtName,string CategoryA,string Url,string VedioLong="",int Sort=100000,decimal Price=0,string Cover="",string tags="", string Seriousname="")
        {
     
            MC_Vedios model = new MC_Vedios();
            model.Name = txtName;
            model.Tag = tags;
            model.VedioLong = VedioLong;
            model.Category = CategoryA;
            model.PreUrl = new BS_Config().GetModelByKey("vediourl").Value;//
            model.Url = Url;
            model.Cover = Cover;
            model.Sort = new BC_Vedios().GetMaxSort(); //
            if(Price<0)
            {
                Price = 0;
            }
            model.Price = Price;
            if (string.IsNullOrEmpty(Seriousname))
            {
                model.SeriousName = "";
                model.SeriousID = 0;
            }
            else
            {
                var seriousModel = new BC_Serious().GetModelByName(Seriousname);
                if(seriousModel!=null)
                {
                    model.SeriousName = Seriousname;
                    model.SeriousID = seriousModel.ID;
                }
                else
                {
                    model.SeriousName = "";
                    model.SeriousID = 0;
                }
            }
            //
            model.Actor = "";
            model.AddTime = DateTime.Now;
            model.Enable = 1;
            model.FreeDownNum = 0;
            model.FreePartUrl = "";
            model.FromCoverUrl = "";
            model.FromPageUrl = "";
            model.FromSite = "sys";
            model.FromVedioUrl = "";
            model.Goods = 0;
            model.Hits = 0;
            model.Introduce = "";
            model.Likes = 0;
            model.Memo = "";
            model.SinglePayDownLoadNum = 0;
            model.VIPDownNum = 0;
            int res= new BC_Vedios().Add(model);
            if(res>0)
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }


        [HttpPost]
        [Power("VediosEdit", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult Edit(string name)
        {
            return View();
        }

        [Power("VediosDelete", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult Delete(string name)
        {
            return View();
        }



        #region 系列
        [Power("VedioSerious", ComEnum.OpenTypeEnum.Page, true)]
        public ActionResult Serious(int pi=1)
        {
            PagedList<MC_Serious> list = new BC_Serious().Pager(pi, PageSize, "Sort asc");
            return View(list);
        }
        [HttpGet]
        [Power("VedioSeriousAdd", ComEnum.OpenTypeEnum.Dialog)]
        public ActionResult SeriousAdd()
        {
            return View();
        }
        [HttpPost]
        [Power("VedioSeriousAdd", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult SeriousAdd(string name)
        {
            var model = new BC_Serious().GetModelByName(name);
            if (model != null)
            {
                return Content("系列已存在");
            }
            else
            {
                model = new MC_Serious();
                model.Name = name;
                model.Sort = 100000;
                int res = new BC_Serious().Add(model);
                if (res > 0)
                {
                    return Content("操作成功");
                }
                else
                {
                    return Content("操作失败");
                }
            }
        }

        [HttpGet]
        [Power("VedioSeriousEdit", ComEnum.OpenTypeEnum.Dialog)]
        public ActionResult SeriousEdit(int ID)
        {
            var model = new BC_Serious().GetModelByID(ID);
            return View(model);
        }
        [HttpPost]
        [Power("VedioSeriousEdit", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult SeriousEdit(int ID,string name)
        {
            MC_Serious model = new MC_Serious();
            model.ID = ID;
            model.Name = name;
            int res= new BC_Serious().Edit(model);
            if (res > 0)
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }

        [Power("VedioSeriousDelete", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult SeriousDelete(int ID)
        {
            var model = new BC_Serious().GetModelByID(ID);
            int res = new BC_Serious().Delete(ID);
            if (res > 0)
            {
                OperateLogAdd("删除系列:" + model.Name, false);
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }
        #endregion


        #region 标签

        [Power("VedioTags", ComEnum.OpenTypeEnum.Page, true)]
        public ActionResult Tags(int pi = 1)
        {
            PagedList<MC_Tags> list = new BC_Tags().Pager(pi, PageSize, "Sort asc");
            return View(list);
        }

        [HttpGet]
        [Power("VedioTagsAdd", ComEnum.OpenTypeEnum.Dialog)]
        public ActionResult TagsAdd()
        {
            return View();
        }
        [HttpPost]
        [Power("VedioTagsAdd", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult TagsAdd(string name)
        {
            var model = new BC_Tags().GetModelByName(name);
            if (model != null)
            {
                return Content("标签已存在");
            }
            else
            {
                model = new MC_Tags();
                model.Name = name;
                model.Sort = 100000;
                int res = new BC_Tags().Add(model);
                if (res > 0)
                {
                    return Content("操作成功");
                }
                else
                {
                    return Content("操作失败");
                }
            }

        }


        [Power("VedioTagsDelete", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult TagsDelete(int ID)
        {
            var model = new BC_Tags().GetModelByID(ID);
            int res = new BC_Tags().Delete(ID);
            if (res > 0)
            {
                OperateLogAdd("删除标签:" + model.Name, false);
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        } 
        #endregion

    }
}