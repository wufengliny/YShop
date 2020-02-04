using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类BankCard(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class BankCard
    {
        public BankCard()
        { }
        #region Model
        private int _id;
        private string _bankno;
        private string _bankname;
        private string _cardtype;
        private string _area;
        private string _brand;
        private string _banksimplecode;
        private string _banktel;
        private string _bankurl;
        private int _uid;
        private string _realname;
        private int _enable;
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
        /// 
        /// </summary>
        public string BankNo
        {
            set { _bankno = value; }
            get { return _bankno; }
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
        public string cardType
        {
            set { _cardtype = value; }
            get { return _cardtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Brand
        {
            set { _brand = value; }
            get { return _brand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BanksimpleCode
        {
            set { _banksimplecode = value; }
            get { return _banksimplecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankTel
        {
            set { _banktel = value; }
            get { return _banktel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankUrl
        {
            set { _bankurl = value; }
            get { return _bankurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UID
        {
            set { _uid = value; }
            get { return _uid; }
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
        public int Enable
        {
            set { _enable = value; }
            get { return _enable; }
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
