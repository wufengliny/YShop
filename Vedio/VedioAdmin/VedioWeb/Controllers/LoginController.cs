using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using BLL;
using UCommon;

namespace VedioWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
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
            int ipNum =new  BS_UserLoginIP().CountByUID(model.ID);
            if (ipNum > 15)
            {
                return Content("由于您在过多地方登录，现在已被限制登录");
            }
            string ClientIP = UCommon.UUtils.GetClientIP();
            MS_UserLoginIP MIP = new BS_UserLoginIP().GetModelByIPUID(ClientIP, model.ID);
            if (MIP == null)
            {
                MIP = new MS_UserLoginIP();
                MIP.Account = model.Account;
                MIP.Count = 1;
                MIP.IP = ClientIP;
                MIP.UID = model.ID;
                new BS_UserLoginIP().Add(MIP);
            }
            else
            {
                new BS_UserLoginIP().UpdateCount(MIP.ID);
            }
            //登陆成功
            int _Exp = 60 * 24 * 60;//过期时间,浏览器进程
            DateTime dtNow = DateTime.Now;
            int ISVIP = 0;
            if (model.VIP&& model.VIPEndTime > DateTime.Now)
            {
                ISVIP = 1;
            }
            Cookies.AddCookies(PubStr.MemberCookieName, "userid", SecurityHelper.Encrypt(model.ID.ToString()), _Exp);
            Cookies.AddCookies(PubStr.MemberCookieName, "Account", SecurityHelper.Encrypt(model.Account.ToString()), _Exp);
            Cookies.AddCookies(PubStr.MemberCookieName, "UserType", SecurityHelper.Encrypt(model.UserType.ToString()), _Exp);
            Cookies.AddCookies(PubStr.MemberCookieName, "lastlogintime", SecurityHelper.Encrypt(UUtils.ToUnixStampSecond(dtNow)), _Exp);
            Cookies.AddCookies(PubStr.MemberCookieName, "VIP", SecurityHelper.Encrypt(ISVIP.ToString()), _Exp);
            new BS_User().UpdateLoginOK(ClientIP,dtNow,model.ID);
            return Content("ok");
        }

        public ActionResult LoginOut()
        {
            Cookies.DeleteCookies(PubStr.MemberCookieName);
            return Redirect("/aca/index");
        }

        [HttpPost]
        public ActionResult RegPost(string reAccount,string repwd,string repcode)
        {
            string CookieimgCode =Cookies.GetCookies(PubStr.CheckCodeCookieName, "ValidecodekayReg");
            if (string.IsNullOrEmpty(CookieimgCode))
            {
                return Content("请重新获取验证码");
            }
            if (string.IsNullOrEmpty(reAccount))
            {
                return Content("账户不能为空");
            }
            if (string.IsNullOrEmpty(repwd))
            {
                return Content("密码不能为空");
            }
            CookieimgCode =SecurityHelper.Decrypt_jie(CookieimgCode, "kay965ou");
            if (repcode.ToLower() != CookieimgCode.ToLower())
            {
                return Content("验证码错误");
            }
            MS_User model = new BS_User().GetModelByAccount(reAccount);
            if (model != null)
            {
                return Content("该账户名称已被注册，请重新输入账号");
            }
            string memo = "会员注册";
            repwd = SecurityHelper.DifferentMD5(repwd);
            List<string> list = new List<string>();
            model = new MS_User();
            model.Account = reAccount;
            model.Pwd = repwd;
            model.Memo = memo;
            //
            model.GUID = Guid.NewGuid().ToString("N");
            model.LoginCount = 0;
            model.RegIP = UCommon.UUtils.GetClientIP();
            model.RegURL = Request.Url.Host;
            model.AddTime = DateTime.Now;
            model.RegType = 2;
            model.Enable = 1;
            model.Memo = memo;
            model.ErrorCount = 0;
            model.UserType = "会员";
            model.VIP = false;
            int res = new BS_User().Add(model);
            if (res > 0)
            {
                string ClientIP = UUtils.GetClientIP();
                model = new BS_User().GetModelByAccount(reAccount);
                MS_UserLoginIP MIP = new MS_UserLoginIP();
                MIP.Account = model.Account;
                MIP.Count = 1;
                MIP.IP = ClientIP;
                MIP.UID = model.ID;
                new BS_UserLoginIP().Add(MIP);
                //记录登录IP
                int _Exp = 60 * 24 * 60;//过期时间,浏览器进程
                DateTime dtNow = DateTime.Now;
                Cookies.AddCookies(PubStr.MemberCookieName, "userid", SecurityHelper.Encrypt(model.ID.ToString()), _Exp);
                Cookies.AddCookies(PubStr.MemberCookieName, "Account", SecurityHelper.Encrypt(model.Account.ToString()), _Exp);
                Cookies.AddCookies(PubStr.MemberCookieName, "UserType", SecurityHelper.Encrypt(model.UserType.ToString()), _Exp);
                Cookies.AddCookies(PubStr.MemberCookieName, "lastlogintime", SecurityHelper.Encrypt(dtNow.ToString()), _Exp);
                Cookies.AddCookies(PubStr.MemberCookieName, "VIP", SecurityHelper.Encrypt("0"), _Exp);
                new BS_User().UpdateLoginOK(ClientIP, dtNow, model.ID);
                return Content("ok");
            }
            else
            {
                return Content("false");
            }
        }

    }
}