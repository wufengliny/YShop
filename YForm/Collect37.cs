using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace YForm
{
    public partial class Collect37 : Form
    {
        public Collect37()
        {
            InitializeComponent();
        }

        private void Collect37_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;//允许跨线程
        }

        string HostUrl = "https://adcxx08.com";
        string Category = "动漫";
        int sort = 1;
        int pageIndex = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            //
            try
            {
                ThreadStart ts_collect = delegate { Collect(); };
                Thread th_collect = new Thread(ts_collect);
                th_collect.IsBackground = true;
                th_collect.Start();
            }
            catch (Exception ex)
            {
                this.textBox2.Text += ex.Message + ex.StackTrace;
            }


        }

        private void Collect()
        {
            string PreMainUrl = "https://adcxx08.com/html/hentai/";
            string url = "";
            string html = "下一页";
            while (html.Contains("下一页"))
            {
                pageIndex++;
                string temp = "";
                string nextUrl = "";
                if (html == "下一页")
                {
                    url = PreMainUrl;
                }
                else
                {
                    temp = new Regex("(?<=page-navigation)[\\s\\S]*?(?=</ul>)").Match(html).Value;
                    nextUrl = new Regex("(?<=next\"\\s*href=')[\\S]*?(?='>下一页)").Match(temp).Value;
                    url = PreMainUrl + nextUrl;
                }
                html = Yax.Common.HTTPHelper.GetHTMLUTF8(url);
                GetInfoByPage(html);
            }
        }
        private void GetInfoByPage(string html)
        {
            this.textBox2.Text = "第"+pageIndex+"页"+ "\r\n";
            MatchCollection ma_item = new Regex("(?<=list-item)[\\s\\S]*?(?=</div>\\s*</div>)").Matches(html);
            for (int i = 0; i < ma_item.Count; i++)
            {
                try
                {
                    string Cover = new Regex("(?<=src=\")[\\S]*?(?=\")").Match(ma_item[i].Value).Value;
                    string CoverPath= Yax.Common.HTTPHelper.SaveRemotPicWinForm(Cover, "VedioCover");
                    string VedioLong = new Regex("(?<=时长：)[\\S]*?(?=</span>)").Match(ma_item[i].Value).Value.Replace("'", ":");
                    string Name = new Regex("(?<=name\">)[\\s\\S]*?(?=</div>)").Match(ma_item[i].Value).Value.Replace("'", ":");
                    string DetailUrl = new Regex("(?<=href=\")[\\S]*?(?=\")").Match(ma_item[i].Value).Value;
                    DetailUrl = HostUrl + DetailUrl;
                    string HtmlDetail = Yax.Common.HTTPHelper.GetHTMLUTF8(DetailUrl);
                    string FromVedioUrl = new Regex("(?<=down_a\"\\s*href=\")[\\S]*?(?=\")").Match(HtmlDetail).Value;
                    string FromVedioM3u8 = new Regex("(?<=vHLSurl = \")[\\S]*?(?=\")").Match(HtmlDetail).Value;
                    StringBuilder sb = new StringBuilder(2000);
                    sb.Append("INSERT INTO [dbo].[AMH_Vedio]([Name],[Cover],[Tag],[Category],[IsFree],[Url] ,[VedioLong],[Hits],[Likes]");
                    sb.Append("   ,[Area],[Introduce],[AddTime],[Enable] ,[Actor],[AddUser],[Sort],[FromVedioUrl],[FromPageUrl] ,[FromSite] ,[FromVedioM3u8])");
                    sb.Append("VALUES('" + Name + "','" + CoverPath + "','','" + Category + "',2,'" + FromVedioUrl + "','" + VedioLong + "'");
                    sb.Append(",1000,1,'','',getdate(),1,'',1," + sort + ",'" + FromVedioUrl + "','" + DetailUrl + "','" + HostUrl + "','" + FromVedioM3u8 + "')");
                    new Yax.BLL.BCommon().ExecuteScalar(sb.ToString());
                    this.textBox2.Text = "第" + pageIndex + "页：" + Name+"\r\n" + this.textBox2.Text + "\r\n";
                    sort++;
                }
                catch
                {

                }
               
            }
        }


    }
}
