using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类TPay_WXConfig(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class TPay_WXConfig
    {
        public TPay_WXConfig()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _token;
        private string _apiid;
        private string _secret;
        private DateTime _addtime;
        private string _paymchid;
        private string _paykey;
        private string _sslcert_path;
        private string _sslcert_password;
        private string _notify_url;
        private string _siteurl;
        private int _enable;
        private string _memo;
        private decimal _minmoney;

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
        public string Token
        {
            set { _token = value; }
            get { return _token; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string apiid
        {
            set { _apiid = value; }
            get { return _apiid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Secret
        {
            set { _secret = value; }
            get { return _secret; }
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
        public string PayMCHID
        {
            set { _paymchid = value; }
            get { return _paymchid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PayKey
        {
            set { _paykey = value; }
            get { return _paykey; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SSLCERT_PATH
        {
            set { _sslcert_path = value; }
            get { return _sslcert_path; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SSLCERT_PASSWORD
        {
            set { _sslcert_password = value; }
            get { return _sslcert_password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NOTIFY_URL
        {
            set { _notify_url = value; }
            get { return _notify_url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SiteUrl
        {
            set { _siteurl = value; }
            get { return _siteurl; }
        }
        /// <summary>
        /// 1正常2维护3禁用4异常
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
        public decimal MinMoney
        {
            set { _minmoney = value; }
            get { return _minmoney; }
        }
        #endregion Model
    }
}
