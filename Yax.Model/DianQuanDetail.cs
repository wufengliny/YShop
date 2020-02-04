using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类DianQuanDetail(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class DianQuanDetail
    {
        public DianQuanDetail()
        { }
        #region Model
        private int _id;
        private int _prejifen;
        private int _jifen;
        private string _memo;
        private DateTime _addtime;
        private int _uid;
        private int _afterjifen;
        private string _account;

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
        public int PreJiFen
        {
            set { _prejifen = value; }
            get { return _prejifen; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Jifen
        {
            set { _jifen = value; }
            get { return _jifen; }
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
        public int UID
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AfterJIfen
        {
            set { _afterjifen = value; }
            get { return _afterjifen; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Account
        {
            set { _account = value; }
            get { return _account; }
        }
        #endregion Model
    }
}
