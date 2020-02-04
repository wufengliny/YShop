using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yax.Common;

namespace YShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Login()
        {
            return View();
            try
            {
                if (Request.Url.Host == "localhost")
                {
                    return View();
                }
                else
                {
                    string adminurl = new Yax.BLL.Config().GetModelBy_key("adminurl").Value;
                    if (adminurl == Request.Url.Host && Request.QueryString["ph"] == "puhui95")
                    {
                        return View();
                    }
                    else
                    {
                     
                        return Redirect("/Login/index");
                    }
                }
            }
            catch
            {
                return Content("系统繁忙");
            }
            
           
        }
        public ActionResult LoginOut()
        {
            Yax.Common.Cookies.DeleteCookies(PubStr.ManageCookieName);
            return View("Login");
        }
        public ActionResult chkL()
        {
            try
            {
                CheckLogin();
            }
            catch(Exception e)
            {
                AjaxMsgHelper.AjaxMsg("2", "Error", "系统错误0001");
                new Yax.BLL.ZY_Log().AddLog_JustMessage(0,e.Message);
                Response.End();
            }
            return null;
        }
        private string ErrrorNum = "";
        Yax.Model.Admin model = null;
        private void CheckLogin()
        {
            string name = Yax.Common.Utils.GetSafeQueryString("txtName"); 
            string pwd = Utils.GetQurryString("txtPwd");
            Yax.BLL.Admin bll = new Yax.BLL.Admin();
            model = bll.GetModelByName(name);
            if (null != model && model.ID > 0)
            {
                if (!IsLock())
                {
                    if (model.Pwd == Yax.Common.SecurityHelper.DifferentMD5(pwd))
                    {
                        int _Exp = 0;//过期时间,浏览器进程
                        Yax.Common.Cookies.AddCookies(PubStr.ManageCookieName, "userid", SecurityHelper.Encrypt(model.ID.ToString()), _Exp);
                        Yax.Common.Cookies.AddCookies(PubStr.ManageCookieName, "username", SecurityHelper.Encrypt(model.Name.ToString()), _Exp);
                        Yax.Common.Cookies.AddCookies(PubStr.ManageCookieName, "lastlogintime", SecurityHelper.Encrypt(model.LastLoginTime.ToString()), _Exp);
                        Yax.Common.Cookies.AddCookies(PubStr.ManageCookieName, "lastloginIP", SecurityHelper.Encrypt(model.LastLoginIP.ToString()), _Exp);
                        Yax.Common.Cookies.AddCookies(PubStr.ManageCookieName, "LoginCount", SecurityHelper.Encrypt((model.LoginCount+1).ToString()), _Exp);
                        Yax.Common.Cookies.AddCookies(PubStr.ManageCookieName, "KGroup", SecurityHelper.Encrypt(model.KGroup.ToString()), _Exp);
                        model.LoginCount += 1;
                        model.LastLoginTime = DateTime.Now;
                        model.ErrorCount = 0;
                        model.LastLoginIP = Utils.GetClientIP();
                        int res = bll.Update(model);
                        if (res > 0)
                        {
                            string adminzhye = new Yax.BLL.Config().GetModelBy_key("adminzhuye").Value;
                            AjaxMsgHelper.AjaxMsg("0", "OK", "登录成功", adminzhye);
                            new Yax.BLL.ZY_Log().AddLog(0, "管理员账号：" + name + "登录成功！");
                        }
                        else
                        {
                            AjaxMsgHelper.AjaxMsg("2", "Error", "系统繁忙");
                        }

                        Response.End();
                    }
                    else
                    {
                        ErrPwdDo();
                        AjaxMsgHelper.AjaxMsg("2", "Error", "密码错误" + ErrrorNum + "次：连续错误5次，帐号将被锁住");
                        Response.End();
                    }
                }
                else
                {
                    AjaxMsgHelper.AjaxMsg("2", "Error", "由于您连续5次输入密码错误，为保护你的帐号安全，请30分钟后再登录");
                    Response.End();
                }
            }
            else
            {
                AjaxMsgHelper.AjaxMsg("1", "Error", "用户名不存在！");
                Response.End();
            }
        }

        //
        private bool IsLock()
        {
            if (DateTime.Now.AddMinutes(-30) > model.LastErrTime)
            {
                Yax.BLL.BCommon bll = new Yax.BLL.BCommon();
                bll.UpdateOneField("Admin", "ErrorCount", "0", " id=" + model.ID, null);
                model.ErrorCount = 0;
                return false;
            }
            else
            {
                if (model.ErrorCount > 4)
                {
                    return true;
                }
            }
            return false;
        }
        //
        private void ErrPwdDo()
        {
            Yax.BLL.Admin bll = new Yax.BLL.Admin();
            if (model != null)
            {
                model.LastErrTime = DateTime.Now;
                model.ErrorCount = model.ErrorCount == null ? 1 : model.ErrorCount + 1;
                bll.UpdateErr(model);
                ErrrorNum = model.ErrorCount.ToString();
            }
            else
            {
                //Do Nothing
            }
        }

    }
}
