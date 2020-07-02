using System;
namespace Entity
{
    /// <summary>
    /// 实体类S_LogLogin(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class MS_LogLogin
    {
        public MS_LogLogin()
        { }
        #region Model

        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 1:管理员登录2代理登录 3会员登录
        /// </summary>
        public int OperatorType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 管理员存的管理员ID,会员存的会员ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LoginUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 1登录成功 2登录失败
        /// </summary>
        public int Statu { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
        #endregion Model
    }
}
