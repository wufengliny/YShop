using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类GoodsUrl(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class GoodsUrl
    {
        public GoodsUrl()
        { }
        #region Model
        private int _id;
        private string _url;
        private string _urlsmalll;
        private int _enable;
        private int _gid;

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
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UrlSmalll
        {
            set { _urlsmalll = value; }
            get { return _urlsmalll; }
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
        public int GID
        {
            set { _gid = value; }
            get { return _gid; }
        }
        #endregion Model
    }
}
