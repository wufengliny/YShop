using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yax.Common.CollectHelp
{
    public class Help80s
    {
        static string Url = "http://www.80s.tw";
        static string Url_Search = "http://www.80s.tw/search";
        /// <summary>
        /// 采集失败返回空字符串
        /// </summary>
        /// <param name="name">搜索关键词</param>
        /// <returns></returns>
        public static string GetSearch_html(string name)
        {
            try
            {
                return Yax.Common.HTTPHelper.GetHtml_01_Post(Url_Search, "keyword=" + name);
            }
            catch
            {
                return "";
            }
        }
    }
}
