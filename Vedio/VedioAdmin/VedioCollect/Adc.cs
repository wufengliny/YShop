using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
namespace VedioCollect
{
    public partial class Adc : Form
    {
        public Adc()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        string url = "https://adcbkx.com";
        string urlzipai = "/html/amateur/";
        string urlAsia = "/html/asia/";
        string urlJuqing = "/html/story/";
        string urlWest = "/html/west/";
        private void btnzipai_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(collect_zipai);
            th.IsBackground = true;
            th.Start();
        }
        private void btnAsia_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(collect_Asia);
            th.IsBackground = true;
            th.Start();
        }
        private void btnjuqing_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(collect_Juqing);
            th.IsBackground = true;
            th.Start();
        }
        private void btnwest_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(collect_West);
            th.IsBackground = true;
            th.Start();
        }
        private void collect_zipai()
        {
            //https://adcbkx.com/html/amateur/list_5_199.html
            //https://adcbkx.com/html/amateur/list_5_191.html
            int startPage = int.Parse(this.txtbeginpage.Text);
            int endPage = int.Parse(this.txtendpage.Text);
            for (int i = startPage; i <= endPage; i++)
            {
                string requestUrl = url + urlzipai + "list_5_" + i + ".html";
                try
                {
                    PageHandler(i, requestUrl, "国产");
                    this.txtLog.Text = "成功完成采集第" + i + "页 \r\n" + this.txtLog.Text;
                    UCommon.UUtils.WriteFileLog_Form("成功完成采集第" + i + "页 \r\n", "/logs", "国产.txt");
                }
                catch (Exception ex)
                {
                    LogErrmsg("采集第" + i + "页出现错误" + ex.StackTrace + ex.StackTrace);
                }
            }
        }
        private void collect_Asia()
        {
            //https://adcbkx.com/html/asia/list_4_1.html
            //https://adcbkx.com/html/asia/list_4_2.html
            int startPage = int.Parse(this.txtbeginpage.Text);
            int endPage = int.Parse(this.txtendpage.Text);
            for (int i = startPage; i <= endPage; i++)
            {
                string requestUrl = url + urlAsia + "list_4_" + i + ".html";
                try
                {
                    PageHandler(i, requestUrl, "日本");
                    this.txtLog.Text = "成功完成采集第" + i + "页 \r\n" + this.txtLog.Text;
                    UCommon.UUtils.WriteFileLog_Form("成功完成采集第" + i + "页 \r\n", "/logs", "日本.txt");
                }
                catch (Exception ex)
                {
                    LogErrmsg("采集第" + i + "页出现错误" + ex.StackTrace + ex.Message);
                }
            }
        }

        private void collect_Juqing()
        {
            //https://adcbkx.com/html/story/list_7_1.html
            //https://adcbkx.com/html/story/list_7_2.html
            int startPage = int.Parse(this.txtbeginpage.Text);
            int endPage = int.Parse(this.txtendpage.Text);
            for (int i = startPage; i <= endPage; i++)
            {
                string requestUrl = url + urlJuqing + "list_7_" + i + ".html";
                try
                {
                    PageHandler(i, requestUrl, "剧情");
                    this.txtLog.Text = "成功完成采集第" + i + "页 \r\n" + this.txtLog.Text;
                    UCommon.UUtils.WriteFileLog_Form("成功完成采集第" + i + "页 \r\n", "/logs", "剧情.txt");
                }
                catch (Exception ex)
                {
                    LogErrmsg("采集第" + i + "页出现错误" + ex.StackTrace + ex.Message);
                }
            }
        }

        private void collect_West()
        {
            //https://adcbkx.com/html/west/list_6_2.html
            //https://adcbkx.com/html/west/list_6_3.html
            int startPage = int.Parse(this.txtbeginpage.Text);
            int endPage = int.Parse(this.txtendpage.Text);
            for (int i = startPage; i <= endPage; i++)
            {
                string requestUrl = url + urlWest + "list_6_" + i + ".html";
                try
                {
                    PageHandler(i, requestUrl, "欧美");
                    this.txtLog.Text = "成功完成采集第" + i + "页 \r\n" + this.txtLog.Text;
                    UCommon.UUtils.WriteFileLog_Form("成功完成采集第" + i + "页 \r\n", "/logs", "欧美.txt");
                }
                catch (Exception ex)
                {
                    LogErrmsg("采集第" + i + "页出现错误" + ex.StackTrace + ex.Message);
                }
            }
        }
        int succnum = 0;
        private void PageHandler(int Page,string requestUrl,string Category)
        {
            string htmlpage = UCommon.UHTTPHelper.Get_Http(requestUrl);
            //缩小范围
            Regex re = new Regex("(?<=breadcrumb\")[\\s\\S]*?(?=页码列表)");
            htmlpage = re.Match(htmlpage).Value;
            //取得视频集合
            Regex relist = new Regex("(?<=<div class=\")list-item[\\s\\S]*?(?=</div>\\s*</a>\\s*</div>)");
            MatchCollection ma_list = relist.Matches(htmlpage);
            //遍历该页视频
            for (int i = 0; i < ma_list.Count; i++)
            
            {
                //播放页地址
                Regex re_detailUrl = new Regex("(?<=href=\")[\\s\\S]*?(?=\")");
                string DetailUrl = re_detailUrl.Match(ma_list[i].Value).Value;
                if(DetailUrl.Contains("view.php"))// /plus/view.php?aid=13811#m   > /html/amateur/13779.html#m
                {
                    Regex re_temp = new Regex("(?<=aid=)\\d+(?=#)"); //  
                    string collectID = re_temp.Match(DetailUrl).Value;
                    if(Category== "国产")
                    {
                        DetailUrl = "/html/amateur/" + collectID + ".html#m";
                    }
                    else  if (Category == "日本")
                    {
                        DetailUrl = "/html/asia/" + collectID + ".html#m";
                    }
                    else if (Category == "剧情")
                    {
                        DetailUrl = "/html/story/" + collectID + ".html#m";
                    }
                    else if (Category == "欧美")
                    {
                        DetailUrl = "/html/west/" + collectID + ".html#m";
                    }
                }
                if(DetailUrl.Contains("http"))
                {
                    UCommon.UUtils.WriteFileLog_Form(DetailUrl+"\r\n", "/logs", "ad.txt");
                    continue;
                }
                if(DetailUrl=="#")
                {
                    continue;
                }
                Regex re_title = new Regex("(?<=name\">)[\\s\\S]*?(?=</div>)");
                string title = re_title.Match(ma_list[i].Value).Value;
                //封面图片
                Regex re_Cover = new Regex("(?<=src=\")[\\s\\S]*?(?=\")");
                string Cover = re_Cover.Match(ma_list[i].Value).Value;
                //发布时间
                Regex re_time = new Regex("(?<=发布：)[\\s\\S]*?(?=</span>)");
                string time = re_time.Match(ma_list[i].Value).Value;
                //视频时长
                Regex re_vediolong = new Regex("(?<=时长：)[\\s\\S]*?(?=</span>)");
                string vediolong=re_vediolong.Match(ma_list[i].Value).Value;
                //获取视频文件地址
                string fullDetailUrl = url + DetailUrl;
                string htmlpageDetail = "";
                try
                {
                    htmlpageDetail = UCommon.UHTTPHelper.Get_Http(fullDetailUrl);
                }
                catch(Exception ex)
                {
                    LogErrmsg("第" + Page + "页，索引" + i + ex.Message + ex.StackTrace);
                    continue;
                }
                //缩小范围
                Regex re_s = new Regex("(?<=download_nojs)[\\s\\S]*?(?=点击下载观看本视频)");
                htmlpageDetail = re_s.Match(htmlpageDetail).Value;
                Regex re_vedioUrl = new Regex("(?<=href=\")[\\s\\S]*?(?=\")");
                string vedioUrl = re_vedioUrl.Match(htmlpageDetail).Value;


                var chkmodel = new BLL.BC_Vedios().GetModelByUrl(vedioUrl);
                if (chkmodel != null)
                {
                    continue;
                }
                string saveCoverPath = savepic(Cover,0);
                if(string.IsNullOrEmpty(saveCoverPath))
                {
                    LogErrmsg("采集远程图片失败："+Cover);
                    continue;
                }
                MC_Vedios model = new MC_Vedios();
                model.Actor = "";
                model.AddTime = DateTime.Now;
                model.Category = Category;
                model.Cover = saveCoverPath;
                model.Enable = 1;
                model.FreeDownNum = 0;
                model.FreePartUrl = "";
                model.FromCoverUrl = Cover;
                model.FromPageUrl = fullDetailUrl;
                model.FromSite = "adc";
                model.FromVedioUrl = vedioUrl;
                model.Goods = 0;
                model.Hits = 0;
                model.Introduce = "";
                model.IsTop = 0;
                model.Likes = 0;
                model.Memo = "";
                model.Name = title;
                model.PreUrl = "";
                model.Price = 0;
                model.SeriousID = 0;
                model.SeriousName = "";
                model.SinglePayDownLoadNum = 0;
                model.Sort = 9000;
                model.Tag = "";
                model.Url = vedioUrl;
                model.VedioLong = vediolong;
                model.VIPDownNum = 0;
                int res =new BLL.BC_Vedios().Add(model);
                if (res > 0)
                {
                    succnum++;
                    string txt = "成功采集"+succnum+"第" + Page + "页：" + title + "\r\n" + this.txtLog.Text;
                    if (txt.Length > 1000)
                    {
                        txt = txt.Substring(0, 100);
                    }
                    this.txtLog.Text = txt;
                }
                else
                {
                    LogErrmsg("插入数据库失败-数据：第" + Page + "页:" + title);
                }
              
            }
        }

        private void LogErrmsg(string msg)
        {
            string txt = msg + "\r\n " + this.txterr.Text;
            this.txterr.Text = txt;
            UCommon.UUtils.WriteFileLog_Form(msg+"\r\n");
        }

        private string savepic(string Cover,int i=0)
        {
            string res = "";
            try
            {
                res = UCommon.UHTTPHelper.SaveRemotPicWinForm(Cover, "UpLoadFiles/AdcCover");
            }
            catch
            {

            }
            if(i<5)
            {
                if (string.IsNullOrEmpty(res))
                {
                    i++;
                    res= savepic(Cover, i);
                }
            }
            return res;
        }

      
    }
}
