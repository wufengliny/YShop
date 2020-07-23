using System;
namespace Entity
{
    /// <summary>
    /// 实体类C_Orders(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class MC_Orders
    {
        public MC_Orders()
        { }
        #region Model

        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>
        public int UID { get; set; }
        /// <summary>
        /// 视频ID
        /// </summary>
        public int VedioID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 三方交易号
        /// </summary>
        public string TradeNo { get; set; }
        /// <summary>
        /// 第三方支付表ID
        /// </summary>
        public int CardID { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 订单支付完成时间
        /// </summary>
        public DateTime OKTime { get; set; }
        /// <summary>
        /// 1:未支付2已支付
        /// </summary>
        public int Statu { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }
        #endregion Model
    }
}
