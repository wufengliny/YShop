using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类AdminGroup(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class AdminGroup
    {
        public AdminGroup()
        { }
        #region Model
        private int _id;
        private string _name;
        private DateTime _addtime;
        private int _enable;
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
        public string Memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        #endregion Model
    }
}
