
using System;
namespace Entity
{
    /// <summary>
    /// 实体类S_LogOperate(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class MS_LogOperate
    {
        public MS_LogOperate()
        { }
        #region Model

        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string URLReferrer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 操作日志
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 1:管理员2代理 3会员
        /// </summary>
        public int OperatorType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsSensitive { get; set; }
        #endregion Model
    }
}
