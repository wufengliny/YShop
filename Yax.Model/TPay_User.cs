using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类TPay_User(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class TPay_User
    {
        public TPay_User()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _account;
        private string _pwd;
        private string _contactman;
        private int _state;
        private string _paykey;
        private string _calway;
        private string _calbankno;
        private string _calbankname;
        private string _calman;
        private string _weburl;
        private string _emali;
        private string _qq;
        private string _memo;
        private decimal _money;
        private decimal _outmoney;
        private decimal _freezemoney;
        private decimal _wxfee;
        private decimal _zfbfee;
        private string _phone;
        private int _recommondid;
        private string _ipwhite;
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
        /// 商户名称（企业名称）
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
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
        /// 
        /// </summary>
        public string Pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string ContactMan
        {
            set { _contactman = value; }
            get { return _contactman; }
        }
        /// <summary>
        /// 商户号状态1：正常(已激活) 2测试 3禁用 4删除
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 密钥
        /// </summary>
        public string PayKey
        {
            set { _paykey = value; }
            get { return _paykey; }
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
        /// 商户网站域名
        /// </summary>
        public string WebUrl
        {
            set { _weburl = value; }
            get { return _weburl; }
        }
        /// <summary>
        /// 联系邮箱
        /// </summary>
        public string Emali
        {
            set { _emali = value; }
            get { return _emali; }
        }
        /// <summary>
        /// 联系QQ
        /// </summary>
        public string QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 商户备注 其他信息
        /// </summary>
        public string Memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// 商户余额
        /// </summary>
        public decimal Money
        {
            set { _money = value; }
            get { return _money; }
        }
        /// <summary>
        /// 历史提现总金额
        /// </summary>
        public decimal OutMoney
        {
            set { _outmoney = value; }
            get { return _outmoney; }
        }
        /// <summary>
        /// 冻结金额
        /// </summary>
        public decimal FreezeMoney
        {
            set { _freezemoney = value; }
            get { return _freezemoney; }
        }
        /// <summary>
        /// 微信费率 eg(金额100元) 费率是4.0 结算之后商户可以提现96元
        /// </summary>
        public decimal WXFee
        {
            set { _wxfee = value; }
            get { return _wxfee; }
        }
        /// <summary>
        /// 支付宝费率 eg(金额100元) 费率是4.0 结算之后商户可以提现96元
        /// </summary>
        public decimal ZFBFee
        {
            set { _zfbfee = value; }
            get { return _zfbfee; }
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
        /// 代理推荐人ID
        /// </summary>
        public int RecommondID
        {
            set { _recommondid = value; }
            get { return _recommondid; }
        }
        /// <summary>
        /// IP白名单  多个,逗号隔开 
        /// </summary>
        public string IPWhite
        {
            set { _ipwhite = value; }
            get { return _ipwhite; }
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
