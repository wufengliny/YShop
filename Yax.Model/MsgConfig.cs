using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类MsgConfig(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class MsgConfig
    {
        public MsgConfig()
        { }
        #region Model
        private int _id;
        private string _qiyeid;
        private string _account;
        private string _pwd;
        private string _owner;
        private DateTime _addtime;
        private string _contentpre;
        private string _url;
        private int _daymax;
        private int _userdaymax;

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
        public string QIYeID
        {
            set { _qiyeid = value; }
            get { return _qiyeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Account
        {
            set { _account = value; }
            get { return _account; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string owner
        {
            set { _owner = value; }
            get { return _owner; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Addtime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ContentPre
        {
            set { _contentpre = value; }
            get { return _contentpre; }
        }
        /// <summary>
        /// 短信接口网关地址
        /// </summary>
        public string URL
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 每日短信条数上限
        /// </summary>
        public int DayMax
        {
            set { _daymax = value; }
            get { return _daymax; }
        }
        /// <summary>
        /// 单个会员每日短信条数上限
        /// </summary>
        public int UserDayMax
        {
            set { _userdaymax = value; }
            get { return _userdaymax; }
        }
        #endregion Model
    }
}
