using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类M_Chapter(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class M_Chapter
    {
        public M_Chapter()
        { }
        #region Model
        private int _id;
        private string _name;
        private int _manhuaid;
        private int _enable;
        private DateTime _addtime;
        private int _sort;
        private string _fromurl;

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
        public int ManHuaID
        {
            set { _manhuaid = value; }
            get { return _manhuaid; }
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
        public int Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 来源网址
        /// </summary>
        public string FromUrl
        {
            set { _fromurl = value; }
            get { return _fromurl; }
        }
        #endregion Model
    }
}
