using System;
namespace Entity
{
    /// <summary>
    /// 实体类C_Vedios(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class MC_Vedios
    {
        public MC_Vedios()
        { }
        #region Model

        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 视频标题
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 封面图
        /// </summary>
        public string Cover { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// 国产，欧美 ，日本，韩国 等
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 系列ID  以某个人 或者团队作为一个系列
        /// </summary>
        public int SeriousID { get; set; }
        /// <summary>
        /// 视频价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 视频的域名部分
        /// </summary>
        public string PreUrl { get; set; }
        /// <summary>
        /// 视频地址(以备数据迁移或者域名失效导致域名变更) 此部分只保存 虚拟路径
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 视频时长
        /// </summary>
        public string VedioLong { get; set; }
        /// <summary>
        /// 点击量
        /// </summary>
        public int Hits { get; set; }
        /// <summary>
        /// 收藏数量
        /// </summary>
        public int Likes { get; set; }
        /// <summary>
        /// 点赞数量
        /// </summary>
        public int Goods { get; set; }
        /// <summary>
        /// 视频简介
        /// </summary>
        public string Introduce { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Enable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Actor { get; set; }
        /// <summary>
        /// 排序值 Sort 初始值100000
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 视频来源地址 视频播放地址
        /// </summary>
        public string FromVedioUrl { get; set; }
        /// <summary>
        /// 视频播放页地址
        /// </summary>
        public string FromPageUrl { get; set; }
        /// <summary>
        /// 来源站点名称
        /// </summary>
        public string FromSite { get; set; }
        /// <summary>
        /// 封面图片来源地址
        /// </summary>
        public string FromCoverUrl { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 如果视频收费，如有需要，上传收费视频的部分 作为免费片段，提前预览
        /// </summary>
        public string FreePartUrl { get; set; }
        /// <summary>
        /// 单个付费下载  次数
        /// </summary>
        public int SinglePayDownLoadNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int VIPDownNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FreeDownNum { get; set; }
        #endregion Model
    }
}
