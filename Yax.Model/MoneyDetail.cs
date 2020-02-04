using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类MoneyDetail(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class MoneyDetail
    {
        public MoneyDetail()
        { }
        #region Model
        private int _id;
        private int _userid;
        private string _phone;
        private string _realname;
        private decimal _money;
        private decimal _premoney;
        private decimal _aftermoney;
        private DateTime _addtime;
        private int _enable;
        private string _orderno;
        private string _memo;
        private string _msgrecord;
        private int _adminid;
        private int _cztype;
        private string _moneytype;

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
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
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
        public int Enable
        {
            set { _enable = value; }
            get { return _enable; }
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
        public string Memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// 后台充值时记录短信内容
        /// </summary>
        public string msgRecord
        {
            set { _msgrecord = value; }
            get { return _msgrecord; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AdminID
        {
            set { _adminid = value; }
            get { return _adminid; }
        }
        /// <summary>
        /// 1 后台充值 2
        /// </summary>
        public int CZtype
        {
            set { _cztype = value; }
            get { return _cztype; }
        }
        /// <summary>
        /// 1 in  2  out
        /// </summary>
        public string MoneyType
        {
            set { _moneytype = value; }
            get { return _moneytype; }
        }
        #endregion Model
    }
}
