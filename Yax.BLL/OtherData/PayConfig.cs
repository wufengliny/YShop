using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yax.BLL.OtherData
{
    public class PayConfig
    {
        public ZFBModel GetZFBData(decimal money)
        {
            ZFBModel model = new ZFBModel();
            List<Yax.Model.TPay_ZFBConfig> list = null;
            object obj = Yax.Common.DataCache.GetCache("payzfbobj");
            if (obj == null)
            {
                list = new Yax.BLL.TPay_ZFBConfig().GetList(10, "*", " Enable=1 and MinMoney<=" + money, "MinMoney asc");
            }
            else
            {
                list = (List<Model.TPay_ZFBConfig>)obj;
            }
            Yax.Model.TPay_ZFBConfig mc=null;
            if (list!=null&&list.Count>0)
            {
                mc = list.Where(p => p.MinMoney < money).OrderBy(p => p.MinMoney).FirstOrDefault();
            }
            if(mc!=null)
            {
                model.app_id = mc.APPID;
                model.private_keyPC = mc.PrivateKeyPC;
                model.alipay_public_keyPC = mc.PublicKeyPC;
            }
            else
            {
                return null;
            }
            return model;
        }
    }
}
