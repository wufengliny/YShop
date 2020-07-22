using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCommon;

namespace VedioWeb.Controllers
{
    public class ValidateCodeController : Controller
    {
        // GET: ValidateCode
        public ActionResult GetValidateCodekay()
        {
            UValidateCode vCode = new UValidateCode();
            string strcode =UUtils.RandCodestr(4);
            string ENcode = SecurityHelper.Encrypt_jia(strcode, "kay965ou");
            Cookies.AddCookies(PubStr.CheckCodeCookieName, "Validecodekay", ENcode, 10);
            byte[] bytes = vCode.CreateCodeKayimg(strcode);
            return File(bytes, @"image");
        }
        public ActionResult GetValidateCodekayReg()
        {
            UValidateCode vCode = new UValidateCode();
            string strcode = UUtils.RandCodestr(4);
            string ENcode = SecurityHelper.Encrypt_jia(strcode, "kay965ou");
            Cookies.AddCookies(PubStr.CheckCodeCookieName, "ValidecodekayReg", ENcode, 10);
            byte[] bytes = vCode.CreateCodeKayimg(strcode);
            return File(bytes, @"image");
        }
    }
}