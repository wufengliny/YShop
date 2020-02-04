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
    public class TPayController : Controller
    {
        //
        // GET: /Admin/TPay/
        #region 代理列表
        [PowerFiler("tpaydllist031")]
        public ActionResult DLList()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            string Account = Yax.Common.Utils.GetSafeQueryString("Account");
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = " 1=1 ";//State<>'删除'
            if (!string.IsNullOrEmpty(Account))
            {
                strWhere += " and  Account like '%" + Account + "%'";
            }
            Yax.BLL.TPay_Agent bll = new Yax.BLL.TPay_Agent();
            List<Yax.Model.TPay_Agent> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }

        [PowerFiler("tpaydllist031")]
        public ActionResult AddDL()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            if (id > 0)
            {
                Yax.Model.TPay_Agent model = new Yax.BLL.TPay_Agent().GetModel(id);
                ViewBag.Account = model.Account;
                ViewBag.RealName = model.RealName;
                ViewBag.WXFee = model.WXFee;
                ViewBag.ZFBFee = model.ZFBFee;
                ViewBag.Memo = model.Memo;
            }
            else
            {

            }
            return View();
        }
        [PowerFiler("tpaydllist031")]
        public ActionResult AddDLPost()
        {
            int id = Yax.Common.Utils.GetFormInt("id");
            string Account = Yax.Common.Utils.GetSafeFormString("txtAccount");
            string RealName = Yax.Common.Utils.GetSafeFormString("RealName");
            string pwd = Yax.Common.Utils.GetSafeFormString("pwd");
            if (id == 0)
            {
                if (string.IsNullOrEmpty(pwd) || pwd.Length < 8)
                {
                    return Content("密码长度至少8个字符");
                }
                pwd = Yax.Common.SecurityHelper.DifferentMD5(pwd);
            }
            decimal WXFee = Yax.Common.Utils.GetFormDecimal("WXFee");
            decimal ZFBFee = Yax.Common.Utils.GetFormDecimal("ZFBFee");
            if (WXFee == 0 || ZFBFee == 0)
            {
                return Content("代理抽成填写错误");
            }
            string memo = Yax.Common.Utils.GetSafeFormString("Memo");
            if (id == 0)
            {
                Yax.Model.TPay_Agent model = new Yax.BLL.TPay_Agent().GetModelByAccount(Account);
                if (model != null)
                {
                    return Content("代理名称已存在，请换个");
                }
                else
                {
                    string str = "INSERT INTO [dbo].[TPay_Agent]([Account],[RealName],Pwd,State,[Memo],[WXFee],[ZFBFee],[AddTime])VALUES";
                    str += "('" + Account + "','" + RealName + "','" + pwd + "','正常','" + memo + "'," + WXFee + "," + ZFBFee + ",getdate())";
                    new Yax.BLL.BCommon().ExecuteScalar(str);
                    new Yax.BLL.ZY_Log().AddLog(1, "添加代理账户：" + Account);
                }
            }
            else
            {
                Yax.Model.TPay_Agent model = new Yax.BLL.TPay_Agent().GetModel(id);
                if (model != null)
                {
                    if (string.IsNullOrEmpty(pwd))
                    {
                        pwd = model.Pwd;
                    }
                    else
                    {
                        pwd = Yax.Common.SecurityHelper.DifferentMD5(pwd);
                    }
                    string str = " update TPay_Agent set pwd='" + pwd + "',RealName='" + RealName + "',WXFee=" + WXFee + ",ZFBFee=" + ZFBFee + ",Memo='" + memo + "' where id=" + id;
                    new Yax.BLL.BCommon().ExecuteScalar(str);
                    new Yax.BLL.ZY_Log().AddLog(1, "修改代理账户：" + Account);
                }
            }
            return Content("操作成功");
        }

        [PowerFiler("tpaydllist031")]
        public ActionResult SetDLState()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            Yax.Model.TPay_Agent model = new Yax.BLL.TPay_Agent().GetModel(id);
            ViewBag.Account = model.Account;
            ViewBag.State = model.State;
            return View();
        }

        [PowerFiler("tpaydllist031")]
        public ActionResult SetDLStatePost()
        {
            int id = Yax.Common.Utils.GetFormInt("id");
            string state = Yax.Common.Utils.GetSafeFormString("State");
            string str = " update TPay_Agent set State='" + state + "' where id=" + id;
            new Yax.BLL.BCommon().ExecuteScalar(str);
            return Content("操作成功");
        }
        #endregion

        #region 商户列表
        [PowerFiler("tpayuserlist032")]
        public ActionResult UserList()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            string Account = Yax.Common.Utils.GetSafeQueryString("Account");
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = " 1=1 ";//State<>'删除'
            if (!string.IsNullOrEmpty(Account))
            {
                strWhere += " and  Account like '%" + Account + "%'";
            }
            Yax.BLL.TPay_User bll = new Yax.BLL.TPay_User();
            List<Yax.Model.TPay_User> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }

        [PowerFiler("tpayuserlist032")]
        public ActionResult AddUser()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            List<Yax.Model.TPay_Agent> list = new Yax.BLL.TPay_Agent().GetList(-1, "*", "State='正常'", "ID Desc");
            ViewBag.listAgent = list;
            if (id > 0)
            {
                Yax.Model.TPay_User model = new Yax.BLL.TPay_User().GetModel(id);
                ViewBag.Account = model.Account;
                ViewBag.WXFee = model.WXFee;
                ViewBag.ZFBFee = model.ZFBFee;
                ViewBag.Memo = model.Memo;
                ViewBag.RecommondID = model.RecommondID;
            }
            else
            {

            }
            return View();
        }

        [PowerFiler("tpayuserlist032")]
        public ActionResult AddUserPost()
        {
            int id = Yax.Common.Utils.GetFormInt("id");
            string Account = Yax.Common.Utils.GetSafeFormString("txtAccount");
            string pwd = Yax.Common.Utils.GetSafeFormString("pwd");
            if (id == 0)
            {
                if (string.IsNullOrEmpty(pwd) || pwd.Length < 8)
                {
                    return Content("密码长度至少8个字符");
                }
                pwd = Yax.Common.SecurityHelper.DifferentMD5(pwd);
            }
            decimal WXFee = Yax.Common.Utils.GetFormDecimal("WXFee");
            decimal ZFBFee = Yax.Common.Utils.GetFormDecimal("ZFBFee");
            if (WXFee == 0 || ZFBFee == 0)
            {
                return Content("代理抽成填写错误");
            }
            string memo = Yax.Common.Utils.GetSafeFormString("Memo");
            int RecommondID = Yax.Common.Utils.GetFormInt("RecommondID");
            if (id == 0)
            {
                Yax.Model.TPay_User model = new Yax.BLL.TPay_User().GetModel_ByAccount(Account);
                if (model != null)
                {
                    return Content("商户号已存在，请换个");
                }
                else
                {
                    string str = "INSERT INTO [dbo].[TPay_User]([Account],Pwd,State,[Memo],[WXFee],[ZFBFee],[AddTime],RecommondID)VALUES";
                    str += "('" + Account + "','" + pwd + "',1,'" + memo + "'," + WXFee + "," + ZFBFee + ",getdate()," + RecommondID + ")";
                    new Yax.BLL.BCommon().ExecuteScalar(str);
                    new Yax.BLL.ZY_Log().AddLog(1, "添加商户号：" + Account);
                }
            }
            else
            {
                Yax.Model.TPay_Agent model = new Yax.BLL.TPay_Agent().GetModel(id);
                if (model != null)
                {
                    if (string.IsNullOrEmpty(pwd))
                    {
                        pwd = model.Pwd;
                    }
                    else
                    {
                        pwd = Yax.Common.SecurityHelper.DifferentMD5(pwd);
                    }
                    string str = " update TPay_User set pwd='" + pwd + "',WXFee=" + WXFee + ",ZFBFee=" + ZFBFee + ",Memo='" + memo + "',RecommondID=" + RecommondID + " where id=" + id;
                    new Yax.BLL.BCommon().ExecuteScalar(str);
                    new Yax.BLL.ZY_Log().AddLog(1, "修改商户号：" + Account);
                }
            }
            return Content("操作成功");
        }

        [PowerFiler("tpayuserlist032")]
        public ActionResult SetUserState()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            Yax.Model.TPay_User model = new Yax.BLL.TPay_User().GetModel(id);
            ViewBag.Account = model.Account;
            ViewBag.State = model.State;
            return View();
        }
        [PowerFiler("tpayuserlist032")]
        public ActionResult SetUserStatePost()
        {
            int id = Yax.Common.Utils.GetFormInt("id");
            int state = Yax.Common.Utils.GetFormInt("State");
            string str = " update TPay_User set State=" + state + " where id=" + id;
            new Yax.BLL.BCommon().ExecuteScalar(str);
            return Content("操作成功");
        }


        public ActionResult UserOrder()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = " PayState='已支付' ";
            string Account= Yax.Common.Utils.GetSafeQueryString("Account");
            string OrderNum = Yax.Common.Utils.GetSafeQueryString("OrderNum");
            string out_trade_no = Yax.Common.Utils.GetSafeQueryString("out_trade_no");
            string Trade_no = Yax.Common.Utils.GetSafeQueryString("Trade_no");
            string str = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime BGTime = Yax.Common.Utils.GetQueryDate("BGTime", str + " 00:00:00");
            DateTime EndTime = Yax.Common.Utils.GetQueryDate("EndTime", str + " 23:59:59");
            strWhere += " and PayTime>'" + BGTime + "' and PayTime<'" + EndTime + "'";
            ViewBag.BGTime = BGTime.ToString();
            ViewBag.EndTime = EndTime.ToString();
            if (!string.IsNullOrEmpty(Account))
            {
                strWhere += " and Account='" + Account + "'";
            }
            if (!string.IsNullOrEmpty(OrderNum))
            {
                strWhere += " and OrderNum='" + OrderNum + "'";
            }
            if (!string.IsNullOrEmpty(out_trade_no))
            {
                strWhere += " and out_trade_no='" + out_trade_no + "'";
            }
            if (!string.IsNullOrEmpty(Trade_no))
            {
                strWhere += " and Trade_no='" + Trade_no + "'";
            }
            new Yax.BLL.ZY_Log().AddLog(2, strWhere);
            Yax.BLL.Tpay_Order bll = new Yax.BLL.Tpay_Order();
            List<Yax.Model.Tpay_Order> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            ViewBag.list = list;
            return View();
        }
        #endregion

        #region 提现管理
        [PowerFiler("tpaytixian036")]
        public ActionResult UserTiXian()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "  UType=1 ";
            string Account = Yax.Common.Utils.GetSafeQueryString("Account");
            int State = Yax.Common.Utils.GetQueryInt("State");
            if (!string.IsNullOrEmpty(Account))
            {
                strWhere += " and  UAccount='" + Account + "'";
            }
            if (State>0)
            {
                strWhere += " and  State=" + State + "";
            }
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
        [PowerFiler("tpaytixian036")]
        public ActionResult UserTiXianState()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            Yax.Model.Tpay_TiXian model = new Yax.BLL.Tpay_TiXian().GetModel(id);
            ViewBag.UAccount = model.UAccount;
            ViewBag.AccountInfo = model.AccountInfo;
            ViewBag.Money = model.Money;
            ViewBag.State = model.State;
            ViewBag.Memo = model.Memo;
            return View();
        }
        public ActionResult UserTiXianStatePost()
        {
            int AdminID = new Yax.BLL.CurrentUser().Id;
            string AdminName = new Yax.BLL.CurrentUser().Name;
            int State = Yax.Common.Utils.GetFormInt("State");
            string memo= Yax.Common.Utils.GetFormString("Memo");
            int id = Yax.Common.Utils.GetFormInt("id");
            Yax.Model.Tpay_TiXian model = new Yax.BLL.Tpay_TiXian().GetModel(id);
            if (State == 1)
            {
                return Content("ok");
            }
            else if (State == 2)
            {
                //修改状态 把钱返还到商户上余额上 
                string str = " update Tpay_TiXian set State="+State+ ",memo='"+ memo + "',ApproID=" + AdminID + ",ApproName='"+AdminName+"'  where id=" + id;
                string str2 = " update TPay_User set Money+="+model.Money+" where id="+model.UID;
                List<string> list = new List<string>();
                list.Add(str);
                list.Add(str2);
                new Yax.BLL.BCommon().ExecuteSqlTran(list);
                return Content("ok");
            }
            else if (State == 3)
            {
                string str = " update Tpay_TiXian set State=" + State + ",memo='" + memo + "',ApproID=" + AdminID + ",ApproName='"+AdminName+"'  where id=" + id;
                new Yax.BLL.BCommon().ExecuteScalar(str);
                return Content("ok");
            }
            return Content("状态错误");
        }

        [PowerFiler("tpaytixian037")]
        public ActionResult AgentTiXian()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "  UType=2 ";
            string Account = Yax.Common.Utils.GetSafeQueryString("Account");
            int State = Yax.Common.Utils.GetQueryInt("State");
            if (!string.IsNullOrEmpty(Account))
            {
                strWhere += " and  UAccount='" + Account + "'";
            }
            if (State > 0)
            {
                strWhere += " and  State=" + State + "";
            }
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

        [PowerFiler("tpaytixian037")]
        public ActionResult AgentiXianState()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            Yax.Model.Tpay_TiXian model = new Yax.BLL.Tpay_TiXian().GetModel(id);
            ViewBag.UAccount = model.UAccount;
            ViewBag.AccountInfo = model.AccountInfo;
            ViewBag.Money = model.Money;
            ViewBag.State = model.State;
            ViewBag.Memo = model.Memo;
            return View();
        }
        [PowerFiler("tpaytixian037")]
        public ActionResult AgentiXianStatePost()
        {
            int AdminID = new Yax.BLL.CurrentUser().Id;
            string AdminName = new Yax.BLL.CurrentUser().Name;
            int State = Yax.Common.Utils.GetFormInt("State");
            string memo = Yax.Common.Utils.GetFormString("Memo");
            int id = Yax.Common.Utils.GetFormInt("id");
            Yax.Model.Tpay_TiXian model = new Yax.BLL.Tpay_TiXian().GetModel(id);
            if (State == 1)
            {
                return Content("ok");
            }
            else if (State == 2)
            {
                //修改状态 把钱返还到商户上余额上 
                string str = " update Tpay_TiXian set State=" + State + ",memo='" + memo + "',ApproID="+ AdminID + ",ApproName='"+AdminName+"'  where id=" + id;
                string str2 = " update TPay_Agent set Money+=" + model.Money + " where id=" + model.UID;
                List<string> list = new List<string>();
                list.Add(str);
                list.Add(str2);
                new Yax.BLL.BCommon().ExecuteSqlTran(list);
                return Content("ok");
            }
            else if (State == 3)
            {
                string str = " update Tpay_TiXian set State=" + State + ",memo='" + memo + "' ,ApproID=" + AdminID + ",ApproName='" + AdminName + "'   where id=" + id;
                new Yax.BLL.BCommon().ExecuteScalar(str);
                return Content("ok");
            }
            return Content("状态错误");
        }
        #endregion


        #region 支付接口
        [PowerFiler("tpayzfb033")]
        public ActionResult ZFBList()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            string Account = Yax.Common.Utils.GetSafeQueryString("Account");
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = " 1=1 ";
            Yax.BLL.TPay_ZFBConfig bll = new Yax.BLL.TPay_ZFBConfig();
            List<Yax.Model.TPay_ZFBConfig> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }

        [PowerFiler("tpayzfb033")]
        public ActionResult AddZFB()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            if (id > 0)
            {
                Yax.Model.TPay_ZFBConfig model = new Yax.BLL.TPay_ZFBConfig().GetModel(id);
                ViewBag.Name = model.Name;
                ViewBag.APPID = model.APPID;
                ViewBag.PrivateKeyPC = model.PrivateKeyPC;
                ViewBag.PublicKeyPC = model.PublicKeyPC;
                ViewBag.MinMoney = model.MinMoney;
                ViewBag.Memo = model.Memo;
                ViewBag.Enable = model.Enable;
            }
            else
            {

            }
            return View();
        }
        [PowerFiler("tpayzfb033")]
        public ActionResult AddZFBPost()
        {
            string Name = Yax.Common.Utils.GetSafeFormString("Name");
            string APPID = Yax.Common.Utils.GetSafeFormString("APPID");
            string PrivateKeyPC = Yax.Common.Utils.GetFormString("PrivateKeyPC");
            string PublicKeyPC = Yax.Common.Utils.GetFormString("PublicKeyPC");
            int MinMoney = Yax.Common.Utils.GetFormInt("MinMoney");
            string Memo = Yax.Common.Utils.GetSafeFormString("Memo");
            int Enable = Yax.Common.Utils.GetFormInt("Enable");
            int id = Yax.Common.Utils.GetFormInt("id");
            if (id == 0)
            {
                Yax.Model.TPay_ZFBConfig model = new Yax.Model.TPay_ZFBConfig();
                model.AddTime = DateTime.Now;
                model.APPID = APPID;
                model.Enable = Enable;
                model.Memo = Memo;
                model.MinMoney = MinMoney;
                model.Name = Name;
                model.Partner = "";
                model.PrivateKeyPC = PrivateKeyPC;
                model.PrivateKeyWap = "";
                model.PublicKeyPC = PublicKeyPC;
                model.PublicKeyWap = "";
                new Yax.BLL.TPay_ZFBConfig().Add(model);
                new Yax.BLL.ZY_Log().AddLog(1, "添加支付宝接口账户" + Name + "APPID:" + APPID);
            }
            else
            {
                Yax.Model.TPay_ZFBConfig model = new Yax.BLL.TPay_ZFBConfig().GetModel(id);
                model.APPID = APPID;
                model.Memo = Memo;
                model.MinMoney = MinMoney;
                model.Name = Name;
                model.PrivateKeyPC = PrivateKeyPC;
                model.PublicKeyPC = PublicKeyPC;
                model.Enable = Enable;
                new Yax.BLL.TPay_ZFBConfig().Update(model);
                new Yax.BLL.ZY_Log().AddLog(1, "修改支付宝接口账户ID" + model.ID + "APPID:" + APPID);
            }
            return Content("操作成功");
        }


        [PowerFiler("tpaywx033")]
        public ActionResult WXList()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            string Account = Yax.Common.Utils.GetSafeQueryString("Account");
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = " 1=1 ";
            Yax.BLL.TPay_WXConfig bll = new Yax.BLL.TPay_WXConfig();
            List<Yax.Model.TPay_WXConfig> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }
        [PowerFiler("tpaywx033")]
        public ActionResult WXAdd()
        {
            int id = Yax.Common.Utils.GetQueryInt("id");
            if (id > 0)
            {
                Yax.Model.TPay_WXConfig model = new Yax.BLL.TPay_WXConfig().GetModel(id);
                ViewBag.Name = model.Name;
                ViewBag.apiid = model.apiid;
                ViewBag.PayMCHID = model.PayMCHID;
                ViewBag.Secret = model.Secret;
                ViewBag.PayKey = model.PayKey;
                ViewBag.MinMoney = model.MinMoney;
                ViewBag.Memo = model.Memo;
                ViewBag.Enable = model.Enable;
            }
            else
            {

            }
            return View();
        }

        [PowerFiler("tpaywx033")]
        public ActionResult WXAddPost()
        {
            string Name = Yax.Common.Utils.GetSafeFormString("Name");
            string apiid = Yax.Common.Utils.GetSafeFormString("apiid");
            string PayMCHID = Yax.Common.Utils.GetFormString("PayMCHID");
            string Secret = Yax.Common.Utils.GetFormString("Secret");
            string PayKey = Yax.Common.Utils.GetFormString("PayKey");
            int MinMoney = Yax.Common.Utils.GetFormInt("MinMoney");
            string Memo = Yax.Common.Utils.GetSafeFormString("Memo");
            int Enable = Yax.Common.Utils.GetFormInt("Enable");
            int id = Yax.Common.Utils.GetFormInt("id");
            if (id == 0)
            {
                Yax.Model.TPay_WXConfig model = new Yax.Model.TPay_WXConfig();
                model.AddTime = DateTime.Now;
                model.apiid = apiid;
                model.Enable = Enable;
                model.Memo = Memo;
                model.MinMoney = MinMoney;
                model.Name = Name;
                model.PayMCHID = PayMCHID;
                model.Secret = Secret;
                model.PayKey = PayKey;
                model.NOTIFY_URL = "";
                model.SiteUrl = "";
                model.SSLCERT_PASSWORD = "";
                model.SSLCERT_PATH = "";
                model.Token = "";
                new Yax.BLL.TPay_WXConfig().Add(model);
                new Yax.BLL.ZY_Log().AddLog(1, "添加微信接口账户" + Name + "apiid:" + apiid);
            }
            else
            {
                Yax.Model.TPay_WXConfig model = new Yax.BLL.TPay_WXConfig().GetModel(id);
                model.apiid = apiid;
                model.Memo = Memo;
                model.MinMoney = MinMoney;
                model.Name = Name;
                model.PayMCHID = PayMCHID;
                model.Secret = Secret;
                model.Enable = Enable;
                model.PayKey = PayKey;
                new Yax.BLL.TPay_WXConfig().Update(model);
                new Yax.BLL.ZY_Log().AddLog(1, "修改微信接口账户ID" + model.ID + "apiid:" + apiid);
            }
            return Content("操作成功");
        }
        #endregion

    }
}
