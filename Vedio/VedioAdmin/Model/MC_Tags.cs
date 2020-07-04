using System;
namespace Entity
{
    /// <summary>
    /// 实体类C_Tags(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class MC_Tags
    {
        public MC_Tags()
        { }
        #region Model

        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 名称（名称添加后不可编辑）
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 排序值
        /// </summary>
        public int Sort { get; set; }
        #endregion Model
    }
}
