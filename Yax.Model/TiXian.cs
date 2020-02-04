using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类TiXian(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class TiXian
    {
        public TiXian()
        { }
        #region Model
        private int _id;
        private string _orderno;
        private string _realname;
        private string _phone;
        private string _bankname;
        private string _bankno;
        private decimal _money;
        private DateTime _addtime;
        private decimal _premoney;
        private decimal _aftermoney;
        private int _userid;
        private int _bankcardid;
        private int _enable;
        private int _state;
        private int _approveid;
        private DateTime _approvetime;
        private string _approvename;
        private string _memo;

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 提现订单号
        /// </summary>
        public string OrderNO
        {
            set { _orderno = value; }
            get { return _orderno; }
        }
        /// <summary>
        /// 提现人 真实姓名
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
        public decimal Money
        {
            set { _money = value; }
            get { return _money; }
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
        /// 提现前金额
        /// </summary>
        public decimal PreMoney
        {
            set { _premoney = value; }
            get { return _premoney; }
        }
        /// <summary>
        /// 提现后剩余金额
        /// </summary>
        public decimal AfterMoney
        {
            set { _aftermoney = value; }
            get { return _aftermoney; }
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
        /// 会员银行卡表的ID
        /// </summary>
        public int BankCardID
        {
            set { _bankcardid = value; }
            get { return _bankcardid; }
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
        /// 1 未审核   2 审核不通过 3审核通过（已出款）
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 审核者的管理员ID
        /// </summary>
        public int ApproveID
        {
            set { _approveid = value; }
            get { return _approveid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ApproveTime
        {
            set { _approvetime = value; }
            get { return _approvetime; }
        }
        /// <summary>
        /// 管理员账户名
        /// </summary>
        public string ApproveName
        {
            set { _approvename = value; }
            get { return _approvename; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        #endregion Model
    }
}
