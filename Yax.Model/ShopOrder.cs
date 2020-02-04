using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类ShopOrder(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class ShopOrder
    {
        public ShopOrder()
        { }
        #region Model
        private int _id;
        private string _orderno;
        private int _statu;
        private DateTime _addtime;
        private string _threeorder;
        private string _introduce;
        private string _ordermemo;
        private string _memo;
        private int _enable;
        private DateTime _paytime;
        private int _userid;
        private decimal _payprice;
        private DateTime _takeovertime;
        private DateTime _sendtime;
        private DateTime _updatetime;
        private string _wuliuno;
        private string _wuliuname;
        private decimal _cutprice;
        private decimal _wuliuprice;
        private int _paymethod;

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderNO
        {
            set { _orderno = value; }
            get { return _orderno; }
        }
        /// <summary>
        /// 订单状态  0：待付款 1：待发货 2：待收货 3：交易完成 4：交易关闭
        /// </summary>
        public int Statu
        {
            set { _statu = value; }
            get { return _statu; }
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
        /// 第三方订单号
        /// </summary>
        public string ThreeOrder
        {
            set { _threeorder = value; }
            get { return _threeorder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Introduce
        {
            set { _introduce = value; }
            get { return _introduce; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderMemo
        {
            set { _ordermemo = value; }
            get { return _ordermemo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Enable
        {
            set { _enable = value; }
            get { return _enable; }
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
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal PayPrice
        {
            set { _payprice = value; }
            get { return _payprice; }
        }
        /// <summary>
        /// 确认收货时间
        /// </summary>
        public DateTime TakeOverTime
        {
            set { _takeovertime = value; }
            get { return _takeovertime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime SendTime
        {
            set { _sendtime = value; }
            get { return _sendtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WuliuNo
        {
            set { _wuliuno = value; }
            get { return _wuliuno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WuliuName
        {
            set { _wuliuname = value; }
            get { return _wuliuname; }
        }
        /// <summary>
        /// 优惠费用
        /// </summary>
        public decimal CutPrice
        {
            set { _cutprice = value; }
            get { return _cutprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal WuLiuPrice
        {
            set { _wuliuprice = value; }
            get { return _wuliuprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PayMethod
        {
            set { _paymethod = value; }
            get { return _paymethod; }
        }



        //
        private string uname;

        public string Uname
        {
            get { return uname; }
            set { uname = value; }
        }
        private string pname;

        public string Pname
        {
            get { return pname; }
            set { pname = value; }
        }
      

       
     
        #endregion Model
    }
}
