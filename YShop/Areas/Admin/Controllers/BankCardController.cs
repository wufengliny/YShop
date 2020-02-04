using Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YShop.Areas.Admin.Controllers
{
    [YUAction]
    public class BankCardController : Controller
    {
        //
        // GET: /Admin/BankCard/

        [PowerFiler("shoukuanzhanghao5")]
        public ActionResult Index()
        {
            Yax.Model.CompanyBankCard model = new Yax.Model.CompanyBankCard();
            model = new Yax.BLL.CompanyBankCard().GetModel(1);
            if(model!=null)
            {
                ViewBag.CardOwner = model.CardOwner;
                ViewBag.CardNO = model.CardNO;
                ViewBag.BankName = model.BankName;
            }
            return View();
        }
        [PowerFiler("shoukuanzhanghao5")]
        public ActionResult BankCardPost(string BankName, string CardNO, string CardOwner)
        {
            int res = 0;
            Yax.Model.CompanyBankCard model = new Yax.Model.CompanyBankCard();
            model = new Yax.BLL.CompanyBankCard().GetModel(1);
            if (model != null)
            {
                //mod
                model.BankName = BankName;
                model.CardNO = CardNO;
                model.CardOwner = CardOwner;
               res=  new Yax.BLL.CompanyBankCard().Update(model);
            }
            else
            {
                model = new Yax.Model.CompanyBankCard();
                //add
                model.BankName = BankName;
                model.CardNO = CardNO;
                model.CardOwner = CardOwner;
                model.AddTime = DateTime.Now;
                model.Enable = 1;
                model.Memo = "";
                res = new Yax.BLL.CompanyBankCard().Add(model);
            }
            if(res>0)
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
            return View();
        }

        [PowerFiler("tixian13")]
        public ActionResult TiXian()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1 and Enable=1";
            Yax.BLL.TiXian bll = new Yax.BLL.TiXian();
            List<Yax.Model.TiXian> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }

        [PowerFiler("tixian13")]
        public ActionResult DelTiXian()
        {
            int id = Yax.Common.Utils.GetQueryInt("id", 0);
            Yax.Model.TiXian y = new Yax.Model.TiXian();
            y.Enable = 0;
            y.ID = id;
            int res = new Yax.BLL.TiXian().UpdateEnable(y);
            try
            {
                if (res > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "删除提现订单ID(" + id + ")成功");
                    return Content("删除成功");
                }
                else
                {
                    return Content("删除失败");
                }
            }
            catch
            {
                return Content("操作异常");
            }
        }


        [PowerFiler("Jiekuan12")]
        public ActionResult JieKuan()
        {
            int pageIndex = Yax.Common.Utils.GetQueryInt("pagenow", 1);
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1 and Enable=1";
            string phone = Yax.Common.Utils.GetSafeQueryString("phone"); 
            if (!string.IsNullOrEmpty(phone))
            {
                strWhere += " and  UserName like '%" + phone + "%'";
            }
            Yax.BLL.JieKuan bll = new Yax.BLL.JieKuan();
            List<Yax.Model.JieKuan> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            ViewBag.TotalPage = TotalPage;
            ViewBag.TotalCount = TotalCount;
            ViewBag.pageIndex = pageIndex;
            string pageWhere = Request.Url.Query;
            ViewBag.PageStr = Yax.Common.PageHelper.GetPage(pageIndex, pageSize, TotalCount, pageWhere);
            return View(list);
        }
        [PowerFiler("Jiekuan12")]
        public ActionResult ModJieKuanMoney(int id)
        {
            Yax.Model.JieKuan model = new Yax.Model.JieKuan();
            model = new Yax.BLL.JieKuan().GetModel(id);
            if (model != null && model.Enable > 0)
            {
                ViewBag.RealName = model.RealName;
                ViewBag.OrderNO = model.OrderNO;
                ViewBag.Money = model.Money;
                ViewBag.JieTime = model.JieTime.ToString();

                string months = new Yax.BLL.Config().GetModelBy_key("yunxuxuanzheyuefen").Value;
                ViewBag.months = months;
            }
            return View();
        }

        [PowerFiler("Jiekuan12")]
        public ActionResult ModJieKuanMoneyPost(Yax.Model.JieKuan model)
        {
            try
            {
                string months = ViewBag.yunxuxuanzheyuefen = new Yax.BLL.Config().GetModelBy_key("yunxuxuanzheyuefen").Value;
                string feilv = ViewBag.fuwufeilv = new Yax.BLL.Config().GetModelBy_key("fuwufeilv").Value;
                double money = double.Parse(model.Money.ToString());
                if (money < 1000)
                {
                    return Content("借款金额不能低于1千");
                }
                double month_fee;
                double month_pay;
                double fee;
                fee = Yax.Common.JieKuanHelper.JD.CalFee(months, feilv, model.JieTime, money, out month_fee, out month_pay);
                model.MonthFee = decimal.Parse(month_fee.ToString());
                model.FeePercent = fee.ToString();

                int res = new Yax.BLL.JieKuan().Update_money(model);
                if (res > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "修改借款订单ID(" + model.ID + ")金额成功");
                    return Content("修改成功");
                }
                else
                {
                    return Content("修改失败");
                }
            }
            catch
            {
                return Content("网络异常994");
            }

            return Content("");
        }

        [PowerFiler("Jiekuan12")]
        public ActionResult ModJieKuanState(int id)
        {
            if (id > 0)
            {
                Yax.Model.JieKuan model = new Yax.BLL.JieKuan().GetModel(id);
                if (model != null)
                {
                    ViewBag.RealName = model.RealName;
                    ViewBag.OrderNO = model.OrderNO;
                    ViewBag.State = model.State;

                    ViewBag.st3 = new Yax.BLL.Config().GetModelBy_key("shenhetongguo").Value;
                    ViewBag.st7 = new Yax.BLL.Config().GetModelBy_key("daikuanzijindongjie").Value;
                    ViewBag.st8 = new Yax.BLL.Config().GetModelBy_key("shouqubaoxianfei").Value;
                    ViewBag.st9 = new Yax.BLL.Config().GetModelBy_key("yufushouqifeiyong").Value;
                    ViewBag.st10 = new Yax.BLL.Config().GetModelBy_key("vipjiajidaozhang").Value;
                }
            }
            return View();
        }

        [PowerFiler("Jiekuan12")]
        public ActionResult ModJieKuanStatePost()
        {
            try
            {
                int state = Yax.Common.Utils.GetFormInt("State");
                int id = Yax.Common.Utils.GetFormInt("id");
                string memo = Request.Form["memo"];
                string pwd = Request.Form["TiKuanPWD"];
                string msg = Request.Form["msg"];
                if (state < 1)
                {
                    return Content("请选择状态");
                }
                int res = 0;
                string result = "";
                if (state == 1 || state == 2 || state == 4 || state == 5 || state == 6 || state == 11 || state == 12)
                {
                    res = new Yax.BLL.JieKuan().Update_state(state, id, memo);
                }
                Yax.Model.JieKuan Jmodel = new Yax.BLL.JieKuan().GetModel(id);
                if (state == 3)
                {
                    //修改订单密码和 备注
                    res = new Yax.BLL.JieKuan().Update_state_pwd_memo(state, id, memo, pwd);
                    new Yax.BLL.BCommon().UpdateOneFieldAdd("Y_User", "money", Jmodel.Money.ToString(), "ID=" + Jmodel.UserID);
                    msg = msg.Replace("{name}", Jmodel.RealName);
                    if (!string.IsNullOrEmpty(msg))
                    {
                        result = SendPhoneMsg(msg, Jmodel.UserName);
                    }
                }
                if (state == 7 || state == 8 || state == 9 || state == 10)
                {
                    res = new Yax.BLL.JieKuan().Update_state(state, id, memo);
                    //发送短信
                    msg = msg.Replace("{name}", Jmodel.RealName);
                    if (!string.IsNullOrEmpty(msg))
                    {
                        result = SendPhoneMsg(msg, Jmodel.UserName);
                    }
                }
                if (string.IsNullOrEmpty(msg))
                {
                    result = "";
                }
                else
                {
                    result = "，短信" + result;
                }
                if (res > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "修改会员借款状态 ID(" + id + ")状态：" + state + " 成功");
                    return Content("修改订单状态成功" + result);
                }
                else
                {
                    return Content("修改订单状态失败" + result);
                }
            }
            catch
            {
                return Content("网络异常995");
            }
            return View();
        }

        [PowerFiler("Jiekuan12")]
        public ActionResult TiXianMIma(int id)
        {
            Yax.Model.JieKuan model = new Yax.BLL.JieKuan().GetModel(id);
            if (model != null)
            {
                ViewBag.ID = model.ID;
                ViewBag.OrderNO = model.OrderNO;
                ViewBag.TiKuanPWD = model.TiKuanPWD;
                ViewBag.UserName = model.UserName;
                ViewBag.msg = new Yax.BLL.Config().GetModelBy_key("tikuanmimaduanxin").Value;
            }
            return View();
        }
        [PowerFiler("Jiekuan12")]
        public ActionResult TiXianMImaPost()
        {
            string pwd = Request.Form["TiKuanPWD"];
            string msg = Request.Form["msg"].Trim();
            int id = Yax.Common.Utils.GetFormInt("id");
            string phone = Request.Form["UserName"].Trim();
            msg = msg.Replace("{msg}", pwd);
            string result = new Yax.BLL.MsgConfig().SendCheckCode(phone, msg);
            if (result == "false")
            {
                return Content("发送失败");
            }
            else
            {
                int res = new Yax.BLL.JieKuan().Update_pwd(pwd, id);
                if (res > 0)
                {
                    return Content("发送成功");
                }
                else
                {
                    return Content("操作失败");
                }
            }
            return Content("");
        }

        [PowerFiler("Jiekuan12")]
        public ActionResult dakuaninfo(int id)
        {
            Yax.Model.JieKuan model = new Yax.Model.JieKuan();
            model = new Yax.BLL.JieKuan().GetModel(id);
            if(model!=null&&model.Enable>0)
            {
                ViewBag.BankName = model.BankName;
                ViewBag.BankNO = model.BankNO;
            }
            return View();
        }

        [PowerFiler("Jiekuan12")]
        public ActionResult DelJieKuan()
        {
            int id = Yax.Common.Utils.GetQueryInt("id", 0);
            int res = new Yax.BLL.JieKuan().UpdateEnable(0, id);
            try
            {
                if (res > 0)
                {
                    new Yax.BLL.ZY_Log().AddLog(1, new Yax.BLL.CurrentUser().Name + "删除借款订单ID(" + id + ")成功");
                    return Content("删除成功");
                }
                else
                {
                    return Content("删除失败");
                }
            }
            catch
            {
                return Content("操作异常");
            }
        }





        private string SendPhoneMsg(string msg,string phone)
        {
            string result = new Yax.BLL.MsgConfig().SendCheckCode(phone, msg);
            if (result == "false")
            {
                return "发送失败";
            }
            else
            {
                return "发送成功";
            }
        }
 



    }
}
