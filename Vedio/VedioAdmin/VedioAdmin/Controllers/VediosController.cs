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
    public class VediosController : BaseController
    {
        // GET: Vedios
        [Power("Vedios", ComEnum.OpenTypeEnum.Page, true)]
        public ActionResult Index()
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