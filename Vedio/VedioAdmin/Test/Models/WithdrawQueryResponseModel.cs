using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models
{
    public class WithdrawQueryResponseModel
    {
        public int status { get; set; }

        public string msg { get; set; }
        public WithdrawQueryResponseDataModel data { get; set; }
    }
    public class WithdrawQueryResponseDataModel
    {
        /// <summary>
        /// 订单状态 1.进行中 3.订单已完成 4.失败
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// 失败原因 0.成功 5.驳回 6.冲正 7.下单失败
        /// </summary>
        public int fail_type { get; set; }

        /// <summary>
        /// 平台订单号	
        /// </summary>
        public string pay_order_id { get; set; }

        /// <summary>
        /// 渠道用户ID	
        /// </summary>
        public string out_uid { get; set; }

        /// <summary>
        /// 渠道订单号	
        /// </summary>
        public string out_trade_no { get; set; }
    }
}
