using Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace YShop.Areas.Admin.Controllers
{
    [YUAction]
    public class ChatController : Controller
    {
        //
        // GET: /Admin/Chat/

        [PowerFiler("Chat20")]
        public ActionResult Index()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1";
            Yax.BLL.Chat_msg bll = new Yax.BLL.Chat_msg();
            List<Yax.Model.Chat_msg> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }
        [PowerFiler("Chat20")]
        public ActionResult ChatmsgAdd()
        {
            return View();
        }
        [PowerFiler("Chat20")]
        public ActionResult ChatmsgAddPost()
        {
            Yax.Model.Chat_msg model = new Yax.Model.Chat_msg();
            model.AddTime = DateTime.Now;
            model.FromID = new Yax.BLL.CurrentUser().Id;
            model.msg = Request.Form["msg"];
            model.Path = Request.Form["Path"];
            int res = new Yax.BLL.Chat_msg().Add(model);
            if (res > 0)
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }
        [PowerFiler("Chat20")]
        public ActionResult ChatmsgDetail(int id)
        {
            Yax.Model.Chat_msg model = new Yax.BLL.Chat_msg().GetModel(id);
            if(model!=null)
            {
                ViewBag.AddTime = model.AddTime;
                ViewBag.msg = model.msg;
                ViewBag.Path = model.Path;
            }
            return View();
        }
        [PowerFiler("Chat20")]
        public ActionResult DelChatMsg(int id)
        {
            Yax.Model.Chat_msg model = new Yax.BLL.Chat_msg().GetModel(id);
            if(model!=null&&!string.IsNullOrEmpty(model.Path))
            {
                Yax.Common.FileUtils.DeleteFile(Server.MapPath(model.Path));
            }
            int res = new Yax.BLL.Chat_msg().Delete(id);
            if (res > 0)
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }

    }
}
