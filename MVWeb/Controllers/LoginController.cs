using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yax.Common;

namespace MVWeb.Controllers
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
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult loginout()
        {
            Yax.Common.Cookies.DeleteCookies(Yax.Common.PubStr.MemberCookieName);
            return Redirect("/Login/Login");
        }
        public ActionResult LoginPost()
        {
            string Account = Yax.Common.Utils.GetSafeFormString("Account");
            string pwd = Yax.Common.Utils.GetFormString("pwd");
            string pcode = Yax.Common.Utils.GetFormString("pcode");
            string CookieimgCode = Yax.Common.Cookies.GetCookies(Yax.Common.PubStr.CheckCodeCookieName, "Validecodekay");
            if(string.IsNullOrEmpty(CookieimgCode))
            {
                return Content("请重新获取验证码");
            }
            CookieimgCode = Yax.Common.SecurityHelper.DecrypKay(CookieimgCode);
            if (pcode.ToLower()!= CookieimgCode.ToLower())
            {
                return Content("验证码错误");
            }
            Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModelAccount(Account);
            if(model==null)
            {
                return Content("账号不存在");
            }
            if(model.Effect!=1)
            {
                return Content("账号被封，如有疑问请联系客服人员");
            }
            if(model.ErrorCount>10)
            {
                TimeSpan ts = DateTime.Now - model.LastErrTime;
                if(ts.TotalMinutes<60)
                {
                    double restMinute = 60 - ts.TotalMinutes;
                    return Content("由于您连续输出密码错误超过10次，请"+restMinute+"再登陆");
                }
            }
            pwd = Yax.Common.SecurityHelper.DifferentMD5(pwd);
            if(model.Pwd!=pwd)
            {
                string str = " update Y_User set ErrorCount=ErrorCount+1,LastErrTime=GETDATE() where id="+model.ID;
                new Yax.BLL.BCommon().ExecuteScalar(str);
                return Content("密码错误");
            }
            string strCountIP = " select count(ID) from UserLoginIP where UID="+model.ID;
            object objip = new Yax.BLL.BCommon().ExecuteScalar(strCountIP);
            int ipNum = 0;
            int.TryParse(objip.ToString(), out ipNum);
            if(ipNum>10)
            {
                if(ipNum>15)
                {
                    return Content("由于您在过多地方登录，现在已被限制登录");
                }
            }
            //
            string ClientIP = Yax.Common.Utils.GetClientIP();
            Yax.Model.UserLoginIP MIP = new Yax.BLL.UserLoginIP().GetModelByIP(ClientIP,model.ID);
            if(MIP==null)
            {
                string strip = " INSERT INTO [dbo].[UserLoginIP]([IP],[Count],[UID],[Account])";
                strip += " VALUES('"+ ClientIP + "',1,"+model.ID+",'"+model.Account+"')";
                new Yax.BLL.BCommon().ExecuteScalar(strip);
            }
            else
            {
                string strip = " update UserLoginIP set Count=Count+1 where id="+MIP.ID;
                new Yax.BLL.BCommon().ExecuteScalar(strip);
            }
            // 登陆成功
            int _Exp = 60 * 24 * 60;//过期时间,浏览器进程
            DateTime dtNow = DateTime.Now;
            Yax.Common.Cookies.AddCookies(PubStr.MemberCookieName, "userid", SecurityHelper.Encrypt(model.ID.ToString()), _Exp);
            Yax.Common.Cookies.AddCookies(PubStr.MemberCookieName, "Account", SecurityHelper.Encrypt(model.Account.ToString()), _Exp);
            Yax.Common.Cookies.AddCookies(PubStr.MemberCookieName, "UserType", SecurityHelper.Encrypt(model.UserType.ToString()), _Exp);
            Yax.Common.Cookies.AddCookies(PubStr.MemberCookieName, "lastlogintime", SecurityHelper.Encrypt(dtNow.ToString()), _Exp);
            string upstr = "  update Y_User set ErrorCount=0,LoginCount=LoginCount+1,LastLoginIP='"+ Utils.GetClientIP() + "',LastLoginTime='"+dtNow+ "' where id="+model.ID;
            new Yax.BLL.BCommon().ExecuteScalar(upstr);
            return Content("ok");
          
        }


        public ActionResult RegC()
        {
            return View();
        }
        public ActionResult RegCPost()
        {
            string regcode = Yax.Common.Utils.GetSafeFormString("regcode");
            string Account= Yax.Common.Utils.GetSafeFormString("Account");
            string pwd = Yax.Common.Utils.GetSafeFormString("pwd");
            string pcode = Yax.Common.Utils.GetSafeFormString("pcode");
            string CookieimgCode = Yax.Common.Cookies.GetCookies(Yax.Common.PubStr.CheckCodeCookieName, "Validecodekay");
            if (string.IsNullOrEmpty(CookieimgCode))
            {
                return Content("请重新获取验证码");
            }
            if(string.IsNullOrEmpty(Account))
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
            Yax.Model.M_RegUserCode mcode = new Yax.BLL.M_RegUserCode().GetModelBy_code(regcode);
            if(mcode==null)
            {
                return Content("邀请码不存在");
            }
            if(mcode.UseTime==1)
            {
                return Content("邀请码已使用");
            }
            Yax.Model.Y_User mAgent = new Yax.BLL.Y_User().GetModel(mcode.AgentID);
            Yax.Model.Y_User model = new Yax.BLL.Y_User().GetModelAccount(Account);
            if(model!=null)
            {
                return Content("该账户名称已被注册，请重新输入账号");
            }
            pwd = Yax.Common.SecurityHelper.DifferentMD5(pwd);
            string memo = "邀请码注册："+ regcode+"";
            List<string> list = new List<string>();
            string strSQl = " INSERT INTO [dbo].[Y_User] ([Account],[Pwd] ,[Memo],[UserType],[Effect],[AddTime],AgentID,RegIP,RegURL)VALUES ";
            strSQl += "('" + Account + "','" + pwd + "','" + memo + "','会员',1 ,getdate(),"+mcode.AgentID+",'"+Yax.Common.Utils.GetClientIP()+"'";
            strSQl += ",'"+Request.Url.ToString()+"')";
            list.Add(strSQl);
            list.Add(" update  M_RegUserCode set RegAccount='"+ Account + "',RegTime=getdate(),UseTime=1 where id="+mcode.ID);
            //新增会员上级代理抽成
            list.Add(" update Y_User set JIFen=JIFen+50 where id="+mcode.AgentID);
            string strSQL_JIfen = "INSERT INTO [dbo].[JiFenDetail]([PreJiFen],[Jifen],[AfterJIfen],[Memo],[AddTime],[UID],[Account])";
            strSQL_JIfen += " VALUES(" + mAgent.JIFen + ",50," + (mAgent.JIFen + 50) + ",'新增会员上级代理抽成',getdate()," + mAgent.ID + ",'" + mAgent.Account + "')";
            list.Add(strSQL_JIfen);
           //

            int res= new Yax.BLL.BCommon().ExecuteSqlTran(list);
            if(res>0)
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


    }
}