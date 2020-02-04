using System;
using System.Collections.Generic;
using System.Text;

namespace Yax.Common
{
    /// <summary>
    /// 常用公共变量  
    /// </summary>
    public class PubStr
    {
        /// <summary>
        /// 总管理员Cookie名
        /// </summary>
        public const string ManageCookieName = "Manage";
        /// <summary>
        /// 管理员登陆过去时间 浏览器关闭过期
        /// </summary>
        public const int ManageCookieExpireTime = 0; 

        /// <summary>
        /// 会员Cookie名
        /// </summary>
        public const string MemberCookieName = "Member";
        /// <summary>
        /// 会员登陆有效期 7天
        /// </summary>
        public const int MemberCookieExpireTime = 10080; //7 * 24 * 60=10080; 分钟  7天

        /// <summary>
        /// 商家Cookie名
        /// </summary>
        public const string ShangJiaCookieName = "ShangJia";

        /// <summary>
        /// 商家登陆有效期 7天
        /// </summary>
        public const int ShangJiaCookieExpireTime = 10080; //7 * 24 * 60=10080; 分钟  7天

        /// <summary>
        /// 验证码 cookie名
        /// </summary>
        public const string CheckCodeCookieName = "CheckCode";
        /// <summary>
        /// 验证码 cookie有效期
        /// </summary>
        public const int CheckCodeCookieExpireTime = 10; //10 分钟
        /// <summary>
        /// 前端其他Cookie名
        /// </summary>
        public const string WebCookieName = "Web";
        /// <summary>
        /// 前端其他Cookie 有效期 浏览器时间
        /// </summary>
        public const int WebCookieExpireTime = 0; //
        /// <summary>
        /// 文件上传保存路径
        /// </summary>
        public const string UpLoadPath = "/UploadFile/";

        /// <summary>
        /// 远程获取文件地址
        /// </summary>
        public const string RemotePicPath = "/RemotePicPath/";
        /// <summary>
        /// 一次性上传文件 临时文件
        /// </summary>
        public const string TempUpLoadPath = "/TempUpFile/";

        public const string WriteFilePath = "/WriteFile/";
        /// <summary>
        /// 上传图片大小限制为5M
        /// </summary>
        public const int UpPicMaxSize5M = 5120;
        /// <summary>
        /// 上传图片大小限制为10M
        /// </summary>
        public const int UpPicMaxSize10M = 10240;
        /// <summary>
        /// 上传允许的图片后缀类型
        /// </summary>
        public const string AllowPicExtNames = "jpg,jpeg,png,gif,bmp";
        /// <summary>
        /// 上传允许的音乐后缀类型
        /// </summary>
        public const string AllowMusicExtNames = "mp1,mp2,mp3,mp4,wma,wmv,aac,mid,wav,mpg,mpeg,vqf,rm,rmvb,avi,cda";



    }
}
