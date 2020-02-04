using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yax.Common;

namespace AMH.Controllers
{
    public class ValidateCodeController : Controller
    {
        //
        // GET: /ValidateCode/

        public ActionResult GetValidateCodekay()
        {
            ValidateCode vCode = new ValidateCode();
            string strcode = Yax.Common.Utils.RandCodestr(4);
            string ENcode = Yax.Common.SecurityHelper.EncryptKay(strcode);
            Yax.Common.Cookies.AddCookies(PubStr.CheckCodeCookieName, "Validecodekay", ENcode, PubStr.CheckCodeCookieExpireTime);
            byte[] bytes = vCode.CreateCodeKayimg(strcode);
            return File(bytes, @"image");
        }

    }
}
