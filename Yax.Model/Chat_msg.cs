using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类Chat_msg(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Chat_msg
    {
        public Chat_msg()
        { }
        #region Model
        private int _id;
        private int _fromid;
        private string _path;
        private string _msg;
        private DateTime _addtime;

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
        public int FromID
        {
            set { _fromid = value; }
            get { return _fromid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Path
        {
            set { _path = value; }
            get { return _path; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string msg
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
        #endregion Model
    }
}
