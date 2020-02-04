using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace YForm
{
    public partial class CollectManHua : Form
    {
        public CollectManHua()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;//允许跨线程
        }


        /// <summary>
        /// http://www.js518.net/
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ThreadStart ts_collect = delegate { GetManHua_fromjs518(); };
                Thread th_collect = new Thread(ts_collect);
                th_collect.IsBackground = true;
                th_collect.Start();
            }
            catch(Exception ex)
            {
                this.txtres.Text +=ex.Message+ex.StackTrace;
            }
        }




        
        private void button2_Click(object sender, EventArgs e)
        {
            //E:\Codes\代码\YShop\YForm\bin\Debug\/RemotePicPath/Default/\
            //E:\Codes\代码\YShop\YForm\bin\Debug\\RemotePicPath\Default\\
            string str = "http://j.aiwenwo.net:55888/upload21/5180/2019/01-17/20190117090459_9216jwhqsfxi_small.jpg";
            Yax.Common.HTTPHelper.SaveRemotPicWinForm(str);
        }
        private  byte[] GetResponseBody(HttpWebResponse response)
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
        private  byte[] GetBytes(Stream stream)
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



        private string GetManHua_fromjs518()
        {
            string CollectDoMain = "http://www.js518.net";
            string weburls = this.txtUrl.Text.Trim();
            string[] wss = Regex.Split(weburls, ",");
            for(int i=0;i<wss.Length;i++)
            {
                string txtTitle = AddByUrl(CollectDoMain + wss[i]);
                this.txtres.Text += txtTitle + "新增结束\r\n";
                if(this.txtres.Text.Length>5000)
                {
                    this.txtres.Text = "";
                }
            }
            MessageBox.Show("新增结束");
            return "";
        }

        private string AddByUrl(string weburl)
        {
            string CollectDoMain = "http://www.js518.net";
            string html = Yax.Common.HTTPHelper.GetHTMLUTF8(weburl);
            string temp = "";
            string ReTitle = "(?<=mh-date-info fl)[\\s\\S]*?(?=/a>)";
            Regex re = new Regex(ReTitle);
            temp = re.Match(html).Value;
            ReTitle = "(?<=/\">)[\\s\\S]*?(?=<)";
            re = new Regex(ReTitle);
            //标题    ----------
            string txtTitle = re.Match(temp).Value;
            txtTitle = Yax.Common.Utils.HtmlFilter(txtTitle).Replace(".", "");
            string ReAuthor = "(?<=作者：)[\\s\\S]*?(?=/a>)";
            temp = new Regex(ReAuthor).Match(html).Value;
            ReAuthor = "(?<=\">)[\\s\\S]*?(?=<)";
            //作者    ----------
            string txtAuthor = new Regex(ReAuthor).Match(temp).Value;

            string ReUpState = "(?<=状态： <em>)[\\s\\S]*?(?=</em>)";
            //更新状态    ----------
            string txtUpState = new Regex(ReUpState).Match(html).Value;

            string ReIntroduce = "(?<=work-ov\">)[\\s\\S]*?(?=</div>)";
            temp = new Regex(ReIntroduce).Match(html).Value;
            //简介    ----------
            string txtIntroduce = Yax.Common.Utils.HtmlFilter(temp).Trim();

            string RePic = "(?<=mh-date-bgpic)[\\s\\S]*?(?=title=)";
            temp = new Regex(RePic).Match(html).Value;
            RePic = "(?<=src=\")[\\s\\S]*?(?=\" alt)";
            //封面图片
            string txtPic = new Regex(RePic).Match(temp).Value;
            string txtCover = Yax.Common.HTTPHelper.SaveRemotPicWinForm(txtPic, txtTitle);
            int ManHuaID = 0;
            object obj = null;
            string strSearch = " select * from M_ManHua where name='" + txtTitle + "' ";
            DataTable dtGet_have = new Yax.BLL.BCommon().GetDataBySQL(strSearch);
            if (dtGet_have != null && dtGet_have.Rows.Count > 0)
            {
                ManHuaID = int.Parse(dtGet_have.Rows[0]["ID"].ToString());
            }
            else
            {
                StringBuilder sbManHua = new StringBuilder(2000);
                sbManHua.Append(" INSERT INTO [dbo].[M_ManHua]([Name] ,[SearchName] ,[UpSate],[Author],[Hits],[Sort] ,[LatestChapter] ,[IsIndex] ");
                sbManHua.Append(" ,[Introduce],[Cagegory],[AddUser],[Memo] ,[Cover] ,[FromUrl] ,[DownUrl],[DownName],[Enable],[AddTime]) ");
                sbManHua.Append(" VALUES(");
                sbManHua.Append("'" + txtTitle + "','" + txtTitle + "','" + txtUpState + "','" + txtAuthor + "',1,1,'',0");
                sbManHua.Append(",'" + txtIntroduce + "','',1,'','" + txtCover + "','" + weburl + "','','',1,getdate())");
                sbManHua.Append(" select @@IDENTITY");
                obj = new Yax.BLL.BCommon().ExecuteScalar(sbManHua.ToString());
                ManHuaID = int.Parse(obj.ToString());
                this.txtres.Text += "新增M_ManHua数据：" + txtTitle + "\r\n";
            }

            // 
            //Chapter 

            string ReChapter = "(?<=mh-chapter-list-ol-0)[\\s\\S]*?(?=</ol>)";
            string ChapterStr = new Regex(ReChapter).Match(html).Value;
            ReChapter = "(?<=href=\")[\\s\\S]*?(?=\")";
            MatchCollection maHref_Chapter = new Regex(ReChapter).Matches(ChapterStr);
            ReChapter = "(?<=_blank\">)[\\s\\S]*?(?=</a>)";
            MatchCollection maName_Chapter = new Regex(ReChapter).Matches(ChapterStr);
            for (int i = 0; i < maHref_Chapter.Count; i++)
            {
                strSearch = " select * from M_Chapter where ManHuaID=" + ManHuaID + " and Name='" + maName_Chapter[i].Value + "'";
                dtGet_have = new Yax.BLL.BCommon().GetDataBySQL(strSearch);
                if (dtGet_have != null && dtGet_have.Rows.Count > 0)
                {
                    continue;
                }
                else
                {
                    int sort = maHref_Chapter.Count - i;
                    string FromUrl = CollectDoMain + maHref_Chapter[i].Value;
                    StringBuilder sbChapter = new StringBuilder(1000);
                    sbChapter.Append(" INSERT INTO [dbo].[M_Chapter]([Name] ,[ManHuaID],[Enable],[AddTime],[Sort],[FromUrl]) ");
                    sbChapter.Append(" VALUES('" + maName_Chapter[i].Value + "'," + ManHuaID + ",1,getdate()," + sort + ",'" + FromUrl + "')");
                    sbChapter.Append(" select @@IDENTITY");
                    obj = new Yax.BLL.BCommon().ExecuteScalar(sbChapter.ToString());
                    int ChapterID = int.Parse(obj.ToString());
                    //pic
                    string picHtml = Yax.Common.HTTPHelper.GetHTMLUTF8(FromUrl);
                    string rePics = "(?<=qTcms_S_m_murl_e=\")[\\s\\S]*?(?=\";)";
                    string base64pics = new Regex(rePics).Match(picHtml).Value;
                    base64pics = Yax.Common.SecurityHelper.Base64Decrypt(base64pics);
                    string[] pics = Regex.Split(base64pics, "\\$qingtiandy\\$");
                    for (int j = 0; j < pics.Length; j++)
                    {
                        if (!string.IsNullOrEmpty(pics[j]))
                        {
                            string FromPic = pics[j];
                            if (!FromPic.Contains("http"))
                            {
                                FromPic = CollectDoMain + FromPic;
                            }
                            string ImgUrl = Yax.Common.HTTPHelper.SaveRemotPicWinForm(FromPic, txtTitle + "/" + maName_Chapter[i].Value);
                            StringBuilder sbPic = new StringBuilder(1000);
                            sbPic.Append(" INSERT INTO [dbo].[M_Pic]([ImgUrl],[Enable],[AddTime],[Sort],[ChapterID],[PageNum] ,[FromPic])");
                            sbPic.Append("  VALUES('" + ImgUrl + "',1,getdate()," + (j + 1) + "," + ChapterID + "," + pics.Length + ",'" + FromPic + "')");
                            obj = new Yax.BLL.BCommon().ExecuteScalar(sbPic.ToString());
                        }
                    } //循环添加  漫画图片结束
                    this.txtres.Text += txtTitle + ":" + maName_Chapter[i].Value + "新增成功\r\n";
                } //  添加 Chapter
            }
            // Chapter 循环结束
            return txtTitle;
        }

    }
}
