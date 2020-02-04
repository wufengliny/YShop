using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类ZY_Log(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class ZY_Log
    {
        public ZY_Log()
        { }
        #region Model
        private int _id;
        private int _type;
        private string _browser;
        private string _url;
        private string _ip;
        private int _userid;
        private DateTime _addtime;
        private string _message;
        private string _username;

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 0 :登录日志  1：操作日志2：系统日志
        /// </summary>
        public int Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Browser
        {
            set { _browser = value; }
            get { return _browser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
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
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Addtime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        #endregion Model
    }
}
