using BLL;
using ComEnum;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VedioAdmin.Filters
{
    /// <summary>
    /// 从数据库获取数据
    /// </summary>
    public class PowerAttribute : ActionFilterAttribute
    {
        public string Mark;
        public int ID;
        public OpenTypeEnum OpenType;
        /// <summary>
        /// 是否搜索页面
        /// </summary>
        public bool IsSearchPage;
        private static BS_Admin bll_BS_Admin=new BS_Admin();//只在第一次运行时初始化
        private static BS_Power bll_BS_Power = new BS_Power();//只在第一次运行时初始化
        public PowerAttribute(string mark, OpenTypeEnum openType,bool isSearchPage=false)
        {
           
            this.Mark = mark;
            OpenType = openType;
            IsSearchPage = isSearchPage;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool HasPower = false;
            object objid = null;
            var actionKeys = filterContext.ActionParameters;
            actionKeys.TryGetValue("id",out objid);  // eg: /home/main/2    程序标识处只需：[Power("loginlog",OpenTypeEnum.Page,true)] 数据库Mark记录 loginlog-2
            string Mark_id = string.Empty;
            if(objid==null)
            {
                Mark_id = Mark;
            }
            else
            {
                Mark_id = Mark+"-"+objid.ToString();
            }
            string guid= new BLL.CurrentAdmin().GUID;
            MS_Admin model = bll_BS_Admin.GetModelByGUID(guid);
            if(model!=null)
            {
                if(model.AdminGroupID==1)
                {
                    HasPower = true;
                }
                else
                {
                    IEnumerable<MS_Power> listpower = bll_BS_Power.ListFromCache(model.AdminGroupID);
                    if (listpower.Any(x => x.Mark == Mark))
                    {
                        HasPower = true;
                    }
                    else if(Mark!=Mark_id)
                    {
                        if(listpower.Any(x=>x.Mark==Mark_id))
                        {
                            HasPower = true;
                        }
                    }
                }
            }
            if(!HasPower)
            {
                RedirctToNoAuth(filterContext);
            }
            if (IsSearchPage)
            {
                FilterSearchParam(filterContext);
            }
        }
        private void RedirctToNoAuth(ActionExecutingContext filterContext)
        {
            if(OpenType==OpenTypeEnum.Dialog)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { area = "Default", Controller = "Error", Action = "Dialog" }));
            }
            else if (OpenType == OpenTypeEnum.Page)
            {
                //后面调整 跳到无权限页面 如果是btn 则弹出无权限dialog
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { area = "Default", Controller = "Error", Action = "NoAuth" }));
                //filterContext.Result = new RedirectResult("http://www.baidu.com");//也可以跳到别的站点
            }
            else if(OpenType == OpenTypeEnum.Ajax)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { area = "Default", Controller = "Error", Action = "Msg" }));
            }

        }


        /// <summary>
        /// 如果是搜索页面 过滤危险字符串  
        /// </summary>
        /// <param name="filterContext"></param>
        private void FilterSearchParam(ActionExecutingContext filterContext)
        {
            var querys=  filterContext.HttpContext.Request.QueryString.AllKeys;
            var forms = filterContext.HttpContext.Request.Form.AllKeys;
            foreach (var item in querys)
            {
                string dangerWords = "";
                string itemValue= filterContext.HttpContext.Request.QueryString[item];
                UCommon.DangerSQLHelper.GetSafeStringForQuery(itemValue, ref dangerWords);
                if(!string.IsNullOrEmpty(dangerWords))
                {
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { area = "Default", Controller = "Error", Action = "DangerSearch",msg=dangerWords }));
                }
            }
            foreach (var item in forms)
            {
                string dangerWords = "";
                string itemValue = filterContext.HttpContext.Request.Form[item];
                UCommon.DangerSQLHelper.GetSafeStringForQuery(itemValue, ref dangerWords);
                if (!string.IsNullOrEmpty(dangerWords))
                {
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { area = "Default", Controller = "Error", Action = "DangerSearch", msg = dangerWords }));
                }
            }
       
        }
    }
}