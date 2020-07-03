using System;

namespace Entity
{
    /// <summary>
    ///S_Config
    /// </summary>	
    /// <param name="ModifiedTime">2015/1/9 19:49:01</param>
    /// <param name="Author">System</param>
    public class MS_Config
    {

        /// <summary>
        /// ID
        /// </summary>		
        public int ID { get; set; }
        /// <summary>
        /// 标识(唯一)
        /// </summary>		
        public string key { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 值
        /// </summary>	
        public string Value { get; set; }
        /// <summary>
        /// 分组
        /// </summary>		
        public string Group { get; set; }
        /// <summary>
        /// CanEdit
        /// </summary>		
        public int CanEdit { get; set; }
        /// <summary>
        /// CanDelete
        /// </summary>		
        public int CanDelete { get; set; }
        /// <summary>
        /// 添加人
        /// </summary>		
        public int AddUser { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>		
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 最新修改人
        /// </summary>		
        public int LastModifyUser { get; set; }
        /// <summary>
        /// 最新修改时间
        /// </summary>		
        public DateTime LastModifyTime { get; set; }
        /// <summary>
        /// 启用状态
        /// </summary>		
        public int Enable { get; set; }
        /// <summary>
        /// 备注
        /// </summary>		
        public string Memo { get; set; }

        public int Sort { get; set; }

    }
}