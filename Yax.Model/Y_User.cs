using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类Y_User(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Y_User
    {
        public Y_User()
        { }
        #region Model
        private int _id;
        private string _account;
        private string _name;
        private string _realname;
        private string _phone;
        private string _pwd;
        private string _email;
        private int _sex;
        private DateTime _lastlogintime;
        private string _lastloginip;
        private int _logincount;
        private string _regip;
        private string _regurl;
        private DateTime _addtime;
        private int _regtype;
        private DateTime _updatetime;
        private int _effect;
        private string _memo;
        private int _errorcount;
        private DateTime _lasterrtime;
        private decimal _money;
        private string _qq;
        private int _jifen;
        private int _dianquan;
        private int _addressid;
        private string _idcard;
        private string _idcardimgzheng;
        private string _idcardimgbei;
        private string _idcardimgshouchi;
        private string _liveplace;
        private string _workplace;
        private string _jobname;
        private string _jobage;
        private string _jobcompanyphone;
        private decimal _jobmoney;
        private string _contactman;
        private string _contactman2;
        private string _bankname;
        private string _bankcardno;
        private string _jobcompanyname;
        private int _rzstate;
        private string _rzmemo;
        private string _buc;
        private string _buc2;
        private string _buc3;
        private string _buc4;
        private string _buc5;
        private string _buc6;
        private string _idcardself;
        private string _usertype;
        private int _agentid;
        private int _vip;
        private int _viplevel;
        private DateTime _vipendtime;
        private string _vipmemo;

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 唯一   邮箱或者手机
        /// </summary>
        public string Account
        {
            set { _account = value; }
            get { return _account; }
        }
        /// <summary>
        /// 用户名 显示
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
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
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 0：男 1：女
        /// </summary>
        public int Sex
        {
            set { _sex = value; }
            get { return _sex; }
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
        public string LastLoginIP
        {
            set { _lastloginip = value; }
            get { return _lastloginip; }
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
        public string RegIP
        {
            set { _regip = value; }
            get { return _regip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RegURL
        {
            set { _regurl = value; }
            get { return _regurl; }
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
        /// 0 邮箱注册  1：手机注册 2:一般注册（无邮箱，手机） 3后台添加 4 代理添加
        /// </summary>
        public int RegType
        {
            set { _regtype = value; }
            get { return _regtype; }
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
        public int Effect
        {
            set { _effect = value; }
            get { return _effect; }
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
        public decimal Money
        {
            set { _money = value; }
            get { return _money; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 会员的积分数
        /// </summary>
        public int JIFen
        {
            set { _jifen = value; }
            get { return _jifen; }
        }
        /// <summary>
        /// 点券 不可提现
        /// </summary>
        public int DianQuan
        {
            set { _dianquan = value; }
            get { return _dianquan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AddressID
        {
            set { _addressid = value; }
            get { return _addressid; }
        }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IDCard
        {
            set { _idcard = value; }
            get { return _idcard; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IDCardImgZheng
        {
            set { _idcardimgzheng = value; }
            get { return _idcardimgzheng; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IDCardImgBei
        {
            set { _idcardimgbei = value; }
            get { return _idcardimgbei; }
        }
        /// <summary>
        /// 手持身份证
        /// </summary>
        public string IDCardImgShouChi
        {
            set { _idcardimgshouchi = value; }
            get { return _idcardimgshouchi; }
        }
        /// <summary>
        /// 现居住地
        /// </summary>
        public string LivePlace
        {
            set { _liveplace = value; }
            get { return _liveplace; }
        }
        /// <summary>
        /// 单位地址
        /// </summary>
        public string WorkPlace
        {
            set { _workplace = value; }
            get { return _workplace; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JobName
        {
            set { _jobname = value; }
            get { return _jobname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JobAge
        {
            set { _jobage = value; }
            get { return _jobage; }
        }
        /// <summary>
        /// 单位电话
        /// </summary>
        public string JobCompanyPhone
        {
            set { _jobcompanyphone = value; }
            get { return _jobcompanyphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal JobMoney
        {
            set { _jobmoney = value; }
            get { return _jobmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ContactMan
        {
            set { _contactman = value; }
            get { return _contactman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ContactMan2
        {
            set { _contactman2 = value; }
            get { return _contactman2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankName
        {
            set { _bankname = value; }
            get { return _bankname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankCardNO
        {
            set { _bankcardno = value; }
            get { return _bankcardno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JobCompanyName
        {
            set { _jobcompanyname = value; }
            get { return _jobcompanyname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int RZState
        {
            set { _rzstate = value; }
            get { return _rzstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RzMemo
        {
            set { _rzmemo = value; }
            get { return _rzmemo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BuC
        {
            set { _buc = value; }
            get { return _buc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BuC2
        {
            set { _buc2 = value; }
            get { return _buc2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BuC3
        {
            set { _buc3 = value; }
            get { return _buc3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BuC4
        {
            set { _buc4 = value; }
            get { return _buc4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BuC5
        {
            set { _buc5 = value; }
            get { return _buc5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BuC6
        {
            set { _buc6 = value; }
            get { return _buc6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IDCardSelf
        {
            set { _idcardself = value; }
            get { return _idcardself; }
        }
        /// <summary>
        /// 会员，代理
        /// </summary>
        public string UserType
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        /// <summary>
        /// 上级代理ID 
        /// </summary>
        public int AgentID
        {
            set { _agentid = value; }
            get { return _agentid; }
        }
        /// <summary>
        /// 0：非VIP 1：VIP
        /// </summary>
        public int VIP
        {
            set { _vip = value; }
            get { return _vip; }
        }
        /// <summary>
        /// 1:普通VIP2 超级VIP 
        /// </summary>
        public int VIPLevel
        {
            set { _viplevel = value; }
            get { return _viplevel; }
        }
        /// <summary>
        /// VIP 结束时间
        /// </summary>
        public DateTime VIPEndTime
        {
            set { _vipendtime = value; }
            get { return _vipendtime; }
        }
        /// <summary>
        /// VIP备注
        /// </summary>
        public string VIPMemo
        {
            set { _vipmemo = value; }
            get { return _vipmemo; }
        }
        #endregion Model
    }
}
