using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPay.Filters;

namespace TPay.Controllers
{
    [AgentAction]
    public class AgentController : Controller
    {
        // GET: Agent
        public ActionResult Index()
        {
            int uid = new Yax.BLL.QuickData.CurrentUserPayAgent().ID;
            Yax.Model.TPay_Agent model = new Yax.BLL.TPay_Agent().GetModel(uid);
            ViewBag.Account = model.Account;
            ViewBag.OutMoney = model.OutMoney;
            ViewBag.Money = model.Money;
            ViewBag.CalWay = model.CalWay;
            ViewBag.WXAccount = model.WXAccount;
            ViewBag.ZFBAccount = model.ZFBAccount;
            ViewBag.ZFBAccount = model.ZFBAccount;
            ViewBag.CalBankName = model.CalBankName;
            ViewBag.CalBankNo = model.CalBankNo;
            ViewBag.CalMan = model.CalMan;
            return View();
        }

        public ActionResult AgentInfoPost()
        {
            int uid = new Yax.BLL.QuickData.CurrentUserPayAgent().ID;
            Yax.Model.TPay_Agent model = new Yax.BLL.TPay_Agent().GetModel(uid);
            model.CalWay = Yax.Common.Utils.GetFormString("CalWay");
            model.WXAccount = Yax.Common.Utils.GetFormString("WXAccount");
            model.ZFBAccount = Yax.Common.Utils.GetFormString("ZFBAccount");
            model.CalBankName = Yax.Common.Utils.GetFormString("CalBankName");
            model.CalBankNo = Yax.Common.Utils.GetFormString("CalBankNo");
            model.CalMan = Yax.Common.Utils.GetFormString("CalMan");
            int res = new Yax.BLL.TPay_Agent().Update(model);
            if (res > 0)
            {
                new Yax.BLL.ZY_Log().AddLog(1, "代理:" + model.Account + "修改了代理信息");
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
        }



        public ActionResult MyKeHu()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            int AgentID = new Yax.BLL.QuickData.CurrentUserPayAgent().ID;
            string AgentAccount= new Yax.BLL.QuickData.CurrentUserPayAgent().Account;
            ViewBag.AgentAccount = AgentAccount;
            string strWhere = " RecommondID="+ AgentID + " ";

            Yax.BLL.TPay_User bll = new Yax.BLL.TPay_User();
            List<Yax.Model.TPay_User> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            ViewBag.list = list;
            return View();
        }


        public ActionResult AgentTiXian()
        {
            int uid = new Yax.BLL.QuickData.CurrentUserPayAgent().ID;
            Yax.Model.TPay_Agent model = new Yax.BLL.TPay_Agent().GetModel(uid);
            ViewBag.Money = model.Money;
            ViewBag.Account = model.Account;
            ViewBag.CalWay = model.CalWay;
            return View();
        }
        public ActionResult AgentTiXianPost()
        {
            int uid = new Yax.BLL.QuickData.CurrentUserPayAgent().ID;
            Yax.Model.TPay_Agent model = new Yax.BLL.TPay_Agent().GetModel(uid);
            decimal Money = Yax.Common.Utils.GetFormDecimal("Money");
            if (Money > 0)
            {
                if (Money > model.Money)
                {
                    return Content("余额不足");
                }
                else
                {
                    Yax.Model.Tpay_TiXian mt = new Yax.Model.Tpay_TiXian();
                    if (model.CalWay == "微信")
                    {
                        mt.AccountInfo = "微信：" + model.WXAccount;
                    }
                    else if (model.CalWay == "支付宝")
                    {
                        mt.AccountInfo = "支付宝：" + model.ZFBAccount;
                    }
                    else if (model.CalWay == "银行卡")
                    {
                        mt.AccountInfo = "银行卡名称：" + model.CalBankName + ",银行卡号：" + model.CalBankNo + ",持卡人：" + model.CalMan;
                    }
                    mt.AddTime = DateTime.Now;
                    mt.AfterMoney = model.Money - Money;
                    mt.PreMoney = model.Money;
                    mt.State = 1;
                    mt.UAccount = model.Account;
                    mt.UID = model.ID;
                    
                    string str = " INSERT INTO [dbo].[Tpay_TiXian]([UID],[UAccount],[UType],[Money],[PreMoney],[AfterMoney]";
                    str += "  ,[AccountInfo] ,[Enable],[State] ,[ApproID],[ApproName],[Memo],[AddTime])   VALUES";
                    str += " (" + model.ID + ",'" + model.Account + "',2," + Money + "," + model.Money + "," + mt.AfterMoney + ",'" + mt.AccountInfo + "',1,1,0,'','',getdate())";
                    string str2 = " update TPay_Agent set Money=" + mt.AfterMoney + " where id=" + model.ID;
                    List<string> list = new List<string>();
                    list.Add(str);
                    list.Add(str2);
                    int res = new Yax.BLL.BCommon().ExecuteSqlTran(list);
                    if (res > 0)
                    {
                        return Content("提现成功,等待审核！");
                    }
                    else
                    {
                        return Content("网络繁忙0010");
                    }
                }
            }
            else
            {
                return Content("提现金额错误");
            }
            return Content("");
        }

        public ActionResult TiXianList()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string Account = new Yax.BLL.QuickData.CurrentUserPayAgent().Account;
            string strWhere = "  UAccount='" + Account + "' and UType=2";


            Yax.BLL.Tpay_TiXian bll = new Yax.BLL.Tpay_TiXian();
            List<Yax.Model.Tpay_TiXian> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            ViewBag.list = list;
            return View();
        }

        #region 右上角修改密码
        public ActionResult ModPwd()
        {
            return View();
        }
        public ActionResult ModPwdPost()
        {

            int id = new Yax.BLL.QuickData.CurrentUserPayAgent().ID;
            Yax.Model.TPay_Agent modele = new Yax.Model.TPay_Agent();
            string pwdold = Request.Form["txtname"];
            string pwd = Request.Form["pwd"];
            if (pwd.Length < 8)
            {
                return Content("为了保护你的账户安全，密码长度至少8个字符");
            }
            if (id > 0)
            {
                modele = new Yax.BLL.TPay_Agent().GetModel(id);
                if (modele != null)
                {
                    if (modele.Pwd == Yax.Common.SecurityHelper.DifferentMD5(pwdold))
                    {
                        modele.Pwd = Yax.Common.SecurityHelper.DifferentMD5(pwd);
                        string str = " update TPay_Agent set Pwd='" + modele.Pwd + "'  where id=" + modele.ID;
                        object res = new Yax.BLL.BCommon().ExecuteScalar(str);
                        return Content("修改成功");
                    }
                    else
                    {
                        return Content("原密码输入错误");
                    }

                }
            }
            else
            {
                return Content("修改失败");
            }
            return Content("修改失败");
        }
        #endregion


        //
    }
}