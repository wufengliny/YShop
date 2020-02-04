using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类Web_Img(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Web_Img
    {
        public Web_Img()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _imgurl;
        private string _imgulrsmall;
        private string _href;
        private string _memo;
        private DateTime _addtime;
        private int _enabale;
        private int _imgtype;
        private string _opentype;
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
        /// 
        /// </summary>
        public string Imgurl
        {
            set { _imgurl = value; }
            get { return _imgurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImgUlrSmall
        {
            set { _imgulrsmall = value; }
            get { return _imgulrsmall; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Href
        {
            set { _href = value; }
            get { return _href; }
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
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Enabale
        {
            set { _enabale = value; }
            get { return _enabale; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ImgType
        {
            set { _imgtype = value; }
            get { return _imgtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OpenType
        {
            set { _opentype = value; }
            get { return _opentype; }
        }
        /// <summary>
        /// 图片第二个类型 用于区分 系统添加 和其他用途的图片上传
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
