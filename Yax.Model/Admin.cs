using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类Admin(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Admin
    {
        public Admin()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _pwd;
        private DateTime _lastlogintime;
        private string _lastloginip;
        private int _logincount;
        private string _regip;
        private DateTime _addtime;
        private DateTime _updatetime;
        private int _effect;
        private string _memo;
        private int _errorcount;
        private DateTime _lasterrtime;
        private string _realname;
        private string _phone;
        private int _kgroup;
        private string _secondpwd;

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
        public string Pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastLoginTime
        {
            set { _lastlogintime = value; }
            get { return _lastlogintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LastLoginIP
        {
            set { _lastloginip = value; }
            get { return _lastloginip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int LoginCount
        {
            set { _logincount = value; }
            get { return _logincount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RegIP
        {
            set { _regip = value; }
            get { return _regip; }
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
        public int Effect
        {
            set { _effect = value; }
            get { return _effect; }
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
        public int ErrorCount
        {
            set { _errorcount = value; }
            get { return _errorcount; }
        }
        /// <summary>
        /// 上一次输入密码错误时间
        /// </summary>
        public DateTime LastErrTime
        {
            set { _lasterrtime = value; }
            get { return _lasterrtime; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 管理员所在的组
        /// </summary>
        public int KGroup
        {
            set { _kgroup = value; }
            get { return _kgroup; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SecondPwd
        {
            set { _secondpwd = value; }
            get { return _secondpwd; }
        }
        #endregion Model
    }
}
