using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类PhoneMsg(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PhoneMsg
    {
        public PhoneMsg()
        { }
        #region Model
        private int _id;
        private string _phone;
        private string _msg;
        private DateTime _addtime;
        private int _size;
        private string _memo;
        private string _ip;

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
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Msg
        {
            set { _msg = value; }
            get { return _msg; }
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
        public int Size
        {
            set { _size = value; }
            get { return _size; }
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
        public string IP
        {
            set { _ip = value; }
            get { return _ip; }
        }
        #endregion Model
    }
}
