using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类ShopGood(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class ShopGood
    {
        public ShopGood()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _searchname;
        private string _goodno;
        private string _color;
        private string _size;
        private string _source;
        private int _cid;
        private string _detail;
        private decimal _price;
        private decimal _saleprice;
        private DateTime _addtime;
        private DateTime _updatetime;
        private int _enable;
        private string _cover;
        private string _memo;
        private int _jifen;
        private int _ishot;
        private int _istop;
        private int _isnew;

 
        private int _isrecomand;
        private string _coversmall;
        private int _isdown;
        private decimal _postfee;
        private string _ip;
        private string _namefirst;
        private string _categaryName;


        private int _stocknum;
        private int _hits;

        /// <summary>
        /// 
        /// </summary>
        public int StockNum
        {
            set { _stocknum = value; }
            get { return _stocknum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Hits
        {
            set { _hits = value; }
            get { return _hits; }
        }
        public int IsNew
        {
            get { return _isnew; }
            set { _isnew = value; }
        }
        public string CategaryName
        {
            get { return _categaryName; }
            set { _categaryName = value; }
        }
       
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 搜索名称
        /// </summary>
        public string SearchName
        {
            set { _searchname = value; }
            get { return _searchname; }
        }
        /// <summary>
        /// 商品编码
        /// </summary>
        public string GoodNO
        {
            set { _goodno = value; }
            get { return _goodno; }
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
        /// 尺寸
        /// </summary>
        public string Size
        {
            set { _size = value; }
            get { return _size; }
        }
        /// <summary>
        /// 商品来源
        /// </summary>
        public string Source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// 商品的分类ＩＤ
        /// </summary>
        public int CID
        {
            set { _cid = value; }
            get { return _cid; }
        }
        /// <summary>
        /// 商品的详细描述
        /// </summary>
        public string Detail
        {
            set { _detail = value; }
            get { return _detail; }
        }
        /// <summary>
        /// 商品的原价格
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 打折后的售卖价格
        /// </summary>
        public decimal SalePrice
        {
            set { _saleprice = value; }
            get { return _saleprice; }
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
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
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
        /// 商品的图片封面
        /// </summary>
        public string Cover
        {
            set { _cover = value; }
            get { return _cover; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// 够买改商品赠送的积分
        /// </summary>
        public int JiFen
        {
            set { _jifen = value; }
            get { return _jifen; }
        }
        /// <summary>
        /// 是否热销
        /// </summary>
        public int IsHot
        {
            set { _ishot = value; }
            get { return _ishot; }
        }
        /// <summary>
        /// 置顶
        /// </summary>
        public int IsTop
        {
            set { _istop = value; }
            get { return _istop; }
        }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public int IsRecomand
        {
            set { _isrecomand = value; }
            get { return _isrecomand; }
        }
        /// <summary>
        /// 封面缩略图
        /// </summary>
        public string CoverSmall
        {
            set { _coversmall = value; }
            get { return _coversmall; }
        }
        /// <summary>
        /// 是否下架  1 下架 0：上架
        /// </summary>
        public int IsDown
        {
            set { _isdown = value; }
            get { return _isdown; }
        }
        /// <summary>
        /// 邮费
        /// </summary>
        public decimal PostFee
        {
            set { _postfee = value; }
            get { return _postfee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IP
        {
            set { _ip = value; }
            get { return _ip; }
        }
        #endregion Model


        #region view
        public string Namefirst
        {
            get { return _namefirst; }
            set { _namefirst = value; }
        }
        private string namesecond;

        public string Namesecond
        {
            get { return namesecond; }
            set { namesecond = value; }
        }

        private int _pid;

        public int Pid
        {
            get { return _pid; }
            set { _pid = value; }
        } 
        #endregion
    }
}
