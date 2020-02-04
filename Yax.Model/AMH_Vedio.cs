using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类AMH_Vedio(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class AMH_Vedio
    {
        public AMH_Vedio()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _cover;
        private string _tag;
        private string _category;
        private int _isfree;
        private string _url;
        private string _vediolong;
        private int _hits;
        private int _likes;
        private string _area;
        private string _introduce;
        private DateTime _addtime;
        private int _enable;
        private string _actor;
        private int _adduser;
        private int _sort;
        private string _fromvediourl;
        private string _frompageurl;
        private string _fromsite;
        private string _fromvediom3u8;

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
        public string Cover
        {
            set { _cover = value; }
            get { return _cover; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tag
        {
            set { _tag = value; }
            get { return _tag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Category
        {
            set { _category = value; }
            get { return _category; }
        }
        /// <summary>
        /// 1:免费 2不免费
        /// </summary>
        public int IsFree
        {
            set { _isfree = value; }
            get { return _isfree; }
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
        /// 分钟
        /// </summary>
        public string VedioLong
        {
            set { _vediolong = value; }
            get { return _vediolong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Hits
        {
            set { _hits = value; }
            get { return _hits; }
        }
        /// <summary>
        /// 收藏
        /// </summary>
        public int Likes
        {
            set { _likes = value; }
            get { return _likes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Introduce
        {
            set { _introduce = value; }
            get { return _introduce; }
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
        /// 主演
        /// </summary>
        public string Actor
        {
            set { _actor = value; }
            get { return _actor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AddUser
        {
            set { _adduser = value; }
            get { return _adduser; }
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
        /// 
        /// </summary>
        public string FromVedioUrl
        {
            set { _fromvediourl = value; }
            get { return _fromvediourl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FromPageUrl
        {
            set { _frompageurl = value; }
            get { return _frompageurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FromSite
        {
            set { _fromsite = value; }
            get { return _fromsite; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FromVedioM3u8
        {
            set { _fromvediom3u8 = value; }
            get { return _fromvediom3u8; }
        }
        #endregion Model
    }
}
