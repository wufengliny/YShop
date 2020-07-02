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
            string name = "";//HttpContext.Current.User.Identity.Name
            if (HttpContext.Current != null)
            {
                name = HttpContext.Current.User.Identity.Name;
            }
            if (!string.IsNullOrEmpty(name))
            {
                try
                {
                    string[] userInfo = UCommon.SecurityHelper.DecryptDES(name).Split(new string[] { ",|" }, StringSplitOptions.None);
                    ID = int.Parse(userInfo[0]);
                    Account = userInfo[1];
                    RealName = userInfo[2];
                    Level = int.Parse(userInfo[3]);
                    if (userInfo.Length > 4)
                    {
                        CustPre = userInfo[4];
                    }
                    else
                    {
                        CustPre = new BS_Config().GetModelByIDFromCache(57).Value;
                    }
                    MachineCode = userInfo[5];
                }
                catch (Exception e)
                {

                }
            }
            else
            {

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
        public string RealName
        {
            get;
            set;
        }

        public int Level
        {
            get;
            set;
        }
        /// <summary>
        /// 客户前缀
        /// </summary>
        public string CustPre
        {
            get;
            set;
        }
        /// <summary>
        /// 机器码
        /// </summary>
        public string MachineCode
        {
            get;
            set;
        }





    }
}
