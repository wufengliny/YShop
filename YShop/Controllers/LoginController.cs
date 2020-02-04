using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using YShop.Filters;
using System.Text;
namespace YShop.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        
        
         /// <summary>
         /// 测试页
         /// </summary>
         /// <returns></returns>
        public ActionResult Index()
        {
            return Content("");
        }
      
        public ActionResult Login()
        {
            return Content("系统繁忙");
        }
        public ActionResult Info()
        {
            return Content("无法连接请求数据");
        }
        public ActionResult NotAccess()
        {
            //Permission Denied
            return Content("权限不足");
        }

  

    }
}
