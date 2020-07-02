using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UCommon;

namespace BLL
{
    public class CurrentAdmin
    {
        public CurrentAdmin()
        {
            string name = "";//HttpContext.Current.User.Identity.Name
            if (HttpContext.Current != null)
            {
                name = HttpContext.Current.User.Identity.Name;
            }
            if (!string.IsNullOrEmpty(name))
            {
                try
                {
                    //GUID+Name+LastLoginTime+LastLoginIP+AdminGroupID+CustPre+ID
                    string[] userInfo = SecurityHelper.De_Login(name).Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                    GUID = userInfo[0];
                    Account = userInfo[1];
                    LastLoginTime = UUtils.FromUnixStamp(userInfo[2]);
                    LastLoginIP = userInfo[3];
                    AdminGroupID = int.Parse(userInfo[4]);
                    CustPre = userInfo[5];
                    ID = int.Parse(SecurityHelper.De_ID(userInfo[6]));
                }
                catch (Exception e)
                {

                }
            }
            else
            {

            }

        }

        public string GUID { get; set; }
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
        public DateTime LastLoginTime { get; set; }
        public string LastLoginIP { get; set; }
        public int AdminGroupID { get; set; }

        /// <summary>
        /// 客户前缀
        /// </summary>
        public string CustPre
        {
            get;
            set;
        }





    }
}
