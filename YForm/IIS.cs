using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace YForm
{
    public partial class IIS : Form
    {
        public IIS()
        {
            InitializeComponent();
        }

        private void IIS_Load(object sender, EventArgs e)
        {
            Thread th = new Thread(JianCe);
            th.IsBackground = true;
            th.Start();
        }
        private void JianCe()
        {
            while(true)
            {
                string url = "http://www.pro-leaf.cn/home/aboutus?menuid=2";
                string str = Yax.Common.HTTPHelper.GetHTMLUTF8(url);
                if (str.Contains("container"))
                {
                    this.txtInfo.Text += "正常"+DateTime.Now +"\r\n";
                }
                else
                {
                    string res = Yax.Common.Utils.CMD("iisreset");
                    this.txtInfo.Text += res + "\r\n";
                }
                int lengthtxt = 2000;
                if (this.txtInfo.Text.Length> lengthtxt)
                {
                    this.txtInfo.Text = this.txtInfo.Text.Substring(lengthtxt/2, this.txtInfo.Text.Length-lengthtxt /2);
                }
                Thread.Sleep(120000);
            }
        }
    }
}
