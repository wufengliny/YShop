using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类L_Data(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class L_Data
    {
        public L_Data()
        { }
        #region Model
        private int _id;
        private string _keyname;
        private string _data;
        private string _searchword;
        private DateTime _addtime;
        private int _enable;
        private int _datatypeid;

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
        public string KeyName
        {
            set { _keyname = value; }
            get { return _keyname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Data
        {
            set { _data = value; }
            get { return _data; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SearchWord
        {
            set { _searchword = value; }
            get { return _searchword; }
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
        public int DataTypeID
        {
            set { _datatypeid = value; }
            get { return _datatypeid; }
        }
        #endregion Model
    }
}
