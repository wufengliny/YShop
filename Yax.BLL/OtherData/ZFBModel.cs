using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yax.BLL.OtherData
{
    public class ZFBModel
    {
        public string gatewayUrl = "https://openapi.alipay.com/gateway.do";
        public string sign_type = "RSA2";
        public string charset = "UTF-8";
        public string app_id;
        public string private_keyPC;
        public string alipay_public_keyPC;
        // 页面跳转同步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数，必须外网可以正常访问
        public  string return_url = new Yax.BLL.Config().GetModelBy_key("tpaywenjkurl").Value + "/Payover/index";//
        public string notify_url = new Yax.BLL.Config().GetModelBy_key("tpaywenjkurl").Value + "/Payover/notifyzfb";//
    }
}
