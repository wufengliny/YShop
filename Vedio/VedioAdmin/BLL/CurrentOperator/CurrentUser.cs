using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UCommon;
namespace BLL
{
    public class CurrentUser
    {
        public CurrentUser()
        {
            string idStr = Cookies.GetCookies(PubStr.MemberCookieName, "userid");
            string lastlogintimeStr = Cookies.GetCookies(PubStr.MemberCookieName, "lastlogintime");
            if(!string.IsNullOrEmpty(idStr))
            {
                idStr = SecurityHelper.Decrypt(idStr);
                int id = 0;
                int.TryParse(idStr, out id);
                ID = id;
                lastlogintimeStr = SecurityHelper.Decrypt(lastlogintimeStr);
                Lastlogintime = UUtils.FromUnixStampSecond(lastlogintimeStr);
                Account = Cookies.GetCookies(PubStr.MemberCookieName, "Account");
                Account = SecurityHelper.Decrypt(Account);
                UserType = Cookies.GetCookies(PubStr.MemberCookieName, "UserType");
                UserType= SecurityHelper.Decrypt(UserType);
            }
        }

        public int ID
        {
            get;
            set;
        }

        public string Account
        {
            get;
            set;
        }


        public string UserType { get; set; }

        public DateTime Lastlogintime { get; set; }



    }
}
