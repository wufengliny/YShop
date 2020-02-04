using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类QiYe_Product(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class QiYe_Product
    {
        public QiYe_Product()
        { }
        #region Model
        private int _id;
        private string _name;
        private int _producttypeid;
        private string _introduce;
        private string _productno;
        private string _seokeyword;
        private string _seodescription;
        private int _isindex;
        private decimal _price;
        private string _size;
        private string _color;
        private string _cover;
        private int _hits;
        private DateTime _addtime;
        private int _enable;
        private string _detail;

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
        public int ProductTypeID
        {
            set { _producttypeid = value; }
            get { return _producttypeid; }
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
        /// 产品序列号
        /// </summary>
        public string ProductNO
        {
            set { _productno = value; }
            get { return _productno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Seokeyword
        {
            set { _seokeyword = value; }
            get { return _seokeyword; }
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
        public int IsIndex
        {
            set { _isindex = value; }
            get { return _isindex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 尺寸
        /// </summary>
        public string Size
        {
            set { _size = value; }
            get { return _size; }
        }
        /// <summary>
        /// 颜色
        /// </summary>
        public string Color
        {
            set { _color = value; }
            get { return _color; }
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
        public int Hits
        {
            set { _hits = value; }
            get { return _hits; }
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
        public string Detail
        {
            set { _detail = value; }
            get { return _detail; }
        }
        #endregion Model
    }
}
