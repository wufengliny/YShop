using System;
using System.Collections.Generic;
using System.Text;

namespace Yax.Common
{
    public class JscriptHelper
    {
        static string jsHtml = "<link href='/content/css/tishikuang.css' rel='stylesheet' type='text/css' />" +
            "<script src='/content/js/jquery-1.6.1.min.js' type='text/javascript'></script>" +
            "<script src='/content/js/tishikuang.js' type='text/javascript'></script>" +
            "<div id='window_ward'>\n" +
            "</div>\n" +
            "<div id='openbox'>\n" +
            "    <div class=\"public_tishi_top\">\n" +
            "        <a href='javascript:void(0)' class='opclose'></a>\n" +
            "    </div>\n" +
            "    <ul class=\"public_tishi_main\">\n" +
            "        <li class=\"public_tishi_main_left\">\n" +
            "            <img src=\"/content/images/public_tishi2_5.png\" alt=\"\" /></li>\n" +
            "        <li class=\"public_tishi_main_text\">\n" +
            "            <div class='public_tishi_text'>\n" +
            "                <font>系统繁忙，请稍后操作！</font>\n" +
            "            </div>\n" +
            "            <input type='button' class='public_tishi_button' value=' 确 定 ' />\n" +
            "        </li>\n" +
            "    </ul>\n" +
            "    <div class=\"public_tishi_foot\">\n" +
            "    </div>\n" +
            "</div>\n";

        /// <summary>
        /// 弹出JavaScript小窗口
        /// </summary>
        public static void Alert(string message)
        {
            string js = @" " + jsHtml + "<Script language='JavaScript'>GetOpenAlert('" + message + "');</Script>";
            System.Web.HttpContext.Current.Response.Write(js);
            System.Web.HttpContext.Current.Response.End();
        }
        /// <summary>
        /// js跳转到另一个页面
        /// </summary>
        public static void Location(string url)
        {
            string js = @" <Script language='JavaScript'>   window.location=' " + url + " ';</Script>";
            System.Web.HttpContext.Current.Response.Write(js);
        }
        /// <summary>
        /// 弹出JavaScript小窗口，并返回 类型为1
        /// </summary>
        public static void AlertReturn(string message)
        {
            string js = @" " + jsHtml + "<Script language='JavaScript'>GetOpenAlertReturn('" + message + "');</Script>";
            System.Web.HttpContext.Current.Response.Write(js);
            System.Web.HttpContext.Current.Response.End();
        }
        /// <summary>
        ///注册页面 弹出JavaScript小窗口，并返回 类型为1
        /// </summary>
        public static void AlertReturnByReg(string message)
        {
            string js = @" " + jsHtml + "<Script language='JavaScript'>  GetOpenAlert('" + message + "',4);</Script>";
            System.Web.HttpContext.Current.Response.Write(js);
            System.Web.HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 弹出JavaScript小窗口，并跳转到另一个页面
        /// </summary>
        public static void AlertTo(string message, string goToUrl)
        {
            string js = @" " + jsHtml + "<Script language='JavaScript'>  GetOpenAlert('" + message + "',2,'" + goToUrl + "');</Script>";
            System.Web.HttpContext.Current.Response.Write(js);


        }
        /// <summary>
        /// Js跳到到父级页面
        /// </summary>
        public static void AlertToParent(string message, string goToUrl)
        {
            string js = @" " + jsHtml + "<Script language='JavaScript'>  GetOpenAlert('" + message + "',3,'" + goToUrl + "');</Script>";

            System.Web.HttpContext.Current.Response.Write(js);

        }
        /// <summary>
        /// 弹出JavaScript小窗口，并关闭
        /// </summary>
        public static void AlertClose(string message)
        {
            string js = @" " + jsHtml + "<Script language='JavaScript'>  GetOpenAlert('" + message + "'); </Script>";
            System.Web.HttpContext.Current.Response.Write(js);
        }
        /// <summary>
        /// Js弹出确认框
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string Confirm(string message)
        {
            string js = @" " + jsHtml + " return confirm('" + message + "')";
            return js;
        }
        /// <summary>
        /// Js关闭窗口
        /// </summary>
        public static string Close()
        {
            string js = @"   return window.close()";
            return js;
        }
        /// <summary>
        /// Js打开新窗口
        /// </summary>
        public static void OpenNewWindow(string url, int width, int height)
        {
            string js = @" <Script language='javascript'>window.open('" + url + "','','width=" + width + ",height=" + height + "');</script>";
            System.Web.HttpContext.Current.Response.Write(js);
        }
        /// <summary>
        /// 刷新窗口
        /// </summary>
        public static void RefreshParent()
        {
            string js = @"  <Script language='JavaScript'>
                    window.opener.parent.location.reload();window.close();
                  </Script>";
            System.Web.HttpContext.Current.Response.Write(js);
        }

    }
}
