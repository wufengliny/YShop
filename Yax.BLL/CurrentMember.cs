using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yax.Common;
namespace Yax.BLL
{
    public class CurrentMember
    {
        public CurrentMember()
        {
            id = 0;
            isLogin = false;
            string cookieid = Cookies.GetCookies(PubStr.MemberCookieName, "userid");
            if(!string.IsNullOrEmpty(cookieid))
            {
                int.TryParse(SecurityHelper.Decrypt(cookieid), out id);
            }
            if(id>0)
            {
                isLogin = true;
            }
            phone = Yax.Common.SecurityHelper.Decrypt(Yax.Common.Cookies.GetCookies(PubStr.MemberCookieName, "phone"));
        }
        private int id;
        private bool isLogin;
        private string phone;
        private double money;

        private string realName;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public bool IsLogin
        {
            get
            {
                return isLogin;
            }

            set
            {
                isLogin = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public double Money
        {
            get
            {
                return money;
            }

            set
            {
                money = value;
            }
        }

        public string RealName
        {
            get
            {
                realName = Yax.Common.Cookies.GetCookies(Yax.Common.PubStr.MemberCookieName, "RealName");
                if(string.IsNullOrEmpty(realName))
                {
                    realName = new Yax.BLL.Y_User().GetModel(new CurrentMember().id).RealName;
                    Yax.Common.Cookies.AddCookies(Yax.Common.PubStr.MemberCookieName, "RealName",realName,0);
                }
                return realName;
            }

            set
            {
                realName = value;
            }
        }
    }
}
