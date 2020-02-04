using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yax.Common.DataModelHelper;

namespace YForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = Yax.Common.SecurityHelper.Encrypt(this.textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = Yax.Common.SecurityHelper.Decrypt(this.textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int a= r.Next(5);
            this.textBox1.Text = a.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        } 

        private void button5_Click(object sender, EventArgs e)
        {
            int i = 1;
            int.TryParse(this.textBox1.Text, out i);
            int pageIndex = 1;
            string phone = "";
            int pageSize = 20;
            int TotalCount;
            int TotalPage;
            string strWhere = "1=1 and enable=1 ";
            if (!string.IsNullOrEmpty(phone))
            {
                strWhere += " and  phone like '%" + phone + "%'";
            }
            Yax.BLL.MoneyDetail bll = new Yax.BLL.MoneyDetail();
            List<Yax.Model.MoneyDetail> list = bll.GetPage(pageIndex, pageSize, strWhere, "ID desc", "*", out TotalCount, out TotalPage);
            i = i + 1;
            this.textBox1.Text = i.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
