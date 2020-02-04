using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类S_Menu(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class S_Menu
    {
        public S_Menu()
        { }
        #region Model
        private int _id;
        private string _name;
        private int _parentid;
        private string _href;
        private int _type;
        private string _icon;
        private string _target;
        private int _sort;
        private int _adduser;
        private DateTime _addtime;
        private int _lastmodifyuser;
        private DateTime _lastmodifytime;
        private int _enable;
        private string _memo;
        private string _nameParent;

        public string NameParent
        {
            get { return _nameParent; }
            set { _nameParent = value; }
        }
        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 菜单名/菜单类型
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 父级
        /// </summary>
        public int ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// Url链接目标
        /// </summary>
        public string Href
        {
            set { _href = value; }
            get { return _href; }
        }
        /// <summary>
        /// 1.前台，2.会员中心，3.管理后台，4.代理
        /// </summary>
        public int Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Icon
        {
            set { _icon = value; }
            get { return _icon; }
        }
        /// <summary>
        /// 页面类型
        /// </summary>
        public string Target
        {
            set { _target = value; }
            get { return _target; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 添加人
        /// </summary>
        public int AddUser
        {
            set { _adduser = value; }
            get { return _adduser; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 最新修改人
        /// </summary>
        public int LastModifyUser
        {
            set { _lastmodifyuser = value; }
            get { return _lastmodifyuser; }
        }
        /// <summary>
        /// 最新修改时间
        /// </summary>
        public DateTime LastModifyTime
        {
            set { _lastmodifytime = value; }
            get { return _lastmodifytime; }
        }
        /// <summary>
        /// 启用状态
        /// </summary>
        public int Enable
        {
            set { _enable = value; }
            get { return _enable; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        #endregion Model
    }
}
