using System;
using System.Collections.Generic;
using System.Web;

namespace Yax.Common
{
    /// <summary>修改时间  2015/2/23
    /// 
    /// 生成 Ajax 响应消息 字符串
    /// 数据格式：{"statu":"1","msg":"出错啦~~","data":[{},{}],"nextUrl":"Login.aspx"}
    /// </summary>
    public static class AjaxMsgHelper
    {
        #region 1.0 生成 Ajax消息 字符串 +static string AjaxMsg
        /// <summary>
        /// 生成 Ajax消息 字符串
        /// </summary>
        /// <param name="statu">0:成功 1：异常</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static void AjaxMsg(string statu, string msg)
        {
            AjaxMsgHelper.AjaxMsg(statu, msg, "null", "null");
        }
        /// <summary>
        /// 生成 Ajax消息 字符串
        /// </summary>
        /// <param name="statu">0:成功 1：异常</param>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static void AjaxMsg(string statu, string msg, string data)
        {
            AjaxMsgHelper.AjaxMsg(statu, msg, data, "null");
        }
        /// <summary>
        /// 生成 Ajax消息 字符串
        /// </summary>
        /// <param name="statu">状态用数字表示</param>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <param name="nextUrl"></param>
        /// <returns></returns>
        public static void AjaxMsg(string statu, string msg, string data, string nextUrl)
        {
            //{"statu":"err","msg":"出错啦~~","data":[{},{}],"nextUrl":"Login.aspx"}
            string strMsg = "{\"statu\":\"" + statu + "\",\"msg\":\"" + msg + "\",\"data\":\"" + (string.IsNullOrEmpty(data) ? "null" : data) + "\",\"nextUrl\":\"" + nextUrl + "\"}";
            //直接输出 数据 到 浏览器
            System.Web.HttpContext.Current.Response.Write(strMsg);
        }
        #endregion
    }
}