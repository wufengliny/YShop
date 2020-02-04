using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Filters
{
    public class PowerFiler : ActionFilterAttribute, IAuthorizationFilter
    {
        public string Mark;
        public PowerFiler(string mark)
        {
            this.Mark = mark;
        }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            int roleID = +new Yax.BLL.CurrentUser().AdminGroupID;
            if(roleID!=1)
            {
                List<Yax.Model.Power> list;
                string menutype = new Yax.BLL.Config().GetModelBy_key("htmenutype").Value;
                if (roleID > 0)
                {
                    list = new Yax.BLL.Power().GetPowerListCache(roleID, menutype);
                    if (list != null && list.Count > 0)
                    {
                        Yax.Model.Power model = list.Where(p => p.Mark == this.Mark).FirstOrDefault();
                        if(model==null)
                        {
                            filterContext.Result = new RedirectResult("/Login/NotAccess");
                        }
                    }
                    else
                    {
                        filterContext.Result = new RedirectResult("/Login/NotAccess");
                    }
                }
                else
                {
                    filterContext.Result = new RedirectResult("/Login/Login");
                }
            }
            //
        }
    }
}