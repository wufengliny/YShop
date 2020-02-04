using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yax.BLL
{
    public class WebTool
    {
        public static string GetAdminUrl()
        {
            string url = "";
            object objurl = Yax.Common.DataCache.GetCache("adminurl");
            if (objurl == null)
            {
                url = new Yax.BLL.Config().GetModel(4).Value;
                Yax.Common.DataCache.SetCache("adminurl", url);
            }
            else
            {
                url = objurl.ToString();
            }
            return url;
        }
        public static string GetHotSearch()
        {
            string str = "";
            object obj = Yax.Common.DataCache.GetCache("HotSearch");
            if (obj == null)
            {
                str = new Yax.BLL.Config().GetModel(3).Value;
                Yax.Common.DataCache.SetCache("HotSearch", str);
            }
            else
            {
                str = obj.ToString();
            }
            string[] strs ;
            strs = str.Split(',');
            return str;
        }



        public string GetMemberName()
        {
            string name = Yax.Common.Cookies.GetCookies(Yax.Common.PubStr.MemberCookieName, "username");
            return Yax.Common.SecurityHelper.Decrypt(name);
        }
        public int GetMemberID()
        {
            string name = Yax.Common.Cookies.GetCookies(Yax.Common.PubStr.MemberCookieName, "userid");
            name = Yax.Common.SecurityHelper.Decrypt(name);
            int id = 0;
            int.TryParse(name,out id);
            return id;
        }
        public string GetMemberLastLoginTime()
        {
            string name = Yax.Common.Cookies.GetCookies(Yax.Common.PubStr.MemberCookieName, "lastlogintime");
            return Yax.Common.SecurityHelper.Decrypt(name);
        }



        public static Yax.Model.Web_Img ImglogoTop()
        {
            Yax.Model.Web_Img model = new Model.Web_Img();
            object obj = Yax.Common.DataCache.GetCache("ImglogoTop");
            if (obj == null)
            {
                model = new Yax.BLL.Web_Img().GetModel(1);
                Yax.Common.DataCache.SetCache("ImglogoTop", model);
            }
            else
            {
                model = (Yax.Model.Web_Img)obj;
            }
            return model;
        }
        public static Yax.Model.Web_Img ImglogoBottom()
        {
            Yax.Model.Web_Img model = new Model.Web_Img();
            object obj = Yax.Common.DataCache.GetCache("ImglogoBottom");
            if (obj == null)
            {
                model = new Yax.BLL.Web_Img().GetModel(2);
                Yax.Common.DataCache.SetCache("ImglogoBottom", model);
            }
            else
            {
                model = (Yax.Model.Web_Img)obj;
            }
            return model;
        }

        public static List<Yax.Model.Web_Img> GetWebImgADLunBo()
        {
            List<Yax.Model.Web_Img> listimg = new List<Model.Web_Img>();
            object obj = Yax.Common.DataCache.GetCache("WebImgADLunBo");
            if (obj == null)
            {
                listimg = new Yax.BLL.Web_Img().GetList(100, "*", "Enabale=1 and ImgType=1","ID Asc");
                Yax.Common.DataCache.SetCache("WebImgADLunBo", listimg);
            }
            else
            {
                listimg = (List<Yax.Model.Web_Img>)obj;
            }
            return listimg;
        }

        public static List<Yax.Model.S_Menu> GetMenuWeb()
        {
            List<Yax.Model.S_Menu> list = new List<Model.S_Menu>();
            object obj = Yax.Common.DataCache.GetCache("MenuWeb");
            if (obj == null)
            {
                list = new Yax.BLL.S_Menu().GetList(100, "*", "enable=1 and ParentID=0  and type=1", "sort desc");
                Yax.Common.DataCache.SetCache("MenuWeb", list);
            }
            else
            {
                list = (List<Yax.Model.S_Menu>)obj;
            }
            return list;
        }
        public static void DelChcheWeb()
        {
            //清除前台缓存
            try
            {
                Yax.Common.DataCache.RemoveAllCache();
                //string strurl = new Yax.BLL.Config().GetModel(2).Value + "/home/DelChacheAll";
                //Yax.Common.HTTPHelper.GetHtml_01_Post(strurl, "");
            }
            catch
            {
                new Yax.BLL.ZY_Log().AddLog(2, "更新信息时，清除缓存失败");
            }
        }

    }
}
