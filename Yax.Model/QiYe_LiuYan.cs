using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类QiYe_LiuYan(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class QiYe_LiuYan
    {
        public QiYe_LiuYan()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _name;
        private string _email;
        private string _detail;
        private DateTime _addtime;
        private int _enable;
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
        public string Title
        {
            set { _title = value; }
            get { return _title; }
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
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Detail
        {
            set { _detail = value; }
            get { return _detail; }
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
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        #endregion Model
    }
}
