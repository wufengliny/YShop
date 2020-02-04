using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类M_ManHua(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class M_ManHua
    {
        public M_ManHua()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _searchname;
        private string _upsate;
        private string _author;
        private int _hits;
        private int _sort;
        private string _latestchapter;
        private int _isindex;
        private string _introduce;
        private string _cagegory;
        private int _adduser;
        private string _memo;
        private string _cover;
        private string _fromurl;
        private string _downurl;
        private string _downname;
        private int _enable;
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
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SearchName
        {
            set { _searchname = value; }
            get { return _searchname; }
        }
        /// <summary>
        /// 1 连载中 2 完结
        /// </summary>
        public string UpSate
        {
            set { _upsate = value; }
            get { return _upsate; }
        }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author
        {
            set { _author = value; }
            get { return _author; }
        }
        /// <summary>
        /// 点击数
        /// </summary>
        public int Hits
        {
            set { _hits = value; }
            get { return _hits; }
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
        /// 最新章节
        /// </summary>
        public string LatestChapter
        {
            set { _latestchapter = value; }
            get { return _latestchapter; }
        }
        /// <summary>
        /// 是否首页
        /// </summary>
        public int IsIndex
        {
            set { _isindex = value; }
            get { return _isindex; }
        }
        /// <summary>
        /// 简介
        /// </summary>
        public string Introduce
        {
            set { _introduce = value; }
            get { return _introduce; }
        }
        /// <summary>
        /// 类型
        /// </summary>
        public string Cagegory
        {
            set { _cagegory = value; }
            get { return _cagegory; }
        }
        /// <summary>
        /// 添加人
        /// </summary>
        public int AddUser
        {
            set { _adduser = value; }
            get { return _adduser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Memo
        {
            set { _memo = value; }
            get { return _memo; }
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
        /// 来源网址
        /// </summary>
        public string FromUrl
        {
            set { _fromurl = value; }
            get { return _fromurl; }
        }
        /// <summary>
        /// 下载地址
        /// </summary>
        public string DownUrl
        {
            set { _downurl = value; }
            get { return _downurl; }
        }
        /// <summary>
        /// 下载名称
        /// </summary>
        public string DownName
        {
            set { _downname = value; }
            get { return _downname; }
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
        #endregion Model
    }
}
