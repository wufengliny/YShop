using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string txt = this.txtmsg.Text;
            this.txtres.Text = Regex.Unescape(txt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txt = this.txtmsg.Text;
            this.txtres.Text =UCommon.UUtils.ChToUnicode(txt);
        }
    }
}
