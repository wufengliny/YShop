using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Admin.Filters;
using System.Data;
using System.Xml;

namespace YShop.Areas.Admin.Controllers
{
    [YUAction]
    public class MenuController : Controller
    {
        //
        // GET: /Menu/

        #region 菜单
        public ActionResult topmenu()
        {
            Dictionary<string, Yax.Common.DataModelHelper.AdminMenu> menulistPower = null;
            int AdminGroupID = new Yax.BLL.CurrentUser().AdminGroupID;
            object obj = Yax.Common.DataCache.GetCache("adminpowermenutop" + AdminGroupID);
            if(obj==null)
            {
                string adminxmlName = new Yax.BLL.Config().GetModelBy_key("htmenutype").Value;
                Dictionary<string, Yax.Common.DataModelHelper.AdminMenu> menulist = null;
                menulist = Yax.BLL.Power.LoadMenuListFromCache();
                int t1;
                int t2;
                List<Yax.Model.Power> listpower = new Yax.BLL.Power().GetPage(1, 1000, "AdminGroupID=" + AdminGroupID + "and MenuType='" + adminxmlName + "'", "ID asc", "*", out t1, out t2);
                if (menulist.Count > 0)
                {
                    if(AdminGroupID==1)
                    {
                        menulistPower = menulist;
                    }
                    else
                    {
                        menulistPower = new Dictionary<string, Yax.Common.DataModelHelper.AdminMenu>();
                        foreach (var menumodel in menulist)
                        {
                            if (listpower.Where(p => p.MenuID == menumodel.Key).FirstOrDefault() != null)
                            {
                                menulistPower.Add(menumodel.Key, menumodel.Value);
                            }
                        }
                    }
                }
                Yax.Common.DataCache.SetCache("adminpowermenutop" + AdminGroupID, menulistPower);
            }
            else
            {
                menulistPower=(Dictionary<string, Yax.Common.DataModelHelper.AdminMenu>)obj;
            }
            return View(menulistPower);
        }


        public ActionResult leftmenu()
        {
            Dictionary<string, Yax.Common.DataModelHelper.AdminMenuChild> chilelistPower = null;
            int AdminGroupID = new Yax.BLL.CurrentUser().AdminGroupID;
            object obj = Yax.Common.DataCache.GetCache("adminpowermenuleft" + AdminGroupID);
            if (obj==null)
            {
                string adminxmlName = new Yax.BLL.Config().GetModelBy_key("htmenutype").Value;
                Dictionary<string, Yax.Common.DataModelHelper.AdminMenu> menulist = null;
                menulist = Yax.BLL.Power.LoadMenuListFromCache();
                int t1;
                int t2;
                List<Yax.Model.Power> listpower = new Yax.BLL.Power().GetPage(1, 1000, "AdminGroupID=" + AdminGroupID + "and MenuType='" + adminxmlName + "'", "ID asc", "*", out t1, out t2);
                if (menulist.Count > 0)
                {
                    chilelistPower = new Dictionary<string, Yax.Common.DataModelHelper.AdminMenuChild>();
                    foreach (var menumodel in menulist)
                    {
                        if(AdminGroupID==1)
                        {
                            foreach (var itemmodel in menumodel.Value.ItemList)
                            {
                                chilelistPower.Add(itemmodel.Key, itemmodel.Value);
                            }
                        }
                        else
                        {
                            if (listpower.Where(p => p.MenuID == menumodel.Key).FirstOrDefault() != null)
                            {
                                foreach (var itemmodel in menumodel.Value.ItemList)
                                {
                                    if (listpower.Where(p => p.MenuID == itemmodel.Key).FirstOrDefault() != null)
                                    {
                                        chilelistPower.Add(itemmodel.Key, itemmodel.Value);
                                    }
                                }
                            }
                        }
                        
                    }
                }
                Yax.Common.DataCache.SetCache("adminpowermenuleft" + AdminGroupID, chilelistPower);
               
            }
            else
            {
                chilelistPower = (Dictionary<string, Yax.Common.DataModelHelper.AdminMenuChild>)obj;
            }

            Dictionary<string, Yax.Common.DataModelHelper.AdminMenuChild> chilelistPower_this = null;
            string pid = Yax.Common.Utils.GetQurryString("pid","001");
            if (!string.IsNullOrEmpty(pid))
            {
                chilelistPower_this = new Dictionary<string, Yax.Common.DataModelHelper.AdminMenuChild>();
                foreach (var cmodel in chilelistPower)
                {
                    if(cmodel.Key.Contains(pid+"_"))
                    {
                        chilelistPower_this.Add(cmodel.Key,cmodel.Value);
                    }
                }
            }
            return View(chilelistPower_this);
        } 

       
  
        #endregion

        [PowerFiler("dangqianht17")]
        public ActionResult NowHT()
        {
            string htmenutype = new Yax.BLL.Config().GetModelBy_key("htmenutype").Value;
            ViewBag.htmenutype = htmenutype;
            return View();
        }
        [PowerFiler("dangqianht17")]
        public ActionResult NowHTPost()
        {
            string htmenutype = Yax.Common.Utils.GetQurryString("htmenutype");
            if(!string.IsNullOrEmpty(htmenutype))
            {
                Yax.Model.Config model = new Yax.Model.Config();
                model.KeyName = "htmenutype";
                model.Value = htmenutype;
                new Yax.BLL.Config().UpdateValue(model);
                Yax.BLL.WebTool.DelChcheWeb();
                return Content("设置成功");
            }
            else
            {
                return Content("false");
            }
            return View();
        }

        //
        [PowerFiler("power8")]
        public ActionResult Power()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            Yax.Model.AdminGroup model_group ;
            if(id>0)
            {
                model_group = new Yax.BLL.AdminGroup().GetModel(id);
                if(model_group!=null)
                {
                    ViewBag.Name = model_group.Name;
                }
            }
            //
            string adminxmlName = new Yax.BLL.Config().GetModelBy_key("htmenutype").Value;
            Dictionary<string, Yax.Common.DataModelHelper.AdminMenu> menulist = null;
            menulist = Yax.BLL.Power.LoadMenuListFromCache();
            int  t1;
            int  t2;
            List<Yax.Model.Power> listpower = new Yax.BLL.Power().GetPage(1,1000, "AdminGroupID="+ id + "and MenuType='"+ adminxmlName + "'" , "ID asc","*",out t1,out t2);
            ViewBag.listpower = listpower;
            return View(menulist);
        }

        [PowerFiler("power8")]
        public ActionResult PowerPost()
        {
            string secondpwd = Yax.Common.Utils.GetSafeFormString("secpwd").Trim();
            string menuid = Yax.Common.Utils.GetSafeFormString("MenuID");
            Yax.Model.Admin model = new Yax.BLL.Admin().GetModel(new Yax.BLL.CurrentUser().Id);
            if(model.SecondPwd==Yax.Common.SecurityHelper.DifferentMD5(secondpwd))
            {
                string adminxmlName = new Yax.BLL.Config().GetModelBy_key("htmenutype").Value;
                int AdminGroupID = Yax.Common.Utils.GetFormInt("KGroup");
                //
                StringBuilder SQLstr = new StringBuilder(2000);
                string[] menus = menuid.Split(',');
                Dictionary<string, Yax.Common.DataModelHelper.AdminMenu> menulist = Yax.BLL.Power.LoadMenuListFromCache();
                string strdelete = "delete from Power where AdminGroupID=" + AdminGroupID + "  and MenuType='" + adminxmlName + "' ;";
                foreach (string menu in menus)
                {
                    string mark = "";
                    if (!string.IsNullOrEmpty(menu))
                    {
                        if (menu.Contains("_"))
                        {
                            foreach (var item in menulist)
                            {
                                KeyValuePair<string,Yax.Common.DataModelHelper.AdminMenuChild> mt= item.Value.ItemList.Where(p => p.Key == menu).FirstOrDefault();
                                if(mt.Key!=null)
                                {
                                    mark = mt.Value.Mark;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            mark = menulist[menu].Mark;
                        }
                        SQLstr.Append("INSERT INTO [dbo].[Power]([MenuID],[MenuType] ,[AdminGroupID],[Mark])VALUES");
                        SQLstr.Append("('" + menu + "','" + adminxmlName + "'," + AdminGroupID + ",'" + mark + "') ");
                        SQLstr.Append(";");
                    }
                }
                //
                int res = new Yax.BLL.Power().AddPowers(strdelete + SQLstr.ToString());
                if (res > 0)
                {
                    Yax.Common.DataCache.RemoveCache("adminpowermenutop" + AdminGroupID);
                    Yax.Common.DataCache.RemoveCache("adminpowermenuleft" + AdminGroupID);
                    Yax.Common.DataCache.RemoveCache("AdminPower" + AdminGroupID + adminxmlName);
                    return Content("配置成功");
                }
                else
                {
                    return Content("配置失败");
                }
            }
            else
            {
                return Content("二级密码错误");
            }
        }
    }
}
