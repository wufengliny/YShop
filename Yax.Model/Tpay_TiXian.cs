using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类Tpay_TiXian(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Tpay_TiXian
    {
        public Tpay_TiXian()
        { }
        #region Model
        private int _id;
        private int _uid;
        private string _uaccount;
        private int _utype;
        private decimal _money;
        private decimal _premoney;
        private decimal _aftermoney;
        private string _accountinfo;
        private int _enable;
        private int _state;
        private int _approid;
        private string _approname;
        private string _memo;
        private DateTime _addtime;

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 提现人ID  商户或者代理
        /// </summary>
        public int UID
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 提现人(商户号或者代理名称) 
        /// </summary>
        public string UAccount
        {
            set { _uaccount = value; }
            get { return _uaccount; }
        }
        /// <summary>
        /// 1商户提现2 代理提现
        /// </summary>
        public int UType
        {
            set { _utype = value; }
            get { return _utype; }
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
        public decimal PreMoney
        {
            set { _premoney = value; }
            get { return _premoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal AfterMoney
        {
            set { _aftermoney = value; }
            get { return _aftermoney; }
        }
        /// <summary>
        /// 提现账户信息
        /// </summary>
        public string AccountInfo
        {
            set { _accountinfo = value; }
            get { return _accountinfo; }
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
        /// 
        /// </summary>
        public int ApproID
        {
            set { _approid = value; }
            get { return _approid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ApproName
        {
            set { _approname = value; }
            get { return _approname; }
        }
        /// <summary>
        /// 审核通过，或者不通过管理员备注信息，客户可以看到
        /// </summary>
        public string Memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        #endregion Model
    }
}
