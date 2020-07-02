using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entity;
using VedioAdmin.Filters;

using System.Text.RegularExpressions;
using ComEnum;

namespace VedioAdmin.Controllers
{

    [IsAuditorFilter]
    public class MenuController : BaseController
    {
        BS_Menus bll = new BS_Menus();
        /// <summary>
        /// 显示所有菜单
        /// </summary>
        /// <returns></returns>
        [Power("menu",OpenTypeEnum.Page)]
        public ActionResult Index()
        {
            return View(bll.List());
        }
        [HttpGet]
        [Power("menuadd", OpenTypeEnum.Dialog)]
        public ActionResult Create()
        {
            Dictionary<int, string> dir = InitParentMenu();
            ViewBag.dirFatherMenu = dir;
            string menuType = "nav导航";
            int pid = UCommon.UUtils.GetQueryInt("pid");
            if (pid == 0)
            {
                menuType = "nav导航";
            }
            else
            {
                string[] names = dir.Where(x => x.Key == pid).FirstOrDefault().Value.Split('-');
                if(names==null)
                {
                 
                    menuType = "nav导航";
                }
                else if (names.Length == 1)
                {
                   
                    menuType = "左侧菜单";
                }
                else if (names.Length == 2)
                {
                    menuType = "tab页";
                }
                else if (names.Length == 3)
                {
                    menuType = "按钮";
                }
            }
            ViewBag.menuType = menuType;
            return View();
        }
        [HttpPost]
        [Power("menuadd", OpenTypeEnum.Ajax)]
        public ActionResult Create(string Name,string Mark)
        {
            string MenuType = Request.Form["MenuType"];
            int menuType = 1;
            if(MenuType== "按钮")
            {
                menuType = 2;
            }
            if (string.IsNullOrEmpty(Name))
            {
                return Content("菜单名称不能为空");
            }
            if(MenuType== "tab页"|| MenuType== "按钮")
            {
                if (string.IsNullOrEmpty(Mark))
                {
                    return Content("菜单标识不能为空");
                }
                //Mark最后一个字符不可以是-   log/id  Log  Log-id 
                string lastCharOfMark = Mark.Substring(Mark.Length - 1, 1);//aa-
                if (lastCharOfMark == "-")
                {
                    return Content("菜单标识最后一个字符不能为-");
                }
            }
            else
            {
                Mark = "";
            }
            MS_Menus chkExist = bll.GetModelByMark(Mark);
            if(chkExist!=null&&!string.IsNullOrEmpty(Mark))
            {
                return Content("权限标识已存在");
            }
            MS_Menus model = new MS_Menus();
            model.Name = Request.Form["Name"];
            model.AddTime = DateTime.Now;
            model.AddUser = CUser.ID;
            model.Enable = true;
            model.Icon = UCommon.UUtils.GetFormString("Icon"); 
            model.Mark = Mark;
            model.Memo = UCommon.UUtils.GetFormString("Memo"); 
            model.MenuType = menuType;
            model.ParentID= UCommon.UUtils.GetFormInt("ParentID");
            model.Sort= UCommon.UUtils.GetFormInt("Sort");
            model.Target = UCommon.UUtils.GetFormString("Target"); 
            model.URL =UCommon.UUtils.GetFormString("URL");
            int res= bll.Add(model);
            if(res>0)
            {
                OperateLogAdd("添加菜单：" + model.Name, true);
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
          
        }

        [HttpGet]
        [Power("menuedit", OpenTypeEnum.Dialog)]
        public ActionResult Edit(int id)
        {
            MS_Menus model = bll.GetModelById(id);
            Dictionary<int, string> dir = InitParentMenu();
            ViewBag.dirFatherMenu = dir;
            string menuType = "nav导航";
            if (model.ParentID == 0)
            {
                menuType = "nav导航";
            }
            else
            {
                string[] names = dir.Where(x => x.Key == model.ParentID).FirstOrDefault().Value.Split('-');
                if (names.Length == 1)
                {
                    menuType = "左侧菜单";
                }
                else if (names.Length == 2)
                {
                    menuType = "tab页";
                }
                else if (names.Length == 3)
                {
                    menuType = "按钮";
                }
            }
            ViewBag.menuType = menuType;
            return View(model);
        }
        [HttpPost]
        [Power("menuedit", OpenTypeEnum.Ajax)]
        public ActionResult Edit(int id, string Name)
        {
            string MenuType = Request.Form["MenuType"];
            int menuType = 1;
            if (MenuType == "按钮")
            {
                menuType = 2;
            }
            if (string.IsNullOrEmpty(Name))
            {
                return Content("菜单名称不能为空");
            }
            MS_Menus model_old =bll.GetModelById(id);
            if(model_old==null)
            {
                return Content("数据不存在");
            }
            MS_Menus model = new MS_Menus();
            model.ID = id;
            model.Name = UCommon.UUtils.GetFormString("Name");
            model.Icon = UCommon.UUtils.GetFormString("Icon");
            model.Memo = UCommon.UUtils.GetFormString("Memo");
            model.MenuType = menuType;
            model.ParentID = UCommon.UUtils.GetFormInt("ParentID");
            model.Sort = UCommon.UUtils.GetFormInt("Sort");
            model.Target = UCommon.UUtils.GetFormString("Target"); 
            model.URL = UCommon.UUtils.GetFormString("URL"); 
            int res = bll.Update(model);
            if (res > 0)
            {
                string opermsg = "";
                if(model.Name!=model_old.Name)
                {
                    opermsg += "名称:"+ model_old.Name+">"+model.Name;
                }
                else
                {
                    opermsg += model_old.Name;
                }
                if (model.URL != model_old.URL)
                {
                    opermsg += "链接地址:" + model_old.URL + ">" + model.URL;
                }
                OperateLogAdd("修改菜单：" + opermsg, true);
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }

        }

        [HttpPost]
        [Power("menudel", OpenTypeEnum.Ajax)]
        public ActionResult Delete(int id)
        {
            MS_Menus model = bll.GetModelById(id);
            if (model == null)
            {
                return Content("数据不存在");
            }
            int childNum = bll.CountNumByPid(id);
            if(childNum>0)
            {
                return Content("有子菜单存在无法删除");
            }
            int res= bll.Delete(id);
            if (res > 0)
            {
                OperateLogAdd("删除菜单ID：" + model.ID + ",名称：" + model.Name+"链接地址："+model.URL, true);
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
            
        }


        private Dictionary<int,string> InitParentMenu()
        {
            Dictionary<int, string> dir = new Dictionary<int, string>();
            IList<MS_Menus> list = bll.ListParentMenu();
            var list_FirstParent = list.Where(p => p.ParentID == 0).ToList();//一级主菜单
            foreach(var item in list_FirstParent)
            {
                dir.Add(item.ID,item.Name);
                var list_SecondParent = list.Where(p => p.ParentID == item.ID).ToList(); ///二级主菜单 即左侧菜单
                foreach(var item2 in list_SecondParent)
                {
                    dir.Add(item2.ID,item.Name+"-"+item2.Name);
                    var list_ThirdParent = list.Where(p => p.ParentID == item2.ID).ToList();//三级主菜单 即标签页菜单
                    foreach(var item3 in list_ThirdParent)
                    {
                        dir.Add(item3.ID, item.Name + "-" + item2.Name+"-"+item3.Name);
                    }
                }
            }
            return dir;
        }

    }
}
