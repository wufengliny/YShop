using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类UserLoginIP(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class UserLoginIP
    {
        public UserLoginIP()
        { }
        #region Model
        private int _id;
        private string _ip;
        private int _count;
        private int _uid;
        private string _account;

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
        public string IP
        {
            set { _ip = value; }
            get { return _ip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            set { _count = value; }
            get { return _count; }
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
        public string Account
        {
            set { _account = value; }
            get { return _account; }
        }
        #endregion Model
    }
}
