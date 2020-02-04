using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类UserLike(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class UserLike
    {
        public UserLike()
        { }
        #region Model
        private int _id;
        private int _uid;
        private int _gid;
        private DateTime _addtime;
        private int _enable;
        private string _name;
        private string _category;

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
        public int UID
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int GID
        {
            set { _gid = value; }
            get { return _gid; }
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
        public int Enable
        {
            set { _enable = value; }
            get { return _enable; }
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
        /// 类型
        /// </summary>
        public string Category
        {
            set { _category = value; }
            get { return _category; }
        }
        #endregion Model
    }
}
