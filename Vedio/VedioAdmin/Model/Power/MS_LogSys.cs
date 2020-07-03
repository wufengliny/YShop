using System;
namespace Entity
{
    /// <summary>
    /// 实体类S_LogSys(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class MS_LogSys
    {
        public MS_LogSys()
        { }
        #region Model

        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 1结算日志 2 返水日志 3 彩票采集   4平台游戏下注记录采集 10其他
        /// </summary>
        public int LogType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Memo { get; set; }
        #endregion Model
    }
}
