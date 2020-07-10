using System;
namespace Entity
{
    /// <summary>
    /// 实体类S_User(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class MS_User
    {
        public MS_User()
        { }
        #region Model

        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string GUID { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 唯一
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 安全密码，二级密码
        /// </summary>
        public string SecurePwd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Sex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastLoginTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LastLoginIP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int LoginCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RegIP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RegURL { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 0 邮箱注册  1：手机注册 2:一般注册（无邮箱，手机） 3后台添加 4 代理添加
        /// </summary>
        public int RegType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Enable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ErrorCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastErrTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string QQ { get; set; }
        /// <summary>
        /// 会员的积分数
        /// </summary>
        public int JIFen { get; set; }
        /// <summary>
        /// 点券 不可提现
        /// </summary>
        public int DianQuan { get; set; }
        /// <summary>
        /// 会员，代理
        /// </summary>
        public string UserType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int AgentID { get; set; }
        /// <summary>
        /// 0：非VIP 1：VIP
        /// </summary>
        public bool VIP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime VIPEndTime { get; set; }
        #endregion Model
    }
}
