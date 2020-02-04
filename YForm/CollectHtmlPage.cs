using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace YForm
{
    public partial class CollectHtmlPage : Form
    {
        public CollectHtmlPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = this.textBox1.Text;
            string html = Yax.Common.HTTPHelper.GetHTMLUTF8(url);
            Regex re=  new Regex("(?<=<iframe[\\s\\S]*?src=\")[\\s\\S]*?(?=\")");
            if(re.IsMatch(html))
            {
                url = re.Match(html).Value;
            }
            Yax.Common.WriteTxtToFile.CollectHtmlPage(url);
            MessageBox.Show("下载成功");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url = "https://www.17sucai.com/preview/776331/2019-07-31/xx/index.html";
            string html = Yax.Common.HTTPHelper.GetHTMLUTF8(url);
            string restr = "<script\\b[^<>]*?src=.[^<>]*?.js[\"']";
           // restr = this.textBox1.Text;
            Regex recss = new Regex(restr, RegexOptions.IgnoreCase);
            MatchCollection ma= recss.Matches(html);
            int a = ma.Count;
            //"<link\\b[^<>]*?href=\"[^<>]*?.css"
        }
    }
}
