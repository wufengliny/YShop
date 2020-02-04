using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类Chw_Order(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Chw_Order
    {
        public Chw_Order()
        { }
        #region Model
        private int _id;
        private string _orderno;
        private int _uid;
        private DateTime _begintime;
        private DateTime _endtime;
        private int _boatid;
        private string _memo;
        private DateTime _addtime;
        private string _state;
        private int _peoplenum;
        private string _phone;

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
        public int UID
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime BeginTime
        {
            set { _begintime = value; }
            get { return _begintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int BoatID
        {
            set { _boatid = value; }
            get { return _boatid; }
        }
        /// <summary>
        /// 订单备注
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
        /// <summary>
        /// 1 待审核  2已审核 3 已取消
        /// </summary>
        public string State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 人数
        /// </summary>
        public int PeopleNum
        {
            set { _peoplenum = value; }
            get { return _peoplenum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        #endregion Model
    }
}
