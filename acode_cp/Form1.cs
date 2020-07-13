using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;
using System.IO;
namespace acode
{
    public partial class Form1 : Form
    {
        private string Temp = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            //MessageBox .Show (Microsoft.VisualBasic.Strings.StrConv ("发",Microsoft.VisualBasic.VbStrConv.TraditionalChinese  ,1));
            this.LoadTable();
        }
        private void LoadTable()
        {
            DataSet ds = DbHelperSQL.Query("select  *  from  sysobjects  where  xtype='U' order by name asc");
            this.cobTable.Items.Clear();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                this.cobTable.Items.Add(row["name"].ToString());
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }
            string tableName = this.cobTable.SelectedItem.ToString().Trim();

            if (this.radioButton1.Checked)
            {
                this.txtValue.Text = "";

                this.txtValue.Text = Control.WebPageByAddSingle(Temp, Control.CommonFile, Control.NamespaceName, this.txtClassName.Text, tableName, Control.TabHtml, Control.TdTopHtml, Control.TdHtml, Control.TdButtomHtml, Control.InputCss, Control.TextAreaCss, Control.BottonCss).ToString();
            }
            //双排
            if (this.radioButton2.Checked)
            {
                this.txtValue.Text = "";
                this.txtValue.Text += "<form id=\"form1\" runat=\"server\" onsubmit=\"return CheckForm();\">\r\n";
                this.txtValue.Text += "<table width=\"600\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\">\r\n";
                this.txtValue.Text += "<tr>\r\n";
                this.txtValue.Text += "<td height=\"30\" colspan=\"4\" align=\"center\" class=\"title\">添加" + this.cobTable.SelectedItem.ToString().Trim() + "</td> \r\n";
                this.txtValue.Text += "</tr>\r\n\r\n";
                DataSet ds = DbHelperSQL.Query(" exec SysTable  '" + this.cobTable.SelectedItem.ToString().Trim() + "'");

                int i = 0;
                this.txtValue.Text += "<tr>\r\n";
                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    string description = row["description"].ToString();

                    string str = row["column_name"].ToString();
                    if (description == "")
                    {
                        description = str;
                    }


                    if (Temp.IndexOf("|" + str + "|") > -1)
                    {
                        this.txtValue.Text += "<td align=\"right\" height=\"30\"><font color=\"red\">*</font>";
                        txtValue.Text += description.Replace("(下拉)", "").Replace("(复选)", "").Replace("(单选)", "").Replace(" ", "") + "：</td>\r\n";

                        if (description.IndexOf("(下拉)") > -1)
                        {
                            this.txtValue.Text += "<td align=\"left\">\r\n<select name=\"" + str + "\" id=\"" + str + "\"  >\r\n<option value=\"\">请选择</option>\r\n<%=LoadOption_" + str + "()%>\n</select>\r\n</td>\r\n";
                        }
                        else if (description.IndexOf("(复选)") > -1)
                        {
                            this.txtValue.Text += "<td align=\"left\"><%=LoadCheck_" + str + "()%></td>\r\n";
                        }
                        else if (description.IndexOf("(单选)") > -1)
                        {
                            this.txtValue.Text += "<td align=\"left\"><%=LoadRadio_" + str + "()%></td>\r\n";
                        }
                        else if (row["data_type"].ToString().ToLower() == "text" || row["data_type"].ToString().ToLower() == "ntext")
                        {
                            this.txtValue.Text += "<td align=\"left\">\n<textarea name=\"" + str + "\" id =\"" + str + "\" cols=\"40\" rows=\"8\" ></textarea>\n</td>\r\n";
                        }
                        else
                        {
                            this.txtValue.Text += "<td align=\"left\"><input type=\"text\" name=\"" + str + "\" id =\"" + str + "\" value=\"\" /></td>\r\n";
                        }
                        i++;
                        if (i != 0 && i % 2 == 0)
                        {
                            this.txtValue.Text += "</tr>\r\n\r\n";
                            this.txtValue.Text += "<tr>\r\n";
                        }
                    }

                }
                this.txtValue.Text += "</tr>\r\n\r\n";

                this.txtValue.Text += "<tr>\r\n<td height=\"30\" colspan=\"4\" align=\"center\">\r\n";
                this.txtValue.Text += "<asp:Button ID=\"btnSave\" runat=\"server\" OnClick=\"btnSave_Click\" Text=\"提交保存\" />&nbsp;&nbsp;&nbsp;&nbsp;<input type=\"reset\" name=\"Submit\" value=\" 重  置 \" />";
                this.txtValue.Text += "</td>\r\n</tr>\r\n</table>\r\n";
                this.txtValue.Text += "</form>\n";
            }

        }

        private void btnAddCode_Click(object sender, EventArgs e)
        {
            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }
            string tableName = this.cobTable.SelectedItem.ToString().Trim();
            string tpath = "";
            if (this.txtClassName.Text != "")
            {
                tpath = this.txtClassName.Text.Remove(this.txtClassName.Text.Length - 1, 1);
            }
            this.txtValue.Text = "";
            this.txtValue.Text = Control.CsPageByAdd(Temp, tableName, tpath, this.checkBox1.Checked).ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }
            string tableName = this.cobTable.SelectedItem.ToString().Trim();

            if (this.radioButton1.Checked)
            {
                this.txtValue.Text = "";

                this.txtValue.Text = Control.WebPageByUpdateSingle(Temp, Control.CommonFile, Control.NamespaceName, this.txtClassName.Text, tableName, Control.TabHtml, Control.TdTopHtml, Control.TdHtml, Control.TdButtomHtml, Control.InputCss, Control.TextAreaCss, Control.BottonCss).ToString();
            }
            //-===============双列
            if (this.radioButton4.Checked)
            {
                this.txtValue.Text = "";
                this.txtValue.Text += "<form id=\"form1\" runat=\"server\" onsubmit=\"return CheckForm();\">\r\n";
                this.txtValue.Text += "<input name=\"ID\" id=\"ID\" type=\"hidden\" value=\"<%=ID%>\" />\r\n<table width=\"600\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\">\r\n";
                this.txtValue.Text += "<tr>\r\n";
                this.txtValue.Text += "<td height=\"30\" colspan=\"4\" align=\"center\" class=\"title\">修改" + this.cobTable.SelectedItem.ToString().Trim() + "</td> \r\n";
                this.txtValue.Text += "</tr>\r\n\r\n";
                DataSet ds = DbHelperSQL.Query(" exec SysTable  '" + this.cobTable.SelectedItem.ToString().Trim() + "'");

                int i = 0;
                this.txtValue.Text += "<tr>\r\n";

                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    string description = row["description"].ToString();

                    string str = row["column_name"].ToString();
                    if (description == "")
                    {
                        description = str;
                    }
                    if (Temp.IndexOf("|" + row["column_name"].ToString() + "|") > -1)
                    {
                        this.txtValue.Text += "<td align=\"right\"  height=\"30\"><font color=\"red\">*</font>";
                        txtValue.Text += description.Replace("(下拉)", "").Replace("(复选)", "").Replace("(单选)", "").Replace(" ", "") + "：</td>\r\n";

                        if (description.IndexOf("(下拉)") > -1)
                        {
                            this.txtValue.Text += "<td align=\"left\">\r\n<select name=\"" + str + "\" id=\"" + str + "\"  >\r\n<option value=\"\">请选择</option>\r\n<%=LoadOption_" + str + "(" + str + ")%>\r\n</select>\r\n</td>\r\n";
                        }
                        else if (description.IndexOf("(复选)") > -1)
                        {
                            if (row["data_type"].ToString() == "int" || row["data_type"].ToString() == "smallint")
                            {
                                this.txtValue.Text += "<td align=\"left\" >\r\n<%=LoadCheck_" + str + "(" + str + ".ToString())%>\r\n</td>\r\n";
                            }
                            else
                            {
                                this.txtValue.Text += "<td align=\"left\" >\r\n<%=LoadCheck_" + str + "(" + str + ")%>\r\n</td>\r\n";
                            }
                        }
                        else if (description.IndexOf("(单选)") > -1)
                        {
                            if (row["data_type"].ToString() == "int" || row["data_type"].ToString() == "smallint")
                            {
                                this.txtValue.Text += "<td align=\"left\" >\r\n<%=LoadRadio_" + str + "(" + str + ".ToString())%>\r\n</td>\r\n";
                            }
                            else
                            {
                                this.txtValue.Text += "<td align=\"left\" >\r\n<%=LoadRadio_" + str + "(" + str + ")%>\r\n</td>\r\n";
                            }
                        }
                        else if (row["data_type"].ToString().ToLower() == "text" || row["data_type"].ToString().ToLower() == "ntext")
                        {
                            this.txtValue.Text += "<td align=\"left\">\n<textarea name=\"" + str + "\" id =\"" + str + "\" cols=\"40\" rows=\"8\" ><%=" + str + "%></textarea>\n</td>\r\n";
                        }
                        else
                        {
                            this.txtValue.Text += "<td align=\"left\" ><input type=\"text\" name=\"" + str + "\" id =\"" + str + "\" value=\"<%=" + str + "%>\"  /></td>\r\n";

                        }
                        i++;
                        if (i != 0 && i % 2 == 0)
                        {
                            this.txtValue.Text += "</tr>\r\n\r\n";
                            this.txtValue.Text += "<tr>\r\n";
                        }
                    }



                }

                this.txtValue.Text += "<tr>\r\n<td height=\"30\" colspan=\"4\" align=\"center\">\r\n";
                this.txtValue.Text += "<asp:Button ID=\"btnSave\" runat=\"server\" OnClick=\"btnSave_Click\" Text=\"提交保存\" />&nbsp;&nbsp;&nbsp;&nbsp;<input type=\"reset\" name=\"Submit\" value=\" 重  置 \" />\r\n";
                this.txtValue.Text += "</td>\r\n</tr>\r\n</table>\r\n";
                this.txtValue.Text += "</form>\n";
            }
        }

        private void btnUpdateCode_Click(object sender, EventArgs e)
        {
            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }
            string tableName = this.cobTable.SelectedItem.ToString().Trim();
            string tpath = "";
            if (this.txtClassName.Text != "")
            {
                tpath = this.txtClassName.Text.Remove(this.txtClassName.Text.Length - 1, 1);
            }
            this.txtValue.Text = "";
            this.txtValue.Text = Control.CsPageByUpdate(Temp, tableName, tpath, this.checkBox2.Checked).ToString();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            DataSet ds = DbHelperSQL.Query(" exec SysTable  '" + this.cobTable.SelectedItem.ToString().Trim() + "'");
            this.checkedListBox1.Items.Clear();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                this.checkedListBox1.Items.Add(row["column_name"].ToString(), true);
            }

            Temp = "|";

            for (int j = 0; j < checkedListBox1.Items.Count; j++)
            {
                if (checkedListBox1.GetItemChecked(j))
                {
                    Temp += checkedListBox1.Items[j].ToString() + "|";
                }
            }


        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAll.Checked)
            {
                for (int j = 0; j < this.checkedListBox1.Items.Count; j++)
                {
                    checkedListBox1.SetItemChecked(j, true);
                }
            }
            else
            {
                for (int j = 0; j < this.checkedListBox1.Items.Count; j++)
                {
                    checkedListBox1.SetItemChecked(j, false);
                }
            }

            Temp = "|";

            for (int j = 0; j < checkedListBox1.Items.Count; j++)
            {
                if (checkedListBox1.GetItemChecked(j))
                {
                    Temp += checkedListBox1.Items[j].ToString() + "|";
                }
            }

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Temp = "|";

            for (int j = 0; j < checkedListBox1.Items.Count; j++)
            {
                if (checkedListBox1.GetItemChecked(j))
                {
                    Temp += checkedListBox1.Items[j].ToString() + "|";
                }
            }



        }

        private void cobTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = DbHelperSQL.Query(" exec SysTable  '" + this.cobTable.SelectedItem.ToString() + "'");
            this.checkedListBox1.Items.Clear();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                this.checkedListBox1.Items.Add(row["column_name"].ToString(), true);

            }
            Temp = "|";

            for (int j = 0; j < checkedListBox1.Items.Count; j++)
            {
                if (checkedListBox1.GetItemChecked(j))
                {
                    Temp += checkedListBox1.Items[j].ToString() + "|";
                }
            }
        }

        private void txtValue_DoubleClick(object sender, EventArgs e)
        {
            this.txtValue.SelectAll();
        }

        private void 字符过滤ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCodeReplace f = new frmCodeReplace();
            f.Show();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }
            string tableName = this.cobTable.SelectedItem.ToString().Trim();
            this.txtValue.Text = Control.WebPageByInfoSingle(Temp, Control.CommonFile, Control.NamespaceName, this.txtClassName.Text, tableName, Control.TabHtml, Control.TdTopHtml, Control.TdHtml, Control.TdButtomHtml, Control.InputCss, Control.TextAreaCss, Control.BottonCss).ToString();


        
        }

        private void btnDetailCode_Click(object sender, EventArgs e)
        {
            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }

            
        }

        private void btnListCode_Click(object sender, EventArgs e)
        {
            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }

            string tableName = this.cobTable.SelectedItem.ToString();
            string path = "";
            if (this.txtClassName.Text != "")
            {
                path = this.txtClassName.Text.Remove(this.txtClassName.Text.Length - 1, 1);
            }
            string[] temp = Temp.Split('|');

            if (rdbPageList.Checked)//分页列表
            {

                this.txtValue.Text = "";
                this.txtValue.Text = Control.CsPageByList(tableName, path, this.chkSort.Checked).ToString();

            }

            if (rdbTopList.Checked)//Top列表
            {

                this.txtValue.Text = "";
                txtValue.Text += "/// <summary>\r\n///列表数据显示\r\n/// </summary>\r\n";
                txtValue.Text += "protected System .Text .StringBuilder LoadTopList()\r\n{\r\n";
                txtValue.Text += "System.Text.StringBuilder strTopList = new System.Text.StringBuilder();\r\n";
                txtValue.Text += "BLL." + this.cobTable.SelectedItem.ToString() + " bll = new BLL. " + this.cobTable.SelectedItem.ToString() + "();\r\n";
                txtValue.Text += "DataSet ds = bll.GetList(10,\"" + Temp.Replace("|", ",").Remove(0, 1).Remove(Temp.Length - 2) + "\",\"" + this.cobTable.SelectedItem.ToString() + "\",\"\",\"id desc\");\r\n";
                txtValue.Text += "foreach (DataRow row in ds.Tables[0].Rows)\r\n{\r\n";
                txtValue.Text += "\r\n}\r\nreturn strTopList;\r\n}\r\n";
                txtValue.Text += "\r\n\r\n\r\n";

            }

        }

        private void btnOption_Click(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }
            string tableName = this.cobTable.SelectedItem.ToString();

            this.txtValue.Text = "";
            this.txtValue.Text = Control.WebPageByList(tableName, Temp, this.txtClassName.Text, this.chkSort.Checked).ToString();
        }

        private void btnJs_Click(object sender, EventArgs e)
        {
            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }

            string tableName = this.cobTable.SelectedItem.ToString().Trim();

            if (this.radioButton7.Checked)//不为空
            {
                this.txtValue.Text = "";
                this.txtValue.Text = Control.JsPageAdd(Temp, tableName).ToString();

            }

            if (this.radioButton8.Checked)//电子邮件
            {
                this.txtValue.Text = "";
                this.txtValue.Text += "<script language=\"javascript\" type=\"text/javascript\" >\r\n";
                this.txtValue.Text += "<!--\r\n";
                this.txtValue.Text += "function CheckForm()\r\n";
                this.txtValue.Text += "{\r\n";
                DataSet ds = DbHelperSQL.Query(" exec SysTable  '" + this.cobTable.SelectedItem.ToString().Trim() + "'");
                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    string description = row["description"].ToString();

                    string str = row["column_name"].ToString();
                    if (description == "")
                    {
                        description = str;
                    }
                    if (Temp.IndexOf("|" + str + "|") > -1)
                    {
                        this.txtValue.Text += "  var " + str + "Reg = /^([a-zA-Z0-9]+[_|\\_|\\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\\_|\\.]?)*[a-zA-Z0-9]+\\.[a-zA-Z]{2,3}$/;\r\n";
                        this.txtValue.Text += "  if (!" + str + "Reg.test(document.getElementById (\"" + str + "\").value))\r\n";
                        this.txtValue.Text += "  {\r\n";
                        this.txtValue.Text += "	  alert(\"" + description.Replace("(下拉)", "").Replace("(复选)", "").Replace("(单选)", "").Replace(" ", "").Replace("\n", "") + "电子邮件格式不对!\");\r\n";
                        this.txtValue.Text += "          document.getElementById (\"" + str + "\").focus();\r\n";
                        this.txtValue.Text += "	  return false;\r\n";
                        this.txtValue.Text += "  }\r\n";
                        this.txtValue.Text += " \r\n";
                    }

                }
                this.txtValue.Text += "  return true;\r\n";
                this.txtValue.Text += "}\r\n";
                this.txtValue.Text += "// -->\r\n";
                this.txtValue.Text += "</script>\r\n";
            }

            if (this.radioButton9.Checked)//电话号话
            {
                this.txtValue.Text = "";
                this.txtValue.Text += "<script language=\"javascript\" type=\"text/javascript\" >\r\n";
                this.txtValue.Text += "<!--\r\n";
                this.txtValue.Text += "function CheckForm()\r\n";
                this.txtValue.Text += "{\r\n";
                DataSet ds = DbHelperSQL.Query(" exec SysTable  '" + this.cobTable.SelectedItem.ToString().Trim() + "'");
                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    string description = row["description"].ToString();

                    string str = row["column_name"].ToString();
                    if (description == "")
                    {
                        description = str;
                    }
                    if (Temp.IndexOf("|" + str + "|") > -1)
                    {
                        this.txtValue.Text += "  var " + str + "Reg = /(^[0-9]{3,4}\\-[0-9]{3,8}$)|(^[0-9]{3,8}$)/;\r\n";
                        this.txtValue.Text += "  if (!" + str + "Reg.test(document.getElementById (\"" + str + "\").value))\r\n";
                        this.txtValue.Text += "  {\r\n";
                        this.txtValue.Text += "	  alert(\"" + description.Replace("(下拉)", "").Replace("(复选)", "").Replace("(单选)", "").Replace(" ", "").Replace("\n", "") + "电话号码格式不对!\");\r\n";
                        this.txtValue.Text += "          document.getElementById (\"" + str + "\").focus();\r\n";
                        this.txtValue.Text += "	  return false;\r\n";
                        this.txtValue.Text += "  }\r\n";
                        this.txtValue.Text += " \r\n";
                    }

                }
                this.txtValue.Text += "  return true;\r\n";
                this.txtValue.Text += "}\r\n";
                this.txtValue.Text += "// -->\r\n";
                this.txtValue.Text += "</script>\r\n";
            }

            if (this.radioButton10.Checked)//数字
            {
                this.txtValue.Text = "";
                this.txtValue.Text += "<script language=\"javascript\" type=\"text/javascript\" >\r\n";
                this.txtValue.Text += "<!--\r\n";
                this.txtValue.Text += "function CheckForm()\r\n";
                this.txtValue.Text += "{\r\n";
                DataSet ds = DbHelperSQL.Query(" exec SysTable  '" + this.cobTable.SelectedItem.ToString().Trim() + "'");
                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    string description = row["description"].ToString();

                    string str = row["column_name"].ToString();
                    if (description == "")
                    {
                        description = str;
                    }
                    if (Temp.IndexOf("|" + str + "|") > -1)
                    {
                        this.txtValue.Text += "  var " + str + "Reg = /^[\\d\\.]+$/;\r\n";
                        this.txtValue.Text += "  if (!" + str + "Reg.test(document.getElementById (\"" + str + "\").value))\r\n";
                        this.txtValue.Text += "  {\r\n";
                        this.txtValue.Text += "	  alert(\"" + description.Replace("(下拉)", "").Replace("(复选)", "").Replace("(单选)", "").Replace(" ", "").Replace("\n", "") + "必须为数字!\");\r\n";
                        this.txtValue.Text += "          document.getElementById (\"" + str + "\").focus();\r\n";
                        this.txtValue.Text += "	  return false;\r\n";
                        this.txtValue.Text += "  }\r\n";
                        this.txtValue.Text += " \r\n";
                    }

                }
                this.txtValue.Text += "  return true;\r\n";
                this.txtValue.Text += "}\r\n";
                this.txtValue.Text += "// -->\r\n";
                this.txtValue.Text += "</script>\r\n";
            }

            if (this.radioButton11.Checked)//手机号码
            {
                this.txtValue.Text = "";
                this.txtValue.Text += "<script language=\"javascript\" type=\"text/javascript\" >\r\n";
                this.txtValue.Text += "<!--\r\n";
                this.txtValue.Text += "function CheckForm()\r\n";
                this.txtValue.Text += "{\r\n";
                DataSet ds = DbHelperSQL.Query(" exec SysTable  '" + this.cobTable.SelectedItem.ToString().Trim() + "'");
                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    string description = row["description"].ToString();

                    string str = row["column_name"].ToString();
                    if (description == "")
                    {
                        description = str;
                    }
                    if (Temp.IndexOf("|" + str + "|") > -1)
                    {
                        this.txtValue.Text += "  var " + str + "Reg = /^\\d{11}$/;\r\n";
                        this.txtValue.Text += "  if (!" + str + "Reg.test(document.getElementById (\"" + str + "\").value))\r\n";
                        this.txtValue.Text += "  {\r\n";
                        this.txtValue.Text += "	  alert(\"" + description.Replace("(下拉)", "").Replace("(复选)", "").Replace("(单选)", "").Replace(" ", "").Replace("\n", "") + "手机号码格式不对!\");\r\n";
                        this.txtValue.Text += "          document.getElementById (\"" + str + "\").focus();\r\n";
                        this.txtValue.Text += "	  return false;\r\n";
                        this.txtValue.Text += "  }\r\n";
                        this.txtValue.Text += " \r\n";
                    }

                }
                this.txtValue.Text += "  return true;\r\n";
                this.txtValue.Text += "}\r\n";
                this.txtValue.Text += "// -->\r\n";
                this.txtValue.Text += "</script>\r\n";
            }

            if (this.radioButton12.Checked)//邮编
            {
                this.txtValue.Text = "";
                this.txtValue.Text += "<script language=\"javascript\" type=\"text/javascript\" >\r\n";
                this.txtValue.Text += "<!--\r\n";
                this.txtValue.Text += "function CheckForm()\r\n";
                this.txtValue.Text += "{\r\n";
                DataSet ds = DbHelperSQL.Query(" exec SysTable  '" + this.cobTable.SelectedItem.ToString().Trim() + "'");
                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    string description = row["description"].ToString();

                    string str = row["column_name"].ToString();
                    if (description == "")
                    {
                        description = str;
                    }
                    if (Temp.IndexOf("|" + str + "|") > -1)
                    {
                        this.txtValue.Text += "  var " + str + "Reg = /^\\d{6}$/;\r\n";
                        this.txtValue.Text += "  if (!" + str + "Reg.test(document.getElementById (\"" + str + "\").value))\r\n";
                        this.txtValue.Text += "  {\r\n";
                        this.txtValue.Text += "	  alert(\"" + description.Replace("(下拉)", "").Replace("(复选)", "").Replace("(单选)", "").Replace(" ", "").Replace("\n", "") + "邮编格式不对!\");\r\n";
                        this.txtValue.Text += "          document.getElementById (\"" + str + "\").focus();\r\n";
                        this.txtValue.Text += "	  return false;\r\n";
                        this.txtValue.Text += "  }\r\n";
                        this.txtValue.Text += " \r\n";
                    }

                }
                this.txtValue.Text += "  return true;\r\n";
                this.txtValue.Text += "}\r\n";
                this.txtValue.Text += "// -->\r\n";
                this.txtValue.Text += "</script>\r\n";
            }

        }

        private string GetDBType(string instr)
        {

            string temp = "";

            switch (instr)
            {
                case "int":
                    {
                        temp = "Int";
                        break;
                    }
                case "smallint":
                    {
                        temp = "SmallInt";
                        break;
                    }
                case "tinyint":
                    {
                        temp = "TinyInt";
                        break;
                    }
                case "bigint":
                    {
                        temp = "BigInt";
                        break;
                    }
                case "varchar":
                    {
                        temp = "VarChar";
                        break;
                    }
                case "nvarchar":
                    {
                        temp = "NVarChar";
                        break;
                    }
                case "datetime":
                    {
                        temp = "DateTime";
                        break;
                    }
                case "smalldatetime":
                    {
                        temp = "SmallDateTime";
                        break;
                    }
                case "timestamp":
                    {
                        temp = "Timestamp";
                        break;
                    }
                case "text":
                    {
                        temp = "Text";
                        break;
                    }
                case "ntext":
                    {
                        temp = "NText";
                        break;
                    }
                case "char":
                    {
                        temp = "Char";
                        break;
                    }
                case "nchar":
                    {
                        temp = "NChar";
                        break;
                    }
                case "bit":
                    {
                        temp = "Bit";
                        break;
                    }
                case "real":
                    {
                        temp = "Real";
                        break;
                    }
                case "money":
                    {
                        temp = "Money";
                        break;
                    }
                case "smallmoney":
                    {
                        temp = "SmallMoney";
                        break;
                    }
                case "float":
                    {
                        temp = "Float";
                        break;
                    }
                case "decimal":
                    {
                        temp = "Decimal";
                        break;
                    }
                case "numeric":
                    {
                        temp = "Decimal";
                        break;
                    }
                case "varbinary":
                    {
                        temp = "VarBinary";
                        break;
                    }
            }
            return temp;

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }

            this.txtValue.Text = "";
            this.txtValue.Text += "/// <summary>\r\n";
            this.txtValue.Text += "/// 增加一条数据\r\n";
            this.txtValue.Text += "/// </summary>\r\n";
            this.txtValue.Text += "public int Add(Model." + this.cobTable.SelectedItem.ToString().Trim() + " model)\r\n";
            this.txtValue.Text += "{\r\n";
            this.txtValue.Text += "		StringBuilder strSql=new StringBuilder();\r\n";
            this.txtValue.Text += "		strSql.Append(\"INSERT INTO " + this.cobTable.SelectedItem.ToString().Trim() + "(\");\r\n";

            string temp1 = Temp.Replace('|', ',');
            string temp2 = Temp.Replace("|", ",@");

            temp1 = temp1.Substring(1, temp1.Length - 2);
            temp2 = temp2.Substring(1, temp2.Length - 3);
            this.txtValue.Text += "		strSql.Append(\"" + temp1 + ")\");\r\n";
            this.txtValue.Text += "		strSql.Append(\" VALUES (\");\r\n";
            this.txtValue.Text += "		strSql.Append(\"" + temp2 + ")\");\r\n";

            DataSet ds = DbHelperSQL.Query(" exec SysTable  '" + this.cobTable.SelectedItem.ToString().Trim() + "'");
            this.txtValue.Text += "     		SqlParameter[] parameters = {\r\n";
            foreach (DataRow row in ds.Tables[0].Rows)
            {

                string description = row["description"].ToString();

                string str = row["column_name"].ToString();
                if (description == "")
                {
                    description = str;
                }
                if (Temp.IndexOf("|" + str + "|") > -1)
                {
                    if (this.GetDBType(row["data_type"].ToString()) == "Text" || this.GetDBType(row["data_type"].ToString()) == "NText")
                    {
                        this.txtValue.Text += "		            new SqlParameter(\"@" + str + "\", SqlDbType." + this.GetDBType(row["data_type"].ToString()) + "),\r\n";
                    }
                    else
                    {
                        this.txtValue.Text += "		            new SqlParameter(\"@" + str + "\", SqlDbType." + this.GetDBType(row["data_type"].ToString()) + "," + row["占用字节数"].ToString() + "),\r\n";
                    }
                }
            }
            this.txtValue.Text = this.txtValue.Text.Substring(0, this.txtValue.Text.Length - 3);
            this.txtValue.Text += "};\r\n";

            int i = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string description = row["description"].ToString();

                string str = row["column_name"].ToString();
                if (description == "")
                {
                    description = str;
                }
                if (Temp.IndexOf("|" + str + "|") > -1)
                {
                    this.txtValue.Text += "		parameters[" + i.ToString() + "].Value = model." + str + ";\r\n";
                    i++;
                }
            }
            this.txtValue.Text += "\r\n		return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType .Text,strSql.ToString (),parameters);\r\n}\r\n";


        }


        private void btnUpdateDA_Click(object sender, EventArgs e)
        {
            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }

            this.txtValue.Text = "";
            this.txtValue.Text += "/// <summary>\r\n";
            this.txtValue.Text += "/// 修改数据\r\n";
            this.txtValue.Text += "/// </summary>\r\n";
            this.txtValue.Text += "public int Update(Model." + this.cobTable.SelectedItem.ToString() + " model)\r\n";
            this.txtValue.Text += "{\r\n";
            this.txtValue.Text += "	StringBuilder strSql=new StringBuilder();\r\n";
            this.txtValue.Text += "	strSql.Append(\"update " + this.cobTable.SelectedItem.ToString() + " set \");\r\n";

            DataSet ds = DbHelperSQL.Query(" exec SysTable  '" + this.cobTable.SelectedItem.ToString().Trim() + "'");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string description = row["description"].ToString();

                string str = row["column_name"].ToString();
                if (description == "")
                {
                    description = str;
                }
                if (str != "ID")
                {
                    if (Temp.IndexOf("|" + str + "|") > -1)
                    {
                        this.txtValue.Text += "	strSql.Append(\"" + str + "=@" + str + ",\");\r\n";

                    }
                }
            }
            this.txtValue.Text = this.txtValue.Text.Substring(0, this.txtValue.Text.Length - 6);
            this.txtValue.Text += "\");\r\n";
            this.txtValue.Text += "	strSql.Append(\" where ID=@ID\");\r\n";

            this.txtValue.Text += "	SqlParameter[] parameters = {\r\n";
            this.txtValue.Text += "		            new SqlParameter(\"@ID\", SqlDbType.Int,4),\r\n";

            foreach (DataRow row in ds.Tables[0].Rows)
            {

                string description = row["description"].ToString();

                string str = row["column_name"].ToString();
                if (description == "")
                {
                    description = str;
                }
                if (str != "ID")
                {
                    if (Temp.IndexOf("|" + str + "|") > -1)
                    {
                        if (this.GetDBType(row["data_type"].ToString()) == "Text" || this.GetDBType(row["data_type"].ToString()) == "NText")
                        {
                            this.txtValue.Text += "		            new SqlParameter(\"@" + str + "\", SqlDbType." + this.GetDBType(row["data_type"].ToString()) + "),\r\n";
                        }
                        else
                        {
                            this.txtValue.Text += "		            new SqlParameter(\"@" + str + "\", SqlDbType." + this.GetDBType(row["data_type"].ToString()) + "," + row["占用字节数"].ToString() + "),\r\n";
                        }
                    }
                }
            }
            this.txtValue.Text = this.txtValue.Text.Substring(0, this.txtValue.Text.Length - 3);
            this.txtValue.Text += "};\r\n";

            int i = 1;
            this.txtValue.Text += "	parameters[0].Value = model.ID;\r\n";
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string description = row["description"].ToString();

                string str = row["column_name"].ToString();
                if (description == "")
                {
                    description = str;
                }
                if (str != "ID")
                {
                    if (Temp.IndexOf("|" + str + "|") > -1)
                    {
                        this.txtValue.Text += "	parameters[" + i.ToString() + "].Value = model." + str + ";\r\n";
                        i++;
                    }
                }
            }
            this.txtValue.Text += "\r\n	return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType .Text,strSql.ToString (),parameters);\r\n}\r\n";

            this.txtValue.Text += Control.UpdateSort(this.cobTable.SelectedItem.ToString().Trim());

        }

        private void 常用设置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SysConfig frm = new SysConfig();
            frm.Show();
        }

        private void 常用代码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsualCode frm = new UsualCode();
            frm.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOption_Click_1(object sender, EventArgs e)
        {
            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }

            DataSet ds = DbHelperSQL.Query(" exec SysTable  '" + this.cobTable.SelectedItem.ToString() + "'");
            this.txtValue.Text = "";
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (Temp.IndexOf("|" + row["column_name"].ToString() + "|") > -1)
                {

                    txtValue.Text += "//" + row["description"].ToString() + "\r\n";
                    txtValue.Text += "public const string strText_" + row["column_name"].ToString() + " = \"\";\r\n";
                    txtValue.Text += "public const string strValue_" + row["column_name"].ToString() + " = \"\";\r\n";

                    string temps = "";
                    if (row["data_type"].ToString() == "varchar" || row["data_type"].ToString() == "nvarchar" || row["data_type"].ToString() == "text" || row["data_type"].ToString() == "ntext")
                    {
                        temps = row["column_name"].ToString();
                    }
                    else if (row["data_type"].ToString() == "int" || row["data_type"].ToString() == "smallint")
                    {
                        temps = row["column_name"].ToString() + ".ToString()";
                    }

                    this.txtValue.Text += "\r\n<%=Commn.ListHelper.GetItemInfo(WebConst.strText_" + row["column_name"].ToString() + " , WebConst .strValue_" + row["column_name"].ToString() + "," + temps + ")%>\r\n\r\n";

                    this.txtValue.Text += Control.SelectOptionsByDB(this.cobTable.SelectedItem.ToString().Trim(), row["column_name"].ToString());
                    this.txtValue.Text += Control.SelectOptionsByDBSelected(this.cobTable.SelectedItem.ToString().Trim(), row["column_name"].ToString());



                }
            }
        }

        private void checkedListBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }

            this.txtValue.Text = "";
            this.txtValue.Text += "/// <summary>\r\n";
            this.txtValue.Text += "/// 增加一条数据\r\n";
            this.txtValue.Text += "/// </summary>\r\n";
            this.txtValue.Text += "public void Add(Model." + this.cobTable.SelectedItem.ToString().Trim() + " model)\r\n";
            this.txtValue.Text += "{\n";
            this.txtValue.Text += "		StringBuilder strSql=new StringBuilder();\r\n";
            this.txtValue.Text += "		strSql.Append(\"insert into " + this.cobTable.SelectedItem.ToString().Trim() + "(\");\r\n";

            string temp1 = Temp.Replace('|', ',');
            string temp2 = Temp.Replace("|", ",@");

            temp1 = temp1.Substring(1, temp1.Length - 2);
            temp2 = temp2.Substring(1, temp2.Length - 3);
            this.txtValue.Text += "		strSql.Append(\"" + temp1 + ")\");\r\n";
            this.txtValue.Text += "		strSql.Append(\" values (\");\r\n";
            this.txtValue.Text += "		strSql.Append(\"" + temp2 + ")\");\r\n";

            DataSet ds = DbHelperSQL.Query(" exec SysTable  '" + this.cobTable.SelectedItem.ToString().Trim() + "'");
            this.txtValue.Text += "     SqlParameter[] parameters = {\r\n";
            foreach (DataRow row in ds.Tables[0].Rows)
            {

                string description = row["description"].ToString();

                string str = row["column_name"].ToString();
                if (description == "")
                {
                    description = str;
                }
                if (Temp.IndexOf("|" + str + "|") > -1)
                {
                    this.txtValue.Text += "		            new SqlParameter(\"@" + str + "\", SqlDbType." + this.GetDBType(row["data_type"].ToString()) + "," + row["占用字节数"].ToString() + "),\r\n";
                }
            }
            this.txtValue.Text = this.txtValue.Text.Substring(0, this.txtValue.Text.Length - 3);
            this.txtValue.Text += "};\r\n";

            int i = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string description = row["description"].ToString();

                string str = row["column_name"].ToString();
                if (description == "")
                {
                    description = str;
                }
                if (Temp.IndexOf("|" + str + "|") > -1)
                {
                    this.txtValue.Text += "parameters[" + i.ToString() + "].Value = model." + str + ";\r\n";
                    i++;
                }
            }
            this.txtValue.Text += "\r\nDbHelperSQL.ExecuteSql(strSql.ToString(),parameters);\r\n}\r\n";
        }

        ///// <summary>
        ///// 取首字母大写
        ///// </summary>
        ///// <param name="inString"></param>
        ///// <returns></returns>
        //private string toTitleCase(string inString)
        //{
        //    System.Globalization.TextInfo tInfo = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo;
        //    return tInfo.ToTitleCase(inString);
        //}

        private string ConvertToUpper(string str)
        {
            string S = Strings.StrConv(str, VbStrConv.ProperCase, System.Globalization.CultureInfo.CurrentCulture.LCID);
            return S;
        }

        #region 生成DALReader代码
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }
            string tableName = this.cobTable.SelectedItem.ToString().Trim();

            txtValue.Text = this.CreateDALReader(tableName).ToString();

        }
        private StringBuilder CreateDALReader(string tableName)
        {
            StringBuilder strTableList = new StringBuilder();

            strTableList.Append("using System;\r\n");
            strTableList.Append("using System.Collections.Generic;\r\n");
            strTableList.Append("using System.Text;\r\n");
            strTableList.Append("using System.Data;\r\n");
            strTableList.Append("using System.Data.SqlClient;\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("namespace " + Control.NamespaceName + ".SQLServerDAL\r\n");
            strTableList.Append("{\r\n");
            strTableList.Append("    /// <summary>\r\n");
            strTableList.Append("    /// " + tableName + "\r\n");
            strTableList.Append("    /// </summary>\r\n");
            strTableList.Append("    public partial class DataProvider\r\n");
            strTableList.Append("    {\r\n");

            DataSet ds = DbHelperSQL.Query(" exec SysTable  '" + tableName + "'");

            strTableList.Append(this.ConvertToModel(tableName, ds));
            strTableList.Append(this.ConvertToModel2(tableName, ds));
            strTableList.Append(this.Add_String(tableName, ds));
            strTableList.Append(Update_String(tableName, ds));
            strTableList.Append(GetModel(tableName));
            strTableList.Append(GetList(tableName));

            //分页
            strTableList.Append(GetPageList(tableName));
            //strTableList.Append(GetPageListNew(tableName));
            //分页 End

            strTableList.Append("    }\r\n");
            strTableList.Append("}\r\n");

            return strTableList;
        }
        private StringBuilder Add_String(string tableName, DataSet ds)
        {
            StringBuilder strTableList = new StringBuilder();
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 增加一条数据(表" + tableName + ")\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public int " + tableName + "Add(Model." + tableName + " model)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            StringBuilder strSql=new StringBuilder();\r\n");
            strTableList.Append("            strSql.Append(\"INSERT INTO " + tableName + "(\");\r\n");

            string identityCooumnName = string.Empty;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string columnName = row["column_name"].ToString();
                string columnFlag = row["标识"].ToString();
                if (columnFlag == "√")
                {
                    identityCooumnName = columnName;
                    break;
                }

            }

            string temp1 = Temp.Replace("|" + identityCooumnName, "").Replace('|', ',');
            string temp2 = Temp.Replace("|" + identityCooumnName, "").Replace("|", ",@");

            temp1 = temp1.Substring(1, temp1.Length - 2);
            temp2 = temp2.Substring(1, temp2.Length - 3);

            strTableList.Append("            strSql.Append(\"" + temp1 + ")\");\r\n");
            strTableList.Append("            strSql.Append(\" VALUES (\");\r\n");
            strTableList.Append("            strSql.Append(\"" + temp2 + ")\");\r\n");

            strTableList.Append("            SqlParameter[] parameters = {\r\n");
            foreach (DataRow row in ds.Tables[0].Rows)
            {

                string description = row["description"].ToString();

                string str = row["column_name"].ToString();

                string columnFlag = row["标识"].ToString();
                if (columnFlag == "√")
                {
                    continue;
                }

                if (description == "")
                {
                    description = str;
                }
                if (Temp.IndexOf("|" + str + "|") > -1)
                {
                    if (this.GetDBType(row["data_type"].ToString()) == "Text" || this.GetDBType(row["data_type"].ToString()) == "NText")
                    {
                        strTableList.Append("		            new SqlParameter(\"@" + str + "\", SqlDbType." + this.GetDBType(row["data_type"].ToString()) + "),\r\n");
                    }
                    else
                    {
                        strTableList.Append("		            new SqlParameter(\"@" + str + "\", SqlDbType." + this.GetDBType(row["data_type"].ToString()) + "," + row["占用字节数"].ToString() + "),\r\n");
                    }
                }
            }
            strTableList = strTableList.Remove(strTableList.Length - 3, 3);
            strTableList.Append("};\r\n");

            int j = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string columnFlag = row["标识"].ToString();
                if (columnFlag == "√")
                {
                    continue;
                }

                string description = row["description"].ToString();

                string str = row["column_name"].ToString();
                if (description == "")
                {
                    description = str;
                }
                if (Temp.IndexOf("|" + str + "|") > -1)
                {
                    strTableList.Append("            parameters[" + j.ToString() + "].Value = model." + str + ";\r\n");
                    j++;
                }
            }

            strTableList.Append("\r\n            return Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType .Text,strSql.ToString (),parameters);\r\n");
            strTableList.Append("        }\r\n");

            return strTableList;
        }
        /// <summary>
        /// 修改生成的代码
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private string Update_String(string tableName, DataSet ds)
        {
            string tempUpdateString = "";
            tempUpdateString = "";
            tempUpdateString += "    /// <summary>\r\n";
            tempUpdateString += "    /// 修改数据(表" + tableName + ")\r\n";
            tempUpdateString += "    /// </summary>\r\n";
            tempUpdateString += "    public int " + tableName + "Update(Model." + tableName + " model)\r\n";
            tempUpdateString += "    {\r\n";
            tempUpdateString += "    	StringBuilder strSql=new StringBuilder();\r\n";
            tempUpdateString += "    	strSql.Append(\"UPDATE " + tableName + " SET \");\r\n";

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string description = row["description"].ToString();

                string str = row["column_name"].ToString();
                if (description == "")
                {
                    description = str;
                }
                if (str != "ID")
                {
                    if (Temp.IndexOf("|" + str + "|") > -1)
                    {
                        tempUpdateString += "    	strSql.Append(\"" + str + "=@" + str + ",\");\r\n";

                    }
                }
            }
            tempUpdateString = tempUpdateString.Substring(0, tempUpdateString.Length - 6);
            tempUpdateString += "\");\r\n";
            tempUpdateString += "    	strSql.Append(\" WHERE ID=@ID\");\r\n";

            tempUpdateString += "    	SqlParameter[] parameters = {\r\n";
            tempUpdateString += "                new SqlParameter(\"@ID\", SqlDbType.Int,4),\r\n";

            foreach (DataRow row in ds.Tables[0].Rows)
            {

                string description = row["description"].ToString();

                string str = row["column_name"].ToString();
                if (description == "")
                {
                    description = str;
                }
                if (str != "ID")
                {
                    if (Temp.IndexOf("|" + str + "|") > -1)
                    {
                        if (this.GetDBType(row["data_type"].ToString()) == "Text" || this.GetDBType(row["data_type"].ToString()) == "NText")
                        {
                            tempUpdateString += "               new SqlParameter(\"@" + str + "\", SqlDbType." + this.GetDBType(row["data_type"].ToString()) + "),\r\n";
                        }
                        else
                        {
                            tempUpdateString += "               new SqlParameter(\"@" + str + "\", SqlDbType." + this.GetDBType(row["data_type"].ToString()) + "," + row["占用字节数"].ToString() + "),\r\n";
                        }
                    }
                }
            }
            tempUpdateString = tempUpdateString.Substring(0, tempUpdateString.Length - 3);
            tempUpdateString += "};\r\n";

            int i = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string description = row["description"].ToString();

                string str = row["column_name"].ToString();
                if (description == "")
                {
                    description = str;
                }

                if (Temp.IndexOf("|" + str + "|") > -1)
                {
                    tempUpdateString += "    	parameters[" + i.ToString() + "].Value = model." + str + ";\r\n";
                    i++;
                }

            }
            tempUpdateString += "\r\n    return	Yax.SqlHelper.SQLExecute.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);\r\n        }\r\n";

            return tempUpdateString;
        }
        private StringBuilder ConvertToModel(string tableName, DataSet ds)
        {
            StringBuilder strTableList = new StringBuilder();

            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 数据转换成实体(表" + tableName + ")\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public static Model." + tableName + " ConvertTo" + tableName + "(DataRow dr)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            Model." + tableName + " model = new Model." + tableName + "();\r\n\r\n");

            int i = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string description = row["description"].ToString();
                if (description != "")
                {
                    description = "//" + description;
                }

                string str = row["column_name"].ToString();
                if (Temp.IndexOf("|" + str + "|") > -1)
                {
                    string tt = "";
                    if (row["data_type"].ToString() == "varchar" || row["data_type"].ToString() == "nvarchar" || row["data_type"].ToString() == "text" || row["data_type"].ToString() == "ntext" || row["data_type"].ToString() == "char" || row["data_type"].ToString() == "nchar")
                    {
                        tt = " Yax.SqlHelper.DBHelper.GetIsDBNULL(dr[\"" + str + "\"]) ? string.Empty : dr[\"" + str + "\"].ToString();";
                    }
                    else if (row["data_type"].ToString() == "int" || row["data_type"].ToString() == "smallint" || row["data_type"].ToString() == "tinyint")
                    {
                        tt = "Yax.SqlHelper.DBHelper.GetIsDBNULL(dr[\"" + str + "\"]) ? 0 : int.Parse(dr[\"" + str + "\"].ToString());";
                    }
                    else if (row["data_type"].ToString() == "bit")
                    {
                        tt = "Yax.SqlHelper.DBHelper.GetIsDBNULL(dr[\"" + str + "\"]) ? false : bool.Parse(dr[\"" + str + "\"].ToString());";
                    }
                    else if (row["data_type"].ToString() == "float")
                    {
                        tt = " Yax.SqlHelper.DBHelper.GetIsDBNULL(dr[\"" + str + "\"]) ? 0 : double.Parse(dr[\"" + str + "\"].ToString()); ";
                    }
                    else if (row["data_type"].ToString() == "real")
                    {
                        tt = "Yax.SqlHelper.DBHelper.GetIsDBNULL(dr[\"" + str + "\"]) ? 0 : float.Parse(dr[\"" + str + "\"].ToString()); ";
                    }
                    else if (row["data_type"].ToString() == "decimal" || row["data_type"].ToString() == "money" || row["data_type"].ToString() == "smallmoney" || row["data_type"].ToString() == "numeric")
                    {
                        tt = "Yax.SqlHelper.DBHelper.GetIsDBNULL(dr[\"" + str + "\"]) ? 0 : decimal.Parse(dr[\"" + str + "\"].ToString()); ";
                    }
                    else if (row["data_type"].ToString() == "timestamp" || row["data_type"].ToString() == "datetime" || row["data_type"].ToString() == "smalldatetime")
                    {
                        tt = " Yax.SqlHelper.DBHelper.GetIsDBNULL(dr[\"" + str + "\"]) ? DateTime.Now.AddYears(-500) : DateTime.Parse(dr[\"" + str + "\"].ToString()); ";
                    }
                    strTableList.Append("            model." + str + " =" + tt + description + "\r\n");
                    i++;
                }
            }
            strTableList.Append("\r\n            return model;\r\n");
            strTableList.Append("        }\r\n");


            return strTableList;
        }

        private StringBuilder ConvertToModel2(string tableName, DataSet ds)
        {
            StringBuilder strTableList = new StringBuilder();

            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 数据转换成实体(表" + tableName + ")\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public static Model." + tableName + " ConvetTo" + tableName + "(SqlDataReader reader,string extParam)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            Model." + tableName + " model = new Model." + tableName + "();\r\n\r\n");

            int i = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string description = row["description"].ToString();
                if (description != "")
                {
                    description = "//" + description;
                }

                string str = row["column_name"].ToString();


                if (Temp.IndexOf("|" + str + "|") > -1)
                {

                    string tt = "";
                    if (row["data_type"].ToString() == "varchar" || row["data_type"].ToString() == "nvarchar" || row["data_type"].ToString() == "text" || row["data_type"].ToString() == "ntext" || row["data_type"].ToString() == "char" || row["data_type"].ToString() == "nchar")
                    {

                        tt = "reader.IsDBNull(" + i + ") ? string.Empty : reader.GetString(" + i + ");";
                    }
                    else if (row["data_type"].ToString() == "int")
                    {
                        tt = "reader.IsDBNull(" + i + ") ? 0 : reader.GetInt32(" + i + ");";
                    }
                    else if (row["data_type"].ToString() == "smallint")
                    {
                        tt = "reader.IsDBNull(" + i + ") ? 0 : reader.GetInt16(" + i + ");";

                    }
                    else if (row["data_type"].ToString() == "tinyint")
                    {
                        tt = "reader.IsDBNull(" + i + ") ? 0 : reader.GetInt16(" + i + ");";
                    }
                    else if (row["data_type"].ToString() == "bigint")
                    {
                        tt = "reader.IsDBNull(" + i + ") ? 0 : reader.GetInt64(" + i + ");";

                    }
                    else if (row["data_type"].ToString() == "bit")
                    {
                        tt = "reader.IsDBNull(" + i + ") ? false : reader.GetBoolean(" + i + ");";

                    }
                    else if (row["data_type"].ToString() == "float")
                    {
                        tt = "reader.IsDBNull(" + i + ") ? 0 : reader.GetDouble(" + i + ");";
                    }
                    else if (row["data_type"].ToString() == "real")
                    {
                        tt = "reader.IsDBNull(" + i + ") ? 0 : reader.GetFloat(" + i + ");";
                    }
                    else if (row["data_type"].ToString() == "decimal")
                    {
                        tt = "reader.IsDBNull(" + i + ") ? 0 : reader.GetDecimal(" + i + ");";
                    }
                    else if (row["data_type"].ToString() == "decimal")
                    {
                        tt = "reader.IsDBNull(" + i + ") ? 0 : reader.GetDecimal(" + i + ");";
                    }
                    else if (row["data_type"].ToString() == "money")
                    {
                        tt = "reader.IsDBNull(" + i + ") ? 0 : reader.GetDecimal(" + i + ");";
                    }
                    else if (row["data_type"].ToString() == "smallmoney")
                    {
                        tt = "reader.IsDBNull(" + i + ") ? 0 : reader.GetDecimal(" + i + ");";
                    }
                    else if (row["data_type"].ToString() == "numeric")
                    {
                        tt = "reader.IsDBNull(" + i + ") ? 0 : reader.GetDecimal(" + i + ");";
                    }
                    else if (row["data_type"].ToString() == "timestamp")
                    {
                        tt = "reader.IsDBNull(" + i + ") ? System .DateTime.MinValue :reader.GetDateTime(" + i + ");";
                    }
                    else if (row["data_type"].ToString() == "datetime")
                    {
                        tt = "reader.IsDBNull(" + i + ") ? System .DateTime.MinValue :reader.GetDateTime(" + i + ");";
                    }
                    else if (row["data_type"].ToString() == "smalldatetime")
                    {
                        tt = "reader.IsDBNull(" + i + ") ? System .DateTime.MinValue :reader.GetDateTime(" + i + ");";
                    }
                    else if (row["data_type"].ToString() == "varbinary")
                    {
                        tt = "(byte[])reader[" + i + "];";
                    }

                    strTableList.Append("            model." + str + " =" + tt + description + "\r\n");

                    i++;
                }

            }

            strTableList.Append("\r\n            return model;\r\n");

            strTableList.Append("        }\r\n");

            return strTableList;
        }
        private StringBuilder GetModel(string tableName)
        {
            StringBuilder strTableList = new StringBuilder();
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 读取实体\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public Model." + tableName + " GetModelBy" + tableName + "(int ID)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            string sql = string.Format(\"SELECT * FROM " + tableName + " WITH(NOLOCK) WHERE ID={0}\", ID);\r\n");
            strTableList.Append("            Model." + tableName + " model = null;\r\n");
            strTableList.Append("            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(CommandType.Text, sql))\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                if (reader.Read())\r\n");
            strTableList.Append("                {\r\n");
            strTableList.Append("                    if (model == null)\r\n");
            strTableList.Append("                    {\r\n");
            strTableList.Append("                        model = new Model." + tableName + "();\r\n");
            strTableList.Append("                    }\r\n");
            strTableList.Append("                    model = ConvetTo" + tableName + "(reader,\"All\");\r\n");
            strTableList.Append("                }\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            return model;\r\n");
            strTableList.Append("        }\r\n");

            return strTableList;

        }
        private StringBuilder GetList(string tableName)
        {
            StringBuilder strTableList = new StringBuilder();
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 读取数据,多条件\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public List<Model." + tableName + "> GetList" + tableName + "(int top, string fldName, string strWhere, string fldSort)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            List<Model." + tableName + "> list = null;\r\n");
            strTableList.Append("            using (SqlDataReader reader =  Yax.SqlHelper.DBHelper.GetList(top, fldName, \"" + tableName + "\", strWhere, fldSort))\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                while (reader.Read())\r\n");
            strTableList.Append("                {\r\n");
            strTableList.Append("                    if (list == null)\r\n");
            strTableList.Append("                    {\r\n");
            strTableList.Append("                        list = new List<Model." + tableName + ">();\r\n");
            strTableList.Append("                    }\r\n");
            strTableList.Append("                    list.Add(ConvetTo" + tableName + "(reader,\"All\"));\r\n");
            strTableList.Append("                }\r\n");
            strTableList.Append("                reader.Close();\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            return list;\r\n");
            strTableList.Append("        }\r\n");

            return strTableList;
        }
        private StringBuilder GetPageList(string tableName)
        {
            StringBuilder strTableList = new StringBuilder();
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 分页读取数据,参数输出总记录数\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public  List<" + Control.NamespaceName + ".Model."+tableName+"> GetPage"+tableName+"(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("              List<" + Control.NamespaceName + ".Model." + tableName + "> list = new List<" + Control.NamespaceName + ".Model." + tableName + ">(); \r\n");
            strTableList.Append("              DataTable dt=Yax.SqlHelper.AspNetPagerList.Pager(pageIndex,pageSize,StrWhere,orderString,Field,\"" + tableName + "\",out TotalRecord);\r\n");
            strTableList.Append("              if (dt != null && dt.Rows.Count > 0)\r\n");
            strTableList.Append("             {\r\n");
            strTableList.Append("                  for(int i=0;i<dt.Rows.Count;i++)\r\n");
            strTableList.Append("                 {\r\n");
            strTableList.Append("                       list.Add(ConvertTo"+tableName+"(dt.Rows[i])); \r\n");
            strTableList.Append("                 }\r\n");
            strTableList.Append("              }\r\n");
            strTableList.Append("             return list;\r\n");
            strTableList.Append("        }\r\n");
            return strTableList;
        }
        //存储过程分页
        private StringBuilder GetPageListNew(string tableName)
        {
            StringBuilder strTableList = new StringBuilder();
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 分页读取数据,参数输出总页数，总记录数根据通用存储过程\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public List<Model." + tableName + "> GetPage" + tableName + "List(string fldName, string tblName, string strWhere, string fldSort, int pageSize, int currentPage, out int totalRecords, out int totalPages)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("   SqlParameter[] parameters = {\r\n");
            strTableList.Append("                    new SqlParameter(\"@TableName\", SqlDbType.VarChar  ,200),\r\n");
            strTableList.Append("                    new SqlParameter(\"@FieldList\", SqlDbType.VarChar , 2000),\r\n");
            strTableList.Append("                    new SqlParameter(\"@Where\", SqlDbType.VarChar ,2000),\r\n");
            strTableList.Append("                    new SqlParameter(\"@Order\", SqlDbType.VarChar  ,1000),\r\n");
            strTableList.Append("                    new SqlParameter(\"@PageSize\", SqlDbType.Int),\r\n");
            strTableList.Append("                    new SqlParameter(\"@PageIndex\", SqlDbType.Int)};\r\n");
            strTableList.Append("            parameters[0].Value = tblName;//表名\r\n");
            strTableList.Append("            parameters[1].Value = fldName;//显示列名，如果是全部字段则为*\r\n");
            strTableList.Append("            parameters[2].Value = strWhere;//查询条件 不含'where'字符，如id>10 and len(userid)>9  \r\n");
            strTableList.Append("            parameters[3].Value = fldSort;//排序 不含'order by'字符，如id asc,userid desc，必须指定asc或desc \r\n");
            strTableList.Append("            parameters[4].Value = pageSize;//每页输出的记录数\r\n");
            strTableList.Append("            parameters[5].Value = currentPage-1;//当前页数 -1\r\n");
            strTableList.Append("\r\n");
            strTableList.AppendFormat("            List<Model.{0}> list = null;\r\n", tableName);
            strTableList.Append("            totalPages = 0;\r\n");
            strTableList.Append("            totalRecords = 0;\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            using (SqlDataReader reader = Yax.SqlHelper.SQLExecute.ExecuteReader(\"Public_GetPaged\", parameters))\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                while (reader.Read())\r\n");
            strTableList.Append("                {\r\n");
            strTableList.Append("                    if (list == null)\r\n");
            strTableList.Append("                    {\r\n");
            strTableList.AppendFormat("                        list = new List<Model.{0}>();\r\n", tableName);
            strTableList.Append("                    }\r\n");
            strTableList.Append("\r\n");
            strTableList.AppendFormat("                    list.Add(ConvetTo{0}(reader, \"All\"));\r\n", tableName);
            strTableList.Append("                }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("                if (reader.NextResult())                //获得总条数\r\n");
            strTableList.Append("                {\r\n");
            strTableList.Append("                    if (reader.Read())\r\n");
            strTableList.Append("                    {\r\n");
            strTableList.Append("                        totalRecords = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);\r\n");
            strTableList.Append("                    }\r\n");
            strTableList.Append("                }\r\n");
            //strTableList.Append("                if (reader.NextResult())\r\n");
            //strTableList.Append("                {\r\n");
            //strTableList.Append("                    if (reader.Read())\r\n");
            //strTableList.Append("                    {\r\n");
            //strTableList.Append("                        totalRecords = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);\r\n");
            //strTableList.Append("                    }\r\n");
            //strTableList.Append("                }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("                reader.Close();\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("                totalPages = totalRecords / pageSize;  //获得总页数\r\n");
            strTableList.Append("                if (totalRecords % pageSize > 0)\r\n");
            strTableList.Append("                {\r\n");
            strTableList.Append("                totalPages = totalPages + 1;\r\n");
            strTableList.Append("                }\r\n");

            strTableList.Append("            }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            return list;\r\n");

            strTableList.Append("        }\r\n");

            return strTableList;

        }
        #endregion

        private void btnGetModel_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder strTableList = new StringBuilder();
            string TableName = "";

            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }
            else
            {
                TableName = this.cobTable.SelectedItem.ToString().Trim();
            }

            DataSet ds = DbHelperSQL.Query(" exec SysTable  '" + TableName + "'");

            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 得到一个对象实体\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public Model." + TableName + " GetModel(int ID)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            StringBuilder strSql = new StringBuilder();\r\n");
            strTableList.Append("            strSql.Append(\"select * from " + TableName + " \");\r\n");
            strTableList.Append("            strSql.Append(\" where ID=@ID\");\r\n");
            strTableList.Append("            SqlParameter[] parameters = {\r\n");
            strTableList.Append("					new SqlParameter(\"@ID\", SqlDbType.Int,4)};\r\n");
            strTableList.Append("            parameters[0].Value = ID;\r\n");
            strTableList.Append("            Model." + TableName + " model = new Model." + TableName + "();\r\n");
            strTableList.Append("            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);\r\n");
            strTableList.Append("            model.ID = ID;\r\n");
            strTableList.Append("            if (ds.Tables[0].Rows.Count > 0)\r\n");
            strTableList.Append("            {\r\n");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (Temp.IndexOf("|" + row["column_name"].ToString() + "|") > -1)
                {
                    if (row["data_type"].ToString() == "varchar" || row["data_type"].ToString() == "nvarchar" || row["data_type"].ToString() == "text" || row["data_type"].ToString() == "ntext")
                    {
                        strTableList.Append("                model." + row["column_name"].ToString() + " = ds.Tables[0].Rows[0][\"" + row["column_name"].ToString() + "\"].ToString();\r\n");

                    }
                    else if (row["data_type"].ToString() == "int" || row["data_type"].ToString() == "smallint")
                    {
                        strTableList.Append("                if (ds.Tables[0].Rows[0][\"" + row["column_name"].ToString() + "\"].ToString() != \"\")\r\n");
                        strTableList.Append("                {\r\n");
                        strTableList.Append("                    model." + row["column_name"].ToString() + " = int.Parse(ds.Tables[0].Rows[0][\"" + row["column_name"].ToString() + "\"].ToString());\r\n");
                        strTableList.Append("                }\r\n");
                    }
                    else if (row["data_type"].ToString() == "datetime")
                    {
                        strTableList.Append("                if (ds.Tables[0].Rows[0][\"" + row["column_name"].ToString() + "\"].ToString() != \"\")\r\n");
                        strTableList.Append("                {\r\n");
                        strTableList.Append("                    model." + row["column_name"].ToString() + " = DateTime.Parse(ds.Tables[0].Rows[0][\"" + row["column_name"].ToString() + "\"].ToString());\r\n");
                        strTableList.Append("                }\r\n");
                    }
                }
            }

            strTableList.Append("                return model;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            else\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                return null;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");

            this.txtValue.Text = strTableList.ToString();



        }


  
        private void btnModel_Click(object sender, EventArgs e)
        {
            string TableName = "";

            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }
            else
            {
                TableName = this.cobTable.SelectedItem.ToString().Trim();
            }

            this.txtValue.Text = this.CreateModel(TableName).ToString();


        }

        private void btnBllReader_Click(object sender, EventArgs e)
        {
            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }
            string tableName = this.cobTable.SelectedItem.ToString();
            this.txtValue.Text = this.CreateBLLReader(tableName).ToString();

        }

        private StringBuilder CreateBLLReader(string tableName)
        {
            StringBuilder strTableList = new StringBuilder();

            strTableList.Append("using System;\r\n");
            strTableList.Append("using System.Collections.Generic;\r\n");
            strTableList.Append("using System.Text;\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("namespace " + Control.NamespaceName + ".BLL\r\n");
            strTableList.Append("{\r\n");
            strTableList.Append("    public partial class " + tableName + "\r\n");
            strTableList.Append("    {\r\n");
            strTableList.Append("        public readonly static " + tableName + " Instance=new " + tableName + " ();\r\n");
            strTableList.Append("      \r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 添加数据\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public int Add(Model." + tableName + " model)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            return SQLServerDAL.DataProvider.Instance." + tableName + "Add(model);\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 修改数据\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public int Update(Model." + tableName + " model)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            return SQLServerDAL.DataProvider.Instance." + tableName + "Update(model);\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 删除数据\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public int Delete(int ID)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            string strWhere = string .Format (\"Id={0}\",ID);\r\n");
            strTableList.Append("            return Yax.SqlHelper.DBHelper.Delete(\"" + tableName + "\",strWhere);\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 获取实体\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public  Model." + tableName + " GetModel(int ID)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            return SQLServerDAL.DataProvider.Instance.GetModelBy" + tableName + "(ID);\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 读取数据,多条件\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public List<Model." + tableName + "> GetList(int top,string fldName,string strWhere,string fldSort)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            return SQLServerDAL.DataProvider.Instance.GetList" + tableName + "(top,fldName,strWhere,fldSort);\r\n");
            strTableList.Append("        }\r\n");


            strTableList.Append("        public List<Model."+tableName+"> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord,out int TotalPage)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            List<Model."+tableName+"> list=new List<Model."+tableName+">();\r\n");
            strTableList.Append("            list= SQLServerDAL.DataProvider.Instance.GetPage"+tableName+"(pageIndex,pageSize,StrWhere,orderString,Field,out TotalRecord); \r\n");
            strTableList.Append("            TotalPage = TotalRecord / pageSize;\r\n");
            strTableList.Append("            if (TotalRecord % pageSize > 0)\r\n");
            strTableList.Append("            { \r\n");
            strTableList.Append("                TotalPage = TotalPage + 1;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            return list;\r\n");
            strTableList.Append("         }\r\n");

            strTableList.Append("   }\r\n");
            strTableList.Append("}\r\n");

            return strTableList;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string path = Control.CreatePath + Control.NamespaceName + ".Model\\";
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            DataSet dstable = DbHelperSQL.Query("select  *  from  sysobjects  where  xtype='U' order by name asc");
            foreach (DataRow row in dstable.Tables[0].Rows)
            {
                try
                {
                    string FileName = path + row["Name"].ToString() + ".cs";
                    string tt = this.CreateModelP(row["Name"].ToString()).ToString();

                    this.txtValue.Text = tt;

                    if (!File.Exists(FileName))
                    {
                        FileStream fsWriter = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.Read, 1000);
                        StreamWriter sw = new StreamWriter(fsWriter, Encoding.UTF8);
                        sw.Write(tt);
                        sw.Close();
                        fsWriter.Close();


                    }
                }
                catch (ExecutionEngineException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            MessageBox.Show("生成完成");
        }

        private string getType(string iType)
        {
            string temp = "";

            switch (iType.ToLower())
            {
                case "int":
                    {
                        temp = "int";
                        break;
                    }
                case "smallint":
                    {
                        temp = "int";
                        break;
                    }
                case "tinyint":
                    {
                        temp = "int";
                        break;
                    }
                case "bigint":
                    {
                        temp = "long";
                        break;
                    }
                case "varchar":
                    {
                        temp = "string";
                        break;
                    }
                case "nvarchar":
                    {
                        temp = "string";
                        break;
                    }
                case "datetime":
                    {
                        temp = "DateTime";
                        break;
                    }
                case "timestamp":
                    {
                        temp = "DateTime";
                        break;
                    }
                case "smalldatetime":
                    {
                        temp = "DateTime";
                        break;
                    }
                case "text":
                    {
                        temp = "string";
                        break;
                    }
                case "ntext":
                    {
                        temp = "string";
                        break;
                    }
                case "char":
                    {
                        temp = "string";
                        break;
                    }
                case "nchar":
                    {
                        temp = "string";
                        break;
                    }
                case "bit":
                    {
                        temp = "bool";
                        break;
                    }
                case "real":
                    {
                        temp = "float";
                        break;
                    }
                case "money":
                    {
                        temp = "decimal";
                        break;
                    }
                case "smallmoney":
                    {
                        temp = "decimal";
                        break;
                    }
                case "float":
                    {
                        temp = "double";
                        break;
                    }
                case "decimal":
                    {
                        temp = "decimal";
                        break;
                    }
                case "numeric":
                    {
                        temp = "Decimal";
                        break;
                    }
                case "varbinary":
                    {
                        temp = "byte[]";
                        break;
                    }
            }
            return temp;
        }

        /// <summary>
        /// 生成Model
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        private StringBuilder CreateModel(string TableName)
        {
            System.Text.StringBuilder strTableList = new StringBuilder();

            strTableList.Append("using System;\r\n");
            strTableList.Append("namespace Entity\r\n");
            strTableList.Append("{\r\n");
            strTableList.Append("    /// <summary>\r\n");
            strTableList.Append("    /// 实体类" + TableName + "(属性说明自动提取数据库字段的描述信息)\r\n");
            strTableList.Append("    /// </summary>\r\n");
            strTableList.Append("    public class M" + TableName + "\r\n");
            strTableList.Append("    {\r\n");
            strTableList.Append("        public M" + TableName + "()\r\n");
            strTableList.Append("        { }\r\n");
            strTableList.Append("        #region Model\r\n");

            DataSet ds = DbHelperSQL.Query(" exec SysTable  '" + TableName + "'");
            strTableList.Append("\r\n");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string description = row["description"].ToString();

                string str = row["column_name"].ToString();

                if (Temp.IndexOf("|" + str + "|") > -1)
                {
                    string tt = "";
                    tt = this.getType(row["data_Type"].ToString());

                    strTableList.Append("        /// <summary>\r\n");
                    strTableList.Append("        /// " + description + "\r\n");
                    strTableList.Append("        /// </summary>\r\n");
                    strTableList.Append("        public " + tt + " " + str + "{ get; set; }  \r\n");

                }
            }

            strTableList.Append("        #endregion Model\r\n");
            strTableList.Append("    }\r\n");
            strTableList.Append("}\r\n");
            return strTableList;
        }
        /// <summary>
        /// 批量生成Model
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        private StringBuilder CreateModelP(string TableName)
        {
            System.Text.StringBuilder strTableList = new StringBuilder();

            strTableList.Append("using System;\r\n");
            strTableList.Append("namespace " + Control.NamespaceName + ".Model\r\n");
            strTableList.Append("{\r\n");
            strTableList.Append("    /// <summary>\r\n");
            strTableList.Append("    /// 实体类" + TableName + "(属性说明自动提取数据库字段的描述信息)\r\n");
            strTableList.Append("    /// </summary>\r\n");
            strTableList.Append("    [Serializable]\r\n");
            strTableList.Append("    public class " + TableName + "\r\n");
            strTableList.Append("    {\r\n");
            strTableList.Append("        public " + TableName + "()\r\n");
            strTableList.Append("        { }\r\n");
            strTableList.Append("        #region Model\r\n");

            DataSet ds = DbHelperSQL.Query(" exec SysTable  '" + TableName + "'");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string str = row["column_name"].ToString();


                string tt = "";
                tt = this.getType(row["data_Type"].ToString());

                strTableList.Append("        private " + tt + " _" + str.ToLower() + ";\r\n");



            }
            strTableList.Append("\r\n");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string description = row["description"].ToString();

                string str = row["column_name"].ToString();


                string tt = "";
                tt = this.getType(row["data_Type"].ToString());

                strTableList.Append("        /// <summary>\r\n");
                strTableList.Append("        /// " + description + "\r\n");
                strTableList.Append("        /// </summary>\r\n");
                strTableList.Append("        public " + tt + " " + str + "\r\n");
                strTableList.Append("        {\r\n");
                strTableList.Append("            set { _" + str.ToLower() + " = value; }\r\n");
                strTableList.Append("            get { return _" + str.ToLower() + "; }\r\n");
                strTableList.Append("        }\r\n");



            }

            strTableList.Append("        #endregion Model\r\n");
            strTableList.Append("    }\r\n");
            strTableList.Append("}\r\n");
            return strTableList;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = Control.CreatePath + Control.NamespaceName + ".SQLServerDAL\\";
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            DataSet dstable = DbHelperSQL.Query("select  *  from  sysobjects  where  xtype='U' order by name asc");
            foreach (DataRow row in dstable.Tables[0].Rows)
            {
                DataSet ds2 = DbHelperSQL.Query(" exec SysTable  '" + row["Name"].ToString() + "'");
                Temp = "|";

                foreach (DataRow rows in ds2.Tables[0].Rows)
                {
                    Temp += rows["column_name"].ToString() + "|";
                }

                try
                {
                    string FileName = path + row["Name"].ToString() + ".cs";
                    string tt = this.CreateDALReader(row["Name"].ToString()).ToString();

                    this.txtValue.Text = tt;

                    if (chkOverride.Checked)
                    {
                        FileStream fsWriter = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.Read, 1000);
                        StreamWriter sw = new StreamWriter(fsWriter, Encoding.UTF8);
                        sw.Write(tt);
                        sw.Close();
                        fsWriter.Close();
                    }
                    else
                    {
                        if (!File.Exists(FileName))
                        {
                            FileStream fsWriter = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.Read, 1000);
                            StreamWriter sw = new StreamWriter(fsWriter, Encoding.UTF8);
                            sw.Write(tt);
                            sw.Close();
                            fsWriter.Close();
                        }
                    }



                }
                catch (ExecutionEngineException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            FileStream fsWriter1 = new FileStream(path + "DataProvider.cs", FileMode.Create, FileAccess.Write, FileShare.Read, 1000);
            StreamWriter sw1 = new StreamWriter(fsWriter1, Encoding.UTF8);
            sw1.Write(Control.DataProviderString().ToString());
            sw1.Close();
            fsWriter1.Close();

            FileStream fsWriter2 = new FileStream(path + "SqlHelper.cs", FileMode.Create, FileAccess.Write, FileShare.Read, 1000);
            StreamWriter sw2 = new StreamWriter(fsWriter2, Encoding.UTF8);
            sw2.Write(Control.SqlHelperString().ToString());
            sw2.Close();
            fsWriter2.Close();

            MessageBox.Show("生成完成");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = Control.CreatePath + Control.NamespaceName + ".BLL\\";
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            DataSet dstable = DbHelperSQL.Query("select  *  from  sysobjects  where  xtype='U' order by name asc");
            foreach (DataRow row in dstable.Tables[0].Rows)
            {
                try
                {
                    string FileName = path + row["Name"].ToString() + ".cs";
                    string tt = this.CreateBLLReader(row["Name"].ToString()).ToString();

                    this.txtValue.Text = tt;

                    if (chkOverride.Checked)
                    {

                        FileStream fsWriter = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.Read, 1000);
                        StreamWriter sw = new StreamWriter(fsWriter, Encoding.UTF8);
                        sw.Write(tt);
                        sw.Close();
                        fsWriter.Close();
                    }
                    else
                    {
                        if (!File.Exists(FileName))
                        {
                            FileStream fsWriter = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.Read, 1000);
                            StreamWriter sw = new StreamWriter(fsWriter, Encoding.UTF8);
                            sw.Write(tt);
                            sw.Close();
                            fsWriter.Close();
                        }
                    }



                }
                catch (ExecutionEngineException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            MessageBox.Show("生成完成");
        }

        private void btnModel2_Click(object sender, EventArgs e)
        {
            string tableName = "";

            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }
            else
            {
                tableName = this.cobTable.SelectedItem.ToString().Trim();
            }
            this.txtValue.Text = "";
            this.txtValue.Text = Control.CsModel2(tableName, Temp, false).ToString();
        }

        private void btnModelP2_Click(object sender, EventArgs e)
        {
            DataSet dstable = DbHelperSQL.Query("select  *  from  sysobjects  where  xtype='U' order by name asc");
            foreach (DataRow row in dstable.Tables[0].Rows)
            {
                try
                {
                    string fileName = Control.CreatePath + Control.NamespaceName + ".Model\\" + row["Name"].ToString() + ".cs";
                    string writeText = Control.CsModel2(row["Name"].ToString(), "", true).ToString();
                    this.txtValue.Text = writeText;


                    FileStream fsWriter = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read, 1000);
                    StreamWriter sw = new StreamWriter(fsWriter, Encoding.UTF8);
                    sw.Write(writeText);
                    sw.Close();
                    fsWriter.Close();



                }
                catch (ExecutionEngineException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            MessageBox.Show("生成完成");
        }

        private void btnDAL_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateWebListFile_Click(object sender, EventArgs e)
        {
            string tableName = "";

            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }
            else
            {
                tableName = this.cobTable.SelectedItem.ToString().Trim();
            }

            string path = Control.CreatePath + Control.NamespaceName + ".Web\\" + this.txtClassName.Text.Replace(".", "\\");
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            string fileName = path + "Show" + tableName + ".aspx";

            FileStream fsWriter = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read, 1000);
            StreamWriter sw = new StreamWriter(fsWriter, Encoding.UTF8);

            sw.Write(Control.WebPageByList(tableName, Temp, this.txtClassName.Text, this.chkSort.Checked));
            sw.Close();
            fsWriter.Close();

            MessageBox.Show("生成完成");

        }

        private void btnListCodeFile_Click(object sender, EventArgs e)
        {
            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }

            string tableName = this.cobTable.SelectedItem.ToString();

            string path = Control.CreatePath + Control.NamespaceName + ".Web.UI\\" + this.txtClassName.Text.Replace(".", "\\");
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            string fileName = path + "Show" + tableName + ".cs";

            FileStream fsWriter = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read, 1000);
            StreamWriter sw = new StreamWriter(fsWriter, Encoding.UTF8);

            string tpath = "";
            if (this.txtClassName.Text != "")
            {
                tpath = this.txtClassName.Text.Remove(this.txtClassName.Text.Length - 1, 1);
            }

            sw.Write(Control.CsPageByList(tableName, tpath, this.chkSort.Checked).ToString());
            sw.Close();
            fsWriter.Close();

            MessageBox.Show("生成完成");

        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            string tableName = "";

            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }
            else
            {
                tableName = this.cobTable.SelectedItem.ToString().Trim();
            }

            string path = Control.CreatePath + Control.NamespaceName + ".Web\\" + this.txtClassName.Text.Replace(".", "\\");
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            string fileName = path + "Add" + tableName + ".aspx";

            FileStream fsWriter = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read, 1000);
            StreamWriter sw = new StreamWriter(fsWriter, Encoding.UTF8);

            sw.Write(Control.WebPageByAddSingle(Temp, Control.CommonFile, Control.NamespaceName, this.txtClassName.Text, tableName, Control.TabHtml, Control.TdTopHtml, Control.TdHtml, Control.TdButtomHtml, Control.InputCss, Control.TextAreaCss, Control.BottonCss).ToString());
            sw.Close();
            fsWriter.Close();

            MessageBox.Show("生成完成");
        }

        private void btnAddCodeFile_Click(object sender, EventArgs e)
        {
            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }

            string tableName = this.cobTable.SelectedItem.ToString();

            string path = Control.CreatePath + Control.NamespaceName + ".Web.UI\\" + this.txtClassName.Text.Replace(".", "\\");
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            string fileName = path + "Add" + tableName + ".cs";

            FileStream fsWriter = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read, 1000);
            StreamWriter sw = new StreamWriter(fsWriter, Encoding.UTF8);

            string tpath = "";
            if (this.txtClassName.Text != "")
            {
                tpath = this.txtClassName.Text.Remove(this.txtClassName.Text.Length - 1, 1);
            }

            sw.Write(Control.CsPageByAdd(Temp, tableName, tpath, this.checkBox1.Checked).ToString());
            sw.Close();
            fsWriter.Close();

            MessageBox.Show("生成完成");
        }

        private void btnUpdateFile_Click(object sender, EventArgs e)
        {
            string tableName = "";

            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }
            else
            {
                tableName = this.cobTable.SelectedItem.ToString().Trim();
            }

            string path = Control.CreatePath + Control.NamespaceName + ".Web\\" + this.txtClassName.Text.Replace(".", "\\");
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            string fileName = path + "Update" + tableName + ".aspx";

            FileStream fsWriter = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read, 1000);
            StreamWriter sw = new StreamWriter(fsWriter, Encoding.UTF8);

            sw.Write(Control.WebPageByUpdateSingle(Temp, Control.CommonFile, Control.NamespaceName, this.txtClassName.Text, tableName, Control.TabHtml, Control.TdTopHtml, Control.TdHtml, Control.TdButtomHtml, Control.InputCss, Control.TextAreaCss, Control.BottonCss).ToString());
            sw.Close();
            fsWriter.Close();

            MessageBox.Show("生成完成");
        }

        private void btnUpdateCodeFile_Click(object sender, EventArgs e)
        {
            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }

            string tableName = this.cobTable.SelectedItem.ToString();

            string path = Control.CreatePath + Control.NamespaceName + ".Web.UI\\" + this.txtClassName.Text.Replace(".", "\\");
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            string fileName = path + "Update" + tableName + ".cs";

            FileStream fsWriter = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read, 1000);
            StreamWriter sw = new StreamWriter(fsWriter, Encoding.UTF8);

            string tpath = "";
            if (this.txtClassName.Text != "")
            {
                tpath = this.txtClassName.Text.Remove(this.txtClassName.Text.Length - 1, 1);
            }

            sw.Write(Control.CsPageByUpdate(Temp, tableName, tpath, this.checkBox2.Checked).ToString());
            sw.Close();
            fsWriter.Close();

            MessageBox.Show("生成完成");
        }

        private void btnJsFile_Click(object sender, EventArgs e)
        {
            string tableName = "";

            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }
            else
            {
                tableName = this.cobTable.SelectedItem.ToString().Trim();
            }

            string path = Control.CreatePath + Control.NamespaceName + ".Web\\" + this.txtClassName.Text.Replace(".", "\\");
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            string fileName = path + "" + tableName + ".js";

            FileStream fsWriter = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read, 1000);
            StreamWriter sw = new StreamWriter(fsWriter, Encoding.UTF8);

            sw.Write(Control.JsPageAdd2(Temp, tableName, this.chkSort.Checked));
            sw.Close();
            fsWriter.Close();

            MessageBox.Show("生成完成");
        }

        private void btnOptionView_Click(object sender, EventArgs e)
        {
            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }
            string tableName = this.cobTable.SelectedItem.ToString();

            DataSet ds = DbHelperSQL.Query(" exec SysTable  '" + tableName + "'");
            this.txtValue.Text = "";
            this.txtValue.Text += Control.SelectOptionView(tableName).ToString();

        }

        private void 常用登陆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOften frm = new frmOften();
            frm.Show();
        }





    }
}