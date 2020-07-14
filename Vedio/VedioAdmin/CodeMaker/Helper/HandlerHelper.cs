using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMaker.Helper
{
    public class HandlerHelper
    {
        /// <summary>
        /// 生成Model
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="namespacestr"></param>
        /// <returns></returns>
        public static StringBuilder CreateModel(string TableName,string Columns, string namespacestr= "Entity")
        {
            System.Text.StringBuilder strTableList = new StringBuilder();
            strTableList.Append("using System;\r\n");
            strTableList.Append("namespace "+ namespacestr + "\r\n");
            strTableList.Append("{\r\n");
            strTableList.Append("    /// <summary>\r\n");
            strTableList.Append("    /// 实体类" + TableName + "(属性说明自动提取数据库字段的描述信息)\r\n");
            strTableList.Append("    /// </summary>\r\n");
            strTableList.Append("    public class M" + TableName + "\r\n");
            strTableList.Append("    {\r\n");
            strTableList.Append("        public M" + TableName + "()\r\n");
            strTableList.Append("        { }\r\n");
            strTableList.Append("        #region Model\r\n");

            DataSet ds = SQLHelper.ExecuteDataSet(" exec SysTable  '" + TableName + "'");
            strTableList.Append("\r\n");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string description = row["description"].ToString();

                string str = row["column_name"].ToString();

                if (Columns.IndexOf("|" + str + "|") > -1)
                {
                    string tt = "";
                    tt = getType(row["data_Type"].ToString());

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
        public static StringBuilder CreateDAL(string TableName, string Columns, string namespacestr = "DAL")
        {
            StringBuilder strTableList = new StringBuilder();

            strTableList.Append("using System;\r\n");
            strTableList.Append("using System.Collections.Generic;\r\n");
            strTableList.Append("using System.Text;\r\n");
            strTableList.Append("using System.Data;\r\n");
            strTableList.Append("using System.Data.SqlClient;\r\n");
            strTableList.Append("\r\n");
            strTableList.Append("namespace " + namespacestr + "\r\n");
            strTableList.Append("{\r\n");
            strTableList.Append("    /// <summary>\r\n");
            strTableList.Append("    /// " + TableName + "\r\n");
            strTableList.Append("    /// </summary>\r\n");
            strTableList.Append("    public  class D"+TableName+"\r\n");
            strTableList.Append("    {\r\n");

            DataSet ds = SQLHelper.ExecuteDataSet(" exec SysTable  '" + TableName + "'");
         
            strTableList.Append(CreateAdd(TableName,Columns, ds));
            strTableList.Append(CreateUpdate(TableName, Columns, ds));
            //strTableList.Append(GetModel(tableName));

            strTableList.Append("    }\r\n");
            strTableList.Append("}\r\n");

            return strTableList;
        }
        public static StringBuilder CreateAdd(string tableName, string Columns, DataSet ds)
        {
            StringBuilder strTableList = new StringBuilder();
            strTableList.Append("        /// <summary>\r\n");
            strTableList.Append("        /// 增加一条数据(表" + tableName + ")\r\n");
            strTableList.Append("        /// </summary>\r\n");
            strTableList.Append("        public int Add(M" + tableName + " model)\r\n");
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
            string temp1 = Columns.Replace("|" + identityCooumnName, "").Replace('|', ',');
            string temp2 = Columns.Replace("|" + identityCooumnName, "").Replace("|", ",@");

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
                if (Columns.IndexOf("|" + str + "|") > -1)
                {
                    if (GetDBType(row["data_type"].ToString()) == "Text" || GetDBType(row["data_type"].ToString()) == "NText")
                    {
                        strTableList.Append("		            new SqlParameter(\"@" + str + "\", SqlDbType." + GetDBType(row["data_type"].ToString()) + "),\r\n");
                    }
                    else
                    {
                        strTableList.Append("		            new SqlParameter(\"@" + str + "\", SqlDbType." + GetDBType(row["data_type"].ToString()) + "," + row["占用字节数"].ToString() + "),\r\n");
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
                if (Columns.IndexOf("|" + str + "|") > -1)
                {
                    strTableList.Append("            parameters[" + j.ToString() + "].Value = model." + str + ";\r\n");
                    j++;
                }
            }

            strTableList.Append("\r\n              return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);\r\n");
            strTableList.Append("        }\r\n");

            return strTableList;
        }

        public static string CreateUpdate(string tableName, string Columns, DataSet ds)
        {
            string tempUpdateString = "";
            tempUpdateString = "";
            tempUpdateString += "    /// <summary>\r\n";
            tempUpdateString += "    /// 修改数据(表" + tableName + ")\r\n";
            tempUpdateString += "    /// </summary>\r\n";
            tempUpdateString += "    public int Update(M." + tableName + " model)\r\n";
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
                    if (Columns.IndexOf("|" + str + "|") > -1)
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
                    if (Columns.IndexOf("|" + str + "|") > -1)
                    {
                        if (GetDBType(row["data_type"].ToString()) == "Text" || GetDBType(row["data_type"].ToString()) == "NText")
                        {
                            tempUpdateString += "               new SqlParameter(\"@" + str + "\", SqlDbType." + GetDBType(row["data_type"].ToString()) + "),\r\n";
                        }
                        else
                        {
                            tempUpdateString += "               new SqlParameter(\"@" + str + "\", SqlDbType." + GetDBType(row["data_type"].ToString()) + "," + row["占用字节数"].ToString() + "),\r\n";
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

                if (Columns.IndexOf("|" + str + "|") > -1)
                {
                    tempUpdateString += "    	parameters[" + i.ToString() + "].Value = model." + str + ";\r\n";
                    i++;
                }

            }
            tempUpdateString += "\r\n      return SQLHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);\r\n        }\r\n";

            return tempUpdateString;
        }


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
        private static string GetDBType(string instr)
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

    }
}
