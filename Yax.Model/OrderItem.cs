using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类OrderItem(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class OrderItem
    {
        public OrderItem()
        { }
        #region Model
        private int _id;
        private string _orderno;
        private int _goodid;
        private int _num;
        private decimal _unitprice;
        private DateTime _addtime;
        private string _buyermessage;
        private string _goodname;
        private string _goodtype;
        private int _enable;
        private string _goodimg;
        private string _goodmemo;
        private string _memo;
        private int _userid;

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
        public int GoodID
        {
            set { _goodid = value; }
            get { return _goodid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Num
        {
            set { _num = value; }
            get { return _num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal UnitPrice
        {
            set { _unitprice = value; }
            get { return _unitprice; }
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
        public string BuyerMessage
        {
            set { _buyermessage = value; }
            get { return _buyermessage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GoodName
        {
            set { _goodname = value; }
            get { return _goodname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GoodType
        {
            set { _goodtype = value; }
            get { return _goodtype; }
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
        public string GoodImg
        {
            set { _goodimg = value; }
            get { return _goodimg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GoodMemo
        {
            set { _goodmemo = value; }
            get { return _goodmemo; }
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
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }


        private int _IsCommented;

        public int IsCommented
        {
            get { return _IsCommented; }
            set { _IsCommented = value; }
        }
        #endregion Model
    }
}
