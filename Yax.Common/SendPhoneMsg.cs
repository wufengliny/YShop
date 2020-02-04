using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Yax.Common
{
    public class SendPhoneMsg
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone">手机</param>
        /// <param name="sendcontent"></param>
        /// <param name="cust_code">QIYeID</param>
        /// <returns></returns>
        public static string SendMsg(string phone, string sendcontent, string cust_code,string ContentPre,string pwd,string url)
        {
            try
            {
                //string PostUrl = "http://119.23.134.102:8860";
                string PostUrl = url; 
                string  content = "", destMobiles = "", sign = "";
                string Orignal_content = ContentPre + sendcontent;
                content = System.Web.HttpContext.Current.Server.UrlEncode(ContentPre + sendcontent);
                destMobiles = phone;

                string postStrTpl = "cust_code={0}&content={1}&destMobiles={2}&sign={3}";
                sign = FormsAuthentication.HashPasswordForStoringInConfigFile(content + pwd, "MD5");

                UTF8Encoding encoding = new UTF8Encoding();
                byte[] postData = encoding.GetBytes(string.Format(postStrTpl, cust_code, content, destMobiles, sign));

                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(PostUrl);
                myRequest.Method = "POST";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.ContentLength = postData.Length;

                Stream newStream = myRequest.GetRequestStream();
                newStream.Write(postData, 0, postData.Length);
                newStream.Flush();
                newStream.Close();
                int haveSuccessSendCount = 0;
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                if (myResponse.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                    string result = reader.ReadToEnd();
                    //return Orignal_content+ "error"+HttpContext.Current.Server.UrlDecode(result);
                    if (result.IndexOf("\r\n") > 0)
                    {
                        result = result.Replace("\r\n", "$");
                        string[] arrys = result.Split('$');

                        if (HttpContext.Current.Server.UrlDecode(arrys[0].Split(':')[1]).Contains("提交成功"))
                        {
                            for (int i = 1; i < arrys.Length; i++)
                            {
                                if (arrys[i] != "" && arrys[i].Split(':')[0] != "" && arrys[i].Split(':')[2] == "0")
                                {
                                    haveSuccessSendCount++;
                                }
                            }
                            return haveSuccessSendCount.ToString();
                        }

                    }
                    else
                    {
                        return HttpContext.Current.Server.UrlDecode(result);
                    }
                }
                else
                {
                    //访问失败
                }
                if (haveSuccessSendCount.ToString() != "0")
                {

                }
                return haveSuccessSendCount.ToString();
            }
            catch (Exception ex)
            {
                return "error:"+ex.Message;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="Pwd"></param>
        /// <param name="Content"></param>
        /// <param name="Mobile"></param>
        /// <param name="SignId"></param>
        /// <returns></returns>
        public static string SendMsg_FG(string Account,string Pwd,string Content,string Mobile,string SignId,string apiurl)
        {
            //http://api.feige.ee
            long SendTime = Convert.ToInt64(Yax.Common.Utils.ToUnixStamp(DateTime.Now));


            StringBuilder arge = new StringBuilder();
            arge.AppendFormat("Account={0}", Account);
            arge.AppendFormat("&Pwd={0}", Pwd);
            arge.AppendFormat("&Content={0}",Content);
            arge.AppendFormat("&Mobile={0}", Mobile);
            arge.AppendFormat("&SignId={0}", SignId);
            arge.AppendFormat("&SendTime={0}", SendTime);
            string weburl = apiurl + "/SmsService/Send";
            string resp = Yax.Common.HTTPHelper.GetHtml_Post(weburl, arge.ToString(), Encoding.UTF8);

            return resp;
        }

        public static string SendMsg_FG_Template(string Account, string Pwd, string Content, string Mobile, string SignId, string apiurl,string TempID)
        {
            StringBuilder arge = new StringBuilder();
            arge.AppendFormat("Account={0}", Account);
            arge.AppendFormat("&Pwd={0}", Pwd);
            arge.AppendFormat("&Content={0}", Content);
            arge.AppendFormat("&Mobile={0}", Mobile);
            arge.AppendFormat("&SignId={0}", SignId);
            arge.AppendFormat("&TemplateId={0}", TempID);
            string weburl = apiurl + "/SmsService/Template";
            string resp = Yax.Common.HTTPHelper.GetHtml_Post(weburl, arge.ToString(), Encoding.UTF8);
            return resp;
        }
    }
}
