using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类PayCard(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PayCard
    {
        public PayCard()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _cardno;
        private int _enable;
        private DateTime _addtime;
        private string _apiurl;
        private string _apikey;
        private string _memo;
        private string _publickey;
        private string _payurl;
        private DateTime _updatetime;
        private string _cardtype;
        private string _imgurl;

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
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CardNo
        {
            set { _cardno = value; }
            get { return _cardno; }
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
        /// <summary>
        /// 
        /// </summary>
        public string APIUrl
        {
            set { _apiurl = value; }
            get { return _apiurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string APIKey
        {
            set { _apikey = value; }
            get { return _apikey; }
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
        public string PublicKey
        {
            set { _publickey = value; }
            get { return _publickey; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PayUrl
        {
            set { _payurl = value; }
            get { return _payurl; }
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
        /// 第三方类型  支付宝 微信  。。。。
        /// </summary>
        public string CardType
        {
            set { _cardtype = value; }
            get { return _cardtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImgUrl
        {
            set { _imgurl = value; }
            get { return _imgurl; }
        }
        #endregion Model
    }
}
