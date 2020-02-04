using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类Chw_Boat(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Chw_Boat
    {
        public Chw_Boat()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _introduce;
        private string _attention;
        private int _hit;
        private int _sort;
        private DateTime _addtime;
        private string _memo;
        private string _contactman;
        private string _contantphone;
        private string _state;
        private int _maxnum;
        private string _cover;
        private string _pricememo;

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 游艇名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 游艇介绍
        /// </summary>
        public string Introduce
        {
            set { _introduce = value; }
            get { return _introduce; }
        }
        /// <summary>
        /// 注意事项
        /// </summary>
        public string Attention
        {
            set { _attention = value; }
            get { return _attention; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Hit
        {
            set { _hit = value; }
            get { return _hit; }
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
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
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
        /// 联系人，负责人
        /// </summary>
        public string ContactMan
        {
            set { _contactman = value; }
            get { return _contactman; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContantPhone
        {
            set { _contantphone = value; }
            get { return _contantphone; }
        }
        /// <summary>
        /// 上架状态1 待审核  2上架中  3 已下架
        /// </summary>
        public string State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 最多几人
        /// </summary>
        public int MaxNum
        {
            set { _maxnum = value; }
            get { return _maxnum; }
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
        /// 价格说明
        /// </summary>
        public string PriceMemo
        {
            set { _pricememo = value; }
            get { return _pricememo; }
        }
        #endregion Model
    }
}
