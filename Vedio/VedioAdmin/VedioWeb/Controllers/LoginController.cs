using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using BLL;
namespace VedioWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LoginPost(string Account,string pwd,string pcode)
        {
            string CookieimgCode = UCommon.Cookies.GetCookies(UCommon.PubStr.CheckCodeCookieName, "Validecodekay");
            if (string.IsNullOrEmpty(CookieimgCode))
            {
                return Content("请重新获取验证码");
            }
            CookieimgCode = UCommon.SecurityHelper.Decrypt_jie(CookieimgCode, "kay965ou");
            if (pcode.ToLower() != CookieimgCode.ToLower())
            {
                return Content("验证码错误");
            }
            MS_User model = new BS_User().GetModelByAccount(Account);
            if (model == null)
            {
                return Content("账号不存在");
            }
            if (model.Enable != 1)
            {
                return Content("账号被封，如有疑问请联系客服人员");
            }
            if (model.ErrorCount > 10)
            {
                TimeSpan ts = DateTime.Now - model.LastErrTime;
                if (ts.TotalMinutes < 60)
                {
                    double restMinute = 60 - ts.TotalMinutes;
                    return Content("由于您连续输出密码错误超过10次，请" + restMinute + "再登陆");
                }
            }
            pwd = UCommon.SecurityHelper.DifferentMD5(pwd);
            if (model.Pwd != pwd)
            {
                new BS_User().UpdateLoginErr(model.ID);
                return Content("密码错误");
            }
            //string strCountIP = " select count(ID) from UserLoginIP where UID=" + model.ID;
            //object objip = new Yax.BLL.BCommon().ExecuteScalar(strCountIP);
            //int ipNum = 0;
            //int.TryParse(objip.ToString(), out ipNum);
            //if (ipNum > 10)
            //{
            //    if (ipNum > 15)
            //    {
            //        return Content("由于您在过多地方登录，现在已被限制登录");
            //    }
            //}
            ////
            //string ClientIP = Yax.Common.Utils.GetClientIP();
            //Yax.Model.UserLoginIP MIP = new Yax.BLL.UserLoginIP().GetModelByIP(ClientIP, model.ID);
            //if (MIP == null)
            //{
            //    string strip = " INSERT INTO [dbo].[UserLoginIP]([IP],[Count],[UID],[Account])";
            //    strip += " VALUES('" + ClientIP + "',1," + model.ID + ",'" + model.Account + "')";
            //    new Yax.BLL.BCommon().ExecuteScalar(strip);
            //}
            //else
            //{
            //    string strip = " update UserLoginIP set Count=Count+1 where id=" + MIP.ID;
            //    new Yax.BLL.BCommon().ExecuteScalar(strip);
            //}
            //// 登陆成功
            //int _Exp = 60 * 24 * 60;//过期时间,浏览器进程
            //DateTime dtNow = DateTime.Now;
            //int ISVIP = 0;
            //if (model.VIP == 1 && model.VIPEndTime > DateTime.Now)
            //{
            //    ISVIP = 1;
            //}
            //Yax.Common.Cookies.AddCookies(PubStr.MemberCookieName, "userid", SecurityHelper.Encrypt(model.ID.ToString()), _Exp);
            //Yax.Common.Cookies.AddCookies(PubStr.MemberCookieName, "Account", SecurityHelper.Encrypt(model.Account.ToString()), _Exp);
            //Yax.Common.Cookies.AddCookies(PubStr.MemberCookieName, "UserType", SecurityHelper.Encrypt(model.UserType.ToString()), _Exp);
            //Yax.Common.Cookies.AddCookies(PubStr.MemberCookieName, "lastlogintime", SecurityHelper.Encrypt(dtNow.ToString()), _Exp);
            //Yax.Common.Cookies.AddCookies(PubStr.MemberCookieName, "VIP", SecurityHelper.Encrypt(ISVIP.ToString()), _Exp);
            //string upstr = "  update Y_User set ErrorCount=0,LoginCount=LoginCount+1,LastLoginIP='" + Utils.GetClientIP() + "',LastLoginTime='" + dtNow + "' where id=" + model.ID;
            //new Yax.BLL.BCommon().ExecuteScalar(upstr);
            return Content("ok");

        }
    }
}