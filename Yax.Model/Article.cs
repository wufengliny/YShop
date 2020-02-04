using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类Article(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Article
    {
        public Article()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _mark;
        private int _hits;
        private string _ip;
        private int _enable;
        private DateTime _addtime;
        private int _articletypeid;
        private string _cover;
        private string _coversmall;
        private string _autho;
        private int _isindex;
        private DateTime _updatetime;
        private string _detail;
        private int _adduser;
        private string _seokeywords;
        private string _seodescription;
        private int _isrecoommend;
        private int _ishot;
        private string _category;
        private int _sort;

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
        /// 标识文章 的唯一性
        /// </summary>
        public string Mark
        {
            set { _mark = value; }
            get { return _mark; }
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
        /// 
        /// </summary>
        public string IP
        {
            set { _ip = value; }
            get { return _ip; }
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
        public int ArticleTypeID
        {
            set { _articletypeid = value; }
            get { return _articletypeid; }
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
        public string CoverSmall
        {
            set { _coversmall = value; }
            get { return _coversmall; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Autho
        {
            set { _autho = value; }
            get { return _autho; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsIndex
        {
            set { _isindex = value; }
            get { return _isindex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
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
        public int AddUser
        {
            set { _adduser = value; }
            get { return _adduser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SeoKeywords
        {
            set { _seokeywords = value; }
            get { return _seokeywords; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SeoDescription
        {
            set { _seodescription = value; }
            get { return _seodescription; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsRecoommend
        {
            set { _isrecoommend = value; }
            get { return _isrecoommend; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsHot
        {
            set { _ishot = value; }
            get { return _ishot; }
        }
        /// <summary>
        /// 1 （固定  不能添加 可修改 ）2 新闻资讯 
        /// </summary>
        public string Category
        {
            set { _category = value; }
            get { return _category; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        #endregion Model
    }
}
