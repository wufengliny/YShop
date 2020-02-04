using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPay.Filters;

namespace TPay.Controllers
{

    [MemAction]
    public class ShangHuController : Controller
    {
        // GET: ShangHu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserInfo()
        {
            int uid = new Yax.BLL.QuickData.CurrentUserPay().ID;
            Yax.Model.TPay_User model = new Yax.BLL.TPay_User().GetModel(uid);
            ViewBag.Account = model.Account;
            ViewBag.OutMoney = model.OutMoney;
            ViewBag.Money = model.Money;
            ViewBag.IPWhite = model.IPWhite;
            ViewBag.ContactMan = model.ContactMan;
            ViewBag.CalWay = model.CalWay;
            ViewBag.WXAccount = model.WXAccount;
            ViewBag.ZFBAccount = model.ZFBAccount;
            ViewBag.ZFBAccount = model.ZFBAccount;
            ViewBag.CalBankName = model.CalBankName;
            ViewBag.CalBankNo = model.CalBankNo;
            ViewBag.CalMan = model.CalMan;
            return View();
        }
        public ActionResult UserInfoPost()
        {
            int uid = new Yax.BLL.QuickData.CurrentUserPay().ID;
            Yax.Model.TPay_User model = new Yax.BLL.TPay_User().GetModel(uid);
            model.IPWhite= Yax.Common.Utils.GetFormString("IPWhite");
            model.ContactMan= Yax.Common.Utils.GetFormString("ContactMan");
            model.CalWay = Yax.Common.Utils.GetFormString("CalWay");
            model.WXAccount = Yax.Common.Utils.GetFormString("WXAccount");
            model.ZFBAccount = Yax.Common.Utils.GetFormString("ZFBAccount");
            model.CalBankName = Yax.Common.Utils.GetFormString("CalBankName");
            model.CalBankNo = Yax.Common.Utils.GetFormString("CalBankNo");
            model.CalMan = Yax.Common.Utils.GetFormString("CalMan");
            int res= new Yax.BLL.TPay_User().Update(model);
            if(res>0)
            {
                new Yax.BLL.ZY_Log().AddLog(1, "商户:" + model.Account + "修改了商户信息");
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
         
        }


        /// <summary>
        /// 商户密钥
        /// </summary>
        /// <returns></returns>
        public ActionResult ShangPriCode()
        {
            int uid = new Yax.BLL.QuickData.CurrentUserPay().ID;
            Yax.Model.TPay_User model = new Yax.BLL.TPay_User().GetModel(uid);
            if(string.IsNullOrEmpty(model.PayKey))
            {
                string temp = Yax.Common.Utils.RandomDateCard() + Yax.Common.Utils.RandStr(5);
                temp = Yax.Common.SecurityHelper.SHA1(temp)+ Yax.Common.Utils.RandStr(5);
                model.PayKey = temp;
                ViewBag.PayKey = temp;
                new Yax.BLL.TPay_User().Update(model);
            }
            else
            {
                ViewBag.PayKey = model.PayKey;
            }
            return View();
        }
        public ActionResult ShangPriCodePost()
        {
            int uid = new Yax.BLL.QuickData.CurrentUserPay().ID;
            Yax.Model.TPay_User model = new Yax.BLL.TPay_User().GetModel(uid);
            string temp = Yax.Common.Utils.RandomDateCard() + Yax.Common.Utils.RandStr(5);
            temp = Yax.Common.SecurityHelper.SHA1(temp) + Yax.Common.Utils.RandStr(5);
            model.PayKey = temp;
            new Yax.BLL.TPay_User().Update(model);
            new Yax.BLL.ZY_Log().AddLog(1, "商户:" + model.Account + "重置了商户密钥");
            return Content("配置成功");
        }


        public ActionResult UserOrder()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string Account = new Yax.BLL.QuickData.CurrentUserPay().Account;
            string strWhere = " PayState='已支付' and Account='"+ Account + "'";
            string OrderNum = Yax.Common.Utils.GetSafeQueryString("OrderNum");
            string out_trade_no = Yax.Common.Utils.GetSafeQueryString("out_trade_no");
            string Trade_no = Yax.Common.Utils.GetSafeQueryString("Trade_no");
            string str = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime BGTime = Yax.Common.Utils.GetQueryDate("BGTime",str+" 00:00:00");
            DateTime EndTime = Yax.Common.Utils.GetQueryDate("EndTime", str + " 23:59:59");
            strWhere += " and PayTime>'"+ BGTime + "' and PayTime<'"+ EndTime + "'";
            ViewBag.BGTime = BGTime.ToString();
            ViewBag.EndTime = EndTime.ToString();
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

        public ActionResult UserOrderSend()
        {
            int oid = Yax.Common.Utils.GetQueryInt("id");
            Yax.Model.Tpay_Order model = new Yax.BLL.Tpay_Order().GetModel(oid);
            Yax.Model.TPay_User mu = new Yax.BLL.TPay_User().GetModel(model.UID);
            string noticeUrl = model.noticeUrl;
            //ABCDEFGHIJKLMNOPQRSTUVWXYZ 
            string ParaStr = "Account="+mu.Account+"&MarK=" + model.UserMark + "&OrderNum=" + model.OrderNum + "&out_trade_no=" + model.out_trade_no + "&Price=" + model.Price;
            string singstr = Yax.Common.SecurityHelper.MD5(ParaStr + mu.PayKey);
            string respay = Yax.Common.HTTPHelper.GetHTMLUTF8(noticeUrl + "?" + ParaStr + "&Sing=" + singstr);
            if (respay == "success")
            {
                new Yax.BLL.BCommon().ExecuteScalar("update Tpay_Order set ISDeal=1 where out_trade_no='" + model.out_trade_no + "' ");
                return Content("ok");
            }
            else
            {
                return Content("响应失败"+ respay);
            }
           
        }
        public ActionResult UserTiXian()
        {
            int uid = new Yax.BLL.QuickData.CurrentUserPay().ID;
            Yax.Model.TPay_User model = new Yax.BLL.TPay_User().GetModel(uid);
            ViewBag.Money = model.Money;
            ViewBag.Account = model.Account;
            ViewBag.CalWay = model.CalWay;
            return View();
        }


        public ActionResult UserTiXianPost()
        {
            int uid = new Yax.BLL.QuickData.CurrentUserPay().ID;
            Yax.Model.TPay_User model = new Yax.BLL.TPay_User().GetModel(uid);
            decimal Money = Yax.Common.Utils.GetFormDecimal("Money");
            if(Money>0)
            {
                if (Money > model.Money)
                {
                    return Content("余额不足");
                }
                else
                {
                    Yax.Model.Tpay_TiXian mt = new Yax.Model.Tpay_TiXian();
                    if(model.CalWay=="微信")
                    {
                        mt.AccountInfo = "微信：" + model.WXAccount;
                    }
                    else if (model.CalWay == "支付宝")
                    {
                        mt.AccountInfo = "支付宝：" + model.ZFBAccount;
                    }
                    else if (model.CalWay == "银行卡")
                    {
                        mt.AccountInfo = "银行卡名称：" + model.CalBankName+",银行卡号："+model.CalBankNo+",持卡人："+model.CalMan;
                    }
                    mt.AddTime = DateTime.Now;
                    mt.AfterMoney = model.Money - Money;
                    mt.PreMoney = model.Money;
                    mt.State = 1;
                    mt.UAccount = model.Account;
                    mt.UID = model.ID;

                    string str = " INSERT INTO [dbo].[Tpay_TiXian]([UID],[UAccount],[UType],[Money],[PreMoney],[AfterMoney]";
                    str += "  ,[AccountInfo] ,[Enable],[State] ,[ApproID],[ApproName],[Memo],[AddTime])   VALUES";
                    str += " ("+model.ID+",'"+model.Account+"',1,"+Money+","+model.Money+","+mt.AfterMoney+",'"+mt.AccountInfo+"',1,1,0,'','',getdate())";
                    string str2 = " update TPay_User set Money="+mt.AfterMoney+" where id="+model.ID;
                    List<string> list = new List<string>();
                    list.Add(str);
                    list.Add(str2);
                    int res =new Yax.BLL.BCommon().ExecuteSqlTran(list);
                    if (res>0)
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
            string Account = new Yax.BLL.QuickData.CurrentUserPay().Account;
            string strWhere = "  UAccount='" + Account + "' and UType=1";

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


        #region 通道测试
        public ActionResult PayWayTest()
        {
            return View();
        }
        public ActionResult PayWayTestPost()
        {
            string jkUrl = new Yax.BLL.Config().GetModelBy_key("tpaywenjkurl").Value;
            decimal Money = Yax.Common.Utils.GetFormDecimal("Money");
            string PayWay = Yax.Common.Utils.GetSafeFormString("PayWay");
            string Account = new Yax.BLL.QuickData.CurrentUserPay().Account;
            int uid = new Yax.BLL.QuickData.CurrentUserPay().ID;
            Yax.Model.TPay_User model = new Yax.BLL.TPay_User().GetModel(uid);
            string PayKey = model.PayKey;
            if (string.IsNullOrEmpty(PayKey))
            {
                return Content("请先初始化商户密钥");
            }
            string Price = Money.ToString("0.00");
            string OrderNum = Yax.Common.Utils.RandCodestr(10);
            string return_url = jkUrl+ "/ShangHu/TestRedict";
            string notify_url = jkUrl+ "/Payover/TestNotify";
            string Mark = uid.ToString();
            string SighType = "md5";
            string SighMsg = "";
            //
            if (PayWay == "zfb")
            {
                //
                string strTempOrder = " insert into ShopOrder(OrderNO,Statu,PayPrice)values('"+ OrderNum + "',1,"+ Price + ")";
                new Yax.BLL.BCommon().ExecuteScalar(strTempOrder);
                //
                string ParaStr = "Account="+Account+ "&Mark="+Mark+ "&notify_url="+ notify_url;
                ParaStr += "&OrderNum="+OrderNum+ "&PayWay="+PayWay+ "&Price="+Price+ "&return_url="+return_url;
                ParaStr += "&SighType=md5";
                string signSTr = ParaStr + PayKey;
                SighMsg = Yax.Common.SecurityHelper.MD5(signSTr);
                ParaStr = ParaStr + "&SighMsg=" + SighMsg;
                string res = jkUrl + "/HandPay/ZFBPay?"+ ParaStr;
                return Content(res);
            }
            else
            {
                return Content("通道维护中！");
            }
            return View();
        }


        
        public ActionResult TestRedict()
        {
            return Content("支付成功");
        }
        #endregion

        #region 右上角修改密码
        public ActionResult ModPwd()
        {
            return View();
        }

        public ActionResult ModPwdPost()
        {

            int id = new Yax.BLL.QuickData.CurrentUserPay().ID;
            Yax.Model.TPay_User modele = new Yax.Model.TPay_User();
            string pwdold = Request.Form["txtname"];
            string pwd = Request.Form["pwd"];
            if (pwd.Length < 8)
            {
                return Content("为了保护你的账户安全，密码长度至少8个字符");
            }
            if (id > 0)
            {
                modele = new Yax.BLL.TPay_User().GetModel(id);
                if (modele != null)
                {
                    if (modele.Pwd == Yax.Common.SecurityHelper.DifferentMD5(pwdold))
                    {
                        modele.Pwd = Yax.Common.SecurityHelper.DifferentMD5(pwd);
                        string str = " update TPay_User set Pwd='" + modele.Pwd + "'  where id=" + modele.ID;
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



    }
}