using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类TPay_Agent(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class TPay_Agent
    {
        public TPay_Agent()
        { }
        #region Model
        private int _id;
        private string _account;
        private string _realname;
        private string _pwd;
        private string _state;
        private string _calway;
        private string _calbankno;
        private string _calbankname;
        private string _calman;
        private string _phone;
        private decimal _money;
        private decimal _outmoney;
        private decimal _freezemoney;
        private string _memo;
        private decimal _wxfee;
        private decimal _zfbfee;
        private DateTime _addtime;
        private int _errorcount;
        private DateTime _lasterrtime;
        private int _logincount;
        private string _lastloginip;
        private DateTime _lastlogintime;
        private string _wxaccount;
        private string _zfbaccount;

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 代理账户
        /// </summary>
        public string Account
        {
            set { _account = value; }
            get { return _account; }
        }
        /// <summary>
        /// 代理人姓名
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }
        /// <summary>
        /// 状态 1：正常3：禁用 4删除
        /// </summary>
        public string State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 结算方式:1支付宝2微信3：银行卡
        /// </summary>
        public string CalWay
        {
            set { _calway = value; }
            get { return _calway; }
        }
        /// <summary>
        /// 结算账号
        /// </summary>
        public string CalBankNo
        {
            set { _calbankno = value; }
            get { return _calbankno; }
        }
        /// <summary>
        /// 结算银行名称 
        /// </summary>
        public string CalBankName
        {
            set { _calbankname = value; }
            get { return _calbankname; }
        }
        /// <summary>
        /// 结算持卡人姓名
        /// </summary>
        public string CalMan
        {
            set { _calman = value; }
            get { return _calman; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Money
        {
            set { _money = value; }
            get { return _money; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal OutMoney
        {
            set { _outmoney = value; }
            get { return _outmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FreezeMoney
        {
            set { _freezemoney = value; }
            get { return _freezemoney; }
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
        /// 代理费率 EG：0.5 代理1000块钱流水5块钱提成
        /// </summary>
        public decimal WXFee
        {
            set { _wxfee = value; }
            get { return _wxfee; }
        }
        /// <summary>
        /// 代理费率 EG：0.5 代理1000块钱流水5块钱提成
        /// </summary>
        public decimal ZFBFee
        {
            set { _zfbfee = value; }
            get { return _zfbfee; }
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
        public int ErrorCount
        {
            set { _errorcount = value; }
            get { return _errorcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastErrTime
        {
            set { _lasterrtime = value; }
            get { return _lasterrtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int LoginCount
        {
            set { _logincount = value; }
            get { return _logincount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LastLoginIP
        {
            set { _lastloginip = value; }
            get { return _lastloginip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastLoginTime
        {
            set { _lastlogintime = value; }
            get { return _lastlogintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WXAccount
        {
            set { _wxaccount = value; }
            get { return _wxaccount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZFBAccount
        {
            set { _zfbaccount = value; }
            get { return _zfbaccount; }
        }
        #endregion Model
    }
}
