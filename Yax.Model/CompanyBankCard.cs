using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类CompanyBankCard(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class CompanyBankCard
    {
        public CompanyBankCard()
        { }
        #region Model
        private int _id;
        private string _bankname;
        private string _cardowner;
        private string _cardno;
        private int _enable;
        private DateTime _addtime;
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
        public string BankName
        {
            set { _bankname = value; }
            get { return _bankname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CardOwner
        {
            set { _cardowner = value; }
            get { return _cardowner; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CardNO
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
        public string Memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        #endregion Model
    }
}
