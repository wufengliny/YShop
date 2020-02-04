using System;
using System.Collections.Generic;
using System.Web;

namespace Yax.Common
{
    /// <summary>
    /// Cookie操作
    /// </summary>
    public class Cookies
    {
        #region 删除cookies
        /// <summary>
        /// 删除cookies
        /// </summary>
        /// <param name="systemname"></param>
        /// <param name="cookiename"></param>
        public static void DeleteCookies(string cookiename)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            if (null != cookie)
            {
                cookie.Values.Clear();
                cookie.Expires = DateTime.Now.AddDays(-1);
                //由于 Cookie 在用户的计算机中，因此无法将其直接移除。但是，可以让浏览器来为您删除 Cookie。 
                //创建一个与要删除的 Cookie 同名的新 Cookie，并将该 Cookie 的到期日期设置为早于当前日期的某个日期。 
                //当浏览器检查 Cookie 的到期日期时，浏览器便会丢弃这个现已过期的 Cookie。  
                HttpContext.Current.Response.AppendCookie(cookie);
                cookie = HttpContext.Current.Request.Cookies[cookiename];
            }
        } 
        #endregion

        #region 添加/修改Cookies
        /// <summary>
        /// 添加/修改Cookies
        /// </summary>
        /// <param name="cookiename">Cookies名称</param>
        /// <param name="name">键名称</param>
        /// <param name="value">cookie值</param>
        /// <param name="Exp">过期时间（分钟）</param>
        public static void AddCookies(string cookiename, string name, Object value, int Exp)
        {
            if (null == value) return;
            string _valueString = "";
            if (value.GetType() == typeof(System.String) || value.GetType() == typeof(System.Int32))
            {
                _valueString = value.ToString();
            }
            else
            {
                _valueString = Utils.Serializer(value);
            }
            string _value = HttpUtility.UrlEncode(_valueString);
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            if (null == cookie)
            {
                cookie = new HttpCookie(cookiename);
                cookie.Values.Add(name, _value);
            }
            else
            {
                cookie.Values[name] = _value;
            }

            if (0 != Exp)
            {
                cookie.Expires = DateTime.Now.AddMinutes(Exp);
            }
            HttpContext.Current.Response.AppendCookie(cookie);
        } 
        #endregion

        #region 获取Cookies
        /// <summary>
        /// 获取Cookies
        /// </summary>
        /// <param name="cookiename">Cookies名称</param>
        /// <param name="name">键名称</param>
        /// <returns></returns>
        public static string GetCookies(string cookiename, string name)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            if (null != cookie && cookie.HasKeys && null != cookie.Values[name])
            {
                return HttpUtility.UrlDecode(cookie.Values[name]);
            }
            return null;
        } 
        #endregion
    }
}