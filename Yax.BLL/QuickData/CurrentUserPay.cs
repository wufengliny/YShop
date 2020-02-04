using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yax.Common;

namespace Yax.BLL.QuickData
{
    public class CurrentUserPay
    {
        public int ID;
        public string Account;
        public string UserType;
        public string lastlogintime;
        public CurrentUserPay()
        {
            int a = 0;
            int.TryParse(Yax.Common.SecurityHelper.Decrypt(Yax.Common.Cookies.GetCookies(PubStr.MemberCookieName, "userid")), out a);
            ID = a;
            Account = Yax.Common.SecurityHelper.Decrypt(Yax.Common.Cookies.GetCookies(PubStr.MemberCookieName, "Account"));
            lastlogintime = Yax.Common.SecurityHelper.Decrypt(Yax.Common.Cookies.GetCookies(PubStr.MemberCookieName, "lastlogintime"));
        }

    }
}
