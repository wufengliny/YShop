using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类Tpay_Order(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Tpay_Order
    {
        public Tpay_Order()
        { }
        #region Model
        private int _id;
        private string _ordernum;
        private string _out_trade_no;
        private string _trade_no;
        private string _account;
        private int _uid;
        private string _paystate;
        private decimal _price;
        private DateTime _addtime;
        private DateTime _paytime;
        private string _payway;
        private string _zhongduan;
        private string _requesturl;
        private string _refferurl;
        private int _isdeal;
        private string _redicurl;
        private string _noticeurl;
        private string _usermark;
        private string _title;
        private decimal _agentmoney;
        private decimal _shmoney;
        private decimal _ptmoney;
        private decimal _kfmoney;

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OrderNum
        {
            set { _ordernum = value; }
            get { return _ordernum; }
        }
        /// <summary>
        /// 平台订单号
        /// </summary>
        public string out_trade_no
        {
            set { _out_trade_no = value; }
            get { return _out_trade_no; }
        }
        /// <summary>
        /// 第三方订单号 支付宝或者微信
        /// </summary>
        public string Trade_no
        {
            set { _trade_no = value; }
            get { return _trade_no; }
        }
        /// <summary>
        /// 商户号
        /// </summary>
        public string Account
        {
            set { _account = value; }
            get { return _account; }
        }
        /// <summary>
        /// 商户ID
        /// </summary>
        public int UID
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 1待支付 2已支付
        /// </summary>
        public string PayState
        {
            set { _paystate = value; }
            get { return _paystate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime PayTime
        {
            set { _paytime = value; }
            get { return _paytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PayWay
        {
            set { _payway = value; }
            get { return _payway; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZhongDuan
        {
            set { _zhongduan = value; }
            get { return _zhongduan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RequestUrl
        {
            set { _requesturl = value; }
            get { return _requesturl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RefferUrl
        {
            set { _refferurl = value; }
            get { return _refferurl; }
        }
        /// <summary>
        /// 客户端是否已经处理完这条数据 0   1
        /// </summary>
        public int ISDeal
        {
            set { _isdeal = value; }
            get { return _isdeal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string redicUrl
        {
            set { _redicurl = value; }
            get { return _redicurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string noticeUrl
        {
            set { _noticeurl = value; }
            get { return _noticeurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserMark
        {
            set { _usermark = value; }
            get { return _usermark; }
        }
        /// <summary>
        /// 商品标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 代理分配的金额
        /// </summary>
        public decimal AgentMoney
        {
            set { _agentmoney = value; }
            get { return _agentmoney; }
        }
        /// <summary>
        /// 商户分配的金额
        /// </summary>
        public decimal SHMoney
        {
            set { _shmoney = value; }
            get { return _shmoney; }
        }
        /// <summary>
        /// 平台分配的金额
        /// </summary>
        public decimal PTMoney
        {
            set { _ptmoney = value; }
            get { return _ptmoney; }
        }
        /// <summary>
        /// 系统商金额
        /// </summary>
        public decimal KFMoney
        {
            set { _kfmoney = value; }
            get { return _kfmoney; }
        }
        #endregion Model
    }
}
