using VedioAdmin.Filters;
using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComEnum;
namespace VedioAdmin.Controllers
{
    [IsAuditorFilter]
    public class PowerController : BaseController
    {
        BS_Power bll = new BS_Power();
        BS_Menus bll_menu = new BS_Menus();
        BS_AdminGroup bll_admingroup = new BS_AdminGroup();
        
        
        [HttpGet]
        [Power("power",OpenTypeEnum.Page)]
        public ActionResult Index()
        {
            int admingroupid = UCommon.UUtils.GetQueryInt("admingroupid");
            var model_admingroup= bll_admingroup.GetModelByID(admingroupid);
            ViewBag.admingroupName = model_admingroup.Name;
            //获取当前权限组 拥有的权限
            IList<MS_Power> Powerlist = bll.GetPowersByAdmingroup(admingroupid);
            ViewBag.Powerlist = Powerlist;
            return View(bll_menu.List());
        }
        
        [HttpPost]
        [Power("power",OpenTypeEnum.Ajax)]
        public ActionResult PowerPost()
        {
            string MenuIDstr = Request.Form["MenuID"];
            if(string.IsNullOrEmpty(MenuIDstr))
            {
                return Content("未配置任何权限");
            }
            int admingroupid = UCommon.UUtils.GetFormInt("admingroupid");
            var adminGroup_model = bll_admingroup.GetModelByID(admingroupid);
            if(adminGroup_model==null)
            {
                return Content("权限组不存在");
            }
            string[] menuids = MenuIDstr.Split(',');
            var list_menu = bll_menu.List();
            bll.DeletePower(admingroupid);
            foreach (var menuid in menuids)
            {
                var mid = int.Parse(menuid);
                var menumodel = list_menu.Where(x => x.ID == mid).FirstOrDefault();
                if (menumodel == null||string.IsNullOrEmpty(menumodel.Mark))
                {
                    continue;
                }
                MS_Power power = new MS_Power();
                power.AdminGroup = admingroupid;
                power.AddTime = DateTime.Now;
                power.Mark = menumodel.Mark;
                power.MenuID = menumodel.ID;
                bll.PowerAdd(power);
            }
            OperateLogAdd("配置权限组（"+ adminGroup_model.Name + "）的权限", true);
            return Content("操作成功");
        }
    }
}