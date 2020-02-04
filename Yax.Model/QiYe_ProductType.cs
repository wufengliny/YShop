using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类QiYe_ProductType(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class QiYe_ProductType
    {
        public QiYe_ProductType()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _seokeyword;
        private string _seodescription;

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
        public string SeoKeyword
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
        #endregion Model
    }
}
