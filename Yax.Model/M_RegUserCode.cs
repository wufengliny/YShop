using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类M_RegUserCode(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class M_RegUserCode
    {
        public M_RegUserCode()
        { }
        #region Model
        private int _id;
        private int _agentid;
        private string _regcode;
        private string _agentaccount;
        private int _usetime;
        private DateTime _addtime;
        private int _reguid;
        private string _regaccount;
        private DateTime _regtime;
        private int _rtype;
        private string _memo;

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
        public int AgentID
        {
            set { _agentid = value; }
            get { return _agentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RegCode
        {
            set { _regcode = value; }
            get { return _regcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AgentAccount
        {
            set { _agentaccount = value; }
            get { return _agentaccount; }
        }
        /// <summary>
        /// 0 未使用 1 已使用
        /// </summary>
        public int UseTime
        {
            set { _usetime = value; }
            get { return _usetime; }
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
        /// 使用者的UID
        /// </summary>
        public int RegUID
        {
            set { _reguid = value; }
            get { return _reguid; }
        }
        /// <summary>
        /// 使用者账号
        /// </summary>
        public string RegAccount
        {
            set { _regaccount = value; }
            get { return _regaccount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime RegTime
        {
            set { _regtime = value; }
            get { return _regtime; }
        }
        /// <summary>
        /// 1 永久VIP 2年VIP 
        /// </summary>
        public int RType
        {
            set { _rtype = value; }
            get { return _rtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        #endregion Model
    }
}
