using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yax.Common;


namespace Yax.BLL
{

    //管理员 后台 信息获取
    public  class CurrentUser
    {
        public  CurrentUser()
        {
            int a = 0;
            string temp;
            int.TryParse(Yax.Common.SecurityHelper.Decrypt(Yax.Common.Cookies.GetCookies(PubStr.ManageCookieName, "userid")), out a);
            Id = a;
            Name = Yax.Common.SecurityHelper.Decrypt(Yax.Common.Cookies.GetCookies(PubStr.ManageCookieName, "username"));
            Lastlogintime = Yax.Common.SecurityHelper.Decrypt(Yax.Common.Cookies.GetCookies(PubStr.ManageCookieName, "lastlogintime"));
            LastLoginIP = Yax.Common.SecurityHelper.Decrypt(Yax.Common.Cookies.GetCookies(PubStr.ManageCookieName, "lastloginIP"));
            LoginCount = Yax.Common.SecurityHelper.Decrypt(Yax.Common.Cookies.GetCookies(PubStr.ManageCookieName, "LoginCount"));
            temp = Yax.Common.SecurityHelper.Decrypt(Yax.Common.Cookies.GetCookies(PubStr.ManageCookieName, "KGroup"));
            int.TryParse(temp, out AdminGroupID);
        }
        private  int id;

        public  int Id
        {
            get { return id; }
            set { id = value; }
        }
        private  string name;

        public  string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string lastlogintime;

        public string Lastlogintime
        {
            get { return lastlogintime; }
            set { lastlogintime = value; }
        }
        private string lastLoginIP;

        public string LastLoginIP
        {
            get { return lastLoginIP; }
            set { lastLoginIP = value; }
        }
        private string loginCount;
        public string LoginCount
        {
            get { return loginCount; }
            set { loginCount = value; }
        }

        public int AdminGroupID;
        
        
    }
}
