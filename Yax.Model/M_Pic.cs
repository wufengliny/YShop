using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类M_Pic(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class M_Pic
    {
        public M_Pic()
        { }
        #region Model
        private int _id;
        private string _imgurl;
        private int _enable;
        private DateTime _addtime;
        private int _sort;
        private int _chapterid;
        private int _pagenum;
        private string _frompic;

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
        public string ImgUrl
        {
            set { _imgurl = value; }
            get { return _imgurl; }
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
        /// 
        /// </summary>
        public int ChapterID
        {
            set { _chapterid = value; }
            get { return _chapterid; }
        }
        /// <summary>
        /// 页数
        /// </summary>
        public int PageNum
        {
            set { _pagenum = value; }
            get { return _pagenum; }
        }
        /// <summary>
        /// 来源图片网址
        /// </summary>
        public string FromPic
        {
            set { _frompic = value; }
            get { return _frompic; }
        }
        #endregion Model
    }
}
