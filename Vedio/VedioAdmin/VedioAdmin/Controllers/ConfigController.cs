using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VedioAdmin.Filters;

namespace VedioAdmin.Controllers
{
    public class ConfigController : BaseController
    {
        BS_Config bconfig = new BS_Config();



        [Power("ConfigList", ComEnum.OpenTypeEnum.Page,true)]
        public ActionResult configlist()
        {
            IList<MS_Config> list = bconfig.GetListByGroup("SiteConfig");
            return View(list);
        }
        /// <summary>
        /// kay 设置 > 网站基本设置 编辑
        /// </summary>
        /// <returns></returns>
        [Power("ConfigEdit", ComEnum.OpenTypeEnum.Dialog)]
        public ActionResult ConfigEdit()
        {
            int id = UCommon.UUtils.GetQueryInt("id");
            MS_Config model = bconfig.GetModelByID(id);
            if (model != null && model.ID > 0)
            {
                ViewBag.Name = model.Name;
                ViewBag.KeyName = model.key;
                ViewBag.Value = model.Value;
                ViewBag.Memo = model.Memo;
            }
            return View();
        }


        /// <summary>
        /// kay 设置 > 网站基本设置 编辑提交
        /// </summary>
        /// <returns></returns>
        [Power("ConfigEdit", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult ConfigEditPost()
        {
            string value = UCommon.UUtils.GetFormString("KValue");
            string memo = UCommon.UUtils.GetFormString("Memo");
            int id = UCommon.UUtils.GetFormInt("id");
            MS_Config model = bconfig.GetModelByID(id);
            int res = bconfig.UpdateByID(id, value, memo);
            if (res > 0)
            {
                if (model.Value != value)
                {
                    string operMsg = "管理员：" + new CurrentUser().Account + "修改网站基本设置》" + model.Name + ":" + model.Value + ">" + value;
                    OperateLogAdd(operMsg, false);
                }
                return Content("操作成功");
            }
            return Content("操作失败");
        }


        [Power("ConfigAdd", ComEnum.OpenTypeEnum.Dialog)]
        public ActionResult ConfigAdd()
        {
            return View();
        }
        [Power("ConfigAdd", ComEnum.OpenTypeEnum.Ajax)]
        public ActionResult ConfigAddPost(string Name,string KeyName, string KValue, string Memo="")
        {
            MS_Config model = bconfig.GetModelByKey(KeyName);
            if(model!=null)
            {
                return Content("键已存在");
            }
            MS_Config modelAdd = new MS_Config();
            modelAdd.AddTime = DateTime.Now;
            modelAdd.AddUser = CUser.ID;
            modelAdd.CanDelete = 1;
            modelAdd.CanEdit = 1;
            modelAdd.Enable = 1;
            modelAdd.Group = "SiteConfig";
            modelAdd.key = KeyName;
            modelAdd.LastModifyTime = DateTime.Now;
            modelAdd.LastModifyUser = CUser.ID;
            modelAdd.Memo = Memo;
            modelAdd.Name = Name;
            modelAdd.Sort = 0;
            modelAdd.Value = KValue;
            int res = bconfig.Add(modelAdd);
            if (res > 0)
            {
                string operMsg = "管理员：" + CUser.Account + "添加网站基本设置》" + modelAdd.Name;
                OperateLogAdd(operMsg, false);
                return Content("操作成功");
            }
            return Content("操作失败");
        }


    }
}