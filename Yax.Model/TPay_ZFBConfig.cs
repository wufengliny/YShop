using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类TPay_ZFBConfig(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class TPay_ZFBConfig
    {
        public TPay_ZFBConfig()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _appid;
        private string _privatekeypc;
        private string _publickeypc;
        private string _partner;
        private string _privatekeywap;
        private string _publickeywap;
        private DateTime _addtime;
        private int _enable;
        private decimal _minmoney;
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
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 支付宝 : APPID PC
        /// </summary>
        public string APPID
        {
            set { _appid = value; }
            get { return _appid; }
        }
        /// <summary>
        /// 支付宝：商户私钥 PC端 
        /// </summary>
        public string PrivateKeyPC
        {
            set { _privatekeypc = value; }
            get { return _privatekeypc; }
        }
        /// <summary>
        /// 支付宝公钥 对应APPID下的支付宝公钥。
        /// </summary>
        public string PublicKeyPC
        {
            set { _publickeypc = value; }
            get { return _publickeypc; }
        }
        /// <summary>
        /// 合作身份者ID wap
        /// </summary>
        public string Partner
        {
            set { _partner = value; }
            get { return _partner; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PrivateKeyWap
        {
            set { _privatekeywap = value; }
            get { return _privatekeywap; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PublicKeyWap
        {
            set { _publickeywap = value; }
            get { return _publickeywap; }
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
        /// 1正常2维护3禁用4异常
        /// </summary>
        public int Enable
        {
            set { _enable = value; }
            get { return _enable; }
        }
        /// <summary>
        /// 此通道最低充值金额
        /// </summary>
        public decimal MinMoney
        {
            set { _minmoney = value; }
            get { return _minmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        #endregion Model
    }
}
