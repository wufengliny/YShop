using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YForm
{
    public partial class Collect37Img : Form
    {
        public Collect37Img()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = " select * from AMH_Vedio ";
            DataTable dt= new Yax.BLL.BCommon().GetDataBySQL(str);
            for(int i=0;i<dt.Rows.Count;i++)
            {
                string html = Yax.Common.HTTPHelper.GetHTMLUTF8(dt.Rows[i]["FromPageUrl"].ToString());

            }
            MessageBox.Show(dt.Rows[0]["Name"].ToString());
        }
    }
}
