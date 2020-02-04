using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace Yax.Common
{
    public class PageHelper
    {
        #region 变量

        public static string WhereStr;
        private static int PageSize;
        private static int TotalCount;
        private static int PageIndex;


        private static int _PageTotal;
        private static int PageTotal
        {
            get
            {
                PageTotal = (TotalCount - 1) / PageSize + 1;
                return _PageTotal;
            }
            set { PageHelper._PageTotal = value; }
        }
        #endregion

       
        public static string GetPage(int pageIndex, int pageSize, int totalCount,string strwhere)
        {
            if(string.IsNullOrEmpty(strwhere))
            {
                strwhere = "?aas=1";
            }
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
            WhereStr = strwhere;
            Regex re = new Regex("&pagenow=[\\d]*");
            WhereStr= re.Replace(WhereStr,"");
            return GetPageStr3();  
        }
        public static string GetPage4(int pageIndex, int pageSize, int totalCount, string strwhere)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
            WhereStr = strwhere;
            Regex re = new Regex("&pagenow=[\\d]*");
            WhereStr = re.Replace(WhereStr, "");
            return GetPageStr4();
        }
        public static string GetPage5(int pageIndex, int pageSize, int totalCount, string strwhere)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
            WhereStr = strwhere;
            Regex re = new Regex("&pagenow=[\\d]*");
            WhereStr = re.Replace(WhereStr, "");
            return GetPageStr5();
        }

        public static string GetPage1(int pageIndex, int pageSize, int totalCount, string strwhere)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
            WhereStr = strwhere;
            Regex re = new Regex("&pagenow=[\\d]*");
            WhereStr = re.Replace(WhereStr, "");
            return GetPageStr1();
        }

        private static string GetPageStr1()
        {
            StringBuilder sb = new StringBuilder();
            if (PageIndex > 1)
            {
                sb.AppendLine(" <a href=\"" + WhereStr + "&pagenow=1\">首页</a> ");
                sb.AppendLine(" <a href=\"" + WhereStr + "&pagenow=" + (PageIndex - 1).ToString() + "\" >上一页</a>");
            }
            else
            {
                sb.Append(" <span class='PreSpan'>首页</span>");
                sb.Append(" <span class='PreSpan'>上一页</span>");
            }
            if (PageIndex < PageTotal)
            {
                sb.Append("<a  href=\"" + WhereStr + "&pagenow=" + (PageIndex + 1).ToString() + "\" >下一页</a>");
                sb.Append(" <a href=\"" + WhereStr + "&pagenow=" + PageTotal + "\" >尾页</a>");
            }
            else
            {
                sb.Append(" <span class='PreSpan'>下一页</span>");
                sb.Append(" <span class='PreSpan'>尾页</span>");
            }
            sb.Append("共" + TotalCount + "条记录,当前:" + PageIndex + "/" + PageTotal + "");
            return sb.ToString();
        }


        private static string GetPageStr3()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul class=\"pagination\">");
           
            if (PageIndex > 1)
            {
                sb.Append(" <li><a href=\"" + WhereStr + "&pagenow=1\">首页</a></li>");
                sb.Append(" <li><a href=\"" + WhereStr + "&pagenow=" + (PageIndex - 1).ToString() + "\">上一页</a></li>");
            }
            else
            {
                sb.Append(" <li><a  href=\"#this\" >首页</a></li>");
                sb.Append(" <li><a  href=\"#this\" >上一页</a></li>");
            }
            if (PageIndex < PageTotal)
            {
                sb.Append(" <li><a  href=\"" + WhereStr + "&pagenow=" + (PageIndex + 1).ToString() + "\" >下一页</a></li>");
                sb.Append(" <li><a href=\"" + WhereStr + "&pagenow=" + PageTotal + "\" >尾页</a></li>");
            }
            else
            {
                sb.Append(" <li><a  href=\"#this\">下一页</a></li>");
                sb.Append(" <li><a  href=\"#this\" >尾页</a></li>");
            }
            sb.Append(" <li><a href=\"#this\">共" + TotalCount + "条记录,当前：" + PageIndex + "/" + PageTotal + "</a></li>");
            sb.Append("</ul>");
            return sb.ToString();
        }

        private static string GetPageStr4()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"Pagination_tow\">");
            sb.Append("<div class=\"right\">");
            sb.Append("共" + TotalCount + "条记录,当前:" + PageIndex + "/" + PageTotal + "");
            sb.Append("</div>");
            sb.Append("<div class=\"right\">");
            if (PageIndex > 1)
            {
                sb.Append(" <a href=\"" + WhereStr + "&pagenow=1\">首页</a>");
                sb.Append(" <a href=\"" + WhereStr + "&pagenow=" + (PageIndex - 1).ToString() + "\">上一页</a>");
            }
            else
            {
                sb.Append(" <a  href=\"#this\" >首页</a>");
                sb.Append("<a  href=\"#this\" >上一页</a>");
            }
            if (PageIndex < PageTotal)
            {
                sb.Append("<a  href=\"" + WhereStr + "&pagenow=" + (PageIndex + 1).ToString() + "\" >下一页</a>");
                sb.Append(" <a href=\"" + WhereStr + "&pagenow=" + PageTotal + "\" >尾页</a>");
            }
            else
            {
                sb.Append(" <a  href=\"#this\">下一页</a>");
                sb.Append("<a  href=\"#this\" >尾页</a>");
            }
            sb.Append("</div>");
            sb.Append("</div>");
            return sb.ToString();
        }

        private static string GetPageStr5()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"Paging\">");
            sb.AppendLine("<div class=\"Pagination\">");
            if (PageIndex > 1)
            {
                sb.AppendLine(" <a href=\"" + WhereStr + "&pagenow=1\">首页</a> ");
                sb.AppendLine(" <a href=\"" + WhereStr + "&pagenow=" + (PageIndex - 1).ToString() + "\" class=\"pn-prev disabled\">上一页</a>");
            }
            else
            {
                sb.Append(" <a  href=\"#this\" >首页</a>");
                sb.Append("<a  href=\"#this\" >上一页</a>");
            }
            if (PageIndex < PageTotal)
            {
                sb.Append("<a  href=\"" + WhereStr + "&pagenow=" + (PageIndex + 1).ToString() + "\" >下一页</a>");
                sb.Append(" <a href=\"" + WhereStr + "&pagenow=" + PageTotal + "\" >尾页</a>");
            }
            else
            {
                sb.Append(" <a  href=\"#this\">下一页</a>");
                sb.Append("<a  href=\"#this\" >尾页</a>");
            }
            sb.Append("共" + TotalCount + "条记录,当前:" + PageIndex + "/" + PageTotal + "");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            return sb.ToString();
        }


    }
}
