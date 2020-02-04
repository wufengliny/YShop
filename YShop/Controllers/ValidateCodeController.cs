using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yax.Common;
namespace YShop.Controllers
{
    public class ValidateCodeController : Controller
    {
        //
        // GET: /ValidateCode/

        public ActionResult GetValidateCode()
        {
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(5);
            Session["ValidateCode"] = code;
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }
        public ActionResult GetValidateCodeLogin()
        {
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(5);

            Yax.Common.Cookies.AddCookies(Yax.Common.PubStr.MemberCookieName, "ValidateCodelogin", code, PubStr.CheckCodeCookieExpireTime);
            //Session["ValidateCodelogin"] = code;
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }
        public ActionResult GetValidateCode2()
        {
            ValidateCode vCode = new ValidateCode();
            //string code = vCode.CreateValidateCode(5);
            string code = "68加12=?";
            string result = "80";
            int code1;
            int code2;
            Random random = new Random();
            if (DateTime.Now.Second % 2 == 0)
            {
                code1 = random.Next(1, 49);
                code2 = random.Next(1, 49);
                code = code1 + "加" + code2 + "=?";
                result = (code1 + code2).ToString();
            }
            else
            {
                code1 = random.Next(50, 99);
                code2 = random.Next(1, 49);
                code = code1 + "减" + code2 + "=?";
                result = (code1 - code2).ToString();
            }
            Session["ValidateCode"] = result;
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }



        public ActionResult GetValidateCodekay()
        {
            ValidateCode vCode = new ValidateCode();
            string strcode = Yax.Common.Utils.RandCodestr(5);
            Yax.Common.Cookies.AddCookies(PubStr.MemberCookieName, "Validecodekay", strcode, PubStr.CheckCodeCookieExpireTime);
            byte[] bytes = vCode.CreateCodeKayimg(strcode);
            return File(bytes, @"image");
        }

    }
}
