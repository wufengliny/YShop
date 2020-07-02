using ComEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UCommon;
using UCommon.ComNames;

namespace VedioAdmin.Controllers
{
    public class LoginController : Controller
    {
        BLL.BS_Admin bll = new BLL.BS_Admin();
        BLL.BS_Log bll_log = new BLL.BS_Log();
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 登录请求
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LoginPost(string Account, string Pwd)
        {
            if (string.IsNullOrEmpty(Account))
            {
                return Content("账号不能为空");
            }
            if (string.IsNullOrEmpty(Pwd))
            {
                return Content("密码不能为空");
            }
            var model= bll.GetModelByName(Account);
            if(model==null)
            {
                bll_log.LoginLogAdd("输入账号："+ Account+"登录，账号不存在，登录失败",AccountEnum.Admin,2,0,"");
                return Content("账号不存在");
            }
            if( model.Pwd != UCommon.SecurityHelper.DifferentMD5(Pwd))
            {
                if(DateTime.Now>model.LastErrTime.AddHours(1))
                {
                    model.ErrorCount = 0;
                }
                else if (model.ErrorCount>5)
                {
                    return Content("你输入错误次数过多，下次可登录时间："+model.LastErrTime.AddHours(1));
                }
                model.ErrorCount += 1;
                model.LastErrTime = DateTime.Now;
                bll.UpdateLoginError(model);
                bll_log.LoginLogAdd("使用账号：" + Account + "登录，密码错误，登录失败", AccountEnum.Admin, 2, model.ID, model.Name);
                return Content("密码错误，连续登录失败错误"+model.ErrorCount+"次，连续失败5次，账号将被锁住");
            }
            model.LastLoginTime = DateTime.Now;
            model.LastLoginIP = UCommon.UUtils.GetClientIP();
            model.ErrorCount = 0;
            model.LoginCount = model.LoginCount + 1;
            model.IsOnline = true;
            model.LastActiveTime = DateTime.Now;

            //处理cookie 权限信息
            string timeStamp = UCommon.UUtils.ToUnixStamp(model.LastLoginTime);
            //GUID+Name+LastLoginTime+LastLoginIP+AdminGroupID+CustPre+ID
            string CustPre = "0000";
            string cookieStr =model.GUID+ "||"+model.Name+"||"+ timeStamp + "||"+model.LastLoginIP+"||"+model.AdminGroupID+"||"+ CustPre + "||"+SecurityHelper.En_ID(model.ID.ToString());
            cookieStr = SecurityHelper.En_Login(cookieStr);
            FormsAuthentication.SetAuthCookie(cookieStr, false);
            //
            bll.UpdateLogin(model);
            bll_log.LoginLogAdd("管理员：" + Account + "登录成功", AccountEnum.Admin, 1, model.ID, model.Name);
            return Content("/Home/Main");
        }
        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult GetValidateCodekay()
        {
            UValidateCode vCode = new UValidateCode();
            string strcode = UCommon.UUtils.RandCodestr(4).ToUpper();
            string enCode = SecurityHelper.OtherMd5(strcode);
            UCommon.Cookies.AddCookies(CookieNames.ImageCodeCookieName, CookieNames.AdminLoginCookieKey, enCode,CookieExpireTime.ImageCodeCookieExpireTime );
            byte[] bytes = vCode.CreateCodeKayimg(strcode);
            return File(bytes, @"image");
        }

   


        public ActionResult Test()
        {
            DateTime dtnow = DateTime.Now;
            string str =UCommon.UUtils.ToUnixStamp(dtnow);
            string str2 = UCommon.UUtils.FromUnixStamp(str).ToString();
            return Content(str+"-----"+ str2.ToString()+"---"+ dtnow.ToString());
        }
    }


}
