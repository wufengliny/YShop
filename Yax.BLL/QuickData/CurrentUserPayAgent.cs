using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yax.Common;

namespace Yax.BLL.QuickData
{
    public class CurrentUserPayAgent
    {
        public int ID;
        public string Account;
        public string UserType;
        public string lastlogintime;
        public CurrentUserPayAgent()
        {
            int a = 0;
            int.TryParse(Yax.Common.SecurityHelper.Decrypt(Yax.Common.Cookies.GetCookies(PubStr.ShangJiaCookieName, "userid")), out a);
            ID = a;
            Account = Yax.Common.SecurityHelper.Decrypt(Yax.Common.Cookies.GetCookies(PubStr.ShangJiaCookieName, "Account"));
            lastlogintime = Yax.Common.SecurityHelper.Decrypt(Yax.Common.Cookies.GetCookies(PubStr.ShangJiaCookieName, "lastlogintime"));
        }
    }
}
