using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace acode
{
    public class Control
    {

        public static string NamespaceName = string.Empty;
        public static string CommonFile = string.Empty;
        public static string CreatePath = string.Empty;
        public static string TabHtml = string.Empty;
        public static string TdTopHtml = string.Empty;
        public static string TdHtml = string.Empty;
        public static string TdButtomHtml = string.Empty;
        public static string InputCss = string.Empty;
        public static string TextAreaCss = string.Empty;
        public static string BottonCss = string.Empty;

        /// <summary>
        /// 添加web页面(单排表格布局)
        /// </summary>
        /// <param name="selectFields">选择的字段</param>
        /// <param name="tabName">数据库表名</param>
        /// <param name="tabHtml">table表头</param>
        /// <param name="tdTopHtml"></param>
        /// <param name="tdHtml"></param>
        /// <param name="tdButtomHtml"></param>
        /// <param name="inputCss"></param>
        /// <returns></returns>
        public static StringBuilder WebPageByAddSingle(string selectFields, string commonFile, string namespaceName, string path, string tabName, string tabHtml, string tdTopHtml, string tdHtml, string tdButtomHtml, string inputCss, string textAreaCss, string bottonCss)
        {
            StringBuilder strTemp = new StringBuilder();
            strTemp.AppendFormat("<%@ Page Language=\"C#\" AutoEventWireup=\"true\" Inherits=\"{0}.Web.UI.{1}Add{2}\" %>\r\n", namespaceName, path, tabName);
            strTemp.Append("\r\n");
            strTemp.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");
            strTemp.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
            strTemp.Append("<head>\r\n");
            strTemp.AppendFormat("    <title>{0}</title>\r\n", tabName);
            strTemp.Append(commonFile);
            strTemp.AppendFormat("\r\n<script type=\"text/javascript\"  src=\"../Js/{0}.js\"></script>\r\n", tabName);
            strTemp.Append("</head>\r\n");
            strTemp.Append("<body>\r\n");
            strTemp.Append("<form name=\"form1\" id=\"form1\" method=\"post\" action=\"?action=save\" onsubmit=\"return CheckForm();\">\r\n");
            strTemp.Append(tabHtml + "\r\n");
            strTemp.Append("<tr>\r\n");
            strTemp.AppendFormat(tdTopHtml + "添加{0}</td> \r\n", tabName);
            strTemp.Append("</tr>\r\n");

            DataSet ds = DbHelperSQL.Query(string.Format(" exec SysTable  '{0}'", tabName));//读取表字段信息
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string description = row["description"].ToString();
                string columnName = row["column_name"].ToString();
                string dataType = row["data_type"].ToString().ToLower();

                if (columnName.ToUpper() == "ID")
                {
                    continue;
                }



                if (selectFields.IndexOf("|" + columnName + "|") > -1)
                {
                    strTemp.AppendFormat("\r\n<tr>\r\n{0}", tdHtml);
                    string titleDescription = description.Replace("(下拉)", "").Replace("(复选)", "").Replace("(单选)", "").Replace(" ", "").Replace("*", "<font color=\"red\">*</font>");
                    strTemp.AppendFormat("{0}</td>\r\n", titleDescription);

                    if (description.IndexOf("(下拉)") > -1)
                    {
                        strTemp.AppendFormat("{0}\r\n<select name=\"{1}\" id=\"{1}\"  >\r\n<option value=\"\">请选择</option>\r\n<%={1}Options%>\n</select>\r\n</td>\r\n</tr>\r\n", tdHtml, columnName);

                    }
                    else if (description.IndexOf("(复选)") > -1)
                    {
                        strTemp.AppendFormat("{0}\r\n<%=LoadCheck{1}()%>\r\n</td>\r\n</tr>\r\n", tdHtml, columnName);

                    }
                    else if (description.IndexOf("(单选)") > -1)
                    {
                        strTemp.AppendFormat("{0}\r\n<%=LoadRadio{1}()%>\r\n</td>\r\n</tr>\r\n", tdHtml, columnName);

                    }
                    else if (description.IndexOf("(图)") > -1)
                    {
                        strTemp.AppendFormat("\r\n{0}\r\n", tdHtml);
                        strTemp.Append("<img src=\"/Images/NoPhoto.jpg\" alt=\"图片\" name=\"ImgName\" height=\"100\"  width=\"100\">\r\n");
                        strTemp.Append("<input name=\"btnSelectImage\" onclick=\"OpenImages();\" type=\"button\" value=\"选择图片\" />\r\n");
                        strTemp.AppendFormat("<input name=\"{0}\" id=\"{0}\" type=\"hidden\" value=\"NoPhoto.jpg\">\r\n", columnName);
                        strTemp.Append("</td>\r\n</tr>\r\n");

                    }
                    else if (dataType == "text" || dataType == "ntext")
                    {
                        strTemp.AppendFormat("{0}\r\n<textarea name=\"{1}\" id =\"{1}\" cols=\"40\" rows=\"8\" {2} ></textarea>\r\n</td>\r\n</tr>\r\n", tdHtml, columnName, textAreaCss);
                    }
                    else
                    {
                        strTemp.AppendFormat("{0}<input type=\"text\" name=\"{1}\" id =\"{1}\" value=\"\" {2}/>\r\n</td>\r\n</tr>\r\n", tdHtml, columnName, inputCss);
                    }



                }

            }
            strTemp.AppendFormat("<tr>\r\n{0}\r\n", tdButtomHtml);
            strTemp.AppendFormat("<input name=\"Submit\" type=\"submit\" {0} value=\"提交保存\" />&nbsp;&nbsp;&nbsp;&nbsp;<input type=\"reset\" name=\"Submit\" value=\" 重  置 \" {0} />", bottonCss);
            strTemp.Append("</td>\r\n</tr>\r\n</table>\r\n");
            strTemp.Append("</form>\r\n");
            strTemp.Append("</body>\r\n</html>\r\n");

            return strTemp;


        }
        /// <summary>
        /// 添加web页面(单排表格布局)
        /// </summary>
        /// <param name="selectFields">选择的字段</param>
        /// <param name="tabName">数据库表名</param>
        /// <param name="tabHtml">table表头</param>
        /// <param name="tdTopHtml"></param>
        /// <param name="tdHtml"></param>
        /// <param name="tdButtomHtml"></param>
        /// <param name="inputCss"></param>
        /// <returns></returns>
        public static StringBuilder WebPageByInfoSingle(string selectFields, string commonFile, string namespaceName, string path, string tabName, string tabHtml, string tdTopHtml, string tdHtml, string tdButtomHtml, string inputCss, string textAreaCss, string bottonCss)
        {
            StringBuilder strTemp = new StringBuilder();
            strTemp.AppendFormat("<%@ Page Language=\"C#\" AutoEventWireup=\"true\" Inherits=\"{0}.Web.UI.{1}Add{2}\" %>\r\n", namespaceName, path, tabName);
            strTemp.Append("\r\n");
            strTemp.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");
            strTemp.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
            strTemp.Append("<head>\r\n");
            strTemp.AppendFormat("    <title>{0}</title>\r\n", tabName);
            strTemp.Append(commonFile);
            strTemp.AppendFormat("\r\n<script type=\"text/javascript\"  src=\"../Js/{0}.js\"></script>\r\n", tabName);
            strTemp.Append("</head>\r\n");
            strTemp.Append("<body>\r\n");
            strTemp.Append(tabHtml + "\r\n");
            strTemp.Append("<tr>\r\n");
            strTemp.AppendFormat(tdTopHtml + "{0}详细</td> \r\n", tabName);
            strTemp.Append("</tr>\r\n");

            DataSet ds = DbHelperSQL.Query(string.Format(" exec SysTable  '{0}'", tabName));//读取表字段信息
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string description = row["description"].ToString();
                string columnName = row["column_name"].ToString();
                string dataType = row["data_type"].ToString().ToLower();

                if (columnName.ToUpper() == "ID")
                {
                    continue;
                }



                if (selectFields.IndexOf("|" + columnName + "|") > -1)
                {
                    strTemp.AppendFormat("\r\n<tr>\r\n{0}", tdHtml);
                    string titleDescription = description.Replace("(下拉)", "").Replace("(复选)", "").Replace("(单选)", "").Replace(" ", "").Replace("*", "<font color=\"red\">*</font>");
                    strTemp.AppendFormat("{0}</td>\r\n", titleDescription);

                    strTemp.AppendFormat("{0}<%=model.{1}%>\r\n</td>\r\n</tr>\r\n", tdHtml, columnName);


                }

            }
            strTemp.Append("</table>\r\n");
            strTemp.Append("</body>\r\n</html>\r\n");

            return strTemp;


        }
        /// <summary>
        /// 添加web页面(单排表格布局)
        /// </summary>
        /// <param name="selectFields">选择的字段</param>
        /// <param name="tabName">数据库表名</param>
        /// <param name="tabHtml">table表头</param>
        /// <param name="tdTopHtml"></param>
        /// <param name="tdHtml"></param>
        /// <param name="tdButtomHtml"></param>
        /// <param name="inputCss"></param>
        /// <returns></returns>
        public static StringBuilder WebPageByAddSingle2(string selectFields, string commonFile, string namespaceName, string tabName, string tabHtml, string tdTopHtml, string tdHtml, string tdButtomHtml, string inputCss, string textAreaCss, string bottonCss)
        {
            StringBuilder strTemp = new StringBuilder();
            strTemp.AppendFormat("<%@ Page Language=\"C#\" AutoEventWireup=\"true\" Inherits=\"{0}.Web.UI.Add{1}\" %>\r\n", namespaceName, tabName);
            strTemp.Append("\r\n");
            strTemp.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");
            strTemp.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
            strTemp.Append("<head>\r\n");
            strTemp.AppendFormat("    <title>{0}</title>\r\n", tabName);
            strTemp.Append(commonFile);
            strTemp.Append("</head>\r\n");
            strTemp.Append("<body>\r\n");
            strTemp.Append("<form name=\"form1\" id=\"form1\" method=\"post\" action=\"?action=save\" onsubmit=\"return CheckForm();\">\r\n");
            strTemp.Append(tabHtml + "\r\n");
            strTemp.Append("<tr>\r\n");
            strTemp.AppendFormat(tdTopHtml + "添加{0}</td> \r\n", tabName);
            strTemp.Append("</tr>\r\n");

            DataSet ds = DbHelperSQL.Query(string.Format(" exec SysTable  '{0}'", tabName));//读取表字段信息
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string description = row["description"].ToString();
                string columnName = row["column_name"].ToString();
                string dataType = row["data_type"].ToString().ToLower();

                if (columnName.ToUpper() == "ID")
                {
                    continue;
                }

                string spanHtml = string.Empty;
                if (description.IndexOf("*") > -1)
                {
                    spanHtml = string.Format("{0}<span class=\"checkHelp\" id=\"lbl{1}\"></span>\r\n</td>", tdHtml, columnName);
                }

                if (selectFields.IndexOf("|" + columnName + "|") > -1)
                {
                    strTemp.AppendFormat("\r\n<tr>\r\n{0}", tdHtml);
                    string titleDescription = description.Replace("(下拉)", "").Replace("(复选)", "").Replace("(单选)", "").Replace(" ", "").Replace("*", "<font color=\"red\">*</font>");
                    strTemp.AppendFormat("{0}</td>\r\n", titleDescription);

                    if (description.IndexOf("(下拉)") > -1)
                    {
                        strTemp.AppendFormat("{0}\r\n<select name=\"{1}\" id=\"{1}\"  >\r\n<option value=\"\">请选择</option>\r\n<%=LoadSelect{1}()%>\n</select>\r\n</td>\r\n{2}</tr>\r\n", tdHtml, columnName, spanHtml);

                    }
                    else if (description.IndexOf("(复选)") > -1)
                    {
                        strTemp.AppendFormat("{0}\r\n<%=LoadCheck{1}()%>\r\n</td>\r\n{2}</tr>\r\n", tdHtml, columnName, spanHtml);

                    }
                    else if (description.IndexOf("(单选)") > -1)
                    {
                        strTemp.AppendFormat("{0}\r\n<%=LoadRadio{1}()%>\r\n</td>\r\n{2}</tr>\r\n", tdHtml, columnName, spanHtml);

                    }
                    else if (description.IndexOf("(图)") > -1)
                    {
                        strTemp.AppendFormat("\r\n{0}\r\n", tdHtml);
                        strTemp.Append("<img src=\"/Images/NoPhoto.jpg\" alt=\"图片\" name=\"ImgName\" height=\"100\"  width=\"100\">\r\n");
                        strTemp.Append("<input name=\"btnSelectImage\" onclick=\"OpenImages();\" type=\"button\" value=\"选择图片\" />\r\n");
                        strTemp.AppendFormat("<input name=\"{0}\" id=\"{0}\" type=\"hidden\" value=\"NoPhoto.jpg\">\r\n", columnName);
                        strTemp.AppendFormat("</td>\r\n{0}</tr>\r\n", spanHtml);

                    }
                    else if (dataType == "text" || dataType == "ntext")
                    {
                        strTemp.AppendFormat("{0}\r\n<textarea name=\"{1}\" id =\"{1}\" cols=\"40\" rows=\"8\" {2} ></textarea>\r\n</td>\r\n{3}</tr>\r\n", tdHtml, columnName, textAreaCss, spanHtml);
                    }
                    else
                    {
                        strTemp.AppendFormat("{0}<input type=\"text\" name=\"{1}\" id =\"{1}\" value=\"\" {2}/>\r\n</td>\r\n{3}</tr>\r\n", tdHtml, columnName, inputCss, spanHtml);
                    }



                }

            }
            strTemp.AppendFormat("<tr>\r\n{0}\r\n", tdButtomHtml);
            strTemp.AppendFormat("<input name=\"Submit\" type=\"submit\" {0} value=\"提交保存\" />&nbsp;&nbsp;&nbsp;&nbsp;<input type=\"reset\" name=\"Submit\" value=\" 重  置 \" {0} />", bottonCss);
            strTemp.Append("</td>\r\n</tr>\r\n</table>\r\n");
            strTemp.Append("</form>\r\n");
            strTemp.Append("</body>\r\n</html>\r\n");
            strTemp.AppendFormat("<script type=\"text/javascript\"  src=\"../Js/Add{0}.js\"></script>\r\n", tabName);
            return strTemp;


        }
        /// <summary>
        /// 添加页面CS代码
        /// </summary>
        /// <param name="selectFields"></param>
        /// <param name="tabName"></param>
        /// <param name="isCheck"></param>
        /// <returns></returns>
        public static StringBuilder CsPageByAdd(string selectFields, string tabName, string path, bool isCheck)
        {
            StringBuilder strTemp = new StringBuilder();
            strTemp.Append("using System;\r\n");
            strTemp.Append("using System.Collections.Generic;\r\n");
            strTemp.Append("using System.Text;\r\n");
            strTemp.Append("\r\n");
            strTemp.AppendFormat("namespace {0}.Web.UI.{1}\r\n", NamespaceName, path);
            strTemp.Append("{\r\n");
            strTemp.AppendFormat("    public class Add{0} : {1}.Web.UI.Page.AdminPageBase\r\n", tabName, NamespaceName);
            strTemp.Append("    {\r\n");
            strTemp.Append("        protected void Page_Load(object sender, EventArgs e)\r\n");
            strTemp.Append("        {\r\n");
            strTemp.Append("            if (!IsPostBack)\r\n");
            strTemp.Append("            {\r\n");
            strTemp.Append("                this.AddSave();\r\n");
            strTemp.Append("\r\n");
            strTemp.Append("            }\r\n");
            strTemp.Append("        }\r\n");

            DataSet ds = DbHelperSQL.Query(string.Format(" exec SysTable  '{0}'", tabName));


            strTemp.Append("/// <summary>\r\n/// 添加数据\r\n/// </summary>\r\n");
            strTemp.Append("protected void AddSave()\r\n{\r\n");

            strTemp.Append("if (Request.QueryString[\"action\"] == \"save\")\r\n");
            strTemp.Append("        {\r\n");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string columnName = row["column_name"].ToString();
                string titleDescription = row["description"].ToString();
                string dataType = row["data_type"].ToString();
                string columnFlag = row["标识"].ToString();

                if (selectFields.IndexOf("|" + columnName + "|") > -1)
                {
                    if (columnFlag == "√")
                    {
                        continue;
                    }
                    if (dataType == "datetime")
                    {
                        continue;
                    }
                    strTemp.AppendFormat("    string {0}={1}.Common.Helper.StringHelper.GetSafeString(Request.Form [\"{0}\"]);//{2}\r\n", columnName, NamespaceName, titleDescription);
                }

            }
            if (isCheck)
            {
                strTemp.Append("\r\n\r\n");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string columnName = row["column_name"].ToString();
                    string description = row["description"].ToString();
                    string titleDescription = description.Replace("(下拉)", "").Replace("(复选)", "").Replace("(单选)", "").Replace(" ", "").Replace("\n", "").Replace("*", "");
                    string dataType = row["data_type"].ToString();
                    string columnFlag = row["标识"].ToString();

                    if (selectFields.IndexOf("|" + columnName + "|") > -1)
                    {
                        if (columnFlag == "√")
                        {
                            continue;
                        }
                        if (description.IndexOf("*") > -1)
                        {
                            strTemp.AppendFormat("\r\n    if ({0} == \"\") \r\n    ", columnName);
                            strTemp.Append("{\r\n");
                            strTemp.AppendFormat("        {0}.Common.Helper.JscriptHelper.AlertReturn(\"{1}不能为空!\");\r\n        return;\r\n", NamespaceName, titleDescription);
                            strTemp.Append("\r\n    }\r\n");
                        }
                    }

                }
            }
            strTemp.Append("\r\n\r\n");
            strTemp.AppendFormat("    {0}.Model.{1} model=new {0}.Model.{1}();\r\n", NamespaceName, tabName);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string columnName = row["column_name"].ToString();
                string titleDescription = row["description"].ToString();
                titleDescription = titleDescription.Replace("(下拉)", "").Replace("(复选)", "").Replace("(单选)", "").Replace(" ", "").Replace("\n", "").Replace("*", "");
                string dataType = row["data_type"].ToString();
                string columnFlag = row["标识"].ToString();

                if (columnFlag == "√")
                {
                    continue;
                }

                if (selectFields.IndexOf("|" + columnName + "|") > -1)
                {
                    strTemp.AppendFormat("    model.{0}={1};\r\n", columnName, GetTypeString(dataType.ToLower(), columnName));
                }

            }
            strTemp.Append("\r\n    if(" + NamespaceName + ".BLL." + tabName + ".Instance.Add(model)>0)\r\n {" + NamespaceName + ".Common.Helper.JscriptHelper.AlertTo(\"操作成功!\", \"Show" + tabName + ".aspx\");\r\n}\r\n");
            strTemp.Append("else \r\n{\r\n" + NamespaceName + ".Common.Helper.JscriptHelper.AlertReturn(\"操作失败!\");\r\n}\r\n}\r\n}\r\n");
            strTemp.Append("    }\r\n");
            strTemp.Append("}\r\n");
            strTemp.Append("\r\n");

            return strTemp;

        }

        /// <summary>
        /// 添加web页面(单排表格布局)
        /// </summary>
        /// <param name="selectFields">选择的字段</param>
        /// <param name="tabName">数据库表名</param>
        /// <param name="tabHtml">table表头</param>
        /// <param name="tdTopHtml"></param>
        /// <param name="tdHtml"></param>
        /// <param name="tdButtomHtml"></param>
        /// <param name="inputCss"></param>
        /// <returns></returns>
        public static StringBuilder WebPageByUpdateSingle(string selectFields, string commonFile, string namespaceName, string path, string tabName, string tabHtml, string tdTopHtml, string tdHtml, string tdButtomHtml, string inputCss, string textAreaCss, string bottonCss)
        {
            StringBuilder strTemp = new StringBuilder();
            strTemp.AppendFormat("<%@ Page Language=\"C#\" AutoEventWireup=\"true\" Inherits=\"{0}.Web.UI.{1}Update{2}\" %>\r\n", namespaceName, path, tabName);
            strTemp.Append("\r\n");
            strTemp.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");
            strTemp.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
            strTemp.Append("<head>\r\n");
            strTemp.AppendFormat("    <title>{0}</title>\r\n", tabName);
            strTemp.Append(commonFile);
            strTemp.AppendFormat("\r\n<script type=\"text/javascript\"  src=\"../Js/{0}.js\"></script>\r\n", tabName);
            strTemp.Append("</head>\r\n");
            strTemp.Append("<body>\r\n");
            strTemp.Append("<form name=\"form1\" id=\"form1\" method=\"post\" action=\"?action=save&ID=<%=model.ID%>\" onsubmit=\"return CheckForm();\">\r\n");
            strTemp.Append(tabHtml + "\r\n");
            strTemp.Append("<tr>\r\n");
            strTemp.AppendFormat(tdTopHtml + "修改{0}</td> \r\n", tabName);
            strTemp.Append("</tr>\r\n");

            DataSet ds = DbHelperSQL.Query(string.Format(" exec SysTable  '{0}'", tabName));//读取表字段信息
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string description = row["description"].ToString();
                string columnName = row["column_name"].ToString();
                string dataType = row["data_type"].ToString().ToLower();

                if (columnName.ToUpper() == "ID")
                {
                    continue;
                }



                if (selectFields.IndexOf("|" + columnName + "|") > -1)
                {
                    strTemp.AppendFormat("\r\n<tr>\r\n{0}", tdHtml);
                    string titleDescription = description.Replace("(下拉)", "").Replace("(复选)", "").Replace("(单选)", "").Replace(" ", "").Replace("*", "<font color=\"red\">*</font>");
                    strTemp.AppendFormat("{0}</td>\r\n", titleDescription);

                    if (description.IndexOf("(下拉)") > -1)
                    {
                        strTemp.AppendFormat("{0}\r\n<select name=\"{1}\" id=\"{1}\"  >\r\n<option value=\"\">请选择</option>\r\n<%={1}Options%>\n</select>\r\n</td>\r\n</tr>\r\n", tdHtml, columnName);

                    }
                    else if (description.IndexOf("(复选)") > -1)
                    {
                        strTemp.AppendFormat("{0}\r\n<%=LoadCheck{1}()%>\r\n</td>\r\n</tr>\r\n", tdHtml, columnName);

                    }
                    else if (description.IndexOf("(单选)") > -1)
                    {
                        strTemp.AppendFormat("{0}\r\n<%=LoadRadio{1}()%>\r\n</td>\r\n</tr>\r\n", tdHtml, columnName);

                    }
                    else if (description.IndexOf("(图)") > -1)
                    {
                        strTemp.AppendFormat("\r\n{0}\r\n", tdHtml);
                        strTemp.Append("<img src=\"/Images/NoPhoto.jpg\" alt=\"图片\" name=\"ImgName\" height=\"100\"  width=\"100\">\r\n");
                        strTemp.Append("<input name=\"btnSelectImage\" onclick=\"OpenImages();\" type=\"button\" value=\"选择图片\" />\r\n");
                        strTemp.AppendFormat("<input name=\"{0}\" id=\"{0}\" type=\"hidden\" value=\"<%=model.{0}%>\">\r\n", columnName);
                        strTemp.Append("</td>\r\n</tr>\r\n");

                    }
                    else if (dataType == "text" || dataType == "ntext")
                    {
                        strTemp.AppendFormat("{0}\r\n<textarea name=\"{1}\" id =\"{1}\" cols=\"40\" rows=\"8\" {2} ><%=model.{1}%></textarea>\r\n</td>\r\n</tr>\r\n", tdHtml, columnName, textAreaCss);
                    }
                    else
                    {
                        strTemp.AppendFormat("{0}<input type=\"text\" name=\"{1}\" id =\"{1}\" value=\"<%=model.{1}%>\" {2}/>\r\n</td>\r\n</tr>\r\n", tdHtml, columnName, inputCss);
                    }



                }

            }
            strTemp.AppendFormat("<tr>\r\n{0}\r\n", tdButtomHtml);
            strTemp.AppendFormat("<input name=\"Submit\" type=\"submit\" {0} value=\"提交保存\" />&nbsp;&nbsp;&nbsp;&nbsp;<input type=\"reset\" name=\"Submit\" value=\" 重  置 \" {0} />", bottonCss);
            strTemp.Append("</td>\r\n</tr>\r\n</table>\r\n");
            strTemp.Append("</form>\r\n");
            strTemp.Append("</body>\r\n</html>\r\n");

            return strTemp;


        }

        /// <summary>
        /// 添加页面CS代码
        /// </summary>
        /// <param name="selectFields"></param>
        /// <param name="tabName"></param>
        /// <param name="isCheck"></param>
        /// <returns></returns>
        public static StringBuilder CsPageByUpdate(string selectFields, string tabName, string path, bool isCheck)
        {
            StringBuilder strTemp = new StringBuilder();
            strTemp.Append("using System;\r\n");
            strTemp.Append("using System.Collections.Generic;\r\n");
            strTemp.Append("using System.Text;\r\n");
            strTemp.Append("\r\n");
            strTemp.AppendFormat("namespace {0}.Web.UI.{1}\r\n", NamespaceName, path);
            strTemp.Append("{\r\n");
            strTemp.AppendFormat("    public class Update{0} : {1}.Web.UI.Page.AdminPageBase\r\n", tabName, NamespaceName);
            strTemp.Append("    {\r\n");
            strTemp.Append(" protected " + NamespaceName + ".Model." + tabName + " model { get; set; }\r\n");
            strTemp.Append("        protected void Page_Load(object sender, EventArgs e)\r\n");
            strTemp.Append("        {\r\n");
            strTemp.Append("            if (!IsPostBack)\r\n");
            strTemp.Append("            {\r\n");
            strTemp.Append("                this.ShowInfo();\r\n");
            strTemp.Append("                this.UpdateSave();\r\n");
            strTemp.Append("\r\n");
            strTemp.Append("            }\r\n");
            strTemp.Append("        }\r\n");

            DataSet ds = DbHelperSQL.Query(string.Format(" exec SysTable  '{0}'", tabName));


            strTemp.Append("/// <summary>\r\n/// 添加数据\r\n/// </summary>\r\n");
            strTemp.Append("protected void UpdateSave()\r\n{\r\n");

            strTemp.Append("if (Request.QueryString[\"action\"] == \"save\")\r\n");
            strTemp.Append("        {\r\n");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string columnName = row["column_name"].ToString();
                string titleDescription = row["description"].ToString();
                string dataType = row["data_type"].ToString();
                string columnFlag = row["标识"].ToString();

                if (selectFields.IndexOf("|" + columnName + "|") > -1)
                {
                    if (columnFlag == "√")
                    {
                        strTemp.AppendFormat("    string {0}={1}.Common.Helper.StringHelper.GetSafeString(Request.QueryString [\"{0}\"]);//{2}\r\n", columnName, NamespaceName, titleDescription);

                    }
                    else
                    {
                        strTemp.AppendFormat("    string {0}={1}.Common.Helper.StringHelper.GetSafeString(Request.Form [\"{0}\"]);//{2}\r\n", columnName, NamespaceName, titleDescription);
                    }

                }

            }
            if (isCheck)
            {
                strTemp.Append("\r\n\r\n");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string columnName = row["column_name"].ToString();
                    string description = row["description"].ToString();
                    string titleDescription = description.Replace("(下拉)", "").Replace("(复选)", "").Replace("(单选)", "").Replace(" ", "").Replace("\n", "").Replace("*", "");
                    string dataType = row["data_type"].ToString();
                    string columnFlag = row["标识"].ToString();

                    if (selectFields.IndexOf("|" + columnName + "|") > -1)
                    {
                        if (columnFlag == "√")
                        {
                            continue;
                        }
                        if (description.IndexOf("*") > -1)
                        {
                            strTemp.AppendFormat("\r\n    if ({0} == \"\") \r\n    ", columnName);
                            strTemp.Append("{\r\n");
                            strTemp.AppendFormat("        {0}.Common.Helper.JscriptHelper.AlertReturn(\"{1}不能为空!\");\r\n        return;\r\n", NamespaceName, titleDescription);
                            strTemp.Append("\r\n    }\r\n");
                        }
                    }

                }
            }
            strTemp.Append("\r\n\r\n");
            strTemp.AppendFormat("    {0}.Model.{1} model=new {0}.Model.{1}();\r\n", NamespaceName, tabName);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string columnName = row["column_name"].ToString();
                string titleDescription = row["description"].ToString();
                titleDescription = titleDescription.Replace("(下拉)", "").Replace("(复选)", "").Replace("(单选)", "").Replace(" ", "").Replace("\n", "").Replace("*", "");
                string dataType = row["data_type"].ToString();
                string columnFlag = row["标识"].ToString();

                if (selectFields.IndexOf("|" + columnName + "|") > -1)
                {
                    strTemp.AppendFormat("    model.{0}={1};\r\n", columnName, GetTypeString(dataType.ToLower(), columnName));
                }

            }
            strTemp.Append("\r\n    if(" + NamespaceName + ".BLL." + tabName + ".Instance.Update(model)>0)\r\n {" + NamespaceName + ".Common.Helper.JscriptHelper.AlertTo(\"操作成功!\", \"Show" + tabName + ".aspx\");\r\n}\r\n");
            strTemp.Append("else \r\n{\r\n" + NamespaceName + ".Common.Helper.JscriptHelper.AlertReturn(\"操作失败!\");\r\n}\r\n}\r\n}\r\n");

            strTemp.Append("        /// <summary>\r\n");
            strTemp.Append("        /// 显示数据\r\n");
            strTemp.Append("        /// </summary>\r\n");
            strTemp.Append("        private void ShowInfo()\r\n");
            strTemp.Append("        {\r\n");
            strTemp.Append("            if (" + NamespaceName + ".Common.Helper.ValidateHelper.IsNumber(Request.QueryString[\"ID\"]))\r\n");
            strTemp.Append("            {\r\n");
            strTemp.Append("                int id = int.Parse(Request.QueryString[\"ID\"]);\r\n");
            strTemp.Append("                model = " + NamespaceName + ".BLL." + tabName + ".Instance.GetModel(id);\r\n");
            strTemp.Append("            }\r\n");
            strTemp.Append("            else\r\n");
            strTemp.Append("            {\r\n");
            strTemp.Append("                Response.Write(\"参数错误!\");\r\n");
            strTemp.Append("                Response.End();\r\n");
            strTemp.Append("            }\r\n");
            strTemp.Append("        }\r\n");
            strTemp.Append("    }\r\n");
            strTemp.Append("}\r\n");
            strTemp.Append("\r\n");

            return strTemp;

        }

        /// <summary>
        /// 取转换类型
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static string GetTypeString(string dataType, string columnName)
        {
            string temp = string.Empty;
            if (dataType == "varchar" || dataType == "nvarchar" || dataType == "text" || dataType == "ntext")
            {
                temp = columnName;
            }
            else if (dataType == "int" || dataType == "smallint")
            {
                temp = string.Format("Convert.ToInt32({0})", columnName);
            }
            else if (dataType == "bigint")
            {
                temp = string.Format("Convert.ToInt64({0})", columnName);
            }
            else if (dataType == "datetime")
            {
                temp = "DateTime.Now";
            }
            else if (dataType == "numeric")
            {
                temp = string.Format("Convert.ToDecimal({0})", columnName);

            }
            return temp;
        }

        public static StringBuilder JsPageAdd(string selectFields, string tabName)
        {
            StringBuilder strTemp = new StringBuilder();
            DataSet ds = DbHelperSQL.Query(string.Format(" exec SysTable  '{0}'", tabName));

            strTemp.Append("$(document).ready(function(){\r\n");
            strTemp.Append("\r\n");
            strTemp.Append("    init();\r\n");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string description = row["description"].ToString();
                string columnName = row["column_name"].ToString();

                if (description.IndexOf("*") > -1)
                {
                    strTemp.AppendFormat("    $(\"#{0}\").bind(\"focus\",{0}Focus);\r\n", columnName);
                    strTemp.AppendFormat("    $(\"#{0}\").bind(\"blur\",{0}Blur);\r\n", columnName);
                }
            }
            strTemp.Append("})\r\n");
            strTemp.Append("\r\n");
            strTemp.Append("function init()\r\n");
            strTemp.Append("{\r\n");
            strTemp.Append("	msg= new Array(\r\n");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string description = row["description"].ToString();
                string titleDescription = ReplaceDescription(description);
                if (description.IndexOf("*") > -1)
                {
                    strTemp.AppendFormat("	\"<font color='#666666'>请输入{0}</font>\",\r\n", titleDescription);
                }
            }

            strTemp.Remove(strTemp.Length - 3, 1);
            strTemp.Append("	);\r\n");
            int i = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string columnName = row["column_name"].ToString();
                string description = row["description"].ToString();

                if (description.IndexOf("*") > -1)
                {
                    strTemp.AppendFormat("	$(\"#lbl{0}\").html(msg[{1}]);\r\n", columnName, i);
                    i++;
                }
            }

            strTemp.Append("	\r\n");
            strTemp.Append("}\r\n");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string columnName = row["column_name"].ToString();
                string description = row["description"].ToString();
                string titleDescription = ReplaceDescription(description);

                if (description.IndexOf("*") > -1)
                {
                    strTemp.AppendFormat("function {0}Focus()\r\n", columnName);
                    strTemp.Append("{\r\n");
                    strTemp.AppendFormat("    $(\"#lbl{0}\").addClass(\"doErr\");\r\n", columnName);
                    strTemp.Append("}\r\n");
                    strTemp.AppendFormat("function {0}Blur()\r\n", columnName);
                    strTemp.Append("{\r\n");
                    strTemp.AppendFormat("    if($(\"#{0}\").val()==\"\")\r\n", columnName);
                    strTemp.Append("    {\r\n");
                    strTemp.AppendFormat("        $(\"#lbl{0}\").addClass(\"doErr\");\r\n", columnName);
                    strTemp.Append("    }\r\n");
                    strTemp.Append("    else\r\n");
                    strTemp.Append("    {\r\n");
                    strTemp.AppendFormat("        $(\"#lbl{0}\").html(\"{1}已输入!\");\r\n", columnName, titleDescription);
                    strTemp.AppendFormat("        $(\"#lbl{0}\").addClass(\"doOk\");\r\n", columnName);
                    strTemp.Append("    }\r\n");
                    strTemp.Append("}\r\n");
                }
            }

            strTemp.Append("function CheckForm()\r\n");
            strTemp.Append("{\r\n");
            strTemp.Append("  \r\n");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string columnName = row["column_name"].ToString();
                string description = row["description"].ToString();
                string titleDescription = ReplaceDescription(description);
                if (description.IndexOf("*") > -1)
                {
                    strTemp.AppendFormat("  if ($(\"#{0}\").val()==\"\")\r\n", columnName);
                    strTemp.Append("  {\r\n");
                    strTemp.AppendFormat("	  alert(\"{0}不能为空!\");\r\n", titleDescription);
                    strTemp.AppendFormat("	  $(\"#lbl{0}\").addClass(\"doErr\");\r\n", columnName);
                    strTemp.AppendFormat("      $(\"#{0}\").focus();\r\n", columnName);
                    strTemp.Append("	  return false;\r\n");
                    strTemp.Append("  }\r\n");
                    strTemp.Append(" \r\n");
                }
            }

            strTemp.Append("  return true;\r\n");
            strTemp.Append("}\r\n");

            return strTemp;


        }

        public static StringBuilder JsPageAdd2(string selectFields, string tabName,bool isCheck)
        {
            StringBuilder strTemp = new StringBuilder();
            DataSet ds = DbHelperSQL.Query(string.Format(" exec SysTable  '{0}'", tabName));
            strTemp.Append("$(document).ready(function () {\r\n");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string columnName = row["column_name"].ToString();
                string description = row["description"].ToString();
                string titleDescription = ReplaceDescription(description);
                if (selectFields .IndexOf (columnName) > -1)
                {
                    strTemp.Append("    $(\"#" + columnName + "\").bind(\"keyup blur\", function () {\r\n");
                    strTemp.Append("        if (isNaN($(this).val())) {\r\n");
                    strTemp.Append("            $(this).val('0');\r\n");
                    strTemp.Append("        }\r\n");
                    strTemp.Append("    })\r\n");
                    strTemp.Append("\r\n");
                }
            }
            if (isCheck)
            {
                strTemp.Append("    $(\"input[name='Sort']\").each(function () {\r\n");
                strTemp.Append("        $(this).bind(\"keyup blur\", function () {\r\n");
                strTemp.Append("            if (isNaN($(this).val())) {\r\n");
                strTemp.Append("                $(this).val('0');\r\n");
                strTemp.Append("            }\r\n");
                strTemp.Append("        })\r\n");
                strTemp.Append("    })\r\n");
            }
            strTemp.Append("\r\n");
            strTemp.Append("})\r\n");

            strTemp.Append("\r\n");
            strTemp.Append("function CheckForm()\r\n");
            strTemp.Append("{\r\n");
            strTemp.Append("  \r\n");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string columnName = row["column_name"].ToString();
                string description = row["description"].ToString();
                string titleDescription = ReplaceDescription(description);
                if (description.IndexOf("*") > -1)
                {
                    strTemp.AppendFormat("  if ($(\"#{0}\").val()==\"\")\r\n", columnName);
                    strTemp.Append("  {\r\n");
                    strTemp.AppendFormat("	  alert(\"{0}不能为空!\");\r\n", titleDescription);
                    strTemp.AppendFormat("      $(\"#{0}\").focus();\r\n", columnName);
                    strTemp.Append("	  return false;\r\n");
                    strTemp.Append("  }\r\n");
                    strTemp.Append(" \r\n");
                }
            }

            strTemp.Append("  return true;\r\n");
            strTemp.Append("}\r\n");

            return strTemp;

        }

        public static string ReplaceDescription(string description)
        {
            return description.Replace("(下拉)", "").Replace("(复选)", "").Replace("(单选)", "").Replace(" ", "").Replace("*", "");
        }

        /// <summary>
        /// 生成2.0的Model代码
        /// </summary>
        /// <param name="tabName"></param>
        /// <returns></returns>
        public static StringBuilder CsModel2(string tabName, string selectFields, bool isP)
        {
            System.Text.StringBuilder strTableList = new StringBuilder();

            strTableList.Append("using System;\r\n");
            strTableList.AppendFormat("namespace {0}.Model\r\n", NamespaceName);
            strTableList.Append("{\r\n");
            strTableList.Append("    /// <summary>\r\n");
            strTableList.Append("    /// 实体类" + tabName + "(属性说明自动提取数据库字段的描述信息)\r\n");
            strTableList.Append("    /// </summary>\r\n");
            strTableList.Append("    [Serializable]\r\n");
            strTableList.Append("    public class " + tabName + "\r\n");
            strTableList.Append("    {\r\n");
            strTableList.Append("        public " + tabName + "()\r\n");
            strTableList.Append("        { }\r\n");
            strTableList.Append("        #region Model\r\n");

            DataSet ds = DbHelperSQL.Query(" exec SysTable  '" + tabName + "'");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string colmnName = row["column_name"].ToString().ToLower();


                if (isP)//如果是批量
                {
                    strTableList.Append("        private " + getType(row["data_Type"].ToString()) + " _" + colmnName + ";\r\n");

                }
                else
                {
                    if (selectFields.ToLower().IndexOf("|" + colmnName + "|") > -1)
                    {
                        strTableList.Append("        private " + getType(row["data_Type"].ToString()) + " _" + colmnName + ";\r\n");

                    }
                }

            }
            strTableList.Append("\r\n");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string description = row["description"].ToString();
                string colmnName = row["column_name"].ToString();

                if (isP)
                {
                    strTableList.Append("        /// <summary>\r\n");
                    strTableList.Append("        /// " + description + "\r\n");
                    strTableList.Append("        /// </summary>\r\n");
                    strTableList.Append("        public " + getType(row["data_Type"].ToString()) + " " + colmnName + "\r\n");
                    strTableList.Append("        {\r\n");
                    strTableList.Append("            set { _" + colmnName.ToLower() + " = value; }\r\n");
                    strTableList.Append("            get { return _" + colmnName.ToLower () + "; }\r\n");
                    strTableList.Append("        }\r\n");
                }
                else
                {
                    if (selectFields.ToLower().IndexOf("|" + colmnName + "|") > -1)
                    {

                        strTableList.Append("        /// <summary>\r\n");
                        strTableList.Append("        /// " + description + "\r\n");
                        strTableList.Append("        /// </summary>\r\n");
                        strTableList.Append("        public " + getType(row["data_Type"].ToString()) + " " + colmnName + "\r\n");
                        strTableList.Append("        {\r\n");
                        strTableList.Append("            set { _" + colmnName.ToLower () + " = value; }\r\n");
                        strTableList.Append("            get { return _" + colmnName.ToLower () + "; }\r\n");
                        strTableList.Append("        }\r\n");


                    }
                }
            }

            strTableList.Append("        #endregion Model\r\n");
            strTableList.Append("    }\r\n");
            strTableList.Append("}\r\n");
            return strTableList;
        }
        /// <summary>
        /// 取数据类型
        /// </summary>
        /// <param name="iType"></param>
        /// <returns></returns>
        private static string getType(string iType)
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
        /// 
        /// </summary>
        /// <returns></returns>
        public static StringBuilder DataProviderString()
        {
            StringBuilder strTableList = new StringBuilder();
            strTableList.Append("using System;\r\n");
            strTableList.Append("using System.Collections.Generic;\r\n");
            strTableList.Append("using System.Text;\r\n");
            strTableList.Append("using System.Configuration;\r\n");
            strTableList.Append("using System.Data;\r\n");
            strTableList.Append("using System.Data.SqlClient;\r\n");
            strTableList.Append("using System.IO;\r\n");
            strTableList.Append("namespace " + NamespaceName + ".SQLServerDAL\r\n");
            strTableList.Append("{\r\n");
            strTableList.Append("    public partial class DataProvider\r\n");
            strTableList.Append("    {\r\n");
            strTableList.Append("        private static object locker = new object();\r\n");
            strTableList.Append("        private static DataProvider _instance = null;\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 返回数据层唯一的一个实例\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public static DataProvider Instance\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            get\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                if (_instance == null)\r\n");
            strTableList.Append("                {\r\n");
            strTableList.Append("                    lock (locker)\r\n");
            strTableList.Append("                    {\r\n");
            strTableList.Append("                        if (_instance == null)\r\n");
            strTableList.Append("                        {\r\n");
            strTableList.Append("                            SqlHelper.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[\"connectionString\"].ToString();\r\n");
            strTableList.Append("                            _instance = new DataProvider();\r\n");
            strTableList.Append("                        }\r\n");
            strTableList.Append("                    }\r\n");
            strTableList.Append("                }\r\n");
            strTableList.Append("                return _instance;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 读取数据\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        private SqlDataReader GetList(int top, string fldName, string tblName, string strWhere, string fldSort)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlParameter[] parameters = new SqlParameter[]\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                new SqlParameter(\"@top\",SqlDbType.Int,4),\r\n");
            strTableList.Append("                new SqlParameter(\"@fldName\",SqlDbType.NVarChar ,4000),\r\n");
            strTableList.Append("                new SqlParameter (\"@tblName\",SqlDbType .NVarChar ,1000),\r\n");
            strTableList.Append("                new SqlParameter (\"@strWhere\",SqlDbType .NVarChar ,4000),\r\n");
            strTableList.Append("                new SqlParameter (\"@fldSort\",SqlDbType .NVarChar ,4000)};\r\n");
            strTableList.Append("            parameters[0].Value = top;\r\n");
            strTableList.Append("            parameters[1].Value = fldName;\r\n");
            strTableList.Append("            parameters[2].Value = tblName;\r\n");
            strTableList.Append("            parameters[3].Value = strWhere;\r\n");
            strTableList.Append("            parameters[4].Value = fldSort;\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            return SqlHelper.ExecuteReader(\"GetList\", parameters);\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 读取数据\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public DataTable GetDataTableList(int top, string fldName, string tblName, string strWhere, string fldSort)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlParameter[] parameters = new SqlParameter[]\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                new SqlParameter(\"@top\",SqlDbType.Int,4),\r\n");
            strTableList.Append("                new SqlParameter(\"@fldName\",SqlDbType.NVarChar ,4000),\r\n");
            strTableList.Append("                new SqlParameter (\"@tblName\",SqlDbType .NVarChar ,1000),\r\n");
            strTableList.Append("                new SqlParameter (\"@strWhere\",SqlDbType .NVarChar ,4000),\r\n");
            strTableList.Append("                new SqlParameter (\"@fldSort\",SqlDbType .NVarChar ,4000)};\r\n");
            strTableList.Append("            parameters[0].Value = top;\r\n");
            strTableList.Append("            parameters[1].Value = fldName;\r\n");
            strTableList.Append("            parameters[2].Value = tblName;\r\n");
            strTableList.Append("            parameters[3].Value = strWhere;\r\n");
            strTableList.Append("            parameters[4].Value = fldSort;\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            return SqlHelper.ExecuteTable(\"GetList\", parameters);\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 读取数据\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public DataTable GetDataTableListByLock(int top, string fldName, string tblName, string strWhere, string fldSort)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlParameter[] parameters = new SqlParameter[]\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                new SqlParameter(\"@top\",SqlDbType.Int,4),\r\n");
            strTableList.Append("                new SqlParameter(\"@fldName\",SqlDbType.NVarChar ,4000),\r\n");
            strTableList.Append("                new SqlParameter (\"@tblName\",SqlDbType .NVarChar ,1000),\r\n");
            strTableList.Append("                new SqlParameter (\"@strWhere\",SqlDbType .NVarChar ,4000),\r\n");
            strTableList.Append("                new SqlParameter (\"@fldSort\",SqlDbType .NVarChar ,4000)};\r\n");
            strTableList.Append("            parameters[0].Value = top;\r\n");
            strTableList.Append("            parameters[1].Value = fldName;\r\n");
            strTableList.Append("            parameters[2].Value = tblName;\r\n");
            strTableList.Append("            parameters[3].Value = strWhere;\r\n");
            strTableList.Append("            parameters[4].Value = fldSort;\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            return SqlHelper.ExecuteTable(\"GetListByLock\", parameters);\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 删除数据\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public int Delete(string tblName, string strWhere)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            string sql = string.Format(\"delete {0} where {1}\", tblName, strWhere);\r\n");
            strTableList.Append("            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql);\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 统计数据\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public int GetCount(string fldName, string tblName, string strWhere)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            string sql = string.Format(\"select count({0}) from {1} with(nolock) \", fldName, tblName);\r\n");
            strTableList.Append("            if (!string.IsNullOrEmpty(strWhere))\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                sql += string.Format(\" where {0}\", strWhere);\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, sql));\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 取单个值\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public object GetSingle(string fldName, string tblName, string strWhere)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            string sql = string.Format(\"select {0} from {1} where {2}\", fldName, tblName, strWhere);\r\n");
            strTableList.Append("            return SqlHelper.ExecuteScalar(CommandType.Text, sql);\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 取最大值\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        /// <param name=\"tblName\"></param>\r\n");
            strTableList.Append("        /// <returns></returns>\r\n");
            strTableList.Append("        public int GetMaxID(string tblName)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            string sql = string.Format(\"select max(id)+1 from {0}\", tblName);\r\n");
            strTableList.Append("            object obj= SqlHelper.ExecuteScalar(CommandType.Text, sql);\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            if (Object.Equals(obj, null ) || Object.Equals(obj, DBNull.Value))\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                return 1;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            else\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                return Convert.ToInt32(obj);\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("    }\r\n");
            strTableList.Append("}\r\n");
            strTableList.Append("\r\n");

            return strTableList;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static StringBuilder SqlHelperString()
        {
            StringBuilder strTableList = new StringBuilder();
            strTableList.Append("using System;\r\n");
            strTableList.Append("using System.Collections.Generic;\r\n");
            strTableList.Append("using System.Text;\r\n");
            strTableList.Append("using System.Data.SqlClient;\r\n");
            strTableList.Append("using System.Data;\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("namespace " + NamespaceName + ".SQLServerDAL\r\n");
            strTableList.Append("{\r\n");
            strTableList.Append("    /// <summary>\r\n");
            strTableList.Append("    /// SQL SERVER Helper\r\n");
            strTableList.Append("    /// </summary>\r\n");
            strTableList.Append("    public class SqlHelper\r\n");
            strTableList.Append("    {\r\n");
            strTableList.Append("        public static int CommandTimeout = 30;\r\n");
            strTableList.Append("        public static string ConnectionString = string.Empty;\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 获得连接对象\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        /// <returns></returns>\r\n");
            strTableList.Append("        public static SqlConnection GetSqlConnection()\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            return new SqlConnection(ConnectionString);\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 获得连接对象\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        /// <returns></returns>\r\n");
            strTableList.Append("        public static SqlConnection GetSqlConnection(string connectionString)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            return new SqlConnection(connectionString);\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 获得Sql Server 中能存储的最小日期\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        /// <returns></returns>\r\n");
            strTableList.Append("        public static DateTime GetMinDateTime()\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            return new DateTime(1753, 1, 1, 0, 0, 0, 0);\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("\r\n");


            strTableList.Append("\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 根据传入的存储过程名称和参数执行存储过程并返回受影响的行数\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        /// <param name=\"cmdText\">存储过程名</param>\r\n");
            strTableList.Append("        /// <param name=\"commandParameters\">传入的参数</param>\r\n");
            strTableList.Append("        /// <returns></returns>\r\n");
            strTableList.Append("        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] commandParameters)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlCommand command = new SqlCommand();\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            using (SqlConnection connection = GetSqlConnection())\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                PrepareCommand(command, connection, null, CommandType.StoredProcedure, cmdText, commandParameters);\r\n");
            strTableList.Append("                int val = command.ExecuteNonQuery();\r\n");
            strTableList.Append("                command.Parameters.Clear();\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                return val;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlCommand command = new SqlCommand();\r\n");
            strTableList.Append("            PrepareCommand(command, connection, null, cmdType, cmdText, commandParameters);\r\n");
            strTableList.Append("            int val = command.ExecuteNonQuery();\r\n");
            strTableList.Append("            command.Parameters.Clear();\r\n");
            strTableList.Append("            return val;\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlCommand command = new SqlCommand();\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            using (SqlConnection connection = GetSqlConnection())\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                PrepareCommand(command, connection, null, cmdType, cmdText, commandParameters);\r\n");
            strTableList.Append("                int val = command.ExecuteNonQuery();\r\n");
            strTableList.Append("                command.Parameters.Clear();\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                return val;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlCommand command = new SqlCommand();\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            using (SqlConnection connection = GetSqlConnection(connectionString))\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                PrepareCommand(command, connection, null, cmdType, cmdText, commandParameters);\r\n");
            strTableList.Append("                int val = command.ExecuteNonQuery();\r\n");
            strTableList.Append("                command.Parameters.Clear();\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                return val;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        public static int ExecuteNonQuery(string connectionString, string cmdText, params SqlParameter[] commandParameters)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlCommand command = new SqlCommand();\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            using (SqlConnection connection = GetSqlConnection(connectionString))\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                PrepareCommand(command, connection, null, CommandType.StoredProcedure, cmdText, commandParameters);\r\n");
            strTableList.Append("                int val = command.ExecuteNonQuery();\r\n");
            strTableList.Append("                command.Parameters.Clear();\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                return val;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 根据传入的存储过程名称和参数执行存储过程并返回SqlDataReader对象\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        /// <param name=\"cmdText\">存储过程名</param>\r\n");
            strTableList.Append("        /// <param name=\"commandParameters\">传入的参数</param>\r\n");
            strTableList.Append("        /// <returns></returns>\r\n");
            strTableList.Append("        public static SqlDataReader ExecuteReader(string cmdText, params SqlParameter[] commandParameters)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlCommand command = new SqlCommand();\r\n");
            strTableList.Append("            SqlConnection connection = GetSqlConnection();\r\n");
            strTableList.Append("            try\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                PrepareCommand(command, connection, null, CommandType.StoredProcedure, cmdText, commandParameters);\r\n");
            strTableList.Append("                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);\r\n");
            strTableList.Append("                command.Parameters.Clear();\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("                return reader;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            catch\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                throw;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlCommand command = new SqlCommand();\r\n");
            strTableList.Append("            SqlConnection connection = GetSqlConnection(connectionString);\r\n");
            strTableList.Append("            try\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                PrepareCommand(command, connection, null, cmdType, cmdText, commandParameters);\r\n");
            strTableList.Append("                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);\r\n");
            strTableList.Append("                command.Parameters.Clear();\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("                return reader;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            catch\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                throw;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        public static SqlDataReader ExecuteReader(string connectionString, string cmdText, params SqlParameter[] commandParameters)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlCommand command = new SqlCommand();\r\n");
            strTableList.Append("            SqlConnection connection = GetSqlConnection(connectionString);\r\n");
            strTableList.Append("            try\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                PrepareCommand(command, connection, null, CommandType.StoredProcedure, cmdText, commandParameters);\r\n");
            strTableList.Append("                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);\r\n");
            strTableList.Append("                command.Parameters.Clear();\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("                return reader;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            catch\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                throw;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlCommand command = new SqlCommand();\r\n");
            strTableList.Append("            SqlConnection connection = GetSqlConnection();\r\n");
            strTableList.Append("            try\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                PrepareCommand(command, connection, null, cmdType, cmdText, commandParameters);\r\n");
            strTableList.Append("                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);\r\n");
            strTableList.Append("                command.Parameters.Clear();\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("                return reader;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            catch\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                throw;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 新增后台获取DataTable方法\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        /// <param name=\"cmdText\"></param>\r\n");
            strTableList.Append("        /// <param name=\"commandParameters\"></param>\r\n");
            strTableList.Append("        /// <returns></returns>\r\n");
            strTableList.Append("        public static DataTable ExecuteTable(string cmdText, params SqlParameter[] commandParameters)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlCommand command = new SqlCommand();\r\n");
            strTableList.Append("            SqlDataAdapter adapter;\r\n");
            strTableList.Append("            SqlConnection connection = GetSqlConnection();\r\n");
            strTableList.Append("            DataTable table = new DataTable();\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            try\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                PrepareCommand(command, connection, null, CommandType.StoredProcedure, cmdText, commandParameters);\r\n");
            strTableList.Append("                adapter = new SqlDataAdapter(command);\r\n");
            strTableList.Append("                adapter.Fill(table);\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            catch (Exception ex)\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                throw;\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            finally\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                command.Parameters.Clear();\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            return table;\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        public static DataTable ExecuteTable(string cmdText, CommandType commandType, params SqlParameter[] commandParameters)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlCommand command = new SqlCommand();\r\n");
            strTableList.Append("            SqlDataAdapter adapter;\r\n");
            strTableList.Append("            SqlConnection connection = GetSqlConnection();\r\n");
            strTableList.Append("            DataTable table = new DataTable();\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            try\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                PrepareCommand(command, connection, null, commandType, cmdText, commandParameters);\r\n");
            strTableList.Append("                adapter = new SqlDataAdapter(command);\r\n");
            strTableList.Append("                adapter.Fill(table);\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            catch (Exception ex)\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                throw;\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            finally\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                command.Parameters.Clear();\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            return table;\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        public static DataTable ExecuteTable(string connectionString, string cmdText, CommandType commandType, params SqlParameter[] commandParameters)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlCommand command = new SqlCommand();\r\n");
            strTableList.Append("            SqlDataAdapter adapter;\r\n");
            strTableList.Append("            SqlConnection connection = GetSqlConnection(connectionString);\r\n");
            strTableList.Append("            DataTable table = new DataTable();\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            try\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                PrepareCommand(command, connection, null, commandType, cmdText, commandParameters);\r\n");
            strTableList.Append("                adapter = new SqlDataAdapter(command);\r\n");
            strTableList.Append("                adapter.Fill(table);\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            catch (Exception ex)\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                throw;\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            finally\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                command.Parameters.Clear();\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            return table;\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 新增后台获取DataSet方法\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        /// <param name=\"cmdText\"></param>\r\n");
            strTableList.Append("        /// <param name=\"commandParameters\"></param>\r\n");
            strTableList.Append("        /// <returns></returns>\r\n");
            strTableList.Append("        public static DataSet ExecuteDataSet(string cmdText, params SqlParameter[] commandParameters)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlCommand command = new SqlCommand();\r\n");
            strTableList.Append("            SqlDataAdapter adapter;\r\n");
            strTableList.Append("            SqlConnection connection = GetSqlConnection();\r\n");
            strTableList.Append("            DataSet ds = new DataSet();\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            try\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                PrepareCommand(command, connection, null, CommandType.StoredProcedure, cmdText, commandParameters);\r\n");
            strTableList.Append("                adapter = new SqlDataAdapter(command);\r\n");
            strTableList.Append("                adapter.Fill(ds);\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            catch (Exception ex)\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                throw;\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            finally\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                command.Parameters.Clear();\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            return ds;\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        public static DataSet ExecuteDataSet(string cmdText, CommandType commandType, params SqlParameter[] commandParameters)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlCommand command = new SqlCommand();\r\n");
            strTableList.Append("            SqlDataAdapter adapter;\r\n");
            strTableList.Append("            SqlConnection connection = GetSqlConnection();\r\n");
            strTableList.Append("            DataSet ds = new DataSet();\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            try\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                PrepareCommand(command, connection, null, commandType, cmdText, commandParameters);\r\n");
            strTableList.Append("                adapter = new SqlDataAdapter(command);\r\n");
            strTableList.Append("                adapter.Fill(ds);\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            catch (Exception ex)\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                throw;\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            finally\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                command.Parameters.Clear();\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            return ds;\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        public static DataSet ExecuteDataSet(string connectionString, string cmdText, CommandType commandType, params SqlParameter[] commandParameters)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlCommand command = new SqlCommand();\r\n");
            strTableList.Append("            SqlDataAdapter adapter;\r\n");
            strTableList.Append("            SqlConnection connection = GetSqlConnection(connectionString);\r\n");
            strTableList.Append("            DataSet ds = new DataSet();\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            try\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                PrepareCommand(command, connection, null, commandType, cmdText, commandParameters);\r\n");
            strTableList.Append("                adapter = new SqlDataAdapter(command);\r\n");
            strTableList.Append("                adapter.Fill(ds);\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            catch (Exception ex)\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                throw;\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            finally\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                command.Parameters.Clear();\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            return ds;\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 根据传入的存储过程名称和参数执行存储过程并返回结果集中的第一行第一列，忽略其他行或列\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        /// <param name=\"cmdText\">存储过程名</param>\r\n");
            strTableList.Append("        /// <param name=\"commandParameters\">传入的参数</param>\r\n");
            strTableList.Append("        /// <returns></returns>\r\n");
            strTableList.Append("        public static object ExecuteScalar(string cmdText, params SqlParameter[] commandParameters)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlCommand cmd = new SqlCommand();\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            using (SqlConnection connection = GetSqlConnection())\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                PrepareCommand(cmd, connection, null, CommandType.StoredProcedure, cmdText, commandParameters);\r\n");
            strTableList.Append("                object val = cmd.ExecuteScalar();\r\n");
            strTableList.Append("                cmd.Parameters.Clear();\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                return val;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        public static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlCommand cmd = new SqlCommand();\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            using (SqlConnection connection = GetSqlConnection())\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);\r\n");
            strTableList.Append("                object val = cmd.ExecuteScalar();\r\n");
            strTableList.Append("                cmd.Parameters.Clear();\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                return val;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlCommand cmd = new SqlCommand();\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            using (SqlConnection connection = GetSqlConnection(connectionString))\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);\r\n");
            strTableList.Append("                object val = cmd.ExecuteScalar();\r\n");
            strTableList.Append("                cmd.Parameters.Clear();\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                return val;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        public static object ExecuteScalar(string connectionString, string cmdText, params SqlParameter[] commandParameters)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlCommand cmd = new SqlCommand();\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            using (SqlConnection connection = GetSqlConnection(connectionString))\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                PrepareCommand(cmd, connection, null, CommandType.StoredProcedure, cmdText, commandParameters);\r\n");
            strTableList.Append("                object val = cmd.ExecuteScalar();\r\n");
            strTableList.Append("                cmd.Parameters.Clear();\r\n");
            strTableList.Append("                connection.Close();\r\n");
            strTableList.Append("                return val;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            if (conn.State != ConnectionState.Open)\r\n");
            strTableList.Append("                conn.Open();\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            cmd.Connection = conn;\r\n");
            strTableList.Append("            cmd.CommandText = cmdText;\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            if (trans != null)\r\n");
            strTableList.Append("                cmd.Transaction = trans;\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            cmd.CommandType = cmdType;\r\n");
            strTableList.Append("            cmd.CommandTimeout = CommandTimeout;\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            if (cmdParms != null)\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                foreach (SqlParameter parm in cmdParms)\r\n");
            strTableList.Append("                    cmd.Parameters.Add(parm);\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        public static int ExecuteNonQuery(SqlTransaction p_trans, CommandType p_cmdType, string p_cmdText, params SqlParameter[] p_cmdParms)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlCommand cmd = new SqlCommand();\r\n");
            strTableList.Append("            PrepareCommand(cmd, p_trans.Connection, p_trans, p_cmdType, p_cmdText, p_cmdParms);\r\n");
            strTableList.Append("            int val = cmd.ExecuteNonQuery();\r\n");
            strTableList.Append("            cmd.Parameters.Clear();\r\n");
            strTableList.Append("            return val;\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("        public static SqlDataReader ExecuteReader(SqlTransaction p_trans, CommandType p_cmdType, string p_cmdText, params SqlParameter[] p_cmdParms)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlCommand cmd = new SqlCommand();\r\n");
            strTableList.Append("            SqlConnection cn = p_trans.Connection;\r\n");
            strTableList.Append("            try\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                PrepareCommand(cmd, cn, p_trans, p_cmdType, p_cmdText, p_cmdParms);\r\n");
            strTableList.Append("                SqlDataReader dr = cmd.ExecuteReader();//CommandBehavior.CloseConnection,关闭关联的 DataReader 对象，则关联的 Connection 对象也将关闭\r\n");
            strTableList.Append("                cmd.Parameters.Clear();\r\n");
            strTableList.Append("                return dr;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            catch\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                cn.Close();\r\n");
            strTableList.Append("                throw;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 参数转换为字符串\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        /// <param name=\"cmdText\"></param>\r\n");
            strTableList.Append("        /// <param name=\"parms\"></param>\r\n");
            strTableList.Append("        /// <returns></returns>\r\n");
            strTableList.Append("        public static string ParmsToString(string cmdText, SqlParameter[] parms)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            StringBuilder sb = new StringBuilder();\r\n");
            strTableList.Append("            sb.AppendFormat(\"CmdText : {0},\", cmdText);\r\n");
            strTableList.Append("            sb.AppendLine(\"\");\r\n");
            strTableList.Append("            sb.AppendLine(\"Parms : \");\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            foreach (SqlParameter parm in parms)\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                sb.AppendFormat(\"{0} = {1}\", parm.ParameterName, parm.Value);\r\n");
            strTableList.Append("                sb.AppendLine(\"\");\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            return sb.ToString();\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 取表中最大值\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        /// <param name=\"FieldName\"></param>\r\n");
            strTableList.Append("        /// <param name=\"TableName\"></param>\r\n");
            strTableList.Append("        /// <returns></returns>\r\n");
            strTableList.Append("        public static int GetMaxId(string fieldName, string tableName)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            string strsql = \"select max(\" + fieldName + \")+1 from \" + tableName;\r\n");
            strTableList.Append("            object obj = SqlHelper.ExecuteScalar(CommandType.Text, strsql);\r\n");
            strTableList.Append("            if (obj == null)\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                return 1;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            else\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                return int.Parse(obj.ToString());\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 获取参数\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public SqlParameter MakeInputParm(string paramName, SqlDbType sqlDbType, int size, object value)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlParameter parm = new SqlParameter(paramName, sqlDbType, size);\r\n");
            strTableList.Append("            parm.Direction = ParameterDirection.Input;\r\n");
            strTableList.Append("            parm.Value = value;\r\n");
            strTableList.Append("            return parm;\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 获取参数(输出参数)\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public SqlParameter MakeOutputParm(string paramName, SqlDbType sqlDbType, int size)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlParameter parm = new SqlParameter(paramName, sqlDbType, size);\r\n");
            strTableList.Append("            parm.Direction = ParameterDirection.Output;\r\n");
            strTableList.Append("            return parm;\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 获取参数(返回值)\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public SqlParameter MakeReturnValueParm(string paramName, SqlDbType sqlDbType, int size)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            SqlParameter parm = new SqlParameter(paramName, sqlDbType, size);\r\n");
            strTableList.Append("            parm.Direction = ParameterDirection.ReturnValue;\r\n");
            strTableList.Append("            return parm;\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("    }\r\n");
            strTableList.Append("}\r\n");
            strTableList.Append("\r\n");

            return strTableList;

        }

        /// <summary>
        /// 列表web页面
        /// </summary>
        /// <returns></returns>
        public static StringBuilder WebPageByList(string tabName, string selectFields, string path, bool isSort)
        {
            StringBuilder strTableList = new StringBuilder();
            strTableList.Append("<%@ Page Language=\"C#\" AutoEventWireup=\"true\" Inherits=\"" + NamespaceName + ".Web.UI." + path + "Show" + tabName + "\" %>\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");
            strTableList.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
            strTableList.Append("<head>\r\n");
            strTableList.Append("    <title>" + tabName + "</title>\r\n");
            strTableList.Append("    <script language=\"javascript\" type=\"text/javascript\" src=\"../Js/jquery.min.js\"></script>\r\n");
            strTableList.Append("    <script language=\"javascript\" type=\"text/javascript\" src=\"../Js/common.js\"></script>\r\n");
            strTableList.Append("    <script language=\"javascript\" type=\"text/javascript\" src=\"../Js/" + tabName + ".js\"></script>\r\n");
            strTableList.Append("    <link rel=\"stylesheet\" type=\"text/css\" href=\"../css/admin.css\" />\r\n");
            strTableList.Append("</head>\r\n");
            strTableList.Append("<body>\r\n");

            strTableList.Append("        \r\n");
            strTableList.Append("            <table width=\"800\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"tableList\">\r\n");
            strTableList.Append("                <tr>\r\n");
            strTableList.Append("                    <td colspan=\"6\" align=\"left\" class=\"noneLeft\">\r\n");
            strTableList.Append("<form name=\"form2\" id=\"form2\" method=\"get\" action=\"\">");
            strTableList.Append("                        关键字：\r\n");
            strTableList.Append("<input id=\"KeyWord\" name=\"KeyWord\" type=\"text\" />\r\n");
            strTableList.Append("<input id=\"Submit1\" type=\"submit\" value=\"查询\" /></form>\r\n");
            strTableList.Append("                    </td>\r\n");
            strTableList.Append("                </tr>\r\n");
            strTableList.Append("    <form name=\"form1\" id=\"form1\" method=\"post\" action=\"\">\r\n");
            strTableList.Append("                <tr class=\"title\">\r\n");
            strTableList.Append("                    <td >\r\n");
            strTableList.Append("                        <input type=\"checkbox\" id=\"chkAll\" value=\"checkbox\" onclick=\"checkAll();\" />\r\n");
            strTableList.Append("                    </td>\r\n");

            int j = 2;
            DataSet ds = DbHelperSQL.Query(string.Format(" exec SysTable  '{0}'", tabName));//读取表字段信息
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string columnName = row["column_name"].ToString();
                string description = row["description"].ToString();
                string titleDescription = description.Replace("(下拉)", "").Replace("(复选)", "").Replace("(单选)", "").Replace(" ", "").Replace("*", "");

                if (selectFields.IndexOf("|" + columnName + "|") > -1)
                {
                    strTableList.Append("                    <td>\r\n");
                    strTableList.Append("                        " + titleDescription + "</td>\r\n");
                    j++;
                }
            }
            if (isSort)
            {
                j++;
                strTableList.Append("                    <td>\r\n");
                strTableList.Append("                        排序</td>\r\n");
            }
            strTableList.Append("                    <td>\r\n");
            strTableList.Append("                        操作</td>\r\n");
            strTableList.Append("                </tr>\r\n");
            strTableList.Append("                <%\r\n");
            strTableList.Append("                    if (" + tabName + "List != null)\r\n");
            strTableList.Append("                    {\r\n");
            strTableList.Append("                        foreach (" + NamespaceName + ".Model." + tabName + " item in " + tabName + "List)\r\n");
            strTableList.Append("                        { \r\n");
            strTableList.Append("                %>\r\n");
            strTableList.Append("                <tr>\r\n");
            strTableList.Append("                    <td>\r\n");
            strTableList.Append("                        <input type=\"checkbox\" name=\"chkID\" value=\"<%=item.ID %>\" />\r\n");
            if (isSort)
            {
                strTableList.Append("                        <input type=\"hidden\" name=\"ID\" value=\"<%=item.ID %>\" />\r\n");
            }
            strTableList.Append("                    </td>\r\n");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string columnName = row["column_name"].ToString();
                string dataType = row["data_type"].ToString().ToLower();
                string description = row["description"].ToString();

                if (selectFields.IndexOf("|" + columnName + "|") > -1)
                {
                    if (description.IndexOf("(下拉)") > -1)
                    {
                        strTableList.Append("                    <td>\r\n");
                        strTableList.Append("                        <%=" + NamespaceName + ".BLL." + columnName.Replace("ID", "") + ".Instance.Get"+columnName.Replace ("ID","Name")+"(item." + columnName + ")%>\r\n");
                        strTableList.Append("                    </td>\r\n");
                    }
                    else
                    {
                        strTableList.Append("                    <td>\r\n");
                        strTableList.Append("                        <%=item." + columnName + "%>\r\n");
                        strTableList.Append("                    </td>\r\n");
                    }
                }
            }
            if (isSort)
            {
                strTableList.Append("                    <td>\r\n");
                strTableList.Append("                        <input name=\"Sort\" type=\"text\" value=\"<%=item.Sort %>\" size=\"5\" />\r\n");
                strTableList.Append("                    </td>\r\n");
            }
            strTableList.Append("                    <td>\r\n");
            strTableList.Append("                        <a href=\"Update" + tabName + ".aspx?ID=<%=item.ID%>\">编辑</a>&nbsp; &nbsp;<a href=\"Show" + tabName + ".aspx?ID=<%=item.ID%>&amp;action=delete\"\r\n");
            strTableList.Append("                            onclick=\"return confirm('确认要删除吗？');\">删除</a>\r\n");
            strTableList.Append("                    </td>\r\n");



            strTableList.Append("                </tr>\r\n");
            strTableList.Append("                <%\r\n");
            strTableList.Append("                    }\r\n");
            strTableList.Append("                }\r\n");
            strTableList.Append("                %>\r\n");
            strTableList.Append("                <tr>\r\n");
            strTableList.Append("                    <td colspan=\"" + j + "\" align=\"left\">\r\n");
            if (isSort)
            {
                strTableList.Append("                        <input name=\"btnDelete\" type=\"submit\" value=\"删除\" /> <input name=\"btnSort\" type=\"submit\"  value=\"保存排序\" /> <a href=\"Add" + tabName + ".aspx\">新增</a>\r\n");
            }
            else
            {
                strTableList.Append("                        <input name=\"btnDelete\" type=\"submit\" value=\"删除\" /> <a href=\"Add" + tabName + ".aspx\">新增</a>\r\n");
            }
            strTableList.Append("                    </td>\r\n");
            strTableList.Append("                </tr>\r\n");
            strTableList.Append("                <tr>\r\n");
            strTableList.Append("                    <td colspan=\"" + j + "\" class=\"noneCenter\">\r\n");
            strTableList.Append("                        <%=GetPageUrl%>\r\n");
            strTableList.Append("                    </td>\r\n");
            strTableList.Append("                </tr>\r\n");
            strTableList.Append("    </form>\r\n");
            strTableList.Append("            </table>\r\n");
            strTableList.Append("      \r\n");
            strTableList.Append("</body>\r\n");
            strTableList.Append("</html>\r\n");
            strTableList.Append("\r\n");

            return strTableList;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tabName"></param>
        /// <param name="path"></param>
        /// <param name="isSort"></param>
        /// <returns></returns>
        public static StringBuilder CsPageByList(string tabName, string path, bool isSort)
        {
            StringBuilder strTableList = new StringBuilder();
            strTableList.Append("using System;\r\n");
            strTableList.Append("using System.Collections.Generic;\r\n");
            strTableList.Append("using System.Text;\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("namespace " + NamespaceName + ".Web.UI." + path + "\r\n");
            strTableList.Append("{\r\n");
            strTableList.Append("    public class Show" + tabName + " : " + NamespaceName + ".Web.UI.Page.AdminPageBase\r\n");
            strTableList.Append("    {\r\n");
            strTableList.Append("        protected void Page_Load(object sender, EventArgs e)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            if (!IsPostBack)\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                //删除\r\n");
            strTableList.Append("                this.DeleteSave();\r\n");
            strTableList.Append("\r\n");
            if (isSort)
            {
                strTableList.Append("                //排序\r\n");
                strTableList.Append("                this.SortSave();\r\n");
                strTableList.Append("\r\n");
            }
            strTableList.Append("                //查询\r\n");
            strTableList.Append("                this.Search();\r\n");
            strTableList.Append("           \r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("        private string _strwhere = string.Empty;\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 查询条件\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        protected string StrWhere\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            get { return _strwhere; }\r\n");
            strTableList.Append("            set { _strwhere = value; }\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 成员列表\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        protected List<" + NamespaceName + ".Model." + tabName + "> " + tabName + "List\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            get\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                return " + NamespaceName + ".BLL." + tabName + ".Instance.GetListByPage(\"*\", StrWhere, \"ID DESC\", 2, this.PageSize, this.CurrentPage, out TotalRecords, out TotalPages);\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 查询\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        private void Search()\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            if (!string.IsNullOrEmpty(Request.QueryString[\"KeyWord\"]))\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                string keyWord = Request.QueryString[\"KeyWord\"];\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("                this.StrWhere += string.Format(\" and title LIKE '%{0}%'\", keyWord);\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 删除\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        private void DeleteSave()\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            if (Request.QueryString[\"action\"] == \"delete\")\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                int id = Convert.ToInt32(Request.QueryString[\"ID\"]);\r\n");
            strTableList.Append("                " + NamespaceName + ".BLL." + tabName + ".Instance.Delete(id);\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            if (Request.Form[\"btnDelete\"] == \"删除\")\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                string idList = Request.Form[\"chkID\"];\r\n");
            strTableList.Append("                string[] arrID = idList.Split(',');\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("                foreach(string id in arrID )\r\n");
            strTableList.Append("                {\r\n");
            strTableList.Append("                    " + NamespaceName + ".BLL." + tabName + ".Instance.Delete(int.Parse(id));\r\n");
            strTableList.Append("                }\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            \r\n");
            strTableList.Append("        }\r\n");
            if (isSort)
            {
                strTableList.Append("        /// <summary>\r\n");
                strTableList.Append("        /// 保存排序\r\n");
                strTableList.Append("        /// </summary>\r\n");
                strTableList.Append("        private void SortSave()\r\n");
                strTableList.Append("        {\r\n");
                strTableList.Append("            if (Request.Form[\"btnSort\"] == \"保存排序\")\r\n");
                strTableList.Append("            {\r\n");
                strTableList.Append("                string idList = Request.Form[\"ID\"];\r\n");
                strTableList.Append("                string sortList = Request.Form[\"Sort\"];\r\n");
                strTableList.Append("\r\n");
                strTableList.Append("                string[] arrID = idList.Split(',');\r\n");
                strTableList.Append("                string[] arrSort = sortList.Split(',');\r\n");
                strTableList.Append("\r\n");
                strTableList.Append("                for (int i = 0; i < arrID.Length; i++)\r\n");
                strTableList.Append("                {\r\n");
                strTableList.Append("                    if (" + NamespaceName + ".Common.Helper.ValidateHelper.IsNumber(arrSort[i]))\r\n");
                strTableList.Append("                    {\r\n");
                strTableList.Append("                        " + NamespaceName + ".BLL." + tabName + ".Instance.UpdateSort(int.Parse(arrID[i]), int.Parse(arrSort[i]));\r\n");
                strTableList.Append("                    }\r\n");
                strTableList.Append("                    else\r\n");
                strTableList.Append("                    {\r\n");
                strTableList.Append("                        " + NamespaceName + ".Common.Helper.JscriptHelper.AlertReturn(\"排序必须为数字!\");\r\n");
                strTableList.Append("                    }\r\n");
                strTableList.Append("                }\r\n");
                strTableList.Append("            }\r\n");
                strTableList.Append("        }\r\n");
            }
            strTableList.Append("    }\r\n");
            strTableList.Append("}\r\n");
            strTableList.Append("\r\n");

            return strTableList;

        }

        /// <summary>
        /// 修改排序
        /// </summary>
        /// <param name="tabName"></param>
        /// <returns></returns>
        public static StringBuilder UpdateSort(string tabName)
        {
            StringBuilder strTableList = new StringBuilder();
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 修改排序\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public int " + tabName + "UpdateSort(int ID,int sort)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            StringBuilder strSql = new StringBuilder();\r\n");
            strTableList.Append("            strSql.Append(\"update " + tabName + " set \");\r\n");
            strTableList.Append("            strSql.Append(\"Sort=@Sort\");\r\n");
            strTableList.Append("            strSql.Append(\" where ID=@ID\");\r\n");
            strTableList.Append("            SqlParameter[] parameters = {\r\n");
            strTableList.Append("		            new SqlParameter(\"@ID\", SqlDbType.Int,4),\r\n");
            strTableList.Append("		            new SqlParameter(\"@Sort\", SqlDbType.Int,4)};\r\n");
            strTableList.Append("            parameters[0].Value = ID;\r\n");
            strTableList.Append("            parameters[1].Value = sort;\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);\r\n");
            strTableList.Append("        }\r\n");

            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 修改排序\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public int UpdateSort(int ID, int sort)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            return SQLServerDAL.DataProvider.Instance." + tabName + "UpdateSort(ID, sort);\r\n");
            strTableList.Append("        }\r\n");

            return strTableList;

        }

        /// <summary>
        /// 选择下拉选项
        /// </summary>
        /// <param name="tabName"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static StringBuilder SelectOptionsByDB(string tabName, string columnName)
        {
            StringBuilder strTableList = new StringBuilder();

            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 下拉选项\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        protected StringBuilder " + columnName + "Options\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            get\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                StringBuilder strTemp = new StringBuilder();\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("                List<Model." + columnName.Replace("ID", "") + "> lists = BLL." + columnName.Replace("ID", "") + ".Instance.GetList(-1, \"*\", \"\", \"SORT ASC\");\r\n");
            strTableList.Append("                foreach (Model." + columnName.Replace("ID", "") + " item in lists)\r\n");
            strTableList.Append("                {\r\n");
            strTableList.Append("                    strTemp.AppendFormat(\"<option value=\\\"{0}\\\">{1}</option>\",item.ID,item." + columnName.Replace("ID", "") + "Name);\r\n");
            strTableList.Append("                }\r\n");
            strTableList.Append("                return strTemp;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");

            return strTableList;

        }

        /// <summary>
        /// 选择下拉选项
        /// </summary>
        /// <param name="tabName"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static StringBuilder SelectOptionsByDBSelected(string tabName, string columnName)
        {
            StringBuilder strTableList = new StringBuilder();

            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 下拉选项\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        protected StringBuilder " + columnName + "Options\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            get\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                StringBuilder strTemp = new StringBuilder();\r\n");
            strTableList.Append("                string strSelect = string.Empty;\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("                List<Model." + columnName.Replace("ID", "") + "> lists = BLL." + columnName.Replace("ID", "") + ".Instance.GetList(-1, \"*\", \"\", \"SORT ASC\");\r\n");
            strTableList.Append("                foreach (Model." + columnName.Replace("ID", "") + " item in lists)\r\n");
            strTableList.Append("                {\r\n");
            strTableList.Append("                if (item.ID == model."+columnName+")\r\n");
            strTableList.Append("                    {\r\n");
            strTableList.Append("                        strSelect = \"selected\";\r\n");
            strTableList.Append("                    }\r\n");
            strTableList.Append("                 else\r\n");
            strTableList.Append("                    {\r\n");
            strTableList.Append("                        strSelect = string.Empty;\r\n");
            strTableList.Append("                    }\r\n");
            strTableList.Append("                    strTemp.AppendFormat(\"<option value=\\\"{0}\\\" {1} >{2}</option>\",item.ID,strSelect,item." + columnName.Replace("ID", "") + "Name);\r\n");
            strTableList.Append("                }\r\n");
            strTableList.Append("                return strTemp;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");

            return strTableList;

        }

        public static StringBuilder SelectOptionView(string tabName)
        {
            StringBuilder strTableList = new StringBuilder();
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 获取名称\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public string Get" + tabName + "Name(int ID)\r\n");
            strTableList.Append("        {\r\n");
            strTableList.Append("            object obj=SQLServerDAL.DataProvider.Instance.GetSingle(\"" + tabName + "Name\", \"" + tabName + "\", string.Format(\"ID={0}\", ID));\r\n");
            strTableList.Append("            if(obj ==null )\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                return string .Empty ;\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("            else\r\n");
            strTableList.Append("            {\r\n");
            strTableList.Append("                return Convert .ToString (obj );\r\n");
            strTableList.Append("            }\r\n");
            strTableList.Append("        }\r\n");

            strTableList.Append("        \r\n");
            strTableList.Append("        \r\n");
            strTableList.Append("<%="+NamespaceName+".BLL."+tabName+".Instance.Get"+tabName+"Name(item."+tabName+"ID)%>\r\n");


            return strTableList;


        }
       



    }

}
