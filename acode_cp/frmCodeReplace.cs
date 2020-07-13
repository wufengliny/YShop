using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace acode
{
    public partial class frmCodeReplace : Form
    {
        public frmCodeReplace()
        {
            InitializeComponent();
        }

        private void TextBox2_DoubleClick(object sender, EventArgs e)
        {
            this.TextBox2.SelectAll();
        }
        private string ReplaceText(string input)
        {
            string pattern = @"[^\u4e00-\u9fa5]";
            Regex rgx = new Regex(pattern);
            string outputStr = rgx.Replace(input, "");
            return outputStr;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.TextBox2.Text = this.TextBox1.Text.Replace("\"", "\\\"");
            string[] arr_text = this.TextBox2.Text.Split('\n');
            this.TextBox2.Text = "";
            foreach (string str in arr_text)
            {
                if (this.checkBox1.Checked)
                {
                    this.TextBox2.Text += "" + txtVName.Text + ".Append(\"" + str.Replace("\r", "") + "\\r\\n\");\r\n";
                }
                else
                {
                    this.TextBox2.Text += "" + txtVName.Text + ".Append(\"" + str.Replace("\r", "") + "\\n\");\r\n";
                }
            }
        }

        private void TextBox1_DoubleClick(object sender, EventArgs e)
        {
            this.TextBox1.SelectAll();
        }

        private void btnChangeStr_Click(object sender, EventArgs e)
        {
            string[] tt = this.TextBox1.Text.Trim().Replace("\r\n", "|").Split('|');
            string ttp = "";
            string ttpa = "";
            for (int i = 0; i < tt.Length; i++)
            {
                ttp += Convert .ToString (i+1) + "|";
                ttpa += tt[i] + "|";
            }
            ttp = ttp.Substring (0,ttp .Length -1);
            ttpa = ttpa.Substring(0, ttpa.Length - 1);
            this.TextBox2.Text = ttpa+"\r\n"+ttp;
       
        }

        private void btnChinese_Click(object sender, EventArgs e)
        {
            this.TextBox1.Text = this.ReplaceText(this.TextBox1.Text);
        }

        private void frmCodeReplace_Load(object sender, EventArgs e)
        {

        }

        private void btnSql_Click(object sender, EventArgs e)
        {
            this.TextBox2.Text = "";
            if (this.TextBox1.Text != "")
            {
                string[] temp = this.TextBox1.Text .Split('\n');
                this.TextBox2.Text += "CREATE TABLE [dbo].[" + this.txtVName.Text + "]\n(\n";

                this.TextBox2.Text += "[ID] [int] IDENTITY (1, 1) NOT NULL ,\r\n";
                foreach (string strtemp in temp)
                {
                    this.TextBox2.Text += "[" + DXHanZiToPinYin.DXHanZiToPinYin.Convert(strtemp.Replace("(下拉)", "").Replace("(复选)", "").Replace("(单选)", ""), 50) + "] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,\r\n";
                }
                this.TextBox2.Text += "[IsLock] [smallint] NULL ,\r\n";
                this.TextBox2.Text += "[AddTime] [datetime] NULL ,\r\n";
                this.TextBox2.Text += "[UpdateTime] [datetime] NULL ,\r\n";
                this.TextBox2.Text += "[IsTop] [int] NULL \r\n)ON [PRIMARY]\r\n\r\n";

                foreach (string strtemp in temp)
                {
                    string pstr = DXHanZiToPinYin.DXHanZiToPinYin.Convert(strtemp, 50);
                    this.TextBox2.Text += "EXECUTE sp_addextendedproperty N'MS_Description', '" + strtemp.Replace(" ", "").Replace("\r", "") + "', N'user', N'dbo', N'table', N'" + this.txtVName.Text + "', N'column', N'" + pstr + "'";
                }


            }

        }

        private void btnToPinYing_Click(object sender, EventArgs e)
        {
            this.TextBox2.Text = DXHanZiToPinYin.DXHanZiToPinYin.Convert(this.TextBox1.Text);
        }
    }
}