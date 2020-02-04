using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Yax.Common
{
    public class HTTPHelper
    {
        #region 获取网页内容
        // <summary>
        /// 读取网页Html内容
        /// </summary>
        /// <param name="httpUrl"></param>
        /// <returns></returns>
        public static string GetHTMLgb2312(string httpUrl)
        {
            WebRequest request = WebRequest.Create(httpUrl);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312"));
            string strResult = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();
            response.Close();
            return strResult;
        }
        /// <summary>
        /// 读取网页Html内容
        /// </summary>
        /// <param name="httpUrl"></param>
        /// <returns></returns>
        public static string GetHTMLUTF8(string httpUrl)
        {
            WebRequest request = null;
            WebResponse response = null;
            request = WebRequest.Create(httpUrl);
            response = request.GetResponse();
            StreamReader reader = null;
            string strResult="";
            try
            {
                reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                strResult = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                response.Close();
            }
            catch
            {
                reader.Close();
                reader.Dispose();
                response.Close();
                //response.d();
            }
            return strResult;
        }

        public static string GetHtml_01_Post(string url,string postdata)
        {
            System.Net.HttpWebRequest webrequest = (HttpWebRequest)System.Net.HttpWebRequest.Create(url);
            System.Net.HttpWebResponse webRespose = null;
            StreamReader sr = null;
            string postData = postdata;
            byte[] bs = Encoding.UTF8.GetBytes(postData);
            webrequest.ContentLength = bs.Length;
            webrequest.Method = "POST";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            webrequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.109 Safari/537.36";
            Stream stream = webrequest.GetRequestStream();
            using (stream)
            {
                stream.Write(bs, 0, bs.Length);
            }
            webRespose = (HttpWebResponse)webrequest.GetResponse();
            sr = new StreamReader(webRespose.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
            return sr.ReadToEnd();
        }
        /// <summary>
        /// gb2312
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postdata"></param>
        /// <returns></returns>
        public static string GetHtml_02_Post(string url, string postdata)
        {
            System.Net.HttpWebRequest webrequest = (HttpWebRequest)System.Net.HttpWebRequest.Create(url);
            System.Net.HttpWebResponse webRespose = null;
            StreamReader sr = null;
            string postData = postdata;
            byte[] bs = Encoding.UTF8.GetBytes(postData); 
            webrequest.ContentLength = bs.Length;
            webrequest.Method = "POST";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            webrequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.109 Safari/537.36";
            Stream stream = webrequest.GetRequestStream();
            using (stream)
            {
                stream.Write(bs, 0, bs.Length);
            }
            webRespose = (HttpWebResponse)webrequest.GetResponse();
            sr = new StreamReader(webRespose.GetResponseStream(), Encoding.GetEncoding("gb2312"));
            return sr.ReadToEnd();
        }
        public static void SaveRemotPic(string HTTPUrl,string savePath)
        {
            string extName = HTTPUrl.Substring(HTTPUrl.LastIndexOf('.')+1).ToLower();
            ImageFormat imgfo = null;
            switch (extName)
            {
                case "bmp":
                    imgfo = ImageFormat.Bmp;
                    break;
                case "jpeg":
                    imgfo = ImageFormat.Jpeg;
                    break;
                case "jpg":
                    imgfo = ImageFormat.Jpeg;
                    break;
                case "png":
                    imgfo = ImageFormat.Png;
                    break;
                case "gif":
                    imgfo = ImageFormat.Gif;
                    break;
                default:
                    break;
            }
            if (imgfo == null)
            {
                return;
            }
            try
            {
                WebRequest webq = WebRequest.Create(HTTPUrl);
                HttpWebResponse resp = (HttpWebResponse)webq.GetResponse();
                using (Stream s = resp.GetResponseStream())
                {
                    using (System.Drawing.Image img = System.Drawing.Image.FromStream(s))
                    {
                        img.Save(savePath, ImageFormat.Png);
                    }
                }
            }
            catch
            {
                if (File.Exists(savePath))
                {
                    File.Delete(savePath);
                }
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HTTPUrl);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var bytes = GetResponseBody(response);
                using (var writeStream = File.Create(savePath))
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }
        }

        public static string SaveRemotPicWeb(string HTTPUrl, string FoldName = "/Default/")
        {
            string extName = HTTPUrl.Substring(HTTPUrl.LastIndexOf('.') + 1).ToLower();
            ImageFormat imgfo = null;
            switch (extName)
            {
                case "bmp":
                    imgfo = ImageFormat.Bmp;
                    break;
                case "jpeg":
                    imgfo = ImageFormat.Jpeg;
                    break;
                case "jpg":
                    imgfo = ImageFormat.Jpeg;
                    break;
                case "png":
                    imgfo = ImageFormat.Png;
                    break;
                case "gif":
                    imgfo = ImageFormat.Gif;
                    break;
                default:
                    break;
            }
            if (imgfo == null)
            {
                return "";
            }
            //
            string savePath = new System.Web.UI.Page().Server.MapPath("~/") + FoldName;
            savePath = savePath.Replace('/', '\\').Replace("\\\\", "\\");
            if (!System.IO.Directory.Exists(savePath))
            {
                System.IO.Directory.CreateDirectory(savePath);
            }
            string PicName = "Remote" + Yax.Common.Utils.RandomDateCard() + "_" + Yax.Common.Utils.RandStr(6);
            string Virtulpath = FoldName + PicName + "." + extName;
            savePath = savePath + PicName + "." + extName;
            //

            try
            {
                if (extName == "gif")
                {
                    WebClient my = new WebClient();
                    byte[] mybyte;
                    mybyte = my.DownloadData(HTTPUrl);
                    MemoryStream ms = new MemoryStream(mybyte);
                    System.Drawing.Image img;
                    img = System.Drawing.Image.FromStream(ms);
                    img.Save(savePath, ImageFormat.Gif);   //保存
                }
                else
                {
                    WebRequest webq = WebRequest.Create(HTTPUrl);
                    HttpWebResponse resp = (HttpWebResponse)webq.GetResponse();
                    using (Stream s = resp.GetResponseStream())
                    {
                        using (System.Drawing.Image img = System.Drawing.Image.FromStream(s))
                        {
                            img.Save(savePath, ImageFormat.Png);
                        }
                    }
                }

                //

            }
            catch
            {
                if (File.Exists(savePath))
                {
                    File.Delete(savePath);
                }
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HTTPUrl);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var bytes = GetResponseBody(response);
                using (var writeStream = File.Create(savePath))
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }
            return Virtulpath;
        }



        public static string SaveRemotPicWinForm(string HTTPUrl,string FoldName="Default")
        {
            string extName = HTTPUrl.Substring(HTTPUrl.LastIndexOf('.') + 1).ToLower();
            ImageFormat imgfo = null;
            switch (extName)
            {
                case "bmp":
                    imgfo = ImageFormat.Bmp;
                    break;
                case "jpeg":
                    imgfo = ImageFormat.Jpeg;
                    break;
                case "jpg":
                    imgfo = ImageFormat.Jpeg;
                    break;
                case "png":
                    imgfo = ImageFormat.Png;
                    break;
                case "gif":
                    imgfo = ImageFormat.Gif;
                    break;
                default:
                    break;
            }
            if (imgfo == null)
            {
                return "";
            }
            //
            FoldName = FoldName + "/";
            string savePath = System.Environment.CurrentDirectory + "\\" + Yax.Common.PubStr.RemotePicPath + FoldName+ "\\";
            savePath = savePath.Replace('/', '\\').Replace("\\\\", "\\");
            if (!System.IO.Directory.Exists(savePath))
            {
                System.IO.Directory.CreateDirectory(savePath);
            }
            string PicName = "Remote" + Yax.Common.Utils.RandomDateCard() + "_" + Yax.Common.Utils.RandStr(6);
            string Virtulpath = Yax.Common.PubStr.RemotePicPath+ FoldName + PicName +"."+ extName;
            savePath = savePath + PicName +"."+ extName;
            //
            try
            {
                if (extName == "gif")
                {
                    WebClient my = new WebClient();
                    byte[] mybyte;
                    mybyte = my.DownloadData(HTTPUrl);
                    MemoryStream ms = new MemoryStream(mybyte);
                    System.Drawing.Image img;
                    img = System.Drawing.Image.FromStream(ms);
                    img.Save(savePath, ImageFormat.Gif);   //保存
                }
                else
                {
                    WebRequest webq = WebRequest.Create(HTTPUrl);
                    HttpWebResponse resp = (HttpWebResponse)webq.GetResponse();
                    using (Stream s = resp.GetResponseStream())
                    {
                        using (System.Drawing.Image img = System.Drawing.Image.FromStream(s))
                        {
                            img.Save(savePath, ImageFormat.Png);
                        }
                    }
                }

                //

            }
            catch
            {
                if (File.Exists(savePath))
                {
                    File.Delete(savePath);
                }
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HTTPUrl);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var bytes = GetResponseBody(response);
                using (var writeStream = File.Create(savePath))
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }
            return Virtulpath;
        }

        private static byte[] GetResponseBody(HttpWebResponse response)
        {
            byte[] bytes = null;
            if (response.ContentEncoding.ToLower().Contains("gzip"))
            {
                using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                {
                    bytes = GetBytes(stream);
                }
            }
            else if (response.ContentEncoding.ToLower().Contains("deflate"))
            {
                using (DeflateStream stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress))
                {
                    bytes = GetBytes(stream);
                }
            }
            else
            {
                using (Stream stream = response.GetResponseStream())
                {
                    bytes = GetBytes(stream);
                }
            }
            return bytes;
        }
        private static byte[] GetBytes(Stream stream)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] bytes = new byte[40960];
                int n;
                while ((n = stream.Read(bytes, 0, bytes.Length)) > 0)
                {
                    ms.Write(bytes, 0, n);
                }
                return ms.ToArray();
            }
        }

      
        /// <summary>
        /// 推送数据 POST方式
        /// </summary>
        /// <param name="weburl">POST到的网址</param>
        /// <param name="data">POST的参数及参数值</param>
        /// <param name="encode">编码方式</param>
        /// <returns></returns>
        public static string GetHtml_Post(string weburl, string data, Encoding encode)
        {
            try
            {
                byte[] byteArray = encode.GetBytes(data);

                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(weburl));
                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.ContentLength = byteArray.Length;

                Stream newStream = webRequest.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);
                newStream.Close();

                //接收返回信息：
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                StreamReader aspx = new StreamReader(response.GetResponseStream(), encode);
                string msg = aspx.ReadToEnd();
                aspx.Close();
                response.Close();
                return msg;
            }
            catch (Exception ex)
            {
                //记录错误日志
                return "";
            }
        }
        #endregion
    }
}
