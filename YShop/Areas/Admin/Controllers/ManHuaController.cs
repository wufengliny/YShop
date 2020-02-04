using Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Data;
namespace YShop.Areas.Admin.Controllers
{
    [YUAction]
    public class ManHuaController : Controller
    {
        //
        // GET: /Admin/ManHua/
        [PowerFiler("Mtixian11")]
        public ActionResult  TiXian()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = " 1=1 ";
            string Account = Yax.Common.Utils.GetSafeQueryString("Account").Trim();
            int State = Yax.Common.Utils.GetQueryInt("State");
            if (!string.IsNullOrEmpty(Account))
            {
                strWhere += " and RealName='"+Account+"'";
            }
            if(State>0)
            {
                strWhere += " and State="+State;
            }
            Yax.BLL.TiXian bll = new Yax.BLL.TiXian();
            List<Yax.Model.TiXian> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            ViewBag.list = list;
            return View();
        }

        [PowerFiler("Mtixian11")]
        public ActionResult TixianShenHe()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            Yax.Model.TiXian model = new Yax.BLL.TiXian().GetModel(id);
            ViewBag.RealName = model.RealName;
            ViewBag.BankNO = model.BankNO;
            ViewBag.Money = model.Money;
            ViewBag.State = model.State;
            ViewBag.Memo = model.Memo;
            return View();
        }
        [PowerFiler("Mtixian11")]
        public ActionResult TixianShenHePost()
        {
            int id = Yax.Common.Utils.GetFormInt("id");
            int State = Yax.Common.Utils.GetFormInt("State");
            string Memo = Yax.Common.Utils.GetSafeFormString("Memo");
            int adminID = new Yax.BLL.CurrentUser().Id;
            string adminName = new Yax.BLL.CurrentUser().Name;
            if (State==1)
            {
                return Content("请选择审核状态");
            }
            Yax.Model.TiXian model = new Yax.BLL.TiXian().GetModel(id);
            if(model.State!=1)
            {
                return Content("此提现申请已处理过");
            }
            Yax.Model.Y_User muser = new Yax.BLL.Y_User().GetModel(model.UserID);
            if (State==2)
            {
                List<string> listSQL = new List<string>();
                listSQL.Add(" update Y_User set JIFen=" + (muser.JIFen + (model.Money*10)) + " where id=" + model.UserID);
                string strSQL_JIfen = "INSERT INTO [dbo].[JiFenDetail]([PreJiFen],[Jifen],[AfterJIfen],[Memo],[AddTime],[UID],[Account])";
                strSQL_JIfen += " VALUES(" + muser.JIFen + "," + (model.Money * 10) + "," + (muser.JIFen + (model.Money * 10)) + ",'提现审核失败返还',getdate()," + model.UserID + ",'" + muser.Account + "')";
                listSQL.Add(strSQL_JIfen);
                listSQL.Add(" update TiXian set State=2, ApproveID="+ adminID + ",ApproveTime=getdate(),ApproveName='"+adminName+"',Memo='"+Memo+"' where id="+id);
                new Yax.BLL.BCommon().ExecuteSqlTran(listSQL);
                return Content("ok");
            }
            if(State==3)
            {
                string str2 = " update TiXian set State=3, ApproveID=" + adminID + ",ApproveTime=getdate(),ApproveName='" + adminName + "',Memo='" + Memo + "' where id=" + id;
                new Yax.BLL.BCommon().ExecuteScalar(str2);
                return Content("ok");
            }
            else
            {
                return Content("false");
            }
        }
    }
}
