using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDAPI.ZFB
{
    public class ZFBPCconfig
    {
        // 应用ID,您的APPID
        public static string app_id = "";//  new Yax.BLL.ZY_Config().GetModelBy_key("zfbAppID").Value;

        // 支付宝网关
        public static string gatewayUrl = "https://openapi.alipay.com/gateway.do";

        // 商户私钥，您的原始格式RSA私钥
        public static string private_key = "";//  new Yax.BLL.ZY_Config().GetModelBy_key("zfbPCPrivate_key").Value;


        // 支付宝公钥,查看地址：https://openhome.alipay.com/platform/keyManage.htm 对应APPID下的支付宝公钥。
        public static string alipay_public_key = "";//  new Yax.BLL.ZY_Config().GetModelBy_key("zfbPCPublic_key").Value;

        // 签名方式
        public static string sign_type = "RSA2";

        // 编码格式
        public static string charset = "UTF-8";
        public static string notify_url = "";//  new Yax.BLL.QuickData.SystemInfo().WebUrl + "/Notify/NotifyZfbPC";
    }
}
