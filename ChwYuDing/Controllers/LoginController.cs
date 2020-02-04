using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yax.Common;

namespace ChwYuDing.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        public ActionResult Error(string msg)
        {
            ViewBag.msg = msg;
            return View();
        }
        public ActionResult LoninOther()
        {
            return Redirect("/login/Error?msg=账号在异地登录，你已被强制下线，请保管好您的账户密码");
        }

        public ActionResult loginout()
        {
            Yax.Common.Cookies.DeleteCookies(Yax.Common.PubStr.MemberCookieName);
            return Redirect("/Login/Login");
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LoginPost()
        {
            string Account = Yax.Common.Utils.GetSafeFormString("Account");
            string pwd = Yax.Common.Utils.GetFormString("pwd");
            string pcode = Yax.Common.Utils.GetFormString("pcode");
            string CookieimgCode = Yax.Common.Cookies.GetCookies(Yax.Common.PubStr.CheckCodeCookieName, "Validecodekay");
            if (string.IsNullOrEmpty(CookieimgCode))
            {
                return Content("请重新获取验证码");
            }
            CookieimgCode = Yax.Common.SecurityHelper.DecrypKay(CookieimgCode);
            if (pcode.ToLower() != CookieimgCode.ToLower())
            {
                return Content("验证码错误");
            }
            Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModelAccount(Account);
            if (model == null)
            {
                return Content("账号不存在");
            }
            if (model.Effect != 1)
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
            pwd = Yax.Common.SecurityHelper.DifferentMD5(pwd);
            if (model.Pwd != pwd)
            {
                string str = " update Y_User set ErrorCount=ErrorCount+1,LastErrTime=GETDATE() where id=" + model.ID;
                new Yax.BLL.BCommon().ExecuteScalar(str);
                return Content("密码错误");
            }
            string strCountIP = " select count(ID) from UserLoginIP where UID=" + model.ID;
            object objip = new Yax.BLL.BCommon().ExecuteScalar(strCountIP);
            int ipNum = 0;
            int.TryParse(objip.ToString(), out ipNum);
            if (ipNum > 10)
            {
                if (ipNum > 15)
                {
                    return Content("由于您在过多地方登录，现在已被限制登录");
                }
            }
            //
            string ClientIP = Yax.Common.Utils.GetClientIP();
            Yax.Model.UserLoginIP MIP = new Yax.BLL.UserLoginIP().GetModelByIP(ClientIP, model.ID);
            if (MIP == null)
            {
                string strip = " INSERT INTO [dbo].[UserLoginIP]([IP],[Count],[UID],[Account])";
                strip += " VALUES('" + ClientIP + "',1," + model.ID + ",'" + model.Account + "')";
                new Yax.BLL.BCommon().ExecuteScalar(strip);
            }
            else
            {
                string strip = " update UserLoginIP set Count=Count+1 where id=" + MIP.ID;
                new Yax.BLL.BCommon().ExecuteScalar(strip);
            }
            // 登陆成功
            int _Exp = 60 * 24 * 60;//过期时间,浏览器进程
            DateTime dtNow = DateTime.Now;
            Yax.Common.Cookies.AddCookies(PubStr.MemberCookieName, "userid", SecurityHelper.Encrypt(model.ID.ToString()), _Exp);
            Yax.Common.Cookies.AddCookies(PubStr.MemberCookieName, "Account", SecurityHelper.Encrypt(model.Account.ToString()), _Exp);
            Yax.Common.Cookies.AddCookies(PubStr.MemberCookieName, "UserType", SecurityHelper.Encrypt(model.UserType.ToString()), _Exp);
            Yax.Common.Cookies.AddCookies(PubStr.MemberCookieName, "lastlogintime", SecurityHelper.Encrypt(dtNow.ToString()), _Exp);
            string upstr = "  update Y_User set ErrorCount=0,LoginCount=LoginCount+1,LastLoginIP='" + Utils.GetClientIP() + "',LastLoginTime='" + dtNow + "' where id=" + model.ID;
            new Yax.BLL.BCommon().ExecuteScalar(upstr);
            return Content("ok");

        }
        public ActionResult Reg()
        {
            return View();
        }
        public ActionResult RegCPost()
        {
            string Account = Yax.Common.Utils.GetSafeFormString("Account");
            string pwd = Yax.Common.Utils.GetSafeFormString("pwd");
            string pcode = Yax.Common.Utils.GetSafeFormString("pcode");
            string CookieimgCode = Yax.Common.Cookies.GetCookies(Yax.Common.PubStr.CheckCodeCookieName, "Validecodekay");
            if (string.IsNullOrEmpty(CookieimgCode))
            {
                return Content("请重新获取验证码");
            }
            if (string.IsNullOrEmpty(Account))
            {
                return Content("账户不能为空");
            }
            if (string.IsNullOrEmpty(pwd))
            {
                return Content("密码不能为空");
            }
            CookieimgCode = Yax.Common.SecurityHelper.DecrypKay(CookieimgCode);
            if (pcode.ToLower() != CookieimgCode.ToLower())
            {
                return Content("验证码错误");
            }
            Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModelAccount(Account);
            if (model != null)
            {
                return Content("该账户名称已被注册，请重新输入账号");
            }
            string memo = "会员注册";
            pwd = Yax.Common.SecurityHelper.DifferentMD5(pwd);
            List<string> list = new List<string>();
            string strSQl = " INSERT INTO [dbo].[Y_User] ([Account],[Pwd] ,[Memo],[UserType],[Effect],[AddTime],AgentID,RegIP,RegURL)VALUES ";
            strSQl += "('" + Account + "','" + pwd + "','" + memo + "','普通',1 ,getdate(),0,'" + Yax.Common.Utils.GetClientIP() + "'";
            strSQl += ",'" + Request.Url.ToString() + "')";
            list.Add(strSQl);
            //

            int res = new Yax.BLL.BCommon().ExecuteSqlTran(list);
            if (res > 0)
            {
                model = new Yax.BLL.Y_User().GetModelAccount(Account);
                //记录登录IP
                string ClientIP = Yax.Common.Utils.GetClientIP();
                string strip = " INSERT INTO [dbo].[UserLoginIP]([IP],[Count],[UID],[Account])";
                strip += " VALUES('" + ClientIP + "',1," + model.ID + ",'" + model.Account + "')";
                new Yax.BLL.BCommon().ExecuteScalar(strip);
                //
                //

                int _Exp = 60 * 24 * 60;//过期时间,浏览器进程
                DateTime dtNow = DateTime.Now;
                Yax.Common.Cookies.AddCookies(PubStr.MemberCookieName, "userid", SecurityHelper.Encrypt(model.ID.ToString()), _Exp);
                Yax.Common.Cookies.AddCookies(PubStr.MemberCookieName, "Account", SecurityHelper.Encrypt(model.Account.ToString()), _Exp);
                Yax.Common.Cookies.AddCookies(PubStr.MemberCookieName, "UserType", SecurityHelper.Encrypt(model.UserType.ToString()), _Exp);
                Yax.Common.Cookies.AddCookies(PubStr.MemberCookieName, "lastlogintime", SecurityHelper.Encrypt(dtNow.ToString()), _Exp);
                string upstr = "  update Y_User set ErrorCount=0,LoginCount=LoginCount+1,LastLoginIP='" + Utils.GetClientIP() + "',LastLoginTime='" + dtNow + "' where id=" + model.ID;
                new Yax.BLL.BCommon().ExecuteScalar(upstr);
                return Content("ok");
            }
            else
            {
                return Content("false");
            }

        }


        public ActionResult test()
        {
            return View();
        }
    }
}