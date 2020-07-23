using System;
namespace Entity
{
    /// <summary>
    /// 实体类C_UserLikes(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class MC_UserLikes
    {
        public MC_UserLikes()
        { }
        #region Model

        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int UID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int VedioID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string VedioName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime { get; set; }
        #endregion Model
        public string Cover { get; set; }


    }
}
