using System;
namespace Entity
{
    /// <summary>
    /// 实体类C_Serious(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class MC_Serious
    {
        public MC_Serious()
        { }
        #region Model

        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Sort { get; set; }
        #endregion Model
    }
}
