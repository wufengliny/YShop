using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Yax.Common;
namespace YShop.Filters
{
    public class QiYeActionAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            setFriendLinkChace();
            Setother();
        }
        private void setFriendLinkChace()
        {
            string strWhere = "1=1 and Enable=1 ";
            int TotalCount;
            int TotalPage;
            object obj = Yax.Common.DataCache.GetCache("webFriendLink");
            List<Yax.Model.FriendLink> listfriend;
            if (obj == null)
            {
                listfriend = new Yax.BLL.FriendLink().GetPage(1, 100, strWhere, "sort Desc", "*", out TotalCount, out TotalPage);
                Yax.Common.DataCache.SetCache("webFriendLink", listfriend);
            }




        }

        private void Setother()
        {
            object obj = Yax.Common.DataCache.GetCache("innvernavqiye");
            List<Yax.Model.Config> list;
            if (obj == null)
            {
                list = new Yax.BLL.Config().GetList(100, "*", "GroupName='innvernav'", "sort asc");
                if(list!=null&&list.Count>0)
                {
                    Yax.Common.DataCache.SetCache("innvernavqiye", list);
                }
            }
        }


    }
}