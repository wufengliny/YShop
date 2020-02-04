using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类JieKuan(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class JieKuan
    {
        public JieKuan()
        { }
        #region Model
        private int _id;
        private string _orderno;
        private string _username;
        private int _userid;
        private string _realname;
        private decimal _money;
        private int _jietime;
        private decimal _monthfee;
        private decimal _allfee;
        private DateTime _addtime;
        private int _state;
        private DateTime _approvetime;
        private string _tikuanpwd;
        private int _bankcardid;
        private string _bankname;
        private string _bankno;
        private int _enable;
        private string _memo;
        private int _approveid;
        private string _approvename;
        private string _feepercent;
        private int _jietpye;

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
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
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
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
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
        /// 借款 借多久  3个月 6个月  12个月 24个月等等 单位月
        /// </summary>
        public int JieTime
        {
            set { _jietime = value; }
            get { return _jietime; }
        }
        /// <summary>
        /// 每月利息 
        /// </summary>
        public decimal MonthFee
        {
            set { _monthfee = value; }
            get { return _monthfee; }
        }
        /// <summary>
        /// 总利息
        /// </summary>
        public decimal AllFee
        {
            set { _allfee = value; }
            get { return _allfee; }
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
        /// 1 未审核 2 审核通过  3 审核不通过
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 管理员操作时间
        /// </summary>
        public DateTime ApproveTime
        {
            set { _approvetime = value; }
            get { return _approvetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TiKuanPWD
        {
            set { _tikuanpwd = value; }
            get { return _tikuanpwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int BankCardID
        {
            set { _bankcardid = value; }
            get { return _bankcardid; }
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
        public string BankNO
        {
            set { _bankno = value; }
            get { return _bankno; }
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
        public string Memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ApproveID
        {
            set { _approveid = value; }
            get { return _approveid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ApproveName
        {
            set { _approvename = value; }
            get { return _approvename; }
        }
        /// <summary>
        /// 利率%
        /// </summary>
        public string FeePercent
        {
            set { _feepercent = value; }
            get { return _feepercent; }
        }
        /// <summary>
        /// 1 每月等额 2 先息后本
        /// </summary>
        public int JieTpye
        {
            set { _jietpye = value; }
            get { return _jietpye; }
        }
        #endregion Model
    }
}
