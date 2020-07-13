using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models
{
    public class WithdrawResponseModel
    {
        public int status { get; set; }

        public string msg { get; set; }

        public WithdrawResponseDataModel data { get; set; }
    }
    public class WithdrawResponseDataModel
    {
        /// <summary>
        /// 平台订单ID
        /// </summary>
        public string pay_order_id { get; set; }

        /// <summary>
        /// 渠道订单号

        /// </summary>
        public string out_trade_no { get; set; }

        /// <summary>
        /// 渠道用户ID
        /// </summary>
        public string out_uid { get; set; }
    }
}
