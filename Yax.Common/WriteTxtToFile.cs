using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Yax.Common
{
    public class WriteTxtToFile
    {


        /// <summary>
        /// 将文本些入指定文件类型
        /// </summary>
        /// <param name="msg">文本信息</param>
        /// <param name="FileType">eg:.txt .html  .css .js 等</param>
        /// <param name="SavePath">保存路径：绝对路径 Eg E:\静态\饭票网\</param>
        /// <param name="FileName">文件名称1.txt</param>
        public static void ToFile(string msg, string FileType,string SavePath,string FileName)
        {
            try
            {
                if (!System.IO.Directory.Exists(SavePath))
                {
                    System.IO.Directory.CreateDirectory(SavePath);
                }
                string fullPath = SavePath + FileName;
                System.IO.StreamWriter sw = System.IO.File.AppendText(SavePath+FileName);
                using (sw)
                {
                    if (System.IO.File.Exists(fullPath))
                    {
                        sw.WriteLine(msg);
                    }
                    else
                    {
                        System.IO.File.Create(fullPath);
                        sw.WriteLine(msg);
                    }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// form端 采集当前整页面保存到本地
        /// </summary>
        /// <param name="url">采集网址</param>
        public static void CollectHtmlPage(string url)
        {
            string html = Yax.Common.HTTPHelper.GetHTMLUTF8(url);
            string DomainUrl = Yax.Common.Utils.GetDoaminFromUrl(url);
            string FoldUrl = url.Substring(0, url.LastIndexOf("/") + 1);
            html = DealCss(html, DomainUrl,FoldUrl);
            html = DealJS(html, DomainUrl, FoldUrl);
            html = DealImage(html, DomainUrl, FoldUrl);
            string SaveDirectory = GetSaveDirectory(Yax.Common.PubStr.WriteFilePath);
            ToFile(html, ".html", SaveDirectory, "demo.html");
        }
        private static string DealCss(string html,string DomainUrl,string FoldUrl)
        {
            Regex recss = new Regex("<link\\b[^<>]*?href=[\"'][^<>]*?.css\"", RegexOptions.IgnoreCase);
            MatchCollection macss = recss.Matches(html);
            string tempStr = "";
            if (macss != null && macss.Count > 0)
            {
                for (int i = 0; i < macss.Count; i++)
                {
                    string Ostr= new Regex("(?<=href=[\"'])[\\s\\S]*?(?=[\"'])").Match(macss[i].Value).Value;
                    if (Ostr.Contains("http://") || Ostr.Contains("https://"))
                    {
                        string FileName = Ostr.Substring(Ostr.LastIndexOf("/") + 1);
                        string FileDirectory =Yax.Common.PubStr.WriteFilePath+ "css/";
                        string SaveDirectory = GetSaveDirectory(FileDirectory);
                        string SavePath = SaveDirectory + FileName;
                        string cssHtml = Yax.Common.HTTPHelper.GetHTMLUTF8(Ostr);
                        ToFile(cssHtml, ".css", SaveDirectory, FileName);//保存文件
                        html = html.Replace(Ostr, "/css/" + FileName);
                    }
                    else
                    {
                        if (Ostr.Contains("~/"))
                        {
                            Ostr = Ostr.Replace("~/", "");
                        }
                        if (Ostr.StartsWith("/"))
                        {
                            Ostr = Ostr.Substring(1);
                            tempStr = DomainUrl + Ostr;
                        }
                        else
                        {
                            tempStr = FoldUrl+Ostr;
                        }
                        string FileName = Ostr.Substring(Ostr.LastIndexOf("/") + 1);
                        string FileDirectory = Yax.Common.PubStr.WriteFilePath  + Ostr.Substring(0, Ostr.LastIndexOf("/") + 1);
                        string SaveDirectory = GetSaveDirectory(FileDirectory);
                        string SavePath = SaveDirectory + FileName;
                        string cssHtml = Yax.Common.HTTPHelper.GetHTMLUTF8(tempStr);
                        ToFile(cssHtml, ".css", SaveDirectory, FileName);//保存文件
                    }
                    
                }
            }
            return html;
        }

        private static string DealJS(string html, string DomainUrl, string FoldUrl)
        {
            string restr = "<script\\b[^<>]*?src=.[^<>]*?.js[\"']";
            Regex recss = new Regex(restr, RegexOptions.IgnoreCase);
            MatchCollection macss = recss.Matches(html);
            string tempStr = "";
            if (macss != null && macss.Count > 0)
            {
                for (int i = 0; i < macss.Count; i++)
                {
                    string Ostr = new Regex("(?<=src=[\"'])[\\s\\S]*?(?=[\"'])").Match(macss[i].Value).Value;
                    string FileName = Ostr.Substring(Ostr.LastIndexOf("/") + 1);
                    if (Ostr.Contains("http://") || Ostr.Contains("https://"))
                    {
                        string FileDirectory = Yax.Common.PubStr.WriteFilePath + "js/";
                        string SaveDirectory = GetSaveDirectory(FileDirectory);
                        string cssHtml = Yax.Common.HTTPHelper.GetHTMLUTF8(Ostr);
                        ToFile(cssHtml, ".js", SaveDirectory, FileName);//保存文件
                        html = html.Replace(Ostr, "/js/"+FileName);
                    }
                    else
                    {
                        if (Ostr.Contains("~/"))
                        {
                            Ostr = Ostr.Replace("~/", "");
                        }
                        if (Ostr.StartsWith("/"))
                        {
                            Ostr = Ostr.Substring(1);
                            tempStr = DomainUrl + Ostr;
                        }
                        else
                        {
                            tempStr = FoldUrl + Ostr;
                        }
                        string FileDirectory = Yax.Common.PubStr.WriteFilePath + Ostr.Substring(0, Ostr.LastIndexOf("/") + 1);
                        string SaveDirectory = GetSaveDirectory(FileDirectory);
                        string SavePath = SaveDirectory + FileName;
                        string cssHtml = Yax.Common.HTTPHelper.GetHTMLUTF8(tempStr);
                        ToFile(cssHtml, ".js", SaveDirectory, FileName);//保存文件
                    }
                  
                }
            }
            return html;
        }

        private static string DealImage(string html, string DomainUrl, string FoldUrl)
        {
            MatchCollection macss = Yax.Common.Utils.GetImgsFromHTml(html);
            if (macss != null && macss.Count > 0)
            {
                for (int i = 0; i < macss.Count; i++)
                {
                    //macss[i].Value   <img src="/uploadimages/pic/2018041901350907518.png" alt="饭票logo" />
                    string Ostr = new Regex("(?<=src=\")[\\s\\S]*?(?=\")").Match(macss[i].Value).Value;
                    string NetStr =""; //文件的网络路径
                    if (Ostr.Contains("http://") || Ostr.Contains("https://"))
                    {
                        string FileName = Ostr.Substring(Ostr.LastIndexOf("/") + 1);
                        string FileDirectory = Yax.Common.PubStr.WriteFilePath+ "images/";
                        string SaveDirectory = GetSaveDirectory(FileDirectory);
                        string SavePath = SaveDirectory + FileName;
                        Yax.Common.HTTPHelper.SaveRemotPic(Ostr, SavePath);
                        html = html.Replace(Ostr, "/images/" + FileName);
                    }
                    else
                    {
                        if (Ostr.Contains("~/"))
                        {
                            Ostr = Ostr.Replace("~/", "");
                        }
                        if (Ostr.StartsWith("/"))
                        {
                            Ostr = Ostr.Substring(1);
                            NetStr = DomainUrl + Ostr; //文件的网络路径
                        }
                        else
                        {
                            NetStr = FoldUrl + Ostr; //文件的网络路径
                        }
                        string FileName = Ostr.Substring(Ostr.LastIndexOf("/") + 1);
                        string FileDirectory = Yax.Common.PubStr.WriteFilePath + Ostr.Substring(0, Ostr.LastIndexOf("/") + 1);
                        string SaveDirectory = GetSaveDirectory(FileDirectory);
                        string SavePath = SaveDirectory + FileName;
                        Yax.Common.HTTPHelper.SaveRemotPic(NetStr, SavePath);
                    }
              
                }
            }
            return html;
        }

        /// <summary>
        /// Form
        /// </summary>
        /// <param name="Fold">保存文件夹 /name/</param>
        /// <returns>E:\Codes\代码\bin\Debug/aa/</returns>
        public static string GetSaveDirectory(string Fold)
        {
            string rootPath = System.Environment.CurrentDirectory;//E:\Codes\代码\bin\Debug
            string SaveDirectory = rootPath + Fold;//E:\Codes\代码\bin\Debug/aa/
            SaveDirectory= SaveDirectory.Replace('/', '\\').Replace("\\\\", "\\");
            if (!System.IO.Directory.Exists(SaveDirectory))
            {
                System.IO.Directory.CreateDirectory(SaveDirectory);
            }
            return SaveDirectory;
        }
        //

    }
}
