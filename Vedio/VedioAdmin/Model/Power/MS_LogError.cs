using System;
namespace Entity
{
    /// <summary>
    /// 实体类S_LogError(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class MS_LogError
    {
        public MS_LogError()
        { }
        #region Model

        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StackTrace { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// 如果是会员或者管理员操作时发生的错误记录 当前操作员的信息
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        #endregion Model
    }
}
