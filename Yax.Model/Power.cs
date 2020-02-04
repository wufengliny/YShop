using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类Power(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Power
    {
        public Power()
        { }
        #region Model
        private int _id;
        private string _menuid;
        private string _menutype;
        private int _admingroupid;
        private string _mark;

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public string MenuID
        {
            set { _menuid = value; }
            get { return _menuid; }
        }
        /// <summary>
        /// 企业后台 聊天后台  商城后台 或者其他
        /// </summary>
        public string MenuType
        {
            set { _menutype = value; }
            get { return _menutype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AdminGroupID
        {
            set { _admingroupid = value; }
            get { return _admingroupid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mark
        {
            set { _mark = value; }
            get { return _mark; }
        }
        #endregion Model
    }
}
