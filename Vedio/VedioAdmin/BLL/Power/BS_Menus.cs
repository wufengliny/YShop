
using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCommon.ComNames;

namespace BLL
{
    public class BS_Menus
    {
        private DS_Menus dal = new DS_Menus();
        public IList<MS_Menus> List()
        {
           return dal.List();
        }



        /// <summary>
        /// Laout处调用
        /// </summary>
        /// <param name="OutNav"></param>
        /// <param name="OutLeft"></param>
        /// <param name="OutTabs"></param>
        public void GetMenusShow(out IEnumerable<MS_Menus> OutNav, out IEnumerable<MS_Menus> OutLeft, out IEnumerable<MS_Menus> OutTabs)
        {
            //业务逻辑
            //先判断缓存是否存在 存在直接从缓存中获取，否则配置缓存数据
            //缓存中存值Cache名称》CacheNames.MenuCacheName+AdminGroupID eg（MenuCache1）
            //非超级管理员则先剔除没有权限的菜单
            //为Nav 和Left菜单赋默认值
            //剔除Url为空的Menu菜单

            int menupid = UCommon.UUtils.GetQueryInt("menupid");
            int menuid = UCommon.UUtils.GetQueryInt("menuid");
            int AdminGroupID = new BLL.CurrentAdmin().AdminGroupID;
            object obj = UCommon.UDataCache.GetCache(CacheNames.MenuCacheName + AdminGroupID); 
            List<MS_Menus> listmenu;
            if (obj == null)
            {
                listmenu = HandleMenus(AdminGroupID);
                UCommon.UDataCache.SetCache(CacheNames.MenuCacheName + AdminGroupID, listmenu);
            }
            else
            {
                listmenu = (List<MS_Menus>)obj;
            }
            OutNav = listmenu.Where(x=>x.ParentID==0);
            if(menupid==0&& OutNav.Count()>0)
            {
                menupid = OutNav.FirstOrDefault().ID;
            }
            OutLeft = listmenu.Where(x => x.ParentID == menupid);
            if(menuid==0&& OutLeft.Count()>0)
            {
                menuid = OutLeft.FirstOrDefault().ID;
            }
            OutTabs= listmenu.Where(x => x.ParentID == menuid);
            //注意 Cache 如果值是引用类型  从Cache获取了 对象值，在外部对其重新赋值 则Cache里面的对应的值也会发生变化
        }


        /// <summary>
        ///根据权限 处理菜单 返回需要的菜单
        /// </summary>
        private List<MS_Menus> HandleMenus(int AdminGroupID)
        {
            IList<MS_Power> listPower = new BLL.BS_Power().GetPowersByAdmingroup(AdminGroupID);
            IList<MS_Menus> listMenu = List();
            List<MS_Menus> listMenu2 = listMenu.ToList();
            IEnumerable<MS_Menus> Navlist = listMenu.Where(x => x.ParentID == 0);
            IEnumerable<MS_Menus> Leftlist;
            if (AdminGroupID != 1)
            {
                //非超级管理员则先剔除没有权限的菜单
                foreach (var nav in Navlist)
                {
                    Leftlist = listMenu.Where(x => x.ParentID == nav.ID);
                    foreach (var left in Leftlist)
                    {
                        var tabList = listMenu.Where(x => x.ParentID == left.ID);
                        foreach (var tab in tabList)
                        {
                            if (!listPower.Any(x => x.MenuID == tab.ID))
                            {
                                listMenu2.Remove(tab);
                            }
                        }
                    }
                }
            }
            //listMenu2 为剔除没有权限菜单后的数据集合
            foreach (var nav in Navlist)
            {
                //为Nav 和Left菜单赋默认值
                Leftlist = listMenu2.Where(x => x.ParentID == nav.ID);
                foreach (var left in Leftlist)
                {
                    var firstTab = listMenu2.Where(x => x.ParentID == left.ID).FirstOrDefault();
                    if (firstTab != null)
                    {
                        if (string.IsNullOrEmpty(nav.URL))
                        {
                            nav.URL = firstTab.URL;
                        }
                        left.URL = firstTab.URL;
                    }
                }
            }
            List<MS_Menus> menuCopylist = new List<MS_Menus>();
            listMenu2.ForEach(x=>menuCopylist.Add(x)); //拷贝listMenu2 到menuCopylist
            foreach (var item in listMenu2)
            {
                //剔除Url为空的Menu菜单
                if (string.IsNullOrEmpty(item.URL))
                {
                    menuCopylist.Remove(item);
                }
            }
            return menuCopylist;
        }


        public IList<MS_Menus> ListParentMenu()
        {
            return dal.ListParentMenu();
        }
        public MS_Menus GetModelByMark(string Mark)
        {
            return dal.GetModelByMark(Mark);
        }
        public MS_Menus GetModelById(int id)
        {
            return dal.GetModelById(id);
        }
        public int CountNumByPid(int ParentID)
        {
            return dal.CountNumByPid(ParentID);
        }
        public int Add(MS_Menus model)
        {
            return dal.Add(model);
        }
        public int Update(MS_Menus model)
        {
            return dal.Update(model);
        }
        public int Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
