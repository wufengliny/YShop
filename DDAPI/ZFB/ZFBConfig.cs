using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDAPI.ZFB
{
    public class ZFBConfig
    {

        //↓↓↓↓↓↓↓↓↓↓请在这里配置您的基本信息↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

        // 合作身份者ID，签约账号，以2088开头由16位纯数字组成的字符串，查看地址：https://b.alipay.com/order/pidAndKey.htm
        public static string partner = "";// new Yax.BLL.ZY_Config().GetModelBy_key("zfbPartner").Value;

        // 收款支付宝账号，以2088开头由16位纯数字组成的字符串，一般情况下收款账号就是签约账号
        public static string seller_id = partner;

        //商户的私钥文件路径,原始格式，RSA公私钥生成：https://doc.open.alipay.com/doc2/detail.htm?spm=a219a.7629140.0.0.nBDxfy&treeId=58&articleId=103242&docType=1

        public static string private_key = "";//  new Yax.BLL.ZY_Config().GetModelBy_key("zfbWapPrivate_key").Value;

        //支付宝的公钥文件路径，查看地址：https://b.alipay.com/order/pidAndKey.htm 
        public static string alipay_public_key = "";//  new Yax.BLL.ZY_Config().GetModelBy_key("zfbWapPublic_key").Value;
        //MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCnxj/9qwVfgoUh/y2W89L6BkRAFljhNhgPdyPuBV64bfQNN1PjbCzkIM6qRdKBoLPXmKKMiFYnkd6rAoprih3/PrQEB/VsW8OoM8fxn67UDYuyBTqA23MML9q1+ilIZwBC2AQ2UBVOrFXfFl75p6/B5KsiNG9zpgmLCUYuLkxpLQIDAQAB
        //MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQC9nZ0+V00nxneEkY56wD3JBKhvwFkH3c30W+tvXLvbjo+NZK+Q5Ojmr8oqp6NaXrBdesqFRoDWw+FMI7NuGZTeMC2JgwZMLQbkbT4ogumRQKn2QIyLF5mdM0sM2dvDfFziFi8NEhdkqF9Z88hbQzEw147wFyScvxRkc6uZvHmDRQIDAQAB


        // 服务器异步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数,必须外网可以正常访问
        public static string notify_url = "";//  new Yax.BLL.QuickData.SystemInfo().WebUrl + "/Notify/Notifyzfb";

        public static string notifybackmoney_url = "";//  new Yax.BLL.QuickData.SystemInfo().WebUrl + "/Notify/notifyzfbback";

        // 页面跳转同步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数，必须外网可以正常访问
        public static string return_url = "";//  new Yax.BLL.QuickData.SystemInfo().WebUrl + "/member/pay/payover";//支付成功的页面要改
        // 签名方式
        public static string sign_type = "RSA";

        // 调试用，创建TXT日志文件夹路径，见AlipayCore.cs类中的LogResult(string sWord)打印方法。
        public static string log_path = "";

        // 退款日期 时间格式 yyyy-MM-dd HH:mm:ss
        public static string refund_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        // 字符编码格式 目前支持utf-8
        public static string input_charset = "utf-8";

        // 支付类型 ，无需修改
        public static string payment_type = "1";

        // 调用的接口名，无需修改
        public static string service = "alipay.wap.create.direct.pay.by.user";

        // 调用的接口名，无需修改
        public static string backservice = "refund_fastpay_by_platform_pwd";
        
        //↑↑↑↑↑↑↑↑↑↑请在这里配置您的基本信息↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
    }
}
