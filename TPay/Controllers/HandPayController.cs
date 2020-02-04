using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPay.Controllers
{
    public class HandPayController : Controller
    {
        // GET: HandPay
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ZFBPay()
        {
            //
            decimal Price = Yax.Common.Utils.GetQueryDecimal("Price");
            decimal MinPayMoney =decimal.Parse(new Yax.BLL.Config().GetModelBy_key("tpayminpaymoney").Value);
            if(Price < MinPayMoney)
            {
                return Redirect("Err?msg=最小支付金额：" + MinPayMoney + "元");
            }
            string Account = Yax.Common.Utils.GetSafeQueryString("Account");
            if(string.IsNullOrEmpty(Account))
            {
                return Redirect("Err?msg=商户号不能为空");
            }
            Yax.Model.TPay_User mu = new Yax.BLL.TPay_User().GetModel_ByAccount(Account);
            if (mu==null)
            {
                return Redirect("Err?msg=商户号不存在");
            }
            if (mu.State != 1)
            {
                return Redirect("Err?msg=商户号异常");
            }
            //平台订单号
            string out_trade_no = "TNO" + Yax.Common.Utils.RandNum(5)+mu.ID + Yax.Common.Utils.RandomDateCard() + Yax.Common.Utils.RandNum(5);
            string strRes= CheckAccount(mu.PayKey, out_trade_no,mu.ID);
            if(strRes!="ok")
            {
                return Redirect("Err?msg="+strRes);
            }

            //设置out_trade_no cookie
            Yax.Common.Cookies.AddCookies("tpay", "out_trade_no",Yax.Common.SecurityHelper.EncryptTian(out_trade_no) , 30);



            string subject = "支付宝在线支付";
            //收银台页面上，商品展示的超链接，必填
            string show_url = "";
            //商品描述，可空
            string body = "订单支付";
            Yax.BLL.OtherData.ZFBModel zfbm = new Yax.BLL.OtherData.PayConfig().GetZFBData(Price);
            DefaultAopClient client = new DefaultAopClient(zfbm.gatewayUrl, zfbm.app_id, zfbm.private_keyPC, "json", "1.0", zfbm.sign_type, zfbm.alipay_public_keyPC, zfbm.charset, false);
            // 组装业务参数model
            AlipayTradePagePayModel model = new AlipayTradePagePayModel();
            model.Body = body;
            model.Subject = subject;
            model.TotalAmount = Price.ToString();
            model.OutTradeNo = out_trade_no;
            model.ProductCode = "FAST_INSTANT_TRADE_PAY";
            AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();
            // 设置同步回调地址


            request.SetReturnUrl(zfbm.return_url);
            // 设置异步通知接收地址
            request.SetNotifyUrl(zfbm.notify_url);
            // 将业务model载入到request
            request.SetBizModel(model);
            AlipayTradePagePayResponse response = null;
            try
            {
                response = client.pageExecute(request, null, "post");
                string content = "<div style='display:none;'>";
                content = content + response.Body + "<div>";
                ViewBag.res = content;
                return View();
            }
            catch (Exception exp)
            {
                return Redirect("Err?msg=系统繁忙0009");
            }
        }

        private string CheckAccount(string PayKey,string out_trade_no,int uid)
        {
            string priceStr = Yax.Common.Utils.GetQurryString("Price");
            string Account = Yax.Common.Utils.GetQurryString("Account");
            string OrderNum = Yax.Common.Utils.GetQurryString("OrderNum");
            string return_url = Yax.Common.Utils.GetQurryString("return_url");
            string notify_url = Yax.Common.Utils.GetQurryString("notify_url");
            string PayWay = Yax.Common.Utils.GetQurryString("PayWay");
            string Mark = Yax.Common.Utils.GetQurryString("Mark");
            string SighType = Yax.Common.Utils.GetQurryString("SighType");
            string SighMsg = Yax.Common.Utils.GetQurryString("SighMsg");

            //
            if (string.IsNullOrEmpty(OrderNum))
            {
                return "订单号不能为空";
            }
            if (string.IsNullOrEmpty(return_url))
            {
                return "return_url不能为空";
            }
            if (string.IsNullOrEmpty(notify_url))
            {
                return "notify_url不能为空";
            }
            if (PayWay!="wx"&& PayWay!="zfb")
            {
                return "不存在的支付方式";
            }
            if (SighType!="md5")
            {
                return "不存在的签名方式";
            }
            //ABCDEFGHIJKLMNOPQRSTUVWXYZ 
            string singStr = "Account=" + Account + "&Price=" + priceStr + "&OrderNum=" + OrderNum + "&PayWay=" + PayWay + "&Mark=" + Mark + "&SighType=" + SighType + "&return_url=" + return_url + "&notify_url=" + notify_url + PayKey;
            //Account  Mark  notify_url OrderNum PayWay Price return_url  SighType   PayKey;
            singStr = "Account=" + Account + "&Mark=" + Mark + "&notify_url=" + notify_url + "&OrderNum=" + OrderNum + "&PayWay=" + PayWay + "&Price=" + priceStr + "&return_url=" + return_url + "&SighType=" + SighType + PayKey;
           
            string sigh = Yax.Common.SecurityHelper.MD5(singStr);
            if(sigh!= SighMsg)
            {
                return "err:签名错误";
            }
            if(PayWay=="zfb")
            {
                PayWay = "支付宝";
            }
            if (PayWay == "wx")
            {
                PayWay = "微信";
            }
            //生成订单
            Yax.Model.Tpay_Order mo = new Yax.Model.Tpay_Order();
            mo.Account = Account;
            mo.AddTime = DateTime.Now;
            mo.ISDeal = 0;
            mo.noticeUrl = notify_url;
            mo.OrderNum = OrderNum;
            mo.out_trade_no = out_trade_no;
            mo.PayState = "待支付";
            mo.PayTime = DateTime.Now.AddYears(300);
            mo.PayWay = PayWay;
            mo.Price = Yax.Common.Utils.GetQueryDecimal("Price");
            mo.redicUrl = return_url;
            mo.RefferUrl = Request.UrlReferrer.ToString();
            mo.RequestUrl = Request.Url.ToString();
            mo.Title = "";
            mo.Trade_no = "";
            mo.UID = uid;
            mo.UserMark = Mark;
            mo.ZhongDuan = "pc";
            new Yax.BLL.Tpay_Order().Add(mo);
            return "ok";
        }



        public ActionResult WXPay()
        {
            return View();
        }



        public ActionResult Err(string msg="系统繁忙")
        {
            return Content(msg);
        }

    }
}