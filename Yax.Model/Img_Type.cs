using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类Img_Type(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Img_Type
    {
        public Img_Type()
        { }
        #region Model
        private int _id;
        private string _name;
        private DateTime _addtime;
        private int _enable;

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
        #endregion Model
    }
}
