using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Collections.Specialized;

namespace TPay.Controllers
{
    public class PayoverController : Controller
    {
        // GET: Payover 


        /// <summary>
        /// 支付成功后跳转到该页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            string out_trade_no= Yax.Common.Cookies.GetCookies("tpay", "out_trade_no");
            out_trade_no = Yax.Common.SecurityHelper.DecrypTian(out_trade_no);
            if (string.IsNullOrEmpty(out_trade_no))
            {
                return Content("订单不存在，或者订单已过期");
            }
            string str = "select * from Tpay_Order where out_trade_no='"+ out_trade_no + "'";
            DataTable dt= new Yax.BLL.BCommon().GetDataBySQL(str);
            if(dt.Rows.Count>0)
            {
                string redicUrl = dt.Rows[0]["redicUrl"].ToString();
                if(dt.Rows[0]["redicUrl"].ToString()== "已支付")
                {
                    Yax.Common.Cookies.DeleteCookies("tpay");
                    return Redirect(redicUrl + "?msg=success");
                }
                else
                {
                    Yax.Common.Cookies.DeleteCookies("tpay");
                    return Redirect(redicUrl + "?msg=false");
                }
            
            }
            else
            {
                return Content("订单不存在");
            }
            return View();
        }

        /// <summary>
        /// 支付成功响应处理
        /// </summary>
        /// <returns></returns>
        public ActionResult notifyzfb()
        {
            SortedDictionary<string, string> sPara = GetRequestPost();
            if (sPara.Count > 0)//判断是否有带返回参数
            {
                DDAPI.ZFB.Notify aliNotify = new DDAPI.ZFB.Notify();
                bool verifyResult = aliNotify.Verify(sPara, Request.Form["notify_id"], Request.Form["sign"]);

                if (verifyResult)//验证成功
                {
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //请在这里加上商户的业务逻辑程序代码

                    //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                    //获取支付宝的通知返回参数，可参考技术文档中服务器异步通知参数列表

                    //商户订单号
                    string out_trade_no = Request.Form["out_trade_no"];
                    //支付宝交易号(要保存，退款时要用)
                    string trade_no = Request.Form["trade_no"];

                    ////批次号 退款接口回调时需要用
                    //string batch_no = Request.Form["batch_no"];
                    ////批量退款数据中转账成功的笔数
                    //string success_num = Request.Form["success_num"];
                    ////批量退款数据中的详细信息
                    //string result_details = Request.Form["result_details"];

                    //交易状态
                    string trade_status = Request.Form["trade_status"];


                    if (Request.Form["trade_status"] == "TRADE_FINISHED" || Request.Form["trade_status"] == "TRADE_SUCCESS")
                    {
                        #region 更新订单信息
                        try
                        {
                            string strQ = " select tod.*,tu.PayKey,tu.ZFBFee,tu.WXFee,ta.ZFBFee aZFBFee,ta.WXFee aWXFee,ta.ID agentID  from Tpay_Order  tod  ";
                            strQ += " left join TPay_User  tu on tod.UID=tu.ID  ";
                            strQ += " left join TPay_Agent ta on tu.RecommondID=ta.ID where tod.out_trade_no='" + out_trade_no + "'";
                            DataTable dt = new Yax.BLL.BCommon().GetDataBySQL(strQ);
                            if (dt.Rows.Count > 0)
                            {
                                //DbHelperSQL.ExecuteSql("insert into test values('')");
                                //保存支付宝交易号
                                if (dt.Rows[0]["PayState"].ToString() == "待支付")
                                {
                                    List<string> listStr = new List<string>();
                                    decimal mon = decimal.Parse(dt.Rows[0]["Price"].ToString());
                                    decimal ZFBFee= decimal.Parse(dt.Rows[0]["ZFBFee"].ToString());
                                    decimal aZFBFee = decimal.Parse(dt.Rows[0]["aZFBFee"].ToString());
                                    decimal SHMoney =mon- mon * ZFBFee / 100;
                                    decimal AgentMoney = mon * aZFBFee / 100;
                                    string strUP = " update TPay_User set Money+=" + SHMoney + " where ID='" + dt.Rows[0]["UID"].ToString() + "'";
                                    listStr.Add(strUP);
                                    strUP = " update TPay_Agent set Money+=" + AgentMoney + " where ID='" + dt.Rows[0]["agentID"].ToString() + "'";
                                    listStr.Add(strUP);
                                    strUP = " update Tpay_Order set Trade_no='" + trade_no + "',PayState='已支付',PayTime='" + DateTime.Now + ",AgentMoney="+AgentMoney+ ",SHMoney="+SHMoney+" where out_trade_no='" + out_trade_no + "'";
                                    listStr.Add(strUP);
                                    new Yax.BLL.BCommon().ExecuteSqlTran(listStr);
                                    //回调信息给客户端
                                    int anum = 0;
                                    try
                                    {
                                        string noticeUrl = dt.Rows[0]["noticeUrl"].ToString();
                                        //ABCDEFGHIJKLMNOPQRSTUVWXYZ 
                                        string  ParaStr = "Account="+ dt.Rows[0]["Account"] + "&MarK=" + dt.Rows[0]["UserMark"] + "&OrderNum=" + dt.Rows[0]["OrderNum"] + "&out_trade_no=" + out_trade_no + "&Price=" + dt.Rows[0]["Price"];
                                        string singstr = Yax.Common.SecurityHelper.MD5(ParaStr + dt.Rows[0]["PayKey"]);
                                        string respay = Yax.Common.HTTPHelper.GetHTMLUTF8(noticeUrl + "?" + ParaStr + "&Sing=" + singstr);
                                        new Yax.BLL.ZY_Log().AddLog(2, noticeUrl + "?" + ParaStr + "&Sing=" + singstr);
                                        if (respay == "success")
                                        {
                                            new Yax.BLL.BCommon().ExecuteScalar("update Tpay_Order set ISDeal=1 where out_trade_no='" + dt.Rows[0]["out_trade_no"] + "' ");
                                        }
                                    }
                                    catch (Exception ee)
                                    {
                                        anum += 1;
                                    }
                                }
                            }

                        }
                        catch (Exception ee2)
                        {
                        }
                        #endregion
                    }
                    return Content("success");  //请不要修改或删除


                }
                else//验证失败
                {
                    return Content("fail");
                }
            }
            else
            {
                return Content("无通知参数");
            }
            return Content("");
        }

        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestPost()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = Request.Form;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }

            return sArray;
        }



        // 商户 通道测试 回调
        public ActionResult TestNotify()
        {
            string Account = Yax.Common.Utils.GetQurryString("Account");
            string MarK = Yax.Common.Utils.GetQurryString("MarK");
            string OrderNum = Yax.Common.Utils.GetQurryString("OrderNum");
            string out_trade_no = Yax.Common.Utils.GetQurryString("out_trade_no");
            string Price = Yax.Common.Utils.GetQurryString("Price");
            string Sing = Yax.Common.Utils.GetQurryString("Sing");
            Yax.Model.TPay_User model = new Yax.BLL.TPay_User().GetModel_ByAccount(Account);
            string singstr = "Account="+Account+"&MarK=" + MarK + "&OrderNum=" + OrderNum + "&out_trade_no=" + out_trade_no + "&Price=" + Price + model.PayKey;
            singstr = Yax.Common.SecurityHelper.MD5(singstr);
            if (singstr != Sing)
            {
                return Content("false");
            }
            else
            {
                string str = " update ShopOrder set Statu=3 where OrderNO='" + OrderNum + "'";
                new Yax.BLL.BCommon().ExecuteScalar(str);
                return Content("success");
            }
            
        }
        //

    }
}