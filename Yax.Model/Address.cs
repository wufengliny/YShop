using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类Address(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Address
    {
        public Address()
        { }
        #region Model
        private int _id;
        private string _receivename;
        private string _country;
        private string _province;
        private string _city;
        private string _town;
        private string _detailaddress;
        private string _phone;
        private string _addresscode;
        private int _enable;
        private DateTime _addtime;
        private int _userid;
        private int _defaltadress;
        private int _addressid;

        public int Addressid
        {
            get { return _addressid; }
            set { _addressid = value; }
        }
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
        public string ReceiveName
        {
            set { _receivename = value; }
            get { return _receivename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Country
        {
            set { _country = value; }
            get { return _country; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Province
        {
            set { _province = value; }
            get { return _province; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Town
        {
            set { _town = value; }
            get { return _town; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DetailAddress
        {
            set { _detailaddress = value; }
            get { return _detailaddress; }
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
        public string AddressCode
        {
            set { _addresscode = value; }
            get { return _addresscode; }
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
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 0  不是默认地址  1 是默认地址
        /// </summary>
        public int DefaltAdress
        {
            set { _defaltadress = value; }
            get { return _defaltadress; }
        }
        #endregion Model
    }
}
