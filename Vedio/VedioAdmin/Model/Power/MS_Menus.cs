using System;
namespace Entity
{
    /// <summary>
    /// 实体类S_Menus(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class MS_Menus
    {
        public MS_Menus()
        { }
        #region Model

        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public int ParentID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Target { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int AddUser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Enable { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        ///1:页面2 按钮
        /// </summary>
        public int MenuType { get; set; }
        /// <summary>
        /// 权限标识（唯一）
        /// </summary>
        public string Mark { get; set; }
        #endregion Model
    }
}
