using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace acode
{
    public partial class frmOften : Form
    {
        public frmOften()
        {
            InitializeComponent();
        }

        #region =====css总文件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.txtValue.Text = GetAdminCss.ToString();
        }
        /// <summary>
        /// css总文件
        /// </summary>
        protected StringBuilder GetAdminCss
        {
            get
            {
                StringBuilder strTableList = new StringBuilder();

                strTableList.Append("\r\n");
                strTableList.Append("html, body\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    width: 100%;\r\n");
                strTableList.Append("    height: 100%;\r\n");
                strTableList.Append("    margin: 0;\r\n");
                strTableList.Append("    padding: 0;\r\n");
                strTableList.Append("    background: #fff;\r\n");
                strTableList.Append("    font: 12px/19px '宋体';\r\n");
                strTableList.Append("    color: #000;\r\n");
                strTableList.Append("    text-align: center;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append("\r\n");
                strTableList.Append("a\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    color: #333;\r\n");
                strTableList.Append("    text-decoration: none;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append("a:hover\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    color: #f60;\r\n");
                strTableList.Append("    text-decoration: underline;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append(".publicTableA\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    color: red;\r\n");
                strTableList.Append("    text-decoration: underline;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append(".tableTopTd\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    height: 30px;\r\n");
                strTableList.Append("    background-color: #6699CC;\r\n");
                strTableList.Append("    color: #ffffff;\r\n");
                strTableList.Append("    text-align: center;\r\n");
                strTableList.Append("    font-size: 12px;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append(".tableTd\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    background-color: #ffffff;\r\n");
                strTableList.Append("    color: #000000;\r\n");
                strTableList.Append("    font-size: 12px;\r\n");
                strTableList.Append("    height: 30px;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append(".tableTdLeft\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    background-color: #ffffff;\r\n");
                strTableList.Append("    color: #000000;\r\n");
                strTableList.Append("    font-size: 12px;\r\n");
                strTableList.Append("    height: 30px;\r\n");
                strTableList.Append("    text-align: right;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append(".tableTdRight\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    background-color: #ffffff;\r\n");
                strTableList.Append("    color: #000000;\r\n");
                strTableList.Append("    font-size: 12px;\r\n");
                strTableList.Append("    height: 30px;\r\n");
                strTableList.Append("    text-align: left;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append("\r\n");
                strTableList.Append(".tableList\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    border-collapse: collapse;\r\n");
                strTableList.Append("    margin: auto;\r\n");
                strTableList.Append("    margin-top: 30px;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append("\r\n");
                strTableList.Append(".tableList td\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    height: 30px;\r\n");
                strTableList.Append("    border: #99CCFF 1px solid;\r\n");
                strTableList.Append("    padding: 0px 8px 0px 8px;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append("\r\n");
                strTableList.Append(".tableList tr.title\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    height: 30px;\r\n");
                strTableList.Append("    color: #ffffff;\r\n");
                strTableList.Append("    background-color: #6699cc;\r\n");
                strTableList.Append("    border: #99CCFF 1px solid;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append("\r\n");
                strTableList.Append(".tableList td.noneLeft\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    background-color: #ffffff;\r\n");
                strTableList.Append("    border: 0px;\r\n");
                strTableList.Append("    padding-left: 8px;\r\n");
                strTableList.Append("    text-align: left;\r\n");
                strTableList.Append("    color: #000000;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append("\r\n");
                strTableList.Append(".tableList td.noneCenter\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    background-color: #ffffff;\r\n");
                strTableList.Append("    border: 0px;\r\n");
                strTableList.Append("    padding-left: 8px;\r\n");
                strTableList.Append("    text-align: center;\r\n");
                strTableList.Append("    color: #000000;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append("\r\n");
                strTableList.Append(".tableAddOrUpdate\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    margin: auto;\r\n");
                strTableList.Append("    margin-top: 30px;\r\n");
                strTableList.Append("    background-color: #99ccff;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append("\r\n");
                strTableList.Append("\r\n");
                strTableList.Append(".NewPage\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    padding: 3px;\r\n");
                strTableList.Append("    margin: 5px;\r\n");
                strTableList.Append("    text-align: center;\r\n");
                strTableList.Append("    font-family: Arial, Helvetica, sans-serif;\r\n");
                strTableList.Append("    color: #b8b8b8;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append(".NewPage A\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    border: 1px solid #CCC;\r\n");
                strTableList.Append("    padding-left: 9px;\r\n");
                strTableList.Append("    padding-right: 9px;\r\n");
                strTableList.Append("    padding-bottom: 4px;\r\n");
                strTableList.Append("    padding-top: 4px;\r\n");
                strTableList.Append("    text-decoration: none;\r\n");
                strTableList.Append("    margin-right: 3px;\r\n");
                strTableList.Append("    color: #b8b8b8;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append(".NewPage A:hover\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    padding-left: 9px;\r\n");
                strTableList.Append("    padding-right: 9px;\r\n");
                strTableList.Append("    padding-bottom: 4px;\r\n");
                strTableList.Append("    padding-top: 4px;\r\n");
                strTableList.Append("    border: 1px solid #ff6600;\r\n");
                strTableList.Append("    text-decoration: none;\r\n");
                strTableList.Append("    margin-right: 3px;\r\n");
                strTableList.Append("    background-color: #ff6600;\r\n");
                strTableList.Append("    color: #fff;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append(".NewPage A:active\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    padding-left: 9px;\r\n");
                strTableList.Append("    padding-right: 9px;\r\n");
                strTableList.Append("    padding-bottom: 4px;\r\n");
                strTableList.Append("    padding-top: 4px;\r\n");
                strTableList.Append("    border: 1px solid #ff6600;\r\n");
                strTableList.Append("    text-decoration: none;\r\n");
                strTableList.Append("    margin-right: 3px;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append(".NewPage .current\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    padding-left: 9px;\r\n");
                strTableList.Append("    padding-right: 9px;\r\n");
                strTableList.Append("    padding-bottom: 4px;\r\n");
                strTableList.Append("    padding-top: 4px;\r\n");
                strTableList.Append("    border: 1px solid #ff6600;\r\n");
                strTableList.Append("    background-color: #ff6600;\r\n");
                strTableList.Append("    color: #fff;\r\n");
                strTableList.Append("    text-decoration: none;\r\n");
                strTableList.Append("    margin-right: 3px;\r\n");
                strTableList.Append("    margin-left: 5px;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append(".NewPage .disabled\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    border: 1px solid #ccc;\r\n");
                strTableList.Append("    padding-left: 9px;\r\n");
                strTableList.Append("    padding-right: 9px;\r\n");
                strTableList.Append("    padding-bottom: 4px;\r\n");
                strTableList.Append("    padding-top: 4px;\r\n");
                strTableList.Append("    text-decoration: none;\r\n");
                strTableList.Append("    color: #999;\r\n");
                strTableList.Append("    margin-right: 3px;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append(".NewPage .Total\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    padding-left: 10px;\r\n");
                strTableList.Append("    padding-right: 10px;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append(".NewPage .input\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    width: 30px;\r\n");
                strTableList.Append("    padding: 0px;\r\n");
                strTableList.Append("    margin: 0px;\r\n");
                strTableList.Append("    border: 1px solid #CACACA;\r\n");
                strTableList.Append("    height: 18px;\r\n");
                strTableList.Append("    line-height: 18px;\r\n");
                strTableList.Append("    text-indent: 2px;\r\n");
                strTableList.Append("    margin-left: 2px;\r\n");
                strTableList.Append("    margin-right: 2px;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append(".NewPage .button\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    width: 40px;\r\n");
                strTableList.Append("    padding: 0px;\r\n");
                strTableList.Append("    margin: 0px;\r\n");
                strTableList.Append("    border: 1px solid #CACACA;\r\n");
                strTableList.Append("    height: 20px;\r\n");
                strTableList.Append("    line-height: 20px;\r\n");
                strTableList.Append("    background-image: url(search/btn11.jpg);\r\n");
                strTableList.Append("    margin-left: 5px;\r\n");
                strTableList.Append("    font-family: Arial, Helvetica, sans-serif;\r\n");
                strTableList.Append("    cursor: pointer;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append("\r\n");
                strTableList.Append("p#vtip\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    position: absolute;\r\n");
                strTableList.Append("    padding: 10px;\r\n");
                strTableList.Append("    left: 5px;\r\n");
                strTableList.Append("    font-size: 0.8em;\r\n");
                strTableList.Append("    background-color: white;\r\n");
                strTableList.Append("    border: 1px solid #a6c9e2;\r\n");
                strTableList.Append("    -moz-border-radius: 5px;\r\n");
                strTableList.Append("    -webkit-border-radius: 5px;\r\n");
                strTableList.Append("    z-index: 9999;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append("p#vtip #vtipArrow\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    position: absolute;\r\n");
                strTableList.Append("    top: -10px;\r\n");
                strTableList.Append("    left: 5px;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append(".input_validation-failed\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    border: 2px solid #FF0000;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append(".select_validation-failed\r\n");
                strTableList.Append("{\r\n");
                strTableList.Append("    color: red;\r\n");
                strTableList.Append("}\r\n");
                strTableList.Append("\r\n");



                return strTableList;

            }
        }
        #endregion

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            this.txtValue.Text = GetMainHtml.ToString();
        }
        /// <summary>
        /// mail.html
        /// </summary>
        protected StringBuilder GetMainHtml
        {
            get 
            {
                StringBuilder strTableList = new StringBuilder();
                strTableList.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">\r\n");
                strTableList.Append("<html>\r\n");
                strTableList.Append("<head>\r\n");
                strTableList.Append("    <title>管理中心</title>\r\n");
                strTableList.Append("    <meta content=\"text/html; charset=gb2312\" http-equiv=\"Content-Type\">\r\n");
                strTableList.Append("    <link rel=\"stylesheet\" type=\"text/css\" href=\"css/index.css\">\r\n");
                strTableList.Append("    <style type=\"text/css\">\r\n");
                strTableList.Append("        .navPoint\r\n");
                strTableList.Append("        {\r\n");
                strTableList.Append("            font-family: Webdings;\r\n");
                strTableList.Append("            color: white;\r\n");
                strTableList.Append("            font-size: 9pt;\r\n");
                strTableList.Append("            cursor: hand;\r\n");
                strTableList.Append("        }\r\n");
                strTableList.Append("    </style>\r\n");
                strTableList.Append("    <meta name=\"GENERATOR\" content=\"MSHTML 8.00.7600.16385\">\r\n");
                strTableList.Append("</head>\r\n");
                strTableList.Append("<body style=\"margin: 0px\" scroll=\"no\" bgcolor=\"#a0a0a0\">\r\n");
                strTableList.Append("    <script>\r\n");
                strTableList.Append("        if (self != top) { top.location = self.location; }\r\n");
                strTableList.Append("        function switchSysBar() {\r\n");
                strTableList.Append("            if (switchPoint.innerText == 3) {\r\n");
                strTableList.Append("                switchPoint.innerText = 4\r\n");
                strTableList.Append("                document.all(\"frmTitle\").style.display = \"none\"\r\n");
                strTableList.Append("            } else {\r\n");
                strTableList.Append("                switchPoint.innerText = 3\r\n");
                strTableList.Append("                document.all(\"frmTitle\").style.display = \"\"\r\n");
                strTableList.Append("            } \r\n");
                strTableList.Append("        }\r\n");
                strTableList.Append("    </script>\r\n");
                strTableList.Append("    <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" height=\"100%\">\r\n");
                strTableList.Append("        <tbody>\r\n");
                strTableList.Append("            <tr>\r\n");
                strTableList.Append("                <td id=\"frmTitle\" valign=\"center\" nowrap align=\"middle\">\r\n");
                strTableList.Append("                    <iframe style=\"z-index: 0; width: 184px; height: 100%; visibility: inherit\" id=\"carnoc\"\r\n");
                strTableList.Append("                        src=\"Left.aspx\" frameborder=\"0\" name=\"carnoc\" scrolling=\"yes\"></iframe>\r\n");
                strTableList.Append("                </td>\r\n");
                strTableList.Append("                <td style=\"width: 12pt\" class=\"division\">\r\n");
                strTableList.Append("                    <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" bgcolor=\"#799AE1\" height=\"100%\">\r\n");
                strTableList.Append("                        <tbody>\r\n");
                strTableList.Append("                            <tr>\r\n");
                strTableList.Append("                                <td style=\"height: 100%\" onclick=\"switchSysBar()\">\r\n");
                strTableList.Append("                                    <font style=\"color: #ffffff; font-size: 9pt; cursor: default\">\r\n");
                strTableList.Append("                                        <br>\r\n");
                strTableList.Append("                                        <br>\r\n");
                strTableList.Append("                                        <br>\r\n");
                strTableList.Append("                                        <br>\r\n");
                strTableList.Append("                                        <br>\r\n");
                strTableList.Append("                                        <br>\r\n");
                strTableList.Append("                                        <br>\r\n");
                strTableList.Append("                                        <span id=\"switchPoint\" class=\"navPoint\" title=\"关闭/打开左栏\">3</span><br>\r\n");
                strTableList.Append("                                        <br>\r\n");
                strTableList.Append("                                        <br>\r\n");
                strTableList.Append("                                        菜单收缩\r\n");
                strTableList.Append("                                        <br>\r\n");
                strTableList.Append("                                        <br>\r\n");
                strTableList.Append("                                        <br>\r\n");
                strTableList.Append("                                        <br>\r\n");
                strTableList.Append("                                        <br>\r\n");
                strTableList.Append("                                        <br>\r\n");
                strTableList.Append("                                        <br>\r\n");
                strTableList.Append("                                        <br>\r\n");
                strTableList.Append("                                        <br>\r\n");
                strTableList.Append("                                        <br>\r\n");
                strTableList.Append("                                        <br>\r\n");
                strTableList.Append("                                    </font>\r\n");
                strTableList.Append("                                </td>\r\n");
                strTableList.Append("                            </tr>\r\n");
                strTableList.Append("                        </tbody>\r\n");
                strTableList.Append("                    </table>\r\n");
                strTableList.Append("                </td>\r\n");
                strTableList.Append("                <td style=\"width: 100%\">\r\n");
                strTableList.Append("                    <iframe style=\"z-index: 1; width: 100%; height: 100%; visibility: inherit\" id=\"right\"\r\n");
                strTableList.Append("                        src=\"home.aspx\" frameborder=\"0\" name=\"right\" scrolling=\"yes\"></iframe>\r\n");
                strTableList.Append("                </td>\r\n");
                strTableList.Append("            </tr>\r\n");
                strTableList.Append("        </tbody>\r\n");
                strTableList.Append("    </table>\r\n");
                strTableList.Append("    <script>\r\n");
                strTableList.Append("        if (window.screen.width < '1024') { switchSysBar() }\r\n");
                strTableList.Append("    </script>\r\n");
                strTableList.Append("</body>\r\n");
                strTableList.Append("</html>\r\n");
                strTableList.Append("\r\n");

                return strTableList;

    
            }
        }

        private void btnIndexCss_Click(object sender, EventArgs e)
        {
            this.txtValue.Text = GetSqlText.ToString();
        }
        protected StringBuilder GetSqlText
        {
            get
            {
                StringBuilder strTableList = new StringBuilder();
                strTableList.Append("CREATE TABLE [dbo].[Accounts_AdminRoles](\r\n");
                strTableList.Append("	[AdminID] [int] NOT NULL CONSTRAINT [DF_Accounts_AdminRoles_AdminID]  DEFAULT ((9999)),\r\n");
                strTableList.Append("	[RoleID] [int] NOT NULL\r\n");
                strTableList.Append(") ON [PRIMARY]\r\n");

                strTableList.Append("\r\n\r\n");

                strTableList.Append("CREATE TABLE [dbo].[Accounts_PermissionCategories](\r\n");
                strTableList.Append("	[ID] [int] IDENTITY(1,1) NOT NULL,\r\n");
                strTableList.Append("	[CategoryName] [varchar](255) COLLATE Chinese_PRC_CI_AS NULL,\r\n");
                strTableList.Append(" CONSTRAINT [PK_Accounts_PermissionCategories] PRIMARY KEY CLUSTERED \r\n");
                strTableList.Append("(\r\n");
                strTableList.Append("	[ID] ASC\r\n");
                strTableList.Append(")WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]\r\n");
                strTableList.Append(") ON [PRIMARY]\r\n");

                strTableList.Append("\r\n\r\n");

                strTableList.Append("CREATE TABLE [dbo].[Accounts_Permissions](\r\n");
                strTableList.Append("	[ID] [int] IDENTITY(1,1) NOT NULL,\r\n");
                strTableList.Append("	[Name] [varchar](255) COLLATE Chinese_PRC_CI_AS NULL,\r\n");
                strTableList.Append("	[CategoryID] [int] NULL,\r\n");
                strTableList.Append("	[Url] [varchar](500) COLLATE Chinese_PRC_CI_AS NULL,\r\n");
                strTableList.Append("	[MenuName] [varchar](255) COLLATE Chinese_PRC_CI_AS NULL,\r\n");
                strTableList.Append("	[FlagKey] [varchar](100) COLLATE Chinese_PRC_CI_AS NULL,\r\n");
                strTableList.Append("	[IsView] [int] NULL,\r\n");
                strTableList.Append("	[OrderNum] [int] NULL CONSTRAINT [DF_Accounts_Permissions_Order_Num]  DEFAULT ((0)),\r\n");
                strTableList.Append(" CONSTRAINT [PK_Accounts_Permissions] PRIMARY KEY CLUSTERED \r\n");
                strTableList.Append("(\r\n");
                strTableList.Append("	[ID] ASC\r\n");
                strTableList.Append(")WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]\r\n");
                strTableList.Append(") ON [PRIMARY]\r\n");
                strTableList.Append("\r\n");
                strTableList.Append("GO\r\n");
                strTableList.Append("SET ANSI_PADDING OFF\r\n");
                strTableList.Append("GO\r\n");
                strTableList.Append("EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限名称*' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Accounts_Permissions', @level2type=N'COLUMN', @level2name=N'Name'\r\n");
                strTableList.Append("\r\n");
                strTableList.Append("GO\r\n");
                strTableList.Append("EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属分组*(下拉)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Accounts_Permissions', @level2type=N'COLUMN', @level2name=N'CategoryID'\r\n");
                strTableList.Append("\r\n");
                strTableList.Append("GO\r\n");
                strTableList.Append("EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Url地址*' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Accounts_Permissions', @level2type=N'COLUMN', @level2name=N'Url'\r\n");
                strTableList.Append("\r\n");
                strTableList.Append("GO\r\n");
                strTableList.Append("EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内部标识' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Accounts_Permissions', @level2type=N'COLUMN', @level2name=N'FlagKey'\r\n");
                strTableList.Append("\r\n");
                strTableList.Append("GO\r\n");
                strTableList.Append("EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否显示*' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Accounts_Permissions', @level2type=N'COLUMN', @level2name=N'IsView'\r\n");
                strTableList.Append("\r\n");
                strTableList.Append("GO\r\n");
                strTableList.Append("EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序*' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Accounts_Permissions', @level2type=N'COLUMN', @level2name=N'OrderNum'\r\n");
                strTableList.Append("\r\n");

                strTableList.Append("\r\n\r\n");

                strTableList.Append("CREATE TABLE [dbo].[Accounts_RolePermissions](\r\n");
                strTableList.Append("	[RoleID] [int] NOT NULL,\r\n");
                strTableList.Append("	[PermissionID] [int] NOT NULL\r\n");
                strTableList.Append(") ON [PRIMARY]\r\n");

                strTableList.Append("\r\n\r\n");

                strTableList.Append("CREATE TABLE [dbo].[Accounts_Roles](\r\n");
                strTableList.Append("	[ID] [int] IDENTITY(1,1) NOT NULL,\r\n");
                strTableList.Append("	[Name] [varchar](255) COLLATE Chinese_PRC_CI_AS NULL,\r\n");
                strTableList.Append(" CONSTRAINT [PK_Accounts_Roles] PRIMARY KEY CLUSTERED \r\n");
                strTableList.Append("(\r\n");
                strTableList.Append("	[ID] ASC\r\n");
                strTableList.Append(")WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]\r\n");
                strTableList.Append(") ON [PRIMARY]\r\n");
                strTableList.Append("\r\n");
                strTableList.Append("GO\r\n");
                strTableList.Append("SET ANSI_PADDING OFF\r\n");
                strTableList.Append("GO\r\n");
                strTableList.Append("EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称*' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Accounts_Roles', @level2type=N'COLUMN', @level2name=N'Name'\r\n");

                strTableList.Append("\r\n\r\n");

                strTableList.Append("CREATE TABLE [dbo].[Accouts_Admin](\r\n");
                strTableList.Append("	[ID] [int] IDENTITY(1,1) NOT NULL,\r\n");
                strTableList.Append("	[Name] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,\r\n");
                strTableList.Append("	[UserName] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,\r\n");
                strTableList.Append("	[Password] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,\r\n");
                strTableList.Append("	[Mobile] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,\r\n");
                strTableList.Append("	[Logout] [bit] NULL,\r\n");
                strTableList.Append("	[Province] [int] NULL CONSTRAINT [DF_Accouts_Admin_Province]  DEFAULT ((9999)),\r\n");
                strTableList.Append("	[City] [int] NULL CONSTRAINT [DF_Accouts_Admin_City]  DEFAULT ((99999)),\r\n");
                strTableList.Append(" CONSTRAINT [PK_Accouts_Admin ] PRIMARY KEY CLUSTERED \r\n");
                strTableList.Append("(\r\n");
                strTableList.Append("	[ID] ASC\r\n");
                strTableList.Append(")WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]\r\n");
                strTableList.Append(") ON [PRIMARY]\r\n");
                strTableList.Append("\r\n");
                strTableList.Append("GO\r\n");
                strTableList.Append("SET ANSI_PADDING OFF\r\n");
                strTableList.Append("GO\r\n");
                strTableList.Append("EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名*' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Accouts_Admin', @level2type=N'COLUMN', @level2name=N'Name'\r\n");
                strTableList.Append("\r\n");
                strTableList.Append("GO\r\n");
                strTableList.Append("EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名*' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Accouts_Admin', @level2type=N'COLUMN', @level2name=N'UserName'\r\n");
                strTableList.Append("\r\n");
                strTableList.Append("GO\r\n");
                strTableList.Append("EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码*' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Accouts_Admin', @level2type=N'COLUMN', @level2name=N'Password'\r\n");
                strTableList.Append("\r\n");
                strTableList.Append("GO\r\n");
                strTableList.Append("EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Accouts_Admin', @level2type=N'COLUMN', @level2name=N'Mobile'\r\n");
                strTableList.Append("\r\n");
                strTableList.Append("GO\r\n");
                strTableList.Append("EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'注销*' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Accouts_Admin', @level2type=N'COLUMN', @level2name=N'Logout'\r\n");
                strTableList.Append("\r\n");
                strTableList.Append("GO\r\n");
                strTableList.Append("EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理员省份默认9999为总站' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Accouts_Admin', @level2type=N'COLUMN', @level2name=N'Province'\r\n");
                strTableList.Append("\r\n");
                strTableList.Append("GO\r\n");
                strTableList.Append("EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理员城市默认99999为总站' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Accouts_Admin', @level2type=N'COLUMN', @level2name=N'City'\r\n");





                return strTableList;
            }
        }

        private void txtValue_DoubleClick(object sender, EventArgs e)
        {
            this.txtValue.SelectAll();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
